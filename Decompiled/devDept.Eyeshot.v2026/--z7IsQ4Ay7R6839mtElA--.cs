using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003Dz7IsQ4Ay7R6839mtElA_003D_003D : IEnumerable<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>, IEnumerable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Random _0023_003Dzlraf5vU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzi4PU_r77w7RJ = 1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzCENLg8ojyQnQKUBz3A_003D_003D;

	public _0023_003Dz7IsQ4Ay7R6839mtElA_003D_003D(_0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D)
		: this(_0023_003DzGGJSiQk_003D, new Random(110503))
	{
	}

	public _0023_003Dz7IsQ4Ay7R6839mtElA_003D_003D(_0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D, Random _0023_003Dzlraf5vU_003D)
	{
		this._0023_003DzGGJSiQk_003D = _0023_003DzGGJSiQk_003D;
		this._0023_003Dzlraf5vU_003D = _0023_003Dzlraf5vU_003D;
	}

	public void _0023_003Dzv9osLK4_003D()
	{
		_0023_003Dzi4PU_r77w7RJ = 1;
		_0023_003DzCENLg8ojyQnQKUBz3A_003D_003D = 0;
	}

	public void _0023_003DzIvyN59Q_003D()
	{
		int count = _0023_003DzGGJSiQk_003D._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count;
		if (_0023_003DzCENLg8ojyQnQKUBz3A_003D_003D != count)
		{
			_0023_003DzCENLg8ojyQnQKUBz3A_003D_003D = count;
			while (11 * _0023_003Dzi4PU_r77w7RJ * _0023_003Dzi4PU_r77w7RJ * _0023_003Dzi4PU_r77w7RJ < count)
			{
				_0023_003Dzi4PU_r77w7RJ++;
			}
		}
	}

	public IEnumerator<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D> GetEnumerator()
	{
		return _0023_003DzGGJSiQk_003D._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D._0023_003DzoWQfySA_003D(_0023_003Dzi4PU_r77w7RJ, _0023_003Dzlraf5vU_003D).GetEnumerator();
	}

	private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
		return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
	}
}
