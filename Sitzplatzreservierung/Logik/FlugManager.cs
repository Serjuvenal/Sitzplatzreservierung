using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    internal class FlugManager : IFlugManager
    {
        public Flug _flug;

        private IFlugRepository _flugRepository;
        public FlugManager(IFlugRepository t_IFlugRepository)
        {
            _flugRepository = t_IFlugRepository;
            //_flug = new Flug(new Flugzeug() { AnzahlDerSitzplaetze = 90, Reihenanzahl = 15 });
        }

        public Flug FlugZusammenstellen(string[] t_DatenzumFlug, Flugzeug t_flugzeug)
        {
            Flug t_flug = new Flug(t_flugzeug);

            t_flug.Zielort = t_DatenzumFlug[0];
            t_flug.Ankunftsort = t_DatenzumFlug[1];
            t_flug.Ausreisesdatum = Convert.ToDateTime(t_DatenzumFlug[2]);
            t_flug.Ankommensdatum = Convert.ToDateTime(t_DatenzumFlug[3]);
            return t_flug;
        }
    }
}
