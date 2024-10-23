using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcStudentApp.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }

        [Required(ErrorMessage = "Поле 'Предмет' обязательно для заполнения.")]
        [DisplayName("Предмет")]
        public string Name { get; set; }
    }
}
