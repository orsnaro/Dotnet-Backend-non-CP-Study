using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace freecodecamp_adv_csharp {
    internal class FakeWebService {
        private static int _securityToken = default;

        internal FakeWebService() {
            _securityToken++;
        }

        internal int Login(int officeId, string userName, string password) {
            return _securityToken;
        }

        internal bool IsLightOn(int securityToken) {
            return false;
        }

        internal bool IsSecuritySystemArmed(int securityToken) {
            return false;
        }

        internal void SwitchLightsOn(int securityToken) { 
            //logic
        }

        internal void SwitchLightsOff(int securityToken) {
            //logic
        }

        internal void ArmSecuritySystem(int securityToken) {
            //logic
        }

        internal void DisarmSecuritySystem(int securityToken) {
            //logic
        }
    }
}
