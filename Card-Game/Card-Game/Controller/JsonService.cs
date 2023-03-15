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
            fileName = "C:\\mvp\\mvp-tema1\\Card-Game\\Card-Game\\Asset\\Data\\" + fileName;
            string jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(fileName, jsonString);            
        }
    }
}
