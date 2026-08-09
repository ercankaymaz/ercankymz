using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoCircle : geoEntity
{
	public Pnt3D CenterPoint = new Pnt3D();

	public double Radius = 0.0;

	public geoCircle()
	{
	}

	public geoCircle(geoCircle circle)
	{
		CenterPoint = new Pnt3D(circle.CenterPoint);
		Radius = circle.Radius;
		Layer = circle.Layer;
		Mode = circle.Mode;
		ToolNo = circle.ToolNo;
		Tag = circle.Tag;
		Color = circle.Color;
		Index = circle.Index;
		Thickness = circle.Thickness;
		Direction = circle.Direction;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(Radius, 0.0, 360.0, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, Radius, 0.0, 360.0, count, Plane, ref Vertice);
		TypeDefination = circle.TypeDefination;
		isText = circle.isText;
	}

	public geoCircle(double X1, double Y1, double Radius)
	{
		CenterPoint = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = 0.0
		};
		this.Radius = Radius;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, this.Radius, 0.0, 360.0, count, Plane, ref Vertice);
	}

	public geoCircle(double X1, double Y1, double Z1, double Radius)
	{
		CenterPoint = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = Z1
		};
		this.Radius = Radius;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, this.Radius, 0.0, 360.0, count, Plane, ref Vertice);
	}

	public geoCircle(Pnt3D Center, double Radius)
	{
		Pnt3D pnt3D = new Pnt3D();
		pnt3D = Center;
		CenterPoint = pnt3D;
		this.Radius = Radius;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, this.Radius, 0.0, 360.0, count, Plane, ref Vertice);
	}

	public geoCircle(Pnt3D Center, double Radius, WorkPlane Plane)
	{
		CenterPoint = new Pnt3D(Center);
		this.Radius = Radius;
		base.Plane = new WorkPlane(Plane);
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, this.Radius, 0.0, 360.0, count, base.Plane, ref Vertice);
	}

	public geoCircle(Pnt3D Center, double Radius, WorkPlane Plane, int layer)
	{
		CenterPoint = new Pnt3D(Center);
		this.Radius = Radius;
		base.Plane = new WorkPlane(Plane);
		Layer = layer;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, this.Radius, 0.0, 360.0, count, base.Plane, ref Vertice);
	}

	public geoCircle(Pnt3D Center, double Radius, WorkPlane Plane, Color color, double thickness)
	{
		CenterPoint = new Pnt3D(Center);
		this.Radius = Radius;
		Thickness = thickness;
		Color = color;
		base.Plane = new WorkPlane(Plane);
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, this.Radius, 0.0, 360.0, count, base.Plane, ref Vertice);
	}

	public geoCircle(PointF Center, double Radius)
	{
		CenterPoint = new Pnt3D
		{
			X = Center.X,
			Y = Center.Y,
			Z = 0.0
		};
		this.Radius = Radius;
		Vertice.Clear();
		int count = buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution);
		buStatics.ArcToLineerByCount(CenterPoint, this.Radius, 0.0, 360.0, count, Plane, ref Vertice);
	}

	public override string ToString()
	{
		return "Circle - Center : " + CenterPoint.ToString() + " , Rad : " + Radius;
	}
}
