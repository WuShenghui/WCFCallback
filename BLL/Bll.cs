using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bll
    {
        public event EventHandler<string> OnProcessStatusEventHandler = (s, e) => { };
        public void GetStoreProcedureData()
        {
            Dal dal = new Dal();
            dal.OnProcessStatusEventHandler += OnProcessStatusEventHandler;

            dal.GetStoreProcedureData();
        }
    }
}
