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
        public string ConnectionString
        {
            get;
            private set;
        }

        public ProductCategoryRepo()
        {
            ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];
        }

        public int Create(ProductCategoryModel entity)
        {
            var SqlString = "INSERT INTO [tProductCategory] VALUES (@ProductId,@CategoryId)";
            var sqlParameters = CreateSqlParams(entity);
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = SqlString;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    command.ExecuteNonQuery();
                    return 1;
                }

            }
        }

        public void Delete(ProductCategoryModel entity)
        {
            var SqlDeleteString = "DELETE FROM [tProductCategory] WHERE (ProductId = @ProductId AND CategoryId = @CategoryId)";
            var SqlParams = CreateSqlParams(entity);
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

        public void Update(ProductCategoryModel entity)
        {
            throw new NotImplementedException();
        }
        
        public List<ProductCategoryModel> Search(ProductCategorySearchParameters searchParameters)
        {
            var result = new List<ProductCategoryModel>();
            var SqlString = CreateSqlSelectStringForPCSearch(searchParameters);
            var sqlParameters = CreateSqlParamsForPCSearch(searchParameters);
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = SqlString;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productCategory = MapModel(reader);
                            result.Add(productCategory);
                        }
                    }
                }

            }

            return result;
        }
        #region //Helpers
        private ProductCategoryModel MapModel(SqlDataReader reader)
        {
            return new ProductCategoryModel()
            {
                CategoryId = int.Parse(reader["CategoryId"].ToString()),
                ProductId = int.Parse(reader["ProductId"].ToString())
            };
        }
        private string CreateSqlSelectStringForPCSearch(ProductCategorySearchParameters productCategorySearch)
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
        private List<SqlParameter> CreateSqlParamsForPCSearch(ProductCategorySearchParameters productCategorySearch)
        {
            var result = new List<SqlParameter>();
            if (productCategorySearch != null && productCategorySearch.ProductId.HasValue)
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
        private List<SqlParameter> CreateSqlParams(ProductCategoryModel productCategoryModel)
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
        #endregion
    }
}