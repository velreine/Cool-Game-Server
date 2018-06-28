using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool_Game_Server.Logging
{
    interface ILogger
    {
        void Log(string message, LOG_SEVERITY severity);



    }


    enum LOG_SEVERITY
    {
        INFO,
        WARNING,
        CRITICAL,



    }

}
