using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    internal interface IFlugzeugRepository
    {
        void FlugzeugSpeichern(Flugzeug t_flugzeug);
        void FlugzeugTabelleErzeugen();
    }
}
