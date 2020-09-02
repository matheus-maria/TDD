using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CursoOnline.Dados.Contextos
{
   public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Course.Data.Course> Course { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public async Task Commit()
		{
			await SaveChangesAsync();
		}
	}
}
