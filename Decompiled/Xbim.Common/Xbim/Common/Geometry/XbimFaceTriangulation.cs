using System.Collections.Generic;
using System.IO;

namespace Xbim.Common.Geometry;

public class XbimFaceTriangulation
{
	private readonly List<int> _indices;

	private readonly List<XbimPackedNormal> _normals;

	public bool IsPlanar => _normals.Count == 1;

	public int TriangleCount => _indices.Count / 3;

	public int NormalCount => _normals.Count;

	public IList<XbimPackedNormal> Normals => _normals;

	public IList<int> Indices => _indices;

	public XbimFaceTriangulation(int numTriangles, int numNormals)
	{
		_normals = new List<XbimPackedNormal>(numNormals);
		_indices = new List<int>(numTriangles * 3);
	}

	internal void AddNormal(XbimPackedNormal xbimPackedNormal)
	{
		_normals.Add(xbimPackedNormal);
	}

	internal void AddIndex(int p)
	{
		_indices.Add(p);
	}

	public void WriteIndices(BinaryWriter bw, int vertexCount)
	{
		if (vertexCount <= 255)
		{
			foreach (int index in _indices)
			{
				bw.Write((byte)index);
			}
			return;
		}
		if (vertexCount <= 65535)
		{
			foreach (int index2 in _indices)
			{
				bw.Write((ushort)index2);
			}
			return;
		}
		foreach (int index3 in _indices)
		{
			bw.Write(index3);
		}
	}

	public void WriteIndicesAndNormals(BinaryWriter bw, int vertexCount)
	{
		if (vertexCount <= 255)
		{
			for (int i = 0; i < _indices.Count; i++)
			{
				bw.Write((byte)_indices[i]);
				_normals[i].Write(bw);
			}
		}
		else if (vertexCount <= 65535)
		{
			for (int j = 0; j < _indices.Count; j++)
			{
				bw.Write((ushort)_indices[j]);
				_normals[j].Write(bw);
			}
		}
		else
		{
			for (int k = 0; k < _indices.Count; k++)
			{
				bw.Write(_indices[k]);
				_normals[k].Write(bw);
			}
		}
	}

	public XbimFaceTriangulation Transform(XbimQuaternion q)
	{
		XbimFaceTriangulation xbimFaceTriangulation = new XbimFaceTriangulation(_indices.Count, _normals.Count);
		foreach (XbimPackedNormal normal in _normals)
		{
			xbimFaceTriangulation.AddNormal(normal.Transform(q));
		}
		foreach (int index in _indices)
		{
			xbimFaceTriangulation.AddIndex(index);
		}
		return xbimFaceTriangulation;
	}
}
