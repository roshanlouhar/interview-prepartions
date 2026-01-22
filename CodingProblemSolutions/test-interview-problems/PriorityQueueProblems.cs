using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_interview_problems
{
    public class PriorityQueueProblems
    {
        public PriorityQueueProblems()
        {
            Console.WriteLine("Running Priority Queue Problems...");
            Run();
            Console.WriteLine("Finished Priority Queue Problems.");
        }
        public void Run()
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            int start = 0;
            int priority = 9;
            while (start < 10 && priority > 0)
            {
                pq.Enqueue(1, priority--);
            }

            Console.WriteLine("--------------------------------");
            start = 0;
            // print before 
            foreach (var item in pq.UnorderedItems)
            {
                Console.WriteLine($"Item: {item.Element}, Priority: {item.Priority}");
            }
            Console.WriteLine("--------------------------------");

            pq.Enqueue(1, 5);
            var deqItem = pq.Dequeue();
            Console.WriteLine($"---------{deqItem}-----------");

            // print after 
            foreach (var item in pq.UnorderedItems)
            {
                Console.WriteLine($"Item: {item.Element}, Priority: {item.Priority}");
            }
            Console.WriteLine("--------------------------------");
            Console.ReadKey();

        }
    }
}
