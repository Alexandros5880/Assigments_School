using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyNewService
{
    public partial class MyNewService : ServiceBase
    {

        System.Diagnostics.EventLog eventLog1;

        public MyNewService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("In OnStart.");
        }

        protected override void OnStop()
        {
            Console.WriteLine("In OnStop.");
        }
    }
}
