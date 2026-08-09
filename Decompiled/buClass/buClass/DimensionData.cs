using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class DimensionData : buSerilization
{
	public string Chars = "";

	public string Explanation = "";

	public string TextOverride = "";

	public double Distance = 0.0;

	public double Angle = 0.0;

	public bool IsVertical = false;

	public DimensionType Type = DimensionType.None;

	public Pnt3D CatchPoint = new Pnt3D();

	public Pnt3D BasePoint = new Pnt3D();

	public Pnt3D CatchPointOfEntity = new Pnt3D();

	public Pnt3D BasePointOfEntity = new Pnt3D();

	public int ReSizedEntityIndex = -1;

	public int ReSizedEntitySubIndex = -1;

	public string SelectedEntities = "";

	public DimensionData()
	{
	}

	public DimensionData(string chars, string explanation, double distance, double angle, bool isvertical, DimensionType type)
	{
		Chars = chars;
		Explanation = explanation;
		Distance = distance;
		Angle = angle;
		IsVertical = isvertical;
		Type = type;
	}

	public DimensionData(DimensionData data)
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
		return Chars + " - Exp: " + Explanation + " - Dis: " + Distance.ToString("f2") + " - Type: " + Type.ToString() + " - Ent Index: " + ReSizedEntityIndex;
	}
}
