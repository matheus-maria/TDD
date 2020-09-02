using System.Threading.Tasks;

namespace CursoOnline.Domain.Base
{
   public interface IUnitOfWork
   {
      public Task Commit();
   }
}
