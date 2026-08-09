using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class EndCutItem : buSerilization
{
	public double ExtractXPosition = 0.0;

	public ToolBase ToolEndCut = new ToolBase();

	public List<Pnt3D> CamPoints = new List<Pnt3D>();

	public EndCutItem()
	{
	}

	public EndCutItem(EndCutItem data)
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
		ToolEndCut = new ToolBase(data.ToolEndCut);
		CamPoints = new List<Pnt3D>();
		for (int j = 0; j <= data.CamPoints.Count - 1; j++)
		{
			CamPoints.Add(new Pnt3D(data.CamPoints[j]));
		}
	}

	public override string ToString()
	{
		return "Extract X : " + ExtractXPosition.ToString("f2") + " - T: " + ToolEndCut.Data.No;
	}
}
