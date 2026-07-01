using Microsoft.AspNetCore.Mvc;
using TaskFlow.DataAccess.Repository;

namespace TaskFlow.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork; 
        }
        public IActionResult Index()
        {
            var projects = _unitOfWork.Project.GetAll();
            return View(projects);
        }
    }
}
    