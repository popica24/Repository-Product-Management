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
        public string ConnectionString { get; private set; }

        public RatingRepository()
        {
            ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];
        }

        public int Create(RatingModel entity)
        {
            var sqlSelect = "INSERT INTO [tProductEvaluation] VALUES (@ProductId,@UserId,@Value)";
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
        private List<SqlParameter> CreateSqlParametersFrom(RatingModel ratingModel)
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
                            var model = MapRatingFrom(reader);
                            result.Add(model);
                        }
                    }
                }


            }
            return result;
        }
        private RatingModel MapRatingFrom(SqlDataReader reader)
        {
            return new RatingModel()
            {
                UserId = int.Parse(reader["UserId"].ToString()),
                ProductId = int.Parse(reader["ProductId"].ToString()),
                Value = int.Parse(reader["Value"].ToString())
            };
        }
        public List<RatingModel> Search(RatingSearchParameters searchParameters)
        {
            throw new NotImplementedException();
        }

        public void Update(RatingModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
