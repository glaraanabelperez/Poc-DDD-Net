using Domain.Agregates;
using Domain.Repository;
using Infraestricture.Persistencia.DBContext.AppDBContext;
using Microsoft.EntityFrameworkCore.Storage;


namespace Infraestructure.Repository
{
    public class ProductRepository : IRepository
    {
        //private readonly ApplicationDbContext _dbContext;
        //public ProductRepository(ApplicationDbContext context)
        //{
        //    this._dbContext = context;
        //}
        public  async Task<Response> AddAsync(Product product, CancellationToken cancellationToken)
        {
            Response res = new Response() { Data = product };

            //using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            //{
            //    try
            //    {

            //            var prod_map = SetObjectToCreate(product);

            //            var prod = await _dbContext.AddAsync(product, cancellationToken);
            //            await _dbContext.SaveChangesAsync(cancellationToken);
            //            await transac.CommitAsync();

            //            res = new Response() { Data = product};
                   
                   
            //    }
            //    catch (Exception ex)
            //    {

            //        var excection = ex.InnerException != null ? ex.InnerException : ex;////preguntar
            //        //Implementar el logger y gestionador de excepciones generico.
            //        //ErrorResult errorResult = ExceptionHandler.CreateErrorResult(excection);
            //        string value = excection.Message;
            //        //_logger.LogWarning(value);
            //        Console.WriteLine(value);
            //    }
            //    finally
            //    {
            //        await transac.RollbackAsync();
            //    }
            //}

            return  res;
        }

        private object SetObjectToCreate(object request)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(long productId)
        {
            throw new NotImplementedException();
        }
    }
}
