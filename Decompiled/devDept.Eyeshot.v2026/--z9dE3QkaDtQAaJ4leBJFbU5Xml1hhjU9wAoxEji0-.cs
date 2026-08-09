using System;
using System.Diagnostics;

internal class _0023_003Dz9dE3QkaDtQAaJ4leBJFbU5Xml1hhjU9wAoxEji0_003D<_0023_003DzWWgGxds_003D> : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected readonly _0023_003DzWWgGxds_003D[] _0023_003DzkoXdJlY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzQi1B3vc_003D;

	public _0023_003Dz9dE3QkaDtQAaJ4leBJFbU5Xml1hhjU9wAoxEji0_003D(int _0023_003Dzu8sgotQ_003D)
	{
		_0023_003DzkoXdJlY_003D = new _0023_003DzWWgGxds_003D[_0023_003Dzu8sgotQ_003D];
	}

	public virtual void _0023_003Dz3sZAfOM_003D(_0023_003DzWWgGxds_003D _0023_003DzUBZd570_003D)
	{
		_0023_003DzkoXdJlY_003D[_0023_003DzQi1B3vc_003D] = _0023_003DzUBZd570_003D;
		_0023_003DzQi1B3vc_003D = (_0023_003DzQi1B3vc_003D + 1) % _0023_003DzkoXdJlY_003D.Length;
	}

	public virtual _0023_003DzWWgGxds_003D _0023_003DzTtbN5fw_003D()
	{
		_0023_003DzQi1B3vc_003D = _0023_003DzhwsRiw9WtYfE();
		return _0023_003DzkoXdJlY_003D[_0023_003DzQi1B3vc_003D];
	}

	public virtual _0023_003DzWWgGxds_003D _0023_003Dzn_KQLEk_003D()
	{
		_0023_003DzQi1B3vc_003D = (_0023_003DzkoXdJlY_003D.Length + _0023_003DzQi1B3vc_003D + 1) % _0023_003DzkoXdJlY_003D.Length;
		return _0023_003DzkoXdJlY_003D[_0023_003DzQi1B3vc_003D];
	}

	public void _0023_003Dzv8i2kiU_003D(_0023_003DzWWgGxds_003D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzkoXdJlY_003D[_0023_003DzhwsRiw9WtYfE()] = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual _0023_003DzWWgGxds_003D _0023_003DzfOWbgto_003D()
	{
		return _0023_003DzkoXdJlY_003D[_0023_003DzhwsRiw9WtYfE()];
	}

	private int _0023_003DzhwsRiw9WtYfE()
	{
		return (_0023_003DzkoXdJlY_003D.Length + _0023_003DzQi1B3vc_003D - 1) % _0023_003DzkoXdJlY_003D.Length;
	}

	public void Dispose()
	{
		_0023_003DzWWgGxds_003D[] array = _0023_003DzkoXdJlY_003D;
		if ((array != null && array.Length == 0) || !(_0023_003DzkoXdJlY_003D[0] is IDisposable))
		{
			return;
		}
		_0023_003DzWWgGxds_003D[] array2 = _0023_003DzkoXdJlY_003D;
		for (int i = 0; i < array2.Length; i++)
		{
			IDisposable disposable = (IDisposable)(object)array2[i];
			if (disposable != null)
			{
				disposable.Dispose();
				continue;
			}
			break;
		}
	}
}
