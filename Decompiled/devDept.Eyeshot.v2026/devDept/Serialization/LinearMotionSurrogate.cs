using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class LinearMotionSurrogate : MotionSurrogate
{
	public Point3D From;

	public Point3D To;

	public LinearMotionSurrogate(Toolpath.LinearMotion linearMotion)
		: base(linearMotion)
	{
	}

	protected override Toolpath.Motion ConvertToObject()
	{
		Toolpath.LinearMotion linearMotion = new Toolpath.LinearMotion(From, To, (motionType)Code, Speed, Feed, CodeLine);
		CopyDataToObject(linearMotion);
		return linearMotion;
	}

	protected override void CopyDataFromObject(Toolpath.Motion obj)
	{
		Toolpath.LinearMotion linearMotion = (Toolpath.LinearMotion)obj;
		From = linearMotion.From;
		To = linearMotion.To;
		base.CopyDataFromObject(obj);
	}
}
