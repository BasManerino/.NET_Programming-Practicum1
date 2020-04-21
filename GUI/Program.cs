using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace GUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //We maken een instantie van de TicTacToeEngine en we setten de status naar PlayerOPlays om het simpel te houden.
            TicTacToeEngine engine = new TicTacToeEngine()
            {
                Status = TicTacToeEngine.GameStatus.PlayerOPlays
            };

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(engine));
        }
    }
}