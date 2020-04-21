using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class TicTacToeEngine
    {
        public enum GameStatus { PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins }
        public GameStatus Status { get; set; }
        //De cellen worden opgeslagen in een array.
        public string[] cels = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

        //Deze functie returned een string van het bord. Is alleen van toepassing bij de Console applicatie.
        public string Board()
        {
            string board = string.Format("-------------\n" +
                         "| {0} | {1} | {2} |\n" +
                         "-------------\n" +
                         "| {3} | {4} | {5} |\n" +
                         "-------------\n" +
                         "| {6} | {7} | {8} |\n" +
                         "-------------", cels[0], cels[1], cels[2], cels[3], cels[4], cels[5], cels[6], cels[7], cels[8]);

            return board;
        }

        //Deze functie vult de cel in aan de hand van de ingevoegde waarde.
        public Boolean ChooseCell(int cel)
        {
            //De indexer is de cel - 1, omdat arrays natuurlijk bij 0 beginnen.
            int indexer = cel - 1;
            //Deze array wordt later gebruikt om een gelijk spel te bepalen.
            string[] cells = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            try
            {
                //Als er wordt geprobeerd een cel te vullen die al eerder gevuld is, weergeeft het een foutmelding.
                if (Equals(cels[indexer], "O") || Equals(cels[indexer], "X"))
                {
                    Console.WriteLine("Invalid Choice.");
                    return false;
                }

                //Deze switch case update de cel and gamestatus zodra deze (nog niet ingevulde) cel wordt aangeklikt.
                switch (Status)
                {
                    case GameStatus.PlayerOPlays:
                        cels[indexer] = "O";
                        Status = GameStatus.PlayerXPlays;
                        break;
                    case GameStatus.PlayerXPlays:
                        cels[indexer] = "X";
                        Status = GameStatus.PlayerOPlays;
                        break;
                }

                //Deze Boolean valt buiten het domeinmodel, aangezien het een lokale functie is binnen ChooseCell. Het returned een true als een speler gewonnen heeft.
                Boolean decideWinner(string a, string b, string c)
                {
                    if (Equals(a,b) && Equals(a,c) && !Equals(a,""))
                    {
                        switch (a)
                        {
                            case "O":
                                Status = GameStatus.PlayerOWins;
                                return true;
                            case "X":
                                Status = GameStatus.PlayerXWins;
                                return true;
                        }
                    }
                    return false;
                }

                //Hier wordt decideWinner meerdere keren gedraait en de twee arrays met elkaar vergeleken. Als alle if-statement conditions waar zijn, zal er een gelijk spel plaatsvinden.
                if (!(decideWinner(cels[0], cels[1], cels[2]) ||
                      decideWinner(cels[3], cels[4], cels[5]) ||
                      decideWinner(cels[6], cels[7], cels[8]) ||
                      decideWinner(cels[0], cels[4], cels[8]) ||
                      decideWinner(cels[2], cels[4], cels[6]) ||
                      decideWinner(cels[0], cels[3], cels[6]) ||
                      decideWinner(cels[1], cels[4], cels[7]) ||
                      decideWinner(cels[2], cels[5], cels[8])) &&
                      !cells.Any(cels.Contains))
                {
                    Status = GameStatus.Equal;
                }
            }

            //Als een cijfer lager dan 1 of hoger dan 9 wordt gegeven, weergeeft het een foutmelding.
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid Choice.");
                return false;
            }

            return true;
        }

        //Deze functie reset het spel. Eerst wordt de cels array gereset en dan wordt de gamestatus op PlayerOPlays gezet. Het spel kan dan opnieuw worden gespeelt.
        public void Reset()
        {
            string[] reset = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            cels = reset;
            Status = GameStatus.PlayerOPlays;
        }
    }
}
