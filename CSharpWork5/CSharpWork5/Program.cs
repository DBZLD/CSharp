using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region main
            Draw draw = new Draw();
            Player player = new Player();
            Enemy enemy = new Enemy();
            int nTurn = 1;
            int nTurnCount = 0;
            bool bTurn = false;
            string chTurn = "";
            Random rand = new Random();
            int nSetTurn = rand.Next(0, 2);
            if (nSetTurn == 0)
            {
                bTurn = true;
                chTurn = "당신";
            }
            else if (nSetTurn == 1)
            {
                bTurn = false;
                chTurn = "상대";
            }

            draw.DrawIntroduceScreen();
            while (true)
            {
                //배경 그리기
                draw.DrawBackground(player, enemy, nTurn, chTurn);
                draw.DrawMap(player, enemy);
                draw.DrawUnitMove(player, enemy);
                //윳 던지기 
                while(true)
                {
                    player.bReroll = false;
                    enemy.bReroll = false;
                    if (bTurn == true)
                    {
                        player.PlayerThrowYut();
                        draw.DrawPlayerYut(player);
                        player.PlayerMove();
                    }
                    else if (bTurn == false)
                    {
                        enemy.EnemyThrowYut();
                        draw.DrawEnemyYut(enemy);
                        enemy.EnemyMove();
                    }
                    if( player.bReroll == false && enemy.bReroll == false) { break; }
                }

                //턴 넘기기 
                if(bTurn == false)
                {
                    bTurn = true;
                    chTurn = "당신";
                    nTurnCount++;
                }
                else if(bTurn == true)
                {
                    bTurn = false;
                    chTurn = "상대";
                    nTurnCount++;
                }
                if(nTurnCount == 2)
                {
                    nTurnCount = 0;
                    nTurn++;
                }
            }
            #endregion
        }
    }

    #region draw
    class Draw
    {
        public void DrawBackground(Player player, Enemy enemy, int nTurn, string chTurn)
        {
            Console.SetCursorPosition(0, 45);
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < 123; i++) { System.Console.Write("━"); }
            Console.SetCursorPosition(5, 47);
            System.Console.Write($"현재 턴 : {nTurn}");
            Console.SetCursorPosition(5, 49);
            System.Console.Write($"{chTurn}의 턴");
            Console.SetCursorPosition(5, 51);
            System.Console.Write($"보유한 돈 : {player.nPlayerMoney}");
            Console.SetCursorPosition(5, 53);
            System.Console.Write($"상대가 보유한 돈 : {enemy.nEnemyMoney}");
        }
        public void DrawIntroduceScreen()
        {
            Console.SetWindowSize(124, 60);
            Console.CursorVisible = false;
            Console.Title = "부루마블 + 윳놀이";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(50, 4);
            System.Console.Write("부루마블 + 윳놀이");
            Console.SetCursorPosition(10, 7);
            System.Console.Write("맵 설명");
            Console.SetCursorPosition(10, 9);
            System.Console.Write("맵은 윳놀이와 동일하고 윳을 던져서 움직인다.");
            Console.SetCursorPosition(10, 10);
            System.Console.Write("말은 1개이며 플레이어의 말은 파란색, 상대의 말은 빨간색이다.");
            Console.SetCursorPosition(10, 11);
            System.Console.Write("라인의 각 중간에는 이벤트 칸이 있고 감옥은 두 곳이 있다.");
            Console.SetCursorPosition(10, 12);
            System.Console.Write("이벤트 칸과 각 라인의 모서리를 제외한 칸은 건물을 지어 통행료를 받을 수 있고 건물 인수와 랜드마크 건설은 없다.");
            Console.SetCursorPosition(10, 13);
            System.Console.Write("아무것도 없는 곳은 검은색, 플레이어 소유는 빨강색, 상대 소유는 파란색 테두리고 건물의 단계는 숫자로 표시된다.");
            Console.SetCursorPosition(10, 15);
            System.Console.Write("점수 설명");
            Console.SetCursorPosition(10, 17);
            System.Console.Write("상대의 점수가 0미만이 되거나 자신의 점수가 50이상이 될시 승리한다.");
            Console.SetCursorPosition(10, 18);
            System.Console.Write("기본으로 주어지는 점수는 10점이고 건물을 짓는데에는 1,2점이 들어가고 통행료는 2,4점이다.");
            Console.SetCursorPosition(10, 19);
            System.Console.Write("상대를 잡으면 5점과 상대를 뒤로 한칸 이동시키며 윳을 한번 더 던질 수 있다.");
            Console.SetCursorPosition(10, 21);
            System.Console.Write("이벤트 설명");
            Console.SetCursorPosition(10, 23);
            System.Console.Write("이벤트칸에 도착하면 이벤트의 실행여부를 선택할 수 있다.");
            Console.SetCursorPosition(10, 24);
            System.Console.Write("긍정적인 이벤트는 자신의 점수 상승, 상대 점수 감소, 강탈, 상대를 감옥으로 이동, 상대를 뒤로 이동시키기가 있다.");
            Console.SetCursorPosition(10, 25);
            System.Console.Write("부정적인 이벤트는 자신의 점수 감소, 상대의 점수 증가, 자신을 감옥으로 이동이 있다.");
            Console.SetCursorPosition(10, 26);
            System.Console.Write("감옥에 걸리면 윳과 모가 나오거나 2턴이 지나야 움직일 수 있다.");
            Console.SetCursorPosition(5, 29);
            System.Console.Write("게임을 시작하려면 아무 키나 누르세요");
            Console.ReadKey(true);
            Console.Clear();
        }
        #region drawtile
        public void DrawTileEdge(int nX, int nY)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(nX, nY);
            System.Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(nX, nY + 1);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(nX, nY + 2);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(nX, nY + 3);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(nX, nY + 4);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(nX, nY + 5);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(nX, nY + 6);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(nX, nY + 7);
            System.Console.Write("┗━━━━━━━━━━━━━━┛");
        }
        public void DrawTileWidth(int nX, int nY, bool PlayerBuilding, bool EnemyBuilding, int PlayerBuildingLevel, int EnemyBuildingLevel)
        {
            if (PlayerBuilding == false && EnemyBuilding == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(nX, nY);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(nX, nY + 1);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 2);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 3);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 4);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(nX, nY + 5);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 6);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if (PlayerBuilding == true && EnemyBuilding == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(nX, nY);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(nX, nY + 1);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 2);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 3);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 4);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(nX, nY + 5);
                System.Console.Write($"┃     {PlayerBuildingLevel}    ┃");
                Console.SetCursorPosition(nX, nY + 6);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if (PlayerBuilding == false && EnemyBuilding == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(nX, nY);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(nX, nY + 1);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 2);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 3);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(nX, nY + 4);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(nX, nY + 5);
                System.Console.Write($"┃     {EnemyBuildingLevel}    ┃");
                Console.SetCursorPosition(nX, nY + 6);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
        }
        public void DrawTileHeight(int nX, int nY, bool PlayerBuilding, bool EnemyBuilding, int PlayerBuildingLevel, int EnemyBuildingLevel)
        {
            if (PlayerBuilding == false && EnemyBuilding == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(nX, nY);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(nX, nY + 1);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 2);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 3);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 4);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 5);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (PlayerBuilding == true && EnemyBuilding == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(nX, nY);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(nX, nY + 1);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 2);
                System.Console.Write($"┃        ┃ {PlayerBuildingLevel} ┃");
                Console.SetCursorPosition(nX, nY + 3);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 4);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 5);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (PlayerBuilding == false && EnemyBuilding == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(nX, nY);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(nX, nY + 1);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 2);
                System.Console.Write($"┃        ┃ {EnemyBuildingLevel} ┃");
                Console.SetCursorPosition(nX, nY + 3);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 4);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(nX, nY + 5);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
        }
        public void DrawPrison(int nX, int nY)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(nX, nY);
            System.Console.Write("┏━━━━━━━━━━┓");
            Console.SetCursorPosition(nX, nY + 1);
            System.Console.Write("┃          ┃");
            Console.SetCursorPosition(nX, nY + 2);
            System.Console.Write("┃          ┃");
            Console.SetCursorPosition(nX, nY + 3);
            System.Console.Write("┃          ┃");
            Console.SetCursorPosition(nX, nY + 4);
            System.Console.Write("┣━━━━━━━━━━┫");
            Console.SetCursorPosition(nX, nY + 5);
            System.Console.Write("┃          ┃");
            Console.SetCursorPosition(nX, nY + 6);
            System.Console.Write("┗━━━━━━━━━━┛");
        }

        #endregion
        #region drawmap
        public void DrawMap(Player player, Enemy enemy)
        {
            //0(start)
            DrawTileEdge(10, 37);
            Console.SetCursorPosition(17, 42);
            System.Console.Write("출발");

            //1
            DrawTileWidth(30, 38, player.PlayerBuilding1, enemy.EnemyBuilding1, player.PlayerBuildingLevel1, enemy.EnemyBuildingLevel1);
            //2
            DrawTileWidth(47, 38, player.PlayerBuilding2, enemy.EnemyBuilding2, player.PlayerBuildingLevel2, enemy.EnemyBuildingLevel2);
            //3
            DrawTileWidth(64, 38, player.PlayerBuilding3, enemy.EnemyBuilding3, player.PlayerBuildingLevel3, enemy.EnemyBuildingLevel3);
            //4
            DrawTileWidth(81, 38, player.PlayerBuilding4, enemy.EnemyBuilding4, player.PlayerBuildingLevel4, enemy.EnemyBuildingLevel4);

            //5
            DrawTileEdge(98, 37);

            //6
            DrawTileHeight(100, 30, player.PlayerBuilding6, enemy.EnemyBuilding6, player.PlayerBuildingLevel6, enemy.EnemyBuildingLevel6);
            //7
            DrawTileHeight(100, 23, player.PlayerBuilding7, enemy.EnemyBuilding7, player.PlayerBuildingLevel7, enemy.EnemyBuildingLevel7);
            //8
            DrawTileHeight(100, 16, player.PlayerBuilding8, enemy.EnemyBuilding8, player.PlayerBuildingLevel8, enemy.EnemyBuildingLevel8);
            //9
            DrawTileHeight(100, 9, player.PlayerBuilding9, enemy.EnemyBuilding9, player.PlayerBuildingLevel9, enemy.EnemyBuildingLevel9);

            //10
            DrawTileEdge(98, 0);

            //11
            DrawTileWidth(30, 0, player.PlayerBuilding11, enemy.EnemyBuilding11, player.PlayerBuildingLevel11, enemy.EnemyBuildingLevel11);
            //12
            DrawPrison(47, 0);
            Console.SetCursorPosition(51, 5);
            System.Console.Write("감옥");
            //13
            DrawTileWidth(64, 0, player.PlayerBuilding13, enemy.EnemyBuilding13, player.PlayerBuildingLevel13, enemy.EnemyBuildingLevel13);
            //14
            DrawTileWidth(81, 0, player.PlayerBuilding14, enemy.EnemyBuilding14, player.PlayerBuildingLevel14, enemy.EnemyBuildingLevel14);

            //15
            DrawTileEdge(10, 0);

            //16
            DrawTileHeight(10, 30, player.PlayerBuilding16, enemy.EnemyBuilding16, player.PlayerBuildingLevel16, enemy.EnemyBuildingLevel16);
            //17
            DrawTileHeight(10, 23, player.PlayerBuilding17, enemy.EnemyBuilding17, player.PlayerBuildingLevel17, enemy.EnemyBuildingLevel17);
            //18
            DrawTileHeight(10, 16, player.PlayerBuilding18, enemy.EnemyBuilding18, player.PlayerBuildingLevel18, enemy.EnemyBuildingLevel18);
            //19
            DrawTileHeight(10, 9, player.PlayerBuilding19, enemy.EnemyBuilding19, player.PlayerBuildingLevel19, enemy.EnemyBuildingLevel19);

            //22
            DrawTileEdge(54, 19);

            //20
            DrawPrison(84, 30);
            Console.SetCursorPosition(88, 35);
            System.Console.Write("감옥");
            //21
            DrawTileWidth(70, 24, player.PlayerBuilding4, enemy.EnemyBuilding4, player.PlayerBuildingLevel4, enemy.EnemyBuildingLevel4);
            //23
            DrawTileWidth(42, 14, player.PlayerBuilding4, enemy.EnemyBuilding4, player.PlayerBuildingLevel4, enemy.EnemyBuildingLevel4);
            //24
            DrawTileWidth(28, 8, player.PlayerBuilding4, enemy.EnemyBuilding4, player.PlayerBuildingLevel4, enemy.EnemyBuildingLevel4);
            //25
            DrawTileWidth(84, 8, player.PlayerBuilding4, enemy.EnemyBuilding4, player.PlayerBuildingLevel4, enemy.EnemyBuildingLevel4);
            //26
            DrawTileWidth(70, 14, player.PlayerBuilding4, enemy.EnemyBuilding4, player.PlayerBuildingLevel4, enemy.EnemyBuildingLevel4);
            //27
            DrawTileWidth(42, 24, player.PlayerBuilding4, enemy.EnemyBuilding4, player.PlayerBuildingLevel4, enemy.EnemyBuildingLevel4);
            //28
            DrawTileWidth(28, 30, player.PlayerBuilding4, enemy.EnemyBuilding4, player.PlayerBuildingLevel4, enemy.EnemyBuildingLevel4);
        }
        #endregion
        #region drawunit
        public void DrawUnit(int nX, int nY)
        {
            Console.SetCursorPosition(nX, nY);
            System.Console.Write("┏━━┓");
            Console.SetCursorPosition(nX, nY + 1);
            System.Console.Write("┃■┃");
            Console.SetCursorPosition(nX, nY + 2);
            System.Console.Write("┗━━┛");
        }
        public void DrawUnitMove(Player player, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            switch (player.nPlayerOnMap)
            {
                case 0:
                    DrawUnit(12, 39);
                    break;
                case 1:
                    DrawUnit(34, 39);
                    break;
                case 2:
                    DrawUnit(51, 39);
                    break;
                case 3:
                    DrawUnit(68, 39);
                    break;
                case 4:
                    DrawUnit(85, 39);
                    break;
                case 5:
                    DrawUnit(102, 39);
                    break;
                case 6:
                    DrawUnit(102, 31);
                    break;
                case 7:
                    DrawUnit(102, 24);
                    break;
                case 8:
                    DrawUnit(102, 17);
                    break;
                case 9:
                    DrawUnit(102, 10);
                    break;
                case 10:
                    DrawUnit(102, 2);
                    break;
                case 11:
                    DrawUnit(85, 1);
                    break;
                case 12:
                    DrawUnit(68, 1);
                    break;
                case 13:
                    DrawUnit(51, 1);
                    break;
                case 14:
                    DrawUnit(34, 1);
                    break;
                case 15:
                    DrawUnit(15, 2);
                    break;
                case 16:
                    DrawUnit(13, 10);
                    break;
                case 17:
                    DrawUnit(13, 17);
                    break;
                case 18:
                    DrawUnit(13, 24);
                    break;
                case 19:
                    DrawUnit(13, 31);
                    break;
                case 20:
                    DrawUnit(88, 31);
                    break;
                case 21:
                    DrawUnit(74, 25);
                    break;
                case 22:
                    DrawUnit(60, 22);
                    break;
                case 23:
                    DrawUnit(46, 15);
                    break;
                case 24:
                    DrawUnit(32, 9);
                    break;
                case 25:
                    DrawUnit(88, 9);
                    break;
                case 26:
                    DrawUnit(74, 15);
                    break;
                case 27:
                    DrawUnit(46, 25);
                    break;
                case 28:
                    DrawUnit(32, 31);
                    break;

            }
            Console.ForegroundColor = ConsoleColor.Red;
            switch (enemy.nEnemyOnMap)
            {
                case 0:
                    DrawUnit(18, 39);
                    break;
                case 1:
                    DrawUnit(34, 39);
                    break;
                case 2:
                    DrawUnit(51, 39);
                    break;
                case 3:
                    DrawUnit(68, 39);
                    break;
                case 4:
                    DrawUnit(85, 39);
                    break;
                case 5:
                    DrawUnit(102, 39);
                    break;
                case 6:
                    DrawUnit(102, 31);
                    break;
                case 7:
                    DrawUnit(102, 24);
                    break;
                case 8:
                    DrawUnit(102, 17);
                    break;
                case 9:
                    DrawUnit(102, 10);
                    break;
                case 10:
                    DrawUnit(102, 2);
                    break;
                case 11:
                    DrawUnit(85, 1);
                    break;
                case 12:
                    DrawUnit(68, 1);
                    break;
                case 13:
                    DrawUnit(51, 1);
                    break;
                case 14:
                    DrawUnit(34, 1);
                    break;
                case 15:
                    DrawUnit(15, 2);
                    break;
                case 16:
                    DrawUnit(13, 10);
                    break;
                case 17:
                    DrawUnit(13, 17);
                    break;
                case 18:
                    DrawUnit(13, 24);
                    break;
                case 19:
                    DrawUnit(13, 31);
                    break;
                case 20:
                    DrawUnit(88, 31);
                    break;
                case 21:
                    DrawUnit(74, 25);
                    break;
                case 22:
                    DrawUnit(60, 22);
                    break;
                case 23:
                    DrawUnit(46, 15);
                    break;
                case 24:
                    DrawUnit(32, 9);
                    break;
                case 25:
                    DrawUnit(88, 9);
                    break;
                case 26:
                    DrawUnit(74, 15);
                    break;
                case 27:
                    DrawUnit(46, 25);
                    break;
                case 28:
                    DrawUnit(32, 31);
                    break;
            }
        }
        #endregion
        #region drawyut
        public void DrawPlayerYut(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            DrawYutImage(30, 46, player.nYut1);
            DrawYutImage(35, 46, player.nYut2);
            DrawYutImage(40, 46, player.nYut3);
            DrawYutImage(45, 46, player.nYut4);
            Console.SetCursorPosition(52, 46);
            System.Console.Write($"{player.chYut}");
        }
        public void DrawEnemyYut(Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            DrawYutImage(30, 46, enemy.nYut1);
            DrawYutImage(35, 46, enemy.nYut2);
            DrawYutImage(40, 46, enemy.nYut3);
            DrawYutImage(45, 46, enemy.nYut4);
            Console.SetCursorPosition(52, 46);
            System.Console.Write($"{enemy.chYut}");
        }
        public void DrawYutImage(int nX, int nY, int nYut)
        {
            if(nYut == 0)
            {
                //앞면
                Console.SetCursorPosition(nX, nY);
                System.Console.Write("┏━━┓");
                Console.SetCursorPosition(nX, nY + 1);
                System.Console.Write("┃Ⅹ┃");
                Console.SetCursorPosition(nX, nY + 2);
                System.Console.Write("┃Ⅹ┃");
                Console.SetCursorPosition(nX, nY + 3);
                System.Console.Write("┃Ⅹ┃");
                Console.SetCursorPosition(nX, nY + 4);
                System.Console.Write("┗━━┛");
            }
            if(nYut == 1)
            {
                //뒷면
                Console.SetCursorPosition(nX, nY);
                System.Console.Write("┏━━┓");
                Console.SetCursorPosition(nX, nY + 1);
                System.Console.Write("┃  ┃");
                Console.SetCursorPosition(nX, nY + 2);
                System.Console.Write("┃  ┃");
                Console.SetCursorPosition(nX, nY + 3);
                System.Console.Write("┃  ┃");
                Console.SetCursorPosition(nX, nY + 4);
                System.Console.Write("┗━━┛");
            }
        }
        #endregion
        public void ResetInterface()
        {
            for (int i = 0; i< 20; i++)
            {
                Console.SetCursorPosition(0, 46);
                for (i = 0; i < 123; i++) { System.Console.Write(" "); }
            }
        }
    }
    #endregion

    #region player
    class Player
    {
        public int nPlayerOnMap = 0;
        public int nPlayerMoney = 10;
        public int nYut1 = 0;
        public int nYut2 = 0;
        public int nYut3 = 0;
        public int nYut4 = 0;
        public int nMove = 0;
        public string chYut;
        public bool bReroll;
        #region PlayerBuilding
        public bool PlayerBuilding1 = false;
        public bool PlayerBuilding2 = false;
        public bool PlayerBuilding3 = false;
        public bool PlayerBuilding4 = false;
        public bool PlayerBuilding6 = false;
        public bool PlayerBuilding7 = false;
        public bool PlayerBuilding8 = false;
        public bool PlayerBuilding9 = false;
        public bool PlayerBuilding11 = false;
        public bool PlayerBuilding12 = false;
        public bool PlayerBuilding13 = false;
        public bool PlayerBuilding14 = false;
        public bool PlayerBuilding16 = false;
        public bool PlayerBuilding17 = false;
        public bool PlayerBuilding18 = false;
        public bool PlayerBuilding19 = false;
        public bool PlayerBuilding20 = false;
        public bool PlayerBuilding21 = false;
        public bool PlayerBuilding23 = false;
        public bool PlayerBuilding24 = false;
        public bool PlayerBuilding25 = false;
        public bool PlayerBuilding26 = false;
        public bool PlayerBuilding27 = false;
        public bool PlayerBuilding28 = false;

        public int PlayerBuildingLevel1 = 0;
        public int PlayerBuildingLevel2 = 0;
        public int PlayerBuildingLevel3 = 0;
        public int PlayerBuildingLevel4 = 0;
        public int PlayerBuildingLevel6 = 0;
        public int PlayerBuildingLevel7 = 0;
        public int PlayerBuildingLevel8 = 0;
        public int PlayerBuildingLevel9 = 0;
        public int PlayerBuildingLevel11 = 0;
        public int PlayerBuildingLevel12 = 0;
        public int PlayerBuildingLevel13 = 0;
        public int PlayerBuildingLevel14 = 0;
        public int PlayerBuildingLevel16 = 0;
        public int PlayerBuildingLevel17 = 0;
        public int PlayerBuildingLevel18 = 0;
        public int PlayerBuildingLevel19 = 0;
        public int PlayerBuildingLevel20 = 0;
        public int PlayerBuildingLevel21 = 0;
        public int PlayerBuildingLevel23 = 0;
        public int PlayerBuildingLevel24 = 0;
        public int PlayerBuildingLevel25 = 0;
        public int PlayerBuildingLevel26 = 0;
        public int PlayerBuildingLevel27 = 0;
        public int PlayerBuildingLevel28 = 0;
        #endregion
        #region yut
        public void PlayerThrowYut()
        {
            Console.SetCursorPosition(29, 52);
            Console.ForegroundColor = ConsoleColor.Black;
            System.Console.Write("아무키나 누르면 윷을 던집니다.");
            Console.ReadKey(true);

            Random rand = new Random();
            nYut1 = rand.Next(0, 2);
            nYut2 = rand.Next(0, 2);
            nYut3 = rand.Next(0, 2);
            nYut4 = rand.Next(0, 2);
            nMove = nYut1 + nYut2 + nYut3 + nYut4;
            if (nMove == 1)
            {
                chYut = "도";
                bReroll = false;
            }
            if (nMove == 2)
            {
                chYut = "개";
                bReroll = false;
            }
            if (nMove == 3)
            {
                chYut = "걸";
                bReroll = false;
            }
            if (nMove == 4) 
            { 
                chYut = "윳";
                bReroll = true;
            }
            if (nMove == 0) 
            {
                chYut = "모";
                bReroll = true;
            }
        }
        #endregion
        public void PlayerMove()
        {
            nPlayerOnMap += nMove;
            if(nPlayerOnMap >= 20) { nPlayerOnMap -= 20; }
        }

    }
    #endregion

    #region enemy
    class Enemy
    {
        public int nEnemyOnMap = 0;
        public int nEnemyMoney = 10;
        public int nYut1 = 0;
        public int nYut2 = 0;
        public int nYut3 = 0;
        public int nYut4 = 0;
        public int nMove = 0;
        public bool bReroll;
        public string chYut;
        #region EnemyBuilding
        public bool EnemyBuilding1 = false;
        public bool EnemyBuilding2 = false;
        public bool EnemyBuilding3 = false;
        public bool EnemyBuilding4 = false;
        public bool EnemyBuilding6 = false;
        public bool EnemyBuilding7 = false;
        public bool EnemyBuilding8 = false;
        public bool EnemyBuilding9 = false;
        public bool EnemyBuilding11 = false;
        public bool EnemyBuilding12 = false;
        public bool EnemyBuilding13 = false;
        public bool EnemyBuilding14 = false;
        public bool EnemyBuilding16 = false;
        public bool EnemyBuilding17 = false;
        public bool EnemyBuilding18 = false;
        public bool EnemyBuilding19 = false;
        public bool EnemyBuilding20 = false;
        public bool EnemyBuilding21 = false;
        public bool EnemyBuilding23 = false;
        public bool EnemyBuilding24 = false;
        public bool EnemyBuilding25 = false;
        public bool EnemyBuilding26 = false;
        public bool EnemyBuilding27 = false;
        public bool EnemyBuilding28 = false;

        public int EnemyBuildingLevel1 = 0;
        public int EnemyBuildingLevel2 = 0;
        public int EnemyBuildingLevel3 = 0;
        public int EnemyBuildingLevel4 = 0;
        public int EnemyBuildingLevel6 = 0;
        public int EnemyBuildingLevel7 = 0;
        public int EnemyBuildingLevel8 = 0;
        public int EnemyBuildingLevel9 = 0;
        public int EnemyBuildingLevel11 = 0;
        public int EnemyBuildingLevel12 = 0;
        public int EnemyBuildingLevel13 = 0;
        public int EnemyBuildingLevel14 = 0;
        public int EnemyBuildingLevel16 = 0;
        public int EnemyBuildingLevel17 = 0;
        public int EnemyBuildingLevel18 = 0;
        public int EnemyBuildingLevel19 = 0;
        public int EnemyBuildingLevel20 = 0;
        public int EnemyBuildingLevel21 = 0;
        public int EnemyBuildingLevel23 = 0;
        public int EnemyBuildingLevel24 = 0;
        public int EnemyBuildingLevel25 = 0;
        public int EnemyBuildingLevel26 = 0;
        public int EnemyBuildingLevel27 = 0;
        public int EnemyBuildingLevel28 = 0;
        #endregion
        #region yut
        public void EnemyThrowYut()
        {
            Console.SetCursorPosition(29, 52);
            Console.ForegroundColor = ConsoleColor.Black;
            System.Console.Write("아무키나 누르면 윷을 던집니다.");
            Console.ReadKey();

            Random rand = new Random();
            nYut1 = rand.Next(0, 2);
            nYut2 = rand.Next(0, 2);
            nYut3 = rand.Next(0, 2);
            nYut4 = rand.Next(0, 2);
            nMove = nYut1 + nYut2 + nYut3 + nYut4;
            if (nMove == 1) 
            { 
                chYut = "도";
                bReroll = false;
            }
            if (nMove == 2)
            {
                chYut = "개";
                bReroll = false;
            }
            if (nMove == 3)
            {
                chYut = "걸";
                bReroll = false;
            }
            if (nMove == 4)
            {
                chYut = "윳";
                bReroll = true;
            }
            if (nMove == 0)
            {
                chYut = "모";
                bReroll = true;
            }
        }
        #endregion
        public void EnemyMove()
        {
            nEnemyOnMap += nMove;
            if (nEnemyOnMap >= 20) { nEnemyOnMap -= 20; }
        }
    }
}
#endregion