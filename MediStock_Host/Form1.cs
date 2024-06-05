using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediStock_Service;

namespace MediStock_Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ServiceHost sh = null;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Uri tcpa = new Uri("net.tcp://localhost:8000/TcpBinding");
            sh = new ServiceHost(typeof(Stock_Service_Imp), tcpa);
            NetTcpBinding tcpb = new NetTcpBinding();
            ServiceMetadataBehavior nBehave = new ServiceMetadataBehavior();
            sh.Description.Behaviors.Add(nBehave);
            sh.AddServiceEndpoint(typeof(IMetadataExchange),
            MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            sh.AddServiceEndpoint(typeof(stock_service), tcpb, tcpa);
            sh.Open();
            label2.Text = "Service Running";
        }
    }
}
