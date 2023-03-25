using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDynamicArray
{
    internal class MyDictionary<TKey,TValue>
    {
        private const int DEFAULT_SIZE = 100;
        private TValue[]_values = new TValue[DEFAULT_SIZE];

        public TValue this[TKey key]
        {
            get => _values[Hash(key)];
            set => _values[Hash(key)] = value;
        }


        public void Add(TKey key, TValue value) 
        {
            _values[Hash(key)] = value;
        }

        public void Remove(TKey key)
        {
            _values[Hash(key)] = default(TValue);
        }

        //out keyword
        //함수가 반환된 때 추가적으로 값을 더 반환할 때 사용하는 키워드
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            //try=catch 구문
            //예외잡기를 시도하는 구문. 예외가 던져질때 그예외에 대해서 내다 직접 핸들링할 때 사용
            try
            {
                value = _values[Hash(key)];
            }
            catch (Exception e)
            {
                //throw e;
                Console.WriteLine($"MyDictionary<{typeof(TKey).Name},{typeof(TValue).Name}> : 유효하지 안은 Key값, {e.Message}");
                return false;
            }
            //finally


        }

        private int Hash(TKey key)
        {
            string tmpString = key.ToString();
            int tmpHash = 0;

            for (int i = 0; i < _values.Length; i++)
            {
                tmpHash += tmpString[i];
            }
            tmpHash %= DEFAULT_SIZE;
            return tmpHash;
        }
    }
}
