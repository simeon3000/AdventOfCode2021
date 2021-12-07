using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day4
    {
        private const string file = @"c:\temp\day4.txt";
        private static readonly List<string> input;

        static Day4()
        {
            input = Helper.GetInputLines(file);
        }

        private static void ReadInput(List<string> input, out List<BoardNumber[,]> playersBoards, out List<int> bingoNumbers)
        {
            bingoNumbers = input[0].Split(',').Select(x => int.Parse(x)).ToList();

            var tempList = new List<List<BoardNumber>>();
            for (int i = 1; i < input.Count; i++)
            {
                if (String.IsNullOrEmpty(input[i]))
                {
                    continue;
                }

                List<int> lineNumbers = input[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

                var tempRow = new List<BoardNumber>();
                foreach (int num in lineNumbers)
                {
                    tempRow.Add(new BoardNumber { Value = num });
                }

                tempList.Add(tempRow);
            }

            playersBoards = new List<BoardNumber[,]>();

            while (tempList.Count > 0)
            {
                var board = new BoardNumber[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        board[i, j] = tempList[i][j];
                    }
                }

                playersBoards.Add(board);
                tempList = tempList.Skip(5).ToList();
            }
        }

        public static void Run1()
        {
            List<BoardNumber[,]> playersBoards;
            List<int> bingoNumbers;
            ReadInput(input, out playersBoards, out bingoNumbers);

            bool isDone = false;

            foreach (int number in bingoNumbers)
            {
                if (isDone)
                {
                    break;
                }

                foreach (BoardNumber[,] board in playersBoards)
                {
                    if (isDone)
                    {
                        break;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        int rowCnt = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            if (board[i, j].IsChecked)
                            {
                                rowCnt++;
                            }
                            if (board[i, j].Value == number)
                            {
                                board[i, j].IsChecked = true;
                                rowCnt++;
                            }
                        }
                        if (rowCnt == 5)
                        {
                            CalcResult(board, number);
                            isDone = true;
                            break;
                        }
                    }

                    if (!isDone)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int colCnt = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                if (board[j, i].IsChecked)
                                {
                                    colCnt++;
                                }
                            }
                            if (colCnt == 5)
                            {
                                CalcResult(board, number);
                                isDone = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static void Run2()
        {
            List<BoardNumber[,]> playersBoards;
            List<int> bingoNumbers;
            ReadInput(input, out playersBoards, out bingoNumbers);

            foreach (int number in bingoNumbers)
            {
                bool isDone = false;
                List<BoardNumber[,]> boardsToRemove = new List<BoardNumber[,]>();

                while (playersBoards.Count > 0)
                {                    
                    isDone = false;

                    foreach (BoardNumber[,] board in playersBoards)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int rowCnt = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                if (board[i, j].IsChecked)
                                {
                                    rowCnt++;
                                }
                                if (board[i, j].Value == number)
                                {
                                    board[i, j].IsChecked = true;
                                    rowCnt++;
                                }
                            }
                            if (rowCnt == 5)
                            {
                                boardsToRemove.Add(board);
                                isDone = true;
                                break;
                            }
                        }

                        if (!isDone)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                int colCnt = 0;
                                for (int j = 0; j < 5; j++)
                                {
                                    if (board[j, i].IsChecked)
                                    {
                                        colCnt++;
                                    }
                                }
                                if (colCnt == 5)
                                {
                                    boardsToRemove.Add(board);
                                    isDone = true;
                                    break;
                                }
                            }
                        }
                    }                    

                    break;
                }                

                if (isDone && playersBoards.Count == boardsToRemove.Count)
                {
                    BoardNumber[,] lastBoard = boardsToRemove.Last();
                    CalcResult(lastBoard, number);
                    break;
                }

                if (isDone && playersBoards.Count > 0)
                {
                    playersBoards = playersBoards.Except(boardsToRemove).ToList();
                }
            }
        }


        private static void CalcResult(BoardNumber[,] board, int number)
        {
            int boardSum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j].IsChecked == false)
                    {
                        boardSum += board[i, j].Value;
                    }
                }
            }

            long result = boardSum * number;
            Console.WriteLine($"Day 4 Run1,2 -> Result: {result}");
        }

        private class BoardNumber
        {
            public int Value { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}
