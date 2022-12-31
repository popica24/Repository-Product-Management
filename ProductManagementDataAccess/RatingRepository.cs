using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    internal class RatingRepository : IRepository<RatingModel, RatingSearchParameters>
    {
        public string ConnectionString
        {
            get;
            private set;
        }

        public RatingRepository()
        {
            ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];
        }

        public int Create(RatingModel entity)
        {
            var SqlString = "INSERT INTO [tProductEvaluation] VALUES (@ProductId,@UserId,@Value)";
            var sqlParameters = CreateSqlParamsForRatingCreate(entity);
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

        public void Delete(RatingModel entity)
        {
            throw new NotImplementedException();
        }

        public List<RatingModel> GetAll()
        {
            List<RatingModel> result = new List<RatingModel>();
            var sqlSelect = "select FirstName, LastName , Description,Value from tUser as A inner join tProductEvaluation as B on A.UserId = B.UserId inner join tProduct as C on C.ProductId = B.ProductId";
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
                            var rating = MapModel(reader);
                            result.Add(rating);
                        }
                    }
                }

            }
            return result;
        }

        public void Update(RatingModel entity)
        {
            throw new NotImplementedException();
        }

        public List<RatingModel> Search(RatingSearchParameters searchParameters)
        {
            throw new NotImplementedException();
        }
        #region //Helpers
        private List<SqlParameter> CreateSqlParamsForRatingCreate(RatingModel ratingModel)
        {
            var result = new List<SqlParameter>();

            var ProductId = new SqlParameter();
            ProductId.ParameterName = "@ProductId";
            ProductId.Value = ratingModel.ProductId;
            ProductId.DbType = System.Data.DbType.Int32;

            var UserId = new SqlParameter();
            UserId.ParameterName = "@UserId";
            UserId.Value = ratingModel.UserId;
            UserId.DbType = System.Data.DbType.Int32;

            var Value = new SqlParameter();
            Value.ParameterName = "@Value";
            Value.Value = ratingModel.Value;
            Value.DbType = System.Data.DbType.Int32;

            result.Add(ProductId);
            result.Add(UserId);
            result.Add(Value);
            return result;
        }
        private RatingModel MapModel(SqlDataReader reader)
        {
            return new RatingModel()
            {
                UserId = int.Parse(reader["UserId"].ToString()),
                ProductId = int.Parse(reader["ProductId"].ToString()),
                Value = int.Parse(reader["Value"].ToString())
            };
        }
        #endregion
    }
}