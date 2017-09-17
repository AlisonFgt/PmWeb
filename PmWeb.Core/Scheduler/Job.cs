using System;
using System.Globalization;
using System.Threading;

namespace PmWeb.Core.Scheduler
{
    public abstract class Job
    {
        protected int counter = 1;

        public void ExecuteJob()
        {
            if (IsRepeatable())
            {
                while (true)
                {
                    DoJob();
                    Thread.Sleep(GetRepetitionIntervalTime());
                }
            }
            else
                DoJob();
        }

        protected static string DataAtual()
        {
            CultureInfo cult = new CultureInfo("pt-BR");
            string dta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", cult);
            return dta;
        }

        public virtual Object GetParameters()
        {
            return null;
        }

        public abstract String GetName();

        public abstract void DoJob();

        public abstract bool IsRepeatable();

        public abstract int GetRepetitionIntervalTime();
    }
}
