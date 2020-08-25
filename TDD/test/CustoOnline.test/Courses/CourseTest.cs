using CursoOnline.Data;
using System;
using Xunit;

namespace CursoOnline.test.Courses
{
   public class CourseTest
   {
      [Theory(DisplayName = "MustCreateCourse")]
      [InlineData("Informática Básica",80, TargetAudience.Estudante, 950)]
      public void MustCreateCourse(string name, double workload, TargetAudience targetAudience, double value)
      {
         var course = new Course(name, workload, targetAudience, value);

         Assert.Equal(name, course.Name);
         Assert.Equal(workload, course.Workload);
         Assert.Equal(targetAudience, course.TargetAudience);
         Assert.Equal(value, course.Value);
      }

      [Theory(DisplayName = "MustNotCourseHaveInvalidName")]
      [InlineData("")]
      [InlineData(null)]
      public void MustNotCourseHaveInvalidName(string name)
      {
         var message = Assert.Throws<ArgumentException>(() => new Course(name, 1, TargetAudience.Estudante, 1)).Message;
         Assert.Equal("Property 'Name' is Invalid.", message);
      }

      [Theory(DisplayName = "MustNotCourseHaveWorkloadSmallerThan1")]
      [InlineData(-1)]
      [InlineData(0)]
      public void MustNotCourseHaveWorkloadSmallerThan1(double workload)
      {
         var message = Assert.Throws<ArgumentException>(() => new Course("teste",workload, TargetAudience.Estudante, 1)).Message;
         Assert.Equal("Property 'Workload' must need to be greater than zero.", message);
      }

      [Theory(DisplayName = "MustNotCourseHaveValueGreaterThan0")]
      [InlineData(-1)]
      [InlineData(-10)]
      public void MustNotCourseHaveValueGreaterThan0(double value)
      {
         var message = Assert.Throws<ArgumentException>(() => new Course("teste", 1, TargetAudience.Estudante, value)).Message;
         Assert.Equal("Property 'Value' must be a positive value.", message);
      }
   }
}
