using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    internal class FlugzeugManager : IFlugzeugManager
    {
        public Flugzeug _flugzeug = new Flugzeug();

        private IFlugzeugRepository _flugzeugRepository;
        public FlugzeugManager(IFlugzeugRepository t_IFlugzeugRepository)
        {
            _flugzeugRepository = t_IFlugzeugRepository;
        }

        public Flugzeug NeuesFlugzeug(string[] t_input)
        {
            Flugzeug t_flugzeug = new Flugzeug();
            t_flugzeug.Marke = t_input[0];
            t_flugzeug.Modell = t_input[1];
            t_flugzeug.AnzahlDerSitzplaetze = Convert.ToInt32(t_input[2]);
            t_flugzeug.Reihenanzahl = Convert.ToInt32(t_input[3]);
            //_flugzeugRepository.FlugzeugSpeichern(t_flugzeug);
            return t_flugzeug;
        }
    }
}
