using System.Collections;

namespace DSA.String;

[Serializable]
public class Deque<T> : IEnumerable<T>, ICollection, IEnumerable
{
    private List<T> front;
    private List<T> back;
    private int frontDeleted;
    private int backDeleted;

    public int Capacity => front.Capacity + back.Capacity;
    public int Count => front.Count + back.Count - frontDeleted - backDeleted;
    public bool IsEmpty => Count == 0;

    public IEnumerable<T> Reversed
    {
        get
        {
            if (back.Count - backDeleted > 0)
            {
                for (int i = back.Count - 1; i >= backDeleted; i--) yield return back[i];
            }

            if (front.Count - frontDeleted > 0)
            {
                for (int i = frontDeleted; i < front.Count; i++) yield return front[i];
            }
        }
    }

    public Deque()
    {
        front = [];
        back = [];
    }

    public Deque(int capacity)
    {
        if (capacity < 0) throw new ArgumentException("Capacity cannot be negative");
        int temp = capacity / 2;
        int temp2 = capacity - temp;
        front = new List<T>(temp);
        back = new List<T>(temp2);
    }

    public Deque(IEnumerable<T> backCollection) : this(backCollection, frontCollection: null) { }

    public Deque(IEnumerable<T> backCollection, IEnumerable<T>? frontCollection)
    {
        if (backCollection == null && frontCollection == null) throw new ArgumentException("Collections cannot both be null");
        front = [];
        back = [];

        if (backCollection != null)
        {
            foreach (T item in backCollection) back.Add(item);
        }

        if (frontCollection != null)
        {
            foreach (T item in frontCollection) front.Add(item);
        }
    }

    public void AddFirst(T item)
    {
        if (frontDeleted > 0 && front.Count == front.Capacity)
        {
            front.RemoveRange(0, frontDeleted);
            frontDeleted = 0;
        }

        front.Add(item);
    }

    public void AddLast(T item)
    {
        if (backDeleted > 0 && back.Count == back.Capacity)
        {
            back.RemoveRange(0, backDeleted);
            backDeleted = 0;
        }

        back.Add(item);
    }

    public void AddRangeFirst(IEnumerable<T> range)
    {
        if (range != null)
        {
            foreach (T item in range) AddFirst(item);
        }
    }

    public void AddRangeLast(IEnumerable<T> range)
    {
        if (range != null)
        {
            foreach (T item in range) AddLast(item);
        }
    }

    public void Clear()
    {
        front.Clear();
        back.Clear();
        frontDeleted = 0;
        backDeleted = 0;
    }

    public bool Contains(T item)
    {
        for (int i = frontDeleted; i < front.Count; i++)
        {
            if (Equals(front[i], item)) return true;
        }

        for (int i = backDeleted; i < back.Count; i++)
        {
            if (Equals(back[i], item)) return true;
        }

        return false;
    }

    public void CopyTo(T[] array, int index)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        if (array.Length < index + Count) throw new ArgumentException("Index is invalid");

        int i = index;

        foreach (T item in this)
        {
            array[i++] = item;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (front.Count - frontDeleted > 0)
        {
            for (int i = front.Count - 1; i >= frontDeleted; i--) yield return front[i];
        }

        if (back.Count - backDeleted > 0)
        {
            for (int i = backDeleted; i < back.Count; i++) yield return back[i];
        }
    }

    public T PeekFirst()
    {
        if (front.Count > frontDeleted)
        {
            return front[^1];
        }
        else if (back.Count > backDeleted)
        {
            return back[backDeleted];
        }
        else
        {
            throw new InvalidOperationException("Can't peek at empty Deque");
        }
    }

    public T PeekLast()
    {
        if (back.Count > backDeleted)
        {
            return back[^1];
        }
        else if (front.Count > frontDeleted)
        {
            return front[frontDeleted];
        }
        else
        {
            throw new InvalidOperationException("Can't peek at empty Deque");
        }
    }

    public T PopFirst()
    {
        T result;

        if (front.Count > frontDeleted)
        {
            result = front[^1];
            front.RemoveAt(front.Count - 1);
        }
        else if (back.Count > backDeleted)
        {
            result = back[backDeleted];
            backDeleted++;
        }
        else
        {
            throw new InvalidOperationException("Can't pop empty Deque");
        }

        return result;
    }

    public T PopLast()
    {
        T result;

        if (back.Count > backDeleted)
        {
            result = back[^1];
            back.RemoveAt(back.Count - 1);
        }
        else if (front.Count > frontDeleted)
        {
            result = front[frontDeleted];
            frontDeleted++;
        }
        else
        {
            throw new InvalidOperationException("Can't pop empty Deque");
        }

        return result;
    }

    public void Reverse()
    {
        (back, front) = (front, back);
        (backDeleted, frontDeleted) = (frontDeleted, backDeleted);
    }

    public T[] ToArray()
    {
        if (Count == 0) return [];
        T[] result = new T[Count];
        CopyTo(result, 0);
        return result;
    }

    public void TrimExcess()
    {
        if (frontDeleted > 0)
        {
            front.RemoveRange(0, frontDeleted);
            frontDeleted = 0;
        }

        if (backDeleted > 0)
        {
            back.RemoveRange(0, backDeleted);
            backDeleted = 0;
        }

        front.TrimExcess();
        back.TrimExcess();
    }

    public bool TryPeekFirst(out T? item)
    {
        if (!IsEmpty)
        {
            item = PeekFirst();
            return true;
        }

        item = default;
        return false;
    }

    public bool TryPeekLast(out T? item)
    {
        if (!IsEmpty)
        {
            item = PeekLast();
            return true;
        }

        item = default;
        return false;
    }

    public bool TryPopFirst(out T? item)
    {
        if (!IsEmpty)
        {
            item = PopFirst();
            return true;
        }

        item = default;
        return false;
    }

    public bool TryPopLast(out T? item)
    {
        if (!IsEmpty)
        {
            item = PopLast();
            return true;
        }

        item = default;
        return false;
    }


    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => this;

    void ICollection.CopyTo(Array array, int index) => CopyTo((T[])array, index);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}