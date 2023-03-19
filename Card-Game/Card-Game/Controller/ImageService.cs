using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Card_Game.Controller
{
    public class ImageService
    {
    
        public List<string> AvatarPaths { get; set; }

        public ImageService() { 
            populateAvatars();
        }

        private static List<string> getRandomCards(int n) {
            DirectoryInfo dir = new DirectoryInfo("../../Asset/Image/Cards/");
            var files= dir.GetFiles();

            List<string> paths = new List<string>();
            foreach(var file in files)
            {
                paths.Add(file.FullName);
            }

            if(n > paths.Count)
            {
                MessageBox.Show("Not enough resources" + n.ToString() + " " + paths.Count.ToString());
                return null;
            }

            List<string> randomPaths= new List<string>();
            for(int i = 0; i < n; i++)
            {
                int index = new Random().Next(0, paths.Count);
                randomPaths.Add(paths[index]);
                paths.Remove(paths[index]);
            }
            return randomPaths;

        }

        public static List<List<BitmapImage>> GetCardBitmapImages(int rows, int cols) {
            List<List<BitmapImage>> bitmapImages= new List<List<BitmapImage>>();
            List<BitmapImage> list;
            for (int index = 0; index < rows; index++) {
                list= new List<BitmapImage>();
                for(int jndex = 0; jndex < cols; jndex++)
                {
                    list.Add(null);
                }
                bitmapImages.Add(list);
            }

            int n = (rows * cols) / 2;

            List<string> paths = getRandomCards(n);
           
            int i, j;
            foreach(var path in paths)
            {
                do
                {
                    i = new Random().Next(0, rows);
                    j = new Random().Next(0, cols);
                } while (bitmapImages[i][j] != null);
                bitmapImages[i][j] = new BitmapImage(new Uri(path));
            }
            foreach(var path in paths)
            {
                for(int index = 0; index < rows; index++)
                {
                    int ok = 0;
                    for(int jndex = 0; jndex < cols; jndex++)
                    {
                        if (bitmapImages[index][jndex] == null)
                        {
                            bitmapImages[index][jndex] = new BitmapImage(new Uri(path));                           
                            ok = 1;
                            break;
                        }
                    }
                    if (ok == 1)
                        break;
                }      
            }
            return bitmapImages;
        }

        public int GetAvatarCountAvalaible()
        {
            return AvatarPaths.Count;
        }

        public string GetAvatarPath(int index)
        {
            return AvatarPaths[index];
        }
        private void populateAvatars()
        {
            AvatarPaths = new List<string>();
            DirectoryInfo dir = new DirectoryInfo("../../Asset/Image/Avatar/");
            foreach(var file in dir.GetFiles()) {
                AvatarPaths.Add(file.FullName);
            }
        }

    }
}
