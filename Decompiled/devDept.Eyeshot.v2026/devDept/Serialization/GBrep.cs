using System;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GBrep : GEntity
{
	public Point3D[] Vertices;

	public Brep.Edge[] Edges;

	public Brep.Face[] Faces;

	public Brep.Face[][] Inners;

	public double RebuildTolerance;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GBrepSurrogate(this);
	}
}
