using Card_Game.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Card_Game.Model
{
    public class CardData
    {
        public static int Rows { get; set; }
        public static int Columns { get; set; }
        public static List<List<BitmapImage>> CardImages { get; set; }

        private void initCardImages()
        {
            CardImages = ImageService.GetCardBitmapImages(Rows, Columns);
        }

        public CardData()
        {  
            initCardImages();
        }
    }
}
