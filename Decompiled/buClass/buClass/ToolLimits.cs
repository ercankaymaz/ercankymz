using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolLimits : buSerilization
{
	public Pnt6D AxesMinLimits = new Pnt6D(0.0, 0.0, 0.0, -360.0, -360.0, -360.0);

	public Pnt6D AxesMaxLimits = new Pnt6D(0.0, 0.0, 0.0, 360.0, 360.0, 360.0);

	public bool PlaneTop = false;

	public bool PlaneBottom = false;

	public bool PlaneFront = false;

	public bool PlaneBack = false;

	public bool PlaneLeft = false;

	public bool PlaneRight = false;

	public bool PlaneAll = true;

	public bool PlaneSlope = false;

	public bool RotationA = false;

	public bool RotationB = false;

	public bool RotationC = false;

	public ToolLimits()
	{
	}

	public ToolLimits(ToolLimits cam)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(cam, ref CopiedClass);
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
		return "PlaneAll: " + PlaneAll + " - PlaneTop: " + PlaneTop + " - PlaneLeft: " + PlaneLeft + " - PlaneRight: " + PlaneRight;
	}
}
