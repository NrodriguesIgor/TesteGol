using TesteGol.Model.Base;

namespace TesteGol.Model.Entities
{
    public class User : Entity
    {
        public User()
        {

        }
        public User(string login, string password, string firstName, string lastName)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
