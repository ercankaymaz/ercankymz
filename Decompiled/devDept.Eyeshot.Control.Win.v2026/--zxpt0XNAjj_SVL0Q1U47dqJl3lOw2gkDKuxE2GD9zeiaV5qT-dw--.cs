using System.Diagnostics;
using devDept;
using devDept.Geometry;

internal sealed class _0023_003Dzxpt0XNAjj_SVL0Q1U47dqJl3lOw2gkDKuxE2GD9zeiaV5qT_0024dw_003D_003D(Point3D[] _0023_003DzqXBOy1c_003D) : _0023_003Dz3yTehjY_1ZV5QPm48sNaXUrG9t0tnVTmAhKlA6ZM8qOw(_0023_003DzqXBOy1c_003D)
{
	private readonly Stopwatch _0023_003DzQ5CuQ14_003D = new Stopwatch();

	public bool _0023_003Dz0_4_A89QUv3z()
	{
		return _0023_003DzQ5CuQ14_003D.IsRunning;
	}

	protected override double _0023_003Dz1rr_Yy0_003D()
	{
		if (!_0023_003DzQ5CuQ14_003D.IsRunning)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590684));
		}
		double totalSeconds = _0023_003DzQ5CuQ14_003D.Elapsed.TotalSeconds;
		_0023_003DzvsdjAuY_003D();
		return totalSeconds;
	}

	public void _0023_003DzvsdjAuY_003D()
	{
		_0023_003DzQ5CuQ14_003D.Restart();
	}

	public void _0023_003Dze5O5R4s_003D()
	{
		_0023_003DzQ5CuQ14_003D.Reset();
	}
}
