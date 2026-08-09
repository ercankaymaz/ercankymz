using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class XRaySettings : buSerilization
{
	public double SurfaceFollowDistance = 150.0;

	public double ScanStep = 50.0;

	public double GridOffset = 20.0;

	public double DevideLength = 100.0;

	public double G1Feed = 5000.0;

	public double G1FeedForAC = 1000.0;

	public double AMinLimit = -45.0;

	public double AMaxLimit = 45.0;

	public double CMinLimit = -45.0;

	public double CMaxLimit = 45.0;

	public double AChangeFixValue = 3.0;

	public double CChangeFixValue = 3.0;

	public double ACAxisChangeLength = 1000.0;

	public XRaySettings()
	{
	}

	public XRaySettings(XRaySettings data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "Scan Step: " + ScanStep;
	}
}
