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
            Draw draw = new Draw();
            Player player = new Player();
            Enemy enemy = new Enemy();
            draw.DrawIntroduceScreen();
            draw.DrawBackground(player, enemy);

            
        }
    }
    class Draw
    {
        
        public void DrawBackground(Player player, Enemy enemy)
        {
            Console.SetCursorPosition(0, 46);
            for (int i = 0; i < 65; i++) { System.Console.Write("■"); }
            DrawMap(player, enemy);

        }
        public void DrawIntroduceScreen()
        {
            Console.SetWindowSize(130, 60);
            Console.Title = "부루마블 + 윳놀이";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(50, 4);
            System.Console.Write("부루마블 + 윳놀이");
            Console.SetCursorPosition(10, 7);
            System.Console.Write("맵 설명");
            Console.SetCursorPosition(10, 9);
            System.Console.Write("맵은 윳놀이와 동일하고 윳을 던져서 움직인다.(빽도 있음)");
            Console.SetCursorPosition(10, 10);
            System.Console.Write("말은 1개이며 플레이어의 말은 파란색, 상대의 말은 빨간색이다.");
            Console.SetCursorPosition(10, 11);
            System.Console.Write("라인의 각 중간에는 이벤트 칸이 있다");
            Console.SetCursorPosition(10, 12);
            System.Console.Write("이벤트 칸과 각 라인의 모서리를 제외한 칸은 건물을 지어 통행료를 받을 수 있고 건물 인수와 랜드마크 건설은 없다.");
            Console.SetCursorPosition(10, 13);
            System.Console.Write("아무것도 짓지 않은 곳은 흰색, 플레이어의 소유는 빨강색, 상대의 소유는 파란색이고 건물의 단계는 숫자로 표시된다.");
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
            Console.ReadKey();
            Console.Clear();
        }
        #region drawmap
        public void DrawMap(Player player, Enemy enemy)
        {
            Console.SetCursorPosition(12, 38);
            System.Console.Write("출발");
            Console.SetCursorPosition(10, 37);
            System.Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(10, 38);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(10, 39);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(10, 40);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(10, 41);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(10, 42);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(10, 43);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(10, 44);
            System.Console.Write("┗━━━━━━━━━━━━━━┛");

            if(player.PlayerBuilding1 == false && enemy.EnemyBuilding1 == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(30, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(30, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(30, 43);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if(player.PlayerBuilding1 == true && enemy.EnemyBuilding1 == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(30, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(30, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(30, 43);
                System.Console.Write($"┃     {player.PlayerBuildingLevel1}    ┃");
                Console.SetCursorPosition(30, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if(player.PlayerBuilding1 == false && enemy.EnemyBuilding1 == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(30, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(30, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(30, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(30, 43);
                System.Console.Write($"┃     {enemy.EnemyBuildingLevel1}    ┃");
                Console.SetCursorPosition(30, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }

            if (player.PlayerBuilding2 == false && enemy.EnemyBuilding2 == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(47, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(47, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(47, 43);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if (player.PlayerBuilding2 == true && enemy.EnemyBuilding2 == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(47, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(47, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(47, 43);
                System.Console.Write($"┃     {player.PlayerBuildingLevel2}    ┃");
                Console.SetCursorPosition(47, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if (player.PlayerBuilding2 == false && enemy.EnemyBuilding2 == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(47, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(47, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(47, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(47, 43);
                System.Console.Write($"┃     {enemy.EnemyBuildingLevel2}    ┃");
                Console.SetCursorPosition(47, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }

            if (player.PlayerBuilding3 == false && enemy.EnemyBuilding3 == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(64, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(64, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(64, 43);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if (player.PlayerBuilding3 == true && enemy.EnemyBuilding3 == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(64, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(64, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(64, 43);
                System.Console.Write($"┃    {player.PlayerBuildingLevel3}     ┃");
                Console.SetCursorPosition(64, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if (player.PlayerBuilding3 == false && enemy.EnemyBuilding3 == true)
            {
                Console.SetCursorPosition(64, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(64, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(64, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(64, 43);
                System.Console.Write($"┃     {enemy.EnemyBuildingLevel3}    ┃");
                Console.SetCursorPosition(64, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }

            if (player.PlayerBuilding4 == false && enemy.EnemyBuilding4 == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(81, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(81, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(81, 43);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if (player.PlayerBuilding4 == true && enemy.EnemyBuilding4 == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(81, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(81, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(81, 43);
                System.Console.Write($"┃     {player.PlayerBuildingLevel4}    ┃");
                Console.SetCursorPosition(81, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }
            else if (player.PlayerBuilding4 == false && enemy.EnemyBuilding4 == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(81, 38);
                System.Console.Write("┏━━━━━━━━━━┓");
                Console.SetCursorPosition(81, 39);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 40);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 41);
                System.Console.Write("┃          ┃");
                Console.SetCursorPosition(81, 42);
                System.Console.Write("┣━━━━━━━━━━┫");
                Console.SetCursorPosition(81, 43);
                System.Console.Write($"┃     {enemy.EnemyBuildingLevel4}    ┃");
                Console.SetCursorPosition(81, 44);
                System.Console.Write("┗━━━━━━━━━━┛");
            }

            Console.SetCursorPosition(98, 37);
            System.Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(98, 38);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 39);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 40);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 41);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 42);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 43);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 44);
            System.Console.Write("┗━━━━━━━━━━━━━━┛");

            if (player.PlayerBuilding6 == false && enemy.EnemyBuilding6 == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(100, 30);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 31);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 32);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 33);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 34);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 35);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (player.PlayerBuilding6 == true && enemy.EnemyBuilding6 == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(100, 30);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 31);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 32);
                System.Console.Write($"┃        ┃ {player.PlayerBuildingLevel6}  ┃");
                Console.SetCursorPosition(100, 33);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 34);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 35);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (player.PlayerBuilding6 == false && enemy.EnemyBuilding6 == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(100, 30);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 31);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 32);
                System.Console.Write($"┃        ┃ {enemy.EnemyBuildingLevel6} ┃");
                Console.SetCursorPosition(100, 33);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 34);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 35);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }

            if (player.PlayerBuilding7 == false && enemy.EnemyBuilding7 == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(100, 23);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 24);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 25);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 26);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 27);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 28);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (player.PlayerBuilding7 == true && enemy.EnemyBuilding7 == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(100, 23);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 24);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 25);
                System.Console.Write($"┃        ┃ {player.PlayerBuildingLevel7}  ┃");
                Console.SetCursorPosition(100, 26);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 27);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 28);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (player.PlayerBuilding7 == false && enemy.EnemyBuilding7 == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(100, 23);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 24);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 25);
                System.Console.Write($"┃        ┃ {enemy.EnemyBuildingLevel7} ┃");
                Console.SetCursorPosition(100, 26);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 27);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 28);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }

            if (player.PlayerBuilding8 == false && enemy.EnemyBuilding8 == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(100, 16);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 17);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 18);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 19);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 20);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 21);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (player.PlayerBuilding8 == true && enemy.EnemyBuilding8 == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(100, 16);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 17);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 18);
                System.Console.Write($"┃        ┃ {player.PlayerBuildingLevel8}  ┃");
                Console.SetCursorPosition(100, 19);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 20);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 21);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (player.PlayerBuilding8 == false && enemy.EnemyBuilding8 == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(100, 16);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 17);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 18);
                System.Console.Write($"┃        ┃ {enemy.EnemyBuildingLevel8} ┃");
                Console.SetCursorPosition(100, 19);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 20);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 21);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }

            if (player.PlayerBuilding7 == false && enemy.EnemyBuilding7 == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(100, 9);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 10);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 11);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 12);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 13);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 14);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (player.PlayerBuilding7 == true && enemy.EnemyBuilding7 == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(100, 9);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 10);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 11);
                System.Console.Write($"┃        ┃ {player.PlayerBuildingLevel7}  ┃");
                Console.SetCursorPosition(100, 12);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 13);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 14);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }
            else if (player.PlayerBuilding7 == false && enemy.EnemyBuilding7 == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(100, 9);
                System.Console.Write("┏━━━━━━━━┳━━━┓");
                Console.SetCursorPosition(100, 10);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 11);
                System.Console.Write($"┃        ┃ {enemy.EnemyBuildingLevel7} ┃");
                Console.SetCursorPosition(100, 12);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 13);
                System.Console.Write("┃        ┃   ┃");
                Console.SetCursorPosition(100, 14);
                System.Console.Write("┗━━━━━━━━┻━━━┛");
            }

            Console.SetCursorPosition(98, 0);
            System.Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(98, 1);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 2);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 3);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 4);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 5);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 6);
            System.Console.Write("┃              ┃");
            Console.SetCursorPosition(98, 7);
            System.Console.Write("┗━━━━━━━━━━━━━━┛");


            //if (player.PlayerBuilding11 == false && enemy.EnemyBuilding11 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding11 == true && enemy.EnemyBuilding11 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel1}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding11 == false && enemy.EnemyBuilding11 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel1}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding12 == false && enemy.EnemyBuilding12 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding12 == true && enemy.EnemyBuilding12 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel12}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding12 == false && enemy.EnemyBuilding12 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel12}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding13 == false && enemy.EnemyBuilding13 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding13 == true && enemy.EnemyBuilding13 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel13}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding13 == false && enemy.EnemyBuilding13 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel13}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding14 == false && enemy.EnemyBuilding14 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding14 == true && enemy.EnemyBuilding14 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel14}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding14 == false && enemy.EnemyBuilding14 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel14}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //Console.SetCursorPosition(5, 35);
            //System.Console.Write("┏━━━━━━━━━━━━━━┓");
            //Console.SetCursorPosition(5, 36);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 37);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 38);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 39);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 40);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 41);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 42);
            //System.Console.Write("┗━━━━━━━━━━━━━━┛");


            //if (player.PlayerBuilding16 == false && enemy.EnemyBuilding16 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding16 == true && enemy.EnemyBuilding16 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel16}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding16 == false && enemy.EnemyBuilding16 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel16}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding17 == false && enemy.EnemyBuilding17 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding17 == true && enemy.EnemyBuilding17 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel17}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding17 == false && enemy.EnemyBuilding17 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel17}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding18 == false && enemy.EnemyBuilding18 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding18 == true && enemy.EnemyBuilding18 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel18}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding18 == false && enemy.EnemyBuilding18 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel18}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding19 == false && enemy.EnemyBuilding19 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding19 == true && enemy.EnemyBuilding19 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel19}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding19 == false && enemy.EnemyBuilding19 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel19}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding20 == false && enemy.EnemyBuilding20 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding20 == true && enemy.EnemyBuilding20 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel20}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding20 == false && enemy.EnemyBuilding20 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel20}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding21 == false && enemy.EnemyBuilding21 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding21 == true && enemy.EnemyBuilding21 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel21}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding21 == false && enemy.EnemyBuilding21 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel21}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //Console.SetCursorPosition(5, 35);
            //System.Console.Write("┏━━━━━━━━━━━━━━┓");
            //Console.SetCursorPosition(5, 36);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 37);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 38);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 39);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 40);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 41);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 42);
            //System.Console.Write("┗━━━━━━━━━━━━━━┛");

            //if (player.PlayerBuilding23 == false && enemy.EnemyBuilding23 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding23 == true && enemy.EnemyBuilding23 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel1}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding23 == false && enemy.EnemyBuilding23 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel23}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding24 == false && enemy.EnemyBuilding24 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding24 == true && enemy.EnemyBuilding24 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel24}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding24 == false && enemy.EnemyBuilding24 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel24}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding25 == false && enemy.EnemyBuilding25 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding25 == true && enemy.EnemyBuilding25 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel25}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding25 == false && enemy.EnemyBuilding25 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel25}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding26 == false && enemy.EnemyBuilding26 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding26 == true && enemy.EnemyBuilding26 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel26}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding26 == false && enemy.EnemyBuilding26 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel26}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding27 == false && enemy.EnemyBuilding27 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding27 == true && enemy.EnemyBuilding27 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel27}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding27 == false && enemy.EnemyBuilding27 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel27}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //if (player.PlayerBuilding28 == false && enemy.EnemyBuilding28 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Black;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding28 == true && enemy.EnemyBuilding28 == false)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {player.PlayerBuildingLevel28}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}
            //else if (player.PlayerBuilding28 == false && enemy.EnemyBuilding28 == true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(24, 36);
            //    System.Console.Write("┏━━━━━━━━━━┓");
            //    Console.SetCursorPosition(24, 37);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 38);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 39);
            //    System.Console.Write("┃          ┃");
            //    Console.SetCursorPosition(24, 40);
            //    System.Console.Write("┣━━━━━━━━━━┫");
            //    Console.SetCursorPosition(24, 41);
            //    System.Console.Write($"┃     {enemy.EnemyBuildingLevel28}    ┃");
            //    Console.SetCursorPosition(24, 42);
            //    System.Console.Write("┗━━━━━━━━━━┛");
            //}

            //Console.SetCursorPosition(5, 35);
            //System.Console.Write("┏━━━━━━━━━━━━━━┓");
            //Console.SetCursorPosition(5, 36);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 37);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 38);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 39);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 40);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 41);
            //System.Console.Write("┃              ┃");
            //Console.SetCursorPosition(5, 42);
            //System.Console.Write("┗━━━━━━━━━━━━━━┛");
        }
        #endregion
    }

    #region player
    class Player
    {
        public int PlayerOnMap = 0;

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
        #endregion

        #region PlayerBuildingLevel
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

    }
    #endregion

    #region enemy
    class Enemy
    {
        public int EnemyOnMap = 0;

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
        #endregion

        #region EnemyBuildingLevel
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

    }
    #endregion
}
