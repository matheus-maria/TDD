using CursoOnline.Course.Data;
using CursoOnline.Course.Interfaces;
using CursoOnline.Course.VMs;
using System;

namespace CursoOnline.Course.Services
{
   public class CourseService
   {
      private readonly ICourseRepository _courseRepository;

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
         if(!Enum.TryParse<TargetAudience>(courseVM.TargetAudience, out var targetAudicence))
            throw new ArgumentException("Invalid Target Audience");

         // PREPARE DATA
         var course = new Data.Course(courseVM.Name,
                                 courseVM.Description,
                                 courseVM.Workload,
                                 targetAudicence,
                                 courseVM.Value);

         // RESULT
         _courseRepository.Store(course);
      }

   }
}
