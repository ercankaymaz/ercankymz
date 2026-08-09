using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class XRayMisalignment : buSerilization
{
	public double AngleOfXVector = 0.0;

	public double AngleOfYVector = 0.0;

	public double AngleOfZVector = 0.0;

	public Pnt3D MovedPositionARotation = new Pnt3D();

	public Pnt3D MovedPositionCRotation = new Pnt3D();

	public XRayMisalignment()
	{
	}

	public XRayMisalignment(XRayMisalignment data)
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
		return "AngleOfZVector: " + AngleOfZVector;
	}
}
