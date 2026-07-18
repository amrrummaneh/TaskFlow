using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.DataAccess.Repository;
using TaskFlow.Models;

namespace TaskFlow.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            comment.CreatedAt = DateTime.Now;
            _unitOfWork.Comment.Add(comment);
            _unitOfWork.Save(); 

            return RedirectToAction("Details", "TaskItem", new { id = comment.TaskItemId });
        }

        [HttpPost]
        public IActionResult Delete(int id, int taskItemId)
        {
            var comment = _unitOfWork.Comment.Get(c => c.Id == id);
            _unitOfWork.Comment.Remove(comment);
            _unitOfWork.Save();

            return RedirectToAction("Details", "TaskItem", new { id = taskItemId });
        }
    }
}
