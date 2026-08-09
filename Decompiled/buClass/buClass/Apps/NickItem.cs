using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class NickItem : buSerilization
{
	public double Height;

	public double Width;

	public double Offset = 0.0;

	public double Distance;

	public double Angle;

	public double ToolWidth;

	public bool Enable = true;

	public int Index;

	public int SubIndex;

	public Pnt3D OriginalPosition = new Pnt3D();

	public double ExtractXPosition = 0.0;

	public Pnt3D BasePosition = new Pnt3D();

	public ToolBase ToolNick = new ToolBase();

	public List<Pnt3D> CamPoints = new List<Pnt3D>();

	public NickItem()
	{
	}

	public NickItem(NickItem data)
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
		return "Extract X : " + ExtractXPosition.ToString("f2");
	}
}
