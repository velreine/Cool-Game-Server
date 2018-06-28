using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool_Game_Server.Logging
{
    class Logger : ILogger
    {
        public void Log(string message, LOG_SEVERITY severity)
        {
            

            switch (severity)
            {
                case LOG_SEVERITY.INFO:
                    Console.WriteLine($"INFO: {message}");
                    break;
                    
                case LOG_SEVERITY.WARNING:
                    Console.WriteLine($"WARNING: {message}");
                    break;

                case LOG_SEVERITY.CRITICAL:
                    Console.WriteLine($"CRITICAL!!!: {message}");
                    break;

                default:
                    Console.WriteLine($"UNHANDLED?SEVERITY: {message}");
                    break;
            }



        }
    }
}
