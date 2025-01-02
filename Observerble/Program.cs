using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Observerbletest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> obs = new ObservableCollection<string>();
            obs.CollectionChanged += change;
            obs.Add("a");
            obs.Add("b");
            obs.Add("c");
            obs.Add("d");
            obs.Remove("a");
            obs.Clear();

        }
        private static void change (object sender , NotifyCollectionChangedEventArgs action)
        {
            switch (action.Action)
            {

                case NotifyCollectionChangedAction.Add:
                    foreach (String newitem in action.NewItems)
                    {
                        Console.WriteLine(newitem);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                        Console.WriteLine("Clear");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (string newitem in action.OldItems)
                    {
                        Console.WriteLine("remove: " + newitem);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
