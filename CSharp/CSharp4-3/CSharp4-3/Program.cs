using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Monster> monster = new Dictionary<string, Monster>();
            {
                Monster zombie = new Monster();
                zombie.name = "zombie";
                Monster skelaton = new Monster();
                skelaton.name = "skelaton";
                Monster ghoul = new Monster();
                ghoul.name = "ghoul";
                Monster dragon = new Monster();
                dragon.name = "dragon";
                Monster golem = new Monster();
                golem.name = "golem";

                monster["zombie"] = zombie;
                monster["skelaton"] = skelaton;
                monster["ghoul"] = ghoul;
                monster["dragon"] = ghoul;
                monster["golem"] = ghoul;

                monster["zombie"].IntroduceMonster();
                monster["skelaton"].IntroduceMonster();
                monster["ghoul"].IntroduceMonster();
                monster["dragon"].IntroduceMonster();
                monster["golem"].IntroduceMonster();
            };
            
            #region city
            //List<City> citylist= new List<City>();
            //City seoul = new City();
            //seoul.name = "seoul";
            //City dokyo = new City();
            //dokyo.name = "dokyo";
            //City busan = new City();
            //busan.name = "busan";
            //City paris = new City();
            //paris.name = "paris";
            //City incheon = new City();
            //incheon.name = "incheon";

            //citylist.Add(seoul);
            //citylist.Add(dokyo);
            //citylist.Add(busan);
            //citylist.Add(paris);
            //citylist.Add(incheon);

            //for (int i = 0; i <citylist.Count; i++)
            //{
            //    citylist[i].IntroduceCity();
            //}
            #endregion
            #region list
            //List<int> intList = new List<int>() { 6, 2, 4, 6 };

            //intList.Add(7);
            //intList.Add(91);

            //for (int i = 0; i <intList.Count; i++)
            //{
            //    Console.WriteLine(intList[i]);
            //}
            //System.Console.WriteLine();

            //intList.Remove(7);
            //for (int i = 0; i < intList.Count; i++)
            //{
            //    Console.WriteLine(intList[i]);
            //}
            //System.Console.WriteLine();

            //intList.Insert(3, 9);
            //for (int i = 0; i < intList.Count; i++)
            //{
            //    Console.WriteLine(intList[i]);
            //}
            //System.Console.WriteLine();

            //intList.Clear();
            //for (int i = 0; i < intList.Count; i++)
            //{
            //    Console.WriteLine(intList[i]);
            //}
            //System.Console.WriteLine();
            #endregion
        }
    }
    class Monster
    {
        public string name;

        public void IntroduceMonster()
        {
            System.Console.WriteLine($"몬스터 이름은 {name}입니다");
        }
    }
    #region city
    //class City
    //{
    //    public string name;

    //    public void IntroduceCity()
    //    {
    //        System.Console.WriteLine($"this city is {name}");
    //    }
    //}
    #endregion
}
