using System;
using System.Collections.Generic;
using System.Text;

namespace SerializableModinfo
{
    class Dlc
    {
        public Dlc() { }
        //use: "Anarchist", "SunkenTreasures", "Botanica", "ThePassage", "SeatOfPower", "BrightHarvest", "LandOfLions", "Christmas", "AmusementPark, "CityLife", "Docklands", "Tourism", "Highlife"
        public String DLC { get; set; }
        //use: "required", "partly", "atLeastOneRequired"
        public String Dependant { get; set; }
    }
}
