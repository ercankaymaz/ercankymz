using System.Collections.Generic;
using System.Reflection;

namespace buClass;

public class FindInternalEntitiesFromContourSettings : buSerilization
{
	public bool CurveCheckBoxsizeCover = true;

	public bool CurveCheckIntersections = true;

	public bool GetTextStrings = true;

	public bool TextCheckBoxsizeCover = false;

	public bool TextForInsertionPoint = true;

	public bool AddPoint = false;

	public bool UseEntityInfoData = false;

	public string refEntityInfoData = "";

	public List<string> InnerEntitiesLayerName = new List<string>();

	public FindInternalEntitiesFromContourSettings()
	{
	}

	public FindInternalEntitiesFromContourSettings(FindInternalEntitiesFromContourSettings data)
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
}
