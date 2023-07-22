using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        // const 키워드
        // 상수 키워드, const 키워드가 붙은 변수는 초기화만 가능하며, 상수처럼 사용됨.
        private const int DEFAULT_SIZE = 1;
        private object[] _data = new object[DEFAULT_SIZE];
        private int _count; // 현재 자료 갯수 (배열의 길이가 아님)



        // 삽입 알고리즘
        // 일반적인 경우에 O(1)
        // Capacity(배열의 크기) 가 모자랄때는 O(N)
        public void Add(object item)
        {
            // 여유공간이 부족하면 더 큰 크기의 배열을 만들고 기존 데이터 복제후 기존 배열은 날림
            if (_count >= _data.Length)
            {
                // 더 큰 크기 배열 만듦
                // (현재 데이터 갯수의 10의 승수 + 1 사이즈 만큼 더 큰 배열을 만듦)
                object[] tmp = new object[_data.Length + (int)Math.Ceiling(Math.Log10(_data.Length)) + DEFAULT_SIZE];

                // 기존 데이터 복제
                for (int i = 0; i < _count; i++)
                {
                    tmp[i] = _data[i];
                }

                // 새 배열참조로 변경 ( 기존 배열을 날림 )
                _data = tmp;
            }
            _data[_count] = item;
            _count++;
        }

        // 탐색 알고리즘
        // O(N)
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

        // Predicate : 파라미터 N 개를 받고 bool 값을 반환하는 함수를 등록할 수 있는 대리자
        public int FindIndex(Predicate<object> match)
        {
            for (int i = 0; i < _count; i++)
            {
                // 해당 대리자에 등록된 함수(들)을 모두 호출하고 마지막 호출된 함수가 반환한 bool 값으로 
                // 내가 원하는 조건 체크
                if (match.Invoke(_data[i]))
                    return i;
            }

            return -1;
        }

        // 삭제 알고리즘
        // O(N)
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                return false;

            for (int i = index; i < _count - 1; i++)
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
    }
}
