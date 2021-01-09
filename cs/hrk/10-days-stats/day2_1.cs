#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using StdIn = System.Console;

namespace hrk {
    public class day2_1 {

        static int[] ReadAllInts() {
            string s = StdIn.ReadLine();
            return Array.ConvertAll(s.Split(), System.Int32.Parse);
        }

        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }
            Console.WriteLine("Template");
        }
#if !(LOCAL_TEST)
        public static void Main(string[] args) => MainTest(args);
#endif
    }
}

