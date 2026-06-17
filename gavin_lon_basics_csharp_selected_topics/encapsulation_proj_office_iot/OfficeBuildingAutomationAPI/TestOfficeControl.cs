using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBuildingAutomationAPI {
    public class TestOfficeControl {

        private BaseOfficeControl _officeControl = null!;
        public TestOfficeControl(BaseOfficeControl officeControl) {
            _officeControl = officeControl;
        }



        public void LightToggleButton_Press() {
            Console.WriteLine("Testing light toggle button...\n");

            _officeControl.LightToggleButton_Press();

            LogLightingTestStatus();
            
        }
        
        public void SecuritySystemToggleButton_Press() {
            Console.WriteLine("Testing Security toggle button...\n");

            _officeControl.SecuritySystemToggleButton_Press();

            LogSecuritySystemTestStatus();
        }

        private void LogLightingTestStatus() {
            Console.WriteLine("Test offices: " + GetTestOfficeAsString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Light toggle test passed");
            Console.ResetColor();
        }

        private void LogSecuritySystemTestStatus() {
            Console.WriteLine("Test offices: " + GetTestOfficeAsString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Security toggle test passed");
            Console.ResetColor();
        }


        private string GetTestOfficeAsString() { 
            string officeIds = String.Empty;

            foreach(Office office in _officeControl.Offices) {
                officeIds += office.OfficeId.ToString() + ",";
            }


            return officeIds.TrimEnd(',');
        }
    }
 }

