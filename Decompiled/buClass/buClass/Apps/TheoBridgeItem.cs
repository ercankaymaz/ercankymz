using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TheoBridgeItem : TheoItem
{
	public double Width = 0.0;

	public double Height = 0.0;

	public Pnt3D Position = new Pnt3D();

	public TheoBridgeItem()
	{
	}

	public TheoBridgeItem(double x, double width, double height)
	{
		Width = width;
		XPos = x;
		Height = height;
	}

	public TheoBridgeItem(TheoBridgeItem data)
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
		return "Bridge - Width: " + Width + " - X: " + XPos;
	}
}
