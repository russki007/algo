#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using StdIn = System.Console;

// Basic probability
// Sample space - a well-defined set of possible outcomes; all the possible outcomes of an experiment;
// Experiment - repeatable procedure with a set of possible results;
// Event - a set of outcomes of an experiment; one or more outcomes of an experiment;
// Compound event - combination of 2 or mode simple events;
// Any probability, is a number between 0 and 1;
// Sample Point: just one of the possible outcomes;
// Probability of a compound event 
// Mutually Exclusive Event: Event that can't happen at the same time, have no events in common;
// For Mutually Exclusive Events, the probability of A or B is the sum of the individual probabilities  P(A or B) = P(A) + P(B)

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
            int[] d1 = new int[] { 1, 2, 3, 4, 5, 6 }, d2 = new int[] { 1, 2, 3, 4, 5, 6 };
            int k = 1;
            for (int i = 0; i < d1.Length; i++) {
                for (int j = 0; j < d2.Length; j++) {
                    if ((d1[i]) % 2 == 1 && (d2[j] % 2 == 1)) {
                        Console.WriteLine($"{k++} : [{d1[i]}, {d2[j]}]");

                    }
                }
            }
            //Console.WriteLine("{k}/36");
        }
#if !(LOCAL_TEST)
        public static void Main(string[] args) => MainTest(args);
#endif
    }
}
