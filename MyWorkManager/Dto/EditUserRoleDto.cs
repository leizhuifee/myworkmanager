using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkManager.Dto
{
    public class EditUserRoleDto
    {

        public EditUserRoleDto()
        {
            NotInRoles = new List<IdentityRole>();
            InRoles = new List<IdentityRole>();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<IdentityRole> NotInRoles { get; set; }
        public List<IdentityRole> InRoles { get; set; }
    }
}
