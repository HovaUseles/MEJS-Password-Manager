using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager___Grundforløbsprøve
{
    class LoginClass
    {
        public LoginClass (int idInput, string deviceInput, string usernameInput, string passwordInput)
            {
            ID = idInput;
            device = deviceInput;
            username = usernameInput;
            password = passwordInput;
            }

        public int ID { get; set; }

        public string device { get; set; }

        public string username { get; set; }

        public string password { get; set; }

    }
}
