using BLLProject.Interfaces;
using DALProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        // inject                                             
        private readonly ApplicationDbContext dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //ADD
        public int Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            return dbContext.SaveChanges();
        }

        //Update
        public int Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return dbContext.SaveChanges();
        }

        //Delete
        public int Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return dbContext.SaveChanges();
        }

        //GetById
        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);

            //var entity = dbContext.Set<T>().Find(id);
            //if (entity == null)
            //{
            //    throw new InvalidOperationException("Entity not found");
            //}
            //return entity;
        }

        //GetALL
        public IQueryable<T> GetAll() => dbContext.Set<T>().AsNoTracking();


    }

}
