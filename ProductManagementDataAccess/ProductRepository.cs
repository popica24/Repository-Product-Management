using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ProductManagementDataAccess
{
    internal class ProductRepository : IRepository<ProductModel, ProductSearchParameters>
    {
        public string ConnectionString
        {
            get;
            private set;
        }

        public ProductRepository()
        {
            ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];
        }

        public int Create(ProductModel entity)
        {
            var SqlString = "INSERT INTO [tProduct] VALUES (@Description,@Price,@DateManufactured) SELECT SCOPE_IDENTITY() AS 'RETURNED'";
            var sqlParameters = CreateSqlParameters(entity);
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = SqlString;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return int.Parse(reader["RETURNED"].ToString());
                    }
                }
            }
        }

        public void Delete(ProductModel entity)
        {
            var SqlString = "DELETE FROM [tProduct] WHERE ProductId = @ProductId";
            var P = new SqlParameter()
            {
                ParameterName = "@ProductId",
                Value = entity.ProductId,
                DbType = System.Data.DbType.Int32
            };
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = SqlString;
                    command.Parameters.Add(P);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ProductModel> GetAll()
        {
            var result = new List<ProductModel>();
            var sqlSelect = CreateSqlStringForProductSearch(null);
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlSelect;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = MapModel(reader);
                            result.Add(product);
                        }
                    }
                }

            }
            return result;
        }

        public List<ProductModel> Search(ProductSearchParameters searchParameters)
        {
            var result = new List<ProductModel>();
            var sqlSelect = CreateSqlStringForProductSearch(searchParameters);
            var sqlParameters = CreateSqlSearchParameters(searchParameters);
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
                            var product = MapModel(reader);
                            result.Add(product);
                        }
                    }
                }

            }

            return result;
        }

        public void Update(ProductModel entity)
        {
            throw new NotImplementedException();
        }
        #region //Helpers
        private List<SqlParameter> CreateSqlParameters(ProductModel entity)
        {
            var result = new List<SqlParameter>();
            var Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.Value = entity.Description;
            Description.DbType = System.Data.DbType.String;

            var Price = new SqlParameter();
            Price.ParameterName = "@Price";
            Price.Value = entity.Price;
            Price.DbType = System.Data.DbType.Int32;

            var DateManufactured = new SqlParameter();
            DateManufactured.ParameterName = "@DateManufactured";
            DateManufactured.Value = entity.DateManufactured;
            DateManufactured.DbType = System.Data.DbType.DateTime;

            var ProductId = new SqlParameter();
            ProductId.ParameterName = "@ProductId";
            ProductId.Value = entity.ProductId;
            ProductId.DbType = System.Data.DbType.Int32;

            result.Add(ProductId);
            result.Add(Description);
            result.Add(Price);
            result.Add(DateManufactured);

            return result;

        }
        private string CreateSqlStringForProductSearch(ProductSearchParameters productSearchParameters)
        {
            if (productSearchParameters != null && !string.IsNullOrEmpty(productSearchParameters.Description))
            {
                return "SELECT * FROM [tProduct] WHERE Description = @Description";
            }
            if (productSearchParameters != null && productSearchParameters.BottomPrice.HasValue && productSearchParameters.TopPrice.HasValue)
            {
                return "SELECT * FROM [tProduct] WHERE Price >= @BottomPrice AND Price <= @TopPrice";
            }
            if (productSearchParameters != null && productSearchParameters.DateManufactured.HasValue)
            {
                return "SELECT * FROM [tProduct] WHERE DateManufactured = @DateManufactured";
            }
            if (productSearchParameters != null && productSearchParameters.ProductId.HasValue)
            {
                return "SELECT * FROM [tProduct] WHERE ProductId = @ProductId";
            }
            if (productSearchParameters != null && productSearchParameters.CategoryId.HasValue)
            {
                return "SELECT * FROM tProduct as A inner join tProductCategory as B on A.ProductId = B.ProductId AND CategoryId = @ID";
            }
            if(productSearchParameters != null && productSearchParameters.Rating.HasValue)
            {
                return "SELECT ProductId,AVG(Value) AS Rating INTO #RatingTable from tProductEvaluation as TEMP GROUP BY ProductId HAVING AVG(Value) = @Rating select * from tProduct as A inner join #RatingTable as B on A.ProductId = B.ProductId";
            }
            return "SELECT TOP 100 * FROM [tProduct]";
        }
        private List<SqlParameter> CreateSqlSearchParameters(ProductSearchParameters productSearchParameters)
        {
            var results = new List<SqlParameter>();
            if (productSearchParameters != null && !string.IsNullOrEmpty(productSearchParameters.Description))
            {
                var P = new SqlParameter();
                P.ParameterName = "@Description";
                P.Value = productSearchParameters.Description;
                P.DbType = System.Data.DbType.String;
                results.Add(P);
            }
            if (productSearchParameters != null && productSearchParameters.BottomPrice.HasValue && productSearchParameters.TopPrice.HasValue)
            {
                var P1 = new SqlParameter();
                P1.ParameterName = "@BottomPrice";
                P1.Value = productSearchParameters.BottomPrice;
                P1.DbType = System.Data.DbType.Int32;
                results.Add(P1);

                var P2 = new SqlParameter();
                P2.ParameterName = "@TopPrice";
                P2.Value = productSearchParameters.TopPrice;
                P2.DbType = System.Data.DbType.Int32;
                results.Add(P2);
            }
            if (productSearchParameters != null && productSearchParameters.DateManufactured.HasValue)
            {
                var P = new SqlParameter();
                P.ParameterName = "@DateManufactured";
                P.Value = productSearchParameters.DateManufactured;
                P.DbType = System.Data.DbType.DateTime;
                results.Add(P);
            }
            if (productSearchParameters != null && productSearchParameters.ProductId.HasValue)
            {
                var P = new SqlParameter();
                P.ParameterName = "@ProductId";
                P.Value = productSearchParameters.ProductId;
                P.DbType = System.Data.DbType.Int32;
                results.Add(P);
            }
            if (productSearchParameters != null && productSearchParameters.CategoryId.HasValue)
            {
                var P = new SqlParameter();
                P.Value = productSearchParameters.CategoryId;
                P.ParameterName = "@ID";
                P.DbType = System.Data.DbType.Int32;
                results.Add(P);
            }
            if (productSearchParameters != null && productSearchParameters.Rating.HasValue)
            {
                var P = new SqlParameter();
                P.Value = productSearchParameters.Rating;
                P.ParameterName = "@Rating";
                P.DbType = System.Data.DbType.Int32;
                results.Add(P);
            }

                return results;
        }
        private ProductModel MapModel(SqlDataReader Reader)
        {
            return new ProductModel()
            {
                ProductId = int.Parse(Reader["ProductId"].ToString()),
                Description = Reader["Description"].ToString(),
                Price = int.Parse(Reader["Price"].ToString()),
                DateManufactured = DateTime.Parse(Reader["DateManufactured"].ToString())
            };
        }
        #endregion
    }
}