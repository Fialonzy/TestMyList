namespace MyListTemplate
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class MyList<T> : IList<T>
    {
        private T[] _items;
        private int _count;

        static readonly T[] _emptyArray = new T[0];

        public MyList()
        {
            _items = _emptyArray;
            _count = 0;
        }

        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_count)
                    throw new Exception();
                return _items[index];
            }
            set
            {
                if ((uint)index >= (uint)_count)
                    throw new Exception();
                _items[index] = value;
            }
        }

        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _items.Length)
                    // TODO: realise exception
                    throw new System.Exception();
                ExpandList(value);
            }
        }



        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_count == _items.Length)
                ExpandList(_count + 1);
            _items[_count++] = item;
        }

        public void Clear()
        {
            if (_count > 0)
            {
                Array.Clear(_items, 0, _count);
                _count = 0;
            }
        }

        public bool Contains(T item)
        {
            // TODO: check null and change Equal() to EqualityComparer
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null && array.Rank == 1)
                // TODO: Exception
                throw new Exception();
            try
            {
                Array.Copy(_items, arrayIndex, array, 0, _count);
            }
            catch (ArrayTypeMismatchException)
            {
                // TODO: Exception
                throw new Exception();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _count);
        }

        public void Insert(int index, T item)
        {
            if ((uint)index >= _count)
                // TODO: Exception
                throw new Exception();
            if (_count == _items.Length)
                ExpandList(_count + 1);
            Array.Copy(_items, index, _items, index + 1, _count - index);
            _items[index] = item;
            _count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_count)
                // TODO: Exception
                throw new Exception();
            _count--;
            if (index < _count)
                Array.Copy(_items, index + 1, _items, index, _count - index);
            _items[_count] = default(T);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        private void ExpandList(int value)
        {
            T[] newItemsList = new T[value];
            Array.Copy(_items, newItemsList, _items.Length);
            _items = newItemsList;
        }

        public struct MyEnumerator : IEnumerator<T>, System.Collections.IEnumerator
        {
            private int _index;
            private MyList<T> _list;
            private T _current;
            internal MyEnumerator(MyList<T> list)
            {
                _list = list;
                _index = 0;
                _current = default(T);
            }
            public T Current => _current;

            object IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || _index == _list._count + 1)
                        // TODO: Exception
                        throw new Exception();
                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                MyList<T> localList = _list;
                if ((uint)_index < (uint)localList._count)
                {
                    _current = localList._items[_index];
                    _index++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = 0;
                _current = default(T);
            }
        }
    }
}