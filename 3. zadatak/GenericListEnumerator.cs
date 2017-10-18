using System.Collections;
using System.Collections.Generic;

namespace _3.zadatak
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> genericList;
        private int position;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            this.genericList = genericList;
            position = 0;
        }

        public X Current
        {
            get { return genericList.getArray()[position]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (position < genericList.Count)
            {
                position++;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            position = 0;
        }
    }
}