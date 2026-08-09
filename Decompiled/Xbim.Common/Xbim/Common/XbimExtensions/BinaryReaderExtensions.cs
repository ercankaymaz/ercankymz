using System;
using System.Collections.Generic;
using System.IO;
using Xbim.Common.Geometry;

namespace Xbim.Common.XbimExtensions;

public static class BinaryReaderExtensions
{
	public static XbimShapeTriangulation ReadShapeTriangulation(this BinaryReader br)
	{
		byte version = br.ReadByte();
		int num = br.ReadInt32();
		br.ReadInt32();
		List<XbimPoint3D> list = new List<XbimPoint3D>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(br.ReadPointFloat3D());
		}
		int num2 = br.ReadInt32();
		List<XbimFaceTriangulation> list2 = new List<XbimFaceTriangulation>(num2);
		for (int j = 0; j < num2; j++)
		{
			int num3 = br.ReadInt32();
			if (num3 == 0)
			{
				continue;
			}
			bool num4 = num3 > 0;
			num3 = Math.Abs(num3);
			if (num4)
			{
				XbimFaceTriangulation xbimFaceTriangulation = new XbimFaceTriangulation(num3, 1);
				xbimFaceTriangulation.AddNormal(br.ReadPackedNormal());
				for (int k = 0; k < num3; k++)
				{
					xbimFaceTriangulation.AddIndex(br.ReadIndex(num));
					xbimFaceTriangulation.AddIndex(br.ReadIndex(num));
					xbimFaceTriangulation.AddIndex(br.ReadIndex(num));
				}
				list2.Add(xbimFaceTriangulation);
				continue;
			}
			XbimFaceTriangulation xbimFaceTriangulation2 = new XbimFaceTriangulation(num3, num3 * 3);
			for (int l = 0; l < num3; l++)
			{
				xbimFaceTriangulation2.AddIndex(br.ReadIndex(num));
				xbimFaceTriangulation2.AddNormal(br.ReadPackedNormal());
				xbimFaceTriangulation2.AddIndex(br.ReadIndex(num));
				xbimFaceTriangulation2.AddNormal(br.ReadPackedNormal());
				xbimFaceTriangulation2.AddIndex(br.ReadIndex(num));
				xbimFaceTriangulation2.AddNormal(br.ReadPackedNormal());
			}
			list2.Add(xbimFaceTriangulation2);
		}
		return new XbimShapeTriangulation(list, list2, version);
	}

	private static int ReadIndex(this BinaryReader br, int maxVertexCount)
	{
		if (maxVertexCount <= 255)
		{
			return br.ReadByte();
		}
		if (maxVertexCount <= 65535)
		{
			return br.ReadUInt16();
		}
		return (int)br.ReadUInt32();
	}

	public static XbimPoint3D ReadPointFloat3D(this BinaryReader br)
	{
		double x = br.ReadSingle();
		double y = br.ReadSingle();
		double z = br.ReadSingle();
		return new XbimPoint3D(x, y, z);
	}

	public static XbimPackedNormal ReadPackedNormal(this BinaryReader br)
	{
		byte u = br.ReadByte();
		byte v = br.ReadByte();
		return new XbimPackedNormal(u, v);
	}
}
