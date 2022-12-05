namespace LeetCode.Models
{
    public class TreeNode
    {
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
    }
}
