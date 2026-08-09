using System;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Diagnostics;

internal sealed class _AccessorDebugProxy
{
	private readonly Accessor _Value;

	public string Identity => $"Accessor[{_Value.LogicalIndex}] {_Value.Name}";

	public BufferView Source
	{
		get
		{
			if (!_Value.TryGetBufferView(out var bv))
			{
				return null;
			}
			return bv;
		}
	}

	public (DimensionType Dimensions, EncodingType Encoding, bool Normalized) Format => (Dimensions: _Value.Dimensions, Encoding: _Value.Encoding, Normalized: _Value.Normalized);

	public object[] Items
	{
		get
		{
			if (_Value == null)
			{
				return null;
			}
			if (!_Value.TryGetBufferView(out var bv))
			{
				return null;
			}
			if (bv.IsIndexBuffer)
			{
				return _Value.AsIndicesArray().Cast<object>().ToArray();
			}
			if (bv.IsVertexBuffer)
			{
				if (_Value.Dimensions == DimensionType.SCALAR)
				{
					return _Value.AsScalarArray().Cast<object>().ToArray();
				}
				if (_Value.Dimensions == DimensionType.VEC2)
				{
					return _Value.AsVector2Array().Cast<object>().ToArray();
				}
				if (_Value.Dimensions == DimensionType.VEC3)
				{
					return _Value.AsVector3Array().Cast<object>().ToArray();
				}
				if (_Value.Dimensions == DimensionType.VEC4)
				{
					return _Value.AsVector4Array().Cast<object>().ToArray();
				}
			}
			if (_Value.Dimensions == DimensionType.MAT4)
			{
				return _Value.AsMatrix4x4Array().Cast<object>().ToArray();
			}
			ArraySegment<byte>[] array = new ArraySegment<byte>[_Value.Count];
			if (_Value.TryGetBufferView(out var bv2))
			{
				int byteSize = _Value.Format.ByteSize;
				int num = Math.Max(bv2.ByteStride, byteSize);
				ArraySegment<byte> array2 = _Extensions.Slice(bv2.Content, _Value.ByteOffset, _Value.Count * num);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _Extensions.Slice(array2, i * num, byteSize);
				}
			}
			return array.Cast<object>().ToArray();
		}
	}

	public _AccessorDebugProxy(Accessor value)
	{
		_Value = value;
	}
}
