using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Xbim.Common.Geometry;

public class XbimShapeGeometry : IXbimShapeGeometryData
{
	private const int VersionPos = 0;

	private const int VertexCountPos = 1;

	private const int TriangleCountPos = 5;

	private const int VertexPos = 9;

	private int _shapeLabel;

	private int _ifcShapeLabel;

	private int _geometryHash;

	private int _referenceCount;

	private XbimGeometryType _format;

	private XbimRect3D _boundingBox;

	private byte[] _shapeData;

	public byte Version
	{
		get
		{
			byte[] shapeData = _shapeData;
			if (shapeData == null || shapeData.Length == 0)
			{
				return 0;
			}
			return _shapeData[0];
		}
	}

	public int VertexCount
	{
		get
		{
			byte[] shapeData = _shapeData;
			if (shapeData == null || shapeData.Length == 0)
			{
				return 0;
			}
			return BitConverter.ToInt32(_shapeData, 1);
		}
	}

	public int TriangleCount
	{
		get
		{
			byte[] shapeData = _shapeData;
			if (shapeData == null || shapeData.Length == 0)
			{
				return 0;
			}
			return BitConverter.ToInt32(_shapeData, 5);
		}
	}

	public int FaceCount
	{
		get
		{
			int startIndex = 9 + VertexCount * 3 * 4;
			byte[] shapeData = _shapeData;
			if (shapeData == null || shapeData.Length == 0)
			{
				return 0;
			}
			return BitConverter.ToInt32(_shapeData, startIndex);
		}
	}

	public int Length
	{
		get
		{
			byte[] shapeData = _shapeData;
			if (shapeData == null || shapeData.Length == 0)
			{
				return 0;
			}
			return _shapeData.Length;
		}
	}

	public IEnumerable<XbimPoint3D> Vertices
	{
		get
		{
			for (int i = 0; i < VertexCount; i++)
			{
				int num = 9 + i * 3 * 4;
				yield return new XbimPoint3D(BitConverter.ToSingle(_shapeData, num), BitConverter.ToSingle(_shapeData, num + 4), BitConverter.ToSingle(_shapeData, num + 8));
			}
		}
	}

	public XbimPoint3D this[int vectorIndex]
	{
		get
		{
			int num = 9 + vectorIndex * 3 * 4;
			return new XbimPoint3D(BitConverter.ToSingle(_shapeData, num), BitConverter.ToSingle(_shapeData, num + 4), BitConverter.ToSingle(_shapeData, num + 8));
		}
	}

	public IEnumerable<WexBimMeshFace> Faces
	{
		get
		{
			int faceOffset = 9 + VertexCount * 3 * 4 + 4;
			ReadIndex readIndex;
			int sizeofIndex;
			if (VertexCount <= 255)
			{
				readIndex = (byte[] array, int offset) => array[offset];
				sizeofIndex = 1;
			}
			else if (VertexCount <= 65535)
			{
				readIndex = (byte[] array, int offset) => BitConverter.ToUInt16(array, offset);
				sizeofIndex = 2;
			}
			else
			{
				readIndex = (byte[] array, int offset) => BitConverter.ToInt32(array, offset);
				sizeofIndex = 4;
			}
			for (int i = 0; i < FaceCount; i++)
			{
				WexBimMeshFace wexBimMeshFace = new WexBimMeshFace(readIndex, sizeofIndex, _shapeData, faceOffset);
				faceOffset += wexBimMeshFace.ByteSize;
				yield return wexBimMeshFace;
			}
		}
	}

	public int ShapeLabel
	{
		get
		{
			return _shapeLabel;
		}
		set
		{
			_shapeLabel = value;
		}
	}

	public int IfcShapeLabel
	{
		get
		{
			return _ifcShapeLabel;
		}
		set
		{
			_ifcShapeLabel = value;
		}
	}

	public int GeometryHash
	{
		get
		{
			return _geometryHash;
		}
		set
		{
			_geometryHash = value;
		}
	}

	public int Cost
	{
		get
		{
			if (_referenceCount == 0)
			{
				return _shapeData.Length;
			}
			return _referenceCount * _shapeData.Length;
		}
	}

	public int ReferenceCount
	{
		get
		{
			return _referenceCount;
		}
		set
		{
			_referenceCount = value;
		}
	}

	public XbimLOD LOD { get; set; }

	byte IXbimShapeGeometryData.LOD
	{
		get
		{
			return (byte)LOD;
		}
		set
		{
			LOD = (XbimLOD)value;
		}
	}

	public XbimGeometryType Format
	{
		get
		{
			return _format;
		}
		set
		{
			_format = value;
		}
	}

	byte IXbimShapeGeometryData.Format
	{
		get
		{
			return (byte)_format;
		}
		set
		{
			_format = (XbimGeometryType)value;
		}
	}

	public XbimRect3D BoundingBox
	{
		get
		{
			return _boundingBox;
		}
		set
		{
			_boundingBox = value;
		}
	}

	byte[] IXbimShapeGeometryData.BoundingBox
	{
		get
		{
			return _boundingBox.ToFloatArray();
		}
		set
		{
			_boundingBox = XbimRect3D.FromArray(value);
		}
	}

	public string ShapeData
	{
		get
		{
			return Encoding.UTF8.GetString(_shapeData.ToArray());
		}
		set
		{
			_shapeData = Encoding.UTF8.GetBytes(value);
		}
	}

	byte[] IXbimShapeGeometryData.ShapeDataCompressed
	{
		get
		{
			using MemoryStream memoryStream = new MemoryStream(_shapeData);
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
			_shapeData = memoryStream.ToArray();
		}
	}

	byte[] IXbimShapeGeometryData.ShapeData
	{
		get
		{
			return _shapeData;
		}
		set
		{
			_shapeData = value;
		}
	}

	public bool IsValid => _shapeLabel > 0;

	IVector3D IXbimShapeGeometryData.LocalShapeDisplacement => LocalShapeDisplacement;

	public XbimVector3D? LocalShapeDisplacement { get; set; }

	public byte[] ToByteArray()
	{
		return _shapeData;
	}

	public override string ToString()
	{
		return $"{_shapeLabel},{_ifcShapeLabel},{_geometryHash},{_shapeLabel},{_referenceCount},{LOD},{_format},{_boundingBox.ToString()},{_shapeData}";
	}
}
