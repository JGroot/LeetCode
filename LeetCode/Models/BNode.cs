namespace LeetCode.Models
{
    public class BNode<T>
    {
        public BNode(T val)
        {
            this.Val = val;
            this.Left = null;
            this.Right = null;
        }
        public T Val { get; set; }
        public BNode<T>? Left { get; set; }
        public BNode<T>? Right { get; set; }
    }

}
