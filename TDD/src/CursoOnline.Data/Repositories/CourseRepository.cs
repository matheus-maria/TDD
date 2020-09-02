using CursoOnline.Course.Interfaces;
using CursoOnline.Dados.Contextos;
using System.Linq;

namespace CursoOnline.Dados.Repositorios
{
   public class CourseRepository : BaseRepository<Course.Data.Course>, ICourseRepository
	{
		public CourseRepository(ApplicationDbContext context) : base(context)
		{
		}

		public Course.Data.Course GetCourse(string name)
		{
			var entity = Context.Set<Course.Data.Course>().Where(c => c.Name.Contains(name));
			if (entity.Any())
				return entity.First();
			return null;
		}		
	}
}
