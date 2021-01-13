#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using StdIn = System.Console;

// Quartiles and quartiles range
// Quartiles - each four equal groups into wich a population of results can be divided
// IQR - inter quartile range
// The maximum difference in test scores for the middle of 50% of the data is 29.5 points.

namespace hrk {

    public class Quartile {
        public uint Start { get; set; }
        public Quartile(int start, int count) { }
    }

    public class day1_1 {
        static int[] ReadAllInts(bool sort = true) {
            //var arr = Array.ConvertAll(StdIn.ReadLine().Split(' '), System.Int32.Parse);
            var arr = StdIn.ReadLine().Split(' ', ',').Select(int.Parse).ToArray();
            if (sort) Array.Sort(arr);
            return arr;
        }

        static int ReadInt() => Int32.Parse(StdIn.ReadLine());

        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }

            ReadInt();
            int[] arr = ReadAllInts();
            int n = arr.Length / 2;
            double q1 = Median(arr, 0, n), q2 = Median(arr, 0, arr.Length), q3 = Median(arr, n + arr.Length % 2, n);
            Console.WriteLine("{0:#.##}\n{1:#.##}\n{2:#.##}", q1, q2, q3);
        }

        static float Median(int[] arr, int start, int count) {
            float m = arr[start + count / 2];
            if (count % 2 == 0) {
                m += arr[start + count / 2 - 1];
                m /= 2;
            }

            return m;
        }

#if !(LOCAL_TEST)
        public static void Main(string[] args) => MainTest(args);
#endif
    }
}

