using System.Collections.Generic;

namespace LeetCode.Tests
{

    public class TwoIntArrays
    {
        public int[] Nums { get; set; }
        public int[] Answer { get; set; }

        public static IEnumerable<object[]> GetSumOneDArray()
         => new object[][]
           {
              new object[]
                { new TwoIntArrays(){ Nums = new int[]{1, 2, 3,4 }, Answer = new int[]{1, 3, 6, 10}}} ,
              new object[]
                { new TwoIntArrays(){ Nums = new int[]{1,1,1,1,1}, Answer = new int[]{1, 2,3,4,5,}} },
              new object[]
                { new TwoIntArrays(){ Nums = new int[]{ 3, 1, 2, 10, 1 }, Answer = new int[]{3,4,6,16,17}} }
           };
    }

    public class OneIntArray
    {
        public int[] Nums { get; set; }
        public int Answer { get; set; }

        public static IEnumerable<object[]> GetPivotIndex()
          => new object[][]
          {
               //new object[]
               //     { new OneIntArray(){ Nums = new int[]{ 1,2,3,4,5 }, Answer= -1} },
                new object[]
                    { new OneIntArray(){ Nums = new int[]{ 1,7,3,6,5,6 }, Answer= 3} },
                new object[]
                    { new OneIntArray(){ Nums = new int[]{ 1,2,3 }, Answer= -1} },
                new object[]
                    { new OneIntArray(){ Nums = new int[]{ 2,1,-1}, Answer = 0} }
          };
    }
}
