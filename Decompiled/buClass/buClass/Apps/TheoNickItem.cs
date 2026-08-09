using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TheoNickItem : TheoItem
{
	public Pnt3D Position = new Pnt3D();

	public string MCode = "";

	public double YPos = 0.0;

	public TheoNickItem()
	{
	}

	public TheoNickItem(double x)
	{
		XPos = x;
	}

	public TheoNickItem(TheoNickItem data)
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
		return "Nick - Y: " + YPos;
	}
}
