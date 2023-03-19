using Card_Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Card_Game
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        Button selectedButton { get; set; } = null;
        Image selected1Ref { get; set; }
        BitmapImage selected1 { get; set; } = null;
        BitmapImage selected2 { get; set; } = null;
        int guessed = 0;
        Model.Game game;
        Player currentPlayer { get; set; }
        public Game(Player currentPlayer)
        {
            game = new Model.Game(currentPlayer);
            game.Board = CardData.CardImages;
            this.currentPlayer = currentPlayer;
            InitializeComponent();
        }

        //get the first child of a specified type
        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null
                    && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            var image = FindVisualChild<Image>(button);
            image.Visibility= Visibility.Visible;
            
            if(selected1 == null)
            {
                selected1Ref = image;
                selected1 = new BitmapImage((image.Source as BitmapImage).UriSource);
                selectedButton = button;
                selectedButton.IsEnabled= false;
            }
            else if(selected2 == null)
            {
                selected2 = new BitmapImage((image.Source as BitmapImage).UriSource);
                if(selected1.UriSource == selected2.UriSource)
                {
                    selectedButton.IsEnabled= false;
                    button.IsEnabled= false;
                    guessed++;
                    if(guessed == CardData.Columns * CardData.Rows / 2)
                    {
                        MessageBox.Show("You won!");
                    }
                    game.Moves.Add(new Tuple<string, string>(selected1.UriSource.ToString(), selected2.UriSource.ToString()));
                    selected1 = null;
                    selected2 = null;
                    selectedButton = null;
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        this.IsEnabled = false;
                        Mouse.OverrideCursor = Cursors.Wait;
                    }, DispatcherPriority.ApplicationIdle);

                    // wait for 2 seconds
                    await Task.Delay(400);

                    // re-enable the UI thread
                    this.Dispatcher.Invoke(() =>
                    {
                        Mouse.OverrideCursor = null;
                        this.IsEnabled = true;
                    }, DispatcherPriority.ApplicationIdle);

                    image.Visibility= Visibility.Hidden;
                    selected1Ref.Visibility= Visibility.Hidden;
                    selectedButton.IsEnabled = true;
                    selected1 = null;
                    selected2 = null;
                    selectedButton = null;
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameSelector gameSelector = new GameSelector(currentPlayer);
            gameSelector.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
