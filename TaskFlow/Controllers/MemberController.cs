using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using TaskFlow.DataAccess.Repository;
using TaskFlow.Models;

namespace TaskFlow.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myTasks = _unitOfWork.TaskItem.GetAll(includeProperties: "Project")
                .Where(t => t.AssignedUserId == currentUserId);

            return View(myTasks);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var task = _unitOfWork.TaskItem.Get(t => t.Id == id);

            if (task == null || task.AssignedUserId != currentUserId)
            {
                return Forbid();
            }

            task.Status = status;
            _unitOfWork.TaskItem.Update(task);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}