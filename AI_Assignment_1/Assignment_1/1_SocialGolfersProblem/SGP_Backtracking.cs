﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_1._1_SocialGolfersProblem
{
    public static class SGP_Backtracking
    {
        #region Driver Method

        public static void Main_SGP_Backtracking()
        {
            int N = 5;
            int[,] board = new int[N * 8, 4];

            if (solveSGP(board, N, 0))
            {
                // print solution
                var result = GetCurrentSolutions(board, N);
                Print(result.Item1);
            }
            else
                Console.Write("No solution");
        }

        #endregion Driver Method


        #region core

        public static bool solveSGP(int[,] board, int n, int startRow = 0)
        {
            int row = -1, col = -1;
            bool isEmpty = true;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                    break;
            }

            // no empty space left
            if (isEmpty)
                return true;

            // else for each-row backtrack
            for (int num = 1; num <= 32; num++)
            {
                if (isSafe(board, row, col, num))
                {
                    board[row, col] = num;
                    if (solveSGP(board, n, row))
                        return true;
                    else
                        board[row, col] = 0; //backtrace
                }
            }
            return false;
        }

        public static bool isSafe(int[,] board, int row, int col, int num)
        {
            var kRow = 0;
            if (row == 0 && col == 0) kRow = 0;
            else
            {
                if (row % 8 == 0 && col == 0) kRow = row / 8 + 1;
                else kRow = row / 8;
            }

            var res = GetCurrentSolutions(board, kRow);
            for (int j = 0; j < res.Item2.GetLength(1); j++)
                for (int i = 0; i < res.Item2.GetLength(0); i++)
                    if (res.Item2[i, j] == num)
                    {
                        if (i == row && j == col)
                            continue;
                        else
                            return false;
                    }

            return CheckValidationInsertion(res.Item1, res.Item2);
        }

        #endregion core



        #region helper methods

        public static bool CheckValidationInsertion(List<int[,]> nodeRounds, int[,] nextNodeRound, int layer = 0)
        {
            var next = nextNodeRound;
            if (nodeRounds.Count == 0)
                layer = -1;
            else layer = nodeRounds.Count - 1;
            for (int i = 0; i < nodeRounds.Count; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var previous = GetRow(j, nodeRounds[i], layer);
                    for (int u = 0; u < 8; u++)
                    {
                        var result = CheckNode(previous, GetRow(u, next, layer), layer);
                        if (result)
                            return false;
                    }
                }
            }
            return true;
        }

        public static bool CheckNode(int[] previous, int[] next, int layer = 0)
        {
            var previosVariationsList = GetVariations<int>(4, previous.ToList());
            var nextList = GetVariations<int>(2, next.ToList());
            foreach (var rountItem in nextList)
                foreach (var item in previosVariationsList.ToList())
                    if (!rountItem.Except(item).Any())
                        return true;
            return false;
        }

        public static int[] GetRow(int row, int[,] representation, int layer = 0)
        {
            var rowData = new int[4];
            for (int i = 0; i <= 3; i++)
                rowData[i] = representation[row, i];
            return rowData;
        }

        public static (List<int[,]>, int[,]) GetCurrentSolutions(int[,] listBoard, int kRow)
        {
            bool validBoard = true; bool parseModel = true;
            List<int[,]> boardListStatus = new List<int[,]>();

            for (int i = 0; i < kRow; i++)
            {
                var modelBoard = new int[8, 4];
                for (int j = 0; j < 8; j++)
                {
                    for (int u = 0; u < 4; u++)
                    {
                        if (listBoard[i * 8 + j, u] == 0)
                            validBoard = false;
                        modelBoard[j, u] = listBoard[i * 8 + j, u];
                    }
                }
                if (!validBoard)
                    break;
                boardListStatus.Add(modelBoard);
            }

            var currentBoard = new int[8, 4];
            var length = boardListStatus.Count;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i + length * 8 == listBoard.GetLength(0)) { parseModel = false; break; }

                    currentBoard[i, j] = listBoard[i + length * 8, j];
                }
                if (!parseModel)
                    break;
            }
            return (boardListStatus, currentBoard);
        }

        public static List<List<T>> GetVariations<T>(int k, List<T> elements)
        {
            List<List<T>> result = new List<List<T>>();
            if (k == 1)
                result.AddRange(elements.Select(element => new List<T>() { element }));
            else
            {
                foreach (T element in elements)
                {
                    List<T> subelements = elements.Where(e => !e.Equals(element)).ToList();
                    List<List<T>> subvariations = GetVariations(k - 1, subelements);
                    foreach (List<T> subvariation in subvariations)
                    {
                        subvariation.Add(element);
                        result.Add(subvariation);
                    }
                }
            }
            return result;
        }

        #endregion helper methods



        #region print

        public static void Print(List<int[,]> listBoards)
        {
            int week = 1;
            foreach (var item in listBoards)
            {
                Console.WriteLine($"Week {week}:");
                for (int i = 0; i < item.GetLength(0); i++)
                {
                    Console.Write($"Group {i + 1}:\t");
                    for (int j = 0; j < item.GetLength(1); j++)
                        Console.Write(item[i, j] + "  ");
                    Console.WriteLine("");
                }
                week++;
                Console.WriteLine("\n\n");
            }
            Console.WriteLine();
        }

        #endregion print
    }
}
