string Execute(Dictionary<string, string> rules, string start, int max = 100, bool show = false)
{
    string result = start;
    int iterations = 0;

    while (iterations < max)
    {
        bool substitutionMade = false;

        foreach (var rule in rules)
        {
            if (result.Contains(rule.Key))
            {
                result = result.Replace(rule.Key, rule.Value);
                substitutionMade = true;
                break;
            }
        }
        if (show)
        {
            Console.WriteLine(result);
        }

        if (!substitutionMade)
        {
            break;
        }

        iterations++;
    }

    return result;
}

void Task1()
{
    Dictionary<string, string> rules = new Dictionary<string, string>
    {
        { "yx", "xy" },
        { "xy", "" }
    };
    string ex1 = "yxxyyxyxyxyxyxxxyxyxyyyx";
    string ex2 = "xxxyxyxxxyxy";
    Console.WriteLine("Task 1");
    Console.WriteLine($"Example ({ex1}) -> {Execute(rules, ex1)}");
    Console.WriteLine($"Example ({ex2}) -> {Execute(rules, ex2)}\n");
}

void Task2()
{
    Dictionary<string, string> rules = new Dictionary<string, string>
    {
        { "yyx", "y" },
        { "xx", "y" },
        { "yyy", "x" }
    };
    string ex1 = "yyyyyyyyyyyy";
    string ex2 = "yyxyxyyxyxyxxxyxyxxyxyxy";
    Console.WriteLine("Task 2");
    Console.WriteLine($"Example ({ex1}) -> {Execute(rules, ex1, 1000)}");
    Console.WriteLine($"Example ({ex2}) -> {Execute(rules, ex2, 1000)}\n");
}

void Task3()
{
    Dictionary<string, string> rules = new Dictionary<string, string>
    {
        { "1-1", "-0"},
        { "01", "1"},
        { "-0", ""}
    };
    string ex1 = "1111-111";
    string ex2 = "111-11111";
    Console.WriteLine("Task 3");
    Console.WriteLine($"Example ({ex1}) -> {Execute(rules, ex1)}");
    Console.WriteLine($"Example ({ex2}) -> {Execute(rules, ex2)}\n");
}

void Task4()
{
    Dictionary<string, string> rules = new Dictionary<string, string>
    {
        { "1+1", "11+0"},
        { "01", "1"},
        { "+0", ""}
    };
    string ex1 = "1111+111";
    string ex2 = "111+11111";
    Console.WriteLine("Task 4");
    Console.WriteLine($"Example ({ex1}) -> {Execute(rules, ex1)}");
    Console.WriteLine($"Example ({ex2}) -> {Execute(rules, ex2)}\n");
}

void Task5()
{
    Dictionary<string, string> rules = new Dictionary<string, string>
    {
        { "*11", "T*1"},
        { "*1", "T"},
        { "1T", "T1F"},
        { "FT", "TF"},
        { "F1", "1F"},
        { "T1", "T"},
        { "TF", "F"},
        { "F", "1"}
    };
    string ex1 = "111*1111";
    Console.WriteLine("Task 5");
    Console.WriteLine($"Example ({ex1}) -> {Execute(rules, ex1, show: true)}\n");
}

void Task6()
{
    //Скласти нормальний алгоритм, який видаляє всі входження, крім першого, букви а з рядка символів, побудованого в алфавіті А={a, b, c}.
    Dictionary<string, string> rules = new Dictionary<string, string>
    {
        { "a", "T"}
    };
    string ex1 = "acaabaa";
    string ex2 = "bacabac";
    Console.WriteLine("Task 6");
    Console.WriteLine($"Example ({ex1}) -> {Execute(rules, ex1)}");
    Console.WriteLine($"Example ({ex2}) -> {Execute(rules, ex2)}\n");
}

void Task7()
{
    Dictionary<string, string> rules = new Dictionary<string, string>
    {
        { "  ", " "}
    };
    string ex1 = "a  a b  a  b c  c ";
    string ex2 = "ab a ab c c  c  b";
    string ex3 = "a  b  c  a  b  c";
    Console.WriteLine("Task 7");
    Console.WriteLine($"Example ({ex1}) -> {Execute(rules, ex1)}");
    Console.WriteLine($"Example ({ex2}) -> {Execute(rules, ex2)}");
    Console.WriteLine($"Example ({ex3}) -> {Execute(rules, ex3)}\n");
}



Console.Clear();
Task1();
Task2();
Task3();
Task4();
Task5();
Task6();
Task7();