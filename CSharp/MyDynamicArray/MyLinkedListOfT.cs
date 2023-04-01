﻿using MyDynamicArray;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDynamicArray
{
    internal class MyLinkedListNode<T> : IEnumerable<T>
    {
        public T Value;
        public MyLinkedListNode<T> Prev;
        public MyLinkedListNode<T> Next;

        public MyLinkedListNode(T value)
        {
            Value = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Fist => _first;

        public MyLinkedListNode<T> Last => _last;

        private MyLinkedListNode<T> _first, _last, _tmp;


        #region 삽입 알고리즘

        //가장 앞에 삽입
        public void AddFirst(T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            if (_first != null)
            {
                _tmp.Next = _first;
                _first.Prev = _tmp;
            }
            else
            {
                _last = _tmp;
            }

            _first = _tmp;
        }

        //가장 뒤에서 삽입
        public void AddLast(T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            if (_last != null) ;
        }

        //특정 노드 앞에 삽입
        public void AddBefore(MyLinkedListNode<T> node, T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            //목표 노드의 앞에 원래 다른 노드가 있을 경우
            if(node != _first)
            {
                node.Prev = _tmp;
                _tmp.Prev = node.Prev;
            }

            node.Prev = _tmp;
            _tmp.Next = node;
        }

        //특정 노드 뒤에 삽입
        public void AddAfter(MyLinkedListNode<T>node, T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            if (node != _last)
            {
                node.Next.Prev = _tmp;
                _tmp.Next = node.Next;
            }

            node.Next = _tmp;
            _tmp.Prev = node.Next;
        }


        #endregion

        #region 탐색 알고리즘
        public MyLinkedListNode<T>Find(T value)
        {
            _tmp = _first;

            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, value) == 0)
                    return _tmp;

                _tmp = _tmp.Prev;


            }
            return null;
        }
        
        #endregion

        #region 삭제 알고리즘
        public bool Remove(MyLinkedListNode<T> node)
        {
            if(node == null)
                return false;

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }

            node = node.Next = node.Prev = null;
            return true;
        }


        public bool Remove(T value)
        {
            return Remove(Find(value));
        }


        #endregion 
        public struct Enumerator : IEnumerator<T>
        {
            public T Current => _current.Value;

            object IEnumerator.Current => _current.Value;
            private MyLinkedListNode<T> _current;
            private MyLinkedList<T> _outer;

            public Enumerator(MyLinkedList<T> outer)
            {
                _outer = outer;
                _current = null;

            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if(_current == _outer.Last)
                    return false;
                if(_current == null)
                    _current = _outer._first;
                else
                    _current = _current.Next;

                return true;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}

