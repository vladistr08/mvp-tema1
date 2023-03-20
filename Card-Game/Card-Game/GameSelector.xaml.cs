using Card_Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Card_Game
{
    /// <summary>
    /// Interaction logic for GameSelector.xaml
    /// </summary>
    public partial class GameSelector : Window
    {
        Player currentPlayer;
        public int Rows, Cols;
        public GameSelector(Player currentPlayer)
        {
            InitializeComponent();
            this.currentPlayer = currentPlayer;
        }

        private void rowsInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = (sender as TextBox).Text.ToString();
            var isNumeric = int.TryParse(text, out _);
            if (isNumeric)
            {
                Rows = int.Parse(text);
            }
        }

        private void colsInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = (sender as TextBox).Text.ToString();
            var isNumeric = int.TryParse(text, out _);
            if (isNumeric)
            {
                Cols = int.Parse(text);
            }
        }

        //load
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //to implement
            MessageBox.Show("Not yet implemented");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SignIn signIn= new SignIn();
            this.Close();
            signIn.Show();
        }

        //start new
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Rows * Cols % 2 != 0) {
                MessageBox.Show("Rows * Cols must be even");
                return;
            }
            CardData.Rows= Rows;
            CardData.Columns= Cols;
            Game game= new Game(currentPlayer);
            this.Close();
            game.Show();
        }
    }
}
