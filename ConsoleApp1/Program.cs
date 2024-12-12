// See https://aka.ms/new-console-template for more information
using System.Collections;

/*Console.WriteLine("Hello, World!");
Console.WriteLine("truoc" + Test.count);
Test test = new();
Test _ = new();
Console.WriteLine("sau" + Test.count);
test.Con = "TUKET";
Console.WriteLine(test.Con);
Console.WriteLine(Test.Tong(5, 5));
Console.WriteLine(Mausac.color);
DeliverChild dlv = new DeliverChild();
DeliverChild.Info();
Kethua kt = new DeliverChild();
kt.Info();
kt.Vtual();
kt.InKq("hjaahaha");
dlv.InKq("hahaha");
dlv.log();*/
/*HashTableTest hashTableTest = new HashTableTest();
hashTableTest.RunHash();*/
//StackTest stackTest = new StackTest();
//stackTest.RunStack();
//stackTest.runQueue();
//stackTest.RunBitArr();
//DictionaryTest myDict = new DictionaryTest();
//var MyTub = Tuple.Create<int, string>(1, "HowK");
//Console.WriteLine(MyTub.Item1 + MyTub.Item2);
//var MyTub2 = new Tuple<int, string, bool>(1, "HowK", true);
//myDict.RunDiction();
//var now = GetCurrentDateInfo();
//Console.WriteLine("Date: {0}, Month: {1}, Year: {2}", now.Item1, now.Item2, now.Item3);
MyArrayList testMyArr = new MyArrayList();
testMyArr.Add(1);
testMyArr.Add(2);
testMyArr.Add(3);
testMyArr.Add(4);
testMyArr.Add(5);
//foreach (int i in testMyArr)
//{
//    Console.WriteLine(i);
//}    
//var rs = testMyArr.Contains(1);
//Console.WriteLine(rs);
//static Tuple<int, int, int> GetCurrentDateInfo()
//{
//    DateTime now = DateTime.Now;
//    return new Tuple<int, int, int>(now.Day, now.Month, now.Year);
//}
class Test
{
    private string con = "sad";
    public static int count = 0;
    public Test() => count++;
    public string Con { get; set; }
    public static int Tong(int a, int b)
    {
        return a + b;
    }

}

class Mausac
{
    public static string color;
    static Mausac()
    {
        DateTime currentDate = DateTime.Now;
        switch (currentDate.DayOfWeek)
        {
            case DayOfWeek.Monday:
                color = "Black";
                break;
            case DayOfWeek.Saturday:
                color = "Green";
                break;
            default:
                color = "red";
                break;
        }
    }
}
abstract class Kethua
{
    public string studentName = "Hoa";
    public Kethua()
    {
        /*       studentName = "Nguoi moi";*/
    }
    public void Info()
    {
        Console.WriteLine(studentName);
    }
    private string pr = "not access";
    public abstract void Vtual();
    public virtual void InKq(string text)
    {
        Console.WriteLine(text);
    }

}

class DeliverChild : Kethua
{
    public DeliverChild()
    {
        /*    studentName = "Child name";*/
        base.Info();
    }
    public static new void Info()
    {
        Console.WriteLine("New info");
    }
    public override void Vtual()
    {
        Console.WriteLine("Vitual");

    }
    public override void InKq(string text)
    {
        Console.WriteLine(text + "New Kq");
    }
    // khởi tạo 1 ArrayList và chỉ định Capacity ban đầu là 5
    ArrayList MyArray = new ArrayList(10);
    public void log()
    {
        ArrayList myPerson = new ArrayList(10);
        for (int i = 0; i < myPerson.Capacity; i++)
        {
            myPerson.Add(new Person("Number " + i, i + new Random().Next(1, 100)));
        }
        Console.WriteLine("Ds ban dau:");
        foreach (Person person in myPerson)
        {
            Console.WriteLine(person.ToString());
        }
        myPerson.Sort(new SortPerson());
        Console.WriteLine("Sau khi sap xep:");
        foreach (Person person in myPerson)
        {
            Console.WriteLine(person.ToString());
        }
    }
}

