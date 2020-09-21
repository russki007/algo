using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace week1 {

    public class StackWithMax : Stack<int> {

        private readonly Stack<int>  _max = new Stack<int>();

        public StackWithMax() {
           
        }

        public StackWithMax(int capacity) : base(capacity) {
            _max = new Stack<int>(capacity);
        }

        public new void Push(int item) {
            if (_max.Count == 0 || _max.Peek() <= item) {
                _max.Push(item);
            }
            base.Push(item);
        }

        public new int Pop() {
            int item = base.Pop();
            if (_max.Peek() == item) {
                _max.Pop();
            }
            return item;
        }

        public int Max() {
            if (_max.Count == 0) throw new InvalidOperationException();
            return _max.Peek();
        }

        //TestFile("01");
        //TestFile("02");
        public static void MainTest(string[] args) {
            int q = StdIn.ReadInt();
            StackWithMax stack = new StackWithMax();
            for (int i = 0; i < q; i++) {
                string op = StdIn.ReadString();
                if (op.Equals("push")) stack.Push(StdIn.ReadInt());
                if (op.Equals("pop")) stack.Pop();
                if (op.Equals("max")) Console.WriteLine(stack.Max());
            }
        }
    }
}
