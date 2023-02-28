using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CSharp4_2;

namespace CSharp4_2
{
    // 생명체 인터페이스 생성, 생명체는 공격하기, 공격받기, 회피하기, 피해받기가 있음, 플레이어와 몬스터중 하나가 죽을때까지 계속 공격, 일정확률로 회피
    class Program
    {
        static void Main(string[] args)
        {
            #region entity
            Player player = new Player();
            Monster monster = new Monster();

            while (player.Hp != 0 && monster.Hp != 0)
            {
                player.Attack(monster);
                Thread.Sleep(500);
                monster.Attack(player);
                Thread.Sleep(500);
                if (player.Hp == 0)
                {
                    System.Console.WriteLine("플레이어가 죽었습니다.");
                }
                if (monster.Hp == 0)
                {
                    System.Console.WriteLine("몬스터가 죽었습니다.");
                }
                System.Console.WriteLine();
            }
            #endregion
            #region abstract
            //Player player = new Player();
            //Zombie zombie = new Zombie();
            //Ghoul ghoul = new Ghoul();

            //zombie.AttackPlayer(player);
            //System.Console.WriteLine();
            //ghoul.AttackPlayer(player);
            #endregion
            #region interface
            //DarkMonster darkmonster = new DarkMonster();
            //LightMonster lightmonster = new LightMonster();
            //Player player = new Player();
            //player.AttackMonster(darkmonster);
            //player.AttackMonster(lightmonster);
            #endregion
        }
    }
    #region entity virtual
    class IEntity
    {
        public int Hp = 3;
        public int Damage = 1;
        public virtual void Attack(IEntity entity)
        {   
            System.Console.WriteLine("플레이어가 몬스터를 공격함");
            entity.Attacked();
        }
        public void Attacked()
        {
            Random rand = new Random();
            int randInt = rand.Next(0, 2);
            if (randInt == 0)
            {
                Dodge();
            }
            else
            {
                Damaged();
            }
        }
        public virtual void Damaged()
        {
            Hp--;
            System.Console.WriteLine($"플레이어가 데미지를 입음 플레이어 체력 : {Hp}");
        }
        public virtual void Dodge()
        {
            System.Console.WriteLine("몬스터가 공격을 회피함");
        }
    }
    }
    class Player : IEntity
    {

    }
    class Monster : IEntity
    {
        public int Hp = 3;
        public override void Attack(IEntity entity)
        {
            System.Console.WriteLine("몬스터가 플레이어를 공격함");
            entity.Attacked();
        }

        public override void Damaged()
        {
            Hp -= Damage;
            System.Console.WriteLine($"몬스터가 데미지를 입음 몬스터 체력 : {Hp}");
        }

        public override void Dodge()
        {
            System.Console.WriteLine("플레이어가 공격을 회피함");
        }
    }
#endregion
    #region entity interface
    //interface IEntity
    //{
    //    void Attack(IEntity entity);
    //    void Attacked();
    //    void Damaged();
    //    void Dodge();
    //}
    //class Player : IEntity
    //{
    //    public int Hp = 3;
    //    public int Damage = 1;
    //    public void Attack(IEntity entity)
    //    {            
    //        System.Console.WriteLine("플레이어가 몬스터를 공격함");
    //        entity.Attacked();
    //    }

    //    public void Attacked()
    //    {
    //        Random rand = new Random();
    //        int randInt = rand.Next(0, 2);
    //        if(randInt == 0)
    //        {
    //            Dodge();
    //        }
    //        else
    //        {
    //            Damaged();
    //        }
    //    }

    //    public void Damaged()
    //    {
    //        Hp -= Damage;
    //        System.Console.WriteLine($"플레이어가 데미지를 입음 플레이어 체력 : {Hp}");
    //    }

    //    public void Dodge()
    //    {
    //        System.Console.WriteLine("몬스터가 공격을 회피함");
    //    }
    //}
    //class Monster : IEntity
    //{
    //    public int Hp = 3;
    //    public int Damage = 1;
    //    public void Attack(IEntity entity)
    //    {            
    //        System.Console.WriteLine("몬스터가 플레이어를 공격함");
    //        entity.Attacked();
    //    }

    //    public void Attacked()
    //    {
    //        Random rand = new Random();
    //        int randInt = rand.Next(0, 2);
    //        if (randInt == 0)
    //        {
    //            Dodge();
    //        }
    //        else
    //        {
    //            Damaged();
    //        }
    //    }

    //    public void Damaged()
    //    {
    //        Hp -= Damage;
    //        System.Console.WriteLine($"몬스터가 데미지를 입음 몬스터 체력 : {Hp}");
    //    }

    //    public void Dodge()
    //    {
    //        System.Console.WriteLine("플레이어가 공격을 회피함");
    //    }
    //}
    #endregion
    #region abstract
    //abstract class DarkMonster
    //{
    //    int attackValue = 10;

    //    public abstract void AttackPlayer(Player player);
    //}
    //class Player
    //{
    //    int Hp = 100;

    //    public void HitFromMonster(int damage)
    //    {
    //        Hp -= damage;
    //        System.Console.WriteLine($"hp is {Hp}");
    //    }
    //}
    //class Zombie : DarkMonster
    //{
    //    public override void AttackPlayer(Player player)
    //    {
    //        System.Console.WriteLine("player bleeding");
    //    }
    //}
    //class Ghoul: DarkMonster
    //{
    //    public override void AttackPlayer(Player player)
    //    {
    //        System.Console.WriteLine("player curse");
    //    }
    //}
    #endregion
    #region interface
    //interface Monster
    //    {
    //        void HitFromPlayer(int damage);
    //    }

    //    class DarkMonster : Monster
    //    {
    //        int hp = 100;

    //        public void HitFromPlayer(int damage)
    //        {
    //            hp -= damage;
    //            System.Console.WriteLine($"dark monster hp is {hp}");
    //        }
    //    }
    //class LightMonster : Monster
    //{
    //    int hp = 100;

    //    public void HitFromPlayer(int damage)
    //    {
    //        hp = hp - (damage / 2);
    //        System.Console.WriteLine($"light monster hp is {hp}");
    //    }
    //}
    //    class Player
    //    {
    //        int AttackDamage = 15;

    //        public void AttackMonster(Monster monster)
    //        {
    //            System.Console.WriteLine("attack monster");
    //            monster.HitFromPlayer(AttackDamage);
    //        }
    //    }
    #endregion
}
