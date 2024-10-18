using BLLProject.Interfaces;
using DALProject.Models;
using DALProject;
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
            // Inject
            private readonly ApplicationDbContext dbContext;
            public GenericRepository(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            // Add
            public int Add(T entity)
            {
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }

            // Update
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

            // GetAll
            public IEnumerable<T> GetAll() =>
                dbContext.Set<T>().AsNoTracking().ToList();

        //Get
        public T Get(int id)
        {
            var entity = dbContext.Set<T>().Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} was not found.");
            }
            return entity;
        }



    }
    }

