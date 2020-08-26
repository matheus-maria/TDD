using Bogus;
using CursoOnline.Data;

namespace CursoOnline.test.Courses
{
   public class CourseBuilder
   {
      private string _name;
      private string _description;
      private double _workload;
      private TargetAudience _targetAudience;
      private double _value;

      public static CourseBuilder Builder()
      {
         var facker = new Faker();

         var courseBuilder = new CourseBuilder();
         courseBuilder._name = facker.Name.FullName();
         courseBuilder._description = facker.Lorem.Paragraph();
         courseBuilder._workload = facker.Random.Double(1, 100000);
         courseBuilder._targetAudience = TargetAudience.Universitário;
         courseBuilder._value = facker.Finance.Random.Double(0, 100000);

         return courseBuilder;
      }

      public Course Build()
      {
         return new Course(_name, _description, _workload, _targetAudience, _value);
      }

      public CourseBuilder WithName(string name)
      {
         _name = name;
         return this;
      }

      public CourseBuilder WithDescription(string description)
      {
         _description = description;
         return this;
      }

      public CourseBuilder WithWorkload(double workload)
      {
         _workload = workload;
         return this;
      }

      public CourseBuilder WithTargetAudience(TargetAudience targetAudience)
      {
         _targetAudience = targetAudience;
         return this;
      }

      public CourseBuilder WithValue(double value)
      {
         _value = value;
         return this;
      }

   }
}
