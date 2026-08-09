using System;
using System.Diagnostics;
using System.Threading;

internal sealed class _0023_003DzAXZzi6Sjw7p1yr6lAy7LfDtbxQJyrEjYWCcrbfg_003D<_0023_003DzWWgGxds_003D> : global::_0023_003Dz9dE3QkaDtQAaJ4leBJFbU5Xml1hhjU9wAoxEji0_003D<_0023_003DzWWgGxds_003D>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler _0023_003DzXPKnbYE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzZmAooI9LzH2BEzHPgQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzGZm13Itei_002451JcebBQ_003D_003D;

	public _0023_003DzAXZzi6Sjw7p1yr6lAy7LfDtbxQJyrEjYWCcrbfg_003D(int _0023_003Dzu8sgotQ_003D)
		: base(_0023_003Dzu8sgotQ_003D)
	{
	}

	public void _0023_003Dz1elxSw0bxGeE(EventHandler _0023_003DzPzO_0024GUk_003D)
	{
		EventHandler eventHandler = _0023_003DzXPKnbYE_003D;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, _0023_003DzPzO_0024GUk_003D);
			eventHandler = Interlocked.CompareExchange(ref _0023_003DzXPKnbYE_003D, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public void _0023_003DzCoTmD1rTdzdX(EventHandler _0023_003DzPzO_0024GUk_003D)
	{
		EventHandler eventHandler = _0023_003DzXPKnbYE_003D;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, _0023_003DzPzO_0024GUk_003D);
			eventHandler = Interlocked.CompareExchange(ref _0023_003DzXPKnbYE_003D, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	private void _0023_003DzgOTsttc_003D()
	{
		_0023_003DzXPKnbYE_003D?.Invoke(this, EventArgs.Empty);
	}

	public int _0023_003Dz3yb60AljKMG1()
	{
		return _0023_003DzZmAooI9LzH2BEzHPgQ_003D_003D;
	}

	private void _0023_003DztkMm6LXEFQ2u(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzZmAooI9LzH2BEzHPgQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public int _0023_003DzjvRZPNq1Nzy7()
	{
		return _0023_003DzGZm13Itei_002451JcebBQ_003D_003D;
	}

	private void _0023_003DzX0rSpMDk74Kw(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzGZm13Itei_002451JcebBQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003Dzru54n9Wsw_0024Uk()
	{
		return _0023_003Dz3yb60AljKMG1() > 0;
	}

	public bool _0023_003Dz6JrdmnU2QTa_0024()
	{
		return _0023_003DzjvRZPNq1Nzy7() > 1;
	}

	public override void _0023_003Dz3sZAfOM_003D(_0023_003DzWWgGxds_003D _0023_003DzUBZd570_003D)
	{
		if (_0023_003DzjvRZPNq1Nzy7() < _0023_003DzkoXdJlY_003D.Length - 1)
		{
			int num = _0023_003DzjvRZPNq1Nzy7();
			_0023_003DzX0rSpMDk74Kw(num + 1);
		}
		_0023_003DztkMm6LXEFQ2u(0);
		base._0023_003Dz3sZAfOM_003D(_0023_003DzUBZd570_003D);
		_0023_003DzgOTsttc_003D();
	}

	public override _0023_003DzWWgGxds_003D _0023_003DzTtbN5fw_003D()
	{
		_0023_003DzX0rSpMDk74Kw(Math.Max(0, _0023_003DzjvRZPNq1Nzy7() - 1));
		int num = _0023_003Dz3yb60AljKMG1();
		_0023_003DztkMm6LXEFQ2u(num + 1);
		_0023_003DzWWgGxds_003D result = base._0023_003DzTtbN5fw_003D();
		_0023_003DzgOTsttc_003D();
		return result;
	}

	public override _0023_003DzWWgGxds_003D _0023_003Dzn_KQLEk_003D()
	{
		int num = _0023_003DzjvRZPNq1Nzy7();
		_0023_003DzX0rSpMDk74Kw(num + 1);
		_0023_003DztkMm6LXEFQ2u(Math.Max(0, _0023_003Dz3yb60AljKMG1() - 1));
		_0023_003DzWWgGxds_003D result = base._0023_003Dzn_KQLEk_003D();
		_0023_003DzgOTsttc_003D();
		return result;
	}

	public void _0023_003DzdkbFwbBUIGfc()
	{
		_0023_003DztkMm6LXEFQ2u(0);
		_0023_003DzgOTsttc_003D();
	}
}
