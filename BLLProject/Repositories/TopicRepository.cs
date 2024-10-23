using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProject.Repositories
{
    public class TopicRepository : GenericRepository<Topic>
    {
        public TopicRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}  
    















