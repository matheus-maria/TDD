using CursoOnline.Data;

namespace CursoOnline.Interfaces
{
   public interface ICourseRepository
   {
      public void Store(Course course);
      public Course GetCourse(string courseName);
   }
}
