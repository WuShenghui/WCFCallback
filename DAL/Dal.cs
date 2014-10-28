using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal
    {
        public event EventHandler<string> OnProcessStatusEventHandler = (s, e) => { };

        public void GetStoreProcedureData()
        {
            //case 1:
            string connectionStr = "Data Source=192.168.1.105;Initial Catalog=TestDB;User ID = wsh;Password=wshsq1;";

            //case 2:
            //var cb = new SqlConnectionStringBuilder
            //{
            //    DataSource = "192.168.1.105",
            //    InitialCatalog = "TestDB",
            //    IntegratedSecurity = false, //未部署在IIS中时，使用True正常，但部署到IIS时就改为false
            //    UserID = "wsh",
            //    Password = "wshsq1"
            //};

            //using (var cn = new SqlConnection(cb.ToString()))
            using (var cn = new SqlConnection(connectionStr))
            {
                cn.FireInfoMessageEventOnUserErrors = true;
                cn.Open();
                //cn.InfoMessage += (o, args) => CallBack.SendStoreProcedureResult(args.Message);
                cn.InfoMessage += cn_InfoMessage;

                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_LongProcess";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
        }

       void cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            OnProcessStatusEventHandler(sender,e.Message);
        }

    }
}
