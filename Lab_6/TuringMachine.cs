namespace Lab_6;

class TuringMachine
{
    public enum State
    {
        q0, q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, qFin
    }
    public enum Direction
    {
        L, R
    }
    private readonly Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> rulesUnaryAddition = new Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> {
        { State.q0, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('X', Direction.R, State.q1) },
            { ' ', Tuple.Create(' ', Direction.R, State.qFin) }
        }},
        { State.q1, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.R, State.q1) },
            { ' ', Tuple.Create(' ', Direction.R, State.q2) }
        }},
        { State.q2, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.R, State.q2) },
            { ' ', Tuple.Create('I', Direction.L, State.q3) }
        }},
        { State.q3, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.L, State.q3) },
            { ' ', Tuple.Create(' ', Direction.L, State.q4) }
        }},
        { State.q4, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.L, State.q4) },
            { 'X', Tuple.Create('X', Direction.R, State.q0) }
        }}
    };
    public readonly Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> rulesBinaryAddition = new Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> {
        { State.q0, new Dictionary<char, Tuple<char, Direction, State>> {
            { '0', Tuple.Create('0', Direction.R, State.q0)},
            { '1', Tuple.Create('1', Direction.R, State.q0)},
            { ' ', Tuple.Create( ' ', Direction.R, State.q1)}
        }},
        { State.q1, new Dictionary<char, Tuple<char, Direction, State>> {
            { '0', Tuple.Create('0', Direction.R, State.q1)},
            { '1', Tuple.Create('1', Direction.R, State.q1)},
            { ' ', Tuple.Create(' ', Direction.L, State.q2)}
        }},
        { State.q2, new Dictionary<char, Tuple<char, Direction, State>> {
            { '0', Tuple.Create('1', Direction.L, State.q2)},
            { '1', Tuple.Create('0', Direction.L, State.q3)},
            { ' ', Tuple.Create(' ', Direction.R, State.q5)}
        }},
        { State.q3, new Dictionary<char, Tuple<char, Direction, State>> {
            { '0', Tuple.Create('0', Direction.L, State.q3)},
            { '1', Tuple.Create('1', Direction.L, State.q3)},
            { ' ', Tuple.Create(' ', Direction.L, State.q4)}
        }},
        { State.q4, new Dictionary<char, Tuple<char, Direction, State>> {
            { '0', Tuple.Create('1', Direction.R, State.q0)},
            { '1', Tuple.Create('0', Direction.L, State.q4)},
            { ' ', Tuple.Create('1', Direction.R, State.q0)}
        }},
        { State.q5, new Dictionary<char, Tuple<char, Direction, State>> {
            { '1', Tuple.Create(' ', Direction.R, State.q5)},
            { ' ', Tuple.Create(' ', Direction.R, State.qFin)}
        }}
    };
    public readonly Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> rulesUnarySubstraction = new Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> {
        { State.q0, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('X', Direction.R, State.q1)},
            { ' ', Tuple.Create(' ', Direction.R, State.q5)}
        }},
        { State.q1, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.R, State.q1)},
            { ' ', Tuple.Create(' ', Direction.R, State.q2)}
        }},
        { State.q2, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'X', Tuple.Create('X', Direction.R, State.q2)},
            { 'I', Tuple.Create('X', Direction.L, State.q3)}
        }},
        { State.q3, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'X', Tuple.Create('X', Direction.L, State.q3)},
            { ' ', Tuple.Create(' ', Direction.L, State.q4)}
        }},
        { State.q4, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.L, State.q4)},
            { 'X', Tuple.Create('X', Direction.R, State.q0)}
        }},
        { State.q5, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'X', Tuple.Create('X', Direction.R, State.q5)},
            { 'I', Tuple.Create('I', Direction.L, State.q6)}
        }},
        { State.q6, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'X', Tuple.Create(' ', Direction.R, State.qFin)}
        }}
    };
    public readonly Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> rulesUnaryMultiplication = new Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> {
        { State.q0, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.R, State.q0)},
            { ' ', Tuple.Create(' ', Direction.R, State.q1)}
        }},
        { State.q1, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.R, State.q1)},
            { ' ', Tuple.Create(' ', Direction.L, State.q2)}
        }},
        { State.q2, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.L, State.q2)},
            { ' ', Tuple.Create(' ', Direction.R, State.q3)}
        }},
        { State.q3, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'X', Tuple.Create('X', Direction.R, State.q3)},
            { 'I', Tuple.Create('X', Direction.L, State.q4)},
            { ' ', Tuple.Create(' ', Direction.L, State.q12)}
        }},
        { State.q4, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'X', Tuple.Create('X', Direction.L, State.q4)},
            { ' ', Tuple.Create(' ', Direction.L, State.q5)}
        }},
        { State.q5, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'Y', Tuple.Create('Y', Direction.L, State.q5)},
            { 'I', Tuple.Create('Y', Direction.R, State.q6)},
            { ' ', Tuple.Create(' ', Direction.R, State.q11)}
        }},
        { State.q6, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'Y', Tuple.Create('Y', Direction.R, State.q6)},
            { ' ', Tuple.Create(' ', Direction.R, State.q7)}
        }},
        { State.q7, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.R, State.q7)},
            { 'X', Tuple.Create('X', Direction.R, State.q7)},
            { ' ', Tuple.Create(' ', Direction.R, State.q8)}
        }},
        { State.q8, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.R, State.q8)},
            { ' ', Tuple.Create('I', Direction.L, State.q9)}
        }},
        { State.q9, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.L, State.q9)},
            { ' ', Tuple.Create(' ', Direction.L, State.q10)}
        }},
        { State.q10, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.L, State.q10)},
            { 'X', Tuple.Create('X', Direction.L, State.q10)},
            { ' ', Tuple.Create(' ', Direction.L, State.q5)}
        }},
        { State.q11, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'Y', Tuple.Create('I', Direction.R, State.q11)},
            { ' ', Tuple.Create(' ', Direction.R, State.q3)}
        }},
        { State.q12, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'X', Tuple.Create(' ', Direction.L, State.q12)},
            { ' ', Tuple.Create(' ', Direction.L, State.q12)},
            { 'I', Tuple.Create(' ', Direction.L, State.q13)}
        }},
        { State.q13, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create(' ', Direction.L, State.q13)},
            { ' ', Tuple.Create(' ', Direction.R, State.qFin)}
        }}
    };
    public readonly Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> rulesConverter = new Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> { 
        { State.q0, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.L, State.q0) },
            { ' ', Tuple.Create('X', Direction.R, State.q1) }
        }},
        { State.q1, new Dictionary<char, Tuple<char, Direction, State>> {
            { '0', Tuple.Create('0', Direction.R, State.q1) },
            { 'I', Tuple.Create('I', Direction.R, State.q1) },
            { '2', Tuple.Create('2', Direction.R, State.q1) },
            { '3', Tuple.Create('3', Direction.R, State.q1) },
            { '4', Tuple.Create('4', Direction.R, State.q1) },
            { '5', Tuple.Create('5', Direction.R, State.q1) },
            { '6', Tuple.Create('6', Direction.R, State.q1) },
            { '7', Tuple.Create('7', Direction.R, State.q1) },
            { '8', Tuple.Create('8', Direction.R, State.q1) },
            { '9', Tuple.Create('9', Direction.R, State.q1) },
            { 'X', Tuple.Create('X', Direction.R, State.q1) },
            { ' ', Tuple.Create(' ', Direction.L, State.q2) }
        }},
        { State.q2, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create(' ', Direction.L, State.q3) },
            { 'X', Tuple.Create(' ', Direction.L, State.qFin) }
        }},
        { State.q3, new Dictionary<char, Tuple<char, Direction, State>> {
            { 'I', Tuple.Create('I', Direction.L, State.q3) },
            { 'X', Tuple.Create('X', Direction.L, State.q4) }
        }},
        { State.q4, new Dictionary<char, Tuple<char, Direction, State>> {
            { ' ', Tuple.Create('1', Direction.R, State.q1) },
            { '0', Tuple.Create('1', Direction.R, State.q1) },
            { '1', Tuple.Create('2', Direction.R, State.q1) },
            { '2', Tuple.Create('3', Direction.R, State.q1) },
            { '3', Tuple.Create('4', Direction.R, State.q1) },
            { '4', Tuple.Create('5', Direction.R, State.q1) },
            { '5', Tuple.Create('6', Direction.R, State.q1) },
            { '6', Tuple.Create('7', Direction.R, State.q1) },
            { '7', Tuple.Create('8', Direction.R, State.q1) },
            { '8', Tuple.Create('9', Direction.R, State.q1) },
            { '9', Tuple.Create('0', Direction.L, State.q4) }
        }}
    };
    static bool ValidateString(string first, string second)
    {
        return first.All(c => c == 'I') && second.All(c => c == 'I') ||
               first.All(c => c == '0' || c == '1') && second.All(c => c == '0' || c == '1');
    }
    static string PrepareString(string first, string second)
    {
        if (!ValidateString(first, second))
        {
            throw new ArgumentException("Invalid input strings");
        }
        return new string(' ', first.Length + second.Length) + first + ' ' + second + new string(' ', (first.Length + second.Length * 2));
    }
    string FinalizeString(string tape)
    {
        return tape.Trim('X', ' ');
    }
    public Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> GetRules(int Operation = 0)
    {
        switch (Operation)
        {
            case 0:
                return rulesUnaryAddition;
            case 1:
                return rulesBinaryAddition;
            case 2:
                return rulesUnarySubstraction;
            case 3:
                return rulesUnaryMultiplication;
            case 4:
                return rulesConverter;
            default:
                throw new ArgumentException("Invalid operation");
        }
    }
    public string TuringMachineRun(string first, string second = "", int Operation = 0,  bool debug = false)
    {
        Dictionary<State, Dictionary<char, Tuple<char, Direction, State>>> rules = GetRules(Operation);
        char[] tape = PrepareString(first, second).ToCharArray();
        State currentState = State.q0;
        int i = Array.FindIndex(tape, c => c != ' ');
        while (currentState != State.qFin)
        {
            char currentSymbol = tape[i];
            tape[i] = rules[currentState][currentSymbol].Item1;
            i = rules[currentState][currentSymbol].Item2 == Direction.R ? i + 1 : i - 1;
            currentState = rules[currentState][currentSymbol].Item3;
            if (debug)
            {
                Console.WriteLine(new string(tape) + " " + currentState + " " + i);
            }
        }
        return debug ? new string(tape) : FinalizeString(new string(tape));
    }
}