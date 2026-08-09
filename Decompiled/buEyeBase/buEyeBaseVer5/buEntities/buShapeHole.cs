using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeHole : buShape
{
	public double Diameter = 10.0;

	public drillTypes DrillType = drillTypes.SingleHole;

	public bool isMilling = false;

	public bool isTapping = false;

	public buShapeHole()
	{
		DrillType = drillTypes.SingleHole;
		ShapeGroup = ShapeGroup.Drill;
	}

	public buShapeHole(double diameter)
	{
		Diameter = diameter;
		DrillType = drillTypes.SingleHole;
		ShapeGroup = ShapeGroup.Drill;
	}

	public buShapeHole(double diameter, double depth)
	{
		Diameter = diameter;
		Depth = depth;
		DrillType = drillTypes.SingleHole;
		ShapeGroup = ShapeGroup.Drill;
	}

	public buShapeHole(buShape data)
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
		string text = "Hole | " + planeName.ToString() + " Dia: " + Diameter.ToString("f2");
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		if (isTapping)
		{
			text += " , Tapping";
		}
		return text;
	}
}
