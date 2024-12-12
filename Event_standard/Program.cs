using System.Text;

namespace Event_standard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Student student = new Student();
            student.NameChanged += Student_NameChanged;
            student.Name = "Change 1 time";
            student.Name = "Change 2 time";
            student.Name = "Change 3 time";
            Console.ReadLine();

        }

        private static void Student_NameChanged(object? sender, EvenNameArgChange e)
        {
            Console.WriteLine("Change Name:"+e.Name);
        }
    }
    class Student
    {
        private string _name;
        public string Name
        {
            get => _name; set
            {
                _name = value;
                OnchangeName(value);
            }
        }

        private event EventHandler<EvenNameArgChange> _NameChanged;
        public event EventHandler<EvenNameArgChange> NameChanged
        {
            add { _NameChanged += value; }
            remove { _NameChanged -= value; }
        }
        void OnchangeName(string name)
        {
            if (_NameChanged != null)
            {
                _NameChanged(this, new EvenNameArgChange(name));
            }

        }
    }
    class EvenNameArgChange : EventArgs
    {
        public string Name { get; set; }
        public EvenNameArgChange(string name)
        {
           Name = name;
        }
    }
}