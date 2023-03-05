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
            #region point
            Point[] pointunit = new Point[29];
            pointunit[0].x = 14;
            pointunit[0].y = 39;
            pointunit[1].x = 34;
            pointunit[1].y = 39;
            pointunit[2].x = 51;
            pointunit[2].y = 39;
            pointunit[3].x = 68;
            pointunit[3].y = 39;
            pointunit[4].x = 85;
            pointunit[4].y = 39;
            pointunit[5].x = 104;
            pointunit[5].y = 39;
            pointunit[6].x = 104;
            pointunit[6].y = 31;
            pointunit[7].x = 104;
            pointunit[7].y = 24;
            pointunit[8].x = 104;
            pointunit[8].y = 17;
            pointunit[9].x = 104;
            pointunit[9].y = 10;
            pointunit[10].x = 104;
            pointunit[10].y = 2;
            pointunit[11].x = 85;
            pointunit[11].y = 1;
            pointunit[12].x = 68;
            pointunit[12].y = 1;
            pointunit[13].x = 51;
            pointunit[13].y = 1;
            pointunit[14].x = 34;
            pointunit[14].y = 1;
            pointunit[15].x = 13;
            pointunit[15].y = 2;
            pointunit[16].x = 13;
            pointunit[16].y = 10;
            pointunit[17].x = 13;
            pointunit[17].y = 17;
            pointunit[18].x = 13;
            pointunit[18].y = 24;
            pointunit[19].x = 13;
            pointunit[19].y = 31;
            pointunit[20].x = 88;
            pointunit[20].y = 31;
            pointunit[21].x = 74;
            pointunit[21].y = 25;
            pointunit[22].x = 60;
            pointunit[22].y = 22;
            pointunit[23].x = 46;
            pointunit[23].y = 15;
            pointunit[24].x = 32;
            pointunit[24].y = 9;
            pointunit[25].x = 88;
            pointunit[25].y = 9;
            pointunit[26].x = 74;
            pointunit[26].y = 15;
            pointunit[27].x = 46;
            pointunit[27].y = 25;
            pointunit[28].x = 32;
            pointunit[28].y = 31;
            Point[] pointmap = new Point[29];
            pointmap[0].x = 10;
            pointmap[0].y = 37;
            pointmap[1].x = 30;
            pointmap[1].y = 38;
            pointmap[2].x = 47;
            pointmap[2].y = 38;
            pointmap[3].x = 64;
            pointmap[3].y = 38;
            pointmap[4].x = 81;
            pointmap[4].y = 38;
            pointmap[5].x = 98;
            pointmap[5].y = 37;
            pointmap[6].x = 102;
            pointmap[6].y = 30;
            pointmap[7].x = 102;
            pointmap[7].y = 23;
            pointmap[8].x = 102;
            pointmap[8].y = 16;
            pointmap[9].x = 102;
            pointmap[9].y = 9;
            pointmap[10].x = 98;
            pointmap[10].y = 0;
            pointmap[11].x = 81;
            pointmap[11].y = 0;
            pointmap[12].x = 64;
            pointmap[12].y = 0;
            pointmap[13].x = 47;
            pointmap[13].y = 0;
            pointmap[14].x = 30;
            pointmap[14].y = 0;
            pointmap[15].x = 10;
            pointmap[15].y = 0;
            pointmap[16].x = 10;
            pointmap[16].y = 9;
            pointmap[17].x = 10;
            pointmap[17].y = 16;
            pointmap[18].x = 10;
            pointmap[18].y = 23;
            pointmap[19].x = 10;
            pointmap[19].y = 30;
            pointmap[20].x = 83;
            pointmap[20].y = 30;
            pointmap[21].x = 70;
            pointmap[21].y = 24;
            pointmap[22].x = 54;
            pointmap[22].y = 19;
            pointmap[23].x = 42;
            pointmap[23].y = 14;
            pointmap[24].x = 28;
            pointmap[24].y = 8;
            pointmap[25].x = 84;
            pointmap[25].y = 8;
            pointmap[26].x = 70;
            pointmap[26].y = 14;
            pointmap[27].x = 42;
            pointmap[27].y = 24;
            pointmap[28].x = 28;
            pointmap[28].y = 30;
            #endregion
            #region main
            Draw draw = new Draw();
            draw.DrawIntroduceScreen();

            Player[] player = new Player[2];
            for(int i = 0; i < 2; i++) { player[i] = new Player(); }
            SetColor(player, 2);
            draw.DrawSetUserName(player, 2);
            int nTurn = 1; //현재 턴
            string chName = player[0].chPlayerName;
            int nTurnCount = 0; //차례
            while (true)
            {
                //배경 그리기
                draw.DrawBackground(nTurn, chName, player, 2);
                draw.DrawMap(pointmap, player);
                for (int i = 0; i < 2; i++)
                {
                    draw.DrawUnitMove(player[i], pointunit);
                }
                //윳 던지기 
                while (true)
                {
                    player[nTurnCount].PlayerThrowYut(draw);
                    draw.DrawPlayerYut(player[nTurnCount]);
                    player[nTurnCount].PlayerMove(); 

                    draw.DrawUnitMove(player[nTurnCount], pointunit);
                    player[nTurnCount].PlayerChoiceFork(draw);
                    draw.DrawBackground(nTurn, chName, player, 2);
                    player[nTurnCount].PlayerChoiceEvent(draw);
                    draw.DrawBackground(nTurn, chName, player, 2);
                    if (player[nTurnCount].bPlayerReroll == false) break;//턴 끝내기
                }
                //턴 넘기기 
                chName = player[nTurnCount].chPlayerName;
                nTurnCount++;
                if (nTurnCount == 2)
                {
                    nTurnCount = 0;
                    nTurn++;
                }
                if(player[0].nPlayerMoney >=50 || player[1].nPlayerMoney <=0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(55, 30);
                    System.Console.Write($"{player[0].chPlayerName} 승리");
                    break;
                }
                if (player[0].nPlayerMoney <= 0 || player[1].nPlayerMoney >= 50)
                {
                    Console.Clear();
                    Console.SetCursorPosition(55, 30);
                    System.Console.Write($"{player[1].chPlayerName} 승리");
                    break;
                }
            }
            
            #endregion
        }
        #region method
        static void SetColor(Player[] player, int nNumberofUser)
        {
            if (nNumberofUser == 2)
            {
                player[0].PlayerColor = ConsoleColor.Blue;
                player[1].PlayerColor = ConsoleColor.Red;
            }
        }
        #endregion
    }

    #region draw
    class Draw
    {
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
        public void DrawTile(int nX, int nY, Player[] player, int nOwner, int nNumber)
        {
            if (nOwner == 0)
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
            else
            {
                Console.ForegroundColor = player[nOwner].PlayerColor;
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
                System.Console.Write($"┃     {player[nOwner].bPlayerBuilding[nNumber]}    ┃");
                Console.SetCursorPosition(nX, nY + 6);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
        }
        public void DrawTileText(int nX, int nY, string chText)
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
            Console.SetCursorPosition(nX+5, nY+5);
            System.Console.Write($"{chText}");
        }
        public void DrawHeightText(int nX, int nY, string chText)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(nX, nY);
            System.Console.Write("┏━━━━━━━┳━━━┓");
            Console.SetCursorPosition(nX, nY + 1);
            System.Console.Write("┃       ┃   ┃");
            Console.SetCursorPosition(nX, nY + 2);
            System.Console.Write("┃       ┃   ┃");
            Console.SetCursorPosition(nX, nY + 3);
            System.Console.Write("┃       ┃   ┃");
            Console.SetCursorPosition(nX, nY + 4);
            System.Console.Write("┃       ┃   ┃");
            Console.SetCursorPosition(nX, nY + 5);
            System.Console.Write("┗━━━━━━━┻━━━┛");
            Console.SetCursorPosition(nX + 10, nY + 1);
            System.Console.Write($"{chText}");
        }

        #endregion
        #region drawmap
        public void DrawMap(Point[] point, Player[]player)
        {
            for (int i = 0; i < 29; i++)
            {
                if(i == 0 || i == 5 || i == 10 || i == 15 || i == 22)
                {
                    DrawTileEdge(point[i].x, point[i].y);
                }
                else if (i == 12 || i == 20)
                {
                    DrawTileText(point[i].x, point[i].y, "감옥");
                }
                else if( i == 4 || i == 9)
                {
                    DrawTileText(point[i].x, point[i].y, "이벤트");
                }
                else
                {
                    DrawTile(point[i].x, point[i].y, player, ReturnBuildingOwner(player, i), i);
                }
            }
            Console.SetCursorPosition(17, 42);
            System.Console.Write("출발");
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
        public void ClearUnit(int nX, int nY)
        {
            Console.SetCursorPosition(nX, nY);
            System.Console.Write("    ");
            Console.SetCursorPosition(nX, nY + 1);
            System.Console.Write("    ");
            Console.SetCursorPosition(nX, nY + 2);
            System.Console.Write("    ");
        }
        public void DrawUnitMove(Player player, Point[] point)
        {
            Console.ForegroundColor = player.PlayerColor;
            DrawUnit(point[player.nPlayerOnMap].x, point[player.nPlayerOnMap].y);
            ClearUnit(point[player.nPlayerOnMapBefore].x, point[player.nPlayerOnMapBefore].y);
        }
        #endregion
        #region drawyut
        public void DrawPlayerYut(Player player)
        {
            Console.ForegroundColor = player.PlayerColor;
            DrawYutImage(40, 46, player.nYut1);
            DrawYutImage(45, 46, player.nYut2);
            DrawYutImage(50, 46, player.nYut3);
            DrawYutImage(55, 46, player.nYut4);
            Console.SetCursorPosition(62, 46);
            System.Console.Write($"{player.chYut}");
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
        #region etc
        public int ReturnBuildingOwner(Player[] player, int nNumber)
        {
            for(int i = 0; i < 2; i++)
            {
                if(player[i].bPlayerBuilding[nNumber] == true)
                {
                    return i;
                }
            }
            return 0;
        }
        public void DrawSetUserName(Player[] player, int nNumberOfUser)
        {
            bool bError = false;
            for(int i = 0; i <nNumberOfUser; i++)
            {
                while(true)
                {
                    Console.SetCursorPosition(40, 49);
                    System.Console.Write($"플레이어 {i+1}의 닉네임을 입력해주세요.(1자 이상 8자 이하)");
                    if(bError == true) { System.Console.Write(" 닉네임을 다시 입력해주세요."); }
                    Console.SetCursorPosition(40, 51);
                    player[i].chPlayerName = System.Console.ReadLine();
                    ClearInterface();
                    if(player[i].chPlayerName.Length >= 1 && player[i].chPlayerName.Length <= 8) { break; }
                    else { bError = true; }
                }
            }

        }
        public void DrawBackground(int nTurn, string chTurn, Player[] player, int nNumberOfUser)
        {
            Console.SetCursorPosition(0, 45);
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < 123; i++) { System.Console.Write("━"); }
            Console.SetCursorPosition(0, 46);
            System.Console.Write($"현재 턴 : {nTurn}");
            Console.SetCursorPosition(0, 48);
            System.Console.Write($"{chTurn}의 턴");
            for(int i = 0; i < nNumberOfUser; i++)
            {
                Console.SetCursorPosition(0, 50 + i * 2);
                System.Console.Write($"{player[i].chPlayerName}가 보유한 돈 : {player[i].nPlayerMoney}");
            }
        }
        public void DrawIntroduceScreen()
        {
            Console.SetWindowSize(124, 60);
            Console.CursorVisible = false;
            Console.Title = "윳마블";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(50, 4);
            System.Console.Write("윳마블");
            Console.SetCursorPosition(10, 7);
            System.Console.Write("맵 설명");
            Console.SetCursorPosition(10, 9);
            System.Console.Write("맵은 윳놀이와 동일하고 윳을 던져서 움직이며 말은 1개이다.");
            Console.SetCursorPosition(10, 10);
            System.Console.Write("2인 플레이가 가능하고 플레이어 1은 파랑, 플레이어 2는 빨강으로 표시된다.");
            Console.SetCursorPosition(10, 11);
            System.Console.Write("라인 곳곳에는 이벤트 칸이 있고 감옥은 두 곳이 있다.");
            Console.SetCursorPosition(10, 12);
            System.Console.Write("특별하지 않은 칸은 건물을 지어 통행료를 받을 수 있고 건물 인수와 랜드마크 건설은 없다.");
            Console.SetCursorPosition(10, 13);
            System.Console.Write("아무것도 없는 곳은 검은색, 플레이어 소유는 빨강색, 상대 소유는 파란색 테두리고 건물의 단계는 숫자로 표시된다.");
            Console.SetCursorPosition(10, 15);
            System.Console.Write("점수 설명");
            Console.SetCursorPosition(10, 17);
            System.Console.Write("점수가 0 미만이 되면 탈락하고 점수가 50이상이 될시 승리한다.");
            Console.SetCursorPosition(10, 18);
            System.Console.Write("기본으로 주어지는 점수는 10점이고 건물을 짓는데에는 1,2점이 들어가고 통행료는 2,4점이다.");
            Console.SetCursorPosition(10, 19);
            System.Console.Write("상대를 잡으면 상대의 점수를 3점 뺏고 윳을 한번 더 던질 수 있다.");
            Console.SetCursorPosition(10, 21);
            System.Console.Write("이벤트 설명");
            Console.SetCursorPosition(10, 23);
            System.Console.Write("이벤트칸에 도착하면 이벤트의 실행여부를 선택할 수 있다.");
            Console.SetCursorPosition(10, 24);
            System.Console.Write("긍정적인 이벤트는 자신의 점수 상승, 상대 점수 감소, 강탈, 상대를 감옥으로 이동이 있다.");
            Console.SetCursorPosition(10, 25);
            System.Console.Write("부정적인 이벤트는 자신의 점수 감소, 상대의 점수 증가, 자신을 감옥으로 이동이 있다.");
            Console.SetCursorPosition(10, 26);
            System.Console.Write("감옥에 걸리면 윳과 모가 나오거나 2턴이 지나야 움직일 수 있다.");
            Console.SetCursorPosition(5, 29);
            System.Console.Write("게임을 시작하려면 아무 키나 누르세요");
            Console.ReadKey(true);
            Console.Clear();
        }
        public void ClearInterface()
        {
            for (int i = 0; i< 8; i++)
            {
                Console.SetCursorPosition(0, 46+i);
                for (int k = 0; k < 31; k++) { System.Console.Write("    "); }
            }
        }
        public void NextScreen()
        {
            ConsoleKeyInfo cki;

            cki = Console.ReadKey(true);

            while (true)
            {
                switch (cki.Key)
                {
                    case ConsoleKey.Spacebar:
                        return;
                }
            }
        }
        public int ReturnPlayerChoice2(string chQuestion, string Answer1, string Answer2)
        {
            ConsoleKeyInfo cki;

            int nReturn = 0;

            ClearInterface();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(50, 47);
            System.Console.Write($"{chQuestion}");
            Console.SetCursorPosition(50, 49);
            System.Console.Write($"1. {Answer1}");
            Console.SetCursorPosition(50, 51);
            System.Console.Write($"2. {Answer2}");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(46, 49);
            System.Console.Write("=>");
            Console.SetCursorPosition(46, 51);
            System.Console.Write("  ");

            while (true)
            {
                cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(46, 49);
                        System.Console.Write("=>");
                        Console.SetCursorPosition(46, 51);
                        System.Console.Write("  ");
                        nReturn--;
                        if (nReturn < 0) nReturn = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(46, 51);
                        System.Console.Write("=>");
                        Console.SetCursorPosition(46, 49);
                        System.Console.Write("  ");
                        nReturn++;
                        if (nReturn > 1) nReturn = 1;
                        break;
                    case ConsoleKey.Spacebar:
                        ClearInterface();
                        return nReturn;
                }
            }
        }
        #endregion
    }
    #endregion

    #region player
    class Player
    {
        public string chPlayerName;
        public ConsoleColor PlayerColor;

        public int nPlayerOnMap = 0;
        public int nPlayerOnMapBefore = 0;
        public int nPlayerMoney = 10;
        public bool bPlayerPrison = false;
        public bool bPlayerTurn = false;
        public int nYut1 = 0;
        public int nYut2 = 0;
        public int nYut3 = 0;
        public int nYut4 = 0;
        public int nMove = 0;
        public string chYut;
        public bool bPlayerFork0 = true;
        public bool bPlayerFork1 = false;
        public bool bPlayerFork2 = false;
        public bool bPlayerFork3 = false;
        public bool bPlayerReroll = false;

        public bool[] bPlayerBuilding = new bool[29];
        public bool[] bPlayerBuildingLevel = new bool[29];

        #region yut
        public void PlayerThrowYut(Draw draw)
        {
            bPlayerReroll = false;
            Console.SetCursorPosition(39, 52);
            Console.ForegroundColor = ConsoleColor.Black;
            System.Console.Write("스페이스바로 윷 던지기");
            draw.NextScreen();

            Random rand = new Random();
            nYut1 = rand.Next(0, 2);
            nYut2 = rand.Next(0, 2);
            nYut3 = rand.Next(0, 2);
            nYut4 = rand.Next(0, 2);
            nMove = nYut1 + nYut2 + nYut3 + nYut4;
            if (nMove == 1)
            {
                chYut = "도";
                bPlayerReroll = false;
            }
            else if (nMove == 2)
            {
                chYut = "개";
                bPlayerReroll = false;
            }
            else if (nMove == 3)
            {
                chYut = "걸";
                bPlayerReroll = false;
            }
            else if (nMove == 4) 
            { 
                chYut = "윳";
                bPlayerReroll = true;
            }
            else if (nMove == 0) 
            {
                chYut = "모";
                bPlayerReroll = true;
                nMove = 5;
            }
        }
        #endregion
        #region playermove
        public void PlayerMove()
        {
                if(bPlayerFork0 == true)
                {
                    nPlayerOnMapBefore = nPlayerOnMap;
                    nPlayerOnMap += nMove;
                if (nPlayerOnMap >= 20)
                {
                    nPlayerMoney += 10;
                    nPlayerOnMap -= 20;

                }

                }
                else if (bPlayerFork1 == true)
                {

                    nPlayerOnMapBefore = nPlayerOnMap;
                    if (nPlayerOnMap == 5 ) { nPlayerOnMap += 14; }
                    nPlayerOnMap += nMove;
                    if (nPlayerOnMap >= 25)
                    {
                        bPlayerFork0 = true;
                        bPlayerFork1 = false;
                        nPlayerOnMap -= 10;
                    }
                }
                else if (bPlayerFork2 == true)
                {
                    nPlayerOnMapBefore = nPlayerOnMap;
                    if (nPlayerOnMap == 10) { nPlayerOnMap += 14; }
                    nPlayerOnMap += nMove;
                    if (nPlayerOnMap == 27)
                    {
                        nPlayerOnMap = 22;
                        bPlayerFork2 = false;
                        bPlayerFork3 = true;
                    }
                    else if (nPlayerOnMap == 28)
                    {
                        nPlayerOnMap = 27;
                        bPlayerFork2 = false;
                        bPlayerFork3 = true;
                    }
                    else if (nPlayerOnMap == 29)
                    {
                        nPlayerOnMap = 28;
                        bPlayerFork2 = false;
                        bPlayerFork3 = true;
                    }
                    else if (nPlayerOnMap >= 30)
                    {
                        nPlayerOnMap -= 30;
                        bPlayerFork2 = false;
                        bPlayerFork0 = true;
                        nPlayerMoney += 10;// 골
                    }
                }
                else if (bPlayerFork3 == true)
                {
                    nPlayerOnMapBefore = nPlayerOnMap;
                    nPlayerOnMap += nMove;
                    if (nPlayerOnMap == 28)
                    {
                        nPlayerOnMap = 27;
                        bPlayerFork2 = false;
                        bPlayerFork3 = true;
                    }
                    else if (nPlayerOnMap == 29)
                    {
                        nPlayerOnMap = 28;
                        bPlayerFork2 = false;
                        bPlayerFork3 = true;
                    }
                    else if (nPlayerOnMap >= 30)
                    {
                        nPlayerOnMap -= 30;
                        bPlayerFork2 = false;
                        bPlayerFork0 = true;
                        nPlayerMoney += 10;// 골
                    }
                }
            
        }
        #endregion
        #region event
        public void PlayerChoiceFork(Draw draw)
        {
            if (nPlayerOnMap == 5) 
            { 
                if(draw.ReturnPlayerChoice2("갈림길을 선택해 주세요.", "↖", "↑") == 0) 
                {
                    bPlayerFork0 = false;
                    bPlayerFork1 = true;
                }
            }
            else if (nPlayerOnMap == 10)
            {
                if (draw.ReturnPlayerChoice2("갈림길을 선택해 주세요.", "↙", "←") == 0)
                {
                    bPlayerFork0 = false;
                    bPlayerFork2 = true;
                }
            }
            else if (nPlayerOnMap == 22 && bPlayerFork1 == true)
            {
                if (draw.ReturnPlayerChoice2("갈림길을 선택해 주세요.", "↙", "↖") == 0)
                {
                    bPlayerFork1 = false;
                    bPlayerFork3 = true;
                }
            }
        }
        public void PlayerChoiceEvent(Draw draw)
        {
            if(nPlayerOnMap == 4 || nPlayerOnMap == 9 || nPlayerOnMap == 28)
            {
                if (draw.ReturnPlayerChoice2("이벤트를 발동하시겠습니까?", "예", "아니요") == 0)
                {
                Random rand = new Random();
                int nEvent = rand.Next(0, 7);
                    switch (nEvent)
                    {
                        case 0:
                            nPlayerMoney += 5;
                            Console.SetCursorPosition()
                            break;
                    }
                }
            }

        }
        public void PlayerGoPrison()
        {

        }
        public void PlayerBuyBuilding()
        {

        }
        #endregion
    }
    
    #endregion
    struct Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}