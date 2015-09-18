﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using dmspl.common;

namespace TCP
{
    public class TCP_RequestHandler
    {
        public static TCP.TCP_MasterSlave ServerInfo { get; set; }

        public static void ReceiveData(Socket socket, byte[] data)
        {
            switch (data[0])
            {
                case 49://connection string request
                    ConStr_Response(socket);
                    break;
                default:
                    break;
            }
        }

        private static void ConStr_Response(Socket socket)
        {
            var auth = dmspl.common.RegAuth.GetRegData();
            var prep = Obfuscation.Code("dms", auth.ConnectionString);
            var data = Encoding.UTF8.GetBytes(prep);
            if (ServerInfo!=null)
            {
                ServerInfo.SendToClient(socket, data);
            }
        }
    }
}
