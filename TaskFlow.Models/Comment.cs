using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("TaskItem")]
        public int TaskItemId { get; set; }

        public TaskItem TaskItem { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
    }
}
