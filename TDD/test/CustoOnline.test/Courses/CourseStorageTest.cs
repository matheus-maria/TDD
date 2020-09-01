using Bogus;
using CursoOnline.Data;
using Moq;
using System;
using Xunit;

namespace CursoOnline.test.Courses
{
   public class CourseStorageTest
   {
      [Fact]
      public void MustAddCourse()
      {
         var faker = new Faker();

         var courseVM = new CourseVM
         {
            Name = faker.Name.FullName(),
            Description = faker.Lorem.Paragraph(),
            Workload = faker.Random.Double(1, 100000),
            TargetAudienceID = 1,
            Value = faker.Finance.Random.Double(0, 100000)
         };

         var courseRepository = new Mock<ICourseRepository>();

         var courseStorage = new CourseStorager(courseRepository.Object);

         courseStorage.Store(courseVM);

         courseRepository.Verify(x => x.Store(It.IsAny<Course>())); 
      }
   }

   public interface ICourseRepository
   { 
      public void Store(Course course);
   }

   public class CourseStorager
   {
      private ICourseRepository _courseRepository;

      public CourseStorager(ICourseRepository courseRepository)
      {
         this._courseRepository = courseRepository;
      }

      public void Store(CourseVM courseVM)
      {
         var course = new Course(courseVM.Name, courseVM.Description, courseVM.Workload, (TargetAudience)courseVM.TargetAudienceID, courseVM.Value);

         _courseRepository.Store(course);
      }
   }

   public class CourseVM
   {
      public string Name { get; set; }
      public string Description { get; set; }
      public double Workload { get; set; }
      public int TargetAudienceID { get; set; }
      public double Value { get; set; }
   }
}
