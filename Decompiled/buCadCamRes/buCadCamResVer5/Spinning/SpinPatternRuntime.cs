using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buCadCamResVer5.Spinning;

[Serializable]
public class SpinPatternRuntime : buSerilization
{
	public Point3D pntLeaveArcMid = new Point3D();

	public Point3D pntLeaveArcEnd = new Point3D();

	public Point3D pntCurveStart = new Point3D();

	public Point3D pntCurveEnd = new Point3D();

	public Point3D pntCurveFinishStart = new Point3D();

	public Point3D pntCurveFinishEnd = new Point3D();

	public Point3D pntSameWayReturn = new Point3D();

	public Point3D pntLastCalc = new Point3D();

	public bool isLastSpin = false;

	public bool isFinish = false;

	public double DirectionAngle = 0.0;

	public SpinPatternRuntime()
	{
	}

	public SpinPatternRuntime(SpinPatternRuntime data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
