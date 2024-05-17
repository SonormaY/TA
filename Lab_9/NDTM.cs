namespace Lab_9;

public class NDTM
{
  private string _tape;
  private int _head;
  private string _state;
  private bool _accepted;
  
  private Dictionary<string, Dictionary<char, List<Transition>>> transitionFunction = new Dictionary<string, Dictionary<char, List<Transition>>>()
  {
    {"q0", new Dictionary<char, List<Transition>>()
    {
      {'1', new List<Transition>(){new Transition("q0", '1', 'R')}},
      {'o', new List<Transition>(){new Transition("q0", 'o', 'R')}},
      {'0', new List<Transition>(){new Transition("q1", 'o', 'L')}},
      {' ', new List<Transition>(){new Transition("q3", ' ', 'L')}}
    }},
    {"q1", new Dictionary<char, List<Transition>>()
    {
      {'1', new List<Transition>(){new Transition("q1", '1', 'L')}},
      {'0', new List<Transition>(){new Transition("q1", '0', 'L')}},
      {'o', new List<Transition>(){new Transition("q1", 'o', 'L')}},
      {' ', new List<Transition>(){new Transition("q2", '0', 'R')}}
    }},
    {"q2", new Dictionary<char, List<Transition>>()
    {
      {'0', new List<Transition>(){new Transition("q2", '0', 'R')}},
      {'1', new List<Transition>(){new Transition("q0", '1', 'R')}}
    }},
    {"q3", new Dictionary<char, List<Transition>>()
    {
      {'o', new List<Transition>(){new Transition("q3", 'o', 'L')}},
      {'1', new List<Transition>(){new Transition("q3", '1', 'L')}},
      {'0', new List<Transition>(){new Transition("q4", 'o', 'L')}},
      {' ', new List<Transition>(){new Transition("q7", ' ', 'R')}}
    }},
    {"q4", new Dictionary<char, List<Transition>>()
    {
      {'0', new List<Transition>(){new Transition("q4", '0', 'L')}},
      {' ', new List<Transition>(){new Transition("q5", ' ', 'R')}}
    }},
    {"q5", new Dictionary<char, List<Transition>>()
    {
      {'0', new List<Transition>(){new Transition("q6", '0', 'R')}}
    }},
    {"q6", new Dictionary<char, List<Transition>>()
      {
        {'0', new List<Transition>(){new Transition("q6", '0', 'R')}},
        {'o', new List<Transition>(){new Transition("q3", '0', 'L')}}
      }},
    {"q7", new Dictionary<char, List<Transition>>()
      {
        {'0', new List<Transition>(){new Transition("q7", '0', 'R')}},
        {'o', new List<Transition>(){new Transition("q7", 'o', 'R')}},
        {'i', new List<Transition>(){new Transition("q11", 'i', 'R')}},
        {'I', new List<Transition>(){new Transition("q7", 'I', 'R')}},
        {'1', new List<Transition>(){new Transition("q7", 'I', 'R'), new Transition("q8", 'i', 'R')}},
        {' ', new List<Transition>(){new Transition("q12", ' ', 'L')}}
      }},
    {"q8", new Dictionary<char, List<Transition>>()
      {
        {' ', new List<Transition>(){new Transition("q12", ' ', 'L')}},
        {'O', new List<Transition>(){new Transition("q8", 'O', 'R')}},
        {'o', new List<Transition>(){new Transition("q9", 'O', 'L')}}
      }},
    {"q9", new Dictionary<char, List<Transition>>()
      {
        {'o', new List<Transition>(){new Transition("q9", 'o', 'L')}},
        {'O', new List<Transition>(){new Transition("q9", 'O', 'L')}},
        {'0', new List<Transition>(){new Transition("q9", '0', 'L')}},
        {'i', new List<Transition>(){new Transition("q9", 'i', 'L')}},
        {'I', new List<Transition>(){new Transition("q9", 'I', 'L')}},
        {' ', new List<Transition>(){new Transition("q10", '#', 'L')}}
      }},
    {"q10", new Dictionary<char, List<Transition>>()
      {
        {'0', new List<Transition>(){new Transition("q10", '0', 'L')}},
        {' ', new List<Transition>(){new Transition("q11", '0', 'R')}}
      }},
    {"q11", new Dictionary<char, List<Transition>>()
      {
        {'0', new List<Transition>(){new Transition("q11", '0', 'R')}},
        {'#', new List<Transition>(){new Transition("q11", '#', 'R')}},
        {'i', new List<Transition>(){new Transition("q11", 'i', 'R')}},
        {'O', new List<Transition>(){new Transition("q11", 'O', 'R')}},
        {'I', new List<Transition>(){new Transition("q11", 'I', 'R')}},
        {'o', new List<Transition>(){new Transition("q9", 'O', 'L')}},
        {'1', new List<Transition>(){new Transition("q7", '1', 'H')}},
        {' ', new List<Transition>(){new Transition("q12", ' ', 'L')}}
      }},
    {"q12", new Dictionary<char, List<Transition>>()
      {
        {'O', new List<Transition>(){new Transition("q12", 'O', 'L')}},
        {'o', new List<Transition>(){new Transition("q12", 'o', 'L')}},
        {'i', new List<Transition>(){new Transition("q12", 'i', 'L')}},
        {'I', new List<Transition>(){new Transition("q12", 'I', 'L')}},
        {'0', new List<Transition>(){new Transition("q13", ' ', 'L')}},
        {'#', new List<Transition>(){new Transition("q17", '#', 'L')}},
        {' ', new List<Transition>(){new Transition("qF", ' ', 'H')}}
      }},
    {"q13", new Dictionary<char, List<Transition>>()
      {
        {'0', new List<Transition>(){new Transition("q13", '0', 'L')}},
        {'#', new List<Transition>(){new Transition("q14", '#', 'L')}}
      }},
    {"q14", new Dictionary<char, List<Transition>>()
      {
        {'0', new List<Transition>(){new Transition("q14", '0', 'L')}},
        {' ', new List<Transition>(){new Transition("q15", ' ', 'R')}}
      }},
    {"q15", new Dictionary<char, List<Transition>>()
      {
        {'0', new List<Transition>(){new Transition("q16", '0', 'R')}}
      }},
    {"q16", new Dictionary<char, List<Transition>>()
      {
        {'0', new List<Transition>(){new Transition("q16", '0', 'R')}},
        {'#', new List<Transition>(){new Transition("q16", '#', 'R')}},
        {' ', new List<Transition>(){new Transition("q12", ' ', 'L')}}
      }},
    {"q17", new Dictionary<char, List<Transition>>()
      {
        {'#', new List<Transition>(){new Transition("q17", '#', 'L')}},
        {'0', new List<Transition>(){new Transition("q17", '0', 'L')}},
        {' ', new List<Transition>(){new Transition("qF", ' ', 'H')}}}
    }};

