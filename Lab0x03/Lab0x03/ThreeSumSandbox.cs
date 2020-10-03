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
            // Test expected true results
            List<int> threeSumTestList = new List<int> {900, 23, 43, 223, 33, 90, 10, 1001};
            if (!ContainsThreeSumBruteForce(threeSumTestList, 1000)) return false;
            if (!ContainsThreeSumBetter(threeSumTestList, 1000)) return false;
            if (!ContainsThreeSumBest(threeSumTestList, 1000)) return false;

            // Test expected false results
            List<int> noThreeSumTestList = new List<int> {900, 23, 43, 223, 33, 90, 11, 1001};
            if (ContainsThreeSumBruteForce(noThreeSumTestList, 1000)) return false;
            if (ContainsThreeSumBetter(noThreeSumTestList, 1000)) return false;
            if (ContainsThreeSumBest(noThreeSumTestList, 1000)) return false;

            // All tests pass
            return true;
        }

        private List<int> GenerateUniqueSet(int setLength, int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            // Use .Net HashSet, which does not store duplicates, to generate a unique set and return as list.
            var tempSet = new HashSet<int>();
            // Account for scenario where range from min to max doesn't have enough values to cover setLength
            while (tempSet.Count < Math.Min(setLength, max - min))
            {
                tempSet.Add(_rand.Next(min, max));
            }

            return tempSet.ToList();
        }

        private bool ContainsThreeSumBruteForce(List<int> set, int target)
        {
            // brute force, check all n^3 combinations and return if the 3 elements ever sum to target.
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

            // takes advantage of sorted list. We iterate through each element and calculate target - current
            // we then know that we need to find 2 numbers that add up to this new 'twoSumTarget'
            // if val1 + val2 is less than current target, we can only increase by incrementing the left index,
            // if it is greater than target we can only decrease by decrementing the right index.
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

        private bool ContainsThreeSumBest(List<int> set, int target)
        {
            // fastest implementation. Does not use sort, but still only iterates through N^2 elements.
            // I use a hash set to store the elements already seen so that we can determine when the
            // difference we're looking for is a successful 3Sum and return.
            for (int i = 0; i < set.Count - 2; i++)
            {
                var tempSet = new HashSet<int>();
                var twoSumTarget = target - set[i];
                for (int j = i + 1; j < set.Count; j++)
                {
                    // check to see if twoSumTarget - current element is already in hash set
                    // if it is, that means twoSumTarget + current + (twoSumTarget - current) == target and we have a 3-sum value
                    // otherwise, add current element to hash table and continue.
                    if (tempSet.Contains(twoSumTarget - set[j])) return true;
                    tempSet.Add(set[j]);
                }
            }

            return false;
        }
    }
}
