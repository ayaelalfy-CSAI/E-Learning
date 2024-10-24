using DALProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Interfaces
{
    public interface IGenericRepository<T> where T: ModelBase
    {

        //ADD
        public int Add(T entity);

        //Update
        public int Update(T entity);                   

        //Delete
        public int Delete(T entity);     

        //GetById  
        public T GetById(int id);

        //GetALL
        public IQueryable<T> GetAll();


    }
}
