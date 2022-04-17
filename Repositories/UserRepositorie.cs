using TCC_AmoPatas.Models;

namespace TCC_AmoPatas
{ //base de dados de exemplo / Lista de dados


// aqui eu praticamente crie um "banco" local chamando 
    public  static class UserRepositorie
    {
        public static User get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User{UserId  = 1 , username = "Augusto", Password = "949156010", Role = "manager"});
            users.Add(new User{UserId  = 2, username = "Siangui", Password = "12345678", Role = "employee"});
            return users.FirstOrDefault(x => 
            x.username.ToLower() == username.ToLower() 
                && x.Password == password); 
        }
    }
}