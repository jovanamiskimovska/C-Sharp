using Newtonsoft.Json;
using SEDC.TimeTracking.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SEDC.TimeTracking.Domain.Database
{
    public class FileDb<T> : IDatabase<T> where T : BaseEntity
    {
        private string _folderPath;
        private string _filePath;
        private int _id;

        public FileDb()
        {
            _id = 0;
            _folderPath = @"..\..\..\Db";
            _filePath = _folderPath + $@"\{typeof(T).Name}s.json";
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
                WriteData(new List<T>());
            }
        }
        public List<T> GetAll()
        {
            return GetAllEntititiesFromDb();
        }

        public T GetById(int id)
        {
            List<T> allDbEntities = GetAllEntititiesFromDb();
            return allDbEntities.FirstOrDefault(x => x.Id == id);

        }

        public int Insert(T entity)
        {
            List<T> allDbEntities = GetAllEntititiesFromDb();
            if (allDbEntities == null)
            {
                allDbEntities = new List<T>();
                _id = 1;
            }
            if (allDbEntities.Count == 0)
            {
                _id = 1;
            }
            else
            {
                _id = allDbEntities.Count + 1;
            }
            entity.Id = _id;
            allDbEntities.Add(entity);
            WriteData(allDbEntities);
            return entity.Id;
        }

        public void RemoveById(int id)
        {
            List<T> allDbEntities = GetAllEntititiesFromDb();
            T entityDb = allDbEntities.FirstOrDefault(x => x.Id == id);
            if(entityDb == null)
            {
                throw new Exception($"The entity with id: {id} was not found in the database!");
            }
            allDbEntities.Remove(entityDb);
            WriteData(allDbEntities);
        }

        public void Update(T entity)
        {
            List<T> allDbEntities = GetAllEntititiesFromDb();
            T entityDb = allDbEntities.FirstOrDefault(x => x.Id == entity.Id);
            if(entityDb == null)
            {
                throw new Exception($"The entity with id: {entity.Id} was not found in the database!");
            }
            allDbEntities[allDbEntities.IndexOf(entityDb)] = entity;
            WriteData(allDbEntities);
        }
        private void WriteData(List<T> dbEntities)
        {
            using (StreamWriter dataStreamWriter = new StreamWriter(_filePath))
            {
                dataStreamWriter.WriteLine(JsonConvert.SerializeObject(dbEntities));
            }
        }
        private List<T> GetAllEntititiesFromDb()
        {
            using(StreamReader dataStreamReader = new StreamReader(_filePath))
            {
                return JsonConvert.DeserializeObject<List<T>>(dataStreamReader.ReadToEnd());
            }
        }
    }
}
