using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpGLTF.Collections;

internal class VertexList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T> where T : struct
{
	private sealed class _KeyComparer : IEqualityComparer<int>
	{
		private readonly IReadOnlyList<T> _Items;

		public T QueryValue { get; set; }

		public _KeyComparer(IReadOnlyList<T> items)
		{
			_Items = items;
		}

		public bool Equals(int x, int y)
		{
			T val = ((x < 0) ? QueryValue : _Items[x]);
			T val2 = ((y < 0) ? QueryValue : _Items[y]);
			return object.Equals(val, val2);
		}

		public int GetHashCode(int idx)
		{
			return ((idx < 0) ? QueryValue : _Items[idx]).GetHashCode();
		}
	}

	private List<T> _Vertices = new List<T>();

	private _KeyComparer _VertexComparer;

	private Dictionary<int, int> _VertexCache;

	public T this[int index] => _Vertices[index];

	public int Count => _Vertices.Count;

	public VertexList()
	{
		_VertexComparer = new _KeyComparer(_Vertices);
		_VertexCache = new Dictionary<int, int>(_VertexComparer);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _Vertices.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _Vertices.GetEnumerator();
	}

	public int Use(in T v)
	{
		int num = IndexOf(in v);
		if (num < 0)
		{
			return _Add(in v);
		}
		return num;
	}

	public int IndexOf(in T v)
	{
		_VertexComparer.QueryValue = v;
		if (_VertexCache.TryGetValue(-1, out var value))
		{
			_VertexComparer.QueryValue = default(T);
			return value;
		}
		_VertexComparer.QueryValue = default(T);
		return -1;
	}

	private int _Add(in T v)
	{
		int count = _Vertices.Count;
		_Vertices.Add(v);
		_VertexCache[count] = count;
		return count;
	}

	public void ApplyTransform(Func<T, T> transformFunc)
	{
		_VertexCache.Clear();
		for (int i = 0; i < _Vertices.Count; i++)
		{
			_Vertices[i] = transformFunc(_Vertices[i]);
			_VertexCache[i] = i;
		}
	}

	public void CopyTo(VertexList<T> dst)
	{
		dst._Set(this);
	}

	private void _Set(VertexList<T> src)
	{
		_Vertices = new List<T>(src._Vertices);
		_VertexComparer = new _KeyComparer(_Vertices);
		_VertexCache = new Dictionary<int, int>(src._VertexCache, _VertexComparer);
	}
}
