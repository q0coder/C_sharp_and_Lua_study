using System;
using HPSocket;
using HPSocket.Tcp;
namespace   HpGameServerDemo
{
    internal class Sever
    {
       public TcpServer server=new TcpServer();
       public Sever()
        {
          //设定服务器地址和端口
        server.Address="127.0.0.1";
        server.Port=5566;
        //接收到客户端连接时触发
        server.OnAccept+=Server_OnAccept;
        //接收到客户端数据时触发
        server.OnReceive+=Server_OnReceive;
        //客户端连接断开时触发
        server.OnClose+=Server_OnClose;
       

        //启动服务器
        server.Start();
        }

        private HandleResult Server_OnClose(IServer sender, IntPtr connId, SocketOperation socketOperation, int errorCode)
        {

            return HandleResult.Ok;
        }

        private HandleResult Server_OnReceive(IServer sender, IntPtr connId, byte[] data)
        {
           return HandleResult.Ok;
        }

        private HandleResult Server_OnAccept(IServer sender, IntPtr connId, IntPtr client)

        {
                Console.WriteLine("Client connected: ");
            return HandleResult.Ok;
        }
    }
}