using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Card_Game.Model
{
    public class Game
    {
        public Player currentPlayer { get; set; }
        public int CurrentGameNumber { get; set; }
        public int NumberOfGames { get; set; }

        public List<List<BitmapImage>> Board { get; set; }
        public List<Tuple<string, string>> Moves { get; set; }
        public Game(Player p) {
            CurrentGameNumber = 1;
            NumberOfGames = 3;
            currentPlayer= p;
            Moves= new List<Tuple<string, string>>();
        }

        public void Save()
        {

        }
    }
}
