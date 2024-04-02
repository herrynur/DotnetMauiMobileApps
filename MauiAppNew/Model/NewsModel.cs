using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppNew.Model
{
    public class NewsModel
    {
        public string status { get; set; }
        public int totalResult { get; set; }
        public int MyProperty { get; set; }
        public List<NewsArticles> articles { get; set; }
    }

    public class NewsArticles
    {
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public NewsSource source { get; set; }
    }

    public class  NewsSource
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
