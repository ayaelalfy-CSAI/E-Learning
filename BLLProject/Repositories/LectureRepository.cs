using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Repositories
{
    public class LectureRepository : GenericRepository<Lecture>
    {
        public LectureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
             
        }
    
    }
}
