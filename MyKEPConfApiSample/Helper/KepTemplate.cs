using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKEPConfApiHelper
{
    public class KepTemplate
    {
        public virtual string getChJson(string name,string port)
        {
            return "";
        }

        public virtual string getDevJson(string name,string host, string port)
        {
           return "";
        }

        public virtual string getTagsJson(List<Tuple<string,string,int>> tags)
        {
          
            return "";
        }

    }
}
