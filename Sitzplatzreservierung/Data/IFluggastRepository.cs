﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    internal interface IFluggastRepository
    {
        void FluggastSpeichern(Fluggast t_fluggast);
    }
}