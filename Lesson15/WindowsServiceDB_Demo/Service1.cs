using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;

namespace WindowsServiceDB_Demo
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost sh;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            sh = new ServiceHost(typeof(Auth));
            sh.Open();
        }

        protected override void OnStop()
        {
            sh.Close();
        }
    }
}
