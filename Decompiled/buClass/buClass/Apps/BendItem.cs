using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendItem : buSerilization
{
	public double ExtractXPosition = 0.0;

	public Pnt3D EntityPosition = new Pnt3D();

	public int Index;

	public int EntIndex;

	public double Offset;

	public double Angle;

	public double Radius;

	public bool Edge = false;

	public bool Enable = true;

	public bool IsArc = false;

	public BendItem()
	{
	}

	public BendItem(BendItem data)
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
		return "X : " + ExtractXPosition.ToString("f2") + " - Angle :" + Angle.ToString("f2") + " , Edge: " + Edge + " , IsArc: " + IsArc;
	}
}
