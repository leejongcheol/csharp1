using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
class ClientHadler
{
    Socket socket = null;
    NetworkStream stream = null;
    StreamReader reader = null;
    StreamWriter writer = null;
    public ClientHadler(Socket socket)
    {
        this.socket = socket;
    }
    public void chat()
    {
        //클라이언트의 데이터를 읽고, 쓰기 위한 스트림을 만든다.
        stream = new NetworkStream(socket);
        Encoding encode = Encoding.GetEncoding("utf-8");
        reader = new StreamReader(stream, encode);
        writer = new StreamWriter(stream, encode) { AutoFlush = true };
        while (true)
        {
            string str = reader.ReadLine();
            Console.WriteLine(str);
            writer.WriteLine(str);
        }
    }
}

class Server
{
    public static void Main()
    {
        TcpListener tcpListener = null;
        Socket clientsocket = null;

        try
        {
            //IP주소를 나타내는 객체를 생성,TcpListener를 생성시 인자로 사용할려고
            IPAddress ipAd = IPAddress.Parse("192.168.0.15");
            //TcpListener Class를 이용하여 클라이언트의 연결을 받아 들인다.
            tcpListener = new TcpListener(ipAd, 5001);
            tcpListener.Start();
            while (true)
            {
                clientsocket = tcpListener.AcceptSocket();
                ClientHadler cHandler = new ClientHadler(clientsocket);
                Thread t = new Thread(cHandler.chat);
                t.Start();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            clientsocket.Close();
        }
    }
}