public class SortPerson : IComparer
{
    public int Compare(object x, object y)
    {
        Person p1 = x as Person;
        Person p2 = y as Person;
        if (p1 == null || p2 == null)
        {
            throw new InvalidOperationException();
        }
        else
        {
            if (p1.Age > p2.Age)
            {
                return 1;
            }
            else if (p1.Age < p2.Age)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
class Person
{
    private string name;
    private int age;

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public Person(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }
    public override string ToString()
    {
        return "Name: " + name + " | Age: " + age;
    }

}

class HashTableTest : SorterListTest
{
    private Hashtable myHash = new Hashtable(5);
    public void RunHash()
    {
        Console.WriteLine(handleSort());
        myHash.Add("A", 55582);
        myHash.Add("B", 1212);
        myHash.Add("C", null);
        myHash.Add("D", 25);
        Console.WriteLine(myHash.Count);
        /*  foreach (var item in myHash.Keys)
          {
              Console.WriteLine(item);
          }
          */
        foreach (var item2 in myHash.Values)
        {
            Console.WriteLine(item2);
        }
        myHash["Ab"] = "asdjasjdjasdjasd";
        myHash["NAHA"] = 0;
        Console.WriteLine(myHash["sadas"]);
        foreach (DictionaryEntry item in myHash)
        {
            Console.WriteLine(item.Key + "---" + item.Value);
        }
    }
}
class SorterListTest
{
    private SortedList mySort = new SortedList(10);
    public string handleSort()
    {
        mySort.Add("A", 250);
        return mySort.Count.ToString();
    }
}


class StackTest : QueueTest
{
    Stack mySt = new Stack();
    public void RunStack()
    {
        mySt.Push("Hello");
        mySt.Push(2522);
        mySt.Push(545);
        Console.WriteLine(mySt.Count);
        /* Console.WriteLine(mySt.Peek());
        Console.WriteLine(mySt.Pop());*/
        mySt.Push(5525);
        int Length = mySt.Count;
        for (int i = 0; i < Length; i++)
        {
            Console.WriteLine(mySt.Pop());
        }
        Console.WriteLine(mySt.Count);
    }
}
class QueueTest : BitArrTest
{
    Queue myQueue = new Queue();
    public void runQueue()
    {
        myQueue.Enqueue("Hello");
        myQueue.Enqueue(2522);
        myQueue.Enqueue(545);
        Console.WriteLine(myQueue.Count);
        /* Console.WriteLine(myQueue.Peek());
        Console.WriteLine(myQueue.Pop());*/
        myQueue.Enqueue(5525);
        int Length = myQueue.Count;
        for (int i = 0; i < Length; i++)
        {
            Console.WriteLine(myQueue.Dequeue());
        }
        Console.WriteLine(myQueue.Count);
    }
}

class BitArrTest
{
    //BitArray myBA = new BitArray(10);
    byte[] myByte = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    //int[] myByte = new int[10] {1,2,3,4,5,6,7,8,9,10};
    public static void PrintBit(BitArray arr, int width)
    {
        int i = width;
        foreach (bool item in arr)
        {
            if (i < 1)
            {
                i = width;
                Console.WriteLine();
            }
            i--;
            Console.Write(item.GetHashCode());
        }
        Console.WriteLine();
    }
    public void RunBitArr()
    {
        BitArray myBA = new BitArray(myByte);
        Console.Write("Count of Bit array is:");
        Console.WriteLine(myBA.Length);
        Console.WriteLine(myBA.Count);
        PrintBit(myBA, 8);
        var rs = myBA.And(new BitArray(80));
        Console.WriteLine(rs.Length);
        myBA.And(new BitArray(80));
        // Khởi tạo 1 BitArray từ mảng bool có sẵn
        bool[] MyBool2 = new bool[5] { true, false, true, true, false };
        BitArray MyBA6 = new BitArray(MyBool2);

        // Khởi tạo 1 BitArray có 2 phần tử và có giá trị mặc định là 1 (true)
        bool[] MyBool3 = new bool[] { false, true, true, false, false };
        BitArray MyBA7 = new BitArray(MyBool3);

        Console.Write(" Gia tri cua MyBA6: ");
        PrintBit(MyBA6, 5);

        Console.Write(" Gia tri cua MyBA7: ");
        PrintBit(MyBA7, 5);

        Console.WriteLine(" Thuc hien cac phep toan AND, OR, NOT, XOR tren MyBA6 va MyBA7: ");

        // thực hiện sao chép giá trị của MyBA6 ra để không làm thay đổi nó
        BitArray AndBit = MyBA6.Clone() as BitArray;
        AndBit.And(MyBA7);
        Console.Write(" Ket qua cua phep toan AND: ");
        PrintBit(AndBit, 5);

        BitArray OrBit = MyBA6.Clone() as BitArray;
        OrBit.Or(MyBA7);
        Console.Write(" Ket qua cua phep toan OR: ");
        PrintBit(OrBit, 5);

        BitArray XorBit = MyBA6.Clone() as BitArray;
        XorBit.Xor(MyBA7);
        Console.Write(" Ket qua cua phep toan XOR: ");
        PrintBit(XorBit, 5);

        BitArray NotBit = MyBA6.Clone() as BitArray;
        NotBit.Not();
        Console.Write(" Ket qua cua phep toan NOT tren MyBA6: ");
        PrintBit(NotBit, 5);
        MyGeneric<int> MyGNR = new MyGeneric<int>(5);
        MyGNR.SetItemWithIndex(0, 58);
        Console.WriteLine(MyGNR.GetbyIndex(0));
    }
}
public class MyGeneric<T>
{
    private T[] items;

    public T[] Items { get => items; }
    public MyGeneric(int size)
    {
        items = new T[size];
    }
    public T GetbyIndex(int Index)
    {
        if (Index < 0 || Index >= items.Length)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            return items[Index];
        }
    }
    public void SetItemWithIndex(int Index, T Value)
    {
        if (Index < 0 || Index > items.Length)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            items[Index] = Value;
        }
    }
}

public class DictionaryTest
{
    Dictionary<string, string> myDict = new Dictionary<string, string>();
    public void RunDiction()
    {
        myDict.Add("Hello", "Hello world");
        myDict.Add("Hello123", "Hello 123");
        myDict.Add("Hello123123", "Hello 345");
        foreach (KeyValuePair<string, string> pair in myDict)
        {
            Console.WriteLine(pair.Key + " -------- " + pair.Value);
        }
    }
}

public class MyArrayList : ICollection
{
    private object[] lstObj;
    private readonly object syncRoot = new object(); // SyncRoot for ICollection
    public int Count { get; private set; }
    private int Capacity { get; set; } = 4;

