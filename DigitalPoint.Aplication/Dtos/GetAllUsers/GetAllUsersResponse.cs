using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPoint.Application.Dtos.GetAllUsers
{
    public  class GetAllUsersResponse {

        public bool Success { get; set; }

        public List<string> Errors { get; set; }

        public List<IdentityUser> Users { get;  set; }

        public GetAllUsersResponse(List<IdentityUser> users, bool success){
            Users = users;
            Success = success;
        }

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);

    }
}
