using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class EntityDevideSettings : buSerilization
{
	public PolylineDevideType Polyline = PolylineDevideType.DontDevide;

	public ArcDevideType Arc = ArcDevideType.ArcToArcIfBig;

	public CircleDevideType Circle = CircleDevideType.CircleToQuadraticArc;

	public EllipseDevideType Ellipse = EllipseDevideType.EllipseToPolyLine;

	public CurveDevideType Curve = CurveDevideType.CurveToPolyLine;

	public EntityDevideSettings()
	{
	}

	public EntityDevideSettings(EntityDevideSettings data)
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

	public EntityDevideSettings(PolylineDevideType polyline, ArcDevideType arc, CircleDevideType circle, EllipseDevideType ellipse, CurveDevideType curve)
	{
		Polyline = polyline;
		Arc = arc;
		Circle = circle;
		Ellipse = ellipse;
		Curve = curve;
	}
}
