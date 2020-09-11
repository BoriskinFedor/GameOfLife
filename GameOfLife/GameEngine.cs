using System;

namespace GameOfLife
{
    public class GameEngine
    {
        public readonly int Cols;
        public readonly int Rows;
        public int GenerationCounter { get; private set; } = 0;
        public bool[,] Field { get; private set; }
        public bool[,] FieldNext { get; private set; }
        public readonly int CellSize;
        private int Density;
        private bool IsFirstGenAuto;    // Is the first generation manual or random?
        private bool IsEarthFlat;  // Is the world looped?

        public GameEngine(int screenWidth, int screenHeight, int cellSize = 6,
            int density = 5, bool isFirstGenAuto = true, bool isEarthFlat = false)
        {
            Cols = screenWidth / cellSize;
            Rows = screenHeight / cellSize;
            Field = new bool[Cols, Rows];
            FieldNext = new bool[Cols, Rows];
            CellSize = cellSize;
            Density = density;
            IsFirstGenAuto = isFirstGenAuto;
            IsEarthFlat = isEarthFlat;
        }

        public void StartGame()
        {
            if (IsFirstGenAuto)
            {
                Random random = new Random();
                for (int x = 0; x < Cols; x++)
                {
                    for (int y = 0; y < Rows; y++)
                    {
                        Field[x, y] = random.Next(Density) == 0;
                    }
                }
                CalculateNextGeneration();
                GenerationCounter = 1;
            }
            else
            {
                Field = new bool[Cols, Rows];
                FieldNext = new bool[Cols, Rows];
                GenerationCounter = 1;
            }
        }

        public void NextGeneration()
        {
            Field = FieldNext;
            FieldNext = new bool[Cols, Rows];
            CalculateNextGeneration();
            GenerationCounter++;
        }

        private void CalculateNextGeneration()
        {
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    int neighbourCount = 0;
                    for (int offsetX = -1; offsetX < 2; offsetX++)
                    {
                        for (int offsetY = -1; offsetY < 2; offsetY++)
                        {
                            int neighbourX = x + offsetX;
                            int neighbourY = y + offsetY;

                            if (IsEarthFlat)
                            {
                                bool XYresult = (offsetX == 0 && offsetY == 0) ||
                                    neighbourX == -1 || neighbourX == Cols ||
                                    neighbourY == -1 || neighbourY == Rows;
                                if (XYresult)
                                    continue;
                                else if(Field[neighbourX, neighbourY])
                                    neighbourCount++;
                                continue;    // if the world is not looped, it will be end of cicle iterations
                            }

                            neighbourX = (neighbourX + Cols) % Cols;
                            neighbourY = (neighbourY + Rows) % Rows;
                            if (offsetX == 0 && offsetY == 0)
                                continue;
                            if (Field[neighbourX, neighbourY])
                                neighbourCount++;
                        }
                    }
                    if (Field[x, y])
                        FieldNext[x, y] = neighbourCount == 2 || neighbourCount == 3 ? true : false;
                    else
                        FieldNext[x, y] = neighbourCount == 3 ? true : false;
                }
            }
        }

        public void AddLiveCell(int x, int y)
        {
            Field[x, y] = true;
            CalculateNextGeneration();
        }

        public void DeleteLiveCell(int x, int y)
        {
            Field[x, y] = false;
            CalculateNextGeneration();
        }
    }
}
