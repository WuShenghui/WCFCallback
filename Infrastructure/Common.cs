using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Infrastructure
{
    public delegate void StoreProcedureProcessInfo(string info);

    public class Common
    {
        private string _resultInfo;
        public string ResultInfo { get; set; }

        public event StoreProcedureProcessInfo ProcessInfoEventHandler;

        public void GetResultInfo(object sender, SqlInfoMessageEventArgs e)
        {
            ResultInfo = e.Message;
            ProcessInfoEventHandler(ResultInfo);
        }
    }
}
