using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeHole3 : buShapeHole
{
	public double DiameterOutside = 4.0;

	public double Hole3Angle = 0.0;

	public double DistanceX = 40.0;

	public double DistanceY = 40.0;

	public buShapeHole3()
	{
		DrillType = drillTypes.ThreeHole;
		ShapeGroup = ShapeGroup.Drill;
	}

	public buShapeHole3(double diameter, double depth, double diameteroutside, double distancex, double distancey, double angle = 0.0)
	{
		Diameter = diameter;
		DiameterOutside = diameteroutside;
		Depth = depth;
		DistanceX = distancex;
		DistanceY = distancey;
		Hole3Angle = angle;
		DrillType = drillTypes.ThreeHole;
		ShapeGroup = ShapeGroup.Drill;
	}

	public buShapeHole3(buShape data)
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
		string text = "Hole 3 | " + planeName.ToString() + " Dia: " + Diameter.ToString("f2") + " DiaOut: " + DiameterOutside.ToString("f2") + " DisX: " + DistanceX.ToString("f2") + " DisY: " + DistanceY.ToString("f2");
		if (Hole3Angle != 0.0)
		{
			text = text + " , Angle: " + Hole3Angle.ToString("f2");
		}
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		return text;
	}
}
