namespace user_info.Models
{
    public class Usermodel
    {
        public int Id { get; set; }
        public string Fname { set; get; }
        public string Lname { set; get; }
        public string Email { set; get; }

        public string Phone { set; get; }

        public string Cvfilepatht { set; get; }

        // Uncomment if you want to store CV as a byte array in the database

    }
}
