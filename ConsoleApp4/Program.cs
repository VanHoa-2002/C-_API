using System.Diagnostics;
using System.Text;

namespace Delegate
{
    internal class Program
    {
        delegate int MyDelegete(string s);

        static void Main(string[] args)
        { 
            Console.OutputEncoding = Encoding.Unicode;
            MyDelegete convertToInt = new MyDelegete(ConvertStringToInt);
            MyDelegete ShowStringDel = new MyDelegete(ShowStringFunc);
            MyDelegete multiCast =   ShowStringDel + convertToInt;
            MyDelegete callBackDel = new MyDelegete(showTen); // CALLBACL TRONG DELEGATE
            string numberStr = "385553255";
            int rsConvert = multiCast(numberStr);
            Console.WriteLine(rsConvert);
            TypeName(callBackDel);
        }
       static int ConvertStringToInt(string s)
        {
            int val = 0;
            Int32.TryParse(s, out val);
            //Console.WriteLine("Đã ép kiểu thành công: {0}", s);
            return val;
        }
        static int ShowStringFunc(string stringVal)
        {
            //Console.WriteLine(stringVal);
            return 0;
        }
        static int TypeName (MyDelegete showTen)
        {
            Console.WriteLine("Nhap ten");
            string ten = Console.ReadLine();
            showTen(ten);
            return 0;
        }
        static int showTen (string str)
        {
            Console.WriteLine(str);
                return 0;
        }
    }
} 
