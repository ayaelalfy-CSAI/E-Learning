using DALProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Repositories
{
    public class UserRepository :GenericRepository<ApplicationUser>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