  public NDTM(string tape)
  {
    _tape = "o" + tape + "o";
    _head = 1;
    _state = "q0";
    _accepted = false;
  }

  public void Run()
    {
        while (_state != "qF")
        {
            char currentSymbol = _tape[_head];
            List<Transition> transitions = transitionFunction[_state][currentSymbol];

            foreach (Transition transition in transitions)
            {
                ApplyTransition(transition);
                Run();
                UndoTransition(transition);
            }

            if (transitions.Count == 0)
                break; // No transition found, halt
        }

        if (_state == "qF")
            _accepted = true;
    }

  private void ApplyTransition(Transition transition)
    {
        _state = transition.nextState;
        _tape = _tape.Substring(0, _head) + transition.symbolToWrite + _tape.Substring(_head + 1);

        if (transition.direction == 'R')
            _head++;
        else if (transition.direction == 'L')
            _head--;
    }

    private void UndoTransition(Transition transition)
    {
        if (transition.direction == 'R')
            _head--;
        else if (transition.direction == 'L')
            _head++;

        _tape = _tape.Substring(0, _head) + transition.readSymbol + _tape.Substring(_head + 1);
        _state = transition.previousState;
    }

    public bool IsAccepted()
    {
        return _accepted;
    }
  
  public struct Transition
  {
    public string nextState;
    public char symbolToWrite;
    public char direction;
    public string previousState;
    public char readSymbol;

    public Transition(string nextState, char symbolToWrite, char direction)
    {
      this.nextState = nextState;
      this.symbolToWrite = symbolToWrite;
      this.direction = direction;
      this.previousState = "";
      this.readSymbol = '\0';
    }

  }
}
