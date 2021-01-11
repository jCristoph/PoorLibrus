using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerTCP;


namespace Gui
{
    public partial class BoskiSerwer : Form
    {
        AsyncAwaitServer aas;
        public BoskiSerwer()
        {
            InitializeComponent();
        }

        private void run()
        {
            try
            {
                IPAddress adresIP = IPAddress.Parse("127.0.0.1");
                int port = 2048;
                aas = new AsyncAwaitServer(adresIP, port);
                aas.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        private void lblCPU_Click(object sender, EventArgs e)
        {

        }

        private void txtPort_Click(object sender, EventArgs e)
        {

        }

        private void btnONOFF_Click_1(object sender, EventArgs e)
        {
            if (btnONOFF.Text == "Turn ON")
            {
                btnONOFF.Text = "Shut Down";
                var th = new Thread(run)
                {
                    Priority = ThreadPriority.Highest
                };
                th.Start();

            }
            else
            {
                if (aas != null)
                {
                    aas.Stop();
                }
                btnONOFF.Text = "Turn ON";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBarCPU_Click(object sender, EventArgs e)
        {

        }

        private void progressBarRAM_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float fcpu = CPU.NextValue();
            float fram = RAM.NextValue();
            progressBarCPU.Value = (int)fcpu;
            progressBarRAM.Value = (int)fram;
            lblCPU.Text = string.Format("{0:0.00}%", fcpu);
            lblRAM.Text = string.Format("{0:0.00}%", fram);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
