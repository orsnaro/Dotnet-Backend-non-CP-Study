using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBuildingAutomationAPI {
    public class RemoteDeviceOfficeControl : BaseOfficeControl {
        public RemoteDeviceOfficeControl(Office[] offices) : base(offices) {
            LogLightingStatus();
            LogSecuritySystemStatus();
        }

        public override void LightToggleButton_Press() {
            base.LightToggleButton_Press();
            LogLightingStatus();
        }

        public override void SecuritySystemToggleButton_Press() {
            base.SecuritySystemToggleButton_Press();
            LogSecuritySystemStatus();
        }

        private void LogLightingStatus() {
            string status = String.Empty;

            foreach (Office office in base.Offices) {
                status = (office.IsLightOn) ? "on" : "off";

                base.LogInfo($"from remote control device: the lightf of office: {office.OfficeId} is {status}");

                Console.WriteLine();
            }
        }

        private void LogSecuritySystemStatus() {
            string status = String.Empty;

            foreach (Office office in base.Offices) {
                status = (office.IsSecuritySystemArmed) ? "armed" : "disarmed";

                base.LogInfo($"from remote control device: the security system of office: {office.OfficeId} is {status}");

                Console.WriteLine();
            }
        }
    }
}
