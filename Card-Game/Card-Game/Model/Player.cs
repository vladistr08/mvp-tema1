using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    [Serializable]
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfileImagePath { get; set; }
        public string DataFileName { get; set; }

        public Player(string name, string profileImagePath)
        {
            Id = Guid.NewGuid();
            Name = name;
            ProfileImagePath = profileImagePath;
            DataFileName = getDataFileName();
        }
        private string getDataFileName()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("../../Asset/Data/");
            int count = dir.GetFiles().Length + 1;
            return count.ToString() + "_" + Name + "_" + Id.ToString();
        }
    }
}
