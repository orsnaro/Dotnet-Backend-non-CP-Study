using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBuildingAutomationAPI {
    public class BaseOfficeControl {
        protected internal Office[] Offices = null!;

        public BaseOfficeControl(Office[] offices) {
            Offices = offices;
        }

        public virtual void LightToggleButton_Press() {
            foreach(Office office in Offices) {
                office.ToggleLights();
            }
        }

        public virtual void SecuritySystemToggleButton_Press() {
            foreach(Office office in Offices) {
                office.ToggleSecuritySystem();
            }
        }

        private protected void LogInfo(string line) {//only this class and childs of this class in same assembly can use this method!
            Console.WriteLine(line);
        }
    }

}
 