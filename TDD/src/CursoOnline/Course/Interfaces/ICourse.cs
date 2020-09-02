namespace CursoOnline.Course.Interfaces
{
   public interface ICourseRepository
   {
      public void Store(Data.Course course);
      public Data.Course GetCourse(string courseName);
   }
}
