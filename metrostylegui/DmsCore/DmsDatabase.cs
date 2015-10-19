using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using metrostylegui.DmsLog;

namespace metrostylegui
{

    public static class DmsDatabase
    {
        /// <summary>
        /// Check against database if specified pair of login-pwd exists in Users Table
        /// </summary>
        /// <param name="login">user name part of login pair</param>
        /// <param name="pwd">pwd part of login pair</param>
        /// <param name="user">if login is succesfull, then here will be returned an instance of DmsUser object with user data</param>
        /// <param name="session_id">uniqe number to indentify the session</param>
        /// <returns>if login pair exists, returns Ok, else returns Failed</returns>
        public static LoginResult Login(string login, string pwd, out DmsUser user, out Guid session_id)
        {
            var adapter = new Adapters.DS_PrmUser();
            user = adapter.Login(login, DmsObfuscation.Code(login, pwd));
            if (user != null)
            {
                session_id = Guid.NewGuid();
                adapter.UpdateLoginTimestamp(user.Id, DateTime.Now);
                return LoginResult.Ok;
            }
            else
            {
                user = null;
                session_id = Guid.Empty;
                return LoginResult.Failed;
            }
        }

        public static bool Logout(string login, out DmsUser user, out Guid session_id)
        {
            user = null;
            session_id = Guid.Empty;
            return true;
        }

        public static System.Data.DataTable GetErpWithRange(int offset, int limit)
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.ERP_SelectRange(offset, limit);
        }

