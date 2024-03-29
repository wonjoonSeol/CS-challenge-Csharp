﻿namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question6
    {
        public static int Answer(int numServers, int targetServer, int[,] times)
        {
            bool[] isUsed = new bool[numServers];
            int[] distance = new int[numServers];
            distance[0] = 0;
            for (int i = 1; i < numServers; i++) {
                distance[i] = int.MaxValue;
            }

            for (int count = 0; count < numServers; count++) {
                //System.out.println(Arrays.toString(distance));
                //System.out.println(Arrays.toString(isUsed));
                int nodeIndex = getMin(isUsed, distance);
                isUsed[nodeIndex] = true;
                //System.out.println("node Index " + nodeIndex);

                for (int j = 0; j < numServers; j++) {
                    if (nodeIndex == j) continue;
                    if (!isUsed[j] && distance[nodeIndex] != int.MaxValue
                            && distance[nodeIndex] + times[nodeIndex,j] < distance[j]) {
                        distance[j] = distance[nodeIndex] + times[nodeIndex,j];
                    }
                }
            }
            return distance[targetServer];
        }
        public static int getMin(bool[] isUsed, int[] distance) {
            int min = int.MaxValue;
            int index = -1;
            for (int i = 0; i < isUsed.Length; i++) {
                if (!isUsed[i] && distance[i] < min) {
                    min = distance[i];
                    index = i;
                }
            }
            return index;
        }
    }
}