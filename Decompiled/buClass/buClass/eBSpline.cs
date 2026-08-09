using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eBSpline : eCurveEntities
{
	public int Order = 0;

	public entityBSplineType BType = entityBSplineType.BSplineQuadratic;

	public List<double> Weigth = new List<double>();

	public double dt = 0.05;

	public eBSpline()
	{
	}

	public eBSpline(List<Pnt3D> Points, bool Closed_, entityBSplineType Type_)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(Points[i]));
		}
		BType = Type_;
		bClosed = Closed_;
		dt = buSystem.EntitiesResolution.dt;
		Update();
	}

	public eBSpline(List<Pnt3D> Points, bool Closed_, entityBSplineType Type_, double dt_)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(Points[i]));
		}
		BType = Type_;
		bClosed = Closed_;
		dt = dt_;
		Update();
	}

	public eBSpline(List<Pnt3D> Points, float Thickness, Color EntColor, bool Closed_, entityBSplineType Type_)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(Points[i]));
		}
		dispThickness = Thickness;
		dispColor = EntColor;
		BType = Type_;
		bClosed = Closed_;
		dt = buSystem.EntitiesResolution.dt;
		Update();
	}

	public eBSpline(List<Pnt3D> Points, float Thickness, Color EntColor, bool Closed_, entityBSplineType Type_, double dt_)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(Points[i]));
		}
		dispThickness = Thickness;
		dispColor = EntColor;
		BType = Type_;
		bClosed = Closed_;
		dt = dt_;
		Update();
	}

	public eBSpline(List<Pnt3D> Points, float Thickness, Color EntColor, entityBSplineType Type_, int Order_, List<double> Weigths_)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(Points[i]));
		}
		Weigth = new List<double>();
		for (int j = 0; j <= Weigths_.Count - 1; j++)
		{
			Weigth.Add(Weigths_[j]);
		}
		dispThickness = Thickness;
		dispColor = EntColor;
		BType = Type_;
		Order = Order_;
		dt = buSystem.EntitiesResolution.dt;
		Update();
	}

	public eBSpline(List<Pnt3D> Points, entityBSplineType Type_, int Order_, List<double> Weigths_)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(Points[i]));
		}
		Weigth = new List<double>();
		for (int j = 0; j <= Weigths_.Count - 1; j++)
		{
			Weigth.Add(Weigths_[j]);
		}
		BType = Type_;
		dt = buSystem.EntitiesResolution.dt;
		Order = Order_;
		Update();
	}

	public eBSpline(eEntities Ent)
	{
		if (Ent.GetType() == typeof(eBSpline))
		{
			for (int i = 0; i <= ((eBSpline)Ent).ControlPoints.Count - 1; i++)
			{
				ControlPoints.Add(new Pnt3D(((eBSpline)Ent).ControlPoints[i]));
			}
			Weigth = new List<double>();
			for (int j = 0; j <= ((eBSpline)Ent).Weigth.Count - 1; j++)
			{
				Weigth.Add(((eBSpline)Ent).Weigth[j]);
			}
			bClosed = ((eBSpline)Ent).bClosed;
			StartPoint = Pnt3D.Copy(((eBSpline)Ent).StartPoint);
			EndPoint = Pnt3D.Copy(((eBSpline)Ent).EndPoint);
			Order = ((eBSpline)Ent).Order;
			BType = ((eBSpline)Ent).BType;
			dt = ((eBSpline)Ent).dt;
			eEntities.CopyBase(Ent, this);
			Update();
		}
	}

	public static eEntities DecodeBSpline(List<string> Codes)
	{
		eBSpline eBSpline2 = new eBSpline();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eBSpline2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eBSpline2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eBSpline2.Update();
		return eBSpline2;
	}

	public override string ToString()
	{
		return "eBSpline - Count : " + ControlPoints.Count + " - Order : " + Order.ToString("f3") + " - BType : " + BType.ToString("");
	}
}
