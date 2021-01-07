#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using StdIn = System.Console;

// Standard Deviation
// [1,2,3,4,5] - M=>3
// What is the average distance to the mean? - [2, 1, 0, 1, 2], individual distances to the mean. 6/5=> 1.2
// Variance - average square distance to the mean.

namespace hrk {
    public class day1_2 {
        static int[] ReadAllInts(string s, int? max = null) => Array.ConvertAll(s.Split(' '), System.Int32.Parse);
        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }
            int n = Int32.Parse(StdIn.ReadLine());
            double r = StdEv(ReadAllInts(StdIn.ReadLine()));
            Console.WriteLine($"{r:F1}");
        }

        static double StdEv(int[] args) {
            var avg = args.Sum() / (float)args.Length;
            return args.Aggregate(0d, (s, n) => s + (n - avg) * (n - avg), r => Math.Sqrt(r / args.Length));
        }

#if !(LOCAL_TEST)
        public static void Main(string[] args) => MainTest(args);
#endif
    }
}

