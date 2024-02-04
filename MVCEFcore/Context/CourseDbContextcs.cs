using Microsoft.EntityFrameworkCore;
using MVCEFcore.Models;
using System.Collections.Generic;

namespace MVCEFcore.Context
{
    public class CourseDbContext : DbContext
    {
 
            public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
            { }
            public DbSet<Course> Courses { get; set; }

        }
    }


