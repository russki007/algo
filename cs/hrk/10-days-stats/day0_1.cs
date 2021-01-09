#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using System.Text;
using static System.Int32;

namespace hrk {
    public class day0_1 {
        static int[] ReadAllInts(string s, int? max = null) => Array.ConvertAll(s.Split(' '), Parse);

#if (LOCAL_TEST)
        public static void MainTest(string[] args) {
#else
        public static void Main(string[] args) {
#endif            
            if (args.Length > 0) {
                Console.SetIn(File.OpenText(args[0]));
            }
            int n = Int32.Parse(Console.ReadLine());
            int[] arr = ReadAllInts(Console.ReadLine(), n);
            int sum = 0;
            //(int Cnt, int Val)[] h = new (int Cnt, int Val)[100_000];
            int[] h = new int[100_000];
            int[] hv = new int[100_000];
            Span<int> hs = stackalloc int[100_000];

            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++) {
                sum += arr[i];
                //h[arr[i]] = (h[arr[i]].Cnt + 1, arr[i]);
                h[arr[i]] += 1;
                hv[arr[i]] = arr[i];
            }
            (int Cnt, int Val) model = (0, 0);
            float mean = ((float)sum) / n;


            // float median = n % 2 == 0 ? (arr[n / 2 - 1] + arr[n / 2]) / (float)2 : arr[n / 2];
            float median = arr[n / 2];
            if ((n & 1) == 0) {
                median += arr[n / 2 - 1];
                median /= 2;
            }

            for (int i = 0; i < h.Length; i++) {
                //     if (h[i].Cnt > model.Cnt) {
                //         model = h[i];
                //     }
                if (h[i] > model.Cnt) {
                    model = (h[i], hv[i]);
                }
            }
            Console.WriteLine($"{mean:F1}");
            Console.WriteLine($"{median:F1}");
            Console.WriteLine($"{model.Val}");
        }
    }
}


