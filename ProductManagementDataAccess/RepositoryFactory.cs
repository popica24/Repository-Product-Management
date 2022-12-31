using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    public class RepositoryFactory<T,S>
    {
        public static IRepository<T,S> Create(int repositoryType)
        {
            switch (repositoryType)
            {
                case (int)RepositoryType.User:
                    return new UserRepository() as IRepository<T, S>;
                case (int)RepositoryType.Product:
                    return new ProductRepository() as IRepository<T, S>;
                case (int)RepositoryType.Category:
                    return new CategoryRepository() as IRepository<T, S>;
                case (int)RepositoryType.ProductCategory:
                    return new ProductCategoryRepo() as IRepository<T, S>;
                case (int)RepositoryType.Rating:
                    return new RatingRepository() as IRepository<T, S>;
                
            }
            return null;
        }
    }
}