        public static System.Data.DataTable GetErpProduction(int lefplant_status)
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.ERP_SelecctStatus(lefplant_status);
        }

        public static System.Data.DataTable GetErpSkidData(int foreignskid,int leftplant)
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.ERP_SelecctBySkidnr(foreignskid, leftplant);
        }

        public static System.Data.DataTable DeleteRow(int foreignskid, int leftplant_status)
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.ERP_DeleteRow(foreignskid, leftplant_status);
        }

        public static System.Data.DataTable GetErpBnsData (int bsn, int leftplant)
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.ERP_SelectByBSNnr(bsn, leftplant);
        }

        public static System.Data.DataTable GetErTop2000()
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.SelecTop1000 ();
        }
        public static System.Data.DataTable MFP_GetStatusSkidFactory()  // all skid on factory
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.MFP_SelectUnitsOnFactory();
        }

        public static System.Data.DataTable MFP_GetHistoricDataForSkid( string time_Start, string time_End, int Skid_Id)
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.MFP_SelectHistoricDataForSkid(time_Start, time_End, Skid_Id);
        }


        public static System.Data.DataTable MFP_GetHistoricDataForAllSkids(string time_Start, string time_End)
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.MFP_SelectHistoricDataForAllUnits(time_Start, time_End);
        }
        public static System.Data.DataTable MFP_GetHistoricDataForBSN(string time_Start, string time_End, int bsn)
        {
            var adapter = new DmsDatabase.Adapters.DMS_ERP();
            return adapter.MFP_SelectHistoricDataForBSN(time_Start, time_End, bsn);
        }



        public class DmsUser
        {
            #region Properties
            public Int64 Id { get; set; }
            public string Login_name { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Display_name { get; set; }
            public string Pwd { get; set; }
            public string Email { get; set; }
            public string Description { get; set; }
            public string Persistent_data { get; set; }
            public string Cardcode { get; set; }
            public DateTime Last_login { get; set; }
            public string Start_url { get; set; }
            public DateTime Expiration_date { get; set; }
            public bool Deactivated { get; set; }
            #endregion
        }

        private static class Adapters
        {
            #region Adapter for DS_PrmUser table
            internal class DS_PrmUser
            {
                private System.Data.SqlClient.SqlDataAdapter _adapter;

                private System.Data.SqlClient.SqlConnection _connection;

                private System.Data.SqlClient.SqlTransaction _transaction;

                System.Data.SqlClient.SqlCommand[] _commandCollection;

                private bool _clearBeforeFill;

                public DS_PrmUser()
                {
                    this.ClearBeforeFill = true;
                }

                protected internal System.Data.SqlClient.SqlDataAdapter Adapter
                {
                    get
                    {
                        if ((this._adapter == null))
                        {
                            this.InitAdapter();
                        }
                        return this._adapter;
                    }
                }

                protected System.Data.SqlClient.SqlCommand[] CommandCollection
                {
                    get
                    {
                        if ((this._commandCollection == null))
                        {
                            this.InitCommandCollection();
                        }
                        return this._commandCollection;
                    }
                }

                internal System.Data.SqlClient.SqlConnection Connection
                {
                    get
                    {
                        if ((this._connection == null))
                        {
                            this.InitConnection();
                        }
                        return this._connection;
                    }
                    set
                    {
                        this._connection = value;
                        if ((this.Adapter.InsertCommand != null))
                        {
                            this.Adapter.InsertCommand.Connection = value;
                        }
                        if ((this.Adapter.DeleteCommand != null))
                        {
                            this.Adapter.DeleteCommand.Connection = value;
                        }
                        if ((this.Adapter.UpdateCommand != null))
                        {
                            this.Adapter.UpdateCommand.Connection = value;
                        }
                        for (int i = 0; (i < this.CommandCollection.Length); i = (i + 1))
                        {
                            if ((this.CommandCollection[i] != null))
                            {
                                ((global::System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).Connection = value;
                            }
                        }
                    }
                }

                internal System.Data.SqlClient.SqlTransaction Transaction
                {
                    get
                    {
                        return this._transaction;
                    }
                    set
                    {
                        this._transaction = value;
                        if (((this.Adapter != null) && (this.Adapter.DeleteCommand != null)))
                        {
                            this.Adapter.DeleteCommand.Transaction = this._transaction;
                        }
                        if (((this.Adapter != null) && (this.Adapter.InsertCommand != null)))
                        {
                            this.Adapter.InsertCommand.Transaction = this._transaction;
                        }
                        if (((this.Adapter != null) && (this.Adapter.UpdateCommand != null)))
                        {
                            this.Adapter.UpdateCommand.Transaction = this._transaction;
                        }
                    }
                }

                public bool ClearBeforeFill
                {
                    get
                    {
                        return this._clearBeforeFill;
                    }
                    set
                    {
                        this._clearBeforeFill = value;
                    }
                }

                private void InitAdapter()
                {
                    this._adapter = new System.Data.SqlClient.SqlDataAdapter();

                    System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();

                    tableMapping.SourceTable = "Table";
                    tableMapping.DataSetTable = "DS_PrmUser_TAB";
                    tableMapping.ColumnMappings.Add("id", "id");
                    tableMapping.ColumnMappings.Add("login_name", "login_name");
                    tableMapping.ColumnMappings.Add("firstname", "firstname");
                    tableMapping.ColumnMappings.Add("lastname", "lastname");
                    tableMapping.ColumnMappings.Add("display_name", "display_name");
                    tableMapping.ColumnMappings.Add("pwd", "pwd");
                    tableMapping.ColumnMappings.Add("email", "email");
                    tableMapping.ColumnMappings.Add("description", "description");
                    tableMapping.ColumnMappings.Add("persistent_data", "persistent_data");
                    tableMapping.ColumnMappings.Add("cardcode", "cardcode");
                    tableMapping.ColumnMappings.Add("last_login", "last_login");
                    tableMapping.ColumnMappings.Add("start_url", "start_url");
                    tableMapping.ColumnMappings.Add("expiration_date", "expiration_date");
                    tableMapping.ColumnMappings.Add("deactivated", "deactivated");

                    this._adapter.TableMappings.Add(tableMapping);

                    #region DeleteCommand
                    this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
                    this._adapter.DeleteCommand.Connection = this.Connection;
                    this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[DS_PrmUser_TAB] WHERE (([id] = @Original_id) AND ([login_name] = @Original_login_name) AND ((@IsNull_firstname = 1 AND [firstname] IS NULL) OR ([firstname] = @Original_firstname)) AND ((@IsNull_lastname = 1 AND [lastname] IS NULL) OR ([lastname] = @Original_lastname)) AND ((@IsNull_display_name = 1 AND [display_name] IS NULL) OR ([display_name] = @Original_display_name)) AND ([pwd] = @Original_pwd) AND ((@IsNull_email = 1 AND [email] IS NULL) OR ([email] = @Original_email)) AND ((@IsNull_description = 1 AND [description] IS NULL) OR ([description] = @Original_description)) AND ((@IsNull_cardcode = 1 AND [cardcode] IS NULL) OR ([cardcode] = @Original_cardcode)) AND ((@IsNull_last_login = 1 AND [last_login] IS NULL) OR ([last_login] = @Original_last_login)) AND ((@IsNull_start_url = 1 AND [start_url] IS NULL) OR ([start_url] = @Original_start_url)) AND ((@IsNull_expiration_date = 1 AND [expiration_date] IS NULL) OR ([expiration_date] = @Original_expiration_date)) AND ((@IsNull_deactivated = 1 AND [deactivated] IS NULL) OR ([deactivated] = @Original_deactivated)))";
                    this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_id", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_login_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_firstname", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_firstname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_lastname", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lastname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_display_name", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_display_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pwd", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_email", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_cardcode", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cardcode", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_last_login", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_last_login", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_start_url", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_start_url", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_expiration_date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_expiration_date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_deactivated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_deactivated", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    #endregion

                    #region Insert Command
                    this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
                    this._adapter.InsertCommand.Connection = this.Connection;
                    this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[DS_PrmUser_TAB] ([id], [login_name], [firstname], [lastname], [display_name], [pwd], [email], [description], [persistent_data], [cardcode], [last_login], [start_url], [expiration_date], [deactivated]) VALUES (@id, @login_name, @firstname, @lastname, @display_name, @pwd, @email, @description, @persistent_data, @cardcode, @last_login, @start_url, @expiration_date, @deactivated); SELECT id, login_name, firstname, lastname, display_name, pwd, email, description, persistent_data, cardcode, last_login, start_url, expiration_date, deactivated FROM DS_PrmUser_TAB WHERE (id = @id)";
                    this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@login_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@display_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@persistent_data", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "persistent_data", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cardcode", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@last_login", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@start_url", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@expiration_date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@deactivated", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion

                    #region Update Command
                    this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
                    this._adapter.UpdateCommand.Connection = this.Connection;
                    this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[DS_PrmUser_TAB] SET [id] = @id, [login_name] = @login_name, [firstn" +
                        "ame] = @firstname, [lastname] = @lastname, [display_name] = @display_name, [pwd]" +
                        " = @pwd, [email] = @email, [description] = @description, [persistent_data] = @pe" +
                        "rsistent_data, [cardcode] = @cardcode, [last_login] = @last_login, [start_url] =" +
                        " @start_url, [expiration_date] = @expiration_date, [deactivated] = @deactivated " +
                        "WHERE (([id] = @Original_id) AND ([login_name] = @Original_login_name) AND ((@Is" +
                        "Null_firstname = 1 AND [firstname] IS NULL) OR ([firstname] = @Original_firstnam" +
                        "e)) AND ((@IsNull_lastname = 1 AND [lastname] IS NULL) OR ([lastname] = @Origina" +
                        "l_lastname)) AND ((@IsNull_display_name = 1 AND [display_name] IS NULL) OR ([dis" +
                        "play_name] = @Original_display_name)) AND ([pwd] = @Original_pwd) AND ((@IsNull_" +
                        "email = 1 AND [email] IS NULL) OR ([email] = @Original_email)) AND ((@IsNull_des" +
                        "cription = 1 AND [description] IS NULL) OR ([description] = @Original_descriptio" +
                        "n)) AND ((@IsNull_cardcode = 1 AND [cardcode] IS NULL) OR ([cardcode] = @Origina" +
                        "l_cardcode)) AND ((@IsNull_last_login = 1 AND [last_login] IS NULL) OR ([last_lo" +
                        "gin] = @Original_last_login)) AND ((@IsNull_start_url = 1 AND [start_url] IS NUL" +
                        "L) OR ([start_url] = @Original_start_url)) AND ((@IsNull_expiration_date = 1 AND" +
                        " [expiration_date] IS NULL) OR ([expiration_date] = @Original_expiration_date)) " +
                        "AND ((@IsNull_deactivated = 1 AND [deactivated] IS NULL) OR ([deactivated] = @Or" +
                        "iginal_deactivated)));\r\nSELECT id, login_name, firstname, lastname, display_name" +
                        ", pwd, email, description, persistent_data, cardcode, last_login, start_url, exp" +
                        "iration_date, deactivated FROM DS_PrmUser_TAB WHERE (id = @id)";
                    this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@login_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@display_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@persistent_data", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "persistent_data", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cardcode", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@last_login", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@start_url", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@expiration_date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@deactivated", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_id", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_login_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_firstname", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_firstname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_lastname", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lastname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_display_name", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_display_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pwd", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_email", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_cardcode", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cardcode", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_last_login", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_last_login", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_start_url", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_start_url", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_expiration_date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_expiration_date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_deactivated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_deactivated", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    #endregion
                }

                private void InitConnection()
                {
                    if (string.IsNullOrWhiteSpace(DmsSession.ConnectionString)) throw new ArgumentException("Connection String");
                    this._connection = new System.Data.SqlClient.SqlConnection();
                    this._connection.ConnectionString = DmsSession.ConnectionString;
                }

                private void InitCommandCollection()
                {
                    this._commandCollection = new global::System.Data.SqlClient.SqlCommand[6];

                    #region Command 0
                    this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[0].Connection = this.Connection;
                    this._commandCollection[0].CommandText = "SELECT id, login_name, firstname, lastname, display_name, pwd, email, description" +
                        ", persistent_data, cardcode, last_login, start_url, expiration_date, deactivated" +
                        " FROM dbo.DS_PrmUser_TAB";
                    this._commandCollection[0].CommandType = System.Data.CommandType.Text;
                    #endregion

                    #region Command 1
                    this._commandCollection[1] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[1].Connection = this.Connection;
                    this._commandCollection[1].CommandText = "SELECT		*\r\nFROM			DS_PrmUser_TAB\r\nWHERE		(id = @id)";
                    this._commandCollection[1].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[1].Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion

                    #region Command 2
                    this._commandCollection[2] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[2].Connection = this.Connection;
                    this._commandCollection[2].CommandText = @"SELECT		DS_PrmUser_TAB.firstname, DS_PrmUser_TAB.lastname, DS_PrmGroup_TAB.name, DS_PrmUser_TAB.login_name, DS_PrmUser_TAB.pwd, 
						 DS_PrmUser_TAB.display_name, DS_PrmUser_TAB.last_login, DS_PrmGroup_TAB.esm_gr, DS_PrmGroup_TAB.esm_ur
FROM			DS_PrmUsers_Groups_TAB INNER JOIN
						 DS_PrmUser_TAB ON DS_PrmUsers_Groups_TAB.user_id = DS_PrmUser_TAB.id INNER JOIN
						 DS_PrmGroup_TAB ON DS_PrmUsers_Groups_TAB.group_id = DS_PrmGroup_TAB.id
WHERE		(DS_PrmUser_TAB.id = @Id)";
                    this._commandCollection[2].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[2].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion

                    #region Command 3 - Login()
                    this._commandCollection[3] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[3].Connection = this.Connection;
                    this._commandCollection[3].CommandText = "SELECT id, login_name, firstname, lastname, display_name, pwd, email, description, persistent_data, cardcode, last_login, start_url, expiration_date, deactivated FROM dbo.DS_PrmUser_TAB Where login_name=@login and pwd=@pwd";
                    this._commandCollection[3].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[3].Parameters.Add(new System.Data.SqlClient.SqlParameter("@login", System.Data.SqlDbType.NVarChar, 32, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._commandCollection[3].Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 512, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion

                    #region Command 4 - UpdateLoginTimestamp()
                    this._commandCollection[4] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[4].Connection = this.Connection;
                    this._commandCollection[4].CommandText = "UPDATE DS_PrmUser_TAB SET last_login = @last_login WHERE id = @Id";
                    this._commandCollection[4].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[4].Parameters.Add(new System.Data.SqlClient.SqlParameter("@last_login", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._commandCollection[4].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    #endregion

                    #region Command 5
                    this._commandCollection[5] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[5].Connection = this.Connection;
                    this._commandCollection[5].CommandText = "SELECT id, login_name, firstname, lastname, display_name, pwd, email, description, persistent_data, cardcode, last_login, start_url, expiration_date, deactivated FROM dbo.DS_PrmUser_TAB WHERE id=@Id";
                    this._commandCollection[5].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@login_name", System.Data.SqlDbType.NVarChar, 32, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstname", System.Data.SqlDbType.NVarChar, 32, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastname", System.Data.SqlDbType.NVarChar, 32, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@display_name", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 512, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion
                }

                public virtual DmsUser Login(string login, string pwd)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[3];
                    if ((login == null))
                    {
                        throw new System.ArgumentNullException("login");
                    }
                    else
                    {
                        command.Parameters[0].Value = ((string)(login));
                    }
                    if ((pwd == null))
                    {
                        throw new System.ArgumentNullException("pwd");
                    }
                    else
                    {
                        command.Parameters[1].Value = ((string)(pwd));
                    }


                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        try
                        {
                            command.Connection.Open();
                        }
                        catch (Exception ex)
                        {
                            string dupa = ex.ToString();
                        }
                    }

                    DmsUser returnValue = null;
                    try
                    {
                        if (command.Connection.State == System.Data.ConnectionState.Open)
                        {


                            var reader = command.ExecuteReader();
                            try
                            {
                                if (reader.Read())
                                {
                                    returnValue = new DmsUser()
                                    {
                                        Id = reader.GetInt64(0),
                                        Login_name = reader.SafeGetString(1),
                                        Firstname = reader.SafeGetString(2),
                                        Lastname = reader.SafeGetString(3),
                                        Display_name = reader.SafeGetString(4),
                                        Pwd = reader.SafeGetString(5),
                                        Email = reader.SafeGetString(6),
                                        Description = reader.SafeGetString(7),
                                        Persistent_data = reader.SafeGetString(8),
                                        Cardcode = reader.SafeGetString(9),
                                        Last_login = reader.SafeGetDateTime(10),
                                        Start_url = reader.SafeGetString(11),
                                        Expiration_date = reader.SafeGetDateTime(12),
                                        Deactivated = reader.GetBoolean(13)
                                    };
                                }
                            }

                            catch
                            {
                                returnValue = null;
                            }
                            finally
                            {
                                if (reader != null && !reader.IsClosed)
                                    reader.Close();
                            }
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }
                    return returnValue;
                }

     

                internal void UpdateLoginTimestamp(long? id, DateTime dateTime)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[4];
                    if ((id == null))
                    {
                        return;
                    }
                    else
                    {
                        command.Parameters[1].Value = id.Value;
                    }
                    if ((dateTime == null))
                    {
                        throw new System.ArgumentNullException("dateTime");
                    }
                    else
                    {
                        command.Parameters[0].Value = dateTime;
                    }

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }
                    object returnValue;
                    try
                    {
                        returnValue = command.ExecuteNonQuery();
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }
                    //if (((returnValue == null)
                    //			|| (returnValue.GetType() == typeof(System.DBNull))))
                    //{
                    //	return new System.Nullable<long>();
                    //}
                    //else
                    //{
                    //	return new System.Nullable<long>(((long)(returnValue)));
                    //}
                }
            }
            #endregion

            #region Adapter for MDS_ERP table
            internal class DMS_ERP
            {
                private System.Data.SqlClient.SqlDataAdapter _adapter;

                private System.Data.SqlClient.SqlConnection _connection;

                private System.Data.SqlClient.SqlTransaction _transaction;

                System.Data.SqlClient.SqlCommand[] _commandCollection;

                private bool _clearBeforeFill;

                public DMS_ERP()
                {
                    this.ClearBeforeFill = true;
                }

                protected internal System.Data.SqlClient.SqlDataAdapter Adapter
                {
                    get
                    {
                        if ((this._adapter == null))
                        {
                            this.InitAdapter();
                        }
                        return this._adapter;
                    }
                }

                protected System.Data.SqlClient.SqlCommand[] CommandCollection
                {
                    get
                    {
                        if ((this._commandCollection == null))
                        {
                            this.InitCommandCollection();
                        }
                        return this._commandCollection;
                    }
                }

                internal System.Data.SqlClient.SqlConnection Connection
                {
                    get
                    {
                        if ((this._connection == null))
                        {
                            this.InitConnection();
                        }
                        return this._connection;
                    }
                    set
                    {
                        this._connection = value;
                        if ((this.Adapter.InsertCommand != null))
                        {
                            this.Adapter.InsertCommand.Connection = value;
                        }
                        if ((this.Adapter.DeleteCommand != null))
                        {
                            this.Adapter.DeleteCommand.Connection = value;
                        }
                        if ((this.Adapter.UpdateCommand != null))
                        {
                            this.Adapter.UpdateCommand.Connection = value;
                        }
                        for (int i = 0; (i < this.CommandCollection.Length); i = (i + 1))
                        {
                            if ((this.CommandCollection[i] != null))
                            {
                                ((global::System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).Connection = value;
                            }
                        }
                    }
                }

                internal System.Data.SqlClient.SqlTransaction Transaction
                {
                    get
                    {
                        return this._transaction;
                    }
                    set
                    {
                        this._transaction = value;
                        if (((this.Adapter != null) && (this.Adapter.DeleteCommand != null)))
                        {
                            this.Adapter.DeleteCommand.Transaction = this._transaction;
                        }
                        if (((this.Adapter != null) && (this.Adapter.InsertCommand != null)))
                        {
                            this.Adapter.InsertCommand.Transaction = this._transaction;
                        }
                        if (((this.Adapter != null) && (this.Adapter.UpdateCommand != null)))
                        {
                            this.Adapter.UpdateCommand.Transaction = this._transaction;
                        }
                    }
                }

                public bool ClearBeforeFill
                {
                    get
                    {
                        return this._clearBeforeFill;
                    }
                    set
                    {
                        this._clearBeforeFill = value;
                    }
                }

                private void InitAdapter()
                {
                    this._adapter = new System.Data.SqlClient.SqlDataAdapter();

                    System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();

                    tableMapping.SourceTable = "Table";
                    tableMapping.DataSetTable = "DMS_ERP";
                    tableMapping.ColumnMappings.Add("Id", "Id");
                    tableMapping.ColumnMappings.Add("dupa", "ForeignSkid");
                    tableMapping.ColumnMappings.Add("Derivative Code", "DerivativeCode");
                    tableMapping.ColumnMappings.Add("Colour", "Colour");
                    tableMapping.ColumnMappings.Add("BSN", "BSN");
                    tableMapping.ColumnMappings.Add("Track", "Track");
                    tableMapping.ColumnMappings.Add("Roof", "Roof");
                    tableMapping.ColumnMappings.Add("Door", "Door");
                    tableMapping.ColumnMappings.Add("Spare", "Spare");
                    tableMapping.ColumnMappings.Add("LeftPlant", "LeftPlant");
                    tableMapping.ColumnMappings.Add("Timestamp", "Timestamp");
                    tableMapping.ColumnMappings.Add("fk_User", "fk_User");

                    this._adapter.TableMappings.Add(tableMapping);

                    #region DeleteCommand
                    this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
                    this._adapter.DeleteCommand.Connection = this.Connection;
                    this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[DS_PrmUser_TAB] WHERE (([id] = @Original_id) AND ([login_name] = @Original_login_name) AND ((@IsNull_firstname = 1 AND [firstname] IS NULL) OR ([firstname] = @Original_firstname)) AND ((@IsNull_lastname = 1 AND [lastname] IS NULL) OR ([lastname] = @Original_lastname)) AND ((@IsNull_display_name = 1 AND [display_name] IS NULL) OR ([display_name] = @Original_display_name)) AND ([pwd] = @Original_pwd) AND ((@IsNull_email = 1 AND [email] IS NULL) OR ([email] = @Original_email)) AND ((@IsNull_description = 1 AND [description] IS NULL) OR ([description] = @Original_description)) AND ((@IsNull_cardcode = 1 AND [cardcode] IS NULL) OR ([cardcode] = @Original_cardcode)) AND ((@IsNull_last_login = 1 AND [last_login] IS NULL) OR ([last_login] = @Original_last_login)) AND ((@IsNull_start_url = 1 AND [start_url] IS NULL) OR ([start_url] = @Original_start_url)) AND ((@IsNull_expiration_date = 1 AND [expiration_date] IS NULL) OR ([expiration_date] = @Original_expiration_date)) AND ((@IsNull_deactivated = 1 AND [deactivated] IS NULL) OR ([deactivated] = @Original_deactivated)))";
                    this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_id", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_login_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_firstname", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_firstname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_lastname", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lastname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_display_name", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_display_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pwd", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_email", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_cardcode", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cardcode", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_last_login", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_last_login", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_start_url", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_start_url", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_expiration_date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_expiration_date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_deactivated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_deactivated", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    #endregion

                    #region Insert Command
                    this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
                    this._adapter.InsertCommand.Connection = this.Connection;
                    this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[DS_PrmUser_TAB] ([id], [login_name], [firstname], [lastname], [display_name], [pwd], [email], [description], [persistent_data], [cardcode], [last_login], [start_url], [expiration_date], [deactivated]) VALUES (@id, @login_name, @firstname, @lastname, @display_name, @pwd, @email, @description, @persistent_data, @cardcode, @last_login, @start_url, @expiration_date, @deactivated); SELECT id, login_name, firstname, lastname, display_name, pwd, email, description, persistent_data, cardcode, last_login, start_url, expiration_date, deactivated FROM DS_PrmUser_TAB WHERE (id = @id)";
                    this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@login_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@display_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@persistent_data", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "persistent_data", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cardcode", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@last_login", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@start_url", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@expiration_date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@deactivated", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion

                    #region Update Command
                    this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
                    this._adapter.UpdateCommand.Connection = this.Connection;
                    this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[DS_PrmUser_TAB] SET [id] = @id, [login_name] = @login_name, [firstn" +
                        "ame] = @firstname, [lastname] = @lastname, [display_name] = @display_name, [pwd]" +
                        " = @pwd, [email] = @email, [description] = @description, [persistent_data] = @pe" +
                        "rsistent_data, [cardcode] = @cardcode, [last_login] = @last_login, [start_url] =" +
                        " @start_url, [expiration_date] = @expiration_date, [deactivated] = @deactivated " +
                        "WHERE (([id] = @Original_id) AND ([login_name] = @Original_login_name) AND ((@Is" +
                        "Null_firstname = 1 AND [firstname] IS NULL) OR ([firstname] = @Original_firstnam" +
                        "e)) AND ((@IsNull_lastname = 1 AND [lastname] IS NULL) OR ([lastname] = @Origina" +
                        "l_lastname)) AND ((@IsNull_display_name = 1 AND [display_name] IS NULL) OR ([dis" +
                        "play_name] = @Original_display_name)) AND ([pwd] = @Original_pwd) AND ((@IsNull_" +
                        "email = 1 AND [email] IS NULL) OR ([email] = @Original_email)) AND ((@IsNull_des" +
                        "cription = 1 AND [description] IS NULL) OR ([description] = @Original_descriptio" +
                        "n)) AND ((@IsNull_cardcode = 1 AND [cardcode] IS NULL) OR ([cardcode] = @Origina" +
                        "l_cardcode)) AND ((@IsNull_last_login = 1 AND [last_login] IS NULL) OR ([last_lo" +
                        "gin] = @Original_last_login)) AND ((@IsNull_start_url = 1 AND [start_url] IS NUL" +
                        "L) OR ([start_url] = @Original_start_url)) AND ((@IsNull_expiration_date = 1 AND" +
                        " [expiration_date] IS NULL) OR ([expiration_date] = @Original_expiration_date)) " +
                        "AND ((@IsNull_deactivated = 1 AND [deactivated] IS NULL) OR ([deactivated] = @Or" +
                        "iginal_deactivated)));\r\nSELECT id, login_name, firstname, lastname, display_name" +
                        ", pwd, email, description, persistent_data, cardcode, last_login, start_url, exp" +
                        "iration_date, deactivated FROM DS_PrmUser_TAB WHERE (id = @id)";
                    this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@login_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@display_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@persistent_data", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "persistent_data", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cardcode", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@last_login", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@start_url", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@expiration_date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@deactivated", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_id", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_login_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_firstname", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_firstname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_lastname", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lastname", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_display_name", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_display_name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pwd", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_email", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "email", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "description", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_cardcode", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cardcode", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "cardcode", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_last_login", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_last_login", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_start_url", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_start_url", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "start_url", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_expiration_date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_expiration_date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "expiration_date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_deactivated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
                    this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_deactivated", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "deactivated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    #endregion
                }

                private void InitConnection()
                {
                    if (string.IsNullOrWhiteSpace(DmsSession.ConnectionString)) throw new ArgumentException("Connection String");
                    this._connection = new System.Data.SqlClient.SqlConnection();
                    this._connection.ConnectionString = DmsSession.ConnectionString;
                }

                private void InitCommandCollection()
                {
                    this._commandCollection = new global::System.Data.SqlClient.SqlCommand[14];

                    #region Command 0
                    this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[0].Connection = this.Connection;
                    this._commandCollection[0].CommandText = @"SELECT TOP 2000 * FROM dbo.DMS_ERP";
                    this._commandCollection[0].CommandType = System.Data.CommandType.Text;
                    #endregion

                    #region Command 1 - Select Range
                    this._commandCollection[1] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[1].Connection = this.Connection;
                    this._commandCollection[1].CommandText = @"WITH Results_CTE AS ( SELECT [ForeignSkid] as 'Skid Nr', [Track], [DerivativeCode] as 'Derivative Code', [Colour], [BSN], [Roof], [Door], [Spare], [LeftPlant] as 'Left Plant', [Timestamp], UpdatedOnMfp as 'MFP', [Id], ROW_NUMBER() OVER (ORDER BY Id desc) AS RowNum FROM DMS_ERP) SELECT * FROM Results_CTE WHERE RowNum >= @Offset AND RowNum < @Offset + @Limit";
                    this._commandCollection[1].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[1].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Offset", System.Data.SqlDbType.Int));
                    this._commandCollection[1].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Limit", System.Data.SqlDbType.Int));
                    #endregion

                    #region Command 2
                    this._commandCollection[2] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[2].Connection = this.Connection;
                    this._commandCollection[2].CommandText = @"SELECT * FROM dbo.DMS_ERP WHERE (Id = @Id)";
                    this._commandCollection[2].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[2].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, 0, 0, "Id", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion

                    #region Command 3 - Login()
                    this._commandCollection[3] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[3].Connection = this.Connection;
                    this._commandCollection[3].CommandText = "SELECT id, login_name, firstname, lastname, display_name, pwd, email, description, persistent_data, cardcode, last_login, start_url, expiration_date, deactivated FROM dbo.DS_PrmUser_TAB Where login_name=@login and pwd=@pwd";
                    this._commandCollection[3].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[3].Parameters.Add(new System.Data.SqlClient.SqlParameter("@login", System.Data.SqlDbType.NVarChar, 32, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._commandCollection[3].Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 512, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion

                    #region Command 4 - UpdateLoginTimestamp()
                    this._commandCollection[4] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[4].Connection = this.Connection;
                    this._commandCollection[4].CommandText = "UPDATE DS_PrmUser_TAB SET last_login = @last_login WHERE id = @Id";
                    this._commandCollection[4].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[4].Parameters.Add(new System.Data.SqlClient.SqlParameter("@last_login", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, 0, 0, "last_login", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    this._commandCollection[4].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    #endregion

                    #region Command 5
                    this._commandCollection[5] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[5].Connection = this.Connection;
                    this._commandCollection[5].CommandText = "SELECT id, login_name, firstname, lastname, display_name, pwd, email, description, persistent_data, cardcode, last_login, start_url, expiration_date, deactivated FROM dbo.DS_PrmUser_TAB WHERE id=@Id";
                    this._commandCollection[5].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.Input, 0, 0, "id", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@login_name", System.Data.SqlDbType.NVarChar, 32, System.Data.ParameterDirection.Input, 0, 0, "login_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstname", System.Data.SqlDbType.NVarChar, 32, System.Data.ParameterDirection.Input, 0, 0, "firstname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastname", System.Data.SqlDbType.NVarChar, 32, System.Data.ParameterDirection.Input, 0, 0, "lastname", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@display_name", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Input, 0, 0, "display_name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    //this._commandCollection[5].Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 512, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
                    #endregion

                    #region Command 6  search units by paramter Left lant
                    this._commandCollection[6] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[6].Connection = this.Connection;
                    this._commandCollection[6].CommandText = @"Select * from DMS_ERP where (LeftPlant = @leftplant)";
                    this._commandCollection[6].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[6].Parameters.Add(new System.Data.SqlClient.SqlParameter("@leftplant", System.Data.SqlDbType.Int));
                    #endregion

                    #region Command 7  search units by paramter fkid id
                    this._commandCollection[7] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[7].Connection = this.Connection;
                    this._commandCollection[7].CommandText = @"Select * from DMS_ERP where (ForeignSkid = @foreignskid) and (LeftPlant = @leftplant)";
                    this._commandCollection[7].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[7].Parameters.Add(new System.Data.SqlClient.SqlParameter("@foreignskid", System.Data.SqlDbType.Int));
                    this._commandCollection[7].Parameters.Add(new System.Data.SqlClient.SqlParameter("@leftplant", System.Data.SqlDbType.Int));
                    #endregion

                    #region Command 8  remove row by  fkid id actual in plant or if left plant
                    this._commandCollection[8] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[8].Connection = this.Connection;
                    this._commandCollection[8].CommandText = @"Delete from DMS_ERP where (ForeignSkid = @foreignskid) and (LeftPlant = @leftplant)";
                    this._commandCollection[8].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[8].Parameters.Add(new System.Data.SqlClient.SqlParameter("@foreignskid", System.Data.SqlDbType.Int));
                    this._commandCollection[8].Parameters.Add(new System.Data.SqlClient.SqlParameter("@leftplant", System.Data.SqlDbType.Int));
                    #endregion

                    #region Command 9  search units by paramter fkid id
                    this._commandCollection[9] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[9].Connection = this.Connection;
                    this._commandCollection[9].CommandText = @"Select * from DMS_ERP where (BSN = @bsn) and (LeftPlant = @leftplant)";
                    this._commandCollection[9].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[9].Parameters.Add(new System.Data.SqlClient.SqlParameter("@bsn", System.Data.SqlDbType.Int));
                    this._commandCollection[9].Parameters.Add(new System.Data.SqlClient.SqlParameter("@leftplant", System.Data.SqlDbType.Int));
                    #endregion

                    #region Command 10  search units in MFP on plant 
                    this._commandCollection[10] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[10].Connection = this.Connection;
                    this._commandCollection[10].CommandText = @"Select * from DMS_ERP join DMS_MFP on DMS_ERP.ForeignSkid = DMS_MFP.fk_LocalSkidNr join DMS_MFPDesc on DMS_MFP.MfpPos = DMS_MFPDesc.fk_MfpPos  where DMS_ERP.LeftPlant = '0'";                  
                    this._commandCollection[10].CommandType = System.Data.CommandType.Text;
                    #endregion
                    #region Command 11  search historic units by skid id with timestamp 
                    this._commandCollection[11] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[11].Connection = this.Connection;
                    this._commandCollection[11].CommandText = @"Select * from DMS_MFPHistoric join DMS_MFPDesc on DMS_MFPHistoric.MfpPos= DMS_MFPDesc.fk_MfpPos join DMS_ERP on DMS_MFPHistoric.LocalSkidId=DMS_ERP.ForeignSkid where DMS_MFPHistoric.Timestamp between @time_Start and @time_End and DMS_ERP.Timestamp  between @time_Start and @time_End and (DMS_MFPHistoric.LocalSkidId = @localSkid) order by LocalSkidId ";  
                    this._commandCollection[11].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[11].Parameters.Add(new System.Data.SqlClient.SqlParameter("@time_Start", System.Data.SqlDbType.DateTime2));
                    this._commandCollection[11].Parameters.Add(new System.Data.SqlClient.SqlParameter("@time_End", System.Data.SqlDbType.DateTime2));
                    this._commandCollection[11].Parameters.Add(new System.Data.SqlClient.SqlParameter("@localSkid", System.Data.SqlDbType.Int));
                    #endregion
                    #region Command 12  search historic  for all skids  with timestamp
                    this._commandCollection[12] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[12].Connection = this.Connection;
                    this._commandCollection[12].CommandText = @"Select * from DMS_MFPHistoric join DMS_MFPDesc on DMS_MFPHistoric.MfpPos= DMS_MFPDesc.fk_MfpPos join DMS_ERP on DMS_MFPHistoric.LocalSkidId=DMS_ERP.ForeignSkid where DMS_MFPHistoric.Timestamp between @time_Start and @time_End and DMS_ERP.Timestamp  between @time_Start and @time_End order by LocalSkidId ";
                    this._commandCollection[12].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[12].Parameters.Add(new System.Data.SqlClient.SqlParameter("@time_Start", System.Data.SqlDbType.DateTime2));
                    this._commandCollection[12].Parameters.Add(new System.Data.SqlClient.SqlParameter("@time_End", System.Data.SqlDbType.DateTime2));
                    #endregion
                    #region Command 13  search historic units by BSN with timestamp
                    this._commandCollection[13] = new System.Data.SqlClient.SqlCommand();
                    this._commandCollection[13].Connection = this.Connection;
                    this._commandCollection[13].CommandText = @"Select * from DMS_MFPHistoric join DMS_MFPDesc on DMS_MFPHistoric.MfpPos= DMS_MFPDesc.fk_MfpPos join DMS_ERP on DMS_MFPHistoric.LocalSkidId=DMS_ERP.ForeignSkid where DMS_MFPHistoric.Timestamp between @time_Start and @time_End and DMS_ERP.Timestamp  between @time_Start and @time_End and (DMS_ERP.BSN = @bsn) order by BSN ";
                    this._commandCollection[13].CommandType = System.Data.CommandType.Text;
                    this._commandCollection[13].Parameters.Add(new System.Data.SqlClient.SqlParameter("@time_Start", System.Data.SqlDbType.DateTime2));
                    this._commandCollection[13].Parameters.Add(new System.Data.SqlClient.SqlParameter("@time_End", System.Data.SqlDbType.DateTime2));
                    this._commandCollection[13].Parameters.Add(new System.Data.SqlClient.SqlParameter("@bsn", System.Data.SqlDbType.Int));
                    #endregion
                }
                internal System.Data.DataTable SelecTop1000()
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[0];   //bylo 1

                    //var dt = new DMS_ERP_DT();
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }

                internal System.Data.DataTable ERP_SelectRange(int offset, int limit)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[1];   //bylo 1
                    command.Parameters[0].Value = offset;
                    command.Parameters[1].Value = limit;

                    //var dt = new DMS_ERP_DT();
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }
                internal System.Data.DataTable ERP_SelecctStatus(int leftplant)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[6];   //bylo 1
                    command.Parameters[0].Value = leftplant;
                    //   command.Parameters[1].Value = limit;

                    //var dt = new DMS_ERP_DT();
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }
                internal System.Data.DataTable ERP_SelecctBySkidnr(int foreignskid, int leftplant)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[7];   //bylo 1
                    command.Parameters[0].Value = foreignskid;
                    command.Parameters[1].Value = leftplant;

                    //var dt = new DMS_ERP_DT();
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }
                internal System.Data.DataTable ERP_DeleteRow(int foreignskid, int leftplant)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[8];
                    command.Parameters[0].Value = foreignskid;
                    command.Parameters[1].Value = leftplant;

                    //var dt = new DMS_ERP_DT();
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }
                internal System.Data.DataTable ERP_SelectByBSNnr(int bsn, int leftplant)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[9];
                    command.Parameters[0].Value = bsn;
                    command.Parameters[1].Value = leftplant;

                    //var dt = new DMS_ERP_DT();
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }
                internal System.Data.DataTable MFP_SelectUnitsOnFactory()
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[10];
                    //var dt = new DMS_ERP_DT();
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }
                internal System.Data.DataTable MFP_SelectHistoricDataForSkid(string timeStart, string timeEnd, int localSkidId)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[11];
                    command.Parameters[0].Value = timeStart;
                    command.Parameters[1].Value = timeEnd;
                    command.Parameters[2].Value = localSkidId;
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }
                internal System.Data.DataTable MFP_SelectHistoricDataForAllUnits(string timeStart, string timeEnd)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[12];
                    command.Parameters[0].Value = timeStart;
                    command.Parameters[1].Value = timeEnd;
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }
                internal System.Data.DataTable MFP_SelectHistoricDataForBSN(string timeStart, string timeEnd, int bsn)
                {
                    System.Data.SqlClient.SqlCommand command = this.CommandCollection[13];
                    command.Parameters[0].Value = timeStart;
                    command.Parameters[1].Value = timeEnd;
                    command.Parameters[2].Value = bsn;
                    var dt = new System.Data.DataTable();

                    System.Data.ConnectionState previousConnectionState = command.Connection.State;
                    if (((command.Connection.State & System.Data.ConnectionState.Open)
                                != System.Data.ConnectionState.Open))
                    {
                        command.Connection.Open();
                    }

                    try
                    {
                        var reader = command.ExecuteReader();

                        try
                        {
                            dt.Load(reader, System.Data.LoadOption.OverwriteChanges);
                        }
                        catch (Exception ex)
                        {
                            Notes.Log(ex);
                            return null;
                        }
                        finally
                        {
                            if (reader != null && !reader.IsClosed)
                                reader.Close();
                        }
                    }
                    finally
                    {
                        if ((previousConnectionState == System.Data.ConnectionState.Closed))
                        {
                            command.Connection.Close();
                        }
                    }

                    return dt;
                }


            }
            #endregion

            #region Adapter for MDS_MDS table
            // TODO Implementation of MDS_MDS table adapter
            #endregion
        }

        #region class DMS_ERP_R
        public class DMS_ERP_R : global::System.Data.DataRow
        {
            private DMS_ERP_DT innerTable;

            internal DMS_ERP_R(global::System.Data.DataRowBuilder rb) :
                base(rb)
            {
                this.innerTable = ((DMS_ERP_DT)(this.Table));
            }

            public int id
            {
                get
                {
                    return ((int)(this[this.innerTable.Id_Col]));
                }
                set
                {
                    this[this.innerTable.Id_Col] = value;
                }
            }

            public int foreign_skid
            {
                get
                {
                    return ((int)(this[this.innerTable.ForeignSkid_Col]));
                }
                set
                {
                    this[this.innerTable.ForeignSkid_Col] = value;
                }
            }

            public int derivative_code
            {
                get
                {
                    return ((int)(this[this.innerTable.DerivativeCode_Col]));
                }
                set
                {
                    this[this.innerTable.DerivativeCode_Col] = value;
                }
            }

            public int colour
            {
                get
                {
                    return ((int)(this[this.innerTable.Colour_Col]));
                }
                set
                {
                    this[this.innerTable.Colour_Col] = value;
                }
            }

            public int bsn
            {
                get
                {
                    return ((int)(this[this.innerTable.BSN_Col]));
                }
                set
                {
                    this[this.innerTable.BSN_Col] = value;
                }
            }

            public int track
            {
                get
                {
                    return ((int)(this[this.innerTable.Track_Col]));
                }
                set
                {
                    this[this.innerTable.Track_Col] = value;
                }
            }

            public int roof
            {
                get
                {
                    return ((int)(this[this.innerTable.Roof_Col]));
                }
                set
                {
                    this[this.innerTable.Roof_Col] = value;
                }
            }

            public int door
            {
                get
                {
                    return ((int)(this[this.innerTable.Door_Col]));
                }
                set
                {
                    this[this.innerTable.Door_Col] = value;
                }
            }

            public int spare
            {
                get
                {
                    return ((int)(this[this.innerTable.Spare_Col]));
                }
                set
                {
                    this[this.innerTable.Spare_Col] = value;
                }
            }

            public bool leftplant
            {
                get
                {
                    return ((bool)(this[this.innerTable.LeftPlant_Col]));
                }
                set
                {
                    this[this.innerTable.LeftPlant_Col] = value;
                }
            }

            public System.DateTime timestamp
            {
                get
                {
                    try
                    {
                        return ((global::System.DateTime)(this[this.innerTable.Timestamp_Col]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new global::System.Data.StrongTypingException("The value for column \'Timestamp\' in table \'DMS_ERP\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.innerTable.Timestamp_Col] = value;
                }
            }

            public Int64 fk_user
            {
                get
                {
                    try
                    {
                        return ((Int64)(this[this.innerTable.Fk_User_Col]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new global::System.Data.StrongTypingException("The value for column \'start_url\' in table \'DS_PrmUser_TAB\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.innerTable.Fk_User_Col] = value;
                }
            }

            //example for setting null
            //public void SetdeactivatedNull()
            //{
            //    this[this.innerTable.deactivatedColumn] = global::System.Convert.DBNull;
            //}
        }
        #endregion

        #region class DMS_ERP_DT
        public class DMS_ERP_DT : global::System.Data.TypedTableBase<DMS_ERP_R>
        {

            private global::System.Data.DataColumn id_Col;
            private global::System.Data.DataColumn foreignSkid_Col;
            private global::System.Data.DataColumn derivativeCode_Col;
            private global::System.Data.DataColumn colour_Col;
            private global::System.Data.DataColumn bSN_Col;
            private global::System.Data.DataColumn track_Col;
            private global::System.Data.DataColumn roof_Col;
            private global::System.Data.DataColumn door_Col;
            private global::System.Data.DataColumn spare_Col;
            private global::System.Data.DataColumn leftPlant_Col;
            private global::System.Data.DataColumn timestamp_Col;
            private global::System.Data.DataColumn fk_User_Col;

            private static System.DateTime TimestampCol_defaultValue = global::System.DateTime.Parse("1900-01-01T00:00:00");

            public DMS_ERP_DT()
            {
                this.TableName = "DMS_ERP";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DMS_ERP_DT(global::System.Data.DataTable table)
            {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace))
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }

            protected DMS_ERP_DT(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
            {
                this.InitVars();
            }

            public global::System.Data.DataColumn Id_Col
            {
                get
                {
                    return this.id_Col;
                }
            }

            public global::System.Data.DataColumn ForeignSkid_Col
            {
                get
                {
                    return this.foreignSkid_Col;
                }
            }

            public global::System.Data.DataColumn DerivativeCode_Col
            {
                get
                {
                    return this.derivativeCode_Col;
                }
            }

            public global::System.Data.DataColumn Colour_Col
            {
                get
                {
                    return this.colour_Col;
                }
            }

            public global::System.Data.DataColumn BSN_Col
            {
                get
                {
                    return this.bSN_Col;
                }
            }

            public global::System.Data.DataColumn Track_Col
            {
                get
                {
                    return this.track_Col;
                }
            }

            public global::System.Data.DataColumn Roof_Col
            {
                get
                {
                    return this.roof_Col;
                }
            }

            public global::System.Data.DataColumn Door_Col
            {
                get
                {
                    return this.door_Col;
                }
            }

            public global::System.Data.DataColumn Spare_Col
            {
                get
                {
                    return this.spare_Col;
                }
            }

            public global::System.Data.DataColumn LeftPlant_Col
            {
                get
                {
                    return this.leftPlant_Col;
                }
            }

            public global::System.Data.DataColumn Timestamp_Col
            {
                get
                {
                    return this.timestamp_Col;
                }
            }

            public global::System.Data.DataColumn Fk_User_Col
            {
                get
                {
                    return this.fk_User_Col;
                }
            }

            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DMS_ERP_R this[int index]
            {
                get
                {
                    return ((DMS_ERP_R)(this.Rows[index]));
                }
            }

            public void AddDMS_ERP_R(DMS_ERP_R row)
            {
                this.Rows.Add(row);
            }

            public DMS_ERP_R AddDMS_ERP_R(int Id, int ForeignSkid, int DerivativeCode, int Colour, int BSN, int Track, int Roof, int Door, int Spare, bool LeftPlant, DateTime Timestamp, Int64 fk_User)
            {
                DMS_ERP_R rowDMS_ERP_R = ((DMS_ERP_R)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        Id,
                        ForeignSkid,
                        DerivativeCode,
                        Colour,
                        BSN,
                        Track,
                        Roof,
                        Door,
                        Spare,
                        LeftPlant,
                        Timestamp,
                        fk_User
                    };
                rowDMS_ERP_R.ItemArray = columnValuesArray;
                this.Rows.Add(rowDMS_ERP_R);
                return rowDMS_ERP_R;
            }

            public DMS_ERP_R FindByid(int Id)
            {
                return ((DMS_ERP_R)(this.Rows.Find(new object[] {
                            Id})));
            }

            public override global::System.Data.DataTable Clone()
            {
                DMS_ERP_DT cln = ((DMS_ERP_DT)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            protected override global::System.Data.DataTable CreateInstance()
            {
                return new DMS_ERP_DT();
            }

            internal void InitVars()
            {
                this.id_Col = base.Columns["Id"];
                this.foreignSkid_Col = base.Columns["foreignSkid"];
                this.derivativeCode_Col = base.Columns["DerivativeCode"];
                this.colour_Col = base.Columns["Colour"];
                this.bSN_Col = base.Columns["BSN"];
                this.track_Col = base.Columns["Track"];
                this.roof_Col = base.Columns["Roof"];
                this.door_Col = base.Columns["Door"];
                this.spare_Col = base.Columns["Spare"];
                this.leftPlant_Col = base.Columns["LeftPlant"];
                this.timestamp_Col = base.Columns["Timestamp"];
                this.fk_User_Col = base.Columns["fk_User"];
            }

            private void InitClass()
            {
                this.id_Col = new global::System.Data.DataColumn("Id", typeof(int), null, global::System.Data.MappingType.Element);
                this.foreignSkid_Col = new global::System.Data.DataColumn("foreignSkid", typeof(int), null, global::System.Data.MappingType.Element);
                this.derivativeCode_Col = new global::System.Data.DataColumn("DerivativeCode", typeof(int), null, global::System.Data.MappingType.Element);
                this.colour_Col = new global::System.Data.DataColumn("Colour", typeof(int), null, global::System.Data.MappingType.Element);
                this.bSN_Col = new global::System.Data.DataColumn("BSN", typeof(int), null, global::System.Data.MappingType.Element);
                this.track_Col = new global::System.Data.DataColumn("Track", typeof(int), null, global::System.Data.MappingType.Element);
                this.roof_Col = new global::System.Data.DataColumn("Roof", typeof(int), null, global::System.Data.MappingType.Element);
                this.door_Col = new global::System.Data.DataColumn("Door", typeof(int), null, global::System.Data.MappingType.Element);
                this.spare_Col = new global::System.Data.DataColumn("Spare", typeof(int), null, global::System.Data.MappingType.Element);
                this.leftPlant_Col = new global::System.Data.DataColumn("LeftPlant", typeof(bool), null, global::System.Data.MappingType.Element);
                this.timestamp_Col = new global::System.Data.DataColumn("Timestamp", typeof(DateTime), null, global::System.Data.MappingType.Element);
                this.fk_User_Col = new global::System.Data.DataColumn("fk_User", typeof(Int64), null, global::System.Data.MappingType.Element);

                this.id_Col.Caption = "Id";
                this.foreignSkid_Col.Caption = "Skid Nr";
                this.derivativeCode_Col.Caption = "Derivative Code";
                this.colour_Col.Caption = "Colour";
                this.bSN_Col.Caption = "BSN";
                this.track_Col.Caption = "Track";
                this.roof_Col.Caption = "Roof";
                this.door_Col.Caption = "Door";
                this.spare_Col.Caption = "Spare";
                this.leftPlant_Col.Caption = "Left Plant";
                this.timestamp_Col.Caption = "Timestamp";
                this.fk_User_Col.Caption = "User";

                base.Columns.Add(this.id_Col);
                base.Columns.Add(this.foreignSkid_Col);
                base.Columns.Add(this.derivativeCode_Col);
                base.Columns.Add(this.colour_Col);
                base.Columns.Add(this.bSN_Col);
                base.Columns.Add(this.track_Col);
                base.Columns.Add(this.roof_Col);
                base.Columns.Add(this.door_Col);
                base.Columns.Add(this.spare_Col);
                base.Columns.Add(this.leftPlant_Col);
                base.Columns.Add(this.timestamp_Col);
                base.Columns.Add(this.fk_User_Col);

                // this.Constraints.Add(new global::System.Data.UniqueConstraint("Constraint1", new global::System.Data.DataColumn[] {
                //                 this.columnid}, true));

                // this.columnid.AllowDBNull = false;
                // this.columnid.Unique = true;
                // this.columnlogin_name.AllowDBNull = false;
                // this.columnlogin_name.MaxLength = 32;
                // this.columnfirstname.MaxLength = 32;
                // this.columnlastname.MaxLength = 32;
                // this.columndisplay_name.MaxLength = 256;
                // this.columnpwd.AllowDBNull = false;
                // this.columnpwd.MaxLength = 512;
                // this.columnemail.MaxLength = 256;
                // this.columndescription.MaxLength = 256;
                // this.columnpersistent_data.MaxLength = 1073741823;
                // this.columncardcode.MaxLength = 32;
                // this.columnstart_url.MaxLength = 256;
                this.timestamp_Col.DefaultValue = ((System.DateTime)(DMS_ERP_DT.TimestampCol_defaultValue));
            }

            public DMS_ERP_R NewDMS_ERP_R()
            {
                return ((DMS_ERP_R)(this.NewRow()));
            }

            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder)
            {
                return new DMS_ERP_R(builder);
            }

            protected override global::System.Type GetRowType()
            {
                return typeof(DMS_ERP_R);
            }

            public void RemoveDMS_ERP_R(DMS_ERP_R row)
            {
                this.Rows.Remove(row);
            }

            // public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            //     global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            //     global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            //     UserDataSet ds = new UserDataSet();
            //     global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
            //     any1.Namespace = "http://www.w3.org/2001/XMLSchema";
            //     any1.MinOccurs = new decimal(0);
            //     any1.MaxOccurs = decimal.MaxValue;
            //     any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
            //     sequence.Items.Add(any1);
            //     global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
            //     any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
            //     any2.MinOccurs = new decimal(1);
            //     any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
            //     sequence.Items.Add(any2);
            //     global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
            //     attribute1.Name = "namespace";
            //     attribute1.FixedValue = ds.Namespace;
            //     type.Attributes.Add(attribute1);
            //     global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
            //     attribute2.Name = "tableTypeName";
            //     attribute2.FixedValue = "DMS_ERP_DT";
            //     type.Attributes.Add(attribute2);
            //     type.Particle = sequence;
            //     global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            //     if (xs.Contains(dsSchema.TargetNamespace)) {
            //         global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
            //         global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
            //         try {
            //             global::System.Xml.Schema.XmlSchema schema = null;
            //             dsSchema.Write(s1);
            //             for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
            //                 schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
            //                 s2.SetLength(0);
            //                 schema.Write(s2);
            //                 if ((s1.Length == s2.Length)) {
            //                     s1.Position = 0;
            //                     s2.Position = 0;
            //                     for (; ((s1.Position != s1.Length) 
            //                                 && (s1.ReadByte() == s2.ReadByte())); ) {
            //                         ;
            //                     }
            //                     if ((s1.Position == s1.Length)) {
            //                         return type;
            //                     }
            //                 }
            //             }
            //         }
            //         finally {
            //             if ((s1 != null)) {
            //                 s1.Close();
            //             }
            //             if ((s2 != null)) {
            //                 s2.Close();
            //             }
            //         }
            //     }
            //     xs.Add(dsSchema);
            //     return type;
            // }
        }
        #endregion
    }

    public class DmsUserChangedArgs
    {
        public string User { get; set; }
        public UserChangedAction Action { get; set; }
    }

    public class DmsConnectionLostEventArgs
    {
        public ConnectionState ConnectionState { get; set; }
    }

    public enum UserChangedAction
    {
        Login,
        Logout,
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

    public enum LoginResult
    {
        Ok,
        Failed,
    }
}