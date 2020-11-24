using System;
using System.Collections.Generic;

namespace StazorPages.Heartcore.Models.Grid
{
    public class Row
    {
        public List<Area> Areas { get; set; }

        public bool Active { get; set; }

        public bool HasConfig { get; set; }

        public Guid Id { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }
    }
}
