using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeclarationDeVol.Models
{
    public class UsersViewModel
    {
        public DeclarationDeVol.Models.Users SingleUser { get; set; }
        public IEnumerable<DeclarationDeVol.Models.Users> UserList { get; set; }
    }
}