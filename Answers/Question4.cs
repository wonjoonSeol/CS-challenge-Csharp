using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] rows, int numberMachines)
        {
            if (rows.Length == 0) return 0;
            int minTime = int.MaxValue;
            for (int row = 0; row < rows.Length; row++) {
                int xNum = 0;
                for (int start = 0; start <= rows.GetLength(1) - numberMachines; start++) {
                    bool isXFound = false;
                    if (rows.GetLength(1)- xNum < numberMachines) break;
                    int end = start + numberMachines;
                    int sum = 0;
    //				System.out.println("start " + start);
    //				System.out.println("end " + end);
                    for (int i = start; i < end; i++) {
                        if (rows[row, i].Equals("X")) {
                            start = i;
                            xNum++;
                            isXFound = true;
                            break;
                        } else {
                            sum += Int32.Parse(rows[row, i]);
                        }
                    }
                    if (isXFound) {
    //					System.out.println("Xfound " + start);
                        continue;
                    }
                    if (sum < minTime) minTime = sum;
    //				System.out.println("sum " + sum);
                }
            }
            if (minTime != int.MaxValue) return minTime;
            return 0;
        }
    }
}