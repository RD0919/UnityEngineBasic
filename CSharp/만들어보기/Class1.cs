using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 만들어보기
{
    internal class Orc
    {

        //멤버 변수
        //--------------------
        public string a;
        public int b;
        public float c;
        public float d;
        public char e;


        //멤버 함수
        //-------------------
        public Orc()
        {

        }

        ~Orc()
        {

        }

        public void SayMyName()
        {
            Console.WriteLine($"나의 이름는 {a}");
        }

        public void SayMyinfo()
        {
            Console.WriteLine($"나이 : {b}, 키 : {c}, 몸무게 : {d}, 성별 : {e}");
        }

    }
}
