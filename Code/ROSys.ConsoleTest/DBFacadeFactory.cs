using ROSys.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.ConsoleTest
{
    public class DBFacadeFactory
    {

        #region Singleton Stuff

        private static IROSysDBFacade instance = null;

        private DBFacadeFactory()
        {
        }

        public static IROSysDBFacade Instance
        {
            get
            {
                if (instance == null)
                    instance = GenerateInstance();
                return instance;
            }
        }

        #endregion

        private static Contracts.IROSysDBFacade GenerateInstance()
        {
            string assemblyName = ConfigurationManager.AppSettings["DBFacadeAssemblyName"];
            string className = ConfigurationManager.AppSettings["DBFacadeClassName"];
            var asm = Assembly.LoadFrom(assemblyName);
            var type = asm.GetType(className);
            return Activator.CreateInstance(type) as IROSysDBFacade;
        }
    }
}
