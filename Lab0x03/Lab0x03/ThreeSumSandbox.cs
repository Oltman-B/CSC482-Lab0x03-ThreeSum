using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Lab0x03
{
    class ThreeSumSandbox
    {
        private readonly Random _rand = new Random();

        public void RunTimeTests()
        {
            var nextList = GenerateUniqueSet(300);
        }

        public bool VerificationTests()
        {
            List<int> threeSumTestList = new List<int> {900, 23, 43, 223, 33, 90, 10, 1001};
            List<int> noThreeSumTestList = new List<int> {900, 23, 43, 223, 33, 90, 11, 1001};
            if (!ContainsThreeSumBruteForce(threeSumTestList, 1000)) return false;
            if (!ContainsThreeSumBetter(threeSumTestList, 1000)) return false;

            if (ContainsThreeSumBruteForce(noThreeSumTestList, 1000)) return false;
            if (ContainsThreeSumBetter(noThreeSumTestList, 1000)) return false;

            // All tests pass
            return true;
        }

        private List<int> GenerateUniqueSet(int setLength, int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            var tempSet = new HashSet<int>();
            while (tempSet.Count < setLength)
            {
                tempSet.Add(_rand.Next(min, max));
            }

            return tempSet.ToList();
        }

        private bool ContainsThreeSumBruteForce(List<int> set, int target)
        {
            for (int i = 0; i < set.Count - 2; i++)
            {
                for (int j = i + 1; j < set.Count - 1; j++)
                {
                    for (int k = j + 1; k < set.Count; k++)
                    {
                        if (set[i] + set[j] + set[k] == target) return true;
                    }
                }
            }
            return false;
        }

        private bool ContainsThreeSumBetter(List<int> set, int target)
        {
            set.Sort();

            for (int i = 0; i < set.Count - 2; i++)
            {
                int twoSumTarget = target - set[i];
                for (int left = i + 1, right = set.Count - 1; left < right;)
                {
                    int candidate = set[left] + set[right];
                    if (candidate == twoSumTarget) return true;

                    if (candidate < twoSumTarget) left++;
                    else right--;
                }
            }

            return false;
        }
    }
}
