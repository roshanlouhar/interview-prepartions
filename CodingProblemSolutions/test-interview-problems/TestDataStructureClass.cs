using System;
using System.Collections;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_interview_problems
{
    public class TestDataStructureClass
    {
        public static void TestDataStructureinCsharp()
        {
            // initialize frozen set and assign values
            FrozenSet<int> emptyFrozenSet = FrozenSet<int>.Empty;
            FrozenSet<int> emptyFrozenSet2 = FrozenSet.ToFrozenSet(new int[] { });
            // initialize frozen set with sample list values
            List<int> sampleList = new List<int> { 1, 2, 3 };
            FrozenSet<int> frozenSet = FrozenSet.ToFrozenSet(sampleList);
            frozenSet.Contains(2);
            
            // heap
            SortedSet<int> heap = new SortedSet<int>();
            heap.Add(3);
            heap.Add(1);

            // heap implementation using PriorityQueue
            PriorityQueue<int, int> priorityQueueHeap = new PriorityQueue<int, int>();
            priorityQueueHeap.Enqueue(3, 3);
            priorityQueueHeap.Enqueue(1, 1);
            var minHeapValue = priorityQueueHeap.Dequeue();
            heap.Clear();
            heap.Add(minHeapValue);
            heap.Add(1);

            // hashset
            HashSet<int> hashSet = new HashSet<int>();
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Remove(1);
            hashSet.Remove(3);

            // hash table
            Hashtable hashtable = new Hashtable();
            hashtable["one"] = 1;
            hashtable["two"] = 2;
            hashtable.Remove("one");
            hashtable.Remove("three");

            // sets
            SortedSet<int> set = new SortedSet<int>();
            set.Add(1);
            set.Add(2);
            set.Remove(1);
            set.Remove(3);
            var values = set.ToArray();
            var min = set.Min;
            var max = set.Max;

            // 

            // stack
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            var value = stack.Pop();

            // queue
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            var dequeuedValue = queue.Dequeue();

            // priority queue
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            priorityQueue.Enqueue(1, 2); // value 1 with priority 2
            priorityQueue.Enqueue(2, 1); // value 2 with priority 1
            var highestPriorityValue = priorityQueue.Dequeue(); // should return 2

            // SortedSet
            SortedSet<int> sortedSet = new SortedSet<int>() { 3, 1, 2 };
            sortedSet.Add(4);
            sortedSet.Remove(2);
            sortedSet.Add(3);
            sortedSet.Remove(4);
            sortedSet.Add(5);
            sortedSet.Remove(6);
            sortedSet.Add(7);
            sortedSet.Remove(8);
            //int min = sortedSet.Min;
            //int max = sortedSet.Max;

            // LinkedList
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.Remove(1);
            linkedList.AddLast(3);
            linkedList.Remove(2);
            linkedList.AddLast(4);
            linkedList.Remove(5);
            linkedList.AddLast(6);
            linkedList.Remove(7);
               
            // Queue using LinkedList
            LinkedList<int> queueLinkedList = new LinkedList<int>();
            queueLinkedList.AddLast(1);
            queueLinkedList.AddLast(2);
            var dequeuedLinkedListValue = queueLinkedList.First.Value;
            queueLinkedList.RemoveFirst();
            queueLinkedList.RemoveLast();

            // array
            int[] array = new int[] { 1, 2, 3 };
            Array.Resize(ref array, 5);
            array[3] = 4;
            // sort array
            Array.Sort(array);

            // Stack using LinkedList
            LinkedList<int> stackLinkedList = new LinkedList<int>();
            stackLinkedList.AddLast(1);
            stackLinkedList.AddLast(2);
            var poppedValue = stackLinkedList.Last.Value;
            stackLinkedList.RemoveLast();
            stackLinkedList.RemoveFirst();

            // dictionary
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary["one"] = 1;
            dictionary["two"] = 2;
            dictionary.Remove("one");
            dictionary.Remove("two");

            // Tuple
            var tuple = Tuple.Create(1, "one");

            // KeyValuePair
            KeyValuePair<string, int> kvp = new KeyValuePair<string, int>("one", 1);

            // LinkedListNode
            LinkedListNode<int> node = new LinkedListNode<int>(1);
            node.Value = 1;

            // string operations
            string str = "hello";
            str = str.ToUpper();
            str = str.ToLower();

            // string to char array
            char[] charArray = str.ToCharArray();

            // StringBuilder
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello");
            sb.Append(" World");
            string result = sb.ToString();

            // List
            List<int> list = new List<int>() { 1, 2, 3 };
            list.Add(4);
            list.Remove(2);
            // Dictionary
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict["one"] = 1;
            dict["two"] = 2;
            dict.Remove("one");
            // HashSet
            //HashSet<int> set = new HashSet<int>() { 1, 2, 3 };
            //set.Add(4);
            //set.Remove(2);
        }

        public static void TestControlFlowinCsharp()
        {
            int x = 10;
            int y = 20;
            // if-else
            if (x < y)
            {
                Console.WriteLine("x is less than y");
            }
            else if (x > y)
            {
                Console.WriteLine("x is greater than y");
            }
            else
            {
                Console.WriteLine("x is equal to y");
            }
            // switch
            switch (x)
            {
                case 10:
                    Console.WriteLine("x is 10");
                    break;
                case 20:
                    Console.WriteLine("x is 20");
                    break;
                default:
                    Console.WriteLine("x is neither 10 nor 20");
                    break;
            }
            // for loop
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"For Loop iteration: {i}");
            }
            // foreach loop
            int[] arr = { 1, 2, 3, 4, 5 };
            foreach (var item in arr)
            {
                Console.WriteLine($"Foreach Loop item: {item}");
            }
            // while loop
            int count = 0;
            while (count < 5)
            {
                Console.WriteLine($"While Loop count: {count}");
                count++;
            }
            // do-while loop
            int doCount = 0;
            do
            {
                Console.WriteLine($"Do-While Loop count: {doCount}");
                doCount++;
            } while (doCount < 5);
        }

        public static void TestBinaryTreeOperations()
        {

            // Create a simple binary tree
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            // In-order traversal
            void InOrderTraversal(TreeNode node)
            {
                if (node == null) return;
                InOrderTraversal(node.Left);
                Console.WriteLine(node.Value);
                InOrderTraversal(node.Right);
            }
            // Perform in-order traversal
            InOrderTraversal(root);
        }

        public static void TestGraphOperations()
        {
            // Representing a graph using adjacency list
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            void AddEdge(int u, int v)
            {
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();
                graph[u].Add(v);
                // For undirected graph, add the reverse edge
                if (!graph.ContainsKey(v))
                    graph[v] = new List<int>();
                graph[v].Add(u);
            }
            // Adding edges
            AddEdge(1, 2);
            AddEdge(1, 3);
            AddEdge(2, 4);
            AddEdge(3, 4);
            // Display the graph
            foreach (var node in graph)
            {
                Console.Write($"{node.Key}: ");
                foreach (var neighbor in node.Value)
                {
                    Console.Write($"{neighbor} ");
                }
                Console.WriteLine();
            }

            // test the DFS traversal
            HashSet<int> visited = new HashSet<int>();
            void DFS(int node)
            {
                if (visited.Contains(node)) return;
                visited.Add(node);
                Console.WriteLine(node);
                foreach (var neighbor in graph[node])
                {
                    DFS(neighbor);
                }
            }

            // test the BFS traversal
            void BFS(int start)
            {
                Queue<int> queue = new Queue<int>();
                HashSet<int> visitedBFS = new HashSet<int>();
                queue.Enqueue(start);
                visitedBFS.Add(start);
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    Console.WriteLine(node);
                    foreach (var neighbor in graph[node])
                    {
                        if (!visitedBFS.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            visitedBFS.Add(neighbor);
                        }
                    }
                }
            }
        }

        public static void TestDepthFirstSearchOnGraph()
        {
            // Representing a graph using adjacency list
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            void AddEdge(int u, int v)
            {
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();
                graph[u].Add(v);
                // For undirected graph, add the reverse edge
                if (!graph.ContainsKey(v))
                    graph[v] = new List<int>();
                graph[v].Add(u);
            }
            // Adding edges
            AddEdge(1, 2);
            AddEdge(1, 3);
            AddEdge(2, 4);
            AddEdge(3, 4);
            // DFS traversal
            HashSet<int> visited = new HashSet<int>();
            void DFS(int node)
            {
                if (visited.Contains(node)) return;
                visited.Add(node);
                Console.WriteLine(node);
                foreach (var neighbor in graph[node])
                {
                    DFS(neighbor);
                }
            }
            // Start DFS from node 1
            DFS(1);
        }

        public static void TestBreadthFirstSearchOnGraph()
        {
            // Representing a graph using adjacency list
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            void AddEdge(int u, int v)
            {
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();
                graph[u].Add(v);
                // For undirected graph, add the reverse edge
                if (!graph.ContainsKey(v))
                    graph[v] = new List<int>();
                graph[v].Add(u);
            }
            // Adding edges
            AddEdge(1, 2);
            AddEdge(1, 3);
            AddEdge(2, 4);
            AddEdge(3, 4);
            // BFS traversal
            void BFS(int start)
            {
                Queue<int> queue = new Queue<int>();
                HashSet<int> visited = new HashSet<int>();
                queue.Enqueue(start);
                visited.Add(start);
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    Console.WriteLine(node);
                    foreach (var neighbor in graph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            visited.Add(neighbor);
                        }
                    }
                }
            }
            // Start BFS from node 1
            BFS(1);
        }

        public static void BFSPOnTree(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                Console.WriteLine(current.Value);
                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }

        public static void DFSOnTree(TreeNode node)
        {
            if (node == null) return;
            Console.WriteLine(node.Value);
            DFSOnTree(node.Left);
            DFSOnTree(node.Right);
        }

    }
}
