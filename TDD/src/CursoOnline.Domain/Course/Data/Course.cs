using CursoOnline.Domain.Base;
using System;

namespace CursoOnline.Course.Data
{
   public enum TargetAudience { Estudante, Universitário, Empregado, Empreededor }

   public class Course : Entity
   {
      public Course(string name, string description, double workload, TargetAudience targetAudience, double value)
      {
         this.Name = name;
         this.Description = description;
         this.Workload = workload;
         this.TargetAudience = targetAudience;
         this.Value = value;
      }

      private string _name;
      public string Name { 
         get => _name;
         private set {
            if (string.IsNullOrEmpty(value))
               throw new ArgumentException("Property 'Name' is Invalid.");
            else
               _name = value;
         }
      }

      private string _description;
      public string Description
      {
         get => _description;
         private set 
         {
            _description = value;
         }
      }

      private double _workload;
      public double Workload { 
         get => _workload;
         private set {
            if (value < 1)
               throw new ArgumentException("Property 'Workload' must need to be greater than zero.");
            else
               _workload = value;

         }
      }

      public TargetAudience TargetAudience { get; private set; }

      private double _value;
      public double Value
      {
         get => _value;
         private set
         {
            if (value < 0)
               throw new ArgumentException("Property 'Value' must be a positive value.");
            else
               _value = value;

         }
      }
   }
}
