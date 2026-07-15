using TaskFlow.DataAccess.Data;
using TaskFlow.Models;

namespace TaskFlow.DataAccess.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
