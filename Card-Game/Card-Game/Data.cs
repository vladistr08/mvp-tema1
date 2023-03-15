using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    public class Data
    {
        public List<List<string>> StringItems { get; set; }

        public Data()
        {
            StringItems = new List<List<string>>();
            for(int i = 0; i < 5; i++)
            {
                List<string> list = new List<string>();
                for(int j = 0; j < 5; j++)
                {
                    list.Add("item:" + i + j);
                }
                StringItems.Add(list);
            }
        }
    }
}
