namespace Domain.Entities
{
    public sealed class User
    {
        public  int UserId { get; set; }

        public  int PersonId { get; set; }

        public  string Username { get; set; } = null!;
        public  string Password { get; set; } = null!;

        public  bool IsActive { get; set; }

        // in the future we'll set ther role to any user on the system
        //public virtual byte Role {  get; set; }





        // Relationship : Person Has many Users and User belong to one Person
        public  Person Person { get; set; }
        public Admin Admin { get; set; }

        // Relationship : Manager Has many User and User Represent a Manager
        public  ICollection<Manager> Managers {  get; set; } = new List<Manager>();
    }
}
