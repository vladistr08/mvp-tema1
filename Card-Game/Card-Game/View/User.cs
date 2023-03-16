using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Card_Game.View
{
    public class User
    {
        public static List<Player> Users = new List<Player>();
        public List<string> UserNames { get; set; }
        public List<string> UserImagePaths { get; set; }

        public User()
        {
            Users = GetAllUsers();
            UserNames = View.User.GetUserNames();
            UserImagePaths = View.User.GeUserImagePaths();
            
        }
        public void AddUser(Player newPlayer)
        {
            Users.Add(newPlayer);
            JsonService.SerializeToFile<Player>(newPlayer.DataFileName, newPlayer);
        }

        public void RemoveUser(Player player)
        {
            Users.Remove(player);
            JsonService.DeleteFileFromPath(player.DataFileName);
        }

        public List<Player> GetAllUsers()
        {
            List<Player> users = new List<Player>();
            string path = "C:\\mvp\\mvp-tema1\\Card-Game\\Card-Game\\Asset\\Data\\";
           
            
            foreach (string fileName in Directory.GetFiles(path))
            {
          
                users.Add(JsonService.DeserializeFromFile<Player>(fileName));
            }
            
            return users;
        }

        public static List<string> GetUserNames()
        {
            return Users.Select(x => x.Name).ToList();
        }

        public static List<string> GeUserImagePaths()
        {
            return Users.Select(x => x.ProfileImagePath).ToList();
        }

    }
}
