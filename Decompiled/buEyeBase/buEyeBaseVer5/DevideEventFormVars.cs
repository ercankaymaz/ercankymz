using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class DevideEventFormVars : buSerilization5
{
	public bool LineEnable = true;

	public bool PolylineEnable = true;

	public bool CircleEnable = true;

	public bool ArcEnable = true;

	public bool EllipseEnable = true;

	public bool CompositeCurveEnable = true;

	public bool CurveEnable = true;

	public double LineLength = 10.0;

	public double PolylineLength = 10.0;

	public double CircleLength = 10.0;

	public double ArcLength = 10.0;

	public double EllipseLength = 10.0;

	public double CompositeCurveLength = 10.0;

	public double CurveLength = 10.0;

	public bool ConvertAllToPolyline = false;

	public DevideEventFormVars()
	{
	}

	public DevideEventFormVars(DevideEventFormVars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
