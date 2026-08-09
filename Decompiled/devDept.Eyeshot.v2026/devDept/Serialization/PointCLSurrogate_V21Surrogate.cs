using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class PointCLSurrogate_V21Surrogate : Point3DSurrogate
{
	public int Tool;

	public double Speed;

	public double Feed;

	public motionType Code;

	public int MotionIndex;

	public PointCLSurrogate_V21Surrogate(PointCL pointCl)
		: base(pointCl)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new PointCL(X, Y, Z)
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
