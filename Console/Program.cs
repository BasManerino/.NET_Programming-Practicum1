using Engine;
using System;

namespace ConsoleApplication
{
    static class Program
    {
        static void Main()
        {
            //We maken een instantie van de TicTacToeEngine en we setten de status naar PlayerOPlays om het simpel te houden.
            TicTacToeEngine engine = new TicTacToeEngine()
            {
                Status = TicTacToeEngine.GameStatus.PlayerOPlays
            };

            //Deze while loop zal gedurende het hele spel actief zijn. Pas als de applicatie wordt afgesloten zal hij stoppen.
            while (true)
            {
                //Hier vragen we om een invoer en laten we het bord zien.
                Console.WriteLine("Type a number from 1-9, new or quit");
                Console.WriteLine("Status: " + engine.Status);
                Console.WriteLine(engine.Board());

                string next = Console.ReadLine();

                //Hier wordt de inhoud van de invoer gecontroleerd.
                switch (next)
                {
                    //Als de invoer "new" is, zal het spel en het bord worden gereset.
                    case "new":
                        engine.Reset();
                        break;
                    //Als de invoer "new" is, zal de applicatie worden afgesloten.
                    case "quit":
                        Environment.Exit(0);
                        break;
                    //Als de waarde iets anders is (in het goede geval een 1-9 cijfer, anders returned hij een foutmelding), zal deze worden geconverteert naar een int en wordt de cel gevuld.
                    default:
                        try
                        {
                            Int32.TryParse(next, out int cel);
                            engine.ChooseCell(cel);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid Choice.");
                        }
                        break;
                }

                //Deze switch case update de status tekst aan de hand van welke status actief is. Omdat het in de while loop draait, zal het altijd updaten indien nodig.
                switch (engine.Status)
                {
                    case (TicTacToeEngine.GameStatus.PlayerOWins):
                        Console.WriteLine("Congratulations to player O, you win!");
                        Console.WriteLine(engine.Board());
                        Console.WriteLine("---------------------------------------------------");
                        engine.Reset();
                        break;
                    case (TicTacToeEngine.GameStatus.PlayerXWins):
                        Console.WriteLine("Congratulations to player X, you win!");
                        Console.WriteLine(engine.Board());
                        Console.WriteLine("---------------------------------------------------");
                        engine.Reset();
                        break;
                    case (TicTacToeEngine.GameStatus.Equal):
                        Console.WriteLine("Too bad, no one wins!");
                        Console.WriteLine(engine.Board());
                        Console.WriteLine("---------------------------------------------------");
                        engine.Reset();
                        break;
                }
            }
        }
    }
}
