using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class DiemakerData : buSerilization
{
	public double Pt = 2.0;

	public double PtReal = 2.0;

	public DiemakerType DiemakerType = DiemakerType.Cutting;

	public int DiemakerTYpeAsInteger = 0;

	public double RuleHeight = 0.0;

	public bool IsBridge = false;

	public bool IsNick = false;

	public bool IsBroach = false;

	public bool IsSameEntity = false;

	public bool IsMirrorEntity = false;

	public DiemakerData()
	{
	}

	public DiemakerData(DiemakerData data)
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
		return "Pt: " + Pt + " - " + DiemakerType;
	}
}
