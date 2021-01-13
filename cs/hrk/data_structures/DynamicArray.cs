#define LOCAL_TEST
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StdIn = System.Console;

namespace hrk {
    public class DynamicArray {

        static int[] ReadInts() {
            string s = StdIn.ReadLine();
            return Array.ConvertAll(s.Split(), System.Int32.Parse);
        }

        public const int X = 1, Y = 2, T = 0;

        static void GetDynamicArray(int n, List<int[]> queries, Action<int> progress) {
            List<int>[] seqList = new List<int>[n];
            for (int i = 0; i < n; i++) seqList[i] = new List<int>();
            int last = 0;
            foreach (int[] q in queries) {
                int x = q[X], y = q[Y];
                int i = (x ^ last) % n;
                if (q[T] == 1) {
                    seqList[i].Add(y);
                    continue;
                }
                last = seqList[i][y % seqList[i].Count];
                progress(last);
            }
        }

        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }
            int[] n = ReadInts();
            List<int[]> queries = new List<int[]>();
            while (n[1]-- > 0) {
                queries.Add(ReadInts());
            }
            GetDynamicArray(n[0], queries, (a) => Console.WriteLine(a));
        }
#if !(LOCAL_TEST)
        public static void Main(string[] args) => MainTest(args);
#endif
    }
}

