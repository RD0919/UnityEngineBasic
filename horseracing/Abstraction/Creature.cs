using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    //abstract 추상화 키워드
    //인스턴스를 만들지 않고 오로지 추상화를 하기위한 용도의 클래스/함수를 정의할 때 앞에 붙여줌.
    internal abstract class Creature
    {
        public int Lv;

        //abstract 함수
        //이 함수를 멤버로 가지는 클래스를 상속받은 지식 클래스가 이함수의 구현을 해야 한다는 선언을 할 때 사용한다.
        public abstract void Breath();
        
        //virtual 함수
        //이함수는 재정의가 가능하다.
        public virtual int GetLv()
        {
            return Lv;
        }
    }
}
