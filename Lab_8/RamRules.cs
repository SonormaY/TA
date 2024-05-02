namespace Lab_8;

public class RamRules
{
    private static List<string> Task1Rules = new()
    {
        "LOAD =5",
        "STORE 1",
        "READ 0",
        "JZERO 9",
        "STORE *1",
        "LOAD 1",
        "ADD =1",
        "STORE 1",
        "JUMP 2",
        "LOAD 1",
        "SUB =1",
        "STORE 1",
        "LOAD =5",
        "STORE 2",
        "LOAD =4",
        "STORE 3",
        "LOAD 3",
        "ADD =1",
        "STORE 3",
        "LOAD =4",
        "STORE 4",
        "LOAD 3",
        "SUB 1",
        "SUB =1",
        "JZERO 35",
        "LOAD 4",
        "ADD =1",
        "STORE 4",
        "LOAD *3",
        "SUB *4",
        "JGTZ 44",
        "LOAD 1",
        "SUB 4",
        "JGTZ 25",
        "JZERO 16",
        "LOAD 1",
        "WRITE *0",
        "SUB =1",
        "STORE 1",
        "LOAD 1",
        "SUB 2",
        "ADD =1",
        "JGTZ 35",
        "HALT",
        "LOAD *3",
        "ADD *4",
        "STORE *4",
        "LOAD *4",
        "SUB *3",
        "STORE *3",
        "LOAD *4",
        "SUB *3",
        "STORE *4",
        "JUMP 31"
    };
    private static List<string> Task2Rules = new()
    {
        "READ 3",
        "LOAD 3",
        "JZERO 13",
        "SUB =1",
        "JZERO 9",
        "LOAD 1",
        "ADD =1",
        "STORE 1",
        "JUMP 12",
        "LOAD 2",
        "ADD =1",
        "STORE 2",
        "JGTZ 0",
        "LOAD 2",
        "MULT 2",
        "SUB 1",
        "JZERO 19",
        "WRITE =0",
        "JUMP 20",
        "WRITE =1",
        "HALT"
    };
    private static List<string> Task3Rules = new()
    {
        "READ 0",
        "STORE 1",
        "STORE 2",
        "LOAD =1",
        "STORE 3",
        "LOAD 2",
        "JZERO 23",
        "DIV =2",
        "MULT =2",
        "STORE 4",
        "LOAD 2",
        "SUB 4",
        "JZERO 16",
        "LOAD 3",
        "MULT 1",
        "STORE 3",
        "LOAD 2",
        "DIV =2",
        "STORE 2",
        "LOAD 1",
        "MULT 0",
        "STORE 1",
        "JUMP 5",
        "WRITE 3",
        "HALT"
    };
    private static List<string> Task4Rules = new()
    {
        "READ 0",  
        "STORE 1", 
        "LOAD =2", 
        "STORE 2", 
        "INPUT_LOOP",
        "READ *2", 
        "STORE *2",
        "LOAD 2",
        "ADD =1",
        "STORE 2",
        "LOAD 2", 
        "SUB 1",  
        "JGTZ INPUT_LOOP",
        "LOAD =2",  
        "STORE 2",  
        "OPERATION_LOOP",
        "LOAD *2",  
        "STORE *2", 
        "LOAD 2",  
        "ADD =1",  
        "STORE 2", 
        "LOAD 2",  
        "SUB 1",  
        "JGTZ OPERATION_LOOP",
        "LOAD =2",  
        "STORE 2",  
        "OUTPUT_LOOP",
        "LOAD *2",  
        "WRITE *0", 
        "LOAD 2",  
        "ADD =1",  
        "STORE 2", 
        "LOAD 2",  
        "SUB 1",  
        "JGTZ OUTPUT_LOOP",
        "HALT"
    };
    private static List<string> Task5Rules = new()
    {
        "READ 0", 
        "STORE 1",
        "LOAD =0",
        "STORE 2",
        "STORE 3",
        "LOOP_START", 
        "LOAD 3", 
        "ADD =1", 
        "STORE 3",
        "LOAD 3", 
        "SUB 1", 
        "JGTZ LOOP_END",
        "READ *3", 
        "LOAD *3", 
        "JGTZ POSITIVE_NUMBER",
        "LOAD 2", 
        "ADD =1", 
        "STORE 2",
        "POSITIVE_NUMBER",
        "JUMP LOOP_START",
        "LOOP_END",
        "WRITE 2",
        "HALT"
    };
    public static List<string> GetCommands(int choice)
    {
        switch (choice)
        {
            case 1:
                return Task1Rules;
            case 2:
                return Task2Rules;
            case 3:
                return Task3Rules;
            case 4: 
                return Task4Rules;
            case 5:
                return Task5Rules;
            default:
                return null;
        }
    }
}