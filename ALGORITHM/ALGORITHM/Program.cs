using System;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize(25);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;
            

            int lastTick = 0;
            while(true)
            {
                #region 프레임
                // FPS 프레임: 1초에 몇번 실행?
                int currentTick = System.Environment.TickCount; // 시스템이 실행된 이후 경과된 ms출력
                int elapsedTick = currentTick - lastTick;

                // 만약 경과시간이 1/30초보다 작다면
                if(elapsedTick < WAIT_TICK)
                {
                    continue;
                }
                lastTick = currentTick;
                #endregion

                // 게임의 기본구조
                // 입력
                // 로직
                // 렌더링

                Console.SetCursorPosition(0, 0);
                board.Render();
                
            }
        }
    }
}