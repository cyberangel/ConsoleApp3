using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // načtení obsahu souboru do stringu
            string json = File.ReadAllText("text.txt");

            // dohledání klíče "soubory" pomocí JSON parseru
            var jsonObjekt = JObject.Parse(json);
            var soubory = jsonObjekt["soubory"].ToString(Formatting.None);

            // odstranění hranatých závorek na začátku/konci a uvozovek na konci
            var obsah = soubory.TrimStart('[').TrimEnd(new[] { ']', '"'});

            // výpočet CRC32
            var crc32 = new Crc32();

            var soucet = crc32.Get(obsah.ToArray());

            Console.WriteLine(soucet);
        }
    }
}
