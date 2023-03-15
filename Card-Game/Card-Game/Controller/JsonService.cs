using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Card_Game
{
    public class JsonService
    {
        public static void SerializeToFile<ObjectToSerializeType>(string fileName, ObjectToSerializeType obj)
        { 
            string jsonString = JsonSerializer.Serialize(obj);
            Console.WriteLine(jsonString);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine(File.ReadAllText(fileName));
            
        }
    }
}
