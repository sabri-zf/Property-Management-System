namespace Infrastructure.Entities
{
    internal class User
    {
        public virtual int UserId { get; set; }

        public virtual int PersonId { get; set; }

        public virtual string Username { get; set; } = null!;
        public virtual string Password { get; set; } = null!;

        public virtual DateTime CreateAt { get; set; }
        public virtual DateTime? UpdateAt { get; set; }

        public virtual bool IsActive { get; set; }

        // in the future we'll set ther role to any user on the system
        //public virtual byte Role {  get; set; }





        // Relationship : Person Has many Users and User belong to one Person
        public virtual Person Person { get; set; }
        public virtual Admin Admin { get; set; }

        // Relationship : Manager Has many User and User Represent a Manager
        public virtual ICollection<Manager> Managers {  get; set; } = new List<Manager>();
    }
}
