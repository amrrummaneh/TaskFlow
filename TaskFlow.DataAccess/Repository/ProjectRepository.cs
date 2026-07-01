using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Data;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repository
{
    public class ProjectRepository :Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
