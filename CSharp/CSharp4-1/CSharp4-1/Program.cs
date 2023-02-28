using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp4_1
{

    class Program
    {
      
        static void Main(string[] args)
        {
            #region Bank
            //int myMoney = 100;

            //Bank Abank = new Bank();
            //Bank Bbank = new Bank();

            //int nChoice;
            //int nChoiceMoney;
            //bool i = true ;
            //while(i)
            //{
            //    System.Console.WriteLine("1. 입금  2. 출금  3. 이체     이외의 키를 누르면 종료합니다.");
            //    nChoice = Convert.ToInt32(System.Console.ReadLine());
            //    switch (nChoice)
            //    {
            //        case 1:
            //            System.Console.WriteLine("금액을 입력해주세요");
            //            nChoiceMoney = Convert.ToInt32(System.Console.ReadLine());
            //            Abank.InputMoney(nChoiceMoney);
            //            myMoney -= nChoiceMoney;
            //            break;
            //        case 2:
            //            System.Console.WriteLine("금액을 입력해주세요");
            //            nChoiceMoney = Convert.ToInt32(System.Console.ReadLine());
            //            Abank.OutputMoney(nChoiceMoney);
            //            myMoney += nChoiceMoney;
            //            break;
            //        case 3:
            //            System.Console.WriteLine("금액을 입력해주세요");
            //            nChoiceMoney = Convert.ToInt32(System.Console.ReadLine());
            //            Abank.GiveMoney(nChoiceMoney);
            //            Bbank.TakeMoney(nChoiceMoney);
            //            System.Console.WriteLine($"A통장 잔고 {Abank.nMoney} B통장의 잔고 {Bbank.nMoney}");
            //            break;
            //        default:
            //            System.Console.WriteLine("반복을 종료합니다.");
            //            i = false;
            //            break;
            //    }
            //}
            #endregion
        }
    }
    #region Bank
    class Bank
        {
            public int nMoney;

            public void InputMoney(int Money)
            {
                nMoney += Money;
                System.Console.WriteLine($"A통장의 잔고는 {nMoney}입니다");
            }
            public void OutputMoney(int Money)
            {
                nMoney -= Money;
                System.Console.WriteLine($"A통장의 잔고는 {nMoney}입니다");
            }
            public void GiveMoney(int Money)
            {
                nMoney -= Money;
            }
            public void TakeMoney(int Money)
            {
                nMoney += Money;
            }
        }
    #endregion

}
