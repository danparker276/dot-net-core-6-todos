using System;
using System.Collections.Generic;

namespace dataEF.Models
{
    public partial class User
    {
        public User()
        {
            UserApiKeys = new HashSet<UserApiKey>();
        }

        public int UserId { get; set; }
        public byte[]? Password { get; set; }
        public string? Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int UserTypeId { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<UserApiKey> UserApiKeys { get; set; }
    }
}
