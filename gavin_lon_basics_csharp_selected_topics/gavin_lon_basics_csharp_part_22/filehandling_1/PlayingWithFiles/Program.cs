using filehandling_1;

namespace PlayingWithFiles {
    class Program {
        static void Main(string[] args) {
            try {
                WriteHeadingToScreen();
                Console.WriteLine("Please enter a name for your File:");
            

                string fileName = Console.ReadLine();

                Console.WriteLine();

                string[] lines = new string[3];
                int size = lines.Length;


                TextFileFunctions textFileFunctions = new TextFileFunctions(fileName: "test.txt");

                int count = 0;
                while (count < size) {
                    Console.WriteLine($"Please add {(count > 0 ? "another line" : "a line")} to file, '{fileName}'");
                    lines[count] = Console.ReadLine();
                    count++;
                }

                textFileFunctions.WriteTextToFile(lines);

                Console.Clear();

                WriteHeadingToScreen();

                Console.WriteLine(textFileFunctions.ReadFile());

            } catch(IOException ex) {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

        }

        private static void WriteHeadingToScreen() {
            Console.WriteLine("Basic .NET Cross Platform File Handling");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
        }
    }
}
