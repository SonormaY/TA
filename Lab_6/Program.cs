using System.Text;

static string AddUnary(string input)
{
    int slashIndex = input.IndexOf('/');
    string num1 = input.Substring(0, slashIndex);
    string num2 = input.Substring(slashIndex + 1);

    StringBuilder sb = new StringBuilder();
    sb.Append(num1);
    sb.Append(num2);

    return sb.ToString();
}

static string AddBinary(string num1, string num2)
{
    int len1 = num1.Length;
    int len2 = num2.Length;
    int maxLen = Math.Max(len1, len2);

    num1 = new string('0', maxLen - len1) + num1;
    num2 = new string('0', maxLen - len2) + num2;

    int carry = 0;
    string sum = "";

    StringBuilder sb = new StringBuilder();

    for (int i = maxLen - 1; i >= 0; i--)
    {
        int digit1 = num1[i] - '0';
        int digit2 = num2[i] - '0';
        int digitSum = digit1 + digit2 + carry;

        sb.Insert(0, digitSum % 2);
        carry = digitSum / 2;
    }

    if (carry == 1)
        sb.Insert(0, "1");

    sum = sb.ToString();

    return sum;
}

static string SubtractUnary(string input)
{
    int slashIndex = input.IndexOf('/');
    string num1 = input.Substring(0, slashIndex);
    string num2 = input.Substring(slashIndex + 1);

    StringBuilder sb = new StringBuilder(num1);

    foreach (char c in num2)
    {
        if (sb.Length > 0)
            sb.Remove(sb.Length - 1, 1);
    }

    return sb.ToString();
}

static string MultiplyUnary(string input)
{
    int slashIndex = input.IndexOf('/');
    string num1 = input.Substring(0, slashIndex);
    string num2 = input.Substring(slashIndex + 1);

    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < num1.Length; i++)
    {
        sb.Append(num2);
    }

    return sb.ToString();
}

static int ConvertUnaryToDecimal(string input)
{
    return input.Length;
}

Console.WriteLine($"Addition of Unary 'III/III':{AddUnary("III/III")}");
Console.WriteLine($"Addition of Binary '101' and '11':{AddBinary("101", "11")}");
Console.WriteLine($"Subtraction of Unary 'IIIIII/II':{SubtractUnary("IIIIII/II")}");
Console.WriteLine($"Multiplication of Unary 'III/II':{MultiplyUnary("III/II")}");
Console.WriteLine($"Conversion of Unary 'IIIIII' to Decimal:{ConvertUnaryToDecimal("IIIIII")}");

