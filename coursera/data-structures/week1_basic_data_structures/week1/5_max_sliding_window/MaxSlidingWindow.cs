using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace week1 {

    public class MaxSlidingWindow {
        
        private int[] seq;
        private Queue queue;
        private int p = 0;

        public MaxSlidingWindow(int m, int[] seq) {
            this.queue = new Queue(seq.Length);
            this.p = m;
            this.seq = seq;
            for (int i = 0; i < m; i++) {
                queue.Enqueue(seq[i]);
            }
        }

        public static void MainTest(string[] args) {
            int n = StdIn.ReadInt();
            int[] seq = new int [n];
            for (int i = 0; i < n; i++) {
                seq[i] = StdIn.ReadInt();
            }
            int m = StdIn.ReadInt();
           
            Queue q = new Queue(n);
            for (int i = 0; i < m; i++) {
                q.Enqueue(seq[i]);
            }
            Console.Write(q.Max());

            for (int i = m; i < n; i++) {
                q.Dequeue();
                q.Enqueue(seq[i]);
                Console.Write(" " + q.Max());
            }

            Console.WriteLine($"{n}");
            Console.WriteLine($"{seq.Aggregate("", (s, i) => s.Length > 0 ? $"{s},{i}" : i.ToString())}");
            Console.WriteLine($"{m}");
        }

        /// <summary>
        /// Returns true if the window has been moved by one
        /// </summary>
        /// <returns></returns>
        public bool MoveNext() {
            if (p < seq.Length) {
                queue.Dequeue();
                queue.Enqueue(seq[p]);
                p++;
                return true;
            }

            return false;
        }

        public int Max() => queue.Max();
    }

    public class Queue {
        
        public StackWithMax _stack1;
        public StackWithMax _stack2;

        public Queue(int capcity) {
            _stack1 = new StackWithMax(capcity);
            _stack2 = new StackWithMax(capcity);
        }
        public void Enqueue(int item) {
            _stack1.Push(item);
        }

        public int Dequeue() {
            if (_stack1.Count == 0 && _stack2.Count == 0) {
                throw new InvalidOperationException();
            }

            if (_stack2.Count == 0) {
                while (_stack1.Count > 0) {
                    _stack2.Push(_stack1.Pop());
                }
            }

            return _stack2.Pop();
        }

        public int Max() {
            if (_stack1.Count == 0 && _stack2.Count == 0) {
                throw new InvalidOperationException();
            }

            if (_stack1.Count !=  0 && _stack2.Count != 0) return Math.Max(_stack1.Max(), _stack2.Max());
            if (_stack1.Count != 0) return _stack1.Max();
           
            return _stack2.Max();
        }
    }
}