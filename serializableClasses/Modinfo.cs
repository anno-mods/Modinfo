using System;
using System.Collections.Generic;
using System.Text;

namespace Modinfo
{
    class Modinfo
    {
        public String Version { get; set; }
        public String ModID { get; set; }
        public String[] IncompatibleIds { get; set; }
        public String[] ModDependencies { get; set; }
        public Localized Category { get; set; }
        public Localized ModName { get; set; }
        public Localized Description { get; set; }
        public Localized[] KnownIssues { get; set; }
        public String[] DLCDependencies { get; set; }
        public String CreatorName { get; set; }
        public String CreatorContact { get; set; }
    }
}
