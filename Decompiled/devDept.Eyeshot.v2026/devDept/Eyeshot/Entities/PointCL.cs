using System;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class PointCL : PointNormal
{
	internal double lengthUpTo;

	public int MotionIndex { get; internal set; }

	public int Tool { get; internal set; }

	public double Speed { get; internal set; }

	public double Feed { get; internal set; }

	public motionType Code { get; internal set; }

	public PointCL(double x, double y, double z, double length = 0.0)
		: base(x, y, z)
	{
		lengthUpTo = length;
		Nz = 1.0;
	}

	public PointCL(double x, double y, double z, double i, double j, double k, double length = 0.0)
		: base(x, y, z, i, j, k)
	{
		lengthUpTo = length;
	}

	public PointCL(double x, double y, double z, int tool, Toolpath.Motion lm)
		: this(x, y, z)
	{
		Feed = lm.Feed;
		Speed = lm.Speed;
		Code = lm.Code;
		Tool = tool;
		Nz = 1.0;
	}

	public PointCL(double x, double y, double z, double i, double j, double k, int tool, Toolpath.Motion lm)
		: this(x, y, z, i, j, k)
	{
		Feed = lm.Feed;
		Speed = lm.Speed;
		Code = lm.Code;
		Tool = tool;
	}

	internal PointCL(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, int _0023_003DzdgoGdiQ_003D, Toolpath.Motion _0023_003DzlIqj_Zk_003D, int _0023_003DzyzK8swU_003D)
		: this(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D)
	{
		Feed = _0023_003DzlIqj_Zk_003D.Feed;
		Speed = _0023_003DzlIqj_Zk_003D.Speed;
		Code = _0023_003DzlIqj_Zk_003D.Code;
		Tool = _0023_003DzdgoGdiQ_003D;
		MotionIndex = _0023_003DzyzK8swU_003D;
		Nz = 1.0;
	}

	internal PointCL(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, double _0023_003Dz437_00244ak_003D, double _0023_003DzTSeNR8Q_003D, double _0023_003DzN6G05Lg_003D, int _0023_003DzdgoGdiQ_003D, Toolpath.Motion _0023_003DzlIqj_Zk_003D, int _0023_003DzyzK8swU_003D)
		: this(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D, _0023_003Dz437_00244ak_003D, _0023_003DzTSeNR8Q_003D, _0023_003DzN6G05Lg_003D)
	{
		Feed = _0023_003DzlIqj_Zk_003D.Feed;
		Speed = _0023_003DzlIqj_Zk_003D.Speed;
		Code = _0023_003DzlIqj_Zk_003D.Code;
		Tool = _0023_003DzdgoGdiQ_003D;
		MotionIndex = _0023_003DzyzK8swU_003D;
	}

	public PointCL(PointCL another)
		: base(another)
	{
		Tool = another.Tool;
		Speed = another.Speed;
		Feed = another.Feed;
		Code = another.Code;
		MotionIndex = another.MotionIndex;
		lengthUpTo = another.lengthUpTo;
	}

	public override object Clone()
	{
		return new PointCL(this);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointCLSurrogate(this);
	}
}
