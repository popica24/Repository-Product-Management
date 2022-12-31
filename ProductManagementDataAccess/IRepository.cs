using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace ProductManagementDataAccess
{
    public interface IRepository<T,S>
    {
        List<T> GetAll();
        List<T> Search(S searchParameters);
        int Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
