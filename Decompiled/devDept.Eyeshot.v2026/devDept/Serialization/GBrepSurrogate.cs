using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

internal class GBrepSurrogate : GEntitySurrogate
{
	public Point3D[] Vertices;

	public Brep.Edge[] Edges;

	public Brep.Face[] Faces;

	public List<ProtoJaggedArray<Brep.Face>> Inners;

	public double RebuildTolerance;

	public GBrepSurrogate(GBrep brep)
		: base(brep)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GBrep gBrep = new GBrep();
		CopyDataToObject(gBrep);
		return gBrep;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		GBrep gBrep = (GBrep)entity;
		if (Inners != null)
		{
			gBrep.Inners = Inners.ToJaggedArray();
		}
		gBrep.Vertices = Vertices ?? Array.Empty<Point3D>();
		gBrep.Edges = Edges ?? Array.Empty<Brep.Edge>();
		gBrep.Faces = Faces ?? Array.Empty<Brep.Face>();
		gBrep.RebuildTolerance = RebuildTolerance;
		base.CopyDataToObject(entity);
	}
}
