using System.Reflection;

namespace buClass.Apps;

public class jewelMaterial : buSerilization
{
	public double Diameter = 30.0;

	public double MajorDiameter = 20.0;

	public double MinorDiameter = 10.0;

	public double EllipseCircumference = 100.0;

	public double Width = 20.0;

	public double StartSpaceX = 0.0;

	public double EndSpaceX = 0.0;

	public double SpaceY = 0.0;

	public bool MoveEnable = false;

	public bool ReadSurfaceEnable = false;

	public jewelCurveType CurveType = jewelCurveType.Flat;

	public jewelMaterialShapeType ShapeType = jewelMaterialShapeType.Circle;

	public double CurveRadius = 0.0;

	public jewelMaterial()
	{
	}

	public jewelMaterial(jewelMaterial data)
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
		return "Dia: " + Diameter + "  -  Width: " + Width + "  -  Curve Rad: " + CurveRadius;
	}
}
