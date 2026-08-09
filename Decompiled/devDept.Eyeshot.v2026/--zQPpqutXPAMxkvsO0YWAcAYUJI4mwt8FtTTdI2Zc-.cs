using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzQPpqutXPAMxkvsO0YWAcAYUJI4mwt8FtTTdI2Zc_003D
{
	public Surface _0023_003DzejDtVY0_003D;

	public double _0023_003DzdeHSgh8_003D;

	public double _0023_003DzVerAUA4_003D;

	public _0023_003DzQPpqutXPAMxkvsO0YWAcAYUJI4mwt8FtTTdI2Zc_003D(Surface _0023_003DzF7GfYSI_003D, double _0023_003DzZRl8jkE_003D, double _0023_003DzbKFdElc_003D)
	{
		_0023_003DzejDtVY0_003D = _0023_003DzF7GfYSI_003D;
		_0023_003DzdeHSgh8_003D = _0023_003DzZRl8jkE_003D;
		_0023_003DzVerAUA4_003D = _0023_003DzbKFdElc_003D;
	}

	public Interval _0023_003Dzc2sIpYmbrSSe()
	{
		return new Interval(_0023_003DzejDtVY0_003D.DomainU.Low * _0023_003DzdeHSgh8_003D, _0023_003DzejDtVY0_003D.DomainU.High * _0023_003DzdeHSgh8_003D);
	}

	public Interval _0023_003Dz6I0VonsHpxSm()
	{
		return new Interval(_0023_003DzejDtVY0_003D.DomainV.Low * _0023_003DzVerAUA4_003D, _0023_003DzejDtVY0_003D.DomainV.High * _0023_003DzVerAUA4_003D);
	}

	public Point3D _0023_003DzMEXpAaVkFlpl(double _0023_003Dz_eY3Y4c_003D, double _0023_003Dz77g161c_003D)
	{
		return _0023_003DzejDtVY0_003D.PointAt(_0023_003Dz_eY3Y4c_003D / _0023_003DzdeHSgh8_003D, _0023_003Dz77g161c_003D / _0023_003DzVerAUA4_003D);
	}

	public Point3D _0023_003DzMEXpAaVkFlpl(Point2D _0023_003DzlY77YgY_003D)
	{
		return _0023_003DzMEXpAaVkFlpl(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y);
	}

	public bool _0023_003DzgXk8Ru_iJQUJ(Point3D _0023_003DzlY77YgY_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out Point2D _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D)
	{
		return _0023_003DzejDtVY0_003D._0023_003DzgXk8Ru_iJQUJ(_0023_003DzlY77YgY_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D);
	}

	public bool _0023_003Dzbse2nfoNwRvN()
	{
		return _0023_003DzejDtVY0_003D._0023_003DzaHuyAw_0024HZVzX();
	}

	public bool _0023_003DzKWdaQi8_003D(Point3D _0023_003DzlY77YgY_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003Dz0ZT3gEddQ5QD, Point2D _0023_003Dz1BPEjBg_003D, out Point2D _0023_003DzOLHnb2M_003D)
	{
		bool result = _0023_003DzejDtVY0_003D.Project(_0023_003DzlY77YgY_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz0ZT3gEddQ5QD, new Point2D(_0023_003Dz1BPEjBg_003D.X / _0023_003DzdeHSgh8_003D, _0023_003Dz1BPEjBg_003D.Y / _0023_003DzVerAUA4_003D), out _0023_003DzOLHnb2M_003D);
		_0023_003DzOLHnb2M_003D.X *= _0023_003DzdeHSgh8_003D;
		_0023_003DzOLHnb2M_003D.Y *= _0023_003DzVerAUA4_003D;
		return result;
	}

	public Transformation _0023_003DzAOlcrIqv6aDt()
	{
		return new Scaling(1.0 / _0023_003DzdeHSgh8_003D, 1.0 / _0023_003DzVerAUA4_003D);
	}
}
