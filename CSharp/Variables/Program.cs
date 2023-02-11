//변수 (Variables)
//아직 정해지지 않은 값

//변수를 사용하겠다고 '선언' 하는 것의 의미:
//특징 형태의 값이 들어갈 수 있는 (쓸수 있는) 메모리영역의 공간을 할당

//변수 선언 형태
//자료형 이름;

//초기화 형태 :
//자료 형 이름 = 초기화 값;
// = 대입 연산연산자, 오른쪽에 있는 값을 왼쪽에있는 변수에 대입하는 연산자
int number1 = 25;//부호가 있는 4byte 정수형
int number2 = 4;
short snum;//부호가 있는 2byte형 정수형
long lnum;//부호가 있는 8byte 정수형
float fnum = 2.0f;// 4byte 실수형
double dnum = 4.2;// 8byte 실수형
char c = 'k'; // 2byte 문자형
string s = "안녕"; //2byte * 문자개수 + 1byte (null) 문자열형
bool isTrue = false; // 1byte 논리형