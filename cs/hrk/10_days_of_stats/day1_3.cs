#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using StdIn = System.Console;

namespace hrk {
    public class day1_3 {

        static int[] ReadAllInts() {
            string s = StdIn.ReadLine();
            return Array.ConvertAll(s.Split(), System.Int32.Parse);
        }
        static int NextInt() {
            string s = StdIn.ReadLine();
            return Int32.Parse(s);
        }

        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }
            int n = NextInt();
            int[] x = ReadAllInts(), f = ReadAllInts();
            int[] s = new int[f.Sum()];
            for (int i = 0, k = 0; i < x.Length; i++) {
                for (int j = 0; j < f[i]; j++) {
                    s[k++] = x[i];
                }
            }
            Array.Sort(s);
            int hi = s.Length / 2;
            double q1 = Median(s, 0, hi), q3 = Median(s, hi + s.Length % 2, hi);
            Console.WriteLine($"{(q3 - q1):F1}");
        }

        static double Median(int[] arr, int start, int count) {
            double m = arr[start + count / 2];
            if (count % 2 == 0) {
                m += arr[start + count / 2 - 1];
                m /= 2d;
            }
            return m;
        }

#if !(LOCAL_TEST)
        public static void Main(string[] args) => MainTest(args);
#endif
    }
}

