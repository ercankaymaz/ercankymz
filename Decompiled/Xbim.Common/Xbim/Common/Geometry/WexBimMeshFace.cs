using System;
using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public class WexBimMeshFace
{
	private byte[] _array;

	private int _offsetStart;

	private ReadIndex _readIndex;

	private int _sizeofIndex;

	public int ByteSize
	{
		get
		{
			if (IsPlanar)
			{
				return 6 + TriangleCount * 3 * _sizeofIndex;
			}
			return 4 + TriangleCount * 3 * (_sizeofIndex + 2);
		}
	}

	public int TriangleCount => Math.Abs(BitConverter.ToInt32(_array, _offsetStart));

	public bool IsPlanar => BitConverter.ToInt32(_array, _offsetStart) > 0;

	public IEnumerable<int> Indices
	{
		get
		{
			int indexSpan;
			int indexOffset;
			int i;
			if (IsPlanar)
			{
				indexOffset = _offsetStart + 4 + 2;
				indexSpan = 3 * _sizeofIndex;
				for (i = 0; i < TriangleCount; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						yield return _readIndex(_array, indexOffset + j * _sizeofIndex);
					}
					indexOffset += indexSpan;
				}
				yield break;
			}
			indexSpan = _offsetStart + 4;
			indexOffset = _sizeofIndex + 2;
			i = 3 * indexOffset;
			for (int j = 0; j < TriangleCount; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					yield return _readIndex(_array, indexSpan + k * indexOffset);
				}
				indexSpan += i;
			}
		}
	}

	public IEnumerable<XbimVector3D> Normals
	{
		get
		{
			int num = _offsetStart + 4;
			if (IsPlanar)
			{
				byte u = _array[num];
				byte v = _array[num + 1];
				yield return new XbimPackedNormal(u, v).Normal;
				yield break;
			}
			int indexSpan = _sizeofIndex + 2;
			int triangleSpan = 3 * indexSpan;
			int normalOffset = num + _sizeofIndex;
			for (int i = 0; i < TriangleCount; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					byte u2 = _array[normalOffset + j * indexSpan];
					byte v2 = _array[normalOffset + j * indexSpan + 1];
					yield return new XbimPackedNormal(u2, v2).Normal;
				}
				normalOffset += triangleSpan;
			}
		}
	}

	internal WexBimMeshFace(ReadIndex readIndex, int sizeofIndex, byte[] array, int faceOffset)
	{
		_readIndex = readIndex;
		_array = array;
		_offsetStart = faceOffset;
		_sizeofIndex = sizeofIndex;
	}

	public XbimVector3D NormalAt(int index)
	{
		int num = _offsetStart + 4;
		if (IsPlanar)
		{
			byte u = _array[num];
			byte v = _array[num + 1];
			return new XbimPackedNormal(u, v).Normal;
		}
		int num2 = _sizeofIndex + 2;
		int num3 = num + index * num2 + _sizeofIndex;
		byte u2 = _array[num3];
		byte v2 = _array[num3 + 1];
		return new XbimPackedNormal(u2, v2).Normal;
	}
}
