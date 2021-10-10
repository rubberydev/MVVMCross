using System.Collections.Generic;

namespace TipCalculator.Android.Helpers
{/// <summary>
/// classs to keep execution historial in memory
/// </summary>
    public class ExecutionHistoricUtil
    {
        public List<string> ExecutionHistorialInMemory;
        public ExecutionHistoricUtil()
        {
            ExecutionHistorialInMemory = new List<string>();
            instance = this;
        }

        #region Singleton
        static ExecutionHistoricUtil instance;
        public static ExecutionHistoricUtil GetInstance() => instance ?? (instance = new ExecutionHistoricUtil());

        #endregion


    }
}