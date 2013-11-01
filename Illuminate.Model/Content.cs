using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Illuminate.Model
{
    public class Content
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Value { get; set; }
        public string ContentUri { get; set; }
        public string CreatorRef { get; set; }
        public string UpdaterRef { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}