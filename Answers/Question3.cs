using System;
using C_Sharp_Challenge_Skeleton.Beans;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question3
    {
        public static int Answer(int numOfNodes, Edge[] edgeLists)
        {
            if (edgeList.length == 0) return numNodes;
            checkedNodes = 0;

            Map<Integer, Set> map = new HashMap<>();
            foreach (Edge edge in edgeList) {
                int a = edge.getEdgeA();
                int b = edge.getEdgeB();

                Set setA = map.getOrDefault(a, new HashSet<Integer>());
                setA.add(b);
                map.put(a, setA);
                Set setB = map.getOrDefault(b, new HashSet<Integer>());
                setB.add(a);
                map.put(b, setB);
            }

            bool[] isChecked = new bool[numNodes + 1];
            LinkedList<Node> queue = new LinkedList();

            int exchanges = 0;
            while (checkedNodes != numNodes) {
                fillQueue(queue, isChecked, numNodes);
                int maxExchange = maxExchanges(map, numNodes, queue, isChecked);
                exchanges += maxExchange;
            }
            int remaining = numNodes - exchanges;
            return Math.abs(exchanges - remaining);
        }

        public static int maxExchanges(Map<Integer, Set> map, int numNodes, LinkedList<Node> queue, boolean[] isChecked) {
            int localNodes = 0, independent = 0;
            while (!queue.isEmpty()) {
                Node currentNode = queue.pop();
                int i = currentNode.name;
                if (currentNode.isIndependent) independent++;
                checkedNodes++;
                localNodes++;
                if (map.containsKey(i)) {
                    Iterator<Integer> itr = map.get(i).iterator();
                    while (itr.hasNext()) {
                        int temp = itr.next();
                        if (!isChecked[temp]) {
                            queue.addLast(new Node(temp, !currentNode.isIndependent));
                            isChecked[temp] = true;
                        }
                    }
                }

            }
            // take maximum as bigger is trading exchanges.
            return Math.max(localNodes - independent, independent);
        }

        public static void fillQueue(LinkedList<Node> queue, boolean[] isChecked, int numNodes) {
            for (int i = 1; i <= numNodes; i++) {
                if (!isChecked[i]) {
                    isChecked[i] = true;
                    queue.add(new Node(i, true));
                    break;
                }
            }
        }

        public static class Node {
            public boolean isIndependent;
            public int name;

            public Node(int name, boolean isIndependent) {
                this.isIndependent = isIndependent;
                this.name = name;
            }
        }
    }
}