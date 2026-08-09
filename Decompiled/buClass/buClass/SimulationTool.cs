using System;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class SimulationTool : buSerilization
{
	public bool Visible = false;

	public double Diameter = 10.0;

	public double Length = 50.0;

	public double Thickness = 4.0;

	public double TangentAngle = 0.0;

	public Pnt3D Coordinate = new Pnt3D();

	public Color Color = Color.Gray;

	public Color BorderColor = Color.DarkGray;

	public SimulationToolType Type = SimulationToolType.Milling;

	public LeftMiddleRightLocationType Orientation = LeftMiddleRightLocationType.Middle;

	public SimulationTool()
	{
	}

	public SimulationTool(SimulationTool data)
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
}
