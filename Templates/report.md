
# Report

Course: C# Development SS2026 (4 ECTS, 3 SWS)

Student ID: CC240142

BCC Group: A

Name: Ksawery Kochanowicz

## Methodology: 


### Iterative Solution:
For the iterative solution I used the equation for the optimal solution for Hanoi Tower.
When the number of disks is Odd:
- moveNumber % 3 == 1:
    moveDisk from Stick A to Stick C
- moveNumber % 3 == 2:
    moveDisk from Stick A to Stick B
- moveNumber % 3 == 0:
    moveDisk from Stick B to Stick C

When the number of disks is Even:
- moveNumber % 3 == 1:
    moveDisk from Stick A to Stick B
- moveNumber % 3 == 2:
    moveDisk from Stick A to Stick C
- moveNumber % 3 == 0:
    moveDisk from Stick B to Stick C

3 stacks are created, for Stick A, B and C respectevely

All disk are first inserted to the Stick A
Then amount of the optimal moves is calculated using the 2^n -1 equation
Then the program loops through the number of optimal moves, calling the DiskMover function and passing the ids of the Sticks, depending on the optimal soultion equation mentioned above.

The DiskMover checks which Stick has the smaller disk, and moves it to the Stick with the bigger one. Then it returns the description of the move.

### Recursive Solution

Recursive solution is initialized in main, by passing as arugment:
- the number of disks x2 (one as n, other as numDisk)
- the name of the Sticks (a,b,c)

The recursive function has a if statement, making the function return, when the n == 0
Then the recursive function HanoiSolverRecursive calls itself spawing the order of the sticks:
- for the first call the order is (fromRod, auxRod, toRod)
- for the second call the order is (auxRod, toRod, fromRod)

In between the 2 calls DiskMover is called, used to generate the move description, and move the disks on the stacks, which later is used to generate the ASCII art.



## Additional Features
I think all of the features I implemented are part of the requirements

## Discussion/Conclusion
Hardest part for me was the creation of the ASCII represenation of the Sticks and Disks. It was also the part I enjoyed the most, becuase it required me to be creative and do a lot of trial and error. The moment I saw the tower form properly was very satisfing.

## Work with: 
I have coded the whole project myself, but I consulted some of my colleuges to discuss different ways how we implemented the solution

## Reference: 
I have used the wikipedia page for the tower of hanoi to learn the optimal iterative solution:
https://en.wikipedia.org/wiki/Tower_of_Hanoi

