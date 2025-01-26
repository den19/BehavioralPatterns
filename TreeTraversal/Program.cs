namespace TreeTraversal
{
    // Перебор дерева
    // Создадим дерево и итератор для его обхода
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode("Root");
            root.Children.Add(new TreeNode("Child A"));
            root.Children.Add(new TreeNode("Child B"));
            root.Children[0].Children.Add(new TreeNode("Grandchild AA"));
            root.Children[0].Children.Add(new TreeNode("Grandchild AB"));

            Tree tree = new Tree(root);
            IIterator iterator = tree.CreateIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Current());
                iterator.Next();
            }

            Console.ReadLine();
        }
    }

    // Интерфейс итератора
    interface IIterator
    {
        bool HasNext();
        object Current();
        void Next();
    }

    // Узел дерева
    class TreeNode
    {
        public string Data { get; set; }
        public List<TreeNode> Children { get; set; }
        public TreeNode(string data)
        {
            Data = data;
            Children = new List<TreeNode>();
        }
    }

    // Агрегат (дерево)
    class Tree
    {
        private TreeNode root;

        public Tree(TreeNode root)
        {
            this.root = root;
        }

        public IIterator CreateIterator()
        {
            return new TreeIterator(root);
        }

        public class TreeIterator : IIterator
        {
            private Stack<TreeNode> stack = new Stack<TreeNode>();
            public TreeIterator(TreeNode root)
            {
                stack.Push(root);
            }

            public bool HasNext()
            {
                return stack.Count > 0;
            }

            public object Current()
            {
                return stack.Peek().Data;
            }

            public void Next()
            {
                TreeNode node = stack.Pop();
                foreach (TreeNode child in node.Children)
                {
                    stack.Push(child);
                }
            }
        }
    }
}
