using System;
using System.Collections;
using System.Collections.Generic;

namespace _3.zadatak
{
    public class GenericList<X> : IGenericList<X>
    {
        private int counter;
        private X[] _array;
        public GenericList() : this(4)
        {
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0) initialSize = 4;
            _array = new X[initialSize];
            counter = 0;
        }

        public int Count
        {
            get { return counter; }
        }

        public X[] getArray()
        {
            return _array;
        }
        public void Add(X item)
        {
            if (_array.Length == counter)
            {
                X[] temp = new X[_array.Length * 2];
                for (int i = 0; i < _array.Length; i++)
                {
                    temp[i] = _array[i];
                }
                _array = temp;
            }
            _array[counter] = item;
            counter++;
        }

        public void Clear()
        {
            int size = _array.Length;
            _array = new X[size];
            counter = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < counter; i++)
            {
                if (_array[i].Equals(item)) return true;
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index <= _array.Length - 1)
            {
                return _array[index];
            }
            else throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(item)) return i;
            }
            return -1;
        }

        public bool Remove(X item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index > _array.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }
            if (index > counter - 1) return false;
            for (int i = index; i < _array.Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _array[_array.Length - 1] = default(X);
            counter--;
            return true;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}