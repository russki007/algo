using System;
using System.IO;
using System.Linq;
using StdIn = System.Console;

namespace hrk {
    public class SolutionName {
        static int[] ReadAllInts(string s, int? max = null) => Array.ConvertAll(s.Split(' '), System.Int32.Parse);
        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }
            Console.WriteLine("Template");
        }
    }
}

