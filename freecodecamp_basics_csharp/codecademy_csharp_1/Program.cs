using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;

namespace codecademy_csharp_1 {
    internal class Program {
        //static int Add(int a, [Optional] int b) { 
        //    return a + b;
        //}
        //static int Add(int a, int b = default) { //here b must come after a if it has a default value 
        //    return a + b;
        //}

        /// <Summary>
        ///  returns -1 if didnt find , the index if found
        /// </Summary>
        //static int IndexOf(List<string> ls, string toFind) {

        //    for(int i = 0; i< ls.Count; i++) 
        //        if (ls[i] == toFind) return i;

        //    return -1;
        //}


        // static double CalcArea(double width, double height) {
        //    return (width * height) / 2;
        //}

        //static int SumOfNumbers(int[] array) {
        //    if (array.Length == 0) return -1;

        //    int sum = 0;
        //    foreach (int num in array) 
        //        sum += num;

        //    return sum;
        //}

        //struct Person {
        //    string name;
        //    int age;

        //    public int GetAge() {
        //        return this.age;
        //    }
        //    public string GetName() {
        //        return this.name;
        //    }

        //    public Person(string name, int age) {
        //        this.name = name;
        //        this.age = age;
        //    }
        //}

        //static Person RegisterPerson(){

        //    string name = default;
        //    Console.WriteLine($"Enter your Name:");
        //    name = Console.ReadLine();

        //    int age = default;
        //    Console.WriteLine($"Enter your Age:");
        //    age = Convert.ToInt32(Console.ReadLine());

        //    return new Person(name: name, age: age);
        //}

        //class Person {
        //    private string name;
        //    private int age;
            
        //    //public string Name {
        //    //    get { return name; }
        //    //    set { name = value; }
        //    //}
        //    //public int Age {
        //    //    get { return age; }
        //    //    set { age = value; }
        //    //}

        //    // same but using arrow functions:
        //    public string Name { get => name; set => name = value; }
        //    public int Age { get => age; set => age = value; }

        //    public Person() { // this empty constructor wouldn't work for structs

        //    }
        //    public Person(string name, int age) {
        //        Name = name;
        //        Age = age;
        //    }

        //    public override string ToString() {
        //        return $"Name: {Name}, Age: {Age}";
        //    }
            
