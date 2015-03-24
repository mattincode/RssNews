using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RSSNews.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Feeds = ReadFeed("http://www.fotbollskanalen.se/rss");
        }

        private ObservableCollection<Feed> _feeds;
        private string _filter;

        public ObservableCollection<Feed> Feeds
        {
            get
            {
                return _feeds;
            }
            set
            {
                if (_feeds != value)
                {
                    _feeds = value;
                    OnPropertyChanged("Feeds");
                }
            }
        }

        public string Filter
        {
            get { return _filter; }
            set 
            { 
                _filter = value;
                Feeds = new ObservableCollection<Feed>(_allFeeds.Where(feed => feed.Title.StartsWith(Filter)));
            }
        }

        private IList<Feed> _allFeeds = new List<Feed>(); 
        public ObservableCollection<Feed> ReadFeed(string url)
        {
            var rssFeed = XDocument.Load(url);

            var feeds = from item in rssFeed.Descendants("item")
                        select new Feed
                        {
                            Title = item.Element("title").Value,
                            Link = item.Element("link").Value,
                            Description = item.Element("description").Value,
                            GUID = item.Element("guid").Value,
                            PublicationDate = DateTime.Parse(item.Element("pubDate").Value),
                        };

            _allFeeds = feeds.ToList();
            return new ObservableCollection<Feed>(feeds);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
