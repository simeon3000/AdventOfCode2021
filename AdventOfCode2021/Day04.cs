using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day04 : IDay
    {
        private const string file = @"inputs\day04.txt";
        private static readonly List<string> input = Helper.GetInputLines(file);
        private static readonly List<int> bingoNumbers = input[0].Split(',').Select(x => int.Parse(x)).ToList();

        public long Run1()
        {
            List<BoardNumber[,]> playersBoards = GetBoards(input);

            foreach (int number in bingoNumbers)
            {
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
                            return CalcResult(board, number);
                        }
                    }

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
                            return CalcResult(board, number);
                        }
                    }
                }
            }

            return 0;
        }

        public long Run2()
        {
            List<BoardNumber[,]> playersBoards = GetBoards(input);

            foreach (int number in bingoNumbers)
            {
                bool isDone = false;
                List<BoardNumber[,]> boardsToRemove = new ();

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

                if (isDone)
                {
                    if (playersBoards.Count == boardsToRemove.Count)
                    {
                        BoardNumber[,] lastBoard = boardsToRemove.Last();
                        return CalcResult(lastBoard, number);
                    }

                    playersBoards = playersBoards.Except(boardsToRemove).ToList();
                }
            }

            return 0;
        }

        private List<BoardNumber[,]> GetBoards(List<string> input)
        {
            List<List<BoardNumber>> tempList = new();
            for (int i = 1; i < input.Count; i++)
            {
                if (String.IsNullOrEmpty(input[i]))
                {
                    continue;
                }

                List<int> lineNumbers = input[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

                List<BoardNumber> tempRow = new();
                foreach (int num in lineNumbers)
                {
                    tempRow.Add(new BoardNumber { Value = num });
                }

                tempList.Add(tempRow);
            }

            List<BoardNumber[,]> playersBoards = new();

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

            return playersBoards;
        }

        private long CalcResult(BoardNumber[,] board, int number)
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
            return result;
        }

        private class BoardNumber
        {
            public int Value { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}
