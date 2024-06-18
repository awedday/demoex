using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Functional
    {
        public Session1_XXEntities db = new Session1_XXEntities();

        public int CountUsers()
        {
            return db.Users.ToList().Count;
        }

        public string IDUser()
        {
            string id;
            string ID = "Ошибка";
            var userList = db.Roles.Where(a => a.Title.Contains("User")).ToList();
            foreach (var user in userList)
            {
                id = user.ID.ToString();
                
                return id;
            }
            return ID;
        }

            


    }
}
