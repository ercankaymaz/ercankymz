using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoEllipse : geoEntity
{
	public Pnt3D CenterPoint = new Pnt3D();

	public double MajorRadius = 0.0;

	public double MinorRadius = 0.0;

	public double Angle = 0.0;

	public geoEllipse()
	{
	}

	public geoEllipse(geoEllipse ellipse)
	{
		CenterPoint = new Pnt3D(ellipse.CenterPoint);
		MajorRadius = ellipse.MajorRadius;
		MinorRadius = ellipse.MinorRadius;
		Angle = ellipse.Angle;
		Layer = ellipse.Layer;
		Mode = ellipse.Mode;
		ToolNo = ellipse.ToolNo;
		Tag = ellipse.Tag;
		Color = ellipse.Color;
		Index = ellipse.Index;
		Thickness = ellipse.Thickness;
		Direction = ellipse.Direction;
		Vertice.Clear();
		int count = buStatics.EllipseVerticeCountByResolution(MajorRadius, MinorRadius, buSystem.EntitiesResolution);
		buStatics.EllipseToLineerByCount(CenterPoint, MajorRadius, MinorRadius, Angle, count, Plane, ref Vertice);
		TypeDefination = ellipse.TypeDefination;
		isText = ellipse.isText;
	}

	public geoEllipse(double X1, double Y1, double MajorRadius, double MinorRadius, double Angle)
	{
		CenterPoint = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = 0.0
		};
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		Vertice.Clear();
		int count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
		buStatics.EllipseToLineerByCount(CenterPoint, this.MajorRadius, this.MinorRadius, Angle, count, Plane, ref Vertice);
	}

	public geoEllipse(double X1, double Y1, double Z1, double MajorRadius, double MinorRadius, double Angle)
	{
		CenterPoint = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = Z1
		};
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		Vertice.Clear();
		int count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
		buStatics.EllipseToLineerByCount(CenterPoint, this.MajorRadius, this.MinorRadius, Angle, count, Plane, ref Vertice);
	}

	public geoEllipse(Pnt3D Center, double MajorRadius, double MinorRadius, double Angle)
	{
		Pnt3D pnt3D = new Pnt3D();
		pnt3D = Center;
		CenterPoint = pnt3D;
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		Vertice.Clear();
		int count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
		buStatics.EllipseToLineerByCount(CenterPoint, this.MajorRadius, this.MinorRadius, Angle, count, Plane, ref Vertice);
	}

	public geoEllipse(Pnt3D Center, double MajorRadius, double MinorRadius, double Angle, WorkPlane Plane)
	{
		CenterPoint = new Pnt3D(Center);
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		base.Plane = new WorkPlane(Plane);
		Vertice.Clear();
		int count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
		buStatics.EllipseToLineerByCount(CenterPoint, this.MajorRadius, this.MinorRadius, Angle, count, base.Plane, ref Vertice);
	}

	public geoEllipse(Pnt3D Center, double MajorRadius, double MinorRadius, double Angle, WorkPlane Plane, int layer)
	{
		CenterPoint = new Pnt3D(Center);
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		base.Plane = new WorkPlane(Plane);
		Layer = layer;
		Vertice.Clear();
		int count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
		buStatics.EllipseToLineerByCount(CenterPoint, this.MajorRadius, this.MinorRadius, Angle, count, base.Plane, ref Vertice);
	}

	public geoEllipse(Pnt3D Center, double MajorRadius, double MinorRadius, double Angle, WorkPlane Plane, Color color, double thickness)
	{
		CenterPoint = new Pnt3D(Center);
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		Thickness = thickness;
		Color = color;
		base.Plane = new WorkPlane(Plane);
		Vertice.Clear();
		int count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
		buStatics.EllipseToLineerByCount(CenterPoint, this.MajorRadius, this.MinorRadius, Angle, count, base.Plane, ref Vertice);
	}

	public geoEllipse(PointF Center, double MajorRadius, double MinorRadius, double Angle)
	{
		CenterPoint = new Pnt3D
		{
			X = Center.X,
			Y = Center.Y,
			Z = 0.0
		};
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		Vertice.Clear();
		int count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
		buStatics.EllipseToLineerByCount(CenterPoint, this.MajorRadius, this.MinorRadius, Angle, count, Plane, ref Vertice);
	}

	public override string ToString()
	{
		return "Ellipse - Center : " + CenterPoint.ToString() + " , Maj Rad : " + MajorRadius + " , Min Rad : " + MinorRadius + " , Angle : " + Angle;
	}
}
