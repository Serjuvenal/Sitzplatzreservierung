﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    internal interface IFlugManager
    {
        Flug FlugZusammenstellen(string[] t_DatenzumFlug, Flugzeug t_flugzeug);
    }
}