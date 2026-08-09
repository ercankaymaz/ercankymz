using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Xbim.Common.Geometry;

public class XbimRegionCollection : List<XbimRegion>, IXbimShapeGeometryData
{
	public int ContextLabel;

	private const int CoordSize = 128;

	private const int Version = -2;

	int IXbimShapeGeometryData.ShapeLabel { get; set; }

	int IXbimShapeGeometryData.IfcShapeLabel
	{
		get
		{
			return ContextLabel;
		}
		set
		{
			ContextLabel = value;
		}
	}

	int IXbimShapeGeometryData.GeometryHash
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	int IXbimShapeGeometryData.Cost => -1;

	int IXbimShapeGeometryData.ReferenceCount
	{
		get
		{
			return -1;
		}
		set
		{
		}
	}

	byte IXbimShapeGeometryData.LOD
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	byte IXbimShapeGeometryData.Format
	{
		get
		{
			return 4;
		}
		set
		{
		}
	}

	byte[] IXbimShapeGeometryData.BoundingBox
	{
		get
		{
			return XbimRect3D.Empty.ToFloatArray();
		}
		set
		{
		}
	}

	byte[] IXbimShapeGeometryData.ShapeDataCompressed
	{
		get
		{
			using MemoryStream memoryStream = new MemoryStream(ToArray());
			using MemoryStream memoryStream2 = new MemoryStream();
			using (GZipStream destination = new GZipStream(memoryStream2, CompressionMode.Compress))
			{
				memoryStream.CopyTo(destination);
			}
			return memoryStream2.ToArray();
		}
		set
		{
			using MemoryStream stream = new MemoryStream(value);
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
			{
				gZipStream.CopyTo(memoryStream);
			}
			FillFromArray(memoryStream.ToArray());
		}
	}

	byte[] IXbimShapeGeometryData.ShapeData
	{
		get
		{
			return ToArray();
		}
		set
		{
			FillFromArray(value);
		}
	}

	IVector3D IXbimShapeGeometryData.LocalShapeDisplacement => null;

	public new byte[] ToArray()
	{
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(-2);
		binaryWriter.Write(base.Count);
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				XbimRegion current = enumerator.Current;
				binaryWriter.Write(current.Name);
				binaryWriter.Write(current.Population);
				binaryWriter.Write((float)current.Centre.X);
				binaryWriter.Write((float)current.Centre.Y);
				binaryWriter.Write((float)current.Centre.Z);
				binaryWriter.Write((float)current.Size.X);
				binaryWriter.Write((float)current.Size.Y);
				binaryWriter.Write((float)current.Size.Z);
				binaryWriter.Write(current.WorldCoordinateSystem.ToArray());
			}
		}
		return memoryStream.ToArray();
	}

	public static XbimRegionCollection FromArray(byte[] bytes)
	{
		XbimRegionCollection xbimRegionCollection = new XbimRegionCollection();
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));
		bool flag = true;
		int num = binaryReader.ReadInt32();
		int num2 = 0;
		if (num < 0)
		{
			num2 = binaryReader.ReadInt32();
			flag = false;
		}
		else
		{
			num2 = num;
		}
		for (int i = 0; i < num2; i++)
		{
			XbimRegion xbimRegion = new XbimRegion
			{
				Name = binaryReader.ReadString(),
				Population = binaryReader.ReadInt32()
			};
			float num3 = binaryReader.ReadSingle();
			float num4 = binaryReader.ReadSingle();
			float num5 = binaryReader.ReadSingle();
			xbimRegion.Centre = new XbimPoint3D(num3, num4, num5);
			num3 = binaryReader.ReadSingle();
			num4 = binaryReader.ReadSingle();
			num5 = binaryReader.ReadSingle();
			xbimRegion.Size = new XbimVector3D(num3, num4, num5);
			if (!flag)
			{
				xbimRegion.WorldCoordinateSystem = XbimMatrix3D.FromArray(binaryReader.ReadBytes(128));
				xbimRegion.version = num;
			}
			else
			{
				xbimRegion.version = 0;
			}
			xbimRegionCollection.Add(xbimRegion);
		}
		return xbimRegionCollection;
	}

	private void FillFromArray(byte[] bytes)
	{
		Clear();
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));
		bool flag = true;
		int num = binaryReader.ReadInt32();
		int num2 = 0;
		if (num < 0)
		{
			num2 = binaryReader.ReadInt32();
			flag = false;
		}
		else
		{
			num2 = num;
		}
		for (int i = 0; i < num2; i++)
		{
			XbimRegion xbimRegion = new XbimRegion
			{
				Name = binaryReader.ReadString(),
				Population = binaryReader.ReadInt32()
			};
			float num3 = binaryReader.ReadSingle();
			float num4 = binaryReader.ReadSingle();
			float num5 = binaryReader.ReadSingle();
			xbimRegion.Centre = new XbimPoint3D(num3, num4, num5);
			num3 = binaryReader.ReadSingle();
			num4 = binaryReader.ReadSingle();
			num5 = binaryReader.ReadSingle();
			if (!flag)
			{
				xbimRegion.WorldCoordinateSystem = XbimMatrix3D.FromArray(binaryReader.ReadBytes(128));
				xbimRegion.version = num;
			}
			else
			{
				xbimRegion.version = 0;
			}
			xbimRegion.Size = new XbimVector3D(num3, num4, num5);
			Add(xbimRegion);
		}
	}

	public XbimRegion MostPopulated()
	{
		int num = -1;
		XbimRegion result = null;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			XbimRegion current = enumerator.Current;
			if (current.Population == -1)
			{
				return current;
			}
			if (current.Population > num)
			{
				result = current;
				num = current.Population;
			}
		}
		return result;
	}

	public XbimRegion Largest()
	{
		double num = 0.0;
		XbimRegion result = null;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			XbimRegion current = enumerator.Current;
			if (current.Diagonal() > num)
			{
				result = current;
				num = current.Diagonal();
			}
		}
		return result;
	}
}
