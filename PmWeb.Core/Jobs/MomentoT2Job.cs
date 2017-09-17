using PmWeb.Core.Scheduler;
using System;

namespace PmWeb.Core.Jobs
{
    public class MomentoT2Job : Job
    {
        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            System.Console.WriteLine(String.Format("O Extrair informações. " + counter.ToString(), this.GetName()));
            System.Console.WriteLine(String.Format("O Job \"{0}\" foi executado.", this.GetName()));
            counter++;
        }

        public override bool IsRepeatable()
        {
            return true;
        }

        public override int GetRepetitionIntervalTime()
        {
            // 2 minuto
            return 120000;
        }
    }
}
