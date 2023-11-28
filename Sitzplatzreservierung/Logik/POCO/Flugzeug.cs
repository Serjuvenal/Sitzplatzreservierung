using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    public class Flugzeug
    {
		private string _marke;
        private string _modell;
        private int _anzahlDerSitzplaetze;
		private int _reihenanzahl;

		public string Marke
		{
			get { return _marke; }
			set { _marke = value; }
		}
		public string Modell
		{
			get { return _modell; }
			set { _modell = value; }
		}
		public int AnzahlDerSitzplaetze
		{
			get { return _anzahlDerSitzplaetze; }
			set { _anzahlDerSitzplaetze = value; }
		}
        public int Reihenanzahl
        {
            get { return _reihenanzahl; }
            set { _reihenanzahl = value; }
        }

        public Flugzeug() { }
	}
}
