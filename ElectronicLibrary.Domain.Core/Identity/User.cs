﻿using Microsoft.AspNetCore.Identity;
namespace ElectronicLibrary.Domain.Core.Identity
{
    public class User: IdentityUser
    {
        public bool IsBlocked { get; set; }
    }
}
