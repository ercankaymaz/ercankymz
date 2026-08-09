using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class PunchPosition : buSerilization
{
	public Pnt3D BasePosition = new Pnt3D();

	public Pnt3D OrjinalPosition = new Pnt3D();

	public Pnt3D Offsets = new Pnt3D();

	public Vec3D Size = new Vec3D();

	public int ToolIndex = 0;

	public bool NextJob = false;

	public PunchPosition()
	{
	}

	public PunchPosition(PunchPosition data)
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
		return "X : " + BasePosition.X.ToString("f3") + " - Y : " + BasePosition.Y.ToString("f3");
	}
}
