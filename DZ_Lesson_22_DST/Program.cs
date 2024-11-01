using DZ_Lesson_22_BST;

Console.WriteLine("Добро пожаловать! Изучаем деревья");

int menu = 0;
try
{
    Node<long, string> treeNode = null;

    do
    {
        switch (menu)
        {
            case 0:
                treeNode = null;
                treeNode = TreeOperation.InputNode(treeNode);
                TreeOperation.StartInOrder(treeNode);
                TreeOperation.StartFindValueNode(treeNode);
                break;
            case 1:
                TreeOperation.StartFindValueNode(treeNode);
                break;
            default:
                continue;
        }

        Console.WriteLine("\r\nОсновные задания выполнены. Хотите начать все с начала - введите 0 или 1 - повторить поиск сотрудника по величине ЗП");
        menu = int.Parse(Console.ReadLine());
    }
    while (true);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}