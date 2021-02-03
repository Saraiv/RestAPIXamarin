using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RestAPIXamarin.Models
{
    public class User{

        [PrimaryKey]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public User() { }

        public User(string username, string password){
            this.username = username;
            this.password = password;
        }

        public bool CheckIfUserInputs(){
            if(!this.username.Equals("") && !this.password.Equals("")){
                return true;
            } else{
                return false;
            }
        }
    }
}
