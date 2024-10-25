using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Identity;
namespace DALProject.Models
{
    public class ApplicationUser : IdentityUser, IModelBase
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int? InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
