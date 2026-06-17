using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeBuildingAutomationAPI;

namespace OfficeBuildingAutomation {
    internal class AppOfficeControl : BaseOfficeControl {
        public AppOfficeControl(Office[] offices) : base(offices) {
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

                // to use this method make it protected or protected internal not private protected
                //base.LogInfo($"from remote control device: the lightf of office: {office.OfficeId} is {status}");

                Console.WriteLine($"from remote control device: the lightf of office: {office.OfficeId} is {status}");
                Console.WriteLine();
            }
        }

        private void LogSecuritySystemStatus() {
            string status = String.Empty;

            foreach (Office office in base.Offices) {
                status = (office.IsSecuritySystemArmed) ? "armed" : "disarmed";

                // to use this method make it protected or protected internal not private protected
                //base.LogInfo($"from remote control device: the security system of office: {office.OfficeId} is {status}");

                Console.WriteLine($"from remote control device: the security system of office: {office.OfficeId} is {status}");
                Console.WriteLine();
            }
        }
        //just to mention that protected internal like baseofficecontrol can be used from another assembly
    }
}
