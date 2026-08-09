using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeJunction : buShape
{
	public double Diameter = 10.0;

	public double DiameterOutside = 5.0;

	public double Distance = 40.0;

	public JunctionTypes JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;

	public bool isMilling = false;

	public buShapeJunction()
	{
		ShapeGroup = ShapeGroup.Junction;
	}

	public buShapeJunction(JunctionTypes junctionType, double diameter, double depth, double diameteroutside, double distance, bool ismilling)
	{
		Diameter = diameter;
		DiameterOutside = diameteroutside;
		Distance = distance;
		isMilling = ismilling;
		Depth = depth;
		JunctionType = junctionType;
		ShapeGroup = ShapeGroup.Junction;
	}

	public buShapeJunction(buShape data)
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
		string text = "Junction | " + planeName.ToString() + " Dia: " + Diameter.ToString("f2") + "Dis: " + Distance.ToString("f2");
		if ((JunctionType == JunctionTypes.Junction2HoleNearByHorizontal) | (JunctionType == JunctionTypes.Junction2HoleNearByVertical))
		{
			text = text + " , Dia Outside: " + DiameterOutside.ToString("f2");
		}
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		return text;
	}
}
