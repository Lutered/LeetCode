using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindSumPairs
    {
        int[] _nums1;
        int[] _nums2;

        Dictionary<int, int> nums2CountDict = new Dictionary<int, int>();

        public FindSumPairs(int[] nums1, int[] nums2)
        {
            _nums1 = nums1;
            _nums2 = nums2;

            foreach (int i in nums2)
            {
                if (nums2CountDict.ContainsKey(i)) nums2CountDict[i]++;
                else nums2CountDict.Add(i, 1);
            }
        }

        public void Add(int index, int val)
        {
            if (index > _nums2.Length - 1) return;

            if (nums2CountDict[_nums2[index]] <= 0) nums2CountDict.Remove(_nums2[index]);
            else nums2CountDict[_nums2[index]]--;

            _nums2[index] += val;

            if (nums2CountDict.ContainsKey(_nums2[index])) nums2CountDict[_nums2[index]]++;
            else nums2CountDict.Add(_nums2[index], 1);
        }

        public int Count(int tot)
        {
            int result = 0;

            foreach (var num1 in _nums1)
            {
                int num2 = tot - num1;

                if (nums2CountDict.ContainsKey(num2)) result += nums2CountDict[num2];
            }

            return result;
        }
    }
}
