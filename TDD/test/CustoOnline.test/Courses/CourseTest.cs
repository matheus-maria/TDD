using Bogus;
using CursoOnline.Data;
using CursoOnline.test._Util;
using System;
using Xunit;

namespace CursoOnline.test.Courses
{
   public class CourseTest
   {    
      [Fact(DisplayName = "MustCreateCourse")]
      public void MustCreateCourse()
      {
         var facker = new Faker();

         string name = facker.Name.FullName();
         string description = facker.Lorem.Paragraph();
         double workload = facker.Random.Double(1, 100000);
         TargetAudience targetAudience = TargetAudience.Estudante;
         double value = facker.Finance.Random.Double(0, 100000);

         var course = new Course(name, description, workload, targetAudience, value);

         Assert.Equal(name, course.Name);
         Assert.Equal(description, course.Description);
         Assert.Equal(workload, course.Workload);
         Assert.Equal(targetAudience, course.TargetAudience);
         Assert.Equal(value, course.Value);
      }

      [Theory(DisplayName = "MustNotCourseHaveInvalidName")]
      [InlineData("")]
      [InlineData(null)]
      public void MustNotCourseHaveInvalidName(string name)
      {
         Assert.Throws<ArgumentException>(() => CourseBuilder.Builder().WithName(name).Build())
            .WithMessage("Property 'Name' is Invalid.");
      }

      [Theory(DisplayName = "MustNotCourseHaveWorkloadSmallerThan1")]
      [InlineData(-1)]
      [InlineData(0)]
      public void MustNotCourseHaveWorkloadSmallerThan1(double workload)
      {
         Assert.Throws<ArgumentException>(() => CourseBuilder.Builder().WithWorkload(workload).Build())
            .WithMessage("Property 'Workload' must need to be greater than zero.");
      }

      [Theory(DisplayName = "MustNotCourseHaveValueGreaterThan0")]
      [InlineData(-1)]
      [InlineData(-10)]
      public void MustNotCourseHaveValueGreaterThan0(double value)
      {
         Assert.Throws<ArgumentException>(() => CourseBuilder.Builder().WithValue(value).Build())
            .WithMessage("Property 'Value' must be a positive value.");
      }      
   }
}
