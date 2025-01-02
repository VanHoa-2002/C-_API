using System.Text;
namespace LabUtils;

public static class ConvertMoneyToTextLib
{
    private static readonly string[] Units = { "", "nghìn", "triệu", "tỷ" };
    private static readonly string[] NumberText = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

    public static string ConvertMoneyToText(long amount)
    {
        if (amount == 0) return "không đồng";
        if (amount < 0) return "âm " + ConvertMoneyToText(-amount);

        string result = "";
        int unitIndex = 0;

        while (amount > 0)
        {
            int segment = (int)(amount % 1000);
            amount /= 1000;

            if (segment > 0)
            {
                result = ConvertSegment(segment) + " " + Units[unitIndex] + " " + result;
            }

            unitIndex++;
        }

        return result.Trim() + "đồng";
    }

    private static string ConvertSegment(int number)
    {
        string result = "";

        int hundreds = number / 100;
        int tens = (number % 100) / 10;
        int units = number % 10;

        if (hundreds > 0)
            result += NumberText[hundreds] + " trăm ";

        if (tens > 1)
            result += NumberText[tens] + " mươi ";
        else if (tens == 1)
            result += "mười ";

        if (units > 0)
        {
            if (tens > 1 && units == 1)
                result += "mốt";
            else if (units == 5 && tens > 0)
                result += "lăm";
            else
                result += NumberText[units];
        }
        else if (tens == 0 && hundreds > 0)
        {
            result += "linh ";
        }

        return result.Trim();
    }
}
