using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//1. 인터페이스를 이용한 콜백 구현


//    어제 배운 내용 복습(Array.Sort)

interface IBase
{
    string GetResult(); // 콜백용 함수
}
class CBase : IBase
{
    Target target = new Target();

    public string GetResult()
    {
        return "콜백호출";
    }
    public void Show()
    {
        target.Do(this);
    }
}

class Target
{
    public void Do(IBase obj) //인터페이스 타입으로 받는다
    {
        Console.WriteLine(obj.GetResult());
    }
}

namespace hwk
{
    class Program
    {
        static void Main(string[] args)
        {
            CBase cbase = new CBase();
            cbase.Show();
        }
    }
}
