using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.Repositories
{
    public class BaseRepository<T> where T:BaseModel, new()
    {
        private readonly DbSet<T> dbSet;
        private readonly AppContext context;
        

        public BaseRepository()
        {
            this.context = new AppContext();
            this.dbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        private void Insert(T item)
        {
            this.dbSet.Add(item);
        }

        private void Update(T item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }

        public void Save(T item)
        {
            if (item.ID != 0)
                Update(item);
            else
                Insert(item);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.dbSet.Remove(GetById(id));
            this.context.SaveChanges();
        }

    }
}