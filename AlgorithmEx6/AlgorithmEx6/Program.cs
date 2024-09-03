// See https://aka.ms/new-console-template for more information
using AlgorithmEx6.BinarySearchTree;
using AlgorithmEx6.BinarySearchTree2;

Console.WriteLine("Hello, World!");
//BinarySearchTreeDemo();
BinarySearchTreeDemo2();

Console.ReadLine();


static void BinarySearchTreeDemo()
{
    int [] arr= { 10, 15, 13,7, 3, 11, 22, 31, 9, 16 };

    BinarySearchTreeCS binarySearchTreeCS=new BinarySearchTreeCS();

    for (int i = 0; i < arr.Length; i++)
    {
        Node n = new Node(arr[i]);
        binarySearchTreeCS.Add(n);
    }

    Console.WriteLine("二元搜尋樹 中序遍歷");
    binarySearchTreeCS.midOrderSort();

}
static void BinarySearchTreeDemo2()
{
    //先new出一個Employee物件叫a
    Employee a = new Employee("a", 95, 25);

    //以我們的二元樹類別，傳入的型別是Employee，預設建構子放a物件。
    Tree<Employee> tree1 = new Tree<Employee>(a);

    //下面就是測試隨便new幾個員工出來，然後用Insert方法放進二元樹裡。
    Employee b = new Employee("b", 120, 10);
    tree1.Insert(b);
    Employee c = new Employee("c", 500, 7);
    tree1.Insert(c);
    Employee d = new Employee("d", 95, 10);
    tree1.Insert(d);

    //將我們要的結果印出來
    tree1.WalkTree();

}