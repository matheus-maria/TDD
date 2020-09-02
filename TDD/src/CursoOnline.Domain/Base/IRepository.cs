using System.Collections.Generic;

namespace CursoOnline.Domain.Base
{
   public interface IRepository<TEntity>
   {
      public TEntity GetById(long id);
      public List<TEntity> GetCourses();
      public void Store(TEntity entity);
   }
}
