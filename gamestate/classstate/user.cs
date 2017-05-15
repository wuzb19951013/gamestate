using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamestate.classstate
{
    class user
    {
        private Windows.System.VirtualKey _keycode = 0;

        public Windows.System.VirtualKey Keycode
        {
            get
            {
                return _keycode;
            }
            set
            {
                _keycode = value;
                CreditUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        public static user instance = new user();

        public event EventHandler CreditUpdated;

        public void hkjhkjh()
        {
            CreditUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
