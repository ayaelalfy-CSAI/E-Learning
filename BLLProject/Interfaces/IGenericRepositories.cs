using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALProject.Models;

namespace BLLProject.Interfaces
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        public int Add(T entity);
        public int Update(T entity);
        public int Delete(T entity);
        public IEnumerable<T> GetAll();
        public T Get(int id);
    }
}