        //}
        static void Main(string[] args) {




            //////////////////////////////
            //Person person = new Person("ahmed", 23);
            //Person person2 = new Person("ahmed", 23);



            //if (person.Equals(person2)) {
            //    Console.WriteLine("equal 1");
            //} else {
            //    Console.WriteLine("not equal 1");
            //}

            //if (person == person2) {
            //    Console.WriteLine("equal 2");
            //} else {
            //    Console.WriteLine("not equal 2");
            //}




                //////////////////////////////
                //Person person;

                //person = RegisterPerson();


                //Console.WriteLine($"New person's info \nName: {person.GetName()}  Age: {person.GetAge()}");














                //////////////////////////////
                //Console.Write("Enter a number: ");

                // //examples of exceptions
                // //System.OverflowException
                // //System.FormatException
                // try {
                //     int num = Convert.ToInt32(Console.ReadLine());
                // } catch (System.FormatException fe) {
                //     Console.WriteLine($"bad formating can't convert to int!: {fe.Message}");
                // } catch (System.OverflowException oe) { 
                //     Console.WriteLine($"you've entered a very big number!: {oe.Message}");
                // } catch (Exception e) {
                //     Console.WriteLine($"something went wrong!: {e.Message}");
                // }
















                //////////////////////////////
                //int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
                //int result = SumOfNumbers(numbers);


                //Console.WriteLine($"Final Sum is {SumOfNumbers(numbers)} (note: if sum equals -1 then numbers array is invalid array)");













                //////////////////////////////
                //Console.Write($"Please enter the Width: ");
                //double width = Convert.ToDouble(Console.ReadLine());

                //Console.WriteLine();

                //Console.Write($"Please enter the Height: ");
                //double height = Convert.ToDouble(Console.ReadLine());

                //Console.WriteLine($"Area = {CalcArea(width: width, height: height)}");





                //////////////////////////////
                //List<string> shoppingList = new List<string>() {
                //    "milk", "coffee"
                //};

                //Console.WriteLine($"the index of coffee: {IndexOf(shoppingList, "coffee")}"); 







                ////////////////////////////////
                //int result = Add(b: 1, a: 2); //cuz we named them we dont need to abid to the order
                //Console.WriteLine($"first result: {result}");

                //result = Add(2, 1);
                //Console.WriteLine($"second result: {result}");





                ////////////////////////////////
                //int num = 8, length = 7;
                //int[] partable = new int[length];

                //for (int i = 0; i < length; i++) {
                //    partable[i] = (i+1) * num;
                //    Console.Write($" {partable[i]}");
                //}


                ////////////////////////////////
                //List<Int32> oddList = new List<Int32>();
                //List<Int32> evenList = new List<Int32>();

                //for (Int32 i = 0; i < 20; i++) {
                //    if( (i & 1) == 1 )//odd
                //        oddList.Add(i);
                //    else 
                //        evenList.Add(i);
                //}

                //Console.WriteLine($"Odd List: ");
                //foreach (var odd in oddList) {
                //    Console.Write($" {odd}");
                //}

                //Console.WriteLine($"\nEven List:");
                //foreach (var even in evenList) {
                //    Console.Write($" {even}");
                //}



                ////////////////////////////////
                //Dictionary<int, string> dict = new Dictionary<int, string>();

                //dict.Add(1, "omar");
                //dict[2] = "ahmed";
                //dict[3] = "osama";

                //for (int i = 0; i < dict.Count; i++) {
                //    KeyValuePair<int, string> pair = dict.ElementAt(i);
                //    Console.WriteLine($"key,pair= {pair.Key} - {pair.Value}");
                //}

                //foreach (KeyValuePair<int, string> pair in dict) {
                //    Console.WriteLine($"key,pair= {pair.Key} - {pair.Value}");
                //}




                ////////////////////////////////

                ////List<int> numList = new List<int>() { 1, 2, 3 };
                //List<int> numList = new List<int>();

                //for (int i = 0; i < 3; i++) {
                //    Console.WriteLine($"enter a number{i+1}: ");
                //    var num = Console.ReadLine();
                //    numList.Add(Convert.ToInt32(num));
                //    Console.WriteLine($"current list size: {numList.Count}");
                //    Console.WriteLine($"current list capacity: {numList.Capacity}");
                //}


                //foreach (var item in numList) {
                //    Console.Write($"{item} ");
                //}


                ////////////////////////////////
                //int[] nums = new int[] { 1, 0, 3, 10, 6, 7, 8, 9 };

                //Array.Sort(nums);
                //foreach (int n in nums) {
                //    Console.Write($"{n} ");
                //}





                ////////////////////////////////
                //string pass = "";
                //string passAgain = "";

                //while (string.IsNullOrEmpty(passAgain) || string.IsNullOrEmpty(pass)) { 
                //    Console.Write("enter your password: ");
                //    pass = Console.ReadLine();
                //    Console.Write("enter your password again: ");
                //    passAgain = Console.ReadLine();
                //}

                //string isMatchString = pass == passAgain ? "Passwords match" : "Passwords do not match";
                //Console.WriteLine(isMatchString);





                ////////////////////////////////
                //Console.WriteLine("Please Input Your Message:");
                //string msg = Console.ReadLine();
                //for (int i = 0; i < msg.Length; i++) {
                //    Console.Write(msg[i]);
                //}
                //Console.WriteLine();
                //for (int i = msg.Length - 1; i >= 0; i--) {
                //    Console.Write(msg[i]);
                //}

                //foreach( char c in msg) {
                //    Console.Write(c);
                //}





                ////////////////////////////////
                //string msg = "test message";

                ////System.String is actually a char[] i.e.(character array) just with more extras
                ////Console.WriteLine(msg[0]);
                ////Console.WriteLine(msg[1]);

                //for (int i = 0; i < msg.Length; i++) {
                //    Console.Write(msg[i]);
                //    //System.Threading.Thread.Sleep(250);
                //    Thread.Sleep(250);
                //}

                //Console.WriteLine($"\n{msg.Contains("t")}");

                //char target = 't';
                //bool contains = false;
                //for (int i = 0; i < msg.Length; i++) {
                //    if (msg[i] == target) {
                //        contains = true;
                //        break;
                //    }
                //}
                //Console.WriteLine(contains);





















                ////////////////////////////////
                //string str = "hi";
                //string str2 = "hi";

                //if (str.Equals(str2)) {
                //    Console.WriteLine("equal strings!");
                //}else {
                //    Console.WriteLine("NOT equal strings!");
                //}

                ////same as equals but more strict (better to use .Equals)
                ////for strings they almost the same! but with different data types like object and string they differ
                //if (str == str2) {
                //    Console.WriteLine("equal strings!");
                //}else {
                //    Console.WriteLine("NOT equal strings!");
                //}



                ////////////////////////////////
                //string str = string.Empty;
                //string str2 = ""; //same!













                ////////////////////////////////

                //for (int i = 0; i < 100; i++) {
                //    string fizz = i % 3 == 0 ? "Fizz" : "";
                //    string buzz = i % 5 == 0 ? "Buzz" : "";
                //    Console.WriteLine(fizz == "" && buzz == "" ? Convert.ToString(i) : (fizz+buzz));
                //}


                ////////////////////////////////
                //Console.WriteLine($"choose a multiplication table from 1 - 12:");
                //string mul_table_choice = Console.ReadLine();

                //for (int i = 1; i <= 12; i++) {
                //    Console.WriteLine($"{i} x {mul_table_choice} = {i * Convert.ToInt32(mul_table_choice)}");
                //    //Console.WriteLine("{0} x {1} = {2}", i, mul_table_choice, i*Convert.ToInt32(mul_table_choice));
                //}






















                ////////////////////////////////
                //Console.WriteLine("Enter a number:");
                ////var num = Console.ReadLine();
                //string num = Console.ReadLine();

                //int val = Convert.ToInt32(num);
                //bool isOk = int.TryParse(num, out int parsedVal);

                //Console.WriteLine($"val after using convert class: {val} \nval after using try parse: {parsedVal}  did parse ok? {isOk}");
                ////////////////////////////////
                ////double num = 123 / 7D;
                //double num = 17.5714002D;
                //Console.WriteLine(string.Format("{0}", num));
                //Console.WriteLine(string.Format("{0:0.0}", num));
                //Console.WriteLine(string.Format("{0:0.00}", num));
                //Console.WriteLine(string.Format("{0:0.0}", num));
                //Console.WriteLine(string.Format("{0:0.####}", num)); // if not zeroes print whats after the point

                //Console.WriteLine( );

                //Console.WriteLine(num.ToString("C")); //format as currency
                //Console.WriteLine(num.ToString("C", CultureInfo.CurrentCulture)); //explicitly tell to use current region currency formatting
                //Console.WriteLine(num.ToString("C0")); //change floting point prec
                //Console.WriteLine(num.ToString("C1"));

                //Console.WriteLine( );

                ////use different culture to change formatting e.g.(united kingdom)
                //Console.WriteLine(num.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")));

                //Console.WriteLine("\nwhat if negative number? \n british format then USA format: ");
                //num = -17.5714002D;
                //Console.WriteLine(num.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")));
                //Console.WriteLine(num.ToString("C", CultureInfo.CreateSpecificCulture("en-us")));
                //Console.ReadLine();     



                ////////////////////////////////
                //Console.WriteLine("Enter you name:");
                //string name = Console.ReadLine();
                //Console.WriteLine(name);

                ////////////////////////////////
                //int first = 21;
                //int second = 22;
                //int remainder = first % second;
                //Console.WriteLine($"first remainder: {remainder}");
                //first = 50;
                //remainder = first % second;
                ////Console.WriteLine($"second remainder {remainder}");
                //Console.WriteLine("second remainder " + remainder);
                //Console.ReadLine();     


                //////////////////////////////
                //int a = 6;
                //int b = 5;
                //int mod = a % b;
                //Console.WriteLine($" a mod b = {mod}");




                //////////////////////////////////
                //var age = 5;
                //const int b = 5;
                //b = 6; //cant do that it's a constant






                //////////////////////////////////////////
                //bool isMale = true;
                //int age = 23;
                //Console.WriteLine($"age is {age}");
                //age++;
                //Console.WriteLine($"age is {age}");
                //age--; //age -=1   age = age - 1
                //Console.WriteLine($"age is {age}");
                //Console.WriteLine($"age: {age} divided by 2 {age/2}");

                ////similar to C++  you can sum  chars unicode 
                //char a = 'A';
                //Console.WriteLine($"char A + 1 = {a+1} after converting to char again {Convert.ToChar(a+1)}");

                //int i = 0;
                //Console.WriteLine(i++); //suffix sum
                //Console.WriteLine(++i); //prefix sum

                ///mod % 
                //Console.WriteLine(10%3); // 3*3 = 9 and 1 remainder


                ///////////////////////////////////////////////
                //string name = "john doe";
                //char oneChar = 'c';

                //Console.WriteLine($"my name is {name} char var value: {oneChar}");

                //string textAge = "23"
                //int age = Convert.ToInt32(textAge);

                /////////////////////////////////////////
                //long bigNumber = -900000000L;

                //int smallNumber = 900;

                //double neg = -55.2D;
                //double neg2 = -55.2;

                //float fl = 5.00000001F;

                //decimal money = 14.99M;

                //Console.WriteLine(bigNumber);
                //Console.WriteLine(smallNumber);

                //Console.WriteLine(int.MaxValue);
                //Console.WriteLine(int.MinValue);

                //Console.WriteLine(long.MaxValue);
                //Console.WriteLine(long.MinValue);

                //Console.WriteLine(double.MaxValue);
                //Console.WriteLine(double.MinValue);

                //Console.WriteLine(float.MaxValue);
                //Console.WriteLine(float.MinValue);

                //Console.WriteLine(decimal.MaxValue);
                //Console.WriteLine(decimal.MinValue);
                //////////////////////////////////////////


                //int x, y, z;
                //int x = 10, y = 20, z = 30;
                //int x = 10,
                //    y = 20,
                //    z = 30;








                Console.ReadLine();
        }
    }
}
