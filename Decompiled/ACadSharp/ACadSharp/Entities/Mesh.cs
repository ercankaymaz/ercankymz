using System.Collections.Generic;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("MESH")]
[DxfSubClass("AcDbSubDMesh")]
public class Mesh : Entity
{
	public struct Edge
	{
		public int Start { get; set; }

		public int End { get; set; }

		public double? Crease { get; set; }

		public Edge(int start, int end)
		{
			Crease = null;
			Start = start;
			End = end;
		}

		public override string ToString()
		{
			string result = $"{Start}|{End}";
			if (!Crease.HasValue)
			{
				return result;
			}
			return $"{Start}|{End}|{Crease}";
		}
	}

	[DxfCodeValue(new int[] { 72 })]
	public bool BlendCrease { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 94 })]
	[DxfCollectionCodeValue(new int[] { 90 })]
	public List<Edge> Edges { get; private set; } = new List<Edge>();

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 93 })]
	[DxfCollectionCodeValue(new int[] { 90 })]
	public List<int[]> Faces { get; private set; } = new List<int[]>();

	public override string ObjectName => "MESH";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker => "AcDbSubDMesh";

	[DxfCodeValue(new int[] { 91 })]
	public int SubdivisionLevel { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public short Version { get; internal set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 92 })]
	[DxfCollectionCodeValue(new int[] { 10, 20, 30 })]
	public List<XYZ> Vertices { get; private set; } = new List<XYZ>();

	public override void ApplyTransform(Transform transform)
	{
		for (int i = 0; i < Vertices.Count; i++)
		{
			Vertices[i] = transform.ApplyTransform(Vertices[i]);
		}
	}

	public override CadObject Clone()
	{
		Mesh obj = (Mesh)base.Clone();
		obj.Edges = new List<Edge>(Edges);
		obj.Vertices = new List<XYZ>(Vertices);
		obj.Faces = new List<int[]>(Faces);
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.FromPoints(Vertices);
	}
}
