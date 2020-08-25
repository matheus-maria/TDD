using CursoOnline.Data;
using CursoOnline.test._Util;
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
         Assert.Throws<ArgumentException>(() => new Course(name, 1, TargetAudience.Estudante, 1)).WithMessage("Property 'Name' is Invalid.");
      }

      [Theory(DisplayName = "MustNotCourseHaveWorkloadSmallerThan1")]
      [InlineData(-1)]
      [InlineData(0)]
      public void MustNotCourseHaveWorkloadSmallerThan1(double workload)
      {
         Assert.Throws<ArgumentException>(() => new Course("teste",workload, TargetAudience.Estudante, 1)).WithMessage("Property 'Workload' must need to be greater than zero.");
      }

      [Theory(DisplayName = "MustNotCourseHaveValueGreaterThan0")]
      [InlineData(-1)]
      [InlineData(-10)]
      public void MustNotCourseHaveValueGreaterThan0(double value)
      {
         Assert.Throws<ArgumentException>(() => new Course("teste", 1, TargetAudience.Estudante, value)).WithMessage("Property 'Value' must be a positive value.");
      }
   }
}
