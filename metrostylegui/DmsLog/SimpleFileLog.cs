using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metrostylegui.DmsLog
{
    public static class Notes
    {
        private static readonly string filename = "log.txt";

        public static void Log(string message)
        {
            try
            {
                CleanLogs();
                using (var fs = new FileStream(filename, FileMode.Append))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(string.Format("{0:yyyyMMddHHmmfffffff}\t{1}", DateTime.Now, message));
                        fs.FlushAsync();
                    }
                }
            }
            catch { }
        }

        private static void CleanLogs()
        {
            var current = new FileInfo(filename);
            if (current.Length > 1024)
            {
                var oldies = new DirectoryInfo(".").EnumerateFiles("log-???????????????????.txt").OrderBy(d => d.LastWriteTime).ToList();
                while (oldies.Count > 9)
                {
                    var f = oldies.First();
                    f.Delete();
                    oldies.Remove(f);
                }
                File.Move(current.Name, string.Format("log-{0:yyyyMMddHHmmfffffff}.txt", DateTime.Now));
            }

            //var pdt = DateTime.ParseExact(dt, "yyyyMMddHHmmfffffff", System.Globalization.CultureInfo.InvariantCulture);
        }

        internal static void Log(Exception e)
        {
            Log(e.Message);
        }
    }
}
