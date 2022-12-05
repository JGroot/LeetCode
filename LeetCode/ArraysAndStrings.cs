using System.Linq;

namespace LeetCode
{
    public class ArraysAndStrings
    {
        public int FindPivotIndex(int[] nums)
        {
            int totalSum = 0;
            int leftSum = 0;

            foreach (int num in nums)
                totalSum += num;

            for(int i = 0; i < nums.Length; i++)
            {
                if (leftSum == (totalSum - leftSum - nums[i]))
                    return i;

                leftSum += nums[i];
            }

            return -1;
        }
       
        public bool IsIsomorphic(string s, string t)
        {
            //first check that the length match
            if (s.Length != t.Length)
                return false;

            //p a p e r
            //t i t l e
            //true

            //b a d c
            //b a b a
            //false

            Dictionary<char, char> sdict = new();
            Dictionary<char, char> tdict = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (sdict.TryGetValue(s[i], out char tvalue))
                {
                    if (t[i] != tvalue)
                        return false;
                }
                else if (tdict.TryGetValue(t[i], out char svalue))
                {
                    if (s[i] != svalue)
                        return false;
                }
                else
                {
                    sdict.Add(s[i], t[i]);
                    tdict.Add(t[i], s[i]);
                }
            }

            return true;
        }

        public bool IsPalindrome(string s)
        {
            //1 <= s.length <= 2 * 105
            //s consists only of printable ASCII characters.

            //easiest case
            if (string.IsNullOrWhiteSpace(s))
                return true;

            //clean up string to remove spaces and store in array
            var letters = s.ToLower().Where(x => char.IsLetterOrDigit(x)).ToArray();

            //iterate through string and compare left to right into the middle
            //// if left and right do not match then return false
            //// complete loop and return true
            var left = 0;
            var right = letters.Length - 1;

            while (left < right)
            {
                if (letters[left] != letters[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        public bool IsSubsequence(string s, string t)
        {
            return false;
        }

        public bool IsValid(string s)
        {
            Dictionary<char, char> dict = new() { { '(', ')' }, { '{', '}' }, { '[', ']' } };
            Stack<char> stack = new();

            foreach (var c in s.ToCharArray())
            {
                if (dict.ContainsKey(c))
                    stack.Push(c);
                else
                {
                    if (!stack.Any())
                        return false;

                    char open = stack.Pop();
                    if (dict.TryGetValue(open, out char value))
                    {
                        if (value != c)
                            return false;
                    }
                }
            }
            return !stack.Any();
        }

        public char[] ReverseString(char[] s)
        {
            //ReverseHelper(ref s);
            RecursiveReverse(ref s);
            return s;
        }

        public void ReverseHelper(ref char[] s)
        {
            var left = 0;
            var right = s.Length - 1;

            if (left < right)
            {
                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }

        public void RecursiveReverse(ref char[] s)
        {
            var left = 0;
            var right = s.Length - 1;
            RecursiveReverseHelper(s, left, right);
        }

        public void RecursiveReverseHelper(char[] s, int left, int right)
        {
            if (left < right)
            {
                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
                RecursiveReverseHelper(s, left, right);
            }
        }

        public string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            var words = s.Split(' ');
            var result = string.Empty;
            for (var i = words.Length -1; i >= 0; i--)
            {
                if (!string.IsNullOrWhiteSpace(words[i]))
                    result += $"{words[i]} ";
            }
            return result.Trim();
        }

        public int[] ReverseIntArray(int[] nums)
        {
            //rev[0] = num[4]
            //rev[1] = num[3]
            //rev[2] = num[2]
            //rev[3] = num[1]
            //rev[4] = num[0]

            int[] reverse = new int[nums.Length];
            for (int i = 1; i <= nums.Length; i++)
            {
                reverse[i - 1] = nums[nums.Length - i];
            }
            return reverse;
        }

        public char[] ReverseWordsTwo(char[] s)
        {
            //reverse letters
            var left = 0;
            var right = s.Length - 1;
            ReverseWordsTwoRef(ref s, left, right);

            //reverse words
            var start = 0;
            var end = 0;
            var len = s.Length;

            while (start < len)
            {
                while(end < len && s[end] != ' ')
                    end++;

                ReverseWordsTwoRef(ref s, start, end - 1);
                start = end + 1;
                end++;
            }

            return s;
        }

        public void ReverseWordsTwoRef(ref char[] s, int left, int right)
        {
            while (left < right)
            {
                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }

        public int[] RunningSumOneDArray(int[] nums)
        {
            int[] runningSum = new int[nums.Length];
            runningSum[0] = nums[0];

            for(var i = 1; i < nums.Length; i++)
                runningSum[i] = runningSum[i-1] + nums[i];
            
            return runningSum;
        }

        public int[] SortedSquares(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] *= nums[i];
            }
            Quicksort(nums, 0, nums.Length - 1);

            return nums;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            // iterate through array
            //subtract current value from target and store in variable (newTarget)
            //check if new target is in the array
            //if it is, then return a new array with current index and the found index
            //if not, then store current val and index
            Dictionary<int, int> dict = new();

            for (var i = 0; i < nums.Length; i++)
            {
                var newTarget = target - nums[i];
                if (dict.TryGetValue(newTarget, out int value))
                {
                    return new int[] { i, value };
                }
                dict[nums[i]] = i;
            }
            return Array.Empty<int>();
        }

        public void Quicksort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                    Quicksort(arr, left, pivot - 1);
                if (pivot + 1 < right)
                    Quicksort(arr, pivot + 1, right);
            }

        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];

            while(true)
            {
                while (arr[left] < pivot)
                    left++;
                while(arr[right] > pivot)
                    right--;
                if (left < right && arr[right] != arr[left])
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                    return right;
            }
        }
    }

}
