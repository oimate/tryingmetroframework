using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace metrostylegui
{
    public delegate void DmsConnectionLostEventHandler(DmsConnectionLostEventArgs e);
    public class DmsDatabase
    {
        public ConnectionState ConnectionState { get; set; }

        public event DmsConnectionLostEventHandler DmsConnectionLostEvent;
        private void OnDmsConnectionLost()
        {
            DmsConnectionLostEventHandler localscopeevent = DmsConnectionLostEvent;
            if (DmsConnectionLostEvent != null)
            {
                DmsConnectionLostEvent(new DmsConnectionLostEventArgs() { ConnectionState = ConnectionState });
            }
        }

        public class DmsUser
        {
            private long id;

            public long Id
            {
                get { return id; }
                private set { id = value; }
            }
            
            private string name, firstname, lastname, displayname;

            public string Displayname
            {
                get { return displayname; }
                set { displayname = value; }
            }

            public string Lastname
            {
                get { return lastname; }
                set { lastname = value; }
            }

            public string Firstname
            {
                get { return firstname; }
                set { firstname = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            DateTime lastlogin;

            public DateTime Lastlogin
            {
                get { return lastlogin; }
                set { lastlogin = value; }
            }

            public static DmsUser GetUser(string login, string pwd)
            {
                DmsUser user = null;
                try
                {
                    using (UserDataSet userDataSet = new UserDataSet())
                    {
                        using (UserDataSetTableAdapters.DS_PrmUser_TABTableAdapter adapter = new UserDataSetTableAdapters.DS_PrmUser_TABTableAdapter())
                        {
                            long? id = adapter.Login(login, pwd);
                            if (id.HasValue)
                            {
                                var usera = adapter.GetUserById(id.Value);
                                if (usera[0].Islast_loginNull()) usera[0].last_login = DateTime.MinValue;
                                return new DmsUser()
                                {
                                    Id = id.Value,
                                    Name = usera[0].login_name,
                                    Displayname = usera[0].display_name,
                                    Lastlogin = usera[0].last_login,
                                    Firstname = usera[0].firstname,
                                    Lastname = usera[0].lastname,
                                };
                            }
                        }
                    }
                }
                catch (SqlException sqlex)
                {
#if DEBUG
                    //System.Diagnostics.Debugger.Break();
                    System.Diagnostics.Debug.WriteLine(
                        string.Format("SqlException: {0} errors", sqlex.Errors.Count));
                    foreach (SqlError error in sqlex.Errors)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            string.Format("Error class: {0}, Error message: {1}", error.Class, error.Message));
                    }
#endif
                }
                catch (Exception genericex)
                {
#if DEBUG
                    //System.Diagnostics.Debugger.Break();
                    System.Diagnostics.Debug.WriteLine(genericex.Message);
#endif
                }
                return user;
            }
        }
    }

    public class DmsConnectionLostEventArgs
    {
        public ConnectionState ConnectionState { get; set; }
    }

    public enum ConnectionState
    {
        Connecting,
        ConnectionLost,
        ConnectionAchived,
    }

    public enum SqlExceptionClass
    {
        User,
        Hardware
    }
}
