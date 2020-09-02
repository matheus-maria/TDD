using CursoOnline.Domain.Base;

namespace CursoOnline.Course.Interfaces
{
   public interface ICourseRepository: IRepository<Data.Course>
   {
      public Data.Course GetCourse(string courseName);
   }
}
