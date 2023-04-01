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

/*
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


*/
#endregion

#region Generic 동적배열

//내가 만든 동적배열
//--------------------------------------------

/*
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
*/
#endregion

#region 연결리스트
//내가 만든 연결리스트
//--------------------------------
/*
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
*/
#endregion


#region generic Dictionary
//내가 만든 generic Dictionary
//--------------------------------
/*
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
*/
#endregion

#region Q
//Queue : 선입선출(먼저 들어가고, 먼저 나온다 = 대기열) 데이터 추가가 1, 12, 123 순일 때 데이터는 123, 23, 3 순으로 쌓인다
//먼저 추가한 데이터를 먼저 뺀다

//아이템 추가
Queue <string> queue = new Queue<string>();
queue.Enqueue("철수");
queue.Enqueue("영희");
queue.Enqueue("미영");


//가장 먼저 추가된 아이템을 반환
Console.WriteLine(queue.Peek());

while (queue.Count > 0)
{
    //가장 앞에 있는 아이템 제거 및 제거된 아이템을 반환
    Console.WriteLine(queue.Dequeue());
}

#endregion


#region S

//Stack : 후입선출(나중에 들어가고, 먼저 나온다) 데이터가 단계별로 쌓이는데 빠지는데는 맨 위에서 부터 빠진다
Stack<int> stack = new Stack<int>();

//아이템을 추가
stack.Push(1);
stack.Push(5);
stack.Push(3);

//가장 늦게 추가된 아이템을 반환
Console.WriteLine(stack.Peek());


while (stack.Count > 0)
{
    //가장 늦게 추가된 아이템 제거 및 반환
    Console.WriteLine(stack.Pop());
}

#endregion

//Binary Tree
//노드 value, Left, 노드 Right를 가지고 있다
// 더이상 아래에 노드가 없으면 Leaf Node 최하단 로그 라고 불린다.

//삽입 : 노드는 value가 작은 노드는 큰 노드 기준 왼쪽(Node Left)에 연결함 이때 뿌리 형태 같이 연결 됨 O(LogN)
//탐색 : 처음 노드 기준으로 탐색 숫자가 그 노드 보다 크거 나 작으면 왼쪽, 오른쪽으로 이동해서 반복 O(LogN) 
//삭제 : O(LogN)지운 노드 기준 Right로 한번 그 노드에 Right에 숫자가 없으면 왼쪽의 노드를 옮긴다.

//Bubble Sort : 배열을 왼쪽에서 부터 옆 배열을 비교후 바꾸거나 그대로 둬서 정열함
