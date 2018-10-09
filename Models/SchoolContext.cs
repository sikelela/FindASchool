
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace FindASchool.Models
{
    public class SchoolContext: DbContext {  
        public SchoolContext(DbContextOptions <SchoolContext> options): base(options) {}  

        public DbSet<School> School {  
            get;  
            set;  
        }  
    }  
}