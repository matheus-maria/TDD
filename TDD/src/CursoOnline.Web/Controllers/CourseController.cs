using CursoOnline.Course.Services;
using CursoOnline.Course.VMs;
using CursoOnline.Domain.Base;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CursoOnline.Web.Controllers
{
   public class CourseController : Controller
	{
		private readonly CourseService _courseService;
		private readonly IRepository<Course.Data.Course> _courseRepository;

		public CourseController(CourseService courseService, IRepository<Course.Data.Course> courseRepository)
		{
			_courseService = courseService;
			_courseRepository = courseRepository;
		}

		public IActionResult Index()
		{
			var courses = _courseRepository.GetCourses();

			if (courses.Any())
			{
				var dtos = courses.Select(x => new CourseVM
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Workload = x.Workload,
					TargetAudience = x.TargetAudience.ToString(),
					Value = x.Value
				});
				return View("Index", PaginatedList<CourseVM>.Create(dtos, Request));
			}

			return View("Index", PaginatedList<CourseVM>.Create(null, Request));
		}

		public IActionResult Edit(int id)
		{
			var course = _courseRepository.GetById(id);
			var dto = new CourseVM
			{
				Id = course.Id,
				Name = course.Name,
				Description = course.Description,
				TargetAudience = course.TargetAudience.ToString(),
				Workload = course.Workload,
				Value = course.Value
			};

			return View("NewOrEdit", dto);
		}

		public IActionResult New()
		{
			return View("NewOrEdit", new CourseVM());
		}

		[HttpPost]
		public IActionResult Save(CourseVM model)
		{
			_courseService.Store(model);
			return Ok();
		}
	}
}