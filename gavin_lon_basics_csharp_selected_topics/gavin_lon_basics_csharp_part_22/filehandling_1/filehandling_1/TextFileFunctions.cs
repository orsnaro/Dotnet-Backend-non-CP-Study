using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace filehandling_1 {
    public class TextFileFunctions {
        private readonly string _rootPath = AppDomain.CurrentDomain.BaseDirectory;
        private string _fileName = "test.txt";

        public TextFileFunctions (string fileName) { 
            _fileName = fileName;
            Console.WriteLine("Root Path: " + _rootPath);
        }

        public void WriteTextToFile(string[] lines) {
            using StreamWriter outputFile = new StreamWriter(Path.Combine(_rootPath, _fileName), append: true);
            foreach (string line in lines) {
                outputFile.WriteLine(line);
            }
            //`using` handles outputFile.Open() and outputFile.Close() 
        }

        public string ReadFile() {
            using StreamReader sr = new StreamReader(Path.Combine(_rootPath, _fileName));
            var content = sr.ReadToEnd();
            return content;
        }


    }
}
