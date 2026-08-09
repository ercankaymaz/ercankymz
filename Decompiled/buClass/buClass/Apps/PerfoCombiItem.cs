using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class PerfoCombiItem : buSerilization
{
	public double StartOffset;

	public double EndOffset;

	public double PerfoHeight;

	public double MaleWidth;

	public double FemaleWidth;

	public double StartPoint;

	public double EndPoint;

	public bool Enable = true;

	public bool MultiPerfo = false;

	public DiemakerPerfoType PerfoType = DiemakerPerfoType.MaleMale;

	public List<Pnt3D> Points = new List<Pnt3D>();

	public ToolBase ToolPerfo = new ToolBase();

	public List<Pnt3D> CamPoints = new List<Pnt3D>();

	public PerfoCombiItem()
	{
		Enable = true;
	}

	public PerfoCombiItem(PerfoCombiItem data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		ToolPerfo = new ToolBase(data.ToolPerfo);
		CamPoints = new List<Pnt3D>();
		for (int j = 0; j <= data.CamPoints.Count - 1; j++)
		{
			CamPoints.Add(new Pnt3D(data.CamPoints[j]));
		}
	}

	public override string ToString()
	{
		return "Type : " + PerfoType;
	}
}
