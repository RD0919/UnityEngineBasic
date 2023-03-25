using Collections;
using MyDynamicArray;
using System.Collections;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
//자료 구조
//자료구조에서 공통적으로 구현하는 요소들은
//탐색, 삽입, 삭제 알고리즘
//현재 자료 갯수


//Enumerator : 열거된 자료를 순회할 수 있는 타입/ 특정로직을 순서대로 순회할 수 있는 타입
//Current : 현재 참조하고 있는 자료/로직의 상태(스텝)
//MoveNext() : 다음 단계로 이동
//Reset() : Current를 end(default)로 초기화

#region 동적 배열
MyDynamicArray myDynamicArray = new MyDynamicArray();

myDynamicArray.Add(0);

Console.WriteLine();

for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.WriteLine($"{myDynamicArray[i]}.");
}

myDynamicArray[0] = 5;
myDynamicArray.Remove(5); //int 타입을 object 파라미터에 인자로 넘겨주면, object 타입으로 암시적 캐스팅(int 타입 변수를 만들고 그주소를 반환)이 일어남.
                          //즉, 정수 5에 대한 데이터를 가지는 Object가 힙 영역에 새로 할당되고 이 새로 할당된 객체가
                          // 동적 배열에 있으면 지워달라느 함수호출이 됨.
                          // 따라서 기존의 5에 대한 객체를 지우는 게 아니라 인자를 넘겨줄때 생긴 객체를 지워달라는 요청이됨.

myDynamicArray.RemoveAt(myDynamicArray.Findlndex(x => (int)x == 5));
                          

for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.WriteLine($"{myDynamicArray[i]}.");
}

// System.Object 타입. C#의 모즌 타입 기반 타입.
// 이타입에 다른 객체를 참조시킬 때 힙영역에 System.Object 타입의 객체가 할당됨
int a = 5;
object obj = a;// System.Object 타입 참조 변수
obj = a;// a를 System.Object 타입으로 변환한 객체를 힙영역에 할당하고 참조를 변환함 (Boxing) : 참조하는 변수 =>  힙영역에 객체(System.object)를 만들고 그(int= a) 주소를 만든다. 일반적인 대입연산보다 얃 20배 느림
obj = myDynamicArray;
MyDynamicArray da2 = (MyDynamicArray)obj; // Object 타입을 하위 타입으로 변환 (Unboxing)



//C# System.Collection의 동적배열
//-------------------------------------------------

ArrayList arrayList = new ArrayList();
arrayList.Add(3);
arrayList.Add("b");
arrayList.Add("안녕");




#endregion

#region Generic 동적배열

//내가 만든 동적배열
//--------------------------------------------

MyDynamicArray<double> doubleArray = new MyDynamicArray<double>();
//<T> : 타입이 정해지지 않은 클래스
doubleArray.Add(1.0);
doubleArray.Add(5.0);
doubleArray.Add(6.0);

Console.WriteLine();
IEnumerator<double> enumerator = doubleArray.GetEnumerator();

while (enumerator.MoveNext())
{
    Console.Write($"{enumerator.Current}.");
}
enumerator.Dispose();
enumerator.Reset();

//foreach
//foreach (순회할 자료형 현재값변수 in IEnumerable)

Console.WriteLine();
foreach (double item in doubleArray)
{
    Console.Write($"{item}.");
}


//C# System.Collection.Generic 의 동적배열
//-------------------------------------------

List<double> doubleList = new List<double>();
doubleList.FindIndex(x => x == 3.0);
foreach (double item in doubleList)
{ 

}

#endregion

#region 연결리스트
//내가 만든 연결리스트
//--------------------------------
MyLinkedList<int> intLinkedList = new MyLinkedList<int>();
intLinkedList.AddLast(2);
intLinkedList.AddLast(3);
intLinkedList.AddLast(5);
MyLinkedListNode<int> dummy = intLinkedList.FindLast(5);
intLinkedList.AddAfter(dummy, 6);

foreach (int value in intLinkedList)
{
    Console.WriteLine($"내 연결리스트 순화중... {value}");
}

// C# System.Collecions.Generic.LinkedList
//--------------------------------
LinkedList<float>floats = new LinkedList<float>();
floatLinkedList.AddFirst(3);
LinkedListNode<float>?dummy2 = floatLinkedList.FindLast(3);
floatLinkedList.AddAfter(dummy2, 5);


#region generic Dictionary
//내가 만든 generic Dictionary
//--------------------------------
MyDictionary<string, int> scores = new MyDictionary<string, int>();
scores.Add("철수", 80);
scores.Add("영희", 70);
scores.Remove("영희");
Console.WriteLine(scores["철수"]);


//C# System.Collections.Generic.Dictioanry
//-------------------------------
Dictionary<string, char> grades = new Dictionary<string, char>();
grades.Add("철수", 'A');
grades.Add("영희", 'C');
grades.Remove("영희");

foreach (KeyValuePair<string, char> grade in grades)
{
    Console.WriteLine($"{grade.Key}의 등급 : {grade.Value}");
}


foreach (string key in grades.Keys)
{
    Console.WriteLine($"학급생{key}");
}

foreach (char value in grades.Values)
{
    Console.WriteLine($"등급표{value}");
}

#endregion