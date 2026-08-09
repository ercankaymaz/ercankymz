using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Xbim.Common.Geometry;

public class XbimShapeTriangulation : IXbimTriangulatedFaceSet
{
	private struct PointAndNormal(int index, XbimPackedNormal n)
	{
		internal readonly int Index = index;

		internal XbimPackedNormal Normal = n;
	}

	private readonly List<XbimPoint3D> _vertices;

	private readonly List<XbimFaceTriangulation> _faces;

	private readonly byte _version;

	public IList<XbimPoint3D> Vertices => _vertices;

	public IList<XbimFaceTriangulation> Faces => _faces;

	public byte Version => _version;

	public XbimShapeTriangulation(List<XbimPoint3D> vertices, List<XbimFaceTriangulation> faces, byte version)
	{
		_vertices = vertices;
		_faces = faces;
		_version = version;
	}

	public static int TriangleCount(byte[] triangulationData)
	{
		return BitConverter.ToInt32(triangulationData, 5);
	}

	public static int VerticesCount(byte[] triangulationData)
	{
		return BitConverter.ToInt32(triangulationData, 1);
	}

	public XbimShapeTriangulation Transform(XbimMatrix3D matrix3D)
	{
		List<XbimPoint3D> vertices = _vertices.Select(((XbimMatrix3D)matrix3D).Transform).ToList();
		List<XbimFaceTriangulation> list = new List<XbimFaceTriangulation>(_faces.Count);
		XbimQuaternion q = matrix3D.GetRotationQuaternion();
		list.AddRange(_faces.Select((XbimFaceTriangulation face) => face.Transform(q)));
		return new XbimShapeTriangulation(vertices, list, _version);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(_version);
		bw.Write(_vertices.Count);
		bw.Write(_faces.Sum((XbimFaceTriangulation face) => face.TriangleCount));
		foreach (XbimPoint3D vertex in _vertices)
		{
			bw.Write((float)vertex.X);
			bw.Write((float)vertex.Y);
			bw.Write((float)vertex.Z);
		}
		bw.Write(_faces.Count);
		foreach (XbimFaceTriangulation face in _faces)
		{
			if (face.IsPlanar)
			{
				bw.Write(face.TriangleCount);
				face.Normals[0].Write(bw);
				face.WriteIndices(bw, _vertices.Count);
			}
			else
			{
				bw.Write(-face.TriangleCount);
				face.WriteIndicesAndNormals(bw, _vertices.Count);
			}
		}
	}

	public void ToPointsWithNormalsAndIndices(out List<float[]> positions, out List<int> indices)
	{
		Dictionary<PointAndNormal, int> dictionary = new Dictionary<PointAndNormal, int>();
		indices = new List<int>();
		foreach (XbimFaceTriangulation face in Faces)
		{
			if (face.IsPlanar)
			{
				XbimPackedNormal n = face.Normals[0];
				foreach (int index2 in face.Indices)
				{
					PointAndNormal key = new PointAndNormal(index2, n);
					if (!dictionary.TryGetValue(key, out var value))
					{
						value = dictionary.Count;
						dictionary.Add(key, value);
					}
					indices.Add(value);
				}
				continue;
			}
			for (int i = 0; i < face.Indices.Count; i++)
			{
				int index = face.Indices[i];
				XbimPackedNormal n2 = face.Normals[i];
				PointAndNormal key2 = new PointAndNormal(index, n2);
				if (!dictionary.TryGetValue(key2, out var value2))
				{
					value2 = dictionary.Count;
					dictionary.Add(key2, value2);
				}
				indices.Add(value2);
			}
		}
		positions = new List<float[]>(dictionary.Count);
		foreach (PointAndNormal key3 in dictionary.Keys)
		{
			float[] array = new float[6];
			XbimPoint3D xbimPoint3D = _vertices[key3.Index];
			array[0] = (float)xbimPoint3D.X;
			array[1] = (float)xbimPoint3D.Y;
			array[2] = (float)xbimPoint3D.Z;
			XbimPackedNormal normal = key3.Normal;
			XbimVector3D normal2 = normal.Normal;
			array[3] = (float)normal2.X;
			array[4] = (float)normal2.Y;
			array[5] = (float)normal2.Z;
			positions.Add(array);
		}
	}
}
