using CursoOnline.Dados.Contextos;
using CursoOnline.Dados.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CursoOnline.Domain.Base;
using CursoOnline.Course.Interfaces;
using CursoOnline.Course.Services;

namespace CursoOnline.Ioc
{
	public static class StartupIoc
	{
		public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(configuration["ConnectionString"]));
			services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
			services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));
			services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
			services.AddScoped<CourseService>();
		}
	}
}
