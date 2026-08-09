using System;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GMesh : GEntity
{
	public Mesh.natureType MeshNature;

	public Mesh.edgeStyleType EdgeStyle;

	public Point3D[] Vertices;

	public IndexTriangle[] Triangles;

	public PointF[] TextureCoords;

	public Vector3D[] Normals;

	public IndexLine[] Edges;

	public double SmoothingAngle;

	public bool LightWeight;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GMeshSurrogate(this);
	}
}
