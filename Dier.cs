using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareProApp
{
    public class Dier
    {
        // Basisgegevens van het dier
        public string Naam { get; set; }
        public string Soort { get; set; }
        public int Leeftijd { get; set; }
        public string Geslacht { get; set; }
        public string Ras { get; set; }

        // Unieke identificatie 
        public string Chipnummer { get; set; }

        // Koppeling aan eigenaar en verblijf
        public string Eigenaar { get; set; }
        public string Verblijf { get; set; }
        public string Opmerkingen { get; set; }
        public string FotoBestandsnaam { get; set; }
    }
}
