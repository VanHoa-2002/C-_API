namespace Delegate_event
{
    delegate void UpdateNameHandle(string name);
    internal class Program
    {
        static void Main(string[] args)
        {
            Student hs = new Student();
            hs.Name = "Kteam";
            hs.NameChanged += Hs_NameChanged;
            Console.WriteLine("Ten tu class:" + hs.Name);
            hs.Name = "hahahaha";
            Console.WriteLine("Ten tu class:" + hs.Name);
        }

        private static void Hs_NameChanged(string name)
        {
            Console.WriteLine("Ten moi:" + name);


        }

        class Student
        {
            public event UpdateNameHandle NameChanged;
            private string name;
            public string Name
            {
                get => name;
                set
                {
                    name = value;
                    if (NameChanged != null)
                    {
                        NameChanged(Name);
                    }
                }
            }
        }
    }
}
