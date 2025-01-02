namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, int> myDict = new Dictionary<string, int>()
            //{
            //    ["name"] = 1,
            //    ["age"] = 18,
            //};
            //myDict["phone"] = 022345145;
            //var keys = myDict.Keys;
            //foreach (var item in keys)
            //{
            //    Console.WriteLine($"key is : {item} and value is: {myDict[item]}");
            //}
            HashSet<int> myHashSet = new HashSet<int>() { 1,2,3,4,5};
            HashSet<int> myHashSet2 = new HashSet<int>() { 1,5,255,255,88};
            HashSet<int> numbers = new HashSet<int>();
            Console.WriteLine(myHashSet.Count);
            foreach (int i in myHashSet)
            {
                Console.WriteLine(i);
            }
              myHashSet.IntersectWith(myHashSet2);
            Console.WriteLine(myHashSet.Count); 
        }
    }
}
