#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;

#endregion

namespace RSS_poller
{
    class rssParser
    {
        private XmlReader reader;

        public bool validateRssFeed()
        {
            Rss20FeedFormatter validator = new Rss20FeedFormatter();
            return validator.CanRead(reader);
        }

        public rssFeedData parseRSS(string feed)
        {
            reader = XmlReader.Create(new StringReader(feed));

            if (!validateRssFeed())
                throw new Exception("Invalid RSS feed");

            reader.ReadToFollowing("channel");

            rssFeedData channel = new rssFeedData();
            channel.Items = new List<rssItem>();

            bool header = true;

            while (header)
            {
                reader.Read();
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "title":
                            channel.Title = reader.ReadElementContentAsString();
                            break;

                        case "link":
                            channel.Link = reader.ReadElementContentAsString();
                            break;

                        case "description":
                            channel.Description = reader.ReadElementContentAsString();
                            break;

                        case "item":
                            header = false;
                            break;
                    }
                }
            }

            rssItem item = new rssItem();

            while (reader.Read())
            {
                switch (reader.Name)
                {
                     case "title":
                        if (reader.IsStartElement())
                            item.Title = reader.ReadElementContentAsString();
                        break;

                    case "link":
                        if (reader.IsStartElement())
                            item.Link = reader.ReadElementContentAsString();
                        break;

                    case "description":
                        if (reader.IsStartElement())
                            item.Description = reader.ReadElementContentAsString();
                        break;

                    case "item":
                        if (!reader.IsStartElement())
                            channel.Items.Add(item);
                        break;
                }
            }
            return channel;
        }

    }
}
