using System;
using System.ComponentModel;
using System.Diagnostics;

namespace devDept.Eyeshot.Control;

public abstract class DisposableBase : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz1O2eeX0_003D;

	[Browsable(false)]
	public bool Disposed => _0023_003Dz1O2eeX0_003D;

	static DisposableBase()
	{
		_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D _0023_003DzL07WkTo_003D = (_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D)0;
		object[] array = null;
		array = new object[1] { _0023_003DzL07WkTo_003D };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "M#I>Qq\"ad(", array);
	}

	internal void _0023_003Dzh2BJvfFX_KvX(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz1O2eeX0_003D = _0023_003DzsLHxXyo_003D;
	}

	public virtual void Dispose()
	{
		_0023_003Dz1O2eeX0_003D = true;
	}
}
