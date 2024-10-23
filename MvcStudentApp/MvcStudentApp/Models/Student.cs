using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcStudentApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения.")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения.")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле 'Группа' обязательно для заполнения.")]
        [DisplayName("Группа")]
        public string Group { get; set; }

        [Required(ErrorMessage = "Поле 'Оценка' обязательно для заполнения.")]
        [Range(2, 5, ErrorMessage = "Сумма от 2 до 5.")]
        [DisplayName("Оценка")]
        public int? Score { get; set; }

        [DisplayName("Предмет")]
        public int LessonId { get; set; }

        [DisplayName("Предмет")]
        public Lesson Lesson { get; set; }

    }
}
