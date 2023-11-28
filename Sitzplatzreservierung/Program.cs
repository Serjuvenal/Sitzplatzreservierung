using System;

namespace Sitzplatzreservierung
{
    internal class Program
    {
        private static IFluggastRepository _fluggastRepository = new FluggastRepository();
        private static IFluggastManager _fluggastManager = new FluggastManager(_fluggastRepository);

        private static IFlugRepository _flugRepository = new FlugRepository();
        private static IFlugManager _flugManager = new FlugManager(_flugRepository);

        private static IFlugzeugRepository _flugzeugRepository = new FlugzeugRepository();
        private static IFlugzeugManager _flugzeugManager = new FlugzeugManager(_flugzeugRepository);


        private static ISitzplatzRepository _sitzplatzRepository = new SitzplatzRepository();
        private static ISitzplatzManager _sitzplatzManager = new SitzplatzManager(_sitzplatzRepository);


        private static IMenueSteuerung _hauptmenue = new MenueSteuerung(_fluggastManager, _flugManager, _flugzeugManager, _sitzplatzManager);
        //private static IMenueSteuerung _hauptmenue = new MenueSteuerung(null, _flugManager, null, null);

        static void Main(string[] args)
        {
            //Console.ReadLine();
            bool running = true;
            do
            {
                
                string _eingabe = _hauptmenue.HauptMenueAnzeigen();
                switch (_eingabe)
                {
                    default:
                        _hauptmenue.FalschBefehl();
                        break;
                    case "1": // Menu Fluggast
                        _hauptmenue.InputZumFluggast();
                        //_hauptmenue.InputZumFlugSuche();
                        break;
                    case "2": // Menu Administrator
                        _eingabe = _hauptmenue.MenuAdministrator();
                        switch (_eingabe)
                        {
                            default:
                                _hauptmenue.FalschBefehl();
                                break;
                            case "1":
                                _hauptmenue.InputZumFlugzeuganlegen();
                                break;
                            case "2":
                                _hauptmenue.InputZumFlug();
                                _hauptmenue.FlugAusgeben();
                                break;
                            
                            case "3":
                                return;
                        }
                        break;
                    case "3":
                        return;
                }
            } while (running);
            
        }
    }
}

