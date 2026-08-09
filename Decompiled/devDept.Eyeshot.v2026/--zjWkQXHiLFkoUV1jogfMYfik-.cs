using System.Collections.Generic;
using System.Runtime.CompilerServices;
using devDept.Serialization;

internal sealed class _0023_003DzjWkQXHiLFkoUV1jogfMYfik_003D
{
	private ConditionalWeakTable<object, ISurrogateWithReferenceId> _0023_003Dz8_q8r5MWWcr3 = new ConditionalWeakTable<object, ISurrogateWithReferenceId>();

	private readonly Dictionary<ISurrogateWithReferenceId, object> _0023_003Dz52RORreB7K2V = new Dictionary<ISurrogateWithReferenceId, object>();

	private ConditionalWeakTable<object, object> _0023_003DzJ_0024knqIB2NUFx = new ConditionalWeakTable<object, object>();

	private int _0023_003Dz6EGS_E2V8e6U = 1;

	private bool _0023_003Dz1Gi5R3tZvRcs(object _0023_003DzGGUd1aw_003D, out ISurrogateWithReferenceId _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003Dz8_q8r5MWWcr3.TryGetValue(_0023_003DzGGUd1aw_003D, out _0023_003DzPzO_0024GUk_003D);
	}

	private bool _0023_003Dz1Gi5R3tZvRcs(ISurrogateWithReferenceId _0023_003DzGGUd1aw_003D, out object _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003Dz52RORreB7K2V.TryGetValue(_0023_003DzGGUd1aw_003D, out _0023_003DzPzO_0024GUk_003D);
	}

	private bool _0023_003Dz1Gi5R3tZvRcs(object _0023_003DzGGUd1aw_003D, out object _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003DzJ_0024knqIB2NUFx.TryGetValue(_0023_003DzGGUd1aw_003D, out _0023_003DzPzO_0024GUk_003D);
	}

	public void _0023_003DzUal_0024ApYHAIaM()
	{
		_0023_003Dz6EGS_E2V8e6U = 1;
		_0023_003Dz52RORreB7K2V.Clear();
		_0023_003DzJ_0024knqIB2NUFx = new ConditionalWeakTable<object, object>();
		_0023_003Dz8_q8r5MWWcr3 = new ConditionalWeakTable<object, ISurrogateWithReferenceId>();
	}

	public void _0023_003Dz6KIxThd6CQ0k(object _0023_003DzGGUd1aw_003D, ISurrogateWithReferenceId _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D.ReferenceId == -1)
		{
			_0023_003DzPzO_0024GUk_003D.ReferenceId = _0023_003Dz6EGS_E2V8e6U++;
		}
		_0023_003Dz8_q8r5MWWcr3.Add(_0023_003DzGGUd1aw_003D, _0023_003DzPzO_0024GUk_003D);
	}

	public void _0023_003Dz6KIxThd6CQ0k(ISurrogateWithReferenceId _0023_003DzGGUd1aw_003D, object _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzGGUd1aw_003D.ReferenceId == -1)
		{
			_0023_003DzGGUd1aw_003D.ReferenceId = _0023_003Dz6EGS_E2V8e6U++;
		}
		_0023_003Dz52RORreB7K2V.Add(_0023_003DzGGUd1aw_003D, _0023_003DzPzO_0024GUk_003D);
	}

	public void _0023_003DzveKV_pyJHw6N(object _0023_003DzGGUd1aw_003D, object _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzJ_0024knqIB2NUFx.Add(_0023_003DzGGUd1aw_003D, _0023_003DzPzO_0024GUk_003D);
	}

	public ISurrogateWithReferenceId _0023_003DzwGxc2HXlQamU(object _0023_003DzCX9Hbao_003D)
	{
		if (_0023_003Dz1Gi5R3tZvRcs(_0023_003DzCX9Hbao_003D, out ISurrogateWithReferenceId _0023_003DzPzO_0024GUk_003D))
		{
			return _0023_003DzPzO_0024GUk_003D;
		}
		return null;
	}

	public object _0023_003DzK6wBUO2c7QzU(ISurrogateWithReferenceId _0023_003DzVmFWvY0Txwe_0024Drja2sOMy9M_003D)
	{
		if (_0023_003Dz1Gi5R3tZvRcs(_0023_003DzVmFWvY0Txwe_0024Drja2sOMy9M_003D, out var _0023_003DzPzO_0024GUk_003D))
		{
			return _0023_003DzPzO_0024GUk_003D;
		}
		return null;
	}

	public object _0023_003DzK6wBUO2c7QzU(object _0023_003DzGGUd1aw_003D)
	{
		if (_0023_003Dz1Gi5R3tZvRcs(_0023_003DzGGUd1aw_003D, out object _0023_003DzPzO_0024GUk_003D))
		{
			return _0023_003DzPzO_0024GUk_003D;
		}
		return null;
	}
}
