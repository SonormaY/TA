namespace Lab_8;
public class RandomAccessMachine
{
    private List<int> inputString;
    private string outputString;
    private int headForInput;
    private int headForOutput;
    private List<string> commands;
    private List<int> registers;
    private Dictionary<string, int> tags;

    public RandomAccessMachine(string inputStringStr, List<string> commands)
    {
        inputString = inputStringStr.Split(' ').Select(int.Parse).ToList();
        outputString = string.Empty;
        headForInput = 0;
        headForOutput = 0;
        this.commands = commands;
        registers = new List<int> { 0 };
        tags = new Dictionary<string, int>();
        InitializeTags();
    }

    private (string, string) BreakCommandInto2Parts(string command)
    {
        var breaked = command.Split(' ', 2);
        if (breaked.Length == 1)
            return (breaked[0], null);
        else
            return (breaked[0], breaked[1].Trim());
    }

    private int? GetNumberFromCommand(string operand)
    {
        if (operand == null)
            return null;
        return int.Parse(operand.Replace("*", "").Replace("=", ""));
    }

    private bool JZERO() => registers[0] == 0;

    private bool JGTZ() => registers[0] > 0;

    private void LOAD(string operand)
    {
        int? value = GetNumberFromCommand(operand);
        if (operand.Contains("="))
            registers[0] = value.Value;
        else if (operand.Contains("*") && IsFreeAtIndex(value.Value) && IsFreeAtIndex(registers[value.Value]))
            registers[0] = registers[registers[value.Value]];
        else
            registers[0] = registers[value.Value];
    }

    private void WRITE(string operand)
    {
        int? value = GetNumberFromCommand(operand);
        if (operand.Contains("="))
            outputString += " " + value.Value;
        else if (operand.Contains("*") && IsFreeAtIndex(value.Value) && IsFreeAtIndex(registers[value.Value]))
            outputString += " " + registers[registers[value.Value]];
        else
            outputString += " " + registers[value.Value];
    }

    private void ADD(string operand)
    {
        int? value = GetNumberFromCommand(operand);
        if (operand.Contains("="))
            registers[0] += value.Value;
        else if (operand.Contains("*") && IsFreeAtIndex(value.Value) && IsFreeAtIndex(registers[value.Value]))
            registers[0] += registers[registers[value.Value]];
        else
            registers[0] += registers[value.Value];
    }

    private void SUB(string operand)
    {
        int? value = GetNumberFromCommand(operand);
        if (operand.Contains("="))
            registers[0] -= value.Value;
        else if (operand.Contains("*") && IsFreeAtIndex(value.Value) && IsFreeAtIndex(registers[value.Value]))
            registers[0] -= registers[registers[value.Value]];
        else
            registers[0] -= registers[value.Value];
    }

    private void MULT(string operand)
    {
        int? value = GetNumberFromCommand(operand);
        if (operand.Contains("="))
            registers[0] *= value.Value;
        else if (operand.Contains("*") && IsFreeAtIndex(value.Value) && IsFreeAtIndex(registers[value.Value]))
            registers[0] *= registers[registers[value.Value]];
        else
            registers[0] *= registers[value.Value];
    }

    private void DIV(string operand)
    {
        int? value = GetNumberFromCommand(operand);
        if (operand.Contains("="))
            registers[0] /= value.Value;
        else if (operand.Contains("*") && IsFreeAtIndex(value.Value) && IsFreeAtIndex(registers[value.Value]))
            registers[0] /= registers[registers[value.Value]];
        else
            registers[0] /= registers[value.Value];
    }

    private void READ(int operand)
    {
        IncreaseTheNumberOfRegisters(operand + 1);
        registers[operand] = inputString[headForInput];
        headForInput++;
    }

    private void STORE(string operand)
    {
        int? value = GetNumberFromCommand(operand);
        if (operand.Contains("*"))
        {
            IncreaseTheNumberOfRegisters(registers[value.Value] + 1);
            registers[registers[value.Value]] = registers[0];
        }
        else
        {
            IncreaseTheNumberOfRegisters(value.Value + 1);
            registers[value.Value] = registers[0];
        }
    }

    private bool IsFreeAtIndex(int i) => i < registers.Count;

    private void IncreaseTheNumberOfRegisters(int newLength)
    {
        int currentRegisters = registers.Count;
        if (newLength > currentRegisters)
            registers.AddRange(Enumerable.Repeat(0, newLength - currentRegisters));
    }
     private void InitializeTags()
    {
        int currentIndex = 0;
        foreach (var command in commands)
        {
            var (op, operand) = BreakCommandInto2Parts(command);
            if (operand == null)
            {
                tags[op] = currentIndex;
            }
            currentIndex++;
        }
    }

    public string Calculate()
    {
        int currentIndex = 0;
        while (currentIndex < commands.Count)
        {
            var (command, operand) = BreakCommandInto2Parts(commands[currentIndex]);
            switch (command)
            {
                 case "LOAD":
                    LOAD(operand);
                    break;
                case "WRITE":
                    WRITE(operand);
                    break;
                case "ADD":
                    ADD(operand);
                    break;
                case "STORE":
                    STORE(operand);
                    break;
                case "DIV":
                    DIV(operand);
                    break;
                case "MULT":
                    MULT(operand);
                    break;
                case "SUB":
                    SUB(operand);
                    break;
                case "READ":
                    int num = GetNumberFromCommand(operand) ?? 0;
                    READ(num);
                    break;
                case "JUMP":
                case "JGTZ" when JGTZ():
                case "JZERO" when JZERO():
                     int? tagIndex = null;
                    if (tags.ContainsKey(operand))
                    {
                        tagIndex = tags[operand];
                    }
                    currentIndex = GetNumberFromCommand(operand) ?? tagIndex ?? currentIndex;
                    continue;
                case "HALT":
                    break;
                default:
                    throw new InvalidOperationException($"Invalid command: {command}");
            }
            currentIndex++;
        }
        return outputString;
    }
}