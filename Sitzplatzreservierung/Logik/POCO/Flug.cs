using System;

namespace Sitzplatzreservierung
{
    //public enum SitzplatzPosition
    //{
    //    GangLinksVorne, GangLinksMitte, GangLinksHinten,
    //    MitteLinksVorne, MitteLinksMitte, MitteLinksHinten,
    //    FensterLinksVorne, FensterLinksMitte, FensterLinksHinten,
    //    GangRechtsVorne, GangRechtsMitte, GangRechtsHinten,
    //    MitteRechtsVorne, MitteRechtsMitte, MitteRechtsHinten,
    //    FensterRechtsVorne, FensterRechtsMitte, FensterRechtsHinten
    //}

    public struct SitzplatzPosition { public string pos; public string seite; public string abteil; }
    public class Flug
    {
        private Flugzeug _flugzeug;
        private string _zielort; 
        private string _ankunftsort;
        private DateTime _ausreisesdatum;
        private DateTime _ankommensdatum;
        private string _referenznummer;
        private SitzplatzPosition _sitzposition;
        private Sitzplatz[] _sitzplan;

        public Flugzeug Flugzeug
        {
            get { return _flugzeug; }
            set { _flugzeug = value; }
        }
        public string Zielort
        {
            get { return _zielort; }
            set { _zielort = value; }
        }
        public string Ankunftsort
        {
            get { return _ankunftsort; }
            set { _ankunftsort = value; }
        }
        public DateTime Ausreisesdatum
        {
            get { return _ausreisesdatum; }
            set { _ausreisesdatum = value; }
        }
        public DateTime Ankommensdatum
        {
            get { return _ankommensdatum; }
            set { _ankommensdatum = value; }
        }
        public string Referenznummer
        {
            get { return _referenznummer; }
            set { _referenznummer = value; }
        }
        public SitzplatzPosition SitzPosition
        {
            get { return _sitzposition; }
        }
        public Sitzplatz[] Sitzplan
        {
            get { return _sitzplan; }
            set { _sitzplan = value; }
        }

        private Sitzplatz[] ErmittleSitzplan(Flugzeug t_flugzeug)
        {
            Sitzplatz[] t_sitzplan = new Sitzplatz[t_flugzeug.AnzahlDerSitzplaetze];
            string buchstabe = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int maxReihen = t_flugzeug.Reihenanzahl;
            int maxAnzahlSitze = t_flugzeug.AnzahlDerSitzplaetze;
            int sitzeProReihe = maxAnzahlSitze / maxReihen;
            //int sitzeProAbteil = maxReihen / 3;
            //int sitzeProSeite = sitzeProReihe / 2;
            for (int i = 1; i <= t_sitzplan.Length; i++)
            {
                Sitzplatz t_sitzplatz = new Sitzplatz();

                //Bezeichnung Erzeugen
                int reihe = (i / sitzeProReihe);
                if ((i % sitzeProReihe) != 0) reihe++;
                int spalteNr = (i % sitzeProReihe);
                if (spalteNr == 0) spalteNr = sitzeProReihe;
                string bezeichnung = buchstabe.Substring(spalteNr - 1, 1) + reihe.ToString();
                t_sitzplatz.Bezeichnung = bezeichnung;

                //Sitzposition Ermitteln
                SitzplatzPosition sitzplatzPositionBezeichnung = new SitzplatzPosition(); 
                if (spalteNr == 1)
                {
                    sitzplatzPositionBezeichnung.pos = "Fenster";
                    sitzplatzPositionBezeichnung.seite = "Links";
                }
                else if (spalteNr == sitzeProReihe)
                {
                    sitzplatzPositionBezeichnung.pos = "Fenster";
                    sitzplatzPositionBezeichnung.seite = "Rechts";
                }
                else if (spalteNr == sitzeProReihe / 2)
                {
                    sitzplatzPositionBezeichnung.pos = "Gang";
                    sitzplatzPositionBezeichnung.seite = "Links";
                }
                else if (spalteNr == (sitzeProReihe / 2) + 1)
                {
                    sitzplatzPositionBezeichnung.pos = "Gang";
                    sitzplatzPositionBezeichnung.seite = "Rechts";
                }
                else if (spalteNr < sitzeProReihe / 2)
                {
                    sitzplatzPositionBezeichnung.pos = "Mitte";
                    sitzplatzPositionBezeichnung.seite = "Links";
                }
                else
                {
                    sitzplatzPositionBezeichnung.pos = "Mitte";
                    sitzplatzPositionBezeichnung.seite = "Rechts";
                }

                //Abteil Ermitteln
                if (reihe <= maxReihen /3) sitzplatzPositionBezeichnung.abteil = "Vorne";
                else if (reihe > maxReihen * 2/3) sitzplatzPositionBezeichnung.abteil = "Hinten";
                else sitzplatzPositionBezeichnung.abteil = "Mitte";

                //Zuweisung SitzplatzPosition zu Sitzplatz
                t_sitzplatz.Position = sitzplatzPositionBezeichnung;
                //Zuweisung Sitzplatz zu Sitzplan
                t_sitzplan[i-1] = t_sitzplatz;
            }
            return t_sitzplan;
        }
        //public Flug() { }

        public Flug(Flugzeug t_flugzeug)
        {
            
            this.Sitzplan = ErmittleSitzplan(t_flugzeug);
        }
    }
}
