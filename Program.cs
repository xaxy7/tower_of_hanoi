using System.Formats.Asn1;
using System.Globalization;

namespace tower_of_hanoi;

class Program
{
    static int[] tower = [0,1,2];
    static List<Stack<int>> stacks = [new Stack<int> (), new Stack<int> (), new Stack<int> ()];
    static void Main(string[] args)
    {

        HanoiSolverIterative(Convert.ToInt32(args[0]));
        
        // for(int i = Convert.ToInt32(args[0]); i > 0; i--)
        // {
        //     stacks[0].Push(i);
        //     // stacks[1].Push(0);
        //     // stacks[2].Push(0);
        // }
        // GenerateWholeGame(5);
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
        for(double i = 1; i <= movesNumber; i++)
        {
            GenerateWholeGame(numDisk);
            if(i % 3 == 1)
            {

                if (isOdd)
                    answer += DiskMoverIterative(tower[0], tower[2]);
                else 
                    answer += DiskMoverIterative(tower[0], tower[1]);

            }
            else if(i % 3 == 2)
            {
                if (isOdd)
                    answer += DiskMoverIterative(tower[0], tower[1]);
                else 
                    answer += DiskMoverIterative(tower[0], tower[2]);                

            }
            else if(i % 3 == 0)
            {
                if(isOdd)
                    answer += DiskMoverIterative(tower[1], tower[2]);
                else 
                    answer += DiskMoverIterative(tower[1], tower[2]);
            }

            
        }
        GenerateWholeGame(numDisk);
        return answer;
    }
    static string DiskMoverIterative(int towerA, int towerB)
    {
        string move = " ";

        if( stacks[towerB].Count == 0 || stacks[towerA].Count > 0 && stacks[towerA].Peek() < stacks[towerB].Peek())
        {
            move = $"Disk {stacks[towerA].Peek()} moved from peg number: {towerA} to peg number: {towerB} \n";
            Console.WriteLine($"Disk {stacks[towerA].Peek()} moved from peg number: {towerA} to peg number: {towerB} \n");
            stacks[towerB].Push(stacks[towerA].Pop());
        }
        else if(stacks[towerA].Count == 0 || stacks[towerB].Count > 0 && stacks[towerB].Peek() < stacks[towerA].Peek())
        {
            move = $"Disk {stacks[towerB].Peek()} moved from peg number: {towerB} to peg number: {towerA} \n";
            Console.WriteLine( $"Disk {stacks[towerB].Peek()} moved from peg number: {towerB} to peg number: {towerA} \n");
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
    static void GenerateTree(int numDisk, int i, ref int x, int LengthX, int[] arrayX)
    {
        int totalLength = numDisk * 2 +3;
        // Console.Write(totalLength);

        if(numDisk - LengthX <= i && LengthX != 0)
        {
            for(int j = 0; j < (totalLength - (arrayX[x] * 2 +1))/2; j++)
            {
                Console.Write(" ");
            }
            for(int j = 0; j < arrayX[x] * 2 +1; j++)
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

}
