using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitzplatzreservierung
{
    internal class SitzplatzManager : ISitzplatzManager
    {
        public Sitzplatz _sitzplatz = new Sitzplatz();

        private ISitzplatzRepository _sitzplatzRepository;
        public SitzplatzManager(ISitzplatzRepository t_ISitzplatzRepository)
        {
            _sitzplatzRepository = t_ISitzplatzRepository;
        }






    }
}
