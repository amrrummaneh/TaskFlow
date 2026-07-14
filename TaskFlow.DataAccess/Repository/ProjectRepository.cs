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
