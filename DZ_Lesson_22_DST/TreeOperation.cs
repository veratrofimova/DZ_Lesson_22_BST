namespace DZ_Lesson_22_BST
{
    public class TreeOperation
    {
        private static void InformationToUser()
        {
            Console.Clear();
            Console.WriteLine("Введите информацио о сотруднике:");
            Console.WriteLine("имя в первой строке, зарплата в виде целого числа во второй строке");
            Console.WriteLine("Ввод пустой строки в качестве имени сотрудника запустит построение бинарного дерева");
        }

        public static Node<long, string> InputNode(Node<long, string> treeNode)
        {
            InformationToUser();

            treeNode = CreateTree(treeNode);

            return treeNode;
        }

        private static Node<long, string> CreateTree(Node<long, string> treeNode)
        {
            try
            {
                while (true)
                {
                    string name = Console.ReadLine();

                    if (string.IsNullOrEmpty(name))
                        break;

                    var value = Console.ReadLine();
                    long Value = long.Parse(value);

                    if (treeNode == null)
                    {
                        treeNode = new Node<long, string>()
                        {
                            Value = Value,
                            Data = name
                        };
                    }
                    else
                    {
                        AddNode(treeNode, new Node<long, string>()
                        {
                            Value = Value,
                            Data = name
                        });
                    }
                }

                return treeNode;
            }

            catch (FormatException)
            {
                throw new Exception("введите число");
            }
        }

        public static void StartFindValueNode(Node<long, string> root)
        {
            try
            {
                Console.WriteLine("\r\nВведите ЗП для поиска");
                long value = long.Parse(Console.ReadLine());

                int operationCount = 0;

                var (node, level) = FindNode(root, value, operationCount);
                if (node != null)
                {
                    Console.WriteLine($"Найден сотрудник {node.Data} с ЗП {node.Value} руб. Для поиска потребовалось {level} итераций сравнения");
                }
                else
                {
                    Console.WriteLine($"Такой сотрудник не найден");
                }
            }
            catch (FormatException)
            {
                throw new Exception("введите число");
            }
        }

        private static (Node<long, string>, int) FindNode(Node<long, string> root, long value, int level)
        {
            if (value < root.Value)
            {
                if (root.Left != null)
                {
                    return FindNode(root.Left, value, level + 1);
                }

                return (null, -1);
            }

            if (value > root.Value)
            {
                if (root.Right != null)
                {
                    return FindNode(root.Right, value, level + 1);
                }

                return (null, -1);
            }

            return (root, level + 1);
        }
        private static void AddNode(Node<long, string> root, Node<long, string> treeNode)
        {
            if (treeNode.Value < root.Value)
            {
                if (root.Left == null)
                {
                    root.Left = treeNode;
                }
                else
                {
                    AddNode(root.Left, treeNode);
                }
            }

            if (treeNode.Value > root.Value)
            {
                if (root.Right == null)
                {
                    root.Right = treeNode;
                }
                else
                {
                    AddNode(root.Right, treeNode);
                }
            }
        }

        public static void StartInOrder(Node<long, string> root)
        {
            Console.WriteLine("\r\n Далее");
            Console.WriteLine("\r\nВыведем имена сотрудников и их зарплаты в порядке возрастания зарплат");

            InOrder(root);
        }

        public static void InOrder(Node<long, string> root)
        {
            if (root.Left != null)
            {
                InOrder(root.Left);
            }

            Console.WriteLine($"Сотрудник {root.Data} с зарплатой {root.Value}");

            if (root.Right != null)
            {
                InOrder(root.Right);
            }
        }
    }
}
