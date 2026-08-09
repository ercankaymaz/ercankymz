using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using devDept.Geometry;

internal sealed class _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D : IIndexObject, ICloneable
{
	private sealed class _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D
	{
		public IReadOnlyList<int> _0023_003DzdPYoyXw_003D;

		public Func<int, int> _0023_003DzJjT3dOU3oUsg;

		internal bool _0023_003DzTGsr4ayrTNZBCJ6jxAwwLMs_003D(int[] _0023_003DzdEvMFOw_003D)
		{
			return _0023_003DzdEvMFOw_003D.Length != _0023_003DzdEvMFOw_003D.Select((int _0023_003Dz77g161c_003D) => _0023_003DzdPYoyXw_003D[_0023_003Dz77g161c_003D]).Distinct().Count();
		}

		internal int _0023_003DzdSlpqUZ_0024iSxVdP9j1gVzT9g_003D(int _0023_003Dz77g161c_003D)
		{
			return _0023_003DzdPYoyXw_003D[_0023_003Dz77g161c_003D];
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int[][] _0023_003DzhMDfC7g_003D;

	public _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(IndexTriangle _0023_003Dz63vmKM0_003D)
	{
		_0023_003DzhMDfC7g_003D = new int[1][] { _0023_003Dz63vmKM0_003D.ToArray() };
	}

	public _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(int[][] _0023_003Dzcv8o5nO25OjS)
	{
		_0023_003DzhMDfC7g_003D = _0023_003Dzcv8o5nO25OjS;
	}

	protected _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(_0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D _0023_003DzySgeilxprQOK)
	{
		int num = _0023_003DzySgeilxprQOK._0023_003DzhMDfC7g_003D.Length;
		_0023_003DzhMDfC7g_003D = new int[num][];
		for (int i = 0; i < num; i++)
		{
			int[] array = _0023_003DzySgeilxprQOK._0023_003DzhMDfC7g_003D[i];
			int[] array2 = new int[array.Length];
			Array.Copy(array, array2, array.Length);
			_0023_003DzhMDfC7g_003D[i] = array2;
		}
	}

	public virtual object Clone()
	{
		return new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(this);
	}

	public bool WouldContainDuplicates(IReadOnlyList<int> _0023_003DzdPYoyXw_003D)
	{
		_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2 = new _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D();
		_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzdPYoyXw_003D = _0023_003DzdPYoyXw_003D;
		return _0023_003DzhMDfC7g_003D.Any(_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzTGsr4ayrTNZBCJ6jxAwwLMs_003D);
	}

	public void Reindex(IReadOnlyList<int> _0023_003DzdPYoyXw_003D)
	{
		int[][] array = _0023_003DzhMDfC7g_003D;
		foreach (int[] array2 in array)
		{
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = _0023_003DzdPYoyXw_003D[array2[j]];
			}
		}
	}
}
