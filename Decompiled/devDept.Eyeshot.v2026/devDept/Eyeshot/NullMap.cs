using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace devDept.Eyeshot;

public class NullMap
{
	private sealed class _0023_003DzLHwtkMoXzHXg<_0023_003DzWWgGxds_003D> : EqualityComparer<_0023_003DzWWgGxds_003D>
	{
		public override bool Equals(_0023_003DzWWgGxds_003D _0023_003Dz2wpkEvw_003D, _0023_003DzWWgGxds_003D _0023_003DzoqButm0_003D)
		{
			return (object)_0023_003Dz2wpkEvw_003D == (object)_0023_003DzoqButm0_003D;
		}

		public override int GetHashCode(_0023_003DzWWgGxds_003D _0023_003DzCX9Hbao_003D)
		{
			return _0023_003DzCX9Hbao_003D.GetHashCode();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int[] _0023_003Dz0uCq1ns_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<int, int> _0023_003DzS0fEsyA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzQZuJCK4_003D;

	public int this[int i] => _0023_003DzS0fEsyA_003D[i];

	protected NullMap(int[] map, int size)
	{
		for (int i = 1; i < map.Length; i++)
		{
			if (map[i] <= map[i - 1])
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996481));
			}
		}
		_0023_003Dz0uCq1ns_003D = map;
		_0023_003DzQZuJCK4_003D = size;
		_0023_003DzS0fEsyA_003D = new Dictionary<int, int>();
		int num = 0;
		for (int j = 0; j < size; j++)
		{
			if (_0023_003Dz0uCq1ns_003D.Length != 0 && num < _0023_003Dz0uCq1ns_003D.Length && j == _0023_003Dz0uCq1ns_003D[num])
			{
				num++;
			}
			else
			{
				_0023_003DzS0fEsyA_003D[j] = j - num;
			}
		}
	}

	private void _0023_003Dzo2j_00246io_003D<T>(IList<T> _0023_003DzCwXFK94_003D, IList<T> _0023_003DzWtgegm0_003D)
	{
		int num = 0;
		for (int i = 0; i < _0023_003DzCwXFK94_003D.Count; i++)
		{
			if (_0023_003Dz0uCq1ns_003D.Length != 0 && num < _0023_003Dz0uCq1ns_003D.Length && i == _0023_003Dz0uCq1ns_003D[num])
			{
				num++;
			}
			else
			{
				_0023_003DzWtgegm0_003D[i - num] = _0023_003DzCwXFK94_003D[i];
			}
		}
	}

	public void Map<T>(List<T> list)
	{
		if (list.Count != _0023_003DzQZuJCK4_003D)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996690));
		}
		_0023_003Dzo2j_00246io_003D(list, list);
		list.RemoveRange(list.Count - _0023_003Dz0uCq1ns_003D.Length, _0023_003Dz0uCq1ns_003D.Length);
	}

	public T[] Map<T>(IList<T> list)
	{
		if (list.Count != _0023_003DzQZuJCK4_003D)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996690));
		}
		T[] array = new T[list.Count - _0023_003Dz0uCq1ns_003D.Length];
		_0023_003Dzo2j_00246io_003D(list, array);
		return array;
	}

	public int Map(int index)
	{
		return _0023_003DzS0fEsyA_003D[index];
	}

	public bool TryMap(int index, out int newIndex)
	{
		return _0023_003DzS0fEsyA_003D.TryGetValue(index, out newIndex);
	}

	public static T[] RemoveNulls<T>(T[] array, T nullElement, out NullMap map, IEqualityComparer<T> comparer = null)
	{
		if (comparer == null)
		{
			comparer = new _0023_003DzLHwtkMoXzHXg<T>();
		}
		int num = array.Length;
		for (int i = 0; i < array.Length; i++)
		{
			if ((object)array[i] == (object)nullElement)
			{
				num--;
			}
		}
		int[] array2 = new int[array.Length - num];
		T[] array3 = new T[num];
		int j = 0;
		int num2 = 0;
		for (; j < array.Length; j++)
		{
			if ((object)array[j] != (object)nullElement)
			{
				array3[num2++] = array[j];
			}
			else
			{
				array2[j - num2] = j;
			}
		}
		map = new NullMap(array2, array.Length);
		return array3;
	}
}
