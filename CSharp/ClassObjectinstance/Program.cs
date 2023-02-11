//using 키워드
//using namespace이름 :
//특정 namespace를 이 cs에서 사용하겠다
using ClassObjectlnstance;
using System.Text;

//값타입, 참조타입
// 값타입 : 값을 직접 메모리에 쓰고 있는 형태, 일반적으로 스택영역에 할당
//참조타입: 데이터이 있는 메모리의 주소로 간접 쓰기/읽기를 하는 형태, 힙영역의 할당

//new 키워드
// 동작할당 키워드, 런타임에서 메모리를 동적할당할 때 사용
SwordMan swordMan = new SwordMan();
//연산자
//멤버접근연산자
swordMan._name = "검사1";
swordMan.Attack();
swordMan.Jump();

SwordMan swordMan2 = new SwordMan();
swordMan2._name = "검사2";

swordMan = swordMan2;
swordMan2.Attack();
swordMan2.Jump();