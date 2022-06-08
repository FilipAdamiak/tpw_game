using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace Data
{
    internal class BallLogger : AbstractBallLogger
    {
        private readonly string _path;
        private Task _logTask;
        private readonly ConcurrentQueue<JObject> _logQueue;
        private readonly JArray _logArray;
        private readonly Mutex _ballsMutex = new Mutex();
        private readonly Mutex _fileMutex = new Mutex();


        public BallLogger()
        {
            string tempPath = Path.GetTempPath();
            _path =  tempPath + "BallsLog.json";
            _logQueue = new ConcurrentQueue<JObject>();
            if (File.Exists(_path))
            {
                try
                {
                    string input = File.ReadAllText(_path);
                    _logArray = JArray.Parse(input);
                    return;
                }
                catch (JsonReaderException)
                {
                    _logArray = new JArray();
                }
            }

            _logArray = new JArray();
            File.Create(_path);
        }

        public override void EnqueueToLoggingQueue(BallEntity ball)
        {
            _ballsMutex.WaitOne();
            try
            {
                JObject timeObject = JObject.FromObject(ball);
                timeObject["Time"] = DateTime.Now.ToString("HH:mm:ss");

                _logQueue.Enqueue(timeObject);

                if (_logTask == null || _logTask.IsCompleted)
                {
                    _logTask = Task.Factory.StartNew(WriteLogToFile);
                }
            }
            finally
            {
                _ballsMutex.ReleaseMutex();
            }
        }
        private void WriteLogToFile()
        {
            while (_logQueue.TryDequeue(out JObject ball)) {
                _logArray.Add(ball);
            }
            string output = JsonConvert.SerializeObject(_logArray);
            _fileMutex.WaitOne();
            try
            {
                File.WriteAllText(_path, output);
            }
            finally
            {
                _fileMutex.ReleaseMutex();
            }

        }
    }
}
