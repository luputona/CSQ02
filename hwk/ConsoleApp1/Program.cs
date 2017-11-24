using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//3. 느슨한 결합
//    간단한 슈팅 게임이 있다고 치자.
//    발사하는 탄알에는,
//   소이탄, 산탄, 공포탄, 철갑탄이 있다고 하자.
//   탄창에 4개의 탄알을 집어 넣고
//    필요할 때마자 원하는 총알을 꺼내서 발사한다.
//    각각의 총알은 발사할 때 각각 고유의 소리가 난다.
//	=> 인터페이스를 이용해 코드를 작성하시오.

interface IBullet
{
    void Fire();
    void Sound();
}

class IncendiaryBomb : IBullet
{
    public void Fire()
    {
        Console.WriteLine("소이탄 장전");
        
    }
    public void Sound()
    {
        Console.WriteLine("소이탄 발사, 퐈아아아아");
    }
}
class Buckshot : IBullet
{
    public void Fire()
    {
        Console.WriteLine("샷건 장전");
    }
    public void Sound()
    {
        Console.WriteLine("샷건 발사, 뚜쉬");
    }
}
class Blankammuition : IBullet
{
    public void Fire()
    {
        Console.WriteLine("공포탄 장전");
    }
    public void Sound()
    {
        Console.WriteLine("공포탄 발사, 탕");
    }
}
class Armorpiercing : IBullet
{
    public void Fire()
    {
        Console.WriteLine("철갑탄 장전");
    }
    public void Sound()
    {
        Console.WriteLine("철갑탄 발사, 타앙");
    }
}

class Magazines
{
    public void Fire(IBullet bulletChange)
    {
       
        bulletChange.Sound();
    }
    public void Reload(IBullet bulletChange)
    {
        bulletChange.Fire();
    }        
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //장전
            IncendiaryBomb incend = new IncendiaryBomb();
            Buckshot buckShot = new Buckshot();
            Armorpiercing piercing = new Armorpiercing();
            Blankammuition blankAmmuition = new Blankammuition();

            Magazines magazines = new Magazines();

            magazines.Reload(incend);
            magazines.Fire(incend);

            Console.WriteLine();

            magazines.Reload(buckShot);
            magazines.Fire(buckShot);

            Console.WriteLine();

            magazines.Reload(piercing);
            magazines.Fire(piercing);

            Console.WriteLine();

            magazines.Reload(blankAmmuition);
            magazines.Fire(blankAmmuition);

            Console.WriteLine();
        }
    }
}
