using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace week1.tests {

    public class StackWithMaxTests {

        [Theory]
        [InlineData("push 2;push 1;max;pop;max;", "2 2")]
        [InlineData("push 1;max;max;", "1 1")]
        public void Push(string commands, string output) { 
            var cmds = commands.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(s => new Command(s)).ToArray();
            var stack = new StackWithMax();
            int[] expected = Array.ConvertAll(output.Split(' '), Int32.Parse);
            List<int> actual = new List<int>();
            foreach (var cmd in cmds) {
                switch (cmd.Op) {
                    case "push": stack.Push(cmd.Arg);
                        break;
                    case "pop":
                        stack.Pop();
                        break;
                    case "max": actual.Add(stack.Max());
                        break;
                }
            }
            Assert.Equal(expected, actual);
            Assert.Throws<NotEqualException>(() => Assert.NotEqual(expected, actual));
        }
    }

    public class Command {
        public Command (string line) {
            string[] parts = line.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            Op = parts[0];
            if (parts.Length > 1) {
                Arg = int.Parse(parts[1]);
            }
        }
        public string Op { get; set; }
        public int Arg { get; set; }
    }
}

