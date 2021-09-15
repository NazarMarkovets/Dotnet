namespace Dotnet.Lib
{
    public class TreeNode
    {
            private int key;
            public TreeNode left, right;
            public TreeNode()
            {
                key = default;
                left = null; right = null;
            }
            public TreeNode(int key)
            {
                this.key = key;
                left = null; right = null;
            }

    }
}