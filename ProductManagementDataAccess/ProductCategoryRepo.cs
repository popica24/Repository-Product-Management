using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    internal class ProductCategoryRepo : IRepository<ProductCategoryModel, ProductCategorySearchParameters>
    {
        public string ConnectionString { get; private set; }

        public ProductCategoryRepo()
        {
            ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];
        }

        public int Create(ProductCategoryModel entity)
        {
            var sqlSelect = "INSERT INTO [tProductCategory] VALUES (@ProductId,@CategoryId)";
            var sqlParameters = CreateSqlParametersFrom(entity);
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlSelect;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    command.ExecuteNonQuery();
                    return 1;
                }


            }
        }
        private List<SqlParameter> CreateSqlParametersFrom(ProductCategoryModel productCategoryModel)
        {
            var result = new List<SqlParameter>();
            
            var ProductId = new SqlParameter();
            ProductId.ParameterName = "@ProductId";
            ProductId.Value = productCategoryModel.ProductId;
            ProductId.DbType = System.Data.DbType.Int32;

            var CategoryId = new SqlParameter();
            CategoryId.ParameterName = "@CategoryId";
            CategoryId.Value = productCategoryModel.CategoryId;
            CategoryId.DbType = System.Data.DbType.Int32;

            result.Add(ProductId);
            result.Add(CategoryId);
            return result;
        }
        public void Delete(ProductCategoryModel entity)
        {
            var SqlDeleteString = "DELETE FROM [tProductCategory] WHERE (ProductId = @ProductId AND CategoryId = @CategoryId)";
            var SqlParams = CreateSqlParametersFrom(entity);
              using (var connection = new SqlConnection(ConnectionString))
              {

                  connection.Open();
                  using (var command = connection.CreateCommand())
                  {
                      command.CommandText = SqlDeleteString;
                      command.Parameters.AddRange(SqlParams.ToArray());
                      command.ExecuteNonQuery();
                  }


              }
            
        }
       
        public List<ProductCategoryModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryModel> Search(ProductCategorySearchParameters searchParameters)
        {
            var result = new List<ProductCategoryModel>();
            var sqlSelect = CreateSqlSelectFrom(searchParameters);
            var sqlParameters = CreateSqlSearchParametersFrom(searchParameters);
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlSelect;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = MapModelFrom(reader);
                            result.Add(user);
                        }
                    }
                }


            }

            return result;
        }

        private ProductCategoryModel MapModelFrom(SqlDataReader reader)
        {
            return new ProductCategoryModel()
            {
                CategoryId = int.Parse(reader["CategoryId"].ToString()),
                ProductId = int.Parse(reader["ProductId"].ToString())
            };
        }

        private string CreateSqlSelectFrom(ProductCategorySearchParameters productCategorySearch)
        {
            if (productCategorySearch != null && productCategorySearch.ProductId.HasValue)
            {
                return "SELECT * FROM [tProductCategory] WHERE ProductId = @ProductId";
            }
            if (productCategorySearch != null && productCategorySearch.CategoryId.HasValue)
            {
                return "SELECT * FROM [tProductCategory] WHERE CategoryId = @CategoryId";
            }
            return "SELECT TOP 100 * FROM [tProductCategory]";
        }

        private List<SqlParameter> CreateSqlSearchParametersFrom(ProductCategorySearchParameters productCategorySearch)
        {
            var result = new List<SqlParameter>();
            if(productCategorySearch != null && productCategorySearch.ProductId.HasValue)
            {
                var P = new SqlParameter();
                P.ParameterName = "@ProductId";
                P.Value = productCategorySearch.ProductId;
                P.DbType = System.Data.DbType.Int32;
                result.Add(P);
            }
            if (productCategorySearch != null && productCategorySearch.CategoryId.HasValue)
            {
                var P = new SqlParameter();
                P.ParameterName = "@CategoryId";
                P.Value = productCategorySearch.CategoryId;
                P.DbType = System.Data.DbType.Int32;
                result.Add(P);
            }
            return result;
        }
        public void Update(ProductCategoryModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
