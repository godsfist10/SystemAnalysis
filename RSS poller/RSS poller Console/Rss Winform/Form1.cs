using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using RSS_poller;


namespace Rss_Winform
{
    public partial class Form1 : Form
    {
        public static string url;
        public static string dataString;

        public Form1()
        {
            dataString = "";
            InitializeComponent();
            
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            url = UrlTextBox.Text;
            UrlTextBox.Text = "Now Polling... deal with it";
            TimerCallback callback = new TimerCallback(Poll);
            System.Threading.Timer pollTimer = new System.Threading.Timer(callback, null, 0, 15000);
        }

        public void Poll(Object stateInfo)
        {
            rssPoller poller = new rssPoller();
            //subscribe to the event in the newly made poller class so that when that event is heard it will call the function poller_RaiseCustomEvent
            poller.RaiseCustomEvent += poller_RaiseCustomEvent;
            poller.poll(url);
        }

        //this is the function that the event listener calls
        void poller_RaiseCustomEvent(object sender, PollFinishedEventArgs e)
        {
            //this calls the function that displays the channel that is recieved
            displayText(e.getChannel.getDataString());
        }

        void displayText(string text)
        {
            string newText = text; // running on worker thread
            this.Invoke((MethodInvoker)delegate  // this shenanigans is to avoid that thread safe exception bs
            {
                TextBox1.Text = newText; // runs on UI thread
            });
        }

    }    
}
