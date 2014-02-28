#region Using

using System;
using System.Xml;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Linq;
using System.Net;
using System.IO;

#endregion
namespace RSS_poller
{
    public class PollFinishedEventArgs : EventArgs
    {
        //the event to send out
        public PollFinishedEventArgs(rssFeedData channelToPublish)
        {
            //constructor for the event
            channel = channelToPublish;
        }

        rssFeedData channel;
        public rssFeedData getChannel
        {
            //used for the listeners to get the channel to display it
            get { return channel; }
        }
    }

    public class rssPoller
    {
        //this is the event definition
        public event EventHandler<PollFinishedEventArgs> RaiseCustomEvent;

        public string _url { get; set; }
        public Stream resultStream;
        WebRequest mRequest;
        HttpWebResponse mResponse;

        public rssPoller(string url)
        {
            _url = url;
        }

        public rssPoller(){}

        public void poll(string url)
        {
            rssPoller poller = new rssPoller();
            rssFeedData channel = new rssFeedData();

            Action<object> action = (object obj) =>
            {
                rssParser parser = new rssParser();

                string response = poller.getReponse(url);
                channel = parser.parseRSS(response);

            };

            Task t1 = Task.Factory.StartNew(action, "alpha");
            try
            {
                t1.Wait();
            }
            catch (System.Exception ex)
            {
                return;
            }

            //this is where I call the event after I fill out all the channel info
            // I send the channel info it recieved out via the event
            OnRaiseCustomEvent(new PollFinishedEventArgs(channel));
            
            return;
        }

        //this is the event sender. It sends out the event for all the listeners to recieve
        protected virtual void OnRaiseCustomEvent(PollFinishedEventArgs e)
        {
           
            EventHandler<PollFinishedEventArgs> handler = RaiseCustomEvent;
          
            if( handler != null)
                handler(this, e);

        }

        public string getReponse(string url)
        {
            try
            {
                mRequest = WebRequest.Create(url);
                mResponse = (HttpWebResponse)mRequest.GetResponse();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            Stream dataStream;
            try
            {
                dataStream = mResponse.GetResponseStream();
            }
            catch (ProtocolViolationException ex)
            {
                throw new Exception(ex.Message);
            }

            StreamReader reader = new StreamReader(dataStream);          
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            mResponse.Close();

            return responseFromServer;
        }

    }

}