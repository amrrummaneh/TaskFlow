using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Data;

namespace TaskFlow.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IProjectRepository Project { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Project = new ProjectRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
