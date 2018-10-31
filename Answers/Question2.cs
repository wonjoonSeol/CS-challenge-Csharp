namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            int portfolioC = 0;
            for (int i = 0; i < portfolios.length - 1; i++) {
                for (int j = i + 1; j < portfolios.length; j++) {
                    int current = portfolios[i] ^ portfolios[j];
                    if (portfolioC < current) portfolioC = current;
                }
            }
            return portfolioC;
        }

        public static int findMin(int[] arr) {
            int min = Integer.MAX_VALUE;
            foreach (int elem in arr) {
                if (elem < min) min = elem;
            }
            return min;
        }

        public static int smallestDifference(int[] shorter, int[] longer) {
            List<Integer> permutations = new ArrayList<Integer>();
            generatePermutation(shorter, 0, 0, permutations);
    //		System.out.println(permutations);
            int minDifference = Integer.MAX_VALUE;
            foreach (int sum in permutations) {
                int temp;
                if (sum > 0) {
                    Map<String, Integer> memo = new HashMap<>();
                    temp = findSum(longer, sum, 0, memo);
                } else {
                    temp = findMin(longer);
                }

                if (temp < minDifference) minDifference = temp;
    //			System.out.println(minDifference);
            }
            return minDifference;
        }

        public static int findSum(int[] longer, int total, int k, Map<String, Integer> memo) {
            if (total <= 0 || k == longer.length) return Math.abs(total);
            if (memo.containsKey(total + ":" + k)) return memo.get(total+":"+k);
            return Math.min(findSum(longer, total - longer[k], k + 1, memo), findSum(longer, total, k + 1, memo));
        }

        public static void generatePermutation(int[] shorter, int k, int sum, List<Integer> result) {
            if (k == shorter.length) {
                result.add(sum);
            } else {
                generatePermutation(shorter, k + 1, sum + shorter[k], result);
                generatePermutation(shorter, k + 1, sum, result);
    //			if (k != shorter.length - 1) generatePermutation(shorter, k + 1, sum, result);
            }
        }
    }
}