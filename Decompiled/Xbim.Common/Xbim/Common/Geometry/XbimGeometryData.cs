using System;
using System.IO;
using System.Linq;
using Xbim.Common.XbimExtensions;

namespace Xbim.Common.Geometry;

public class XbimGeometryData
{
	public readonly int GeometryLabel;

	public readonly int IfcProductLabel;

	public readonly XbimGeometryType GeometryType;

	public readonly byte[] ShapeData;

	public readonly byte[] DataArray2;

	public readonly int GeometryHash;

	public readonly short IfcTypeId;

	public readonly int StyleLabel;

	public readonly int Counter;

	public XbimShapeTriangulation TriangulatedFaceSet()
	{
		using MemoryStream input = new MemoryStream(ShapeData);
		using BinaryReader br = new BinaryReader(input);
		return br.ReadShapeTriangulation();
	}

	public XbimGeometryData(int geometrylabel, int productLabel, XbimGeometryType geomType, short ifcTypeId, byte[] shape, byte[] dataArray2, int geometryHash, int styleLabel, int counter)
	{
		GeometryLabel = geometrylabel;
		GeometryType = geomType;
		IfcTypeId = ifcTypeId;
		ShapeData = shape;
		IfcProductLabel = productLabel;
		GeometryHash = geometryHash;
		StyleLabel = styleLabel;
		DataArray2 = dataArray2;
		Counter = counter;
	}

	[Obsolete("This method should not be used and is marked for deletion", false)]
	public XbimGeometryData TransformBy(XbimMatrix3D matrix)
	{
		XbimMatrix3D mat = XbimMatrix3D.FromArray(DataArray2);
		mat = XbimMatrix3D.Multiply(mat, matrix);
		return new XbimGeometryData(GeometryLabel, IfcProductLabel, GeometryType, IfcTypeId, ShapeData, mat.ToArray(), GeometryHash, StyleLabel, Counter);
	}

	public XbimGeometryData(int geometrylabel, int productLabel, XbimGeometryType geomType, short ifcTypeId, byte[] shape, byte[] transform, int styleLabel)
	{
		GeometryLabel = geometrylabel;
		GeometryType = geomType;
		IfcTypeId = ifcTypeId;
		ShapeData = shape;
		DataArray2 = transform;
		IfcProductLabel = productLabel;
		GeometryHash = GenerateGeometryHash(ShapeData);
		StyleLabel = styleLabel;
	}

	public bool IsGeometryEqual(XbimGeometryData to)
	{
		return Enumerable.SequenceEqual(ShapeData, to.ShapeData);
	}

	public static int GenerateGeometryHash(byte[] array)
	{
		int num = array.Aggregate(-2128831035, (int current, byte t) => (current ^ t) * 16777619);
		int num2 = num + (num << 13);
		int num3 = num2 ^ (num2 >> 7);
		int num4 = num3 + (num3 << 3);
		int num5 = num4 ^ (num4 >> 17);
		return num5 + (num5 << 5);
	}
}
