using System;
using System.Collections;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            if (cashflowIn.Length < cashflowOut.Length) {
                if (cashflowIn.Length == 0) return findMin(cashflowOut);
                return smallestDifference(cashflowIn, cashflowOut);
            } else {
                if (cashflowOut.Length == 0) return findMin(cashflowIn);
                return smallestDifference(cashflowOut, cashflowIn);
            }
        }

        public static int findMin(int[] arr) {
            int min = int.MaxValue;
            foreach (int elem in arr) {
                if (elem < min) min = elem;
            }
            return min;
        }

        public static int smallestDifference(int[] shorter, int[] longer) {
            List<int> permutations = new List<int>();
            generatePermutation(shorter, 0, 0, permutations);
    //		System.out.println(permutations);
            int minDifference = int.MaxValue;
            foreach (int sum in permutations) {
                int temp;
                if (sum > 0) {
                    Dictionary<string, int> memo = new Dictionary<string, int>();
                    temp = findSum(longer, sum, 0, memo);
                } else {
                    temp = findMin(longer);
                }

                if (temp < minDifference) minDifference = temp;
    //			System.out.println(minDifference);
            }
            return minDifference;
        }

        public static int findSum(int[] longer, int total, int k, Dictionary<string, int> memo) {
            if (total <= 0 || k == longer.Length) return Math.Abs(total);
            if (memo.ContainsKey(total + ":" + k)) return memo[total+":"+k];
            return Math.Min(findSum(longer, total - longer[k], k + 1, memo), findSum(longer, total, k + 1, memo));
        }

        public static void generatePermutation(int[] shorter, int k, int sum, List<int> result) {
            if (k == shorter.Length) {
                result.Add(sum);
            } else {
                generatePermutation(shorter, k + 1, sum + shorter[k], result);
                generatePermutation(shorter, k + 1, sum, result);
    //			if (k != shorter.Length - 1) generatePermutation(shorter, k + 1, sum, result);
            }
        }
    }
}