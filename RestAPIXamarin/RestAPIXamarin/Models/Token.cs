using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIXamarin.Models
{
    public class Token{
        [PrimaryKey]
        public int id { get; set; }
        public string accessToken { get; set; }
        public string errorDescription { get; set; }
        public DateTime expireDate { get; set; }
        public int expireIn { get; set; }

        public Token() { }
    }
}
