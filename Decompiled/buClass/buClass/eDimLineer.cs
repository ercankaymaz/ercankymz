using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eDimLineer : eDimension
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public Pnt3D SetPoint = new Pnt3D();

	public bool Aligned = false;

	public eDimLineer()
	{
	}

	public eDimLineer(Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D SetPoint, bool Aligned)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		this.SetPoint = new Pnt3D(SetPoint);
		this.Aligned = Aligned;
		Update();
	}

	public eDimLineer(Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D SetPoint, bool Aligned, float Thickness, Color Clr)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		this.SetPoint = new Pnt3D(SetPoint);
		this.Aligned = Aligned;
		dispThickness = Thickness;
		dispColor = Clr;
		Update();
	}

	public eDimLineer(eEntities ent)
	{
		if (ent.GetType() == typeof(eDimLineer))
		{
			StartPoint = new Pnt3D(((eDimLineer)ent).StartPoint);
			EndPoint = new Pnt3D(((eDimLineer)ent).EndPoint);
			SetPoint = new Pnt3D(((eDimLineer)ent).SetPoint);
			TextHeight = ((eDimLineer)ent).TextHeight;
			Aligned = ((eDimLineer)ent).Aligned;
			DimData = new DimensionData(((eDimLineer)ent).DimData);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeDimLinear(List<string> Codes)
	{
		eDimLineer eDimLineer2 = new eDimLineer();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eDimLineer2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eDimLineer2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eDimLineer2.Update();
		return eDimLineer2;
	}

	public override string ToString()
	{
		return "eDimLineer - SP : " + StartPoint.ToString(3) + " - EP : " + EndPoint.ToString(3) + " - Set Pnt : " + SetPoint.ToString(3) + " - Aligned : " + Aligned + " - Type : " + DimData.Type;
	}
}
