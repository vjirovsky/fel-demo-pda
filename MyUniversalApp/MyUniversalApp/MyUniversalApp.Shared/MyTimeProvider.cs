using System;
using System.Collections.Generic;
using System.Text;

namespace MyUniversalApp
{
    class MyTimeProvider
    {
        public static string GetMyTime()
        {
            return "Time from shared time provider: " + DateTime.Now.ToString();
        }
    }
}
