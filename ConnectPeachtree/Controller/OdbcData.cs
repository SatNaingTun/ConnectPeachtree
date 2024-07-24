using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace ConnectPeachtree.Controller
{
    class OdbcData
    {


        public static string connString = Properties.Settings.Default.ConnectionString1;

        public static DataTable Execute(String commandText, List<OdbcParameter> parameters = null, String connectionString = null)
        {
            
            if (connectionString == null)
                connectionString = connString;

            using (OdbcConnection conn = new OdbcConnection(connectionString))
            {
                DataTable dt = new DataTable();
                using (OdbcCommand cmd = new OdbcCommand(commandText, conn))
                {
                   // cmd.CommandType = commandType;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    try
                    {
                        conn.Open();
                        // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                        // IDataReader is closed.
                        OdbcDataAdapter da = new OdbcDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                       
                    }
                    finally
                    {
                        conn.Close();
                    }

                    return dt;
                }
            }
        }


       
    }
}
