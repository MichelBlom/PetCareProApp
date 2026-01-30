using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetCareProApp
{
    public static class DataManager
    {
        // Bepaal de mappen in de projectmap
        private static string mappenPad = Path.Combine(Application.StartupPath, "PetCareData");
        private static string fotosPad = Path.Combine(mappenPad, "DierFotos");
        private static string jsonBestand = Path.Combine(mappenPad, "dieren.json");
        private static string eigenarenBestand = Path.Combine(mappenPad, "eigenaren.json");
        private static string reserveringenBestand = Path.Combine(mappenPad, "reserveringen.json");

        public static void Initialiseer()
        {
            // Maak de mappen aan als ze nog niet bestaan
            if (!Directory.Exists(mappenPad)) Directory.CreateDirectory(mappenPad);
            if (!Directory.Exists(fotosPad)) Directory.CreateDirectory(fotosPad);
        }

        public static List<Dier> LaadDieren()
        {
            if (!File.Exists(jsonBestand)) return new List<Dier>();
            string json = File.ReadAllText(jsonBestand);
            return JsonConvert.DeserializeObject<List<Dier>>(json) ?? new List<Dier>();
        }

        public static void SlaDierenOp(List<Dier> lijst)
        {
            string json = JsonConvert.SerializeObject(lijst, Formatting.Indented);
            File.WriteAllText(jsonBestand, json);
        }

        public static string KopieerFoto(string bronPad)
        {
            if (string.IsNullOrEmpty(bronPad) || !File.Exists(bronPad)) return "";

            // Maak een unieke bestandsnaam om overschrijven te voorkomen
            string nieuweNaam = Guid.NewGuid().ToString() + Path.GetExtension(bronPad);
            string doelPad = Path.Combine(fotosPad, nieuweNaam);

            File.Copy(bronPad, doelPad);
            return nieuweNaam;
        }

        public static string KrijgFotoPad(string bestandsnaam)
        {
            if (string.IsNullOrEmpty(bestandsnaam)) return "";
            return Path.Combine(fotosPad, bestandsnaam);
        }

        public static List<string> KrijgBeschikbareHokken(string huidigHokDier = null)
        {
            // 1. Maak de uiteindelijke lijst aan en voeg (Geen) als eerste toe
            List<string> lijstOmTerugTeGeven = new List<string>();
            lijstOmTerugTeGeven.Add("(Geen)");

            // 2. Haal alle dieren op om de bezette hokken te bepalen
            List<Dier> alleDieren = LaadDieren();

            // 3. We kijken welke hokken bezet zijn (behalve het hok waar het huidige dier al in zit)
            // We negeren "(Geen)" in deze check omdat die nooit 'bezet' kan zijn
            List<string> bezetteHokken = alleDieren
                .Where(d => !string.IsNullOrEmpty(d.Verblijf) && d.Verblijf != "(Geen)" && d.Verblijf != huidigHokDier)
                .Select(d => d.Verblijf)
                .ToList();

            // 4. Maak de lijst van Hok 1 t/m Hok 100 en voeg ze toe als ze niet bezet zijn
            for (int i = 1; i <= 100; i++)
            {
                string hokNaam = "Hok " + i;
                if (!bezetteHokken.Contains(hokNaam))
                {
                    lijstOmTerugTeGeven.Add(hokNaam);
                }
            }

            return lijstOmTerugTeGeven;
        }

        public static List<Eigenaar> LaadEigenaren()
        {
            if (!File.Exists(eigenarenBestand)) return new List<Eigenaar>();
            string json = File.ReadAllText(eigenarenBestand);
            return JsonConvert.DeserializeObject<List<Eigenaar>>(json) ?? new List<Eigenaar>();
        }

        public static void SlaEigenarenOp(List<Eigenaar> lijst)
        {
            string json = JsonConvert.SerializeObject(lijst, Formatting.Indented);
            File.WriteAllText(eigenarenBestand, json);
        }

        // --- Nieuwe Reservering Methoden ---

        public static List<Reservering> LaadReserveringen()
        {
            if (!File.Exists(reserveringenBestand)) return new List<Reservering>();
            string json = File.ReadAllText(reserveringenBestand);
            return JsonConvert.DeserializeObject<List<Reservering>>(json) ?? new List<Reservering>();
        }

        public static void SlaReserveringenOp(List<Reservering> lijst)
        {
            string json = JsonConvert.SerializeObject(lijst, Formatting.Indented);
            File.WriteAllText(reserveringenBestand, json);
        }
    }
}

