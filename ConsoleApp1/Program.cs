using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//2. IEnumerable 인터페이스
//    인벤토리 안에 방패 아이템이 3개 들어 있다.
//    foreach문으로 방패 안에 있는 아이템들을
//    열거할 수 있는 코드를 작성하시오.

class Item
{
}
class Shield
{
    string m_name;
    public Shield(string name)
    {
        m_name = name;
    }

    public override string ToString()
    {
        return m_name;
    }

}

class Inventory : Item, IEnumerable
{
    Shield[] shieldList = new Shield[] {new Shield("나무방패"),new Shield("타워쉴드"), new Shield("빔실드") };

    public IEnumerator GetEnumerator() //열거자 인스턴스 반환
    {
        return new ShieldIEnumerator(shieldList);
    }

    public class ShieldIEnumerator : IEnumerator //중첩클래스로  정의된 열거자 타입
    {
        int m_index = -1;
        int m_length = 0;
        object[] m_list;

        public ShieldIEnumerator(Shield[] shield)
        {
            m_list = shield;
            m_length = shield.Length;
        }

        public object Current //현재 요소를 반환하도록 하는 접근자 메서드
        {
            get
            {
                return m_list[m_index];
            }
        }
        public bool MoveNext() //다음 
        {
            if(m_index >= m_length - 1)
            {
                return false;
            }
            m_index++;
            return true;
        }

        public void Reset() //초기화
        {
            m_index = -1; 
        }
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inven = new Inventory();
            
            foreach(Shield shield in inven)
            {
                Console.WriteLine(shield);
            }

        }
    }
}
