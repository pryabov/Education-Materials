using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialization_and_Deserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SomeClass> list = new List<SomeClass>
            {
                new SomeClass { Name = "user1", Date = new DateTime(2018,04,11), Value = 512 },
                new SomeClass { Name = "user2", Date = new DateTime(2018,04,12), Value = 1024 },
                new SomeClass { Name = "user3", Date = new DateTime(2018,04,13), Value = 2048 },
                new SomeClass { Name = "user4", Date = new DateTime(2018,04,14), Value = 4096 }
            };

            var xmlFileFullPath = XmlSerialization(list);

            if (XmlDeserialization<List<SomeClass>>(xmlFileFullPath, out List<SomeClass> newList))
            {
                //var jsonFileFullPath = JsonSerialization(list);

                //List<SomeClass> newList = JsonDeserialization<List<SomeClass>>(jsonFileFullPath);

                foreach (var item in newList)
                {
                    Console.WriteLine($"User: {item.Name}; Date: {item.Date}; Value: {item.Value}");
                }
            }
        }

        static string XmlSerialization<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            var xmlFileFullPath = $"{Directory.GetCurrentDirectory()}\\xmltest.xml";

            using (TextWriter writer = new StreamWriter(xmlFileFullPath))
            {
                xmlSerializer.Serialize(writer, obj);
            }

            return xmlFileFullPath;
        }

        static bool XmlDeserialization<T>(string xmlFileFulPath, out T result)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StreamReader(xmlFileFulPath))
            {
                try
                {
                    result = (T)xmlSerializer.Deserialize(reader);
                }
                catch
                {
                    result = default(T);

                    return false;
                }
            }

            return true;
        }

        static string JsonSerialization<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            var jsonFileFullPath = $"{Directory.GetCurrentDirectory()}\\jsontest.xml";

            using (TextWriter writer = new StreamWriter(jsonFileFullPath))
            {
                writer.Write(json);
            }

            return jsonFileFullPath;
        }

        static T JsonDeserialization<T>(string xmlFileFulPath)
        {
            T result;
            using (TextReader reader = new StreamReader(xmlFileFulPath))
            {
                result = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }

            return result;
        }
    }
}
