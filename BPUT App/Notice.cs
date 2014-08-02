using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BPUT_App
{
    public class Notice
    {
        [DataMember(Name = "url")]
        public string url { get; set; }

        [DataMember(Name = "text")]
        public string text { get; set; }
    }

    public class RootObject
    {
        public List<Notice> notice { get; set; }
    }
}
