﻿using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.User.PutUser
{
    public class PutUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
};
