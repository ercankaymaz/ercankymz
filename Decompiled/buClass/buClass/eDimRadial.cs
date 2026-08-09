using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eDimRadial : eDimension
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public Pnt3D SetPoint = new Pnt3D();

	public double Radius = 0.0;

	public eDimRadial()
	{
	}

	public eDimRadial(Pnt3D CenterPoint, double Radius, Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D SetPoint)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		this.Radius = Radius;
		this.SetPoint = new Pnt3D(SetPoint);
		Update();
	}

	public eDimRadial(Pnt3D CenterPoint, double Radius, Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D SetPoint, float Thickness, Color Clr)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.Radius = Radius;
		this.SetPoint = new Pnt3D(SetPoint);
		dispThickness = Thickness;
		dispColor = Clr;
		Update();
	}

	public eDimRadial(eEntities ent)
	{
		if (ent.GetType() == typeof(eDimRadial))
		{
			StartPoint = new Pnt3D(((eDimRadial)ent).StartPoint);
			EndPoint = new Pnt3D(((eDimRadial)ent).EndPoint);
			CenterPoint = new Pnt3D(((eDimRadial)ent).CenterPoint);
			Radius = ((eDimRadial)ent).Radius;
			SetPoint = new Pnt3D(((eDimRadial)ent).SetPoint);
			TextHeight = ((eDimRadial)ent).TextHeight;
			DimData = new DimensionData(((eDimRadial)ent).DimData);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeDimRadial(List<string> Codes)
	{
		eDimRadial eDimRadial2 = new eDimRadial();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eDimRadial2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eDimRadial2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eDimRadial2.Update();
		return eDimRadial2;
	}

	public override string ToString()
	{
		return "eDimRadius - Center Pnt : " + CenterPoint.ToString(3) + " - Rad: " + Radius.ToString("f3") + " - Set Pnt : " + SetPoint.ToString(3);
	}
}
