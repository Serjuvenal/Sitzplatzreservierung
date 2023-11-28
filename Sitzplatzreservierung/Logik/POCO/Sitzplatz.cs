using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    public class Sitzplatz
    {
		private string _bezeichnung;
        private SitzplatzPosition _position;
        private bool _istBesetzt;

        public string Bezeichnung
        {
            get { return _bezeichnung; }
            set { _bezeichnung = value; }
        }

		public SitzplatzPosition Position
		{
			get { return _position; }
			set { _position = value; }
		}
		public bool IstBesetzt
		{
			get { return _istBesetzt; }
			set { _istBesetzt = value; }
		}






		public Sitzplatz() { }
    }
}
