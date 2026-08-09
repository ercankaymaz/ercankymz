using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class AnalyseEntitiesResultError : buSerilization5
{
	public bool Enable = true;

	public int IndexEntity = -1;

	public List<int> IndexEntityList = new List<int>();

	public string Explanation = "";

	public Point3D pntError = new Point3D();

	public AnalyseEntitiesResultErrorType ErrorType = AnalyseEntitiesResultErrorType.None;

	public AnalyseEntitiesActionType Action = AnalyseEntitiesActionType.None;

	public AnalyseEntitiesResultError()
	{
	}

	public AnalyseEntitiesResultError(AnalyseEntitiesResultError data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		return "IndexEntity: " + IndexEntity + " - ErrorType: " + ErrorType;
	}
}
