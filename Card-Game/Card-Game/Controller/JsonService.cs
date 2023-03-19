using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows;
using System.Text.Json.Serialization;

namespace Card_Game
{
    public class JsonService
    {
        public static void SerializeToFile<ObjectToSerializeType>(string fileName, ObjectToSerializeType obj)
        {
            fileName = "../../Asset/Data/" + fileName;
            string jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(fileName, jsonString);            
        }

        public static ObjectToDeserializeType DeserializeFromFile<ObjectToDeserializeType>(string fileName)
        {
            if (!(fileName[0] == 'C' && fileName[1] == ':'))
                fileName = "../../Asset/Data/" + fileName;

            var jsonData = File.ReadAllText(fileName);
            ObjectToDeserializeType result = JsonSerializer.Deserialize<ObjectToDeserializeType>(jsonData);
            return result;
        }

        public static void DeleteFileFromPath(string filePath)
        {
            try
            {
                filePath = "C:../../Asset/Data/" + filePath;
                //create a file sample.txt in current working directory 
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }

                // Delete the file
                File.Delete(filePath);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} is successfully deleted.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"File could not be deleted:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
