﻿using System.ComponentModel.DataAnnotations;

namespace KGD.Domain.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
