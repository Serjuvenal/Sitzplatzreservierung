using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    public class Fluggast
    {

		private string _vorname;
		public string Vorname
		{
			get { return _vorname; }
			set { _vorname = value; }
		}

		private string _nachname;
		public string Nachname
		{
			get { return _nachname; }
			set { _nachname = value; }
		}

		private string _telefonnummer;

		public string Telefonnummer
		{
			get { return _telefonnummer; }
			set { _telefonnummer = value; }
		}

		public Fluggast() { }
	}
}
