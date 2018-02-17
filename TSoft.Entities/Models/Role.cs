using System.Collections.Generic;

namespace TSoft.Entities.Models
{
    public class Role
    {
        public Role()
        {
            UserProfiles = new List<UserProfile>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        //public ObjectState State { get; set; }
    } 
}