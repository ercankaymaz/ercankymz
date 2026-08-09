using System.Collections.Generic;

namespace buClass;

public class eCurveEntities : eEntities
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public List<Pnt3D> ControlPoints = new List<Pnt3D>();

	public eCurveEntities()
	{
	}

	public eCurveEntities(eCurveEntities ent)
	{
		StartPoint = new Pnt3D(ent.StartPoint);
		EndPoint = new Pnt3D(ent.EndPoint);
		ControlPoints.Clear();
		Pnt3D.Copy(ent.ControlPoints, ref ControlPoints);
	}

	public static void CopyCurveBase(eEntities baseEnt, ref eEntities copiedEnt)
	{
		((eCurveEntities)copiedEnt).StartPoint = new Pnt3D(((eCurveEntities)baseEnt).StartPoint);
		((eCurveEntities)copiedEnt).EndPoint = new Pnt3D(((eCurveEntities)baseEnt).EndPoint);
		((eCurveEntities)copiedEnt).ControlPoints.Clear();
		Pnt3D.Copy(((eCurveEntities)baseEnt).ControlPoints, ref ((eCurveEntities)copiedEnt).ControlPoints);
	}
}
