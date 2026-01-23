using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_interview_problems
{
    public class AgodaInterviewQuestions
    {
        public AgodaInterviewQuestions()
        {
            Console.WriteLine("Running Agoda Interview Questions...");
            Run();
            Console.WriteLine("Finished Agoda Interview Questions.");
        }
        public void Run()
        {
            // Implement your Agoda interview questions here
            Console.WriteLine("Agoda Interview Questions Placeholder");
            customReverse();
        }

        public List<int> reverse(List<int> list)
        {
            // O(n) time complexity
            List<int> reversedList = new List<int>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                reversedList.Add(list[i]);
            }

            // o(n/2) time complexity
            int left = 0;
            int right = list.Count - 1;
            while (left < right)
            {
                int temp = list[left];
                list[left] = list[right];
                list[right] = temp;
                left++;
                right--;
            }

            return reversedList;
        }

        public void customReverse()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            // print the original list
            Console.WriteLine("Original List: " + string.Join(", ", list));

            // reverse the list using collection class methods only
            collection<int> coll = new collection<int>(list);
            collection<int> reversedColl = new collection<int>();
            while (!coll.isEmpty())
            {
                reversedColl = reversedColl.append(coll.last());
                coll.dropLast();
            }
            //print the reversed collection
            Console.WriteLine("Reversed List: " + reversedColl.ToString());
        }
    }

    public class collection<T>
    {
        private List<T> items;
        public collection()
        {
            items = new List<T>();
        }

        public collection(List<T> initialItems)
        {
            items = new List<T>(initialItems);
        }

        public bool isEmpty()
        {
            return items.Count == 0;
        }

        public T first()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Collection is empty");
            }
            return items[0];
        }

        public T last()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Collection is empty");
            }
            return items[items.Count - 1];
        }

        public void dropFirst()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Collection is empty");
            }
            items.RemoveAt(0);
        }

        public void dropLast()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Collection is empty");
            }
            items.RemoveAt(items.Count - 1);
        }

        public collection<T> append(T item)
        {
            collection<T> newCollection = new collection<T>(items);
            newCollection.items.Add(item);
            return newCollection;
        }

        public string ToString()
        {
            return "[" + string.Join(", ", items) + "]";
        }
    }
}
