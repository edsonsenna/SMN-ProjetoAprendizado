using System.Data;
using System.Data.SqlClient;

namespace BNK.Infra.Data.Infra
{
    public interface IDatabaseConnection
    {
        SqlConnection Connect();
        void ExecuteProcedure(string nomeProcedure);
        void AddParameter(string nomeParametro, object valor);
        void ExecuteNoReturn();
        SqlDataReader ExecuteReader();
        void AddParameterReturn(string parameterName, DbType parameterType);
        int ExecuteNonQueryWithReturn();
    }
}
