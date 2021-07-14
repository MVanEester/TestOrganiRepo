using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestOrgani
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static bool MainMenu()
        {
            //console menu - Main
            Console.Clear();
            Console.WriteLine("Broodjeszaak Kassa Systeem");
            Console.WriteLine("Kies een optie:");
            Console.WriteLine("1) Prijslijst");
            Console.WriteLine("2) PrijsBerekening");
            Console.WriteLine("3) Bestelling plaatsen");
            Console.WriteLine("4) Bestelling afwerken");
            Console.WriteLine("5) Bestelling Annuleren");
            Console.WriteLine("6) Exit");
            Console.Write("\r\nSelecteer een optie ");

            switch (Console.ReadLine())
            {
                case "1":
                    Prijslijst();
                    return true;
                case "2":
                    PrijsBerekenen();
                    return true;
                case "3":
                    BestellingPlaatsen();
                    return true;
                case "4":
                    BestellingAfwerken();
                    return true;
                case "5":
                    BestellingAnnuleren();
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }
        }

        private static void BestellingAnnuleren()
        {
            Console.Clear();
            Console.WriteLine("Bestelling wordt Gecancelled");

            Thread.Sleep(1000);

            MainMenu();
        }

        private static void BestellingAfwerken()
        {
            
            Console.Clear();
            Console.WriteLine("Rekening Broodjeszaak");
            Console.WriteLine("=====================");
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yy"));
            Console.WriteLine($"Bestelling:    BestellingID");
            Console.WriteLine();
            Console.WriteLine($"soortBrood");
            Console.WriteLine($"Beleg");
            Console.WriteLine($"Saus");
            Console.WriteLine($"Smos");
            Console.WriteLine($"");
            Console.WriteLine($"Totale prijs:    TotaalPrijs");

            Thread.Sleep(2000);

            MainMenu();
        }

        private static void BestellingPlaatsen()
        {
            //OPDRACHT 3 - Bestelling Plaatsen

            List<Bestelling> bestellings = new List<Bestelling>();

            Bestelling bestelling = new Bestelling();
            bestelling.BestellingID = bestellings.Max(x => x.BestellingID) + 1;


            //new Bestelling { BestellingID = bestelling.BestellingID, SoortBrood = soortBrood, Beleg = bestellingBelegList, Saus = saus, Smos = isSmos, TotaalPrijs = totaalPrijs };

            MainMenu();
        }

        private static void PrijsBerekenen()
        {
            //OPDRACHT 2 - Prijs berekenen
            double totaalPrijs = 0.00;
            //console menu - Prijsberekening
            Console.Clear();
            //Brood
            Console.WriteLine("Soort brood: 1) Geen, 2) Wit, 3) Bruin, 4) Waldkorn, 5) Multi-granen");
            string soortBrood = Convert.ToString(Console.ReadLine());
            Console.WriteLine();

            //Beleg
            string beleg = "0";
            var berekenBeleg = new List<string>();
            while (beleg != "7")
            {
                Console.WriteLine("Beleg: 1) Kaas, 2) Ham, 3) Kip-curry, 4) Americain, 5) Krabsla, 6) Gebakken Kip, 7) Volgende stap");
                beleg = Console.ReadLine();
                if (beleg != "7")
                {
                    berekenBeleg.Add(beleg);
                }
                Console.WriteLine();
            }

            
            //Saus
            Console.WriteLine("Saus: 1) Mayonaise, 2) Ketchup, 3) Pepersaus, 4) Andalouse, 5) Cocktail");
            string saus = Convert.ToString(Console.ReadLine());
            Console.WriteLine();

            //Smos?
            Console.WriteLine("Wilt u van uw broodje een smos maken? 1) Ja, 2) Nee");
            string smos = Convert.ToString(Console.ReadLine());
            Console.WriteLine();

            switch (soortBrood)
            {
                case "2":
                    totaalPrijs += 2.00;
                    break;
                case "3":
                    totaalPrijs += 2.00;
                    break;
                case "4":
                    totaalPrijs += 2.20;
                    break;
                case "5":
                    totaalPrijs += 2.30;
                    break;
                default:
                    break;
            }

            List<string> bestellingBelegList = new List<string>();
            foreach (var item in berekenBeleg)
            {
                //string[] bestellingBeleg = new string[] { };
                int i = 0;
                switch (item)
                {
                    case "1":
                        totaalPrijs += 0.50;
                        bestellingBelegList.Add("Kaas");
                        i++;
                        break;
                    case "2":
                        totaalPrijs += 0.50;
                        bestellingBelegList.Add("Ham");
                        i++;
                        break;
                    case "3":
                        totaalPrijs += 0.60;
                        bestellingBelegList.Add("Kip-curry");
                        i++;
                        break;
                    case "4":
                        totaalPrijs += 0.70;
                        bestellingBelegList.Add("Americain");
                        i++;
                        break;
                    case "5":
                        totaalPrijs += 0.70;
                        bestellingBelegList.Add("Krabsla");
                        i++;
                        break;
                    case "6":
                        totaalPrijs += 0.70;
                        bestellingBelegList.Add("Gebakken kip");
                        i++;
                        break;
                    default:
                        break;
                }
            }

            switch (saus)
            {
                case "1":
                    totaalPrijs += 0.30;
                    break;
                case "2":
                    totaalPrijs += 0.30;
                    break;
                case "3":
                    totaalPrijs += 0.30;
                    break;
                case "4":
                    totaalPrijs += 0.30;
                    break;
                case "5":
                    totaalPrijs += 0.30;
                    break;
                default:
                    break;
            }

            bool isSmos = false;
            if (smos == "1")
            {
                totaalPrijs += 0.50;
                isSmos = true;
            }

            Console.WriteLine("---------------------");
            Console.WriteLine($"Uw totaal prijs is: {totaalPrijs} EUR");

            Thread.Sleep(2000);

            MainMenu();
        }

        private static void Prijslijst()
        {
            //OPDRACHT 1 - Ophalen Filter Gegevens
            //lijsten
            string[,] arraySoortBrood = new string[,] { { "Geen", "0.00" }, { "Wit", "2.00" }, { "Bruin", "2.00" }, { "Waldkorn", "2.20" }, { "Multi-granen", "2.30" } };
            string[,] arrayBeleg = new string[,] { { "Kaas", "0.50" }, { "Ham", "0.50" }, { "Kip-curry", "0.60" }, { "Americain", "0.70" }, { "Krabsla", "0.70" }, { "Gebakken kip", "0.70" } };
            string[,] arraySaus = new string[,] { { "Mayonaise", "0.30" }, { "Ketchup", "0.30" }, { "Pepersaus", "0.30" }, { "Andalouse", "0.30" }, { "Cocktail", "0.30" } };

            //console menu - Prijslijsten
            Console.Clear();
            Console.WriteLine("Kies een optie:");
            Console.WriteLine("1) Verschillende soorten brood");
            Console.WriteLine("2) Verschillende soorten beleg");
            Console.WriteLine("3) Verschillende soorten Sauzen");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelecteer een optie: ");

            //lijsten tonen
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine();
                    for (int i = 0; i < arraySoortBrood.GetLength(0); i++)
                    {
                        Console.WriteLine(arraySoortBrood[i, 0] + " " + arraySoortBrood[i, 1]);
                    }
                    Console.WriteLine("Druk ENTER om verder te gaan");
                    Console.ReadLine();
                    Prijslijst();
                    break;

                case "2":
                    Console.WriteLine();
                    for (int i = 0; i < arrayBeleg.GetLength(0); i++)
                    {
                        Console.WriteLine(arrayBeleg[i, 0] + " " + arrayBeleg[i, 1]);
                    }
                    Console.WriteLine("Druk ENTER om verder te gaan");
                    Console.ReadLine();
                    Prijslijst();
                    break;

                case "3":
                    Console.WriteLine();
                    for (int i = 0; i < arraySaus.GetLength(0); i++)
                    {
                        Console.WriteLine(arraySaus[i, 0] + " " + arraySaus[i, 1]);
                    }
                    Console.WriteLine("Druk ENTER om verder te gaan");
                    Console.ReadLine();
                    Prijslijst();
                    break;

                case "4":
                    MainMenu();
                    break;
            }
        }
    }

    public class Bestelling
    {
        public string BestellingID { get; set; }
        public string SoortBrood { get; set; }
        public List<string> Beleg { get; set; }
        public string Saus { get; set; }
        public bool Smos { get; set; }
        public double TotaalPrijs { get; set; }
    }
}
