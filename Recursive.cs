// using System.Formats.Asn1;
// using System.Globalization;

// namespace tower_of_hanoi;

// class Recursive
// {
//     static int[] tower = [0,1,2];
//     static List<Stack<int>> stacks = [new Stack<int> (), new Stack<int> (), new Stack<int> ()];
//     static void Main(string[] args)
//     {
//         int a,b,c;
//         a =0; b =1; c= 2;
//         for(int i = Convert.ToInt32(args[0]); i > 0; i--)
//         {
//             stacks[0].Push(i);

//         }
//         // HanoiSolverIterative(Convert.ToInt32(args[0]));
//         HanoiSolverRecursive(Convert.ToInt32(args[0]),a,c,b,Convert.ToInt32(args[0]) );
//     }

    
//     static void HanoiSolverRecursive(int n,int fromRod, int toRod, int auxRod, int numDisk)
//     {
 
//         if(n == 0)
//         {
            
//             return;
//         }
//         HanoiSolverRecursive(n-1,fromRod, auxRod, toRod, numDisk );
//         DiskMover(fromRod, toRod);
//         GenerateWholeGame(numDisk);
//         HanoiSolverRecursive(n-1,auxRod, toRod, fromRod, numDisk);
//     }
//     static string DiskMover(int towerA, int towerB)
//     {
//         string move = " ";

//         if( stacks[towerB].Count == 0 || stacks[towerA].Count > 0 && stacks[towerA].Peek() < stacks[towerB].Peek())
//         {
//             move = $"Disk {stacks[towerA].Peek()} moved from peg number: {towerA} to peg number: {towerB} \n";
//             Console.WriteLine($"Disk {stacks[towerA].Peek()} moved from peg number: {towerA} to peg number: {towerB} \n");
//             stacks[towerB].Push(stacks[towerA].Pop());
//         }
//         else if(stacks[towerA].Count == 0 || stacks[towerB].Count > 0 && stacks[towerB].Peek() < stacks[towerA].Peek())
//         {
//             move = $"Disk {stacks[towerB].Peek()} moved from peg number: {towerB} to peg number: {towerA} \n";
//             Console.WriteLine( $"Disk {stacks[towerB].Peek()} moved from peg number: {towerB} to peg number: {towerA} \n");
//             stacks[towerA].Push(stacks[towerB].Pop());
//         }
//         else return "error";
//         return move;

//     }
//     static void GenerateWholeGame(int numDisk)
//     {
   
//         int[] arrayA = stacks[0].ToArray();
//         int[] arrayB = stacks[1].ToArray();
//         int[] arrayC = stacks[2].ToArray();

//         int a = 0;
//         int b = 0;
//         int c = 0;
//         // Console.WriteLine(" ");
//         for(int i = 0; i < numDisk; i++)
//         {
 
//             Console.Write("|");
//             GenerateTreeWithNumbers(numDisk, i, ref a, arrayA.Length, arrayA );
//             Console.Write("|");
//             GenerateTreeWithNumbers(numDisk, i, ref b, arrayB.Length, arrayB );
//             Console.Write("|");
//             GenerateTreeWithNumbers(numDisk, i, ref c, arrayC.Length, arrayC );
//             Console.Write("|");
//             Console.WriteLine();
//             // Console.Write($"a: {a} b: {b} c: {c}");
//         }
//         // Console.WriteLine(" ");

//     }
//     static void GenerateTreeWithNumbers(int numDisk, int i, ref int x, int LengthX, int[] arrayX)
//     {
//         int totalLength = numDisk * 2 +3;
//         // Console.Write(totalLength);

//         if(numDisk - LengthX <= i && LengthX != 0)
//         {
//             for(int j = 0; j < (totalLength - (arrayX[x] * 2 +1))/2; j++)
//             {
//                 Console.Write(" ");
//             }
//             for(int j = 0; j < (arrayX[x] * 2 +1)/2; j++)
//             {
//                 Console.Write("*");
//             }
//             Console.Write(arrayX[x]);
//             for(int j = 0; j < (arrayX[x] * 2 + 1) / 2; j++)
//             {
//                 Console.Write("*");
//             }
//             for(int j = (totalLength - (arrayX[x] * 2 +1))/2 + (arrayX[x]*2 +1); j < totalLength ; j++)
//             {
//                 Console.Write($" ");
//             }
//             x++;
//         }
//         else
//         {
//             for(int j = 0; j < totalLength; j++)
//             {
//                 Console.Write(" ");
//             }
//         }
//     }


// }
