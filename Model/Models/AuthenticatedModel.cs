using Solution.Model.Enums;
using System.Collections.Generic;

namespace Solution.Model.Models
{
    public class AuthenticatedModel
    {
        public IEnumerable<Role> Roles { get; set; } = new List<Role>();

        public long UserId { get; set; }
    }
}