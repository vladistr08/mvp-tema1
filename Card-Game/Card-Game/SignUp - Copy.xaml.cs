using Card_Game.Controller;
using Card_Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        ImageService imageService = new ImageService();
        private int currentImageIndex = 0;
        public SignUp()
        {
            InitializeComponent();
            loadImage();
        }

        private void loadImage()
        {
            imageSelector.Source = new BitmapImage(new Uri(imageService.GetAvatarPath(currentImageIndex)));
        }

        //save
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string userNameInput = userInput.Text;
            var allUsers = User.GetUserNames();
            if (allUsers.IndexOf(userNameInput) != -1)
            {
                MessageBox.Show("User already exists");
                return;
            }
                
            Player newPlayer = new Player(userNameInput, imageService.GetAvatarPath(currentImageIndex));
            User.AddUser(newPlayer);
            MessageBox.Show("User added succesfully");
        }

        //prev
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            currentImageIndex--;
            if (currentImageIndex < 0)
                currentImageIndex = imageService.GetAvatarCountAvalaible() + currentImageIndex;
            loadImage();
        }

        //next
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            currentImageIndex++;
            if (currentImageIndex > imageService.GetAvatarCountAvalaible() - 1)
                currentImageIndex = 0;
            loadImage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            this.Close();
        }
    }
}
