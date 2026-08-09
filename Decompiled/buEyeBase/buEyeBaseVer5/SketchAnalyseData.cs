using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5;

[Serializable]
public class SketchAnalyseData : buSerilization5
{
	public List<double> DepthLevel = null;

	public List<buEntity> AnalyseEntities = null;

	public SketchAnalyseData()
	{
		DepthLevel = new List<double>();
		AnalyseEntities = new List<buEntity>();
	}

	public SketchAnalyseData(SketchAnalyseData data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		DepthLevel = new List<double>();
		AnalyseEntities = new List<buEntity>();
		if (GetType() == CopiedClass.GetType())
		{
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
		for (int j = 0; j <= data.DepthLevel.Count - 1; j++)
		{
			DepthLevel.Add(data.DepthLevel[j]);
		}
		for (int k = 0; k <= data.AnalyseEntities.Count - 1; k++)
		{
			AnalyseEntities.Add(buEntity.Copy(data.AnalyseEntities[k]));
		}
	}

	public override string ToString()
	{
		return "Ent: " + AnalyseEntities.Count + "- Depth: " + DepthLevel.Count;
	}
}
