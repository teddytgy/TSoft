using System.Collections.Generic;


namespace TSoft.Entities.Models
{       
    public class UserProfile
    {
        public UserProfile()
        {
            Roles = new List<Role>();           
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}