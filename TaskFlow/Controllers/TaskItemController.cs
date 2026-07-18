using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using TaskFlow.DataAccess.Repository;
using TaskFlow.Models;
using TaskFlow.Utility;

namespace TaskFlow.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class TaskItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskItemController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var taskItems = _unitOfWork.TaskItem.GetAll(includeProperties: "Project,AssignedUser");
            return View(taskItems);
        }
        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskItem taskItem)
        {
            _unitOfWork.TaskItem.Add(taskItem);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var taskItem = _unitOfWork.TaskItem.Get(t => t.Id == id);
            PopulateDropdowns();
            return View(taskItem);
        }
        [HttpPost]
        public IActionResult Edit(TaskItem taskItem)
        {
            _unitOfWork.TaskItem.Update(taskItem);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var taskItem = _unitOfWork.TaskItem.Get(t => t.Id == id, includeProperties: "Project,AssignedUser");
            return View(taskItem);
        }

        [HttpPost]
        public IActionResult Delete(TaskItem taskItem)
        {
            _unitOfWork.TaskItem.Remove(taskItem);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var taskItem = _unitOfWork.TaskItem.Get(t => t.Id == id, includeProperties: "Project,AssignedUser");

            var comments = _unitOfWork.Comment.GetAll(includeProperties: "Author")
                .Where(c => c.TaskItemId == id)
                .OrderBy(c => c.CreatedAt);

            ViewBag.Comments = comments;

            return View(taskItem);
        }

        private void PopulateDropdowns()
        {
            ViewBag.ProjectList = _unitOfWork.Project.GetAll()
                .Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() });

            ViewBag.UserList = _userManager.Users
                .Select(u => new SelectListItem { Text = u.Name, Value = u.Id });
        }

    }
}
