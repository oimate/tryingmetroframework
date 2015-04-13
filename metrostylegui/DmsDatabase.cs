using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace metrostylegui
{
    public delegate void DmsConnectionLostEventHandler(DmsConnectionLostEventArgs e);
    class DmsDatabase
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
                set { id = value; }
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
                                return new DmsUser()
                                {
                                    Id = id.Value
                                };
                            }
                        }
                    }
                }
                catch (SqlException sqlex)
                {
#if DEBUG
                    System.Diagnostics.Debugger.Break();
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
                    System.Diagnostics.Debugger.Break();
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
