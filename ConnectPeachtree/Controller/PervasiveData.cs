using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pervasive.Data.SqlClient;
using System.Windows.Forms;


namespace ConnectPeachtree.Controller
{
    class PervasiveData
    {
        public static string connString = Properties.Settings.Default.ConnectionString1;


        public static DataTable Execute(String commandText,List<PsqlParameter> parameters = null, String connectionString = null)
        {

            if (connectionString == null)
                connectionString = connString;

            using (PsqlConnection conn = new PsqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
               
                using (PsqlCommand cmd = new PsqlCommand(commandText, conn))
                {
                    // cmd.CommandType = commandType;
                    if (parameters != null)
                        cmd.Parameters.Add(parameters.ToArray());
                    try
                    {
                        conn.Open();
                        // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                        // IDataReader is closed.
                        PsqlDataAdapter da = new PsqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return dt;
                }
            }
        }
    }
}
