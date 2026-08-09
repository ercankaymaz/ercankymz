using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoArc : geoEntity
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public Pnt3D CenterPoint = new Pnt3D();

	public double Radius = 0.0;

	public double SweepAngle = 0.0;

	public double StartAngle = 0.0;

	public double EndAngle = 0.0;

	public bool Reverse = false;

	public bool isCW = false;

	public geoArc()
	{
	}

	public geoArc(geoArc arc)
	{
		CenterPoint = new Pnt3D(arc.CenterPoint);
		Radius = arc.Radius;
		StartAngle = arc.StartAngle;
		EndAngle = arc.EndAngle;
		Reverse = arc.Reverse;
		Layer = arc.Layer;
		Mode = arc.Mode;
		ToolNo = arc.ToolNo;
		Tag = arc.Tag;
		Color = arc.Color;
		Index = arc.Index;
		Thickness = arc.Thickness;
		Direction = arc.Direction;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, StartAngle, EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, StartAngle, EndAngle, count, Plane, ref Vertice);
		TypeDefination = arc.TypeDefination;
		isText = arc.isText;
	}

	public geoArc(double X1, double Y1, double Rad, double StartAng, double EndAng)
	{
		CenterPoint = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = 0.0
		};
		Radius = Rad;
		StartAngle = StartAng;
		EndAngle = EndAng;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, StartAngle, EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, StartAngle, EndAngle, count, Plane, ref Vertice);
	}

	public geoArc(double X1, double Y1, double Z1, double Rad, double StartAng, double EndAng)
	{
		CenterPoint = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = Z1
		};
		Radius = Rad;
		StartAngle = StartAng;
		EndAngle = EndAng;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, StartAngle, EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, StartAngle, EndAngle, count, Plane, ref Vertice);
	}

	public geoArc(Pnt3D Center, double Rad, double StartAng, double EndAng)
	{
		Pnt3D pnt3D = new Pnt3D();
		pnt3D = Center;
		CenterPoint = pnt3D;
		Radius = Rad;
		StartAngle = StartAng;
		EndAngle = EndAng;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, StartAngle, EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, StartAngle, EndAngle, count, Plane, ref Vertice);
	}

	public geoArc(Pnt3D Center, double Rad, double StartAng, double EndAng, WorkPlane Plane)
	{
		Pnt3D pnt3D = new Pnt3D();
		pnt3D = Center;
		CenterPoint = pnt3D;
		Radius = Rad;
		StartAngle = StartAng;
		EndAngle = EndAng;
		base.Plane = new WorkPlane(Plane);
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, StartAngle, EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, StartAngle, EndAngle, count, base.Plane, ref Vertice);
	}

	public geoArc(Pnt3D Center, double Rad, double StartAng, double EndAng, WorkPlane Plane, Color color, double thickness)
	{
		Pnt3D pnt3D = new Pnt3D();
		pnt3D = Center;
		CenterPoint = pnt3D;
		Radius = Rad;
		StartAngle = StartAng;
		EndAngle = EndAng;
		Color = color;
		Thickness = thickness;
		base.Plane = new WorkPlane(Plane);
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, StartAngle, EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, StartAngle, EndAngle, count, base.Plane, ref Vertice);
	}

	public geoArc(Pnt3D Center, double Rad, double StartAng, double EndAng, WorkPlane Plane, int Layer)
	{
		Pnt3D pnt3D = new Pnt3D();
		pnt3D = Center;
		CenterPoint = pnt3D;
		Radius = Rad;
		StartAngle = StartAng;
		EndAngle = EndAng;
		base.Layer = Layer;
		base.Plane = new WorkPlane(Plane);
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, StartAngle, EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, StartAngle, EndAngle, count, base.Plane, ref Vertice);
	}

	public geoArc(PointF Center, double Rad, double StartAng, double EndAng)
	{
		CenterPoint = new Pnt3D
		{
			X = Center.X,
			Y = Center.Y,
			Z = 0.0
		};
		Radius = Rad;
		StartAngle = StartAng;
		EndAngle = EndAng;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, StartAngle, EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, StartAngle, EndAngle, count, Plane, ref Vertice);
	}

	public geoArc(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint, WorkPlane Plane)
	{
		Pnt3D Center = new Pnt3D();
		double StartAngle = 0.0;
		double EndAngle = 0.0;
		double Radius = 0.0;
		List<Pnt3D> Vertices = new List<Pnt3D>();
		buStatics.Arc3Point(FirstPoint, SecondPoint, ThirdPoint, Plane, ref Center, ref Radius, ref StartAngle, ref EndAngle, ref Vertices);
		CenterPoint = new Pnt3D(Center);
		this.Radius = Radius;
		this.StartAngle = StartAngle;
		this.EndAngle = EndAngle;
		base.Plane = new WorkPlane(Plane);
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, this.Radius, this.StartAngle, this.EndAngle, count, base.Plane, ref Vertice);
	}

	public override string ToString()
	{
		return "Arc - Center : " + CenterPoint.ToString() + " , Rad : " + Radius + " , SA : " + StartAngle + " , EA : " + EndAngle + " , Reverse : " + Reverse;
	}
}
