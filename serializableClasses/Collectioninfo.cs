using System;
using System.Collections.Generic;
using System.Text;

namespace Modinfo
{
    class Collectioninfo
    {
        public String Name { get; set; }
        public String Version { get; set; }
        public String LastUpdate { get; set; }
        public String[] Creators { get; set; }
        public String[] Translators { get; set; }
        public String[] Thanks { get; set; }
        public ModIdActiveTouple[] ModIDs { get; set; }
    }
}
