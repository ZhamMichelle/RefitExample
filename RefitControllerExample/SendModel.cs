using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefitControllerExample
{
    public class RequestModel
    {
        public string city { get; set; }
        public string source { get; set; }
        public string auto { get; set; }
        public string phone { get; set; }
        public string costGroup { get; set; }
        public string url { get; set; }

    }


    public class SendModel
    {
        public string system { get; set; }
        public Attributes attributes { get; set; }
    }


    public class Attributes
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string iinBin { get; set; }
        public string organizationName { get; set; }
        public string email { get; set; }
        public string callTime { get; set; }
        public string date { get; set; }
    }
}
