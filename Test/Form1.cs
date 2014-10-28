using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

        }

        delegate void SendStoreProcedureResult(string info);
        event SendStoreProcedureResult resultEventHandler;
        void Form1_Load(object sender, EventArgs e)
        {
            resultEventHandler = ShowResult;
        }


        private void ShowResult(string info)
        {
            MessageBox.Show(info);
        }


        public event EventHandler<string> OnProcessStatusEventHandler = (s, e) => { MessageBox.Show(e); };
        private void button1_Click(object sender, EventArgs e)
        {
            //Infrastructure.Common common = new Infrastructure.Common();
            //common.ProcessInfoEventHandler += o => resultEventHandler(common.ResultInfo);
            //new Bll().GetStoreProcedureData(common);

            Bll bll = new Bll();
            bll.OnProcessStatusEventHandler += OnProcessStatusEventHandler;
            bll.GetStoreProcedureData();
        }

    }
}
