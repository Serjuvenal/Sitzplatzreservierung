using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    internal interface IMenueSteuerung
    {
        void InputZumFlugzeuganlegen();
        string HauptMenueAnzeigen();
        void InputZumFluggast();
        string[] InputZumFlugSuche();
        string MenuAdministrator();
        void FalschBefehl();
        void InputZumFlug();
        void FlugAusgeben();
    }
}
