using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Utility
{
    public static class KodUret
    {
        public static string Fabrika()
        {
            string kod = null;
            kod += DateTime.Now.Hour;
            kod += DateTime.Now.Year;
            kod += DateTime.Now.Minute;
            kod += DateTime.Now.Month;
            kod += DateTime.Now.Second;
            kod += DateTime.Now.Day;
            return kod;
        }
    }
}
