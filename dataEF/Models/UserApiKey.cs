using System;
using System.Collections.Generic;

namespace dataEF.Models
{
    public partial class UserApiKey
    {
        public int UserApiKeyId { get; set; }
        public Guid ApiKeyValue { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
