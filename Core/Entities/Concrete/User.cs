using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public byte[] UserPasswordHush { get; set; }
        public byte[] UserPasswordSalt { get; set; }
        public bool Status { get; set; }
    }

}
