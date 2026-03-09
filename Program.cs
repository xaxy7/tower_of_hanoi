using System.Formats.Asn1;
using System.Globalization;

namespace tower_of_hanoi;

class Program
{
    static int[] tower = [0,1,2];
    static List<Stack<int>> stacks = [new Stack<int> (), new Stack<int> (), new Stack<int> ()];
    static int moveLogStartRow = 0;
    static int moveLogHeight = 8;
    static int currentLogLine = 0;
    static readonly object consoleLock = new();
    static void Main(string[] args)
    {
        int a = 0; int b = 1; int c = 2;

        var cmd = Environment.GetCommandLineArgs();
        int numDisk = Convert.ToInt32(args[1]);

        moveLogStartRow = numDisk + 1;
        moveLogHeight = 8; // or any small fixed value
        currentLogLine = 0;

        Console.CursorVisible = false;
        Console.Clear();
        if (cmd.Contains("-Recursive"))
        {
            for(int i = Convert.ToInt32(args[1]); i > 0; i--)
                {
                    stacks[0].Push(i);
                }
                HanoiSolverRecursive(Convert.ToInt32(args[1]),a,c,b,Convert.ToInt32(args[1]) );
                
        }else if(cmd.Contains("-Iterative")){
                HanoiSolverIterative(Convert.ToInt32(args[1]));
        }

        Console.CursorVisible = true;

    }

    static string HanoiSolverIterative(int numDisk)
    {
        string answer = "";
        bool isOdd = false;
        if(numDisk % 2 != 0)
        {
            isOdd = true;
        }
        double movesNumber = Math.Pow(2, Convert.ToDouble(numDisk)) -1; 
 
        if(numDisk == 0)
        {
            Console.Write("For Zero disk the optimal solution is 0 moves");
            return "";
        }
        else Console.WriteLine($"The optimal number of moves is: {movesNumber}");
        for(int i = numDisk; i > 0; i--)
        {
            stacks[0].Push(i);

        }
        RenderFrame(numDisk);
        for(double i = 1; i <= movesNumber; i++)
        {
            string moveText = "";
            if(i % 3 == 1)
            {

                if (isOdd)
                    moveText += DiskMover(tower[0], tower[2]);
                else 
                    moveText += DiskMover(tower[0], tower[1]);

            }
            else if(i % 3 == 2)
            {
                if (isOdd)
                    moveText += DiskMover(tower[0], tower[1]);
                else 
                    moveText += DiskMover(tower[0], tower[2]);                

            }
            else if(i % 3 == 0)
            {
                if(isOdd)
                    moveText += DiskMover(tower[1], tower[2]);
                else 
                    moveText += DiskMover(tower[1], tower[2]);
            }
  
            answer +=  moveText;
            moveText =  $"Move Number {i}: " + moveText;
            RenderFrame(numDisk, moveText);
            
        }
        return answer;
    }
    static void HanoiSolverRecursive(int n,int fromRod, int toRod, int auxRod, int numDisk)
    {
 
        if(n == 0)
        {
            
            return;
        }
        HanoiSolverRecursive(n-1,fromRod, auxRod, toRod, numDisk );
        string moveText = DiskMover(fromRod, toRod);
        RenderFrame(numDisk, moveText);
        HanoiSolverRecursive(n-1,auxRod, toRod, fromRod, numDisk);
    }
    static string DiskMover(int towerA, int towerB)
    {
        string move = " ";

        if( stacks[towerB].Count == 0 || stacks[towerA].Count > 0 && stacks[towerA].Peek() < stacks[towerB].Peek())
        {
            move = $"Disk {stacks[towerA].Peek()} moved from peg number: {towerA} to peg number: {towerB} \n";
            //  Console.WriteLine($"Disk {stacks[towerA].Peek()} moved from peg number: {towerA} to peg number: {towerB} \n");
            stacks[towerB].Push(stacks[towerA].Pop());
        }
        else if(stacks[towerA].Count == 0 || stacks[towerB].Count > 0 && stacks[towerB].Peek() < stacks[towerA].Peek())
        {
            move = $"Disk {stacks[towerB].Peek()} moved from peg number: {towerB} to peg number: {towerA} \n";
            //  Console.WriteLine( $"Disk {stacks[towerB].Peek()} moved from peg number: {towerB} to peg number: {towerA} \n");
            stacks[towerA].Push(stacks[towerB].Pop());
        }
        else return "error";
        return move;

    }
    static void GenerateWholeGame(int numDisk)
    {
   
        int[] arrayA = stacks[0].ToArray();
        int[] arrayB = stacks[1].ToArray();
        int[] arrayC = stacks[2].ToArray();

        int a = 0;
        int b = 0;
        int c = 0;
        // Console.WriteLine(" ");
        for(int i = 0; i < numDisk; i++)
        {
 
            Console.Write("|");
            GenerateTreeWithNumbers(numDisk, i, ref a, arrayA.Length, arrayA );
            Console.Write("|");
            GenerateTreeWithNumbers(numDisk, i, ref b, arrayB.Length, arrayB );
            Console.Write("|");
            GenerateTreeWithNumbers(numDisk, i, ref c, arrayC.Length, arrayC );
            Console.Write("|");
            Console.WriteLine();
            // Console.Write($"a: {a} b: {b} c: {c}");
        }
        // Console.WriteLine(" ");

    }
    static void GenerateTreeWithNumbers(int numDisk, int i, ref int x, int LengthX, int[] arrayX)
    {
        int totalLength = numDisk * 2 +3;
        // Console.Write(totalLength);

        if(numDisk - LengthX <= i && LengthX != 0)
        {
            for(int j = 0; j < (totalLength - (arrayX[x] * 2 +1))/2; j++)
            {
                Console.Write(" ");
            }
            for(int j = 0; j < (arrayX[x] * 2 +1)/2; j++)
            {
                Console.Write("*");
            }
            Console.Write(arrayX[x]);
            for(int j = 0; j < (arrayX[x] * 2 + 1) / 2; j++)
            {
                Console.Write("*");
            }
            for(int j = (totalLength - (arrayX[x] * 2 +1))/2 + (arrayX[x]*2 +1); j < totalLength ; j++)
            {
                Console.Write($" ");
            }
            x++;
        }
        else
        {
            for(int j = 0; j < totalLength; j++)
            {
                Console.Write(" ");
            }
        }
    }
    static void RenderFrame(int numDisk, string? moveText = null, int delayMs = 200)
    {
        lock (consoleLock)
        {
            int boardTop = 0;
            int boardHeight = numDisk;
            int logTop = moveLogStartRow;

            // Redraw board
            Console.SetCursorPosition(0, boardTop);
            GenerateWholeGame(numDisk);

            // Write move text into a fixed log window
            if (!string.IsNullOrWhiteSpace(moveText))
            {
                int row = logTop + currentLogLine;

                // If log window is full, clear it and start again at the top
                if (currentLogLine >= moveLogHeight)
                {
                    for (int i = 0; i < moveLogHeight; i++)
                    {
                        Console.SetCursorPosition(0, logTop + i);
                        Console.Write(new string(' ', Console.BufferWidth -     1));
                    }

                    currentLogLine = 0;
                    row = logTop;
                }

                Console.SetCursorPosition(0, row);
                Console.Write(new string(' ', Console.BufferWidth - 1));
                Console.SetCursorPosition(0, row);
                Console.Write(moveText.TrimEnd());

                currentLogLine++;
            }

            Thread.Sleep(delayMs);
        }
    }
}
