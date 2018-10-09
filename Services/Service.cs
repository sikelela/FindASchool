using FindASchool.Models;
using System.Linq;
using System.Collections.Generic;

public class Service : IService
{
    private readonly SchoolContext _context;

    public Service(SchoolContext ctx){
         _context = ctx;
    }

    public School GetSchool(int schooolID)
    {
        var school = from scl in _context.School where scl.SchoolID == schooolID select scl;
        if (school.Count() == 1)
        {
            return school.First();
        }
        return null;
    }

    
    public List<School> GetAllSchools()
    {
        var school = from scl in _context.School select scl;
        return school.ToList();
    }
}

public interface IService
{
    School GetSchool(int schooolID);
    List<School> GetAllSchools();
}