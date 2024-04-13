namespace Lab_7;

static public class TuringMachine
{
    static char[] PrepareTape(string input)
    {
        return $"            {input}                ".ToCharArray();
    }
    static public string RunTwoTapeMachine(int TaskNumber, string input1, string input2, bool returnState = false, bool returnTape2 = false, bool debug = false)
    {
        var rules = Rules.GetRules(TaskNumber);
        var tape1 = PrepareTape(input1);
        if (input2 == String.Empty)
        {
            input2 = new string('_', input1.Length);
        }
        var tape2 = PrepareTape(input2);
        int head1 = 12;
        int head2 = 12;
        string state = "0";
        while (state != "A" && state != "R" && state != "F")
        {
            var currentSymbol1 = tape1[head1];
            var currentSymbol2 = tape2[head2];
            var tempRules = rules.First(r => r.Item1 == state && (
                (r.Item2[0] == '*' || r.Item2[0] == currentSymbol1) &&
                (r.Item2[1] == '*' || r.Item2[1] == currentSymbol2)
                ));
            tape1[head1] = tempRules.Item3[0];
            tape2[head2] = tempRules.Item3[1];
            var directions = tempRules.Item4;
            head1 += directions[0] == 'L' ? -1 : directions[0] == 'R' ? 1 : 0;
            head2 += directions[1] == 'L' ? -1 : directions[1] == 'R' ? 1 : 0;
            state = tempRules.Item5;
            if (debug)
            {
                Console.WriteLine(new string(tape1).Trim() + " " + head1);
                Console.WriteLine(new string(tape2).Trim() + " " + head2);
                Console.WriteLine(state);
                Console.WriteLine();
            }
        }
        tape1 = returnTape2 ? tape2 : tape1;
        return returnState ? state : new string(tape1).Trim();
    }

    static public string RunThreeTapeMachine(int TaskNumber, string input, string input2, bool returnState = false, bool debug = false)
    {
        var rules = Rules.GetRules(TaskNumber);
        var tape1 = PrepareTape(input);
        var tape2 = PrepareTape(input2);
        var tape3 = (new string(' ', 12) + new string('_', Math.Max(input.Length, input2.Length)) + new string(' ', 12)).ToCharArray();
        int head1 = 12;
        int head2 = 12;
        int head3 = 12;
        string state = "0";
        while (state != "A" && state != "R" && state != "F")
        {
            var currentSymbol1 = tape1[head1];
            var currentSymbol2 = tape2[head2];
            var currentSymbol3 = tape3[head3];
            var tempRules = rules.First(r => r.Item1 == state && (
                (r.Item2[0] == '*' || r.Item2[0] == currentSymbol1) &&
                (r.Item2[1] == '*' || r.Item2[1] == currentSymbol2) &&
                (r.Item2[2] == '*' || r.Item2[2] == currentSymbol3)
                ));
            tape1[head1] = tempRules.Item3[0];
            tape2[head2] = tempRules.Item3[1];
            tape3[head3] = tempRules.Item3[2];
            var directions = tempRules.Item4;
            head1 += directions[0] == 'L' ? -1 : directions[0] == 'R' ? 1 : 0;
            head2 += directions[1] == 'L' ? -1 : directions[1] == 'R' ? 1 : 0;
            head3 += directions[2] == 'L' ? -1 : directions[2] == 'R' ? 1 : 0;
            state = tempRules.Item5;
            if (debug)
            {
                Console.WriteLine(new string(tape1).Trim() + " " + head1);
                Console.WriteLine(new string(tape2).Trim() + " " + head2);
                Console.WriteLine(new string(tape3).Trim() + " " + head3);
                Console.WriteLine(state);
                Console.WriteLine();
            }
        }
        return returnState ? state : new string(tape3).Trim();
    }
}