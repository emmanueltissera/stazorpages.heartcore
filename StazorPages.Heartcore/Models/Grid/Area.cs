using System.Collections.Generic;

namespace StazorPages.Heartcore.Models.Grid
{
    public class Area
    {
        public List<Control> Controls { get; set; }
        public bool Active { get; set; }
        public bool HasConfig { get; set; }
        public int Grid { get; set; }
    }
}
