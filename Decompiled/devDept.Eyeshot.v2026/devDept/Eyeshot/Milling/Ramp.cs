using System;

namespace devDept.Eyeshot.Milling;

public abstract class Ramp : LeadBase
{
	protected double RadialClearance;

	protected double ClearanceHeight;

	protected Ramp(double clearanceHeight)
	{
		ClearanceHeight = clearanceHeight;
	}

	private Ramp(double _0023_003DzgiwX4fPs8OReh4cAVw_003D_003D, double _0023_003DzFvmFIZSStiBxz0WT_rl2hy0_003D)
	{
		throw new NotImplementedException();
	}

	public virtual void Init(double tolerance, double layerHeight)
	{
		Init(tolerance);
	}

	internal _0023_003Dz0JIgxQpsDZbf4VcHqAU5fSFJJQQX8QJVWaIXn9RwP83t _0023_003Dzdlp53MQ_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dz9BM_0024JJOnfyrP, int _0023_003DzGaSzuaHRZ_0024fm, bool _0023_003DzdnLFZC6dNqmw, double _0023_003Dz1v8WebVg_QJi, double _0023_003Dz4w6tHu4_003D, cutDirectionType _0023_003DzCIpOJSfcMrGo)
	{
		return new _0023_003Dz0JIgxQpsDZbf4VcHqAU5fSFJJQQX8QJVWaIXn9RwP83t(this, _0023_003Dz9BM_0024JJOnfyrP, _0023_003DzGaSzuaHRZ_0024fm, _0023_003DzdnLFZC6dNqmw, _0023_003Dz1v8WebVg_QJi, _0023_003Dz4w6tHu4_003D, _0023_003DzCIpOJSfcMrGo);
	}

	internal _0023_003Dz0JIgxQpsDZbf4VcHqAU5fSFJJQQX8QJVWaIXn9RwP83t _0023_003Dzdlp53MQ_003D(_0023_003DzffJpiSDBgZf8XoMYriAgy6yOFLX95VOWMvylykc5q4Hm _0023_003DzOm40_LfQ2mOP, double _0023_003Dz1v8WebVg_QJi, double _0023_003Dz4w6tHu4_003D, cutDirectionType _0023_003DzCIpOJSfcMrGo)
	{
		return new _0023_003Dz0JIgxQpsDZbf4VcHqAU5fSFJJQQX8QJVWaIXn9RwP83t(this, _0023_003DzOm40_LfQ2mOP, _0023_003Dz1v8WebVg_QJi, _0023_003Dz4w6tHu4_003D, _0023_003DzCIpOJSfcMrGo);
	}
}
