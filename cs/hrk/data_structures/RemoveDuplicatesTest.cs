#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using System.Text;
using StdIn = System.Console;

// Delete duplicate-value nodes from a sorted linked list
// https://www.hackerrank.com/challenges/delete-duplicate-value-nodes-from-a-sorted-linked-list/problem

namespace hrk {
    public class RemoveDuplicatesTest {
        static int[] ReadAllInts() {
            string s = StdIn.ReadLine();
            return Array.ConvertAll(s.Split(), System.Int32.Parse);
        }
        static int NextInt() => Int32.Parse(StdIn.ReadLine());

        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }
            int t = NextInt(), n = NextInt();
            SinglyLinkedList list = new SinglyLinkedList();
            while (n-- > 0) {
                list.InsertNode(NextInt());
            }

            StringBuilder sb = new StringBuilder();
            var cur = RemoveDuplicates(list.head);
            while (cur != null) {
                sb.Append(sb.Length > 0 ? $" {cur.data}" : cur.data);
                cur = cur.next;
            }
            Console.WriteLine(sb);
        }

        static SinglyLinkedListNode RemoveDuplicates(SinglyLinkedListNode head) {
            SinglyLinkedListNode cur = head, prev = null;
            if (head == null) return null;
            while (cur.next != null) {
                if (cur.next.data == cur.data) cur.next = cur.next.next;
                else cur = cur.next;
            }
            return head;
        }
    }

    class SinglyLinkedListNode {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData) {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList() {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData) {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null) {
                this.head = node;
            }
            else {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    /*
    public class SinglyLinkedList {
        internal SinglyLinkedListNode Head { get; set; }
        public SinglyLinkedList() {
        }
        public void Add(int value) {
            var node = new SinglyLinkedListNode(value);
            SinglyLinkedListNode cur = this.Head, prev = this.Head;
            if (cur == null) this.Head = node;
            else {
                while (cur != null && cur.Data < value) {
                    prev = cur;
                    cur = cur.Next;
                }
                if (cur == null) {
                    prev.Next = node;
                }
                else {
                    if (cur == Head) {
                        Head = node;
                        node.Next = cur;
                    }
                    else {
                        node.Next = cur;
                        prev.Next = node;
                    }
                }
            }
        }
    }*/


#if !(LOCAL_TEST)
        public static void Main(string[] args) => MainTest(args);
#endif
}


