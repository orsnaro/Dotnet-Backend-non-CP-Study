using System;
using System.Diagnostics.Tracing;
using OfficeBuildingAutomationAPI;

namespace OfficeBuildingAutomation {

    class Program {
        static void Main(string[] args) {
            Office office1 = new Office();
            Office office2 = new Office();
            Office office3 = new Office();

            Office[] offices = new Office[3];

            office1.Login(1001, "Admin", "password");
            office2.Login(1002, "Admin", "password");
            office3.Login(1003, "Admin", "password");

            offices[0] = office1;
            offices[1] = office2;
            offices[2] = office3;

            WriteInstructionHeader();

            AppOfficeControl appOfficeControl = new AppOfficeControl(offices);

            TestOfficeControl officeControl = new TestOfficeControl(appOfficeControl);

            while (true) {
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();

                WriteInstructionHeader();

                if (key == ConsoleKey.L) {
                    officeControl.LightToggleButton_Press();
                } else if (key == ConsoleKey.S) {
                    officeControl.SecuritySystemToggleButton_Press();
                } else if (key == ConsoleKey.Spacebar) { 
                    Console.Clear();
                    break;
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please use those controls: \nToggle lights: [L]\nToggle security system: [S]\nEnd application: [Spacebar]");
                }

            
            }
        }

        private static void WriteInstructionHeader() {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("\nToggle lights: [L]\nToggle security system: [S]\nEnd application: [Spacebar]");
            Console.ResetColor();

            Console.Write("\n\n***STATUS***\n\n");
        }

    }

}