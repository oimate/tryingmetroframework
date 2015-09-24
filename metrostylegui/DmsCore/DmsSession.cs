using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metrostylegui
{
    public static class DmsSession
    {
        private static metrostylegui.DmsDatabase.DmsUser user;
        public static string LoggedUser { get { return (user != null) ? user.Login_name : string.Empty; } }
        public static bool IsSomeoneLogged { get { return user != null; } }
        public static string LoggedUserDisplayName { get { return (user != null) ? ((!string.IsNullOrWhiteSpace(user.Display_name)) ? user.Display_name : user.Login_name) : string.Empty; } }

        private static Guid session_id;

        public static bool Login(string login, string pwd)
        {
            if (DmsDatabase.Login(login, pwd, out user, out session_id) == LoginResult.Ok)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Logout(object sender)
        {
            if (DmsDatabase.Logout(LoggedUser, out user, out session_id))
            {
                OnLogout(sender);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static EventHandler LogingOut;
        private static void OnLogout(object sender)
        {
            if (LogingOut != null)
            {
                LogingOut(sender, null);
            }
        }

        private static string connectionString = "Data Source=dbmachine\\durr_systems;Initial Catalog=EMOS_WEB;Persist Security Info=True;User ID=user;Password=user;Connection Timeout = 16";
        internal static string ConnectionString { get { return connectionString; } set { connectionString = value; } }
    }
}
