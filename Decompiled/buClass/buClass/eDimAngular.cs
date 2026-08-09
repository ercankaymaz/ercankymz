using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eDimAngular : eDimension
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public Pnt3D QuadrantPoint = new Pnt3D();

	public Pnt3D SetPoint = new Pnt3D();

	public Line3D FirstLine = new Line3D();

	public Line3D SecondLine = new Line3D();

	public bool IsArc = false;

	public eDimAngular()
	{
	}

	public eDimAngular(Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D CenterPoint, Pnt3D QuadrantPoint, Pnt3D SetPoint, Line3D FirstLine, Line3D SecondLine, bool IsArc)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.SetPoint = new Pnt3D(SetPoint);
		this.QuadrantPoint = new Pnt3D(QuadrantPoint);
		this.FirstLine = new Line3D(FirstLine);
		this.SecondLine = new Line3D(SecondLine);
		this.IsArc = IsArc;
		Update();
	}

	public eDimAngular(Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D CenterPoint, Pnt3D QuadrantPoint, Pnt3D SetPoint, Line3D FirstLine, Line3D SecondLine, bool IsArc, float Thickness, Color Clr)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		this.SetPoint = new Pnt3D(SetPoint);
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.QuadrantPoint = new Pnt3D(QuadrantPoint);
		this.FirstLine = new Line3D(FirstLine);
		this.SecondLine = new Line3D(SecondLine);
		dispThickness = Thickness;
		dispColor = Clr;
		this.IsArc = IsArc;
		Update();
	}

	public eDimAngular(eEntities ent)
	{
		if (ent.GetType() == typeof(eDimAngular))
		{
			StartPoint = new Pnt3D(((eDimAngular)ent).StartPoint);
			EndPoint = new Pnt3D(((eDimAngular)ent).EndPoint);
			SetPoint = new Pnt3D(((eDimAngular)ent).SetPoint);
			CenterPoint = new Pnt3D(((eDimAngular)ent).CenterPoint);
			QuadrantPoint = new Pnt3D(((eDimAngular)ent).QuadrantPoint);
			FirstLine = new Line3D(((eDimAngular)ent).FirstLine);
			SecondLine = new Line3D(((eDimAngular)ent).SecondLine);
			TextHeight = ((eDimAngular)ent).TextHeight;
			DimData = new DimensionData(((eDimAngular)ent).DimData);
			IsArc = ((eDimAngular)ent).IsArc;
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeDimLinear(List<string> Codes)
	{
		eDimAngular eDimAngular2 = new eDimAngular();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eDimAngular2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eDimAngular2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eDimAngular2.Update();
		return eDimAngular2;
	}

	public override string ToString()
	{
		return "eDimAngular - SP : " + StartPoint.ToString(3) + " - EP : " + EndPoint.ToString(3) + " - Set Pnt : " + SetPoint.ToString(3) + " - QuadrantPoint : " + QuadrantPoint.ToString() + " - IsArc : " + IsArc;
	}
}
