using System.Reflection;

namespace buClass.Apps;

public class jewelCamItem : buSerilization
{
	public Pnt9D Point = new Pnt9D();

	public Pnt3D NotMovedPoint = new Pnt3D();

	public Pnt9D SimPoints = new Pnt9D();

	public string Code = "";

	public double Speed = 0.0;

	public bool FastMoveByG1 = false;

	public bool LeaveMode = false;

	public bool PlungeMode = false;

	public bool G0Mode = false;

	public jewelCamItem()
	{
	}

	public jewelCamItem(jewelCamItem data)
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
		return Point.ToString();
	}
}
