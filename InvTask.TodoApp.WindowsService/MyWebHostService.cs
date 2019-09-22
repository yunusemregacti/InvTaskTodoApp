using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using InvTask.TodoApp.Business.Abstract;
using InvTask.TodoApp.Business.Concrete;
using InvTask.TodoApp.DataAccess.Concrete.InMemoryDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Timer = System.Timers.Timer;

namespace InvTask.TodoApp.WindowsService
{
    public class MyWebHostService:WebHostService
    {
        private Timer _timer;

        public MyWebHostService(IWebHost host) : base(host)
        {
            timerOperations();
        }

        private void timerOperations()
        {
            _timer = new Timer();
            _timer.Interval = 30000;
            _timer.Elapsed += new ElapsedEventHandler(_tmr_Tick);
            _timer.Enabled = true;
        }

        protected override void OnStarting(string[] args)
        {

            timerOperations();
            System.Diagnostics.Debugger.Launch();
            base.OnStarting(args);
        }

        public void Deneme(DateTime dateTime)
        {

        }

        protected override void OnStarted()
        {
            timerOperations();
            base.OnStarted();
        }

        private void _tmr_Tick(object sender, ElapsedEventArgs e)
        {
            
        }

        protected override void OnStopping()
        {
            _timer.Enabled = true;
            base.OnStopping();
        }

        protected override void OnStopped()
        {
            _timer.Enabled = true;
            base.OnStopped();
        }
    }

    public static class WebHostServiceExtensions
    {
        public static void RunAsCustomService(this IWebHost host)
        {
            var webHostService = new MyWebHostService(host);
            ServiceBase.Run(webHostService);
        }
    }
}
