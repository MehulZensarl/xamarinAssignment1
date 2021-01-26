using System;
using Akavache.Sqlite3.Internal;

namespace Assignment1.Models
{
    public class UserModel
    {
        [PrimaryKey][AutoIncrement]
        public int id { get; set; }

        public string name { get; set; }

        public string designation { get; set; }

        public string email { get; set; }

        public string mobnumber { get; set; }

        public byte[] profileImage { get; set; }
    }
}
