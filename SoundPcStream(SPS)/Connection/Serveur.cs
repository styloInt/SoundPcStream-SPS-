﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Net.NetworkInformation;

namespace SoundPcStream_SPS_.Connection
{
    class Serveur
    {
        IPGlobalProperties ipGlobalProperties;
        List<TcpConnectionInformation> tcpConnInfoListe;

        private IPHostEntry ipHostInfo;
        private IPAddress ipAddress;
        private IPEndPoint localEndPoint;

        // Incoming data from the client.
        public static string data = null;

        public Serveur()
        {
            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] tabIpAdress = ipHostInfo.AddressList;
            ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            tcpConnInfoListe = ipGlobalProperties.GetActiveTcpConnections().ToList();

            foreach (IPAddress adress in tabIpAdress)
                if (adress.AddressFamily == AddressFamily.InterNetwork)
                    ipAddress = adress;
            localEndPoint = new IPEndPoint(ipAddress, 11000);
        }

        public void StartListening(int numPort) 
        {
            if (!isPortOpen(numPort))
                throw new System.ArgumentException("Port not open");
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp );

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (true) {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.
                    while (true) {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes,0,bytesRec);
                        if (data.IndexOf("<EOF>") > -1) {
                            break;
                        }
                    }

                    // Show the data on the console.
                    Console.WriteLine( "Text received : {0}", data);

                    // Echo the data back to the client.
                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public string getIpAdress()
        {
            return ipAddress.ToString();
        }

        public int getPortValide()
        {
            return tcpConnInfoListe.First().LocalEndPoint.Port;
        }

        private bool isPortOpen(int numPort)
        {
            ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            tcpConnInfoListe = ipGlobalProperties.GetActiveTcpConnections().ToList();

            return tcpConnInfoListe.Exists(tcp => tcp.LocalEndPoint.Port == numPort);
        }
    }
}