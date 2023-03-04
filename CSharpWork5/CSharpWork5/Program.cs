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
            draw.DrawIntroduceScreen();

            //유저 수 선택

            Player[] player = new Player[2];
            Player Commender = new Player();
            SetColor(player, 2);

            int nTurn = 1; //현재 턴
            int nUserCount = 2;// 유저 수
            string chName = "";
            int nTurnCount = 0;


            while (true)
            {
                //배경 그리기
                draw.DrawBackground(nTurn, chName, player);
                draw.DrawMap(player[0]);
                for(int i = 0; i < nUserCount; i++)
                {
                    draw.DrawUnitMove(player[i], player[i].PlayerColor);
                }
                //윳 던지기 
                while (true)
                {
                    for(int i = 0; i < nUserCount; i++)
                    {
                        player[i].PlayerThrowYut();
                        draw.DrawPlayerYut(player[i], player[i].PlayerColor);
                        player[i].PlayerMove();
                        player[i].PlayerChoiceFork(draw);
                    }

                    //턴 끝내기 if (  ) { break; }
                }
                //턴 넘기기 
                    chName = player[nTurnCount].chPlayerName;
                    nTurnCount++;
                if(nTurnCount == nUserCount)
                {
                    nTurnCount = 0;
                    nTurn++;
                }
            }
            #endregion
        }
        #region method
        static void SelectNumberOfUser()
        {

        }
        static void SetColor(Player[] player, int nNumberofUser)
        {
            if (nNumberofUser == 2)
            {
                player[0].PlayerColor = ConsoleColor.Blue;
                player[1].PlayerColor = ConsoleColor.Red;
            }
            if (nNumberofUser == 3)
            {
                player[0].PlayerColor = ConsoleColor.Blue;
                player[1].PlayerColor = ConsoleColor.Red;
                player[2].PlayerColor = ConsoleColor.Green;
            }
            if (nNumberofUser == 4)
            {
                player[0].PlayerColor = ConsoleColor.Blue;
                player[1].PlayerColor = ConsoleColor.Red;
                player[2].PlayerColor = ConsoleColor.Green;
                player[3].PlayerColor = ConsoleColor.Yellow;
            }
        }
        #endregion
    }

    #region draw
    class Draw
    {
        public int nNumberOfUser = 0;

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
        public void DrawTileWidth(int nX, int nY, bool PlayerBuilding, int PlayerBuildingLevel, ConsoleColor color)
        {
            if (PlayerBuilding == true)
            {
                Console.ForegroundColor = color;
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
        }
        public void DrawTileHeight(int nX, int nY, bool PlayerBuilding, int PlayerBuildingLevel, ConsoleColor color)
        {
            if (PlayerBuilding == true)
            {
                Console.ForegroundColor = color;
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
            Console.SetCursorPosition(nX+5, nY+5);
            System.Console.Write("감옥");
        }

        #endregion
        #region drawmap
        public void DrawMap(Player player)
        {
            //0(start)
            DrawTileEdge(10, 37);
            Console.SetCursorPosition(17, 42);
            System.Console.Write("출발");

            //1
            DrawTileWidth(30, 38, player.bPlayerBuilding1, player.nPlayerBuildingLevel1, player.PlayerColor);
            //2
            DrawTileWidth(47, 38, player.bPlayerBuilding2, player.nPlayerBuildingLevel2, player.PlayerColor);
            //3
            DrawTileWidth(64, 38, player.bPlayerBuilding3, player.nPlayerBuildingLevel3, player.PlayerColor);
            //4
            DrawTileWidth(81, 38, player.bPlayerBuilding4, player.nPlayerBuildingLevel4, player.PlayerColor);
            //5
            DrawTileEdge(98, 37);
            //6
            DrawTileHeight(100, 30, player.bPlayerBuilding6, player.nPlayerBuildingLevel6, player.PlayerColor);
            //7
            DrawTileHeight(100, 23, player.bPlayerBuilding7, player.nPlayerBuildingLevel7, player.PlayerColor);
            //8
            DrawTileHeight(100, 16, player.bPlayerBuilding8, player.nPlayerBuildingLevel8, player.PlayerColor);
            //9
            DrawTileHeight(100, 9, player.bPlayerBuilding9, player.nPlayerBuildingLevel9, player.PlayerColor);
            //10
            DrawTileEdge(98, 0);
            //11
            DrawTileWidth(30, 0, player.bPlayerBuilding11, player.nPlayerBuildingLevel11, player.PlayerColor);
            //12 감옥
            DrawPrison(47, 0);
            //13
            DrawTileWidth(64, 0, player.bPlayerBuilding13, player.nPlayerBuildingLevel13, player.PlayerColor);
            //14
            DrawTileWidth(81, 0, player.bPlayerBuilding14, player.nPlayerBuildingLevel14, player.PlayerColor);
            //15
            DrawTileEdge(10, 0);
            //16
            DrawTileHeight(10, 30, player.bPlayerBuilding16, player.nPlayerBuildingLevel16, player.PlayerColor);
            //17
            DrawTileHeight(10, 23, player.bPlayerBuilding17, player.nPlayerBuildingLevel17, player.PlayerColor);
            //18
            DrawTileHeight(10, 16, player.bPlayerBuilding18, player.nPlayerBuildingLevel18, player.PlayerColor);
            //19
            DrawTileHeight(10, 9, player.bPlayerBuilding19, player.nPlayerBuildingLevel19, player.PlayerColor);
            //22
            DrawTileEdge(54, 19);
            //20 감옥
            DrawPrison(84, 30);
            //21
            DrawTileWidth(70, 24, player.bPlayerBuilding21, player.nPlayerBuildingLevel21, player.PlayerColor);
            //23
            DrawTileWidth(42, 14, player.bPlayerBuilding23, player.nPlayerBuildingLevel23, player.PlayerColor);
            //24
            DrawTileWidth(28, 8, player.bPlayerBuilding24, player.nPlayerBuildingLevel24, player.PlayerColor);
            //25
            DrawTileWidth(84, 8, player.bPlayerBuilding25, player.nPlayerBuildingLevel25, player.PlayerColor);
            //26
            DrawTileWidth(70, 14, player.bPlayerBuilding26, player.nPlayerBuildingLevel26, player.PlayerColor);
            //27
            DrawTileWidth(42, 24, player.bPlayerBuilding27, player.nPlayerBuildingLevel27, player.PlayerColor);
            //28
            DrawTileWidth(28, 30, player.bPlayerBuilding28, player.nPlayerBuildingLevel28, player.PlayerColor);
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
        public void DrawUnitMove(Player player, ConsoleColor color)
        {
            Console.ForegroundColor = color;
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
        }
        #endregion
        #region drawyut
        public void DrawPlayerYut(Player player, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            DrawYutImage(30, 46, player.nYut1);
            DrawYutImage(35, 46, player.nYut2);
            DrawYutImage(40, 46, player.nYut3);
            DrawYutImage(45, 46, player.nYut4);
            Console.SetCursorPosition(52, 46);
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
        public void DrawBackground(int nTurn, string chTurn, Player[] player)
        {
            Console.SetCursorPosition(0, 45);
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < 123; i++) { System.Console.Write("━"); }
            Console.SetCursorPosition(5, 46);
            System.Console.Write($"현재 턴 : {nTurn}");
            Console.SetCursorPosition(5, 48);
            System.Console.Write($"{chTurn}의 턴");
            for(int i = 0; i < nNumberOfUser; i++)
            {
                Console.SetCursorPosition(5, 50 + i * 2);
                System.Console.Write($"가 보유한 돈 : {player[i].nPlayerMoney}");
            }
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
            System.Console.Write("맵은 윳놀이와 동일하고 윳을 던져서 움직이며 말은 1개이다.");
            Console.SetCursorPosition(10, 10);
            System.Console.Write("2인 플레이가 가능하고 플레이어 1은 파랑, 플레이어 2는 빨강으로 표시된다.");
            Console.SetCursorPosition(10, 11);
            System.Console.Write("라인의 각 중간에는 이벤트 칸이 있고 감옥은 한 곳이 있다.");
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
                Console.SetCursorPosition(40, 46+i);
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

            int nReturn = 1;

            ClearInterface();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(40, 47);
            System.Console.Write($"{chQuestion}");
            Console.SetCursorPosition(40, 49);
            System.Console.Write($"1. {Answer1}");
            Console.SetCursorPosition(40, 51);
            System.Console.Write($"2. {Answer2}");

            while (true)
            {
                cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(36, 49);
                        System.Console.Write("⇛");
                        Console.SetCursorPosition(36, 51);
                        System.Console.Write(" ");
                        nReturn--;
                        if (nReturn < 1) nReturn = 2;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(36, 51);
                        System.Console.Write("⇛");
                        Console.SetCursorPosition(36, 49);
                        System.Console.Write(" ");
                        nReturn++;
                        if (nReturn > 2) nReturn = 1;
                        break;
                    case ConsoleKey.Spacebar:
                        return nReturn;
                }
            }
        }
    }
    #endregion

    #region player
    class Player
    {
        public string chPlayerName;
        public ConsoleColor PlayerColor = ConsoleColor.Black;

        public int nPlayerOnMap = 0;
        public int nPlayerMoney = 10;
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

        #region PlayerBuilding
        public bool bPlayerBuilding1 = false;
        public bool bPlayerBuilding2 = false;
        public bool bPlayerBuilding3 = false;
        public bool bPlayerBuilding4 = false;
        public bool bPlayerBuilding6 = false;
        public bool bPlayerBuilding7 = false;
        public bool bPlayerBuilding8 = false;
        public bool bPlayerBuilding9 = false;
        public bool bPlayerBuilding11 = false;
        public bool bPlayerBuilding12 = false;
        public bool bPlayerBuilding13 = false;
        public bool bPlayerBuilding14 = false;
        public bool bPlayerBuilding16 = false;
        public bool bPlayerBuilding17 = false;
        public bool bPlayerBuilding18 = false;
        public bool bPlayerBuilding19 = false;
        public bool bPlayerBuilding20 = false;
        public bool bPlayerBuilding21 = false;
        public bool bPlayerBuilding23 = false;
        public bool bPlayerBuilding24 = false;
        public bool bPlayerBuilding25 = false;
        public bool bPlayerBuilding26 = false;
        public bool bPlayerBuilding27 = false;
        public bool bPlayerBuilding28 = false;

        public int nPlayerBuildingLevel1 = 0;
        public int nPlayerBuildingLevel2 = 0;
        public int nPlayerBuildingLevel3 = 0;
        public int nPlayerBuildingLevel4 = 0;
        public int nPlayerBuildingLevel6 = 0;
        public int nPlayerBuildingLevel7 = 0;
        public int nPlayerBuildingLevel8 = 0;
        public int nPlayerBuildingLevel9 = 0;
        public int nPlayerBuildingLevel11 = 0;
        public int nPlayerBuildingLevel12 = 0;
        public int nPlayerBuildingLevel13 = 0;
        public int nPlayerBuildingLevel14 = 0;
        public int nPlayerBuildingLevel16 = 0;
        public int nPlayerBuildingLevel17 = 0;
        public int nPlayerBuildingLevel18 = 0;
        public int nPlayerBuildingLevel19 = 0;
        public int nPlayerBuildingLevel20 = 0;
        public int nPlayerBuildingLevel21 = 0;
        public int nPlayerBuildingLevel23 = 0;
        public int nPlayerBuildingLevel24 = 0;
        public int nPlayerBuildingLevel25 = 0;
        public int nPlayerBuildingLevel26 = 0;
        public int nPlayerBuildingLevel27 = 0;
        public int nPlayerBuildingLevel28 = 0;
        #endregion
        #region yut
        public void PlayerThrowYut()
        {
            bPlayerReroll = false;
            Console.SetCursorPosition(29, 52);
            Console.ForegroundColor = ConsoleColor.Black;
            System.Console.Write("스페이스바로 윷 던지기");

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
            if (nMove == 2)
            {
                chYut = "개";
                bPlayerReroll = false;
            }
            if (nMove == 3)
            {
                chYut = "걸";
                bPlayerReroll = false;
            }
            if (nMove == 4) 
            { 
                chYut = "윳";
                bPlayerReroll = true;
            }
            if (nMove == 0) 
            {
                chYut = "모";
                bPlayerReroll = true;
            }
        }
        #endregion
        public void PlayerMove()
        {
            if( bPlayerFork0 == true)
            {
                nPlayerOnMap += nMove;
                if(nPlayerOnMap >= 20) { nPlayerOnMap -= 20; }
            }
            if (bPlayerFork1 == true)
            {

            }
            if (bPlayerFork2 == true)
            {

            }
            if (bPlayerFork3 == true)
            {

            }

        }
        public void PlayerChoiceFork(Draw draw)
        {
            if (nPlayerOnMap == 5) 
            { 
                if(draw.ReturnPlayerChoice2("갈림길을 선택해 주세요.", "↖", "↑") == 1) 
                {
                    bPlayerFork0 = false;
                    bPlayerFork1 = true;
                    bPlayerFork2 = false;
                    bPlayerFork3 = false;
                }
            }
            else if (nPlayerOnMap == 10)
            {
                if (draw.ReturnPlayerChoice2("갈림길을 선택해 주세요.", "↙", "←") == 1)
                {
                    bPlayerFork0 = false;
                    bPlayerFork1 = false;
                    bPlayerFork2 = true;
                    bPlayerFork3 = false;
                }
            }
            else if (nPlayerOnMap == 22)
            {
                if (draw.ReturnPlayerChoice2("갈림길을 선택해 주세요.", "↙", "↖") == 1)
                {
                    bPlayerFork0 = false;
                    bPlayerFork1 = false;
                    bPlayerFork2 = false;
                    bPlayerFork3 = true;
                }
            }
        }
        public void PlayerChoiceEvent(Draw draw)
        {
            if (draw.ReturnPlayerChoice2("이벤트를 발동하시겠습니까?", "예", "아니요") == 1)
            {
                Random rand = new Random();
                int nEvent = rand.Next(0, 7);
            }
        }
    }
    #endregion
}