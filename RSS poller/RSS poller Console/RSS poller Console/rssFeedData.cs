#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace RSS_poller
{

    public interface IDataFeed
    {

        List<rssItem> getItems();
        List<string> getProperties();
        List<string> getPropertyNames();
    }

    public interface IDataFeedDisplay
    {
        void fullDisplay();
    }

    public interface IGetDataFeedDisplay
    {
        string getDataString();
    }

    public class rssFeedData : IDataFeed, IDataFeedDisplay, IGetDataFeedDisplay
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime PubDate { get; set; }
        public List<rssItem> Items = new List<rssItem>();

        public string getDataString()
        {
            string dataOutputString = "";

            

            dataOutputString += "Title: " + Title + "\nLink:  " + Link + "\nDescription:  " + Description + "\n\n";
            foreach (rssItem item in Items)
            {
                dataOutputString += "\n_________________________________________________________\n\n";
                dataOutputString += item.getTitle() + "\n";
                dataOutputString += item.getLink() + "\n\n";
                if (item.getDescription() != null)
                    dataOutputString += item.getDescription() + "\n";

                
            }

            return dataOutputString;
        }

        public void fullDisplay()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Link: " + Link);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("\n------------Items------------\n");

            foreach (rssItem item in Items)
            {
                Console.WriteLine(item.getTitle());
                Console.WriteLine(item.getLink());

                Console.WriteLine("\n_________________________________________________\n");
            }
        }

        public List<rssItem> getItems() { return Items; }

        public List<string> getProperties()
        {
            return new List<string>() { Title, Link, Description };
        }

        public List<string> getPropertyNames()
        {
            return new List<string>() { "Title", "Link", "Description" };
        }

    }

}