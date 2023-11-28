using System;

namespace Sitzplatzreservierung
{
    internal class FluggastManager : IFluggastManager
    {
        public Fluggast _fluggast = new Fluggast();

        private IFluggastRepository _fluggastRepository;
        public FluggastManager(IFluggastRepository t_IFluggastRepository)
        {
            _fluggastRepository = t_IFluggastRepository;
        }

        public void FluggastAnmelden(string[] t_fluggastnamen)
        {
            _fluggast.Vorname = t_fluggastnamen[0];
            _fluggast.Nachname = t_fluggastnamen[1];
            _fluggast.Telefonnummer = t_fluggastnamen[2];
        }
    }
}
