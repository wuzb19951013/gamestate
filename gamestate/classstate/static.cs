using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamestate.classstate
{
    class @static
    {
        public static int keystate = -1;
    }
    public class User2
    {
        private string _credit = "";

        public string Credit
        {
            get
            {
                return _credit;
            }
            set
            {
                _credit = value;
                CreditUpdated(this, EventArgs.Empty);
            }
        }

        public static User2 instance = new User2();

        public event EventHandler CreditUpdated;
    }
}
