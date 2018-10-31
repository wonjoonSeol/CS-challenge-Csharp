using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int Answer(int[] portfolios)
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
    }
}
