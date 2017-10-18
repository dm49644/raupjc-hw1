using System;
using System.Linq;

namespace ConsoleApplication
{
    public class IntegerList : IIntegerList
    {
        private int?[] _internalStorage;
        private int counter;

        public int Count
        {
            get { return counter; }
        }

        public IntegerList() : this(4)
        {
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 0) initialSize = 4;
            _internalStorage=new int?[initialSize];
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = null;
            }
            counter = 0;
        }


        public void Add(int item)
        {
            if (_internalStorage.Length == counter)
            {
                int?[] temp=new int?[_internalStorage.Length*2];
                for(int i=0;i<_internalStorage.Length;i++)
                {
                    temp[i] = _internalStorage[i];
                }
                _internalStorage = temp;
            }
            _internalStorage[counter] = item;
            counter++;
        }

        public void Clear()
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = null;
            }
            counter = 0;
        }

        public bool Contains(int item)
        {
            foreach (int? i in _internalStorage)
            {
                if (i.HasValue)
                {
                    if (i == item) return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index < _internalStorage.Length - 1)
            {
                if (_internalStorage[index] != null)
                {
                    return (int)_internalStorage[index];
                }
                else return 0;
            }
            else throw new IndexOutOfRangeException();
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item) return i;
            }
            return -1;
        }

        public bool Remove(int item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index > _internalStorage.Length-1)
            {
                throw new IndexOutOfRangeException();
            }
            if (!_internalStorage[index].HasValue) return false;
            for (int i = index; i < _internalStorage.Length-1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _internalStorage[_internalStorage.Length-1] = null;
            counter--;
            return true;
        }
    }
}