using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace CRUD_usingXamarin.Models
{
    public class Company
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }


        public override string ToString()
        {
            return this.Name;
        }
    }
}
