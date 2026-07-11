using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.DataAccess.Repository;
using TaskFlow.Models;
using TaskFlow.Utility;

namespace TaskFlow.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Project project)
        {
            project.CreatedAt = DateTime.Now;
            _unitOfWork.Project.Add(project);       
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var project = _unitOfWork.Project.Get(p => p.Id == id);
            return View(project);
        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            _unitOfWork.Project.Update(project);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var project = _unitOfWork.Project.Get(p => p.Id == id);
            return View(project);
        }
        [HttpPost]
        public IActionResult Delete(Project project)
        {
            _unitOfWork.Project.Remove(project);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
    