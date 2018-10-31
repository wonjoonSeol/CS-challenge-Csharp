using System;
using System.Collections.Generic;
using C_Sharp_Challenge_Skeleton.Beans;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question3
    {
        public static int checkedNodes;
        public static int Answer(int numNodes, Edge[] edgeList)
        {
            if (edgeList.Length == 0) return numNodes;
            checkedNodes = 0;

            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            foreach (Edge edge in edgeList) {
                int a = edge.EdgeA;
                int b = edge.EdgeB;

                HashSet<int> setA = map.GetValueOrDefault(a, new HashSet<int>());
                setA.Add(b);
                map.Add(a, setA);
                HashSet<int> setB = map.GetValueOrDefault(b, new HashSet<int>());
                setB.Add(a);
                map.Add(b, setB);
            }

            bool[] isChecked = new bool[numNodes + 1];
            Queue<Node> queue = new Queue<Node>();

            int exchanges = 0;
            while (checkedNodes != numNodes) {
                fillQueue(queue, isChecked, numNodes);
                int maxExchange = maxExchanges(map, numNodes, queue, isChecked);
                exchanges += maxExchange;
            }
            int remaining = numNodes - exchanges;
            return Math.Abs(exchanges - remaining);
        }

        public static int maxExchanges(Dictionary<int, HashSet<int>> map, int numNodes, Queue<Node> queue, bool[] isChecked) {
            int localNodes = 0, independent = 0;
            while (!(queue.Count == 0)) {
                Node currentNode = queue.Dequeue();
                int i = currentNode.name;
                if (currentNode.isIndependent) independent++;
                checkedNodes++;
                localNodes++;
                if (map.ContainsKey(i)) {
                    foreach (int temp in map[i]) {
                        if (!isChecked[temp]) {
                            queue.Enqueue(new Node(temp, !currentNode.isIndependent));
                            isChecked[temp] = true;
                        }
                    }
                }

            }
            // take maximum as bigger is trading exchanges.
            return Math.Max(localNodes - independent, independent);
        }

        public static void fillQueue(Queue<Node> queue, bool[] isChecked, int numNodes) {
            for (int i = 1; i <= numNodes; i++) {
                if (!isChecked[i]) {
                    isChecked[i] = true;
                    queue.Enqueue(new Node(i, true));
                    break;
                }
            }
        }

        public class Node {
            public bool isIndependent;
            public int name;

            public Node(int name, bool isIndependent) {
                this.isIndependent = isIndependent;
                this.name = name;
            }
        }
    }
}