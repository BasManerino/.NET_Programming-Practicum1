using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace GUI
{
    public partial class Form1 : Form
    {
        //We geven hier een parameter mee aan de form, deze parameter bevat de game-engine die we hebben geinstantieerd in de main klasse.
        public TicTacToeEngine engine;
        public Form1(TicTacToeEngine engine)
        {
            this.engine = engine;
            InitializeComponent();
        }

        //De functies voor alle cel knoppen.
        private void button1_Click(object sender, EventArgs e)
        {
            //Hier wordt de cell op het bord gekozen.
            engine.ChooseCell(1);
            //Hier wordt de tekst van de cel geupdate naar het respectievelijke teken van elke speler.
            this.button1.Text = engine.cels[0];
            //Hier wordt de tekst op het bord geupdate dat weergeeft wat momenteel de status is van het spel.
            setResult(engine.Status);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(2);
            this.button2.Text = engine.cels[1];
            setResult(engine.Status);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(3);
            this.button3.Text = engine.cels[2];
            setResult(engine.Status);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(4);
            this.button4.Text = engine.cels[3];
            setResult(engine.Status);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(5);
            this.button5.Text = engine.cels[4];
            setResult(engine.Status);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(6);
            this.button6.Text = engine.cels[5];
            setResult(engine.Status);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(7);
            this.button7.Text = engine.cels[6];
            setResult(engine.Status);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(8);
            this.button8.Text = engine.cels[7];
            setResult(engine.Status);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(9);
            this.button9.Text = engine.cels[8];
            setResult(engine.Status);
        }

        //Deze functie reset het spel.
        private void reset(object sender, EventArgs e)
        {
            //Hier wordt het spel gereset.
            engine.Reset();
            //Hier wordt de tekst van alle knoppen en de status gereset.
            this.button1.Text = engine.cels[0];
            this.button2.Text = engine.cels[1];
            this.button3.Text = engine.cels[2];
            this.button4.Text = engine.cels[3];
            this.button5.Text = engine.cels[4];
            this.button6.Text = engine.cels[5]; 
            this.button7.Text = engine.cels[6];
            this.button8.Text = engine.cels[7];
            this.button9.Text = engine.cels[8];
            this.resultText.Text = "It's player O's turn.";
        }

        //Deze functie update de status tekst aan de hand van welke status actief is.
        private void setResult(TicTacToeEngine.GameStatus status)
        {
            switch (status)
            {
                case (TicTacToeEngine.GameStatus.PlayerOPlays):
                    this.resultText.Text = "It's player O's turn.";
                    break;
                case (TicTacToeEngine.GameStatus.PlayerXPlays):
                    this.resultText.Text = "It's player X's turn.";
                    break;
                case (TicTacToeEngine.GameStatus.PlayerOWins):
                    this.resultText.Text = "Congratulations to player O, you win!";
                    break;
                case (TicTacToeEngine.GameStatus.PlayerXWins):
                    this.resultText.Text = "Congratulations to player X, you win!";
                    break;
                case (TicTacToeEngine.GameStatus.Equal):
                    this.resultText.Text = "Too bad, no one wins!";
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
