using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Common.Common
{
   public class Generic
    {
        public  void ErrorLogging(Exception ex, string functionNanme)
        {
            string fileName = Path.GetPathRoot(Environment.SystemDirectory) + "ErrorLogs.txt";
          
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Dispose();
            }
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("=========== "+ functionNanme +"============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===================================== ");

            }
        }
        public int UniqueId()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
