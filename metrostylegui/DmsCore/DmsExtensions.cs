using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metrostylegui
{
    static class DmsExtensions
    {
        public static string SafeGetString(this System.Data.SqlClient.SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }

        public static DateTime SafeGetDateTime(this System.Data.SqlClient.SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            else
                return DateTime.MinValue;
        }
    }
}
