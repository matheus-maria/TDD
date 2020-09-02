using Bogus;
using CursoOnline.Course.Data;
using CursoOnline.Course.Services;
using CursoOnline.test._Util;
using Moq;
using System;
using Xunit;

namespace CursoOnline.test.Courses
{
   public class CourseServiceTest
   {
      // VARIABLES
      public Course.VMs.CourseVM _courseVM;
      public Mock<Course.Interfaces.ICourseRepository> _courseRepository;
      public CourseService _courseService;

      public CourseServiceTest()
      {
         var faker = new Faker();

         _courseVM = new Course.VMs.CourseVM
         {
            Name = faker.Name.FullName(),
            Description = faker.Lorem.Paragraph(),
            Workload = faker.Random.Double(1, 100000),
            TargetAudience = "Estudante",
            Value = faker.Finance.Random.Double(0, 100000)
         };

         _courseRepository = new Mock<Course.Interfaces.ICourseRepository>();
         _courseService = new CourseService(_courseRepository.Object);
      }

      [Fact(DisplayName = "MustAddCourse")]
      public void MustAddCourse()
      {
         _courseService.Store(_courseVM);

         _courseRepository.Verify(x => x.Store(It.Is<Course.Data.Course>(x => x.Name == _courseVM.Name && 
                                                                 x.Description == _courseVM.Description &&
                                                                 x.Workload == _courseVM.Workload &&
                                                                 x.TargetAudience == (TargetAudience)Enum.Parse(typeof(TargetAudience), _courseVM.TargetAudience) &&
                                                                 x.Value == _courseVM.Value)
         ), Times.Once());
      }

      [Fact(DisplayName = "MustNoAcceptAInvalidTargetAudience")]
      public void MustNoAcceptAInvalidTargetAudience()
      {
         _courseVM.TargetAudience = "Médico";

         Assert.Throws<ArgumentException>(() => _courseService.Store(_courseVM))
            .WithMessage("Invalid Target Audience");
      }

      [Fact(DisplayName = "MustNoCreateACourseWithTheSameNameAsAnother")]
      public void MustNoCreateACourseWithTheSameNameAsAnother()
      {
         var existingCourse = CourseBuilder.Builder().WithName(_courseVM.Name).Build();
         _courseRepository.Setup(x => x.GetCourse(_courseVM.Name)).Returns(existingCourse);

         Assert.Throws<ArgumentException>(() => _courseService.Store(_courseVM))
            .WithMessage("Course already exists");
      }
   }   
}
