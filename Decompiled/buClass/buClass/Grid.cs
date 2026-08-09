using System;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class Grid : buSerilization
{
	public bool Visible = false;

	public bool AutoSize = false;

	public bool AutoPlane = false;

	public bool AlwaysBehind = true;

	public Pnt2D MinimumValue = new Pnt2D(-100.0, -100.0);

	public Pnt2D MaximumValue = new Pnt2D(-100.0, -100.0);

	public double Step = 10.0;

	public int MajorLineSteps = 5;

	public Color LineColor = Color.LightGray;

	public Color MajorLineColor = Color.LightGray;

	public Color AxisXColor = Color.Gray;

	public Color AxisYColor = Color.Gray;

	public Color BorderColor = Color.LightGray;

	public Color FillColor = Color.LightGray;

	public bool GridStepFromSnapXValue = true;

	public bool Lighting = true;

	public Grid()
	{
	}

	public Grid(Grid data)
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
		return "Visible : " + Visible + " ;  Step : " + Step;
	}
}
