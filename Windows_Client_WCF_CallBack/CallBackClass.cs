using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_Client_WCF_CallBack;
using Windows_Client_WCF_CallBack.ServiceReference;

namespace WPF_Client_WCF_CallBack
{
   public class RequestCallBack:IServiceCallback
    {
        MainWindow win;
        public RequestCallBack(MainWindow obj)
        {
            win = obj;
        }

        private Department[] _Departments;

        public Department[] Departments
        {
            get { return _Departments; }
            set
            {
                _Departments = value;
            }
        }
        public void SendResult(Department[] arrDept)
        {
            Departments = arrDept;
            //System.Windows.MessageBox.Show("Response  Received " + Departments.Count().ToString());

            win.txtResult.Dispatcher.Invoke(
                    new UpdateTextCallback(this.UpdateText),
                    new object[] { "Response  Received " + Departments.Count().ToString() }
                );
        }


        public void SendStoreProcedureResult(string resultinfo)
        {
            win.txtResult.Dispatcher.Invoke(
                    new UpdateTextCallback(this.UpdateText),
                    new object[] { resultinfo }
                );
        }

        public delegate void UpdateTextCallback(string message);

        private void UpdateText(string message)
        {
            win.txtResult.AppendText(message + "\n");
            if (message.Contains("100"))
            {
                System.Windows.MessageBox.Show("Success");
            }
        }
    }
}
