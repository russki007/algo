#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using StdIn = System.Console;

// Weigted mean - take datapoints and multiply by their weight and div by the total weight
namespace hrk {
    public class day0_2 {
        static int[] ReadAllInts(string s, int? max = null) => Array.ConvertAll(s.Split(' '), System.Int32.Parse);
        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }
            int n = Int32.Parse(StdIn.ReadLine());
            int[] s = ReadAllInts(StdIn.ReadLine(), n), w = ReadAllInts(StdIn.ReadLine(), n);
            float wm = 0;
            float wt = 0;
            for (int i = 0; i < n; i++) {
                wm += s[i] * w[i];
                wt += w[i];
            }
            Console.WriteLine($"{wm / wt:F1}");
        }

#if !(LOCAL_TEST)
        public static void Main(string[] args) {
            MainTest(args);
        }
#endif
    }
}

