using System.Net.NetworkInformation;
using System.Text;

namespace MemoryStreamExample
{
    internal class Program
    {

        //in bytes (char == 2 bytes in unicode default)
        const int IdOffset = 0;
        const int IdLength = 16;

        const int FirstNameOffset = 16;
        const int FirstNameLength = 40;

        const int LastNameOffset = 56;
        const int LastNameLength = 40;

        const int SalaryOffset = 96;
        const int SalaryLength = 20;

        const int GenderOffset = 116;
        const int GenderLength = 4;

        const int IsManagerOffset = 120;
        const int IsManagerLength = 10; //false is 5 char  , each char 2 bytes -> total= 5 * 2 = 10 bytes needed

        //tot length in bytes
        const int RecordLength = IdLength + FirstNameLength + LastNameLength + SalaryLength + GenderLength + IsManagerLength;

        static void Main(string[] args)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            MemoryStream ms = new MemoryStream(RecordLength); //not fixed size can increase dynamically (as long as were not passing an byte[] as an arg

            SeedData(unicodeEncoding, ms);

            Console.WriteLine("Employee Record before Promotion");
            Console.WriteLine("--------------------------------");

            Console.WriteLine($"Id: {GetField(unicodeEncoding, ms, IdOffset, IdLength)}");
            Console.WriteLine($"FirstName: {GetField(unicodeEncoding, ms, FirstNameOffset, FirstNameLength)}");
            Console.WriteLine($"LastName: {GetField(unicodeEncoding, ms, LastNameOffset, LastNameLength)}");
            Console.WriteLine($"Salary: {GetField(unicodeEncoding, ms, SalaryOffset, SalaryLength)}");
            Console.WriteLine($"Gender: {GetField(unicodeEncoding, ms, GenderOffset, GenderLength)}");
            Console.WriteLine($"Manager: {GetField(unicodeEncoding, ms, IsManagerOffset, IsManagerLength)}");

            Console.WriteLine($"Press any key to update the above employee's record");
            Console.ReadKey();
            Console.WriteLine();

            ms.Seek(0, SeekOrigin.Begin);

            UpdateSalary(unicodeEncoding, ms, SalaryOffset, SalaryLength, 80000);
            UpdateIsManager(unicodeEncoding, ms, IsManagerOffset, IsManagerLength, true);

            ms.Seek(0, SeekOrigin.Begin);

            Console.WriteLine("Employee Record after Promotion");
            Console.WriteLine("-------------------------------");

            Console.WriteLine($"Id: {GetField(unicodeEncoding, ms, IdOffset, IdLength)}");
            Console.WriteLine($"FirstName: {GetField(unicodeEncoding, ms, FirstNameOffset, FirstNameLength)}");
            Console.WriteLine($"LastName: {GetField(unicodeEncoding, ms, LastNameOffset, LastNameLength)}");
            Console.WriteLine($"Salary: {GetField(unicodeEncoding, ms, SalaryOffset, SalaryLength)}");
            Console.WriteLine($"Gender: {GetField(unicodeEncoding, ms, GenderOffset, GenderLength)}");
            Console.WriteLine($"Manager: {GetField(unicodeEncoding, ms, IsManagerOffset, IsManagerLength)}");

            Console.ReadKey();
        }

        private static void SeedData(UnicodeEncoding unicodeEncoding, MemoryStream ms) {
            int id = 1003;
            string firstName = "John";
            string lastName = "Jenkins";
            decimal salary = 60000;
            char gender = 'm';
            bool isManager = false;

            string employeeRecord = id.ToString().PadRight(IdLength / 2) + firstName.PadRight(FirstNameLength / 2) + lastName.PadRight(LastNameLength / 2) + salary.ToString().PadRight(SalaryLength / 2) + gender.ToString().PadRight(GenderLength / 2) + isManager.ToString().PadRight(IsManagerLength / 2);

            byte[] employeeData = unicodeEncoding.GetBytes(employeeRecord); //not char array bytes are standard fixed size of 8bits (char can be one bytes or two bytes and in this example the default is 2 bytes per char)

            ms.Write(employeeData, 0, employeeRecord.Length * 2); //each char is 2 bytes memroy stream needs to know the total bytes (also can use employeeData.Length or member RecordLength
        }

        private static string GetField(UnicodeEncoding unicodeEncoding, MemoryStream ms, int offset, int lengthBytes) {
            //we can skipp usign offset variable totally cuz the seek pointer auto moves when we read from memory

            ms.Seek(offset, SeekOrigin.Begin); //go to the right location in memory

            byte[] byteArray = new byte[lengthBytes];

            int count = ms.Read(byteArray, 0, lengthBytes); //get the value from memory and save it to the buffer (byteArray)

            //string fieldValue = new String(byteArray);//ops we need to converte byteArray to char[] first !❌
            string fieldValue = new String(GetCharArrayFromByteArray(unicodeEncoding, byteArray, count));//✅

            return fieldValue;
        }

        private static char[] GetCharArrayFromByteArray(UnicodeEncoding unicodeEncoding, byte[] byteArray, int count) {
            //char[] charArray = unicodeEncoding.GetChars(byteArray);// slow  when reading a big file via loop + splited big chars (4byte emojies) will be corrupted

            //better approach
            //1.pre-alocate the output var (GetCharCount() also faster when given count)
            char[] charArray2 = new char[unicodeEncoding.GetCharCount(byteArray, 0, count)]; //or jsut unicodeEncoding.GetCharCount(byteArray) (bit slower)

            //2. faster + GetDecoder() is smarter read more on GetDecoder
            unicodeEncoding.GetDecoder().GetChars(byteArray, 0, count, charArray2, 0);

            return charArray2;
        }


        private static void UpdateSalary(UnicodeEncoding unicodeEncoding, MemoryStream ms, int salaryOffset, int salaryLength, decimal newSalary) {
            string newSalaryStr = newSalary.ToString().PadRight(salaryLength/2);

            UpdateField(unicodeEncoding, ms, salaryOffset, salaryLength, newSalaryStr);
        }

        private static void UpdateIsManager(UnicodeEncoding unicodeEncoding, MemoryStream ms, int isManagerOffset, int isManagerLength, bool newIsManager) {
            string newIsManagerStr = newIsManager.ToString().PadRight(isManagerLength / 2);
            UpdateField(unicodeEncoding, ms, isManagerOffset, isManagerLength, newIsManagerStr);
        }

        private static void UpdateField(UnicodeEncoding unicodeEncoding, MemoryStream ms, int fieldOffset, int fieldLength, string newFieldValue) {
            byte[] newValueBytes = unicodeEncoding.GetBytes(newFieldValue);

            ms.Seek(fieldOffset, SeekOrigin.Begin);

            ms.Write(newValueBytes, 0, fieldLength);
        }


    }
}
