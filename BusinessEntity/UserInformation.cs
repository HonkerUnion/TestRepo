using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UserInformation
    {
        public int USERINFORMATIONID { get; set; }
        public int USERID { get; set; }
        public string USERFIRSTNAME { get; set; }

        public string TREATMENTTYPE {get;set;}

        public string PRIMARYCONTACTNO { get; set; }
    }
}
