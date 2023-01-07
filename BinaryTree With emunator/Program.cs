// See https://aka.ms/new-console-template for more information
using BinaryTree_With_emunator;
Node<double> tree = new Node<double>(0);
tree.Insert(1);
tree.Insert(-1);
tree.Insert(10);
tree.Insert(5);
tree.Insert(6);
tree.Insert(7);
tree.Insert(-2);
tree.Insert(-0.5);
tree.print();
Console.WriteLine("Iterator 1");
foreach (Node<double> node in tree)
{
    Console.WriteLine(node.GetValue);
}
Console.WriteLine("Iterator 2");
foreach (Node<double> node in tree)
{
    Console.WriteLine(node.GetValue);
}
