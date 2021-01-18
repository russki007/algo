#define LOCAL_TEST
using System;
using System.IO;
using System.Linq;
using StdIn = System.Console;

namespace hrk {


    // Class
    class DoublyLinkedListNode {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData) {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    // Class
    class DoublyLinkedList {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList() {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData) {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null) {
                this.head = node;
            }
            else {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    static class ListEx {
        public static DoublyLinkedListNode SortedInsert(this DoublyLinkedListNode head, int data) {
            var newNode = new DoublyLinkedListNode(data);

            if (head == null) return newNode;
            if (data < head.data) { // Insert new node before head
                newNode.next = head;
                head.prev = newNode;
                return newNode;
            }
            else {
                DoublyLinkedListNode cur = head, prev = null;
                while (cur != null && cur.data < data) {
                    prev = cur;
                    cur = cur.next;
                }
                if (cur == null) {
                    prev.next = newNode;
                    newNode.prev = prev;
                }
                else {
                    newNode.next = cur;
                    newNode.prev = cur.prev;
                    cur.prev.next = newNode;
                    cur.prev = newNode;
                }
            }
            return head;
        }

        public static void PrintDoublyLinkedList(this DoublyLinkedList list, string sep, TextWriter textWriter) {
            var node = list.head;
            while (node != null) {
                textWriter.Write(node.data);
                node = node.next;
                if (node != null) {
                    textWriter.Write(sep);
                }
            }
        }
    }

    public class InsertDoublyLinkedListNodeTest {

        static int[] ReadAllInts() {
            string s = StdIn.ReadLine();
            return Array.ConvertAll(s.Split(), System.Int32.Parse);
        }

        static int NextInt() => Int32.Parse(StdIn.ReadLine());

        public static void MainTest(string[] args) {
            if (args.Length > 0) {
                StdIn.SetIn(File.OpenText(args[0]));
            }
            int t = NextInt();
            while (t-- > 0) {
                int n = NextInt();
                var list = new DoublyLinkedList();
                while (n-- > 0) {
                    list.InsertNode(NextInt());
                }
                list.head.SortedInsert(NextInt());
                list.PrintDoublyLinkedList(" ", Console.Out);
            }
        }
#if !(LOCAL_TEST)
        public static void Main(string[] args) => MainTest(args);
#endif

    }
}

