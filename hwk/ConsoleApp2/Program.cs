using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

//4. 이벤트
//    어느 날 갑자기 신문이 보고 싶어진 나.
//    이벤트를 이용하여 신문을 구독하고
//    해지하는 코드를 작성하시오.
//    (수업 시간에 배웠던 PrimeGenerator 예제 코드 참고)

namespace ConsoleApp2
{
    class Program
    {
        class Newspaper : EventArgs //콜백값을 담는 클래스  : 신문사 이름
        {
            public string m_makerName;
            public Newspaper(string makerName)
            {
                m_makerName = makerName;
            }
        }

        //콜백 매서드 호출
        class ReadNewspaper
        {
            public event EventHandler ReadNewspapers;
          
            //구독하고있는 신문사들 호출

            //신문사를 구독 - 추가
            public void AddSubscribe(string maker)
            {
                if(this.ReadNewspapers != null)
                {
                    ReadNewspapers(this, new Newspaper(maker));
                }
                else
                {
                    ReadNewspapers(this, new Newspaper(null));
                }
            }

            public void DeleteSubscribe(string maker)
            {
               
            }

           
        }
        static ArrayList maker = new ArrayList();

        static void PrintSubscribe(object sender,EventArgs args)
        { 
            if((args as Newspaper) != null)
            {
                Console.WriteLine((args as Newspaper).m_makerName + "사의 신문을 구독중");
            }
            if ((args as Newspaper) == null)
            {
                Console.WriteLine("fff");
            }
        }
        
        static void Subscribe(object sender, EventArgs args)
        {
            maker.Add((args as Newspaper).m_makerName);
        }
             
        static void CancelSub(object sender, EventArgs args)
        {
            //if(args.Equals())
            //{

            //}
            maker.Remove((args as Newspaper).m_makerName);
        }
        
        static void Main(string[] args)
        {
            ReadNewspaper readNewspaper = new ReadNewspaper();
            readNewspaper.ReadNewspapers += PrintSubscribe;
            readNewspaper.ReadNewspapers += Subscribe;

            readNewspaper.AddSubscribe("좆선일보");
            readNewspaper.AddSubscribe("한겨레");
            readNewspaper.AddSubscribe("중앙일보");
            readNewspaper.AddSubscribe("동아일보");

           
            readNewspaper.ReadNewspapers -= Subscribe;
                        
        }
    }
}
