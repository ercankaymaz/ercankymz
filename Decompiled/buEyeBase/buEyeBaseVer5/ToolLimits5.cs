using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ToolLimits5 : buSerilization5
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

	public ToolLimits5()
	{
	}

	public ToolLimits5(ToolLimits5 cam)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(cam, ref CopiedClass);
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

	public ToolLimits5(ToolLimits cam)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(cam, ref CopiedClass);
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

	public override string ToString()
	{
		return "PlaneAll: " + PlaneAll + " - PlaneTop: " + PlaneTop + " - PlaneLeft: " + PlaneLeft + " - PlaneRight: " + PlaneRight;
	}
}
