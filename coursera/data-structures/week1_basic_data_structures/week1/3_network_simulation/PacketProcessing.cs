using System;
using System.Collections.Generic;

namespace week1 {
    public struct Buffer {
        private int _size;
        private Queue<int> _queue;

        public Buffer(int size) {
            _size = size;
            _queue = new Queue<int>();
        }


        public (bool Dropped, int StartTime) Process((int TimeOfArrival, int ProcessingTime) request) {
            return (true, 1);
        }
    }

    public class PacketProcessing {

        public static void MainTest(string[] args) {
            Console.WriteLine($"Running {nameof(PacketProcessing)}");
            int size = StdIn.ReadInt();
            Buffer buffer = new Buffer(size);
            var requests = ReadQueries();
            foreach (var response in ProcessRequests(buffer, requests)) {
                Console.WriteLine(response.Dropped ? -1 : response.StartTime);
            }

            IEnumerable<(int TimeOfArrival, int ProcessingTime)> ReadQueries() {
                int n = StdIn.ReadInt();
                for (int i = 0; i < n; i++) {
                    yield return (StdIn.ReadInt(), StdIn.ReadInt());
                }
            }

            IEnumerable<(bool Dropped, int StartTime)> ProcessRequests(Buffer buffer,
                IEnumerable<(int TimeOfArrival, int ProcessingTime)> requests) {
                foreach (var request in requests) {
                    yield return buffer.Process(request);
                }
            }
        }
    }
}