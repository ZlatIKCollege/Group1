using System;
using System.Collections.Generic;

#nullable disable

namespace Xiaomi.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Passport { get; set; }
        public string Contact { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }

        public virtual Role Role { get; set; }
    }
}
