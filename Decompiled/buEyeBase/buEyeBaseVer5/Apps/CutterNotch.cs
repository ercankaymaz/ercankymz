using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterNotch : buSerilization5
{
	public double Length = 5.0;

	public double Width = 3.0;

	public double Angle = 15.0;

	public bool Enable = true;

	public CutterNotchType NotchType = CutterNotchType.INotch;

	public Point3D Position = new Point3D();

	public InOutType Direction = InOutType.Inside;

	public double CurveAtPersentage = 1.0;

	public double CurveAtLength = 0.0;

	public double DirectionAngle = 0.0;

	public bool InCurve = false;

	public string baseEntityName = "";

	public int baseEntityIndex = -1;

	public CutterNotch()
	{
	}

	public CutterNotch(CutterNotch data)
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
		Position = new Point3D(data.Position.X, data.Position.Y, data.Position.Z);
	}

	public static void Copy(CutterNotch Source, ref CutterNotch Target)
	{
		Target = new CutterNotch(Source);
	}

	public override string ToString()
	{
		return "Type: " + NotchType.ToString() + " Dir: " + Direction.ToString() + " Pos: " + Position.ToString();
	}
}
