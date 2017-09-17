using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PmWeb.Core.Scheduler
{
    public class JobManager
    {
        public void ExecuteAllJobs()
        {
            Log.Debug("Início do método ExecuteAllJobs");

            try
            {
                IEnumerable<Type> jobs = GetAllTypesImplementingInterface(typeof(Job));
                if (jobs != null && jobs.Count() > 0)
                {
                    Job instanceJob = null;
                    Thread thread = null;
                    foreach (Type job in jobs)
                    {
                        if (IsRealClass(job))
                        {
                            try
                            {
                                instanceJob = (Job)Activator.CreateInstance(job);
                                Log.Debug(String.Format("O Job \"{0}\" iniciou com sucesso.", instanceJob.GetName()));
                                thread = new Thread(new ThreadStart(instanceJob.ExecuteJob));
                                thread.Start();
                                Log.Debug(String.Format("O Job \"{0}\" finalizou com sucesso.", instanceJob.GetName()));
                            }
                            catch (Exception ex)
                            {
                                Log.Error(String.Format("O Job \"{0}\" não foi possível ser instanciado ou executado. \"{0}\"", job.Name, ex));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Ocorreu um erro ao instanciar ou executar Jobs para o Scheduler Framework.", ex.Message);
            }
            Log.Debug("Fim do método ExecuteAllJobs");
        }

        private IEnumerable<Type> GetAllTypesImplementingInterface(Type desiredType)
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => desiredType.IsAssignableFrom(type));

        }

        public static bool IsRealClass(Type testType)
        {
            return testType.IsAbstract == false
                && testType.IsGenericTypeDefinition == false
                && testType.IsInterface == false;
        }
    }
}
