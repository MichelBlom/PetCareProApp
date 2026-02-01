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
        // Paden voor de database en foto's binnen de projectmap
        private static string mappenPad = Path.Combine(Application.StartupPath, "PetCareData");
        private static string fotosPad = Path.Combine(mappenPad, "DierFotos");
        private static string jsonBestand = Path.Combine(mappenPad, "dieren.json");
        private static string eigenarenBestand = Path.Combine(mappenPad, "eigenaren.json");
        private static string reserveringenBestand = Path.Combine(mappenPad, "reserveringen.json");

        public static void Initialiseer()
        {
            // Maak mappen aan indien deze nog niet bestaan
            if (!Directory.Exists(mappenPad)) Directory.CreateDirectory(mappenPad);
            if (!Directory.Exists(fotosPad)) Directory.CreateDirectory(fotosPad);
        }

        public static List<Dier> LaadDieren()
        {
            // Lees dierenbestand en converteer JSON naar een lijst
            if (!File.Exists(jsonBestand)) return new List<Dier>();
            string json = File.ReadAllText(jsonBestand);
            return JsonConvert.DeserializeObject<List<Dier>>(json) ?? new List<Dier>();
        }

        public static void SlaDierenOp(List<Dier> lijst)
        {
            // Zet lijst met dieren om naar JSON-formaat en sla op
            string json = JsonConvert.SerializeObject(lijst, Formatting.Indented);
            File.WriteAllText(jsonBestand, json);
        }

        public static string KopieerFoto(string bronPad)
        {
            // Controleer of bronbestand bestaat
            if (string.IsNullOrEmpty(bronPad) || !File.Exists(bronPad)) return "";

            // Genereer unieke bestandsnaam om overschrijven te voorkomen
            string nieuweNaam = Guid.NewGuid().ToString() + Path.GetExtension(bronPad);
            string doelPad = Path.Combine(fotosPad, nieuweNaam);

            File.Copy(bronPad, doelPad);
            return nieuweNaam;
        }

        public static string KrijgFotoPad(string bestandsnaam)
        {
            // Bouw het volledige pad naar een specifieke foto
            if (string.IsNullOrEmpty(bestandsnaam)) return "";
            return Path.Combine(fotosPad, bestandsnaam);
        }

        public static List<string> KrijgBeschikbareHokken(string huidigHokDier = null)
        {
            // Initialiseer lijst 
            List<string> lijstOmTerugTeGeven = new List<string>();
            lijstOmTerugTeGeven.Add("(Geen)");

            // Haal alle dieren op om bezetting te controleren
            List<Dier> alleDieren = LaadDieren();

            // Bepaal welke hokken bezet zijn
            List<string> bezetteHokken = alleDieren
                .Where(d => !string.IsNullOrEmpty(d.Verblijf) && d.Verblijf != "(Geen)" && d.Verblijf != huidigHokDier)
                .Select(d => d.Verblijf)
                .ToList();

            // Filter beschikbare hokken uit de reeks 1 t/m 100
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
            // Lees eigenarenbestand en converteer naar lijst
            if (!File.Exists(eigenarenBestand)) return new List<Eigenaar>();
            string json = File.ReadAllText(eigenarenBestand);
            return JsonConvert.DeserializeObject<List<Eigenaar>>(json) ?? new List<Eigenaar>();
        }

        public static void SlaEigenarenOp(List<Eigenaar> lijst)
        {
            // Sla lijst met eigenaren op als JSON
            string json = JsonConvert.SerializeObject(lijst, Formatting.Indented);
            File.WriteAllText(eigenarenBestand, json);
        }

        // Reservering methoden

        public static List<Reservering> LaadReserveringen()
        {
            // Laad alle reserveringen vanuit JSON-bestand
            if (!File.Exists(reserveringenBestand)) return new List<Reservering>();
            string json = File.ReadAllText(reserveringenBestand);
            return JsonConvert.DeserializeObject<List<Reservering>>(json) ?? new List<Reservering>();
        }

        public static void SlaReserveringenOp(List<Reservering> lijst)
        {
            // Sla lijst met reserveringen op naar schijf
            string json = JsonConvert.SerializeObject(lijst, Formatting.Indented);
            File.WriteAllText(reserveringenBestand, json);
        }
    }
}

