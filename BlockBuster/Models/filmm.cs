using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace BlockBuster.Models
{
    public class filmm
    {
        dbBBusterDataContext data = new dbBBusterDataContext();
        public int? Id { set; get; }
        public string Name { set; get; }
        public int Year { set; get; }
        public string Month { set; get; }
        public int Day { set; get; }
        public int Hour { set; get; }
        public int Minute { set; get; }
        public string Image_link { set; get; }
        public Double View_count { set; get; }
        public string Description { set; get; }
        public DateTime Created { set; get; }
        public int Form_id { set; get; }
        public int Rate { set; get; }
    }
}