using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace week1 {

    public static class StdIn {
        private static char Space = ' ';
        private static TextInput Input;
     
        static StdIn() {
            Input = new TextInput(new StreamReader(Console.OpenStandardInput(), Encoding.UTF8));
        }

        public static int[] ReadAllInts() {
            IList<int> ints = new List<int>();
            while (!Input.IsEmpty()) ints.Add(ReadInt());
            return ints.ToArray();
        }

        public static string ReadString() {
            return Input.Next();
        }

        public static int ReadInt() {
            return int.Parse(Input.Next());
        }
    }



    public class TextInput {
        private TextReader _reader;
        private string _buffer = "";

        public TextInput(string file) : this(File.OpenText(file)) {

        }

        public static TextInput Open(string file) => new TextInput(file);
      
        public TextInput(TextReader reader) {
            this._reader = reader;
        }

        public bool IsEmpty() {
            if (string.IsNullOrEmpty(_buffer)) {
                string line = _reader.ReadLine();
                if (string.IsNullOrEmpty(line)) {
                    return true;
                }

                _buffer += line;
            }

            return false;
        }

        public string Next() {
            if (IsEmpty()) throw new InvalidOperationException();
            var match = Regex.Match(_buffer, @"\s*\S+\s*", RegexOptions.Compiled);
            _buffer = _buffer.Substring(match.Value.Length);
            return match.Value.Trim();
        }

        public class StringTokenizer {

            private const String WHITE_SPACE = @"^\s*$";
            private string[] _tokens;
            private int _index = 0;

            public StringTokenizer(string str) {
                _tokens = Tokenize(str).ToArray();
                _index = 0;
            }

            public IEnumerable<string> Tokenize(string str) {
                foreach (var s in Regex.Split(str, @"\s*").Where(token => !Regex.IsMatch(token, WHITE_SPACE)))
                    yield return s;
                //yield return new String(new[] {'\0'});
            }

            internal bool HasNext() {
                if (_index >= _tokens.Length) return false;
                return true;
            }

            public string NextToken() {
                string token = _tokens[_index];
                _index++;
                return token;
            }
        }

        /*
        class StringTokenizer : IEnumerable<string> {

            private string _str;

            public StringTokenizer(string str) {
                this._str = str;
            }

            public Enumerator GetEnumerator() => new Enumerator(_str);

            IEnumerator<string> IEnumerable<string>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            internal class Enumerator : IEnumerator
            {
                private string _value;
                private int _index;

                public Enumerator(string value)
                {
                    this._value = value;
                    this._index = 0;
                }

                public object Current => throw new NotImplementedException();

                public bool MoveNext()
                {
                    if (_value == null || _index > _value.Length) {
                        return false;
                    }
                    
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }
            }
        }
        */

    }
}