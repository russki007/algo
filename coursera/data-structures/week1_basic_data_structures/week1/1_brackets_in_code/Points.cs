using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;



public class Points {
    public void Main(string[] args) {
        string S = "ABDCA";
        int[] X = new int[] { 2, -1, -4, -3, 3 };
        int[] Y = new int[] { 2, -2, 4, 1, -3 };
        // resut 3;
        int actual = Points.Solve(S, X, Y);
        Debug.Assert(3 == actual, "Should be 3");


        S = "ABB";
        X = new int[] { 1, -2, -2 };
        Y = new int[] { 1, -2, 2 };
        actual = Points.Solve(S, X, Y);
        Debug.Assert(1 == actual, "Should be 1");

        S = "CCD";
        X = new int[] { 1, -1, 2 };
        Y = new int[] { 1, -1, -2 };
        actual = Points.Solve(S, X, Y);
        Debug.Assert(0 == actual, "Should be 0");
    }

    public struct Point {
        public char Tag;
        public int Dist;
        public Point(char tag, int dist) => (Tag, Dist) = (tag, dist);
    }
    public static int Solve(string s, int[] x, int[] y) {
        Dictionary<char, Point> set = new Dictionary<char, Point>();
        Point[] points = new Point[s.Length];
        for (int i = 0; i < s.Length; i++) {
            points[i] = new Point(s[i], (int)Math.Sqrt(x[i] * x[i] + y[i] * y[i]));
        }
        Array.Sort(points, (a, b) => a.Dist - b.Dist);
        for (int i = 0; i < points.Length; i++) {
            char tag = points[i].Tag;
            if (!set.ContainsKey(tag)) {
                int j = i + 1;
                if (j < points.Length && points[j].Tag == tag && points[j].Dist == points[i].Dist) {
                    break;
                }
                set.Add(tag, points[i]);
            } else {
                break;
            }
        }
        return set.Count;
    }
}