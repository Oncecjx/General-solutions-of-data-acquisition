using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GeneralSystemBoard.Tool
{
    public interface IMySqlHelper
    {
        MySqlDataReader ExecuteReader(string sqlString);
        MySqlDataReader ExecuteReader(string sqlString, params MySqlParameter[] cmdParms);
        int ExecuteSql(string sql);
        int ExecuteSql(string sqlString, params MySqlParameter[] cmdParms);
        DataSet GetDataSet(string sql);
        DataTable GetDataTable(string sql);
        DataSet GetDataSet(string sqlString, params MySqlParameter[] cmdParms);
        object GetSingle(string sqlString, params MySqlParameter[] cmdParms);
        DataSet RunProcedureForDataSet(string storedProcName, IDataParameter[] parameters);

        DataTable GetDataTable(string sql, string ConnectionString);
    }
}
