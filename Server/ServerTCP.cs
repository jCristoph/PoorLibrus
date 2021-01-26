using DatabaseLib;
using Server;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerTCP
{
    public class AsyncAwaitServer
    {
        /// <summary>
        /// Structure for holding information about individual server client sessions.
        /// That is- the TCP Stream of the client and his unique ID.
        /// </summary>
        public struct Client
        {
            public Client(int id, NetworkStream stream)
            {
                Id = id;
                Stream = stream;
            }

            public int Id { get; }
            public NetworkStream Stream { get; }
        }



        #region fields
        IPAddress ipAddress;
        int port;
        int buffer_size = 1024;
        bool running;
        List<byte[]> buffers = new List<byte[]>();
        int clientCounter = 0;
        TcpListener tcpListener;
        Base a;

        public delegate void TransmissionDataDelegate(NetworkStream stream);
        #endregion

        #region field_definitions
        public IPAddress IPAddress
        {
            get => ipAddress;
            set
            {
                if (!running) ipAddress = value;
                else throw new Exception("The server is not curently running");
            }
        }

        public int Port
        {
            get => port;
            set
            {
                int tmp = port;
                if (!running) port = value; else throw new Exception("Cannot change the port while the server is running");
                if (!checkPort())
                {
                    port = tmp;
                    throw new Exception("Illegal port value");
                }

            }

        }

        public int Buffer_size
        {
            get => buffer_size; set
            {
                if (value < 0 || value > 1024 * 1024 * 64) throw new Exception("Illegal packet size");
                if (!running) buffer_size = value; else throw new Exception("Cannot change packet size while the server is running");
            }

        }
        protected TcpListener TcpListener { get => tcpListener; set => tcpListener = value; }
        public List<byte[]> Buffers { get => buffers; set => buffers = value; }
        #endregion


        public AsyncAwaitServer(IPAddress IP, int port)

        {
            running = false;
            IPAddress = IP;
            Port = port;
            if (!checkPort())
            {
                Port = 8000;
                throw new Exception("illegal port, port set to 8000");
            }

        }

        #region Functions
        protected bool checkPort()
        {
            if (port < 1024 || port > 49151) return false;
            return true;
        }


        protected void StartListening()
        {
            TcpListener = new TcpListener(IPAddress, Port);
            TcpListener.Start();
        }

        protected void AcceptClient()
        {
            while (true)
            {
                TcpClient tcpClient = TcpListener.AcceptTcpClient();
                //create a new buffer for the client
                NetworkStream stream = tcpClient.GetStream();
                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);
                transmissionDelegate.BeginInvoke(stream, TransmissionCallback, tcpClient);
                clientCounter++;

            }
        }

        private void TransmissionCallback(IAsyncResult ar)
        {
            TcpClient tcpClient = (TcpClient)ar.AsyncState;
            tcpClient.Close();
        }

        /// <summary>
        /// Here we can add log in option
        /// </summary>
        /// <param name="client"></param>
        protected void BeginDataTransmission(NetworkStream stream)
        {
            Client client = new Client(clientCounter, stream);
            Menu m = new Menu(a, client.Stream);
            m.start();
        }


        /// <summary>
        /// Starts the server.
        /// </summary>
        public void Start()
        {
            a = new Base();
           
            Admin b = (Admin)a.userDatabase[0];


            // Przy pierwszym uruchomieniu serwera trzeba stworzyć baze danych czyli odkomentować poniższe linijki.
            // przy nastepnym uruchomieniu ponizszy kod powinien byc zakomentowany aby nie dublowac bazy danych
            /*a.userDatabase.Clear();
            b.addUser(a, "Jan", "Nowak", "now123ak", "matematyka5", 10001, 's');
            b.addUser(a, "Anna", "Kowalska", "annkaaa", "matematyka5", 10002, 's');
            b.addUser(a, "Tomasz", "Kruk", "taaaa123", "matematyka5", 10003, 's');
            b.addUser(a, "Oliwia", "Wolna", "oli134", "matematyka5", 10004, 's');
            b.addUser(a, "Adam", "Gruszka", "wojak16", "matematyka5", 10005, 's');
            b.addUser(a, "Aneta", "Miklaszewski", "bsad432", "matematyka5", 10006, 's');
            b.addUser(a, "Martyna", "Grys", "kjbdas125", "matematyka5", 10007, 's');
            b.addUser(a, "Aleksandra", "Cicha", "124jnouh32", "matematyka5", 10008, 's');
            b.addUser(a, "Grzegorz", "Kluska", "dsjfb567", "matematyka5", 10009, 's');
            b.addUser(a, "Krzysztof", "Bombka", "fksb29", "matematyka5", 10010, 's');
            b.addUser(a, "Karol", "Szymczak", "1kjsd3", "matematyka5", 10011, 's');
            b.addUser(a, "Karolina", "Kacperska", "asdiy", "matematyka5", 10012, 's');
            b.addUser(a, "Szymon", "Kowal", "198gsa", "matematyka5", 10013, 's');
            b.addUser(a, "Lidia", "Kalisiak", "jbjdsf04", "matematyka5", 10014, 's');
            b.addUser(a, "Arkadiusz", "Wojtkowiak", "osadb983", "matematyka5", 10015, 's');
            b.addUser(a, "Anna", "Bartkowiak", "iusdfg92", "matematyka5", 10016, 's');
            b.addUser(a, "Jan", "Nowak", "now123ak", "chemia5", 10001, 's');
            b.addUser(a, "Anna", "Kowalska", "annkaaa", "chemia5", 10002, 's');
            b.addUser(a, "Tomasz", "Kruk", "taaaa123", "chemia5", 10003, 's');
            b.addUser(a, "Oliwia", "Wolna", "oli134", "chemia5", 10004, 's');
            b.addUser(a, "Adam", "Gruszka", "wojak16", "chemia5", 10005, 's');
            b.addUser(a, "Aneta", "Miklaszewski", "bsad432", "chemia5", 10006, 's');
            b.addUser(a, "Martyna", "Grys", "kjbdas125", "chemia5", 10007, 's');
            b.addUser(a, "Aleksandra", "Cicha", "124jnouh32", "chemia5", 10008, 's');
            b.addUser(a, "Grzegorz", "Kluska", "dsjfb567", "chemia5", 10009, 's');
            b.addUser(a, "Krzysztof", "Bombka", "fksb29", "chemia5", 10010, 's');
            b.addUser(a, "Karol", "Szymczak", "1kjsd3", "chemia5", 10011, 's');
            b.addUser(a, "Karolina", "Kacperska", "asdiy", "chemia5", 10012, 's');
            b.addUser(a, "Szymon", "Kowal", "198gsa", "chemia5", 10013, 's');
            b.addUser(a, "Lidia", "Kalisiak", "jbjdsf04", "chemia5", 10014, 's');
            b.addUser(a, "Arkadiusz", "Wojtkowiak", "osadb983", "chemia5", 10015, 's');
            b.addUser(a, "Anna", "Bartkowiak", "iusdfg92", "chemia5", 10016, 's');
            b.addUser(a, "Czeslaw", "Kaminski", "Nauczyciel1", "matematyka5", 90001, 't');
            b.addUser(a, "Anna", "Dziedzic", "kjsdCV24", "chemia5", 90002, 't');
            b.editGrades(a, 10001, "chemia5", 0, 4);
            b.editGrades(a, 10001, "chemia5", 1, 3);
            b.editGrades(a, 10001, "chemia5", 2, 5);
            b.editGrades(a, 10001, "matematyka5", 0, 1);
            b.editGrades(a, 10001, "matematyka5", 1, 3);
            b.editGrades(a, 10001, "matematyka5", 2, 2);
            b.addUser(a, "Czeslaw", "Kaminski", "Nauczyciel1", "polski6", 90001, 't');
            b.addUser(a, "Jan", "Nowak", "now123ak", "polski6", 10001, 's');
            b.addUser(a, "Czeslaw", "Kaminski", "Nauczyciel1", "fizyka2", 90001, 't');
            a.sync();*/
            
            StartListening();
            AcceptClient();
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        public void Stop()
        {
            tcpListener.Stop();
        }
        #endregion
    }
}

