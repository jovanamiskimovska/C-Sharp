﻿using SEDC.TimeTracking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.TimeTracking.Domain.Database
{
    public class Database<T> : IDatabase<T> where T : BaseEntity
    {
        private List<T> _table { get; set; }
        public int Id { get; set; }
        public Database()
        {
            _table = new List<T>();
            Id = 1;
        }
        public List<T> GetAll()
        {
            return _table;
        }

        public T GetById(int id)
        {
            T databaseEntity = _table.FirstOrDefault(x => x.Id == id);
            if(databaseEntity == null)
            {
                throw new Exception($"Entity with id {id} was not found!");
            }
            return databaseEntity;
        }

        public int Insert(T entity)
        {
            entity.Id = Id++;
            _table.Add(entity);
            return entity.Id;
        }

        public void RemoveById(int id)
        {
            T databaseEntity = _table.FirstOrDefault(x => x.Id == id);
            if(databaseEntity == null)
            {
                throw new Exception($"Entity with id {id} was not found!");
            }
            _table.Remove(databaseEntity);
        }

        public void Update(T entity)
        {
            T databaseEntity = _table.FirstOrDefault(x => x.Id == entity.Id);
            if(databaseEntity == null)
            {
                throw new Exception($"Entity with id {entity.Id} was not found!");
            }
            databaseEntity = entity;
        }
    }
}
