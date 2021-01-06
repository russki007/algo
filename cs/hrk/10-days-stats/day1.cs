using System;
using static System.Int32;

namespace hrk {
    public class day1 {
        static int[] ReadAllInts(string s, int? max = null) => Array.ConvertAll(s.Split(' ', max ?? Int32.MaxValue, StringSplitOptions.RemoveEmptyEntries), Parse);
        public static void MainTest(string[] args) {
            int n = Int32.Parse(Console.ReadLine());
            int[] arr = ReadAllInts(Console.ReadLine(), n);
            int sum = 0;
            int model = 0;
            int prev = -1;
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++) {
                sum += arr[i];
                if (prev == arr[i] && model < prev) {
                    model = prev;
                }
                else prev = arr[i];
            }
            float mean = ((float)sum) / n;
            float median = n % 2 == 0 ? (arr[n / 2 - 1] + arr[n / 2]) / (float)2 : arr[n / 2];
            if (model == 0 && n > 0) model = arr[0];

            Console.WriteLine($"{mean:F1}");
            Console.WriteLine($"{median:F1}");
            Console.WriteLine($"{model}");
            Console.ReadKey();
        }
    }
}


