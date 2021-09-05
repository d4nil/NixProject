using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Interface.Presentation.ViewModels
{
    public class UsersViewModel : IdentityUser
    {
        public IEnumerable<IdentityUser> Users { get; set; }
    }
}
