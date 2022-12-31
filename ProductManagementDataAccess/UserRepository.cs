using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    internal class UserRepository : IRepository<UserModel, UserSearchParameter>
    {
        public string ConnectionString
        {
            get;
            private set;
        }

        public UserRepository()
        {
            ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];
        }

        public int Create(UserModel entity)
        {
            var sqlSelect = "INSERT INTO [tUser] VALUES (@IsAdmin,@FirstName,@LastName,@PhoneNumber,@Password) SELECT SCOPE_IDENTITY() AS 'RETURNED'";
            var sqlParameters = CreateSqlParametersForCreate(entity);
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlSelect;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return int.Parse(reader["RETURNED"].ToString());
                    }
                }

            }
        }

        public List<UserModel> GetAll()
        {
            var result = new List<UserModel>();
            var sqlSelect = CreateSqlStringForSearch(null);
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
                            var user = MapModel(reader);
                            result.Add(user);
                        }
                    }
                }

            }
            return result;
        }

        public void Delete(UserModel entity)
        {
            var sqlSelect = "DELETE FROM [tUser] WHERE UserId = @UserId";
            var sqlParameters = CreateSqlParametersForDelete(entity);
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlSelect;
                    command.Parameters.Add(sqlParameters);
                    command.ExecuteNonQuery();
                }

            }
        }

        public List<UserModel> Search(UserSearchParameter searchParameters)
        {
            var result = new List<UserModel>();
            var sqlSelect = CreateSqlStringForSearch(searchParameters);
            var sqlParameters = CreateSqlParametersForSearch(searchParameters);
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
                            var user = MapModel(reader);
                            result.Add(user);
                        }
                    }
                }

            }

            return result;
        }

        public void Update(UserModel entity)
        {
            throw new NotImplementedException();
        }
        #region //Helpers
        private SqlParameter CreateSqlParametersForDelete(UserModel userModel)
        {
            var p = new SqlParameter();
            p.ParameterName = "@UserId";
            p.Value = userModel.UserId;
            p.DbType = System.Data.DbType.Int32;
            return p;
        }
        private List<SqlParameter> CreateSqlParametersForCreate(UserModel userModel)
        {
            var result = new List<SqlParameter>();
            var IsAdmin = new SqlParameter();
            IsAdmin.ParameterName = "@IsAdmin";
            IsAdmin.Value = userModel.IsAdmin;
            IsAdmin.DbType = System.Data.DbType.Int32;

            var FirstName = new SqlParameter();
            FirstName.ParameterName = "@FirstName";
            FirstName.Value = userModel.FirstName;
            FirstName.DbType = System.Data.DbType.String;

            var LastName = new SqlParameter();
            LastName.ParameterName = "@LastName";
            LastName.Value = userModel.LastName;
            LastName.DbType = System.Data.DbType.String;

            var PhoneNumber = new SqlParameter();
            PhoneNumber.ParameterName = "@PhoneNumber";
            PhoneNumber.Value = userModel.PhoneNumber;
            PhoneNumber.DbType = System.Data.DbType.String;

            var Password = new SqlParameter();
            Password.ParameterName = "@Password";
            Password.Value = userModel.Password;
            Password.DbType = System.Data.DbType.String;

            result.Add(IsAdmin);
            result.Add(FirstName);
            result.Add(LastName);
            result.Add(PhoneNumber);
            result.Add(Password);
            return result;
        }
        private string CreateSqlStringForSearch(UserSearchParameter userSearchParameter)
        {
            if (userSearchParameter != null && !string.IsNullOrEmpty(userSearchParameter.FirstName)&& !string.IsNullOrEmpty(userSearchParameter.LastName)&& !string.IsNullOrEmpty(userSearchParameter.Password))
            {
                return "SELECT * FROM [tUser] WHERE (FirstName = @FirstName AND LastName = @LastName AND Password = @Password)";
            }
            if (userSearchParameter != null && !string.IsNullOrEmpty(userSearchParameter.PhoneNumber))
            {
                return "SELECT * FROM [tUser] WHERE PhoneNumber = @PhoneNumber";
            }
            if (userSearchParameter != null && userSearchParameter.UserId.HasValue)
            {
                return "SELECT * FROM [tUser] WHERE UserId = @UserId";
            }
            if (userSearchParameter != null && !string.IsNullOrEmpty(userSearchParameter.FirstName))
            {
                return "SELECT * FROM [tUser] WHERE FirstName = @FirstName";
            }
            if (userSearchParameter != null && !string.IsNullOrEmpty(userSearchParameter.LastName))
            {
                return "SELECT * FROM [tUser] WHERE LastName = @LastName";
            }
            return "SELECT TOP 100 * from [tUser]";
        }
        private List<SqlParameter> CreateSqlParametersForSearch(UserSearchParameter userSearchParameter)
        {
            var result = new List<SqlParameter>();
            if (userSearchParameter != null && !string.IsNullOrEmpty(userSearchParameter.PhoneNumber))
            {
                var p = new SqlParameter();
                p.ParameterName = "@PhoneNumber";
                p.Value = userSearchParameter.PhoneNumber;
                p.DbType = System.Data.DbType.String;
                result.Add(p);
            }
            if (userSearchParameter != null && userSearchParameter.UserId.HasValue)
            {
                var p = new SqlParameter();
                p.ParameterName = "@UserId";
                p.Value = userSearchParameter.UserId;
                p.DbType = System.Data.DbType.Int32;
                result.Add(p);
            }
            if (userSearchParameter != null && !string.IsNullOrEmpty(userSearchParameter.FirstName))
            {
                var p = new SqlParameter();
                p.ParameterName = "@FirstName";
                p.Value = userSearchParameter.FirstName;
                p.DbType = System.Data.DbType.String;
                result.Add(p);
            }
            if (userSearchParameter != null && !string.IsNullOrEmpty(userSearchParameter.LastName))
            {
                var p = new SqlParameter();
                p.ParameterName = "@LastName";
                p.Value = userSearchParameter.LastName;
                p.DbType = System.Data.DbType.String;
                result.Add(p);
            }
            if (userSearchParameter != null && !string.IsNullOrEmpty(userSearchParameter.Password))
            {
                var p = new SqlParameter();
                p.ParameterName = "@Password";
                p.Value = userSearchParameter.Password;
                p.DbType = System.Data.DbType.String;
                result.Add(p);
            }
            return result;
        }
        private UserModel MapModel(SqlDataReader reader)
        {
            if (int.Parse(reader["IsAdmin"].ToString()) == 1)
            {
                return new UserModel()
                {
                    UserId = int.Parse(reader["UserId"].ToString()),
                    IsAdmin = true,
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Password = reader["Password"].ToString()
                };
            }

            return new UserModel()
            {
                UserId = int.Parse(reader["UserId"].ToString()),
                IsAdmin = false,
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Password = reader["Password"].ToString()
            };
        }
        #endregion
    }
}