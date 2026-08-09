using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Printer3DSettings : buSerilization5
{
	public bool ShowOperationButton = false;

	public int SliceCount = 10;

	public double SliceStep = 20.0;

	public bool InFill = true;

	public bool InFillConnect = true;

	public bool Simplify = true;

	public bool ZSpiralMove = true;

	public bool UseSpline = true;

	public double OffsetXY = 5.0;

	public double NozzleDiameter = 10.0;

	public double FeedSpeed = 50.0;

	public double PlungeSpeed = 10.0;

	public double TopHeight = 0.0;

	public double FilletRadius = 4.0;

	public double FilletLimitMaxAngle = 179.0;

	public double FilletLimitMinAngle = 150.0;

	public Printer3DSliceType SliceType = Printer3DSliceType.Step;

	public Printer3DSpiralNextLEvelConnectionType SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Bezeir;

	public double SpiralConnectionDT = 0.2;

	public Printer3DSettings()
	{
	}

	public Printer3DSettings(Printer3DSettings data)
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
