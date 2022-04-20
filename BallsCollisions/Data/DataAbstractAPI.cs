using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateDataAPI()
        {
            return new DataLayer();
        }
        
    }
    public class DataLayer : DataAbstractAPI
    {
        public DataLayer() { }
    }
}
