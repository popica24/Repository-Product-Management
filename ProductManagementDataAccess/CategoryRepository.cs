using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    internal class CategoryRepository : IRepository<CategoryModel, CategorySearchParameters>
    {
        public string ConnectionString
        {
            get;
            private set;
        }
        
        public CategoryRepository()
        {
            ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];
        }
       
        public int Create(CategoryModel entity)
        {
            var SqlString = "INSERT INTO [tCategory] VALUES(@CategoryName) SELECT SCOPE_IDENTITY() AS 'RETURNED'";
            var SqlParams = CreateSqlParamsForCategoryCreate(entity);
            using (var Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();

                using (var Command = Connection.CreateCommand())
                {
                    Command.CommandText = SqlString;
                    Command.Parameters.Add(SqlParams);
                    using (var reader = Command.ExecuteReader())
                    {
                        reader.Read();
                        return int.Parse(reader["RETURNED"].ToString());
                    }
                }
            }
        }

        public void Delete(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public List<CategoryModel> GetAll()
        {
            var result = new List<CategoryModel>();
            var SqlString = CreateSqlStringForCategorySearch(null);
            using (var Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                using (var Command = Connection.CreateCommand())
                {
                    Command.CommandText = SqlString;
                    using (var reader = Command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = MapModel(reader);
                            result.Add(category);
                        }
                    }
                }
            }
            return result;
        }

        public List<CategoryModel> Search(CategorySearchParameters searchParameters)
        {
            var result = new List<CategoryModel>();
            var SqlString = CreateSqlStringForCategorySearch(searchParameters);
            var sqlParams = CreateSqlParamsForCategorySearch(searchParameters);
            using (var Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                using (var Command = Connection.CreateCommand())
                {
                    Command.CommandText = SqlString;
                    Command.Parameters.AddRange(sqlParams.ToArray());
                    using (var reader = Command.ExecuteReader())
                    {
                        var category = MapModel(reader);
                        result.Add(category);
                    }
                }
            }
            return result;
        }

        public void Update(CategoryModel entity)
        {
            throw new NotImplementedException();
        }
        #region //Helpers
        private SqlParameter CreateSqlParamsForCategoryCreate(CategoryModel entity)
        {
            var CategoryName = new SqlParameter();
            CategoryName.ParameterName = "@CategoryName";
            CategoryName.Value = entity.CategoryName;
            CategoryName.DbType = System.Data.DbType.String;
            return CategoryName;
        }
        private string CreateSqlStringForCategorySearch(CategorySearchParameters categorySearchParameters)
        {
            if (categorySearchParameters != null && !string.IsNullOrEmpty(categorySearchParameters.CategoryName))
            {
                return "SELECT * FROM [tCategory] WHERE CategoryName = @CategoryName";
            }
            if (categorySearchParameters != null && categorySearchParameters.CategoryId.HasValue)
            {
                return "SELECT * FROM [tCategory] WHERE CategoryId = @CategoryId";
            }
            return "SELECT TOP 100 * FROM [tCategory]";
        }
        private List<SqlParameter> CreateSqlParamsForCategorySearch(CategorySearchParameters categorySearchParameters)
        {
            var results = new List<SqlParameter>();
            if (categorySearchParameters != null && !string.IsNullOrEmpty(categorySearchParameters.CategoryName))
            {
                var P = new SqlParameter();
                P.ParameterName = "@CategoryName";
                P.Value = categorySearchParameters.CategoryName;
                P.DbType = System.Data.DbType.String;
                results.Add(P);
            }
            if (categorySearchParameters != null && categorySearchParameters.CategoryId.HasValue)
            {
                var P = new SqlParameter();
                P.ParameterName = "@CategoryId";
                P.Value = categorySearchParameters.CategoryId;
                P.DbType = System.Data.DbType.String;
                results.Add(P);
            }
            return results;

        }
        private CategoryModel MapModel(SqlDataReader Reader)
        {
            return new CategoryModel()
            {
                CategoryId = int.Parse(Reader["CategoryId"].ToString()),
                CategoryName = Reader["CategoryName"].ToString()
            };
        }
        #endregion
    }
}