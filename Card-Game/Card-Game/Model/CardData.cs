using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game.Model
{
    public class CardData
    {
        public static int Rows { get; set; } = 6;
        public static int Columns { get; set; } = 6;
        public List<List<string>> CardItems { get; set; }

        public CardData()
        {
            CardItems = new List<List<string>>();
            for (int i = 0; i < Rows; i++)
            {
                List<string> list = new List<string>();
                for (int j = 0; j < Columns; j++)
                {
                    list.Add("item:" + i + j);
                }
                CardItems.Add(list);
            }
        }
    }
}
