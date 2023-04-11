using Card_Game.Controller;
using Card_Game.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        Player currentSelectedPlayer;

        public SignIn()
        {
            InitializeComponent();
        }

        //signup
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentSelectedPlayer = User.GetUserByName((sender as ListBox).SelectedItem.ToString());
            imageAvatar.Source = new BitmapImage(new Uri(currentSelectedPlayer.ProfileImagePath));
        }

        //remove
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User.RemoveUser(currentSelectedPlayer);
            currentSelectedPlayer= null;
            this.Hide();
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        //play
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GameSelector gameSelector = new GameSelector(currentSelectedPlayer);
            this.Close();
            gameSelector.Show();
        }

        //exit
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Istratescu Vlad, 10LF312, Informatica Aplicata, Nu am salvarea de joc si statistici :(");
        }
    }
}
