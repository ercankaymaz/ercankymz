using System;
using System.IO;
using ModuleWorks.Util;

namespace ModuleWorks;

[Serializable]
[Obsolete("Deprecated since Release 2018.04.")]
public class RenderedMeshData
{
	public FastList<float> TriangleVertices { get; set; }

	[CLSCompliant(false)]
	public FastList<uint> TriangleIndices { get; set; }

	public FastList<float> LineVertices { get; set; }

	public BoundingBoxf BoundingBox { get; set; }

	public int LineVertexCount => LineVertices.Count / 3;

	public int TriangleCount => TriangleIndices.Count / 3;

	public RenderedMeshData()
	{
		TriangleVertices = new FastList<float>();
		TriangleIndices = new FastList<uint>();
		LineVertices = new FastList<float>();
	}

	public void UpdateBoundingBox()
	{
		BoundingBoxf boundingBoxf = new BoundingBoxf(Vectorf.Max, Vectorf.Min);
		for (int i = 0; i < TriangleVertices.Count; i += 3)
		{
			float num = TriangleVertices[i];
			float num2 = TriangleVertices[i + 1];
			float num3 = TriangleVertices[i + 2];
			if (num < boundingBoxf.LowerLeft.X)
			{
				boundingBoxf.LowerLeft.X = num;
			}
			if (num > boundingBoxf.UpperRight.X)
			{
				boundingBoxf.UpperRight.X = num;
			}
			if (num2 < boundingBoxf.LowerLeft.Y)
			{
				boundingBoxf.LowerLeft.Y = num2;
			}
			if (num2 > boundingBoxf.UpperRight.Y)
			{
				boundingBoxf.UpperRight.Y = num2;
			}
			if (num3 < boundingBoxf.LowerLeft.Z)
			{
				boundingBoxf.LowerLeft.Z = num3;
			}
			if (num3 > boundingBoxf.UpperRight.Z)
			{
				boundingBoxf.UpperRight.Z = num3;
			}
		}
		for (int j = 0; j < LineVertices.Count; j += 3)
		{
			float num4 = LineVertices[j];
			float num5 = LineVertices[j + 1];
			float num6 = LineVertices[j + 2];
			if (num4 < boundingBoxf.LowerLeft.X)
			{
				boundingBoxf.LowerLeft.X = num4;
			}
			if (num4 > boundingBoxf.UpperRight.X)
			{
				boundingBoxf.UpperRight.X = num4;
			}
			if (num5 < boundingBoxf.LowerLeft.Y)
			{
				boundingBoxf.LowerLeft.Y = num5;
			}
			if (num5 > boundingBoxf.UpperRight.Y)
			{
				boundingBoxf.UpperRight.Y = num5;
			}
			if (num6 < boundingBoxf.LowerLeft.Z)
			{
				boundingBoxf.LowerLeft.Z = num6;
			}
			if (num6 > boundingBoxf.UpperRight.Z)
			{
				boundingBoxf.UpperRight.Z = num6;
			}
		}
		BoundingBox = boundingBoxf;
	}

	public void Serialize(Stream stream)
	{
		using BinaryWriter writer = new BinaryWriter(stream);
		Serialize(writer);
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(TriangleIndices.Count);
		writer.Write(TriangleVertices.Count);
		writer.Write(LineVertices.Count);
		foreach (uint triangleIndex in TriangleIndices)
		{
			writer.Write(triangleIndex);
		}
		foreach (float triangleVertex in TriangleVertices)
		{
			writer.Write(triangleVertex);
		}
		foreach (float lineVertex in LineVertices)
		{
			writer.Write(lineVertex);
		}
	}

	public void Deserialize(Stream stream)
	{
		using BinaryReader reader = new BinaryReader(stream);
		Deserialize(reader);
	}

	public void Deserialize(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		int num2 = reader.ReadInt32();
		int num3 = reader.ReadInt32();
		TriangleIndices = new FastList<uint>(num);
		TriangleVertices = new FastList<float>(num2);
		LineVertices = new FastList<float>(num3);
		for (int i = 0; i < num; i++)
		{
			uint element = reader.ReadUInt32();
			TriangleIndices.Add(element);
		}
		for (int j = 0; j < num2; j++)
		{
			float element2 = reader.ReadSingle();
			TriangleVertices.Add(element2);
		}
		for (int k = 0; k < num3; k++)
		{
			float element3 = reader.ReadSingle();
			LineVertices.Add(element3);
		}
		UpdateBoundingBox();
	}
}