    public MyArrayList()
    {
        Count = 0;
        lstObj = new object[Capacity];
    }

    public MyArrayList(int capacity)
    {
        this.Capacity = capacity;
        Count = 0;
        lstObj = new object[Capacity];
    }

    public void CopyTo(Array array, int index)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        if (index < 0 || index >= array.Length) throw new ArgumentOutOfRangeException(nameof(index));
        if (array.Length - index < Count) throw new ArgumentException("Array too small");

        for (int i = 0; i < Count; i++)
        {
            array.SetValue(lstObj[i], index + i);
        }
    }

    public bool IsSynchronized => false;

    public object SyncRoot => syncRoot;

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return lstObj[i];
        }
    }

    public bool IsFixedSize => false;

    public bool IsReadOnly => false;

    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            return lstObj[index];
        }
        set
        {
            if (IsReadOnly) throw new NotSupportedException();
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            lstObj[index] = value;
        }
    }

    public int Add(object value)
    {
        if (IsReadOnly || IsFixedSize) throw new NotSupportedException();
        EnsureCapacity();
        lstObj[Count++] = value;
        return Count - 1;
    }

    private void EnsureCapacity()
    {
        if (Count >= Capacity)
        {
            Capacity *= 2;
            object[] newArray = new object[Capacity];
            Array.Copy(lstObj, newArray, Count);
            lstObj = newArray;
        }
    }

    public void Clear()
    {
        Count = 0;
        lstObj = new object[Capacity];
    }

    public bool Contains(object value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (lstObj[i]?.Equals(value) == true) return true;
        }
        return false;
    }

    public int IndexOf(object value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (lstObj[i]?.Equals(value) == true) return i;
        }
        return -1;
    }

    public void Insert(int index, object value)
    {
        if (index < 0 || index > Count) throw new IndexOutOfRangeException();
        EnsureCapacity();

        for (int i = Count; i > index; i--)
        {
            lstObj[i] = lstObj[i - 1];
        }

        lstObj[index] = value;
        Count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

        for (int i = index; i < Count - 1; i++)
        {
            lstObj[i] = lstObj[i + 1];
        }

        Count--;
    }

    public void Remove(object value)
    {
        int index = IndexOf(value);
        if (index >= 0) RemoveAt(index);
    }
}

public class DelegateTest
{
    delegate int MyDelegate(string s);
}