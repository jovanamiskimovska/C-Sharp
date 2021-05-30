using Domain.Models;
using System;
using System.IO;

namespace Domain.Services
{
    public class FileSystemService
    {
        public string ReadFileContent(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception($"[Error] File path - {path} was not found!");
            }
            string fileContent = string.Empty;
            using(StreamReader streamFileReader = new StreamReader(path))
            {
                fileContent = streamFileReader.ReadToEnd();
            }
            return fileContent;
        }

        public void WriteInFile(string path, string content)
        {
            using(StreamWriter streamFileWriter = new StreamWriter(path))
            {
                streamFileWriter.WriteLine(content);
            }
        }

        public void PrintDogs(Dog[] dogs)
        {
            foreach(Dog dog in dogs)
            {
                Console.WriteLine($"Id: {dog.Id}, Name: {dog.Name}, Color: {dog.Color}, Age: {dog.Age}");
            }
        }

    }
}
