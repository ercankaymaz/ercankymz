using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buShapeCut : buShape
{
	public double Diameter = 10.0;

	public double Length = 200.0;

	public double Angle = 0.0;

	public double StartDistance = 0.0;

	public double EndDistance = 0.0;

	public CutTypes CutType = CutTypes.CutHorizontal;

	public bool isMilling = false;

	public Point3D pntEnd = new Point3D();

	public buShapeCut()
	{
		ShapeGroup = ShapeGroup.Cut;
	}

	public buShapeCut(CutTypes slotType, double diameter, double depth, double length, double startdistance = 0.0, double enddistance = 0.0, double angle = 0.0)
	{
		Diameter = diameter;
		Length = length;
		Angle = angle;
		StartDistance = startdistance;
		EndDistance = enddistance;
		Depth = depth;
		CutType = slotType;
		ShapeGroup = ShapeGroup.Cut;
	}

	public buShapeCut(buShape data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		if (data is buShapeCut)
		{
			pntEnd = new Point3D(((buShapeCut)data).pntEnd.X, ((buShapeCut)data).pntEnd.Y, ((buShapeCut)data).pntEnd.Z);
		}
	}

	public override string ToString()
	{
		string text = "Slot | " + planeName.ToString() + " Dia: " + Diameter.ToString("f2") + "Len: " + Length.ToString("f2");
		if (Angle != 0.0)
		{
			text = text + " , Angle: " + Angle.ToString("f2");
		}
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		return text;
	}
}
