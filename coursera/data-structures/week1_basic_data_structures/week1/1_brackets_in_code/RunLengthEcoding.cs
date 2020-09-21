using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;

// [0] = 'a' 1
// [1] = 'b' ab 1
// [2] = 'b' abb 2
// [3] = 'b' abbb 3
// [4] = 'c' abbbc 1
// [5] = 'c' abbbcc 2
// [6] = 'd' abbbccd 1 
// [7] = 'd' abbbccdd 2
// [8] = 'c' abbbccddc 1
// [9] = 'c' abbbccddcc 2
// [9] = 'c' abbbccddccc 3


/// ABABAA
public class RunLengthEncoding {

    public static void MainTest(String[] args) {
        //string test1 = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWBWWWWWWWWWWWWWW";
        //Console.WriteLine(Encode(test1));

        string test2 = "ABBBCCDDCC";
        Console.WriteLine(Encode(test2));

        string test3 = "ABBBCCDDCCC";
        Console.WriteLine(Encode(test3));
        var ans = Solve(test3, k: 3);
        Console.Write($"{test3}->{ans.Result}:{ans.Encoded}");


        string test4 = "AAAAAAAAAAABXXAAAAAAAAAA";
        Console.WriteLine(Encode(test4));
        ans = Solve(test4, k: 3);
        Console.Write($"{test4}->{ans.Result}:{ans.Encoded}");
    }

    struct Entry {
        public int n;
        public string S;
        public string P;
    }

    struct Block {
        public Entry[] Entries;
        public string S;
        public string P;
    }

    public static (int Stat, string Str) Solve3(string str, int k) {

        int Min(string[] s, string[] p) {
            return 1;
        }

        Block[] block = new Block[str.Length];
        for (int i = 0; i < str.Length / k; i++) {
            block[i].Entries = new Entry[k];
            for (int j = 0; j < k; j++) {
                int index = i * k + j;
                // Suf Pref
                // C    // CB
                // C2   // B
                // C2B  

                // Suf Pref
                // C    // CB
                // C2   // B
                // C2B  
                block[i].S = block[i].Entries[j].S = Encode2(str, index, index + j);
                block[i].Entries[j].P = Encode2(str, index + j, index + k);
                
            }
        }

        for (int i = 0; i < str.Length / k; i++) {
            // X 1 2
            // 0 X 2
            // 0 1 X
            int left = i, right = i + 1;
            
            for (int j = 1; j < k; j++) {
                int leftSuffix = j, rightPrefix = j - 1;
                //block[i].Entries[leftSuffix], 
            }
        }
        
        return (1, "");
    }

    public static string Encode2(string str, int start, int end) {
        string encoded = "";
        for (int i = 0; i < str.Length; i++) {
            int runLength = 1;
            for (int j = i + 1; j < str.Length && str[i] == str[j]; j++, i++) {
                runLength++;
            }

            if (runLength > 1) {
                encoded += runLength;
            }

            encoded += str[i];
        }

        return encoded;
    }

   

    public static (int Result, string Encoded) Solve(string str, int k) {
        int min = str.Length;
        string minEncoded = "";
        Queue<(int Pos, char Ch)> queue = new Queue<(int Pos, char Ch)>();
        for (int i = 0; i < str.Length - k; i++) {
            for (int j = i + queue.Count; queue.Count < k && j < str.Length; j++) {
                queue.Enqueue((j, str[j]));
            }

            var start = queue.Peek();
            string prefix = str.Substring(0, start.Pos), suffix = str.Substring(i + k);
            string encoded = Encode(prefix + suffix);
            if (encoded.Length < min) {
                minEncoded = encoded;
                min = encoded.Length;
            }

            queue.Dequeue();
        }

        return (min, minEncoded);
    }


    public static string Encode(string str) {
        string encoded = "";
        for (int i = 0; i < str.Length; i++) {
            int runLength = 1;
            for (int j = i + 1; j < str.Length && str[i] == str[j]; j++, i++) {
                runLength++;
            }

            if (runLength > 1) {
                encoded += runLength;
            }

            encoded += str[i];
        }

        return encoded;
    }
}