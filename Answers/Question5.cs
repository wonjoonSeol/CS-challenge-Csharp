namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            int result = minAllocations(numOfShares, totalValueOfShares);
            return result == int.MaxValue ? 0 : result;
        }


        public static int minAllocations(int[] allowedAllocations, int total) {
            int[] memo = new int[total + 1];
            // Base case (If given value V is 0)
            memo[0] = 0;
            // Initialize all table values as Infinite
            for (int i = 1; i <= total; i++) {
                memo[i] = int.MaxValue;
            }
            // Compute minimum coins required for all
            // values from 1 to total
            for (int i = 1; i <= total; i++) {
                // Go through all coins smaller than i
                for (int j = 0; j < allowedAllocations.Length; j++) {
                    if (allowedAllocations[j] <= i) {
                        int temp = memo[i - allowedAllocations[j]];
                        if (temp != int.MaxValue && temp + 1 < memo[i])
                            memo[i] = temp + 1;
                    }
                }
            }
            return memo[total];
        }
    }
}