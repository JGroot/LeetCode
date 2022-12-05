using LeetCode.Models;

namespace LeetCode
{

    public class BinaryTrees
    {
        private int _depthCount;
        private IList<IList<int>> levels = new List<IList<int>>();

        public char[] BreadthFirstValues(BNode<char> root)
        {
            var values = string.Empty;
            if (root == null)
                return new char[0];

            Queue<BNode<char>> queue = new();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                values += current.Val;

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }

            return values.ToCharArray();
        }
        
        public int ComputeSum(BNode<int> root)
        {
            if (root == null)
                return 0;

            Queue<BNode<int>> queue = new();
            queue.Enqueue(root);
            int sum = 0;

            //while (queue.Any())
            {
                var current = queue.Dequeue();
                sum += current.Val;

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }

            return sum;
        }
       
        public char[] DepthFirstValues(BNode<char> root)
        {
            if (root == null)
                return Array.Empty<char>();

            Stack<BNode<char>> stack = new();
            stack.Push(root);
            string values = string.Empty;
            while (stack.Any())
            {
                var current = stack.Pop();
                values += current.Val;

                if (current.Right != null)
                    stack.Push(current.Right);
                if (current.Left != null)
                    stack.Push(current.Left);
            }
            return values.ToCharArray();
        }

        public bool HasPathSum(BNode<int> root, int targetSum)
        {
            if (root == null)
                return false;

            var sum = 0;
            Stack<BNode<int>> stack = new();
            stack.Push(root);

            while (stack.Any())
            {
                var current = stack.Pop();
                var proposedSum = sum + current.Val;

                if (proposedSum == targetSum && current.Left == null && current.Right == null)
                    return true;

                if (Math.Min(proposedSum, targetSum) <= targetSum && (current.Left != null || current.Right != null))
                {
                    sum = proposedSum;
                    if (current.Right != null)
                        stack.Push(current.Right);
                    if (current.Left != null)
                        stack.Push(current.Left);
                }
            }

            return false;
        }

        private bool InOrder(BNode<int> root, int prev)
        {
            if (root == null)
                return true;

            if (!InOrder(root.Left, prev))
                return false;

            if (prev != null && root.Val <= prev)
                return false;

            prev = root.Val;
            return InOrder(root.Right, prev);
        }

