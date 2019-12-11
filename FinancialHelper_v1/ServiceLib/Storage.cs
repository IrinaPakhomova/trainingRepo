using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ServiceLib
{
    public class Storage
    {
        private const string fileStorage = @"operation.txt";

        public Storage()
        {  
        }

        public void WriteDataToStorage(OperationEntity op)
        {
            using (StreamWriter sw = new StreamWriter(fileStorage, true, System.Text.Encoding.Default))
            {
                string json = JsonConvert.SerializeObject(op);
                sw.WriteLine(json);
                Console.WriteLine("Запись выполнена");
            }
        }

        public List<OperationEntity> ReadDataFromStorage()
        {
            if (!File.Exists(fileStorage)) { return null; }

            List<OperationEntity> list = new List<OperationEntity>();
            using (StreamReader sr = new StreamReader(fileStorage, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(JsonConvert.DeserializeObject<OperationEntity>(line));
                }
            }
            return list;
        }
    }
}
