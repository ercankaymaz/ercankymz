using System.Collections.Generic;
using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class ViewportDrawOptions
{
	public double Sing = 1.0;

	public ViewportRefType ViewportRef = ViewportRefType.Main;

	public ShapeGroup GroupType = ShapeGroup.Drill;

	public viewType SetView = viewType.Other;

	public bool DrawItems = true;

	public bool ZoomFit = false;

	public List<Entity> OtherEntities = null;

	public Point3D calcPoint = null;

	public Point3D refPoint = null;

	public int indexSelectdOP = -1;

	public int indexSelectdOPSub = -1;

	public ViewportDrawOptions()
	{
	}

	public ViewportDrawOptions(ViewportRefType viewportRef)
	{
		ViewportRef = viewportRef;
	}

	public ViewportDrawOptions(ViewportRefType viewportRef, int indexSelectdop, int indexSelectdopSub)
	{
		ViewportRef = viewportRef;
		indexSelectdOP = indexSelectdop;
		indexSelectdOPSub = indexSelectdopSub;
	}
}
