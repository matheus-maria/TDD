using CursoOnline.Dados.Contextos;
using CursoOnline.Domain.Base;
using System.Collections.Generic;
using System.Linq;

namespace CursoOnline.Dados.Repositorios
{
	public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
	{
		protected readonly ApplicationDbContext Context;

		public BaseRepository(ApplicationDbContext context)
		{
			Context = context;
		}

		public void Store(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public virtual TEntity GetById(long id)
		{
			var query = Context.Set<TEntity>().Where(x => x.Id == id);
			return query.Any() ? query.First() : null;
		}

		public virtual List<TEntity> GetCourses()
		{
			var entities = Context.Set<TEntity>().ToList();
			return entities.Any() ? entities : new List<TEntity>();
		}
	}
}
