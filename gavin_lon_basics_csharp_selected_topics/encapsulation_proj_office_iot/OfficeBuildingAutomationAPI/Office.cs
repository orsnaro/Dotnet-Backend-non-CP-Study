using freecodecamp_adv_csharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBuildingAutomationAPI {
    public class Office {
        public int OfficeId = 0;

        private bool _isLightOn = false;
        public bool IsLightOn { get => _isLightOn; private set => _isLightOn = value; } //read only

        private bool _isSecuritySystemArmed = false;
        public bool IsSecuritySystemArmed { get => _isSecuritySystemArmed; private set => _isSecuritySystemArmed = value; } //read only

        private FakeWebService _officeFakeWebService = null!; //read about 'the Null-Forgiving Operator' so if instead used null/default/didn't assign any! this will have initial value of null and its type is  not nullabe so we will get a warning sooner or later in constructor if not assigned value other than null
        private int _securityToken = 0;

        public Office() {
            _officeFakeWebService = new FakeWebService();
        }

        public void Login(int officeId, string userName, string password) {
            _securityToken = _officeFakeWebService.Login(officeId, userName, password);

            if (_securityToken > 0) {
                IsLightOn = _officeFakeWebService.IsLightOn(_securityToken);
                IsSecuritySystemArmed = _officeFakeWebService.IsSecuritySystemArmed(_securityToken);
                OfficeId = officeId;
            }

        }

        internal void ToggleLights() {
            if (IsLightOn) {
                _officeFakeWebService.SwitchLightsOff(_securityToken);
                IsLightOn = false;
            } else {
                _officeFakeWebService.SwitchLightsOff(_securityToken);
                IsLightOn = true;
            }
        }
        internal void ToggleSecuritySystem() {
            if (IsSecuritySystemArmed) {
                _officeFakeWebService.DisarmSecuritySystem(_securityToken);
                IsSecuritySystemArmed = false;
            } else {
                _officeFakeWebService.ArmSecuritySystem(_securityToken);
                IsSecuritySystemArmed = true;
            }
        }
    }
}
