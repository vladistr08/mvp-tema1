using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfileImagePath { get; set; }
        public Player(string name, string profileImagePath)
        {
            Id = new Guid();
            Name = name;
            ProfileImagePath = profileImagePath;
        }
    }
}
