using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class RulStrectPoints : buSerilization
{
	public int No = 0;

	public double dX = 0.0;

	public double dY = 0.0;

	public Pnt3D Position = new Pnt3D();

	public RulStrectPoints()
	{
	}

	public RulStrectPoints(RulStrectPoints data)
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
		return "No : " + No + " - Dx : " + dX + " - Dy : " + dY + " X:" + Position.X + " , Y:" + Position.Y;
	}
}
