using System;
using System.Data;
using System.Data.SqlClient;

namespace BNK.Infra.Data.Infra
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private string _connectionString = "Data Source=EDSON-PC;Initial Catalog=SMN_Bank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection _connection;

        public DatabaseConnection()
        {
            _connection = Connect();
        }

        private SqlCommand Command { get; set; }

        public void AddParameter(string nomeParametro, object valor)
        {
            Command.Parameters.Add(new SqlParameter(nomeParametro, valor ?? DBNull.Value));
        }

        public SqlConnection Connect()
        {
            var connection = new SqlConnection(_connectionString);

            if(connection.State == ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }

            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }

        public void ExecuteNoReturn()
        {
            Command.ExecuteNonQuery();
        }

        public void AddParameterReturn(string parameterName = "@RETURN_VALUE", DbType parameterType = DbType.Int16)
        {
            Command.Parameters.Add(new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.ReturnValue,
                DbType = parameterType
            });
        }

        public int ExecuteNonQueryWithReturn()
        {
            try
            {
                AddParameterReturn();
                Connect();
                Command.ExecuteNonQuery();
                return int.Parse(Command.Parameters["@RETURN_VALUE"].Value.ToString());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw new NotImplementedException();
            }
        }

        public void ExecuteProcedure(string nomeProcedure)
        {
            Command = new SqlCommand(nomeProcedure, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        public SqlDataReader ExecuteReader()
        {
            return Command.ExecuteReader();
        }
    }
}
