using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//클래스
//사용자 정의 자료형
//멤버 변수 및 함수등의 캡슐화 형태


//namespace 키워드
//특정 이름으로 식별할 공간을 구분하는 키워드

namespace ClassObjectlnstance
{
    // 클래스 정의 형태:
    //class 클래스 이름
    //{
    //클래스의 멥버들
    //}


    internal class SwordMan
    {
        //파스칼(CamelCase),카멜(camelCase), 스네이크(snake_case) 어퍼 스네이크(UPPER_SNAKE_CASE) 캐이스

        //접근 제한자
        //public : 접근 제한 없음
        //protected :  자식(상속 타입) 이 부모(기반 타입) 에 접근할 수 있음
        //internal : 동일 어셈블리(프로젝트)에서 제한없이 접근가능
        //private : 타 클래스 접근 불가능
        //클래스는 기본적으로 캡슐화를 위한 타입이기 떼문에 
        //접근제한자가 명시되지 않을 경우에 defult 접근제한자는 private이다.

        //멤버 변수
        //-------------------
        private int _lv;
        private float _exp;
        private char _gender;
        public string _name;

        //클래스 생성자
        //객체를 힙영역에 할당하고 하달한 힙영역의 주소참조를 반환
        //따로 정의하지 않아도 Default 생성자는 클래스를 정의하면 생성됨
        public SwordMan()
        {

        }

        // 소멸자
        // 해당 객체가 할당된 영역의 메모리를 해제할 때 호출하는 함수
        // 이 객체가 더이상 참조되지 않을때 .Net 의 CLR 의 GarbageCollector 가
        //알아서 호출해주기 때문에 직접 호출할 일 없음.
        ~SwordMan()
        {

        }

        //멤버 함수들
        //-------------------
        public void Attack()
        {
            Console.WriteLine($"{_name} 이(가) 공격을 했다 ..!");
        }

        public void Jump()
        {
            Console.WriteLine($"{_name} 이(가) 뛰었다 ..!");
        }
    }
}
