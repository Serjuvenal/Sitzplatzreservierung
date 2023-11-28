using System;

namespace Sitzplatzreservierung
{
    internal class MenueSteuerung : IMenueSteuerung
    {
        private IFluggastManager _fluggastmanager;
        private IFlugManager _flugmanager;
        private IFlugzeugManager _flugzeugmanager;
        private ISitzplatzManager _sitzplatzmanager;
        public MenueSteuerung(IFluggastManager t_fluggastManager, IFlugManager t_flugManager,
            IFlugzeugManager t_flugzeugManager, ISitzplatzManager t_sitzplatzManager)
        {
            _fluggastmanager = t_fluggastManager;
            _flugmanager = t_flugManager;
            _flugzeugmanager = t_flugzeugManager;
            _sitzplatzmanager = t_sitzplatzManager;
        }

        public Flugzeug _flugzeug;
        public Flug _flug;

        public string HauptMenueAnzeigen()
        {
            Console.WriteLine("Willkommen!" + Environment.NewLine);
            Console.WriteLine("1 - Fluggast.");
            Console.WriteLine("2 - Administrator.");
            Console.WriteLine("3 - EXIT" + Environment.NewLine);
            Console.Write("Auswahl: ");
            return Console.ReadLine();
        }
        public void FalschBefehl()
        {
            Console.WriteLine(Environment.NewLine + "Sie haben ein falsches Befehl eingegeben."+Environment.NewLine+" Press any key to continue...");
            Console.ReadKey();
        }
        public string MenuAdministrator()
        {
            Console.Clear();
            Console.WriteLine("1 - Neues Flugzeug anlegen.");
            Console.WriteLine("2 - Einen Flug Zusammenstellen.");
            return Console.ReadLine();
        }
        public void InputZumFluggast()
        {
            
            string[] t_fluggast = new string[3];
            Console.Clear();
            Console.WriteLine("Anmelden:" + Environment.NewLine);
            Console.Write("Bitte geben Sie Ihr Vorname ein: ");
            t_fluggast[0] = Console.ReadLine();
            Console.Write("Bitte geben Sie Ihr Nachname ein: ");
            t_fluggast[1] = Console.ReadLine();
            Console.Write("Bitte geben Sie Ihr Telefonnummer ein: ");
            t_fluggast[2] = Console.ReadLine();
            if (t_fluggast[0] == "" || t_fluggast[1] == "" || t_fluggast[2] == "")
            {
                Console.WriteLine("Fehlende Daten. Press any key...");
                Console.ReadKey();
                return;
            }
            else
            {
                _fluggastmanager.FluggastAnmelden(t_fluggast);
                Console.Clear();
                Console.WriteLine("Registriert als: {0}", t_fluggast[0] + Environment.NewLine);
            }
        }
        public string[] InputZumFlugSuche()
        {
            string[] t_flugsuche = new string[2];
            Console.WriteLine("Für die Suche eines Fluges..." + Environment.NewLine);
            Console.Write("Bitte geben Sie das Zielort ein: ");
            t_flugsuche[0] = Console.ReadLine();
            Console.Write("Bitte geben Sie das Ankunftsort ein: ");
            t_flugsuche[1] = Console.ReadLine();
            return t_flugsuche;

        }
        public void InputZumFlugzeuganlegen()
        {
            string[] t_flugzeug = new string[4];
            Console.Clear();
            Console.Write("Bitte geben Sie die Marke des Flugzeuges ein: ");
            t_flugzeug[0] = Console.ReadLine();
            Console.Write("Bitte geben Sie das Modell des Flugzeuges ein: ");
            t_flugzeug[1] = Console.ReadLine();
            Console.Write("Bitte geben Sie die Anzahl den Sitzplätze ein: ");
            t_flugzeug[2] = Console.ReadLine();
            Console.Write("Bitte geben Sie die Anzahl den Reihen ein: ");
            t_flugzeug[3] = Console.ReadLine();
            Console.WriteLine(Environment.NewLine + "Sind die Daten richtig? J / N");
            string bestaetigung = Console.ReadLine();
            if (bestaetigung.ToLower() == "j")
            {
                _flugzeug = _flugzeugmanager.NeuesFlugzeug(t_flugzeug);
            }
            else
            {
                Console.WriteLine("Bitte versuchen Sie es nochmals.");
            }
        }
        public void InputZumFlug()
        {
            string[] t_flug = new string[4];
            Console.Clear();
            Console.Write("Bitte geben Sie Zielort ein: ");
            t_flug[0] = Console.ReadLine();
            Console.Write("Bitte geben Sie Ankunftsort ein: ");
            t_flug[1] = Console.ReadLine();
            Console.Write("Bitte geben Sie Ausreisesdatum ein: TT/MM/YYYY HH:MM:SS");
            t_flug[2] = Console.ReadLine();
            Console.Write("Bitte geben Sie Ankommensdatum ein: TT/MM/YYYY HH:MM:SS");
            t_flug[3] = Console.ReadLine();

            _flug = _flugmanager.FlugZusammenstellen(t_flug, _flugzeug);
        }
        public void FlugAusgeben()
        {
            Console.Clear();
            Console.WriteLine(_flug.Ausreisesdatum);
            foreach(var s in _flug.Sitzplan)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
