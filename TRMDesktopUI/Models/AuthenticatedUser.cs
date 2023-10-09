using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Models
{    
    public class AuthenticatedUser
    {
        public string Access_Token { get; set; }
        public string UserName { get; set; }


        //Do we need these?:
        public string token_type { get; set; }
        public int expires_in { get; set; }        
        public string issued { get; set; }
        public string expires { get; set; }
    }
}
