using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareProApp
{
    public class Reservering
    {
        public string ReserveringId { get; set; } // Uniek ID voor de boeking
        public string DierChipnummer { get; set; } // Koppeling naar het dier
        public string DierNaam { get; set; } 
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public string Verblijf { get; set; } 
        public string Status { get; set; } 
    }
}