        public List<int> InorderTraversal(BNode<int> root)
        {
            List<int> result = new List<int>();
            Stack<BNode<int>> stack = new();
            var current = root;

            while (current != null || stack.Any())
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                current = stack.Pop();
                result.Add(current.Val);
                current = current.Right;
            }
            return result;
        }

        public bool IsSymmetric(BNode<int> root)
        {
            return IsSymmetricHelper(root, root);
        }

        public bool IsSymmetricHelper(BNode<int> left, BNode<int> right)
        {
            if (left == null && right == null)
                return true;
            if (left == null || right == null)
                return false;

            var l = IsSymmetricHelper(left.Right, right.Left);
            var r = IsSymmetricHelper(left.Left, right.Right);

            return (left.Val == right.Val)
                && l && r;
        }

        public bool IsSymmetricIterative(BNode<int> root)
        {
            if (root == null)
                return true;

            Queue<BNode<int>> queue = new();
            queue.Enqueue(root);
            queue.Enqueue(root);

            while (queue.Any())
            {
                var t1 = queue.Dequeue();
                var t2 = queue.Dequeue();
                if (t1 == null && t2 == null) continue;
                if (t1 == null || t2 == null) return false;
                if (t1.Val != t2.Val) return false;

                queue.Enqueue(t1.Left);
                queue.Enqueue(t2.Right);
                queue.Enqueue(t1.Right);
                queue.Enqueue(t2.Left);
            }

            return true;
        }

        public bool IsValidBST(BNode<int> root)
        {
            int prev = int.MinValue;
            return InOrder(root, prev);
        }

        public IList<IList<int>> LevelOrder(BNode<int> root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return result;

            Queue<BNode<int>> queue = new();
            queue.Enqueue(root);

            while (queue.Any())
            {
                IList<int> levelList = new List<int>();
                var levelCount = queue.Count;

                for (int i = 0; i < levelCount; i++)
                {
                    var current = queue.Dequeue();
                    levelList.Add(current.Val);

                    if (current.Left != null)
                        queue.Enqueue(current.Left);
                    if (current.Right != null)
                        queue.Enqueue(current.Right);
                }
                result.Add(levelList);
            }
            return result;
        }

        public int MaxDepthBottom(BNode<int> root)
        {
            if (root == null)
                return 0;

            var left = MaxDepthBottom(root.Left);
            var right = MaxDepthBottom(root.Right);

            return Math.Max(left, right) + 1;
        }

        public int MaxPathSum(BNode<int> root)
        {
            if (root == null)
                return int.MinValue;

            if (root.Left == null && root.Right == null)
                return root.Val;

            var maxL = MaxPathSum(root.Left);
            var maxR = MaxPathSum(root.Right);

            var childSum = Math.Max(maxR, maxL);
            return root.Val + childSum;
        }

        public int MaxDepthTop(BNode<int> root)
        {
            if (root == null)
                return 0;

            _depthCount = 0;
            MaxDepthTopHelper(root, _depthCount + 1);

            return _depthCount;
        }

        public List<int> PostorderTraversal(BNode<int> root)
        {
            if (root == null)
                return new List<int>();

            List<int> result = new();
            result.AddRange(PostorderTraversal(root.Left));
            result.AddRange(PostorderTraversal(root.Right));
            result.Add(root.Val);
            return result;
        }

        public List<int> PreorderTraversal(BNode<int> root)
        {
            if (root == null)
                return new List<int>();

            var current = root;
            List<int> result = new();
            Stack<BNode<int>> stack = new();
            stack.Push(current);

            while (stack.Any())
            {
                current = stack.Pop();
                result.Add(current.Val);

                if (current.Right != null)
                    stack.Push(current.Right);

                if (current.Left != null)
                    stack.Push(current.Left);
            }

            return result;
        }

        public string RecursiveDepthFirstValues(BNode<char> root)
        {
            if (root == null)
                return string.Empty;

            var leftValues = RecursiveDepthFirstValues(root.Left);
            var rightValues = RecursiveDepthFirstValues(root.Right);

            return root.Val + leftValues + rightValues;
        }

        public bool RecursiveIsValidBST(BNode<int> root)
        {
            return validate(root, null, null);
        }

        public IList<IList<int>> RecursiveLevelOrder(BNode<int> root)
        {
            if (root == null)
                return new List<IList<int>>();

            RecurisveLevelOrderHelper(root, 0);
            return levels;
        }

        public void RecurisveLevelOrderHelper(BNode<int> root, int level)
        {
            if (levels.Count == level)
                levels.Add(new List<int>());

            levels.ElementAt(level).Add(root.Val);

            if (root.Left != null)
                RecurisveLevelOrderHelper(root.Left, level + 1);
            if (root.Right != null)
                RecurisveLevelOrderHelper(root.Right, level + 1);

        }

        public List<int> RecursivePreorderTraversal(BNode<int> root)
        {
            if (root == null)
                return new List<int>();

            List<int> result = new() { root.Val };
            if (root.Left != null)
                result.AddRange(RecursivePreorderTraversal(root.Left));

            if (root.Right != null)
                result.AddRange(RecursivePreorderTraversal(root.Right));

            return result;

        }

        public int RecursiveSum(BNode<int> root)
        {
            if (root == null)
                return 0;

            var left = RecursiveSum(root.Left);
            var right = RecursiveSum(root.Right);

            return root.Val + left + right;
        }

        public bool RecursiveTreeIncludes(BNode<char> root, char value)
        {
            if (root == null)
                return false;
            if (root.Val == value)
                return true;

            return TreeIncludes(root.Left, value) || TreeIncludes(root.Right, value);
        }

        public int RecursiveTreeMin(BNode<int> root)
        {
            if (root == null)
                return int.MaxValue;

            var minLeft = RecursiveTreeMin(root.Left);
            var minRight = RecursiveTreeMin(root.Right);

            if (root.Val < minLeft && root.Val < minRight)
                return root.Val;

            return Math.Min(minLeft, minRight);
        }

        public bool RootEqualsSumOfChildren(TreeNode root)
        {
            return root.val == root.left.val + root.right.val;
        }

        public int TreeMin(BNode<int> root)
        {
            Stack<BNode<int>> stack = new();
            stack.Push(root);
            var min = int.MaxValue;
            while (stack.Any())
            {
                var current = stack.Pop();
                if (min >= current.Val)
                    min = current.Val;

                if (current.Left != null)
                    stack.Push(current.Left);
                if (current.Right != null)
                    stack.Push(current.Right);
            }

            return min;
        }

        public bool validate(BNode<int> root, int? min, int? max)
        {
            if (root == null)
                return true;

            if (min != null && root.Val <= min)
                return false;
            if (max != null && root.Val >= max)
                return false;

            return validate(root.Left, min, root.Val)
                && validate(root.Right, root.Val, max);

        }

        private void MaxDepthTopHelper(BNode<int> node, int depth)
        {
            if (node == null)
                return;

            _depthCount = Math.Max(_depthCount, depth);

            MaxDepthTopHelper(node.Left, depth + 1);
            MaxDepthTopHelper(node.Right, depth + 1);
        }

        public bool TreeIncludes(BNode<char> root, char value)
        {
            if (root == null)
                return false;

            Queue<BNode<char>> queue = new();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current.Val == value)
                    return true;

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Append(current.Right);
            }

            return false;
        }
    }
}

