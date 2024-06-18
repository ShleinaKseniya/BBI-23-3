using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
#region Выберите библиотеку(и) для сериализации
// using Newtonsoft;
// using System.Text.Json;
// using System.Text.Json.Serialization;
#endregion


namespace Variant_2
{
    class Task4
    {
        static void Main()
        {
            DataSerializer serializer = new DataSerializer();

            Grep grep = new Grep("Example text");
            serializer.Write(grep, "grep.json");

            Grep readGrep = serializer.Read<Grep>("grep.json");
            Console.WriteLine(readGrep.Text);

            Creator creator = new Creator();
            creator.CreateFolder(".", "NewFolder");
            creator.CreateFile(".", "NewFile.txt");

            creator.CreateFolders(".", new string[] { "Folder1", "Folder2" });
            creator.CreateFiles(".", new string[] { "File1.txt", "File2.txt" });
        }
    }

    interface IDataSerializer
        {
            void Write<T>(T data, string path);
            T Read<T>(string path);
        }

        class DataSerializer : IDataSerializer
        {
            public void Write<T>(T data, string path)
            {
                string jsonData = JsonConvert.SerializeObject(data);
                File.WriteAllText(path, jsonData);
            }

            public T Read<T>(string path)
            {
                string jsonData = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
        }

        interface ICreator
        {
            void CreateFolder(string path, string folderName);
            void CreateFile(string path, string fileName);
            void CreateFolders(string path, string[] folderNames);
            void CreateFiles(string path, string[] fileNames);
        }

        class Creator : ICreator
        {
            public void CreateFolder(string path, string folderName)
            {
                Directory.CreateDirectory(Path.Combine(path, folderName));
            }

            public void CreateFile(string path, string fileName)
            {
                File.Create(Path.Combine(path, fileName)).Close();
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                foreach (string folderName in folderNames)
                {
                    Directory.CreateDirectory(Path.Combine(path, folderName));
                }
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                foreach (string fileName in fileNames)
                {
                    File.Create(Path.Combine(path, fileName)).Close();
                }
            }
        }

        class Grep
        {
            public string Text { get; set; }

            public Grep(string text)
            {
                Text = text;
            }
        }

    }


