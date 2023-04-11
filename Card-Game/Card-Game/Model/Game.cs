using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace Card_Game.Model
{
    public class Game
    {
        public Player currentPlayer { get; set; }
        public int CurrentLevel { get; set; }
        public int NumberOfGamesWon { get; set; }

        public List<List<BitmapImage>> Board { get; set; }
        public List<Tuple<string, string>> Moves { get; set; }
        public Game(Player p) {
            Board = new List<List<BitmapImage>> { new List<BitmapImage>() };
            CurrentLevel = 1;
            NumberOfGamesWon = 0;
            currentPlayer= p;
            Moves= new List<Tuple<string, string>>();
        }

        public void SaveStatistics()
        {
            /*DirectoryInfo dir = new DirectoryInfo("../../Asset/Data/Statistics/");
            foreach (var fileName in dir.GetFiles())
            {
                JsonService.DeleteFileFromPath("../../Asset/Data/Statistics/" + currentPlayer.DataFileName);
            }
            JsonService.SerializeToFile<Player>("../../Asset/Data/Statistics/" + currentPlayer.DataFileName, currentPlayer);*/
            MessageBox.Show("Player statistics saved succesfully");
        }

        public void Save()
        {
            /*DirectoryInfo dir = new DirectoryInfo("../../Asset/Data/Save/");
            foreach(var fileName in dir.GetFiles())
            {
                JsonService.DeleteFileFromPath("../../Asset/Data/Save/" + currentPlayer.DataFileName);
            }
            JsonService.SerializeToFile<Game>("../../Asset/Data/Save/" + currentPlayer.DataFileName, this);*/
            MessageBox.Show("Game saved succesfully");
        }

        public void AddWin()
        {
            CurrentLevel += 1;
            if((CurrentLevel - 1) % 3 == 0)
            {
                NumberOfGamesWon+= 1;
            }
            //currentPlayer.Statistics.TotalLevelsWon = CurrentLevel;
            //currentPlayer.Statistics.TotalGamesWon = NumberOfGamesWon;
        }

    }
}
