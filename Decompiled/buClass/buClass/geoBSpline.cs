using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoBSpline : geoEntity
{
	public List<Pnt3D> ControlPoints = new List<Pnt3D>();

	public entityBSplineType BType = entityBSplineType.BSplineQuadratic;

	public double dt = 0.05;

	public bool Closed = false;

	public geoBSpline()
	{
	}

	public geoBSpline(geoBSpline bspline)
	{
		Vertice.Clear();
		for (int i = 0; i <= bspline.Vertice.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(bspline.Vertice[i]));
		}
		ControlPoints.Clear();
		for (int j = 0; j <= bspline.ControlPoints.Count - 1; j++)
		{
			ControlPoints.Add(new Pnt3D(bspline.ControlPoints[j]));
		}
		Closed = bspline.Closed;
		dt = bspline.dt;
		BType = bspline.BType;
		Layer = bspline.Layer;
		Mode = bspline.Mode;
		ToolNo = bspline.ToolNo;
		Tag = bspline.Tag;
		Color = bspline.Color;
		Index = bspline.Index;
		Thickness = bspline.Thickness;
		Direction = bspline.Direction;
		TypeDefination = bspline.TypeDefination;
		isText = bspline.isText;
	}

	public geoBSpline(List<Pnt3D> controls)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= controls.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(controls[i]));
		}
		double num = buSystem.EntitiesResolution.dt;
		if (dt > 0.0)
		{
			num = dt;
		}
		Vertice.Clear();
		if (BType == entityBSplineType.BSplineCubic)
		{
			buStatics.CreatBSplineCubicUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.BSplineQuadratic)
		{
			buStatics.CreatBSplineQuadraticUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.SplineCubic)
		{
			buStatics.CreatSplineCubicUniform(ControlPoints, num, ref Vertice);
		}
	}

	public geoBSpline(List<Pnt3D> controls, bool closed, entityBSplineType Type)
	{
		Closed = closed;
		BType = Type;
		ControlPoints.Clear();
		for (int i = 0; i <= controls.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(controls[i]));
		}
		double num = buSystem.EntitiesResolution.dt;
		if (dt > 0.0)
		{
			num = dt;
		}
		Vertice.Clear();
		if (BType == entityBSplineType.BSplineCubic)
		{
			buStatics.CreatBSplineCubicUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.BSplineQuadratic)
		{
			buStatics.CreatBSplineQuadraticUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.SplineCubic)
		{
			buStatics.CreatSplineCubicUniform(ControlPoints, num, ref Vertice);
		}
	}

	public geoBSpline(List<Pnt3D> controls, bool closed, entityBSplineType Type, Color color, double thickness)
	{
		Color = color;
		Thickness = thickness;
		Closed = closed;
		BType = Type;
		ControlPoints.Clear();
		for (int i = 0; i <= controls.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(controls[i]));
		}
		double num = buSystem.EntitiesResolution.dt;
		if (dt > 0.0)
		{
			num = dt;
		}
		Vertice.Clear();
		if (BType == entityBSplineType.BSplineCubic)
		{
			buStatics.CreatBSplineCubicUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.BSplineQuadratic)
		{
			buStatics.CreatBSplineQuadraticUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.SplineCubic)
		{
			buStatics.CreatSplineCubicUniform(ControlPoints, num, ref Vertice);
		}
	}

	public geoBSpline(List<Pnt3D> controls, Color color)
	{
		Color = color;
		ControlPoints.Clear();
		for (int i = 0; i <= controls.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(controls[i]));
		}
		double num = buSystem.EntitiesResolution.dt;
		if (dt > 0.0)
		{
			num = dt;
		}
		Vertice.Clear();
		if (BType == entityBSplineType.BSplineCubic)
		{
			buStatics.CreatBSplineCubicUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.BSplineQuadratic)
		{
			buStatics.CreatBSplineQuadraticUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.SplineCubic)
		{
			buStatics.CreatSplineCubicUniform(ControlPoints, num, ref Vertice);
		}
	}

	public geoBSpline(List<Pnt3D> controls, Color color, double thickness)
	{
		Color = color;
		Thickness = thickness;
		ControlPoints.Clear();
		for (int i = 0; i <= controls.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(controls[i]));
		}
		double num = buSystem.EntitiesResolution.dt;
		if (dt > 0.0)
		{
			num = dt;
		}
		Vertice.Clear();
		if (BType == entityBSplineType.BSplineCubic)
		{
			buStatics.CreatBSplineCubicUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.BSplineQuadratic)
		{
			buStatics.CreatBSplineQuadraticUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.SplineCubic)
		{
			buStatics.CreatSplineCubicUniform(ControlPoints, num, ref Vertice);
		}
	}

	public geoBSpline(List<Pnt3D> controls, int Layer)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= controls.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(controls[i]));
		}
		double num = buSystem.EntitiesResolution.dt;
		if (dt > 0.0)
		{
			num = dt;
		}
		Vertice.Clear();
		if (BType == entityBSplineType.BSplineCubic)
		{
			buStatics.CreatBSplineCubicUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.BSplineQuadratic)
		{
			buStatics.CreatBSplineQuadraticUniform(ControlPoints, num, Closed, ref Vertice);
		}
		if (BType == entityBSplineType.SplineCubic)
		{
			buStatics.CreatSplineCubicUniform(ControlPoints, num, ref Vertice);
		}
		base.Layer = Layer;
	}

	public override string ToString()
	{
		if (Vertice.Count == 0)
		{
			return "PLine - Count: " + Vertice.Count;
		}
		return "PLine - Count: " + Vertice.Count + " Start: " + Vertice[0].ToString() + " End: " + Vertice[Vertice.Count - 1].ToString();
	}
}
