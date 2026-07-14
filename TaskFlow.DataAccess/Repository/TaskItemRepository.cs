using TaskFlow.DataAccess.Data;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repository
{
    public class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
    {
        private readonly ApplicationDbContext _db;

        public TaskItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}