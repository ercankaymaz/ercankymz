using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeHoleMulti : buShapeHole
{
	public int Count = 2;

	public double Distance = 32.0;

	public double StartDistance = 10.0;

	public double EndDistance = 10.0;

	public double Angle = 0.0;

	public buShapeHoleMulti()
	{
		ShapeGroup = ShapeGroup.Drill;
	}

	public buShapeHoleMulti(drillTypes type, double diameter, int count, double distance, double startdistance, double enddistance, double Angle = 0.0)
	{
		Diameter = diameter;
		Count = count;
		Distance = distance;
		StartDistance = startdistance;
		EndDistance = enddistance;
		DrillType = type;
		this.Angle = Angle;
		ShapeGroup = ShapeGroup.Drill;
	}

	public buShapeHoleMulti(drillTypes type, double diameter, int count, double distance, double startdistance, double enddistance, double depth, double Angle = 0.0)
	{
		Diameter = diameter;
		Count = count;
		Depth = depth;
		Distance = distance;
		StartDistance = startdistance;
		EndDistance = enddistance;
		DrillType = type;
		this.Angle = Angle;
		ShapeGroup = ShapeGroup.Drill;
	}

	public buShapeHoleMulti(buShape data)
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
		string text = "Hole Multi | " + planeName.ToString() + " Dia: " + Diameter.ToString("f2") + " Count: " + Count + " Dis: " + Distance.ToString("f2");
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		return text;
	}
}
