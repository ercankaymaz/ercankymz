using System;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Serialization;

public class FemMeshSurrogate : EntitySurrogate
{
	public Color ElementEdgeColor;

	public IndexTriangle[] BoundaryMeshTriangles;

	public IndexLine[] BoundaryMeshEdges;

	public Point3D[] Vertices;

	public Element[] Elements;

	public ProtoArray<int> IsoEdges;

	public Mesh BoundaryMesh;

	internal double skinMinEdgeLen;

	internal int[] boundaryNodes;

	public FemMeshSurrogate(FemMesh femMesh)
		: base(femMesh)
	{
	}

	protected override Entity ConvertToObject()
	{
		FemMesh femMesh = new FemMesh(this);
		CopyDataToObject(femMesh);
		return femMesh;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		FemMesh femMesh = entity as FemMesh;
		if (base.Content != contentType.Geometry)
		{
			if (base.Version < 13)
			{
				femMesh.skin = null;
			}
			else if (BoundaryMesh != null)
			{
				if (BoundaryMesh.Vertices == null)
				{
					BoundaryMesh._vertices = Array.Empty<Point3D>();
				}
				if (BoundaryMesh.Triangles == null)
				{
					BoundaryMesh.Triangles = Array.Empty<IndexTriangle>();
					BoundaryMesh._edges = Array.Empty<IndexLine>();
					BoundaryMesh.entityNature = entityNatureType.None;
				}
				femMesh.skin = BoundaryMesh;
			}
			femMesh.minEdgeLen = skinMinEdgeLen;
			femMesh.boundaryNodes = boundaryNodes;
			if (IsoEdges != null)
			{
				femMesh.isoEdges = IsoEdges.ToArray() as int[,];
			}
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		FemMesh femMesh = (FemMesh)entity;
		Vertices = femMesh.Vertices;
		Elements = femMesh.Elements;
		if (femMesh.BoundaryMesh != null)
		{
			BoundaryMesh = femMesh.BoundaryMesh;
			skinMinEdgeLen = femMesh.minEdgeLen;
			boundaryNodes = femMesh.boundaryNodes;
		}
		if (femMesh.isoEdges != null)
		{
			IsoEdges = femMesh.isoEdges.ToProtoArray<int>();
		}
		base.CopyDataFromObject(entity);
	}
}
