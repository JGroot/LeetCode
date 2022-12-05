namespace Strings
{
    public class StringFunctions
    {
        public string ReverseString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;

            var result = string.Empty;
            string[] words = s.Split(" ");

            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (!string.IsNullOrWhiteSpace(words[i]))
                    result += $"{words[i]} ";
            }

            return result.TrimEnd();
        }

        public string ReverseString2(string s)
        {
            var words = s.Trim().Split(' ').ToArray().ToList();
            words.Reverse();
            words.RemoveAll(x => string.IsNullOrWhiteSpace(x));
            return string.Join(" ", words);
        }

        public char[] ReverseWords(char[] s)
        {
            ReverseChars(ref s, 0, s.Length - 1);

            int start = 0;
            int end = 0;
            int len = s.Length;

            while (start < len)
            {
                while (end < len && s[end] != ' ')
                    end++;
                ReverseChars(ref s, start, end-1);
                start = end + 1;
                end++;
            }

            
            return s;
        }




        public void ReverseChars(ref char[] s, int left, int right)
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
    }
}