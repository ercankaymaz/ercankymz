using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eDimDiametric : eDimension
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public Pnt3D SetPoint = new Pnt3D();

	public double Diameter = 0.0;

	public eDimDiametric()
	{
	}

	public eDimDiametric(Pnt3D CenterPoint, double Diameter, Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D SetPoint)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.Diameter = Diameter;
		this.SetPoint = new Pnt3D(SetPoint);
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		Update();
	}

	public eDimDiametric(Pnt3D CenterPoint, double Diameter, Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D SetPoint, float Thickness, Color Clr)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.Diameter = Diameter;
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		this.SetPoint = new Pnt3D(SetPoint);
		dispThickness = Thickness;
		dispColor = Clr;
		Update();
	}

	public eDimDiametric(eEntities ent)
	{
		if (ent.GetType() == typeof(eDimDiametric))
		{
			StartPoint = new Pnt3D(((eDimDiametric)ent).StartPoint);
			EndPoint = new Pnt3D(((eDimDiametric)ent).EndPoint);
			CenterPoint = new Pnt3D(((eDimDiametric)ent).CenterPoint);
			Diameter = ((eDimDiametric)ent).Diameter;
			SetPoint = new Pnt3D(((eDimDiametric)ent).SetPoint);
			TextHeight = ((eDimDiametric)ent).TextHeight;
			DimData = new DimensionData(((eDimDiametric)ent).DimData);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeDimDiameter(List<string> Codes)
	{
		eDimDiametric eDimDiametric2 = new eDimDiametric();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eDimDiametric2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eDimDiametric2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eDimDiametric2.Update();
		return eDimDiametric2;
	}

	public override string ToString()
	{
		return "eDimDiametric - Center Pnt : " + CenterPoint.ToString(3) + " - Dia: " + Diameter.ToString("f3") + " - Set Pnt : " + SetPoint.ToString(3);
	}
}
