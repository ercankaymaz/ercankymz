using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class PointCLSurrogate : PointNormalSurrogate
{
	public int Tool;

	public double Speed;

	public double Feed;

	public motionType Code;

	public int MotionIndex;

	public PointCLSurrogate(PointCL pointCl)
		: base(pointCl)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new PointCL(X, Y, Z, Nx, Ny, Nz)
		{
			Tool = Tool,
			Speed = Speed,
			Feed = Feed,
			Code = Code,
			MotionIndex = MotionIndex
		};
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		PointCL pointCL = (PointCL)p;
		Tool = pointCL.Tool;
		Speed = pointCL.Speed;
		Feed = pointCL.Feed;
		Code = pointCL.Code;
		MotionIndex = pointCL.MotionIndex;
		base.CopyDataFromObject(p);
	}
}
