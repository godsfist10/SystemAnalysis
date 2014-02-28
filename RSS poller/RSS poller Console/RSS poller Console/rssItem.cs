#region Using
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RSS_poller
{
    public interface IGetItem
    {
        string getTitle();
        string getLink();
        string getDescription();
    }

    public interface ISetItem
    {
        void setTitle(string title);
        void setLink(string link);
        void setDescription(string description);
    }


    public struct rssItem : IGetItem
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PubDate { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public string getTitle() { return Title; }
        public string getLink() { return Link; }
        public string getDescription() { return Description; }

    }
    
}