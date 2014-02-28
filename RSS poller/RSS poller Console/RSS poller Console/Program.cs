#region Using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace RSS_poller
{
    public class nonStaticConsolePoller
    {
        private string url;

        public void StartPoller()
        {
            Console.Write("Enter URL: ");
            url = Console.ReadLine();

            TimerCallback callback = new TimerCallback(Poll);
            Timer pollTimer = new Timer(callback, null, 0, 15000);

            string tempExit = Console.ReadLine();
            while (tempExit != "exit" && tempExit != "Exit")
            {
                tempExit = Console.ReadLine();
            }
        }
        private void Poll(Object stateInfo)
        {
            rssPoller poller = new rssPoller();
            poller.RaiseCustomEvent += consolPoller_RaiseCustomEvent;
            poller.poll(url);
        }

        void consolPoller_RaiseCustomEvent(object sender, PollFinishedEventArgs e)
        {
            //event recieved
            Console.Clear();
            //display the channel that was recieved
            e.getChannel.fullDisplay();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            nonStaticConsolePoller ConsolePoller = new nonStaticConsolePoller();
            ConsolePoller.StartPoller();
       // Console.ReadKey();
        }
    }
}
