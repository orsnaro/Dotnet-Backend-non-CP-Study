using System.Reflection.PortableExecutable;

namespace BinaryFileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                int recSize = sizeof(int) + ((Employee.NameSize + 1) * 2) + sizeof(decimal) + (sizeof(char) - 1) + sizeof(bool);

                string rootPath = AppDomain.CurrentDomain.BaseDirectory;
                string binaryFile = Path.Combine(rootPath, "Employees.dat");

                SeedData(binaryFile);
            

                while (true){
                    ShowMainScreen(binaryFile, recSize);

                    Console.WriteLine("Please press the 'y' key if you'd like to update a particular record or press any other key");
                    ConsoleKey key = Console.ReadKey().Key;

                    if(key == ConsoleKey.Y) {
                        Console.WriteLine();
                        Console.WriteLine("Please enter the id of record you wish to update");
                        int inputId = Convert.ToInt32(Console.ReadLine());
                        UpdateEmployeeRecord(inputId, binaryFile, recSize);
                    } else {
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Thank you!");

                Console.ReadKey();

            } catch (Exception e) {
                Console.Clear();
                Console.BackgroundColor= ConsoleColor.DarkRed;
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine($"{e}");
                Console.ResetColor();
            }
        }

        private static void SeedData(string binaryFile) {
            if (!File.Exists(binaryFile)) {
                // Instance 1: A standard employee
                Employee emp1 = new Employee {
                    Id = 101,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Salary = 65000.00m,
                    Gender = 'F',
                    IsManager = false
                };

                // Instance 2: A manager with a long name (will be truncated to 20 chars by the getter)
                Employee emp2 = new Employee {
                    Id = 102,
                    FirstName = "Alexander-Christopher", // 21 characters long, will be truncated to "Alexander-Christophe"
                    LastName = "Rodriguez",
                    Salary = 95000.50m,
                    Gender = 'M',
                    IsManager = true
                };

                // Instance 3: An employee with short names (will be right-padded with spaces by the getter)
                Employee emp3 = new Employee {
                    Id = 103,
                    FirstName = "Bo", // Will be padded to 20 characters
                    LastName = "Li", // Will be padded to 20 characters
                    Salary = 58000.00m,
                    Gender = 'U',
                    IsManager = false
                };

                using (BinaryWriter writer = new BinaryWriter(new FileStream(binaryFile, FileMode.Create))) {
                    AddEmployeeRecord(writer, emp1);
                    AddEmployeeRecord(writer, emp2);
                    AddEmployeeRecord(writer, emp3);
                }
            }
        }
        
        private static void AddEmployeeRecord(BinaryWriter writer, Employee employee) {
            writer.Write(employee.Id);
            writer.Write(employee.FirstName);//size is ecatly 20chars
            writer.Write(employee.LastName);//size is ecatly 20chars
            writer.Write(employee.Salary);
            writer.Write(employee.Gender);//char in csharp is 2 bytes we write it as one byte 'M' or 'F' gaurnteed to not exceed one byte
            writer.Write(employee.IsManager);
        }

        private static void UpdateEmployeeRecord(int inputId, string binaryFile, int recSize) {
            int totalRecords = GetNumberOfRecords(GetFileSize(binaryFile), recSize);
            int recordOffset = FindRecordById(binaryFile, inputId, recSize, totalRecords);

            if (recordOffset != -1) { //found!

                using (FileStream filestream = new FileStream(binaryFile, FileMode.Open)) {
                    filestream.Seek(recordOffset + sizeof(int), SeekOrigin.Begin); //skip the id (prevent user from updating ids!)
                    using (BinaryWriter writer = new BinaryWriter(filestream)) {
                        UpdateName(filestream, writer, "First Name");
                        UpdateName(filestream, writer, "Last Name");
                        UpdateSalary(filestream, writer, "Salary");
                        UpdateGender(filestream, writer, "Gender"); // no you cant update gender just skips to next internally
                        UpdateIsManager(filestream, writer, "Manager");
                    }
                }
            } else {
                Console.WriteLine();
                Console.WriteLine("Unable to find record. Please press any key to navigate to the main screen");
            }
        }
        private static void UpdateName(FileStream fileStream, BinaryWriter writer, string fieldLabel) {
            Console.WriteLine($"Please enter a value for {fieldLabel}");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name)) {
                fileStream.Seek(Employee.NameSize + 1, SeekOrigin.Current);//why skip?(auto move to next field in the record
            } else {
                writer.Write(name.PadRight(Employee.NameSize));
            }
        }
        private static void UpdateSalary(FileStream fileStream, BinaryWriter writer, string fieldLabel) {
            Console.WriteLine($"Please enter a value for {fieldLabel}");
            string? salaryInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(salaryInput)) { 
                fileStream.Seek(sizeof(decimal), SeekOrigin.Current);
            } else {
                decimal salary = decimal.Parse(salaryInput, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);
                writer.Write(salary);
            }


        }
        private static void UpdateGender(FileStream fileStream, BinaryWriter writer, string fieldLabel) { 
                fileStream.Seek(sizeof(byte), SeekOrigin.Current); //you cant change gender!
        }
        private static void UpdateIsManager(FileStream fileStream, BinaryWriter writer, string fieldLabel) {
            Console.WriteLine($"Please enter a value for {fieldLabel}:   true/false");
            string isManagerInput = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(isManagerInput)) { 
                bool isManager = Convert.ToBoolean(isManagerInput);
                writer.Write(isManager);
            }

        }

        private static int FindRecordById(string binaryFile, int inputId, int recSize, int totalRecords) {
            int recPosition = -1;
            int readId = -1;

            using (FileStream fileStream = new FileStream(binaryFile, FileMode.Open)) {
                using (BinaryReader reader = new BinaryReader(fileStream)) {
                    for (int i = 0; i < totalRecords; i++) {
                        recPosition = GetRecordFirstByteOffset(recSize, i);
                        fileStream.Seek(recPosition, SeekOrigin.Begin);
                        readId = reader.ReadInt32(); //first field in the Employee class saved in the binary file is the id and its int32 var

                        if (readId == inputId) {
                            return recPosition;
                        } else {
                            recPosition = -1;
                        }
                    }
                }
            }
            return recPosition; //fail record not found in the .dat binary file
        }
        private static int GetRecordFirstByteOffset(int recSize, int position) {
            return recSize * position; //return byte poistion
        }

        private static string GetMainHeading() {
            return "Employee Records binary Application";
        } 
        private static string GetFieldHeadings() {
            return $"{"Id".PadRight(7)} {"First Name".PadRight(Employee.NameSize)} {"Last Name".PadRight(Employee.NameSize)} {"Salary".PadRight(10)} {"Gender".PadRight(7)} {"Manager".PadRight(8)}";
        }
        private static void DisplayHeading(){
            string mainHeading = GetMainHeading();
            Console.WriteLine(mainHeading);
            Console.WriteLine(GetUnderline(mainHeading));
            Console.WriteLine();

            string fieldHeadings = GetFieldHeadings();
            Console.WriteLine(fieldHeadings);
            Console.WriteLine(GetUnderline(fieldHeadings));
            Console.WriteLine();

        }
        private static string GetUnderline(string heading) {
            return new string('-', heading.Length);
        }



        private static int GetFileSize(string binaryFile) {
            FileInfo file = new FileInfo(binaryFile);

            return Convert.ToInt32(file.Length);
        }
        private static int GetNumberOfRecords(int binaryFileSize, int recSize) {
            return binaryFileSize / recSize;
        }

        private static void ShowMainScreen(string binaryFile, int recSize) {
            Console.Clear();
            DisplayHeading();
            int totalRecords = GetNumberOfRecords(GetFileSize(binaryFile), recSize);

            DisplayAllRecordsOnScreen(binaryFile, totalRecords);
        }
        private static void DisplayAllRecordsOnScreen(string binaryFile, int totalRecords) {
            using (BinaryReader reader = new BinaryReader(new FileStream(binaryFile, FileMode.Open))) {
                for (int i = 0; i < totalRecords; i++) {
                    //read from file -> convert to string -> (optional) pad -> print to console
                    Console.Write(reader.ReadInt32().ToString().PadRight(7)); //id
                    Console.Write(" " + reader.ReadString().PadRight(Employee.NameSize)); //first name
                    Console.Write(" " + reader.ReadString().PadRight(Employee.NameSize)); //first name
                    Console.Write(" " + reader.ReadDecimal().ToString().PadRight(10)); //salary
                    Console.Write(" " + reader.ReadChar().ToString().PadRight(7)); //gender
                    Console.Write(" " + reader.ReadBoolean().ToString().PadRight(8)); //is manager
                    Console.WriteLine();
                }
            }
        }
    }


    public class Employee {
        public const int NameSize = 20;
        private string _firstName = String.Empty;
        private string _lastName = String.Empty;

        public int Id { get; set; } //TODO: auto generate unique ids
        public string FirstName {
            get {
                return (_firstName.Length > NameSize) ? _firstName.Substring(0, NameSize) : _firstName.PadRight(NameSize);
            }
            set { 
                _firstName = value;
            }
        }
        public string LastName {
            get {
                return (_lastName.Length > NameSize) ? _lastName.Substring(0, NameSize) : _lastName.PadRight(NameSize);
            }
            set {
                _lastName = value;
            }
        }

        public decimal Salary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }
    }

}
