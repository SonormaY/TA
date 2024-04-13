namespace Lab_7;

static class Rules
{
    readonly static public Tuple<string, string, string, string, string>[] palindromeRules =
    {
        Tuple.Create("0", "1_", "11", "RR", "0"),
        Tuple.Create("0", "0_", "00", "RR", "0"),
        Tuple.Create("0", "  ", "  ", "LL", "1"),
        Tuple.Create("1", "11", "11", "LS", "1"),
        Tuple.Create("1", "00", "00", "LS", "1"),
        Tuple.Create("1", "01", "01", "LS", "1"),
        Tuple.Create("1", "10", "10", "LS", "1"),
        Tuple.Create("1", " 1", " 1", "RS", "2"),
        Tuple.Create("1", " 0", " 0", "RS", "2"),
        Tuple.Create("2", "11", "11", "RL", "2"),
        Tuple.Create("2", "00", "00", "RL", "2"),
        Tuple.Create("2", "10", "10", "SS", "R"),
        Tuple.Create("2", "01", "01", "SS", "R"),
        Tuple.Create("2", "1_", "1_", "SS", "R"),
        Tuple.Create("2", "0_", "0_", "SS", "R"),
        Tuple.Create("2", "  ", "  ", "SS", "A")

    };
    readonly static public Tuple<string, string, string, string, string>[] binaryAdditionRules = 
    {
        Tuple.Create("0", "00_", "00_", "RRR", "0"),
        Tuple.Create("0", "01_", "01_", "RRR", "0"),
        Tuple.Create("0", "10_", "10_", "RRR", "0"),
        Tuple.Create("0", "11_", "11_", "RRR", "0"),
        Tuple.Create("0", " 1_", " 1_", "SRR", "0"),
        Tuple.Create("0", " 0_", " 0_", "SRR", "0"),
        Tuple.Create("0", "1 _", "1 _", "RSR", "0"),
        Tuple.Create("0", "0 _", "0 _", "RSR", "0"),
        Tuple.Create("0", "   ", "   ", "LLL", "1"),
        Tuple.Create("1", "00_", "000", "LLL", "1"),
        Tuple.Create("1", "01_", "011", "LLL", "1"),
        Tuple.Create("1", "10_", "101", "LLL", "1"),
        Tuple.Create("1", "11_", "110", "LLL", "2"),
        Tuple.Create("1", " 1_", " 11", "LLL", "1"),
        Tuple.Create("1", " 0_", " 00", "LLL", "1"),
        Tuple.Create("1", "1 _", "1 1", "LLL", "1"),
        Tuple.Create("1", "0 _", "0 0", "LLL", "1"),
        Tuple.Create("1", "  _", "  _", "SSS", "F"),
        Tuple.Create("2", "00_", "001", "LLL", "1"),
        Tuple.Create("2", "01_", "010", "LLL", "2"),
        Tuple.Create("2", "10_", "100", "LLL", "2"),
        Tuple.Create("2", "11_", "111", "LLL", "2"),
        Tuple.Create("2", " 1_", " 10", "LLL", "2"),
        Tuple.Create("2", " 0_", " 01", "LLL", "1"),
        Tuple.Create("2", "1 _", "1 0", "LLL", "2"),
        Tuple.Create("2", "0 _", "0 1", "LLL", "1"),
        Tuple.Create("2", "   ", "  1", "SSS", "F")

    };
    readonly static public Tuple<string, string, string, string, string>[] nSquaredRules = 
    {
        Tuple.Create("0", "X ", "X ", "SS", "F"),
        Tuple.Create("0", "I*", "I ", "SS", "1"),

        Tuple.Create("1", "I*", "II", "RR", "1"),
        Tuple.Create("1", "X*", "XI", "RR", "1"),
        Tuple.Create("1", "  ", "  ", "LS", "2"),

        Tuple.Create("2", "I ", "X ", "LS", "3"),
        Tuple.Create("2", "X ", "X ", "LS", "2"),

        Tuple.Create("3", "I ", "I ", "LS", "3"),
        Tuple.Create("3", "  ", "  ", "RS", "0"),
    };

    public static Tuple<string, string, string, string, string>[] GetRules(int TaskNumber)
    {
        return TaskNumber switch
        {
            1 => palindromeRules,
            2 => binaryAdditionRules,
            3 => nSquaredRules,
            _ => throw new NotImplementedException(),
        };
    }
}