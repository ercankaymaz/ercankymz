using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class CoordinateCatch : buSerilization
{
	public bool Found = false;

	public bool SnapFound = false;

	public bool OrthoFound = false;

	public bool OsnapFound = false;

	public bool TrackFound = false;

	public bool OverFound = false;

	public Pnt3D Point = new Pnt3D();

	public osnapType Type = osnapType.None;

	public osnapMethodType Method = osnapMethodType.None;

	public eEntities DrawEntity = new eEntities();

	public eEntities DrawEntity2 = new eEntities();

	public List<eEntities> HostEntities = new List<eEntities>();

	public int HostEntityIndex = -1;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Depth = 0.0;

	public double Thickness = 2.0;

	public Color Color = Color.Lime;

	public List<Pnt3D> CatchBasePoints = new List<Pnt3D>();

	public Pnt3D EntityPoint = new Pnt3D();

	public CoordinateCatch()
	{
	}

	public CoordinateCatch(CoordinateCatch Catch)
	{
		HostEntityIndex = Catch.HostEntityIndex;
		Found = Catch.Found;
		Point = new Pnt3D(Catch.Point);
		Type = Catch.Type;
		Width = Catch.Width;
		Height = Catch.Height;
		Depth = Catch.Depth;
		Method = Catch.Method;
		Thickness = Catch.Thickness;
		Color = Catch.Color;
		eEntities copiedEnt = new eEntities();
		eEntities.CopyEntity(Catch.DrawEntity, ref copiedEnt);
		DrawEntity = copiedEnt;
		eEntities copiedEnt2 = new eEntities();
		eEntities.CopyEntity(Catch.DrawEntity2, ref copiedEnt2);
		DrawEntity2 = copiedEnt2;
		HostEntities = new List<eEntities>();
		eEntities.CopyEntities(Catch.HostEntities, ref HostEntities);
	}
}
