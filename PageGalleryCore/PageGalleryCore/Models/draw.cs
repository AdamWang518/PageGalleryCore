using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageGalleryCore.Models
{
    public class draw
    {
        public Guid id { get; set; }
        public String artist { get; set; }
        public String imageLink { get; set; }
        public String startYear { get; set; }
        public String endYear { get; set; }
        public String attribute { get; set; }
        public String drawName { get; set; }
    }
}
