using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class Board
    {
        const char CIRCLE = '●';
        public TileType[,] _tile;
        public int _size;

        // 항상 매직넘버는 지양하도록하자
        public enum TileType
        {
            Empty,
            Wall,
        }
        public void Initialize(int size)
        {
            _tile = new TileType[size, size];
            _size = size;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    // 외각은 wall
                    if (x == 0 || x == _size - 1 || y == 0 || y == _size - 1)
                    {
                        _tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        _tile[y, x] = TileType.Empty;
                    }
                }
            }
        }

        // 콘솔창에 출력을 담당하는 부분
        public void Render()
        {
            // 색 정보가 날라가는걸 방지하기위해 임시저장
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    // 타일배열의 정보에 따라서 표시할 색이 달라야하므로 정보가 담긴 타일을 가져온다
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            // Render가 실행되어도 이전상태에 영향을 주지 않기위해 임시저장을 한뒤 출력
            Console.ForegroundColor = prevColor;
        }

        // 기능이 다른부분은 따로 빼서 관리하는것이 장기적으로 볼땐 좋다
        // 타일의 색을 정하는 부분
        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
