using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Hash_Maps_And_Sets
{
    internal class VerifySudokuBoard
    {
        /*
         Verify Sudoku Board
Medium
Given a partially completed 9×9 Sudoku board, determine if the current state of the board adheres to the rules of the game:

Each row and column must contain unique numbers between 1 and 9, or be empty (represented as 0).

Each of the nine 3×3 subgrids that compose the grid 
        must contain unique numbers between 1 and 9, or be empty.

Note: You are asked to determine whether the current state of the board is valid given these rules, not whether the board is solvable.

Example:
Example
Output: False
Constraints:
Assume each integer on the board falls in the range of [0, 9].
         
         */

        public bool IsValidSudoku(int[,] board)
        {

            HashSet<string> seen = new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int num = board[i, j];
                    if (num != 0)
                    {
                        string rowKey = $"row{i}-{num}";
                        string colKey = $"col{j}-{num}";

                        //box key is a different way to calculate the key for 3x3 subgrids, we can use i/3 and j/3 to get the box index
                        string boxKey = $"box{i / 3}{j / 3}-{num}";

                        if (!seen.Add(rowKey) || !seen.Add(colKey) || !seen.Add(boxKey))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
