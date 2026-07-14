using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IProjectRepository Project { get; }
        ITaskItemRepository TaskItem { get; }
        void Save();
    }
}
