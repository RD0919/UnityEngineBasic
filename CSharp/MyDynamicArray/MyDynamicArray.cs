using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


//object 타입


namespace Collections
{
    internal class MyDynamicArray
    {
        public int Count
        {
            get 
            {
                return _count;
            }
        }

        public int Capacity
        {
            get
            {
                return _data.Length;
            }
        }

        public object this[int index]
        {
            get 
            {
                return _data[index];
            }
            set 
            { 
                _data[index] = value;
            }
        }

        //const 키워드
        //상수 키워드, const키워드가 붙은 변수는 초기화만 가능하며, 상수처럼 사용됨.
        private const int DEFAULT_SIZE = 1;
        private object[] _data = new object[DEFAULT_SIZE];
        private int _count; // 현재 자료 갯수
        

       

        //***삽입 알고리즘***
        //일반적인 경우에는 O(1)
        //Capacity(배열의 크기)가 모자랄 때는  더 큰 배열을 만들고 데이터를 전부 복제해야허가 떼문에O(N)
        public void Add(object item)
        {
            //여유 공간이 부족하면 더 큰 크기의 배열을 만들고 기존 데이터 복제후 기존 배열을 날림
            if (_count >= _data.Length)
            {
                //더 큰 배열을 많듦
                //(현재 데이터 갯수의 10의 승수 + 1 사이즈 만큼  더 큰 배열을 만듦)
                object[] tmp = new object[(int)Math.Ceiling(Math.Log10(_data.Length)) + DEFAULT_SIZE];

                //int[] tmp = new int[_data.Length * 2];
                //for (int i = 0; i < Count; i++)
                //{//~~.Length = 배열의 길이
                //tmp[i] = _data[i];
                //}

                // 새 배열참조로 변경(기존 배열을 날림)
                _data = tmp;
            }
            _data[_count] = item;
            _count++;
        }

        //***탐색 알고리즘***
        //인텍스 접근하기 떼문에O(1),만약 특정값이나 조건에 해당되는 아이템을 찾으려면 O(N)
        public bool Contains(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_data[i] == item)
                    return true;
            }

            return false;
        }

        public int FindIndex(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_data[i] == item)
                    return i;
            }
            return -1;

        }

        public int Findlndex(Predicate<object> match)
        {
            for (int i = 0; i < _count; i++)
            {
                //해당 대리자에 등록된
                if (match.Invoke(_data[i]))
                    return i;
            }
            return -1;
        }

        //***삭제 알고리즘***
        //삭제하고 싶은 인덱스 다음거부터 끝까지 전부 한칸씩 앞으로 당기기 떼문에 O(N)
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                return false;

            for (int i = 0; i < _count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _count--;
            _data[_count] = default(int);
            return true;
        }

        public bool Remove(object item)
        {
            return RemoveAt(FindIndex(item));
        }

        //LinkedList : 자료를 담는 기본단위인 노드(Node) 단위로 자료를 구성하고, 노드(Note)끼리 연결시킴. 노드(Note)들은 힙영역에 랜덤하게 분포됨
        //삽입 : 맨앞/뒤에 삽입할 경우 O(1), 특정 노드 앞/뒤에 삽입할 경우 O(1)
        //탐색 : O(N)
        //삭제 : O(1)
        //Hashtable : 추가하고자 하는 값에 대해서 Hash 함수를 통해 고유한 Key 값을 산출하고, 그 Key값으로 인덱스에 접근하는 형태의 테이블
        //헤시키의 충돌에 해결방법? : LinkedList Buket : 해시 테이블에 value를 개별 LinkedList로 만들어서 충돌이 일어나는 값들을 모두 개별 노드로 저장하는 방법, Open Addressing : 해시키를 다시 구한다
        //삽입 : 거의 O(1), 충돌이 일어날 경우 LinkedList : O(1), OpenAddressing : 배열을 늘려야한다면 그때는 O(N)
        //탐색 : 해시함수를 통해 인덱스접근하기 때문에 거의 O(1)
        //삭제 : 해시함수를 통해 인덱스접근하기 때문에 거의 O(1)


    }
}
