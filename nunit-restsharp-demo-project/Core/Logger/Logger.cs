using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace nunit_restsharp_demo_project.Core
{
    public class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger(typeof(Logger));

        public static void InitLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}