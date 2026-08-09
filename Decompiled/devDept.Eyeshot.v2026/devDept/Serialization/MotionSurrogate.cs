using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public abstract class MotionSurrogate : Surrogate<Toolpath.Motion>
{
	public double Speed;

	public double Feed;

	public byte Code;

	public string CodeLine;

	public byte Approach;

	public int PrintLayer;

	public Point3D[] Points;

	internal float PrintExtrusionRadius;

	public float PrintExtrusionRadiusX;

	public float PrintExtrusionRadiusY;

	public MotionSurrogate(Toolpath.Motion motion)
		: base(motion)
	{
	}

	protected abstract override Toolpath.Motion ConvertToObject();

	protected override void CopyDataFromObject(Toolpath.Motion obj)
	{
		Speed = obj.Speed;
		Feed = obj.Feed;
		Code = (byte)obj.Code;
		CodeLine = obj.CodeLine;
		Approach = (byte)obj.Approach;
		PrintLayer = obj.PrintLayer;
		PrintExtrusionRadiusX = obj.PrintExtrusionRadiusX;
		PrintExtrusionRadiusY = obj.PrintExtrusionRadiusY;
		Points = obj.points;
	}

	protected override void CopyDataToObject(Toolpath.Motion obj)
	{
		obj.Approach = (approachType)Approach;
		obj.Speed = Speed;
		obj.Code = (motionType)Code;
		obj.CodeLine = CodeLine;
		obj.Approach = (approachType)Approach;
		obj.PrintLayer = PrintLayer;
		obj.points = Points;
		if (base.Version >= 16)
		{
			obj.PrintExtrusionRadiusX = PrintExtrusionRadiusX;
			obj.PrintExtrusionRadiusY = PrintExtrusionRadiusY;
		}
		else
		{
			obj.PrintExtrusionRadiusX = PrintExtrusionRadius;
			obj.PrintExtrusionRadiusY = PrintExtrusionRadius;
		}
	}

	public static implicit operator Toolpath.Motion(MotionSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator MotionSurrogate(Toolpath.Motion source)
	{
		return source?.ConvertToSurrogate();
	}
}
