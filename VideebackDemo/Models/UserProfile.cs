using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideebackDemo.Models
{
    public class UserProfile
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? userId { get; set; }
        public int? groupId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string path { get; set; }
        public int? videoType { get; set; }
        public int? videoStatus { get; set; }
        public DateTime? dateCreated { get; set; }
        public int? trending { get; set; }
        public int? technicId { get; set; }
        public int? tutorial { get; set; }
        public int? youtubeVideoId { get; set; }
        public int? duration { get; set; }
        public int? skillId { get; set; }
        public int? showcase { get; set; }
        public int? training { get; set; }
        public int? views { get; set; }
        public int? hidden { get; set; }
    }
}