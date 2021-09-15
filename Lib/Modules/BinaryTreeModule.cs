using Dotnet.Lib;

namespace Lib.Modules
{
    public class BinaryTreeModule
    {
        public void CreateTree()
        {
            var binaryTree = new BinaryTree(1)
                /*
                 1
                / \
             null null     
             */
            {
                treeRoot =
                {
                    left = new TreeNode(2),
                    right = new TreeNode(3)
                }
            };
        }
    }
}