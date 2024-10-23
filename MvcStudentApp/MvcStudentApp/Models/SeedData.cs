using Microsoft.EntityFrameworkCore;
using MvcStudentApp;

namespace MvcStudentApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversityContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<UniversityContext>>()))
            {
                if (context == null || context.Students == null)
                {
                    throw new ArgumentNullException("Null UniversityContext");
                }

                if (!context.Lessons.Any())
                {
                    context.Lessons.Add(new Lesson { Name = "Математика" });
                    context.Lessons.Add(new Lesson { Name = "Физика" });
                    context.Lessons.Add(new Lesson { Name = "История" });
                    context.Lessons.Add(new Lesson { Name = "Литература" });
                    context.SaveChanges();
                }

                if (context.Students.Any())
                {
                    return;
                }

                context.Students.Add(new Student { FirstName = "Степан", LastName = "Иванов", Group = "856", Score = 3, LessonId = 2 });
                context.Students.Add(new Student { FirstName = "Иван", LastName = "Сидоров", Group = "675", Score = 5, LessonId = 1 });
                context.Students.Add(new Student { FirstName = "Александр", LastName = "Петров", Group = "778", Score = 4, LessonId = 1 });

                context.Students.AddRange(

                new Student
                {
                    FirstName = "Петр",
                    LastName = "Синицин",
                    Group = "546",
                    Score = 5,
                    LessonId = 3
                },
                new Student
                {
                    FirstName = "Михаил",
                    LastName = "Завидов",
                    Group = "487",
                    Score = 4,
                    LessonId = 4
                }
                );
                context.SaveChanges();
            }
        }
    }
}
