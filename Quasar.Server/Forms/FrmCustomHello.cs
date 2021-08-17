using Quasar.Common.Messages;
using Quasar.Server.Helper;
using Quasar.Server.Messages;
using Quasar.Server.Networking;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{
    public partial class FrmCustomHello : Form
    {

        private static readonly Dictionary<Client, FrmCustomHello> OpenedForms = new Dictionary<Client, FrmCustomHello>();
        private readonly Client _connectClient;
        private readonly SayHelloHandler _sayHelloHandler;


        public FrmCustomHello(Client client)
        {
            _connectClient = client;
            _sayHelloHandler = new SayHelloHandler(client);
            RegisterMessageHandler();
            InitializeComponent();
        }

        private void RegisterMessageHandler()
        {
            _connectClient.ClientState += ClientDisconnected;
            _sayHelloHandler.ProgressChanged += SayHelloChanged;
            MessageHandler.Register(_sayHelloHandler);
        }

        private void ClientDisconnected(Client client, bool connected)
        {
            if (!connected)
            {
                this.Invoke((MethodInvoker)this.Close);
            }
        }

        private void SayHelloChanged(object sender, List<Tuple<string, string>> infos)
        {
            // remove "Loading..." information
            // textBox1.Clear();

            foreach (var info in infos)
            {
                // var lvi = new ListViewItem(new[] { info.Item1, info.Item2 });
                textBox1.Text = textBox1.Text + "\r\n" + info.Item1 + ":" + info.Item2;
            }
 
        }

        public static FrmCustomHello CreateNewOrGetExisting(Client client)
        {
            if (OpenedForms.ContainsKey(client))
            {
                return OpenedForms[client];
            }
            FrmCustomHello f = new FrmCustomHello(client);
            f.Disposed += (sender, args) => OpenedForms.Remove(client);
            OpenedForms.Add(client, f);
            return f;
        }

        private void FrmSayHello_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterMessageHandler();
        }

        private void UnregisterMessageHandler()
        {
            MessageHandler.Unregister(_sayHelloHandler);
            _sayHelloHandler.ProgressChanged -= SayHelloChanged;
            _connectClient.ClientState -= ClientDisconnected;
        }



        private void FrmCustomHello_Load(object sender, EventArgs e)
        {
            // this.Text = WindowHelper.GetWindowTitle("System Information", _connectClient);
            this.Text = "FrmCustomHello_Load";

            _sayHelloHandler.RefreshSystemInformation(textBox2.Text);
            AddBasicSystemInformation();
        }

        private void AddBasicSystemInformation()
        {
            textBox1.Clear();
            textBox1.Text = "start : say hello";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sayHelloHandler.RefreshSystemInformation(textBox2.Text);
        }
    }
}
