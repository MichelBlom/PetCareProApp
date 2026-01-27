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
            return JsonConvert.DeserializeObject<List<Dier>>(json);
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
    }
}
