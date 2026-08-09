using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class SelectionOption : buSerilization
{
	public bool Point = true;

	public bool Line = true;

	public bool Polyline = true;

	public bool Circle = true;

	public bool Arc = true;

	public bool Ellipse = true;

	public bool EllipseArc = true;

	public bool CompositeCurve = true;

	public bool Curve = true;

	public bool Text = true;

	public bool Picture = true;

	public bool Mesh = true;

	public bool Surface = true;

	public bool Brep = true;

	public bool Dimension = true;

	public bool CompositeCurveToEntity = true;

	public bool CircleToArc = false;

	public bool CircleTo4Arc = false;

	public bool SplitArcIfGreatThen180 = false;

	public bool OnlyClosedShapes = false;

	public int MinVerticeCount = 0;

	public double SplitArcIfGreatThenValue = 0.0;

	public double MinSingleEntityLength = 0.0;

	public SelectionOption()
	{
	}

	public SelectionOption(SelectedEntities data)
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

	public SelectionOption(bool AllSelected)
	{
		Arc = AllSelected;
		Brep = AllSelected;
		Circle = AllSelected;
		CompositeCurve = AllSelected;
		Curve = AllSelected;
		Dimension = AllSelected;
		Ellipse = AllSelected;
		EllipseArc = AllSelected;
		Line = AllSelected;
		Mesh = AllSelected;
		Picture = AllSelected;
		Point = AllSelected;
		Polyline = AllSelected;
		Surface = AllSelected;
		Text = AllSelected;
	}

	public SelectionOption(bool Wire, bool Solid, bool Dimension, bool Text, bool Point, bool Picture)
	{
		Arc = Wire;
		Brep = Solid;
		Circle = Wire;
		CompositeCurve = Wire;
		Curve = Wire;
		this.Dimension = Dimension;
		Ellipse = Wire;
		EllipseArc = Wire;
		Line = Wire;
		Mesh = Solid;
		this.Picture = Picture;
		this.Point = Point;
		Polyline = Wire;
		Surface = Solid;
		this.Text = Text;
	}

	public SelectionOption(bool Wire, bool Solid, bool Dimension, bool Text, bool Point, bool Picture, bool circletoArc, bool circleto4Arc, bool splitArcIfGreatThen180)
	{
		Arc = Wire;
		Brep = Solid;
		Circle = Wire;
		CompositeCurve = Wire;
		Curve = Wire;
		this.Dimension = Dimension;
		Ellipse = Wire;
		EllipseArc = Wire;
		Line = Wire;
		Mesh = Solid;
		this.Picture = Picture;
		this.Point = Point;
		Polyline = Wire;
		Surface = Solid;
		this.Text = Text;
		CircleToArc = circletoArc;
		CircleTo4Arc = circleto4Arc;
		SplitArcIfGreatThen180 = splitArcIfGreatThen180;
	}
}
