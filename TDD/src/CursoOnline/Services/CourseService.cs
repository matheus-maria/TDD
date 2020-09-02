using CursoOnline.Data;
using CursoOnline.Interfaces;
using CursoOnline.VMs;
using System;

namespace CursoOnline.Services
{
   public class CourseService
   {
      private ICourseRepository _courseRepository;

      public CourseService(ICourseRepository courseRepository)
      {
         this._courseRepository = courseRepository;
      }

      public void Store(CourseVM courseVM)
      {
         // VALIDATE IF ALREADY EXITS THIS COURSE
         var existingCourse = _courseRepository.GetCourse(courseVM.Name);
         if (existingCourse != null)
            throw new ArgumentException("Course already exists");

         // VALIDATE TARGET AUDIENCE
         Enum.TryParse(typeof(TargetAudience), courseVM.TargetAudience, out var targetAudicence);
         if (targetAudicence == null)
            throw new ArgumentException("Invalid Target Audience");

         // PREPARE DATA
         var course = new Course(courseVM.Name, courseVM.Description, courseVM.Workload, (TargetAudience)targetAudicence, courseVM.Value);

         // RESULT
         _courseRepository.Store(course);
      }

   }
}
