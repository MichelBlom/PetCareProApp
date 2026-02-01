using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareProApp
{
    public class Eigenaar
    {
        public string Naam { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Email { get; set; }
        public string Telefoonnummer { get; set; }
        public string Opmerkingen { get; set; }

        // Juiste weergave van de naam in UI
        public override string ToString() => Naam;
    }
}
