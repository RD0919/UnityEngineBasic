

//함수
//함수 선언
// C# 에서는 추상화를 할 때만 함수 선언을 함.

//함수 정의
//반환 타입 함수 이름 (매개변수1타입 매개변수 이름, 매개변수2타임 매개변수이름)
//{
// 구현부
// return 반환값
//}

int Sum(int op1, int op2)
{
    //return
    //이 함수가 할당된 수택영역의 메모리 제어권을 반환한다
    // 함수의 연산 결과값을 반환한다
    return op1 + op2;
}

// 정해진 타입이 없음
void SayHello()
{
    Console.WriteLine("SayHello");
    return; //void 반환 하는 함수의 가장 마징막라인의 return은 생략가능,
}

//3가지 실수를 더하고 결과를  콘솔창에 출력 후 연산결과를 반환하는 함수 작성
//3가지 실수를 더해야 한다
//더한 연산결과값을 콘솔창에 출력
//연산결과값을 반환


int result = 0;
//함수 호출
//형태 :
//함수이름(인자1, 인자2, ...);
result = Sum(1, 1);
Console.WriteLine($"1 + 1 = {result}");

//지역변수 : {} 영역 안에서 선언되고 해당 영역을 벗어나면 메모리 헤제되는 변수
float number(float a, float b, float c)
{
    float d = a + b + c;
    Console.WriteLine(d);
    return d;
}
