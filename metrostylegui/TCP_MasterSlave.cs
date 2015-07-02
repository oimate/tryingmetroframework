using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace metrostylegui
{
  public  class TCP_MasterSlave
    {

        public bool isConnected;


        public TCP_MasterSlave(IPAddress ipAdress, int port, string login)
        {
   
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAdress, port);
            try
            {
                socket.Connect(ipEndPoint);

                isConnected = true;
            }
            catch (SocketException ex)
            {
              Console.WriteLine("Error during connecting to server", "System");
            }

        }
        //public void Close {get;set;}
        //{
        //        socket.Close();
        //        isConnected = false;
        //        thread.Abort();
        //}
    }
}
