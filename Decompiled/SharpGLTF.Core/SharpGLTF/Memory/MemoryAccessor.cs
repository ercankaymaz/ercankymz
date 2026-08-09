using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public sealed class MemoryAccessor
{
	public MemoryAccessInfo Attribute { get; private set; }

	public ArraySegment<byte> Data { get; private set; }

	internal string _GetDebuggerDisplay()
	{
		return Attribute._GetDebuggerDisplay();
	}

	public MemoryAccessor(byte[] data, MemoryAccessInfo info)
	{
		Attribute = info;
		Data = new ArraySegment<byte>(data);
	}

	public MemoryAccessor(ArraySegment<byte> data, MemoryAccessInfo info)
	{
		Attribute = info;
		Data = data;
	}

	public MemoryAccessor(MemoryAccessInfo info)
	{
		Attribute = info;
		Data = default(ArraySegment<byte>);
	}

	public void Update(ArraySegment<byte> data, MemoryAccessInfo encoding)
	{
		Attribute = encoding;
		Data = data;
	}

	public IAccessorArray<T> AsArrayOf<T>() where T : unmanaged
	{
		if (typeof(T) == typeof(uint))
		{
			return AsIntegerArray() as IAccessorArray<T>;
		}
		if (typeof(T) == typeof(float))
		{
			return AsScalarArray() as IAccessorArray<T>;
		}
		if (typeof(T) == typeof(Vector2))
		{
			return AsVector2Array() as IAccessorArray<T>;
		}
		if (typeof(T) == typeof(Vector3))
		{
			return AsVector3Array() as IAccessorArray<T>;
		}
		if (typeof(T) == typeof(Vector4))
		{
			if (Attribute.Dimensions == DimensionType.VEC4)
			{
				return AsVector4Array() as IAccessorArray<T>;
			}
			if (Attribute.Dimensions == DimensionType.VEC3)
			{
				return AsColorArray() as IAccessorArray<T>;
			}
		}
		if (typeof(T) == typeof(Quaternion))
		{
			return AsQuaternionArray() as IAccessorArray<T>;
		}
		if (typeof(T) == typeof(Matrix3x2))
		{
			return AsMatrix2x2Array() as IAccessorArray<T>;
		}
		if (typeof(T) == typeof(Matrix4x4))
		{
			if (Attribute.Dimensions == DimensionType.MAT3)
			{
				return AsMatrix3x3Array() as IAccessorArray<T>;
			}
			if (Attribute.Dimensions == DimensionType.MAT4)
			{
				return AsMatrix4x4Array() as IAccessorArray<T>;
			}
		}
		throw new NotSupportedException(typeof(T).Name);
	}

	public IntegerArray AsIntegerArray()
	{
		Guard.IsTrue(Attribute.IsValidIndexer, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.SCALAR, "Attribute");
		return new IntegerArray(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.Encoding.ToIndex());
	}

	public ScalarArray AsScalarArray()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.SCALAR, "Attribute");
		return new ScalarArray(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public Vector2Array AsVector2Array()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.VEC2, "Attribute");
		return new Vector2Array(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public Vector3Array AsVector3Array()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.VEC3, "Attribute");
		return new Vector3Array(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public Vector4Array AsVector4Array()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.VEC4, "Attribute");
		return new Vector4Array(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public QuaternionArray AsQuaternionArray()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.VEC4, "Attribute");
		return new QuaternionArray(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public Matrix2x2Array AsMatrix2x2Array()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.MAT2, "Attribute");
		return new Matrix2x2Array(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public Matrix3x3Array AsMatrix3x3Array()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.MAT3, "Attribute");
		return new Matrix3x3Array(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public Matrix4x3Array AsMatrix4x3Array()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		return new Matrix4x3Array(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public Matrix4x4Array AsMatrix4x4Array()
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.MAT4, "Attribute");
		return new Matrix4x4Array(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Encoding, Attribute.Normalized);
	}

	public ColorArray AsColorArray(float defaultW = 1f)
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.VEC3 || Attribute.Dimensions == DimensionType.VEC4, "Attribute");
		return new ColorArray(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, Attribute.Dimensions.DimCount(), Attribute.Encoding, Attribute.Normalized, defaultW);
	}

	public MultiArray AsMultiArray(int dimensions)
	{
		Guard.IsTrue(Attribute.IsValidVertexAttribute, "Attribute");
		Guard.IsTrue(Attribute.Dimensions == DimensionType.SCALAR, "Attribute");
		Guard.IsTrue(Attribute.ByteStride == 0, "Attribute");
		return new MultiArray(Data, Attribute.ByteOffset, Attribute.ItemsCount, Attribute.ByteStride, dimensions, Attribute.Encoding, Attribute.Normalized);
	}

	public IEnumerable<ArraySegment<byte>> GetItemsAsRawBytes()
	{
		int itemSize = Attribute.ByteLength;
		int rowStride = Attribute.StepByteLength;
		int rowOffset = Attribute.ByteOffset;
		int i = 0;
		while (i < Attribute.ItemsCount)
		{
			yield return _Extensions.Slice(Data, i * rowStride + rowOffset, itemSize);
			int num = i + 1;
			i = num;
		}
	}

	public (MemoryAccessor indices, MemoryAccessor values) ConvertToSparse()
	{
		List<uint> list = new List<uint>();
		List<ArraySegment<byte>> list2 = new List<ArraySegment<byte>>();
		uint num = 0u;
		foreach (ArraySegment<byte> itemsAsRawByte in GetItemsAsRawBytes())
		{
			if (!RepresentsZeroValue(itemsAsRawByte))
			{
				list.Add(num);
				list2.Add(itemsAsRawByte);
			}
			num++;
		}
		byte[] array = new byte[list.Count * 4];
		for (int i = 0; i < list.Count; i++)
		{
			BinaryPrimitives.WriteUInt32LittleEndian(array.Slice(i * 4), list[i]);
		}
		int byteLength = Attribute.ByteLength;
		byte[] array2 = new byte[list2.Count * byteLength];
		for (int j = 0; j < list2.Count; j++)
		{
			ArraySegment<byte> segment = list2[j];
			ArraySegment<byte> arraySegment = new ArraySegment<byte>(array2, j * byteLength, byteLength);
			MemoryExtensions.AsSpan(segment).CopyTo(arraySegment);
		}
		MemoryAccessor item = new MemoryAccessor(array, new MemoryAccessInfo("SparseIndices", 0, list2.Count, 0, EncodingType.UNSIGNED_INT));
		MemoryAccessor item2 = new MemoryAccessor(array2, new MemoryAccessInfo("SparseValues", 0, list2.Count, 0, Attribute.Format));
		return (indices: item, values: item2);
	}

	private bool RepresentsZeroValue(ArraySegment<byte> bytes)
	{
		if (Attribute.Encoding == EncodingType.FLOAT)
		{
			Span<float> span = MemoryMarshal.Cast<byte, float>((Span<byte>)bytes);
			Span<float> span2 = span;
			for (int i = 0; i < span2.Length; i++)
			{
				float num = span2[i];
				if (num != 0f)
				{
					return false;
				}
			}
			return true;
		}
		return bytes.All((byte b) => b == 0);
	}

	public static IAccessorArray<T> CreateSparseArray<T>(MemoryAccessor denseValues, IntegerArray sparseKeys, MemoryAccessor sparseValues) where T : unmanaged
	{
		return _CreateSparseArray(denseValues, sparseKeys, sparseValues, (MemoryAccessor m) => m.AsArrayOf<T>());
	}

	public static IAccessorArray<T> CreateSparseArray<T>(int denseCount, IntegerArray sparseKeys, MemoryAccessor sparseValues) where T : unmanaged
	{
		return _CreateSparseArray(denseCount, sparseKeys, sparseValues, (MemoryAccessor m) => m.AsArrayOf<T>());
	}

	public static IAccessorArray<Vector4> CreateColorSparseArray(int denseCount, IntegerArray sparseKeys, MemoryAccessor sparseValues, float defaultW = 1f)
	{
		return _CreateSparseArray<Vector4>(denseCount, sparseKeys, sparseValues, (Func<MemoryAccessor, IAccessorArray<Vector4>>)((MemoryAccessor m) => m.AsColorArray(defaultW)));
	}

	public static IAccessorArray<Vector4> CreateColorSparseArray(MemoryAccessor denseValues, IntegerArray sparseKeys, MemoryAccessor sparseValues, float defaultW = 1f)
	{
		return _CreateSparseArray<Vector4>(denseValues, sparseKeys, sparseValues, (Func<MemoryAccessor, IAccessorArray<Vector4>>)((MemoryAccessor m) => m.AsColorArray(defaultW)));
	}

	private static IAccessorArray<T> _CreateSparseArray<T>(int denseCount, IntegerArray sparseKeys, MemoryAccessor sparseValues, Func<MemoryAccessor, IAccessorArray<T>> toAccessor) where T : unmanaged
	{
		Guard.NotNull(sparseValues, "sparseValues");
		Guard.IsTrue(sparseKeys.Count <= denseCount, "sparseKeys");
		IAccessorArray<T> accessorArray = toAccessor(sparseValues);
		Guard.IsTrue(sparseKeys.Count == accessorArray.Count, "sparseValues");
		return new SparseArray<T>(new ZeroAccessorArray<T>(denseCount), accessorArray, sparseKeys);
	}

	private static IAccessorArray<T> _CreateSparseArray<T>(MemoryAccessor denseValues, IntegerArray sparseKeys, MemoryAccessor sparseValues, Func<MemoryAccessor, IAccessorArray<T>> toAccessor) where T : unmanaged
	{
		Guard.NotNull(denseValues, "denseValues");
		Guard.NotNull(sparseValues, "sparseValues");
		IAccessorArray<T> accessorArray = toAccessor(denseValues);
		IAccessorArray<T> accessorArray2 = toAccessor(sparseValues);
		Guard.IsTrue(sparseKeys.Count <= accessorArray.Count, "sparseKeys");
		Guard.IsTrue(sparseKeys.Count == accessorArray2.Count, "sparseValues");
		return new SparseArray<T>(accessorArray, accessorArray2, sparseKeys);
	}

	public static void SanitizeVertexAttributes(MemoryAccessor[] vertexAccessors)
	{
		MemoryAccessor weights = vertexAccessors.FirstOrDefault((MemoryAccessor item) => item.Attribute.Name == "WEIGHTS_0");
		MemoryAccessor weights2 = vertexAccessors.FirstOrDefault((MemoryAccessor item) => item.Attribute.Name == "WEIGHTS_1");
		SanitizeWeightsSum(weights, weights2);
	}

	public static bool HaveOverlappingBuffers(MemoryAccessor a, MemoryAccessor b)
	{
		Guard.NotNull(a, "a");
		Guard.NotNull(b, "b");
		ArraySegment<byte> arraySegment = a._GetBytes();
		ArraySegment<byte> arraySegment2 = b._GetBytes();
		if (arraySegment.Array != arraySegment2.Array)
		{
			return false;
		}
		if (arraySegment.Offset >= arraySegment2.Offset + arraySegment2.Count)
		{
			return false;
		}
		if (arraySegment2.Offset >= arraySegment.Offset + arraySegment.Count)
		{
			return false;
		}
		return true;
	}

	internal ArraySegment<byte> _GetBytes()
	{
		int byteOffset = Attribute.ByteOffset;
		int val = Attribute.StepByteLength * Attribute.ItemsCount;
		ArraySegment<byte> array = _Extensions.Slice(Data, byteOffset);
		return _Extensions.Slice(array, 0, Math.Min(array.Count, val));
	}

	public static bool HaveOverlappingBuffers(IEnumerable<MemoryAccessor> abc)
	{
		List<MemoryAccessor> list = abc.ToList();
		for (int i = 0; i < list.Count - 1; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				if (HaveOverlappingBuffers(list[i], list[j]))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void SanitizeWeightsSum(MemoryAccessor weights0, MemoryAccessor weights1)
	{
		if (weights1 == null)
		{
			if (weights0 == null)
			{
				return;
			}
			{
				foreach (ArraySegment<byte> itemsAsRawByte in weights0.GetItemsAsRawBytes())
				{
					_SanitizeWeightSum(itemsAsRawByte, weights0.Attribute.Encoding);
				}
				return;
			}
		}
		if (weights0 == null)
		{
			return;
		}
		int byteLength = weights0.Attribute.ByteLength;
		Span<byte> span = stackalloc byte[byteLength * 2];
		IEnumerable<(ArraySegment<byte>, ArraySegment<byte>)> enumerable = weights0.GetItemsAsRawBytes().Zip(weights1.GetItemsAsRawBytes(), (ArraySegment<byte> a, ArraySegment<byte> b) => (a: a, b: b));
		foreach (var (arraySegment, arraySegment2) in enumerable)
		{
			MemoryExtensions.AsSpan(arraySegment).CopyTo(span);
			MemoryExtensions.AsSpan(arraySegment2).CopyTo(span.Slice(byteLength));
			if (_SanitizeWeightSum(span, weights0.Attribute.Encoding))
			{
				span.Slice(0, byteLength).CopyTo(arraySegment);
				span.Slice(byteLength, byteLength).CopyTo(arraySegment2);
			}
		}
	}

	private static bool _SanitizeWeightSum(Span<byte> dst, EncodingType encoding)
	{
		switch (encoding)
		{
		case EncodingType.UNSIGNED_BYTE:
		{
			Span<byte> span3 = dst;
			int num6 = 0;
			for (int l = 0; l < span3.Length; l++)
			{
				num6 += span3[l];
			}
			if (num6 == 255)
			{
				return false;
			}
			span3[0] += (byte)(255 - num6);
			return true;
		}
		case EncodingType.UNSIGNED_SHORT:
		{
			Span<ushort> span2 = MemoryMarshal.Cast<byte, ushort>(dst);
			int num5 = 0;
			for (int k = 0; k < span2.Length; k++)
			{
				num5 += span2[k];
			}
			if (num5 == 65535)
			{
				return false;
			}
			ref ushort reference = ref span2[0];
			reference += (byte)(65535 - num5);
			return true;
		}
		case EncodingType.FLOAT:
		{
			Span<float> span = MemoryMarshal.Cast<byte, float>(dst);
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < span.Length; i++)
			{
				float num3 = span[i];
				if (float.IsNaN(num3))
				{
					return false;
				}
				if (num3 < 0f || num3 > 1f)
				{
					return false;
				}
				if (num3 > 0f)
				{
					num2 += num3;
					num += 1f;
				}
			}
			float num4 = 2E-07f * num;
			if (Math.Abs(num2 - 1f) <= num4)
			{
				return false;
			}
			for (int j = 0; j < span.Length; j++)
			{
				span[j] /= num2;
			}
			return true;
		}
		default:
			return false;
		}
	}

	public static void VerifyWeightsSum(MemoryAccessor weights0, MemoryAccessor weights1)
	{
		int num = 0;
		if (weights1 == null)
		{
			if (weights0 == null)
			{
				return;
			}
			{
				foreach (ArraySegment<byte> itemsAsRawByte in weights0.GetItemsAsRawBytes())
				{
					if (!_CheckWeightSum(itemsAsRawByte, weights0.Attribute.Encoding))
					{
						throw new ArgumentException($"Weight Sum invalid at Index {num}", "weights0");
					}
					num++;
				}
				return;
			}
		}
		if (weights0 == null)
		{
			throw new ArgumentNullException("weights0");
		}
		if (weights0.Attribute.Encoding != weights1.Attribute.Encoding)
		{
			throw new ArgumentException("WEIGHTS_0 and WEIGHTS_1 format mismatch.", "weights1");
		}
		int byteLength = weights0.Attribute.ByteLength;
		Span<byte> span = stackalloc byte[byteLength * 2];
		IEnumerable<(ArraySegment<byte>, ArraySegment<byte>)> enumerable = weights0.GetItemsAsRawBytes().Zip(weights1.GetItemsAsRawBytes(), (ArraySegment<byte> a, ArraySegment<byte> b) => (a: a, b: b));
		foreach (var (segment, segment2) in enumerable)
		{
			MemoryExtensions.AsSpan(segment).CopyTo(span);
			MemoryExtensions.AsSpan(segment2).CopyTo(span.Slice(byteLength));
			if (!_CheckWeightSum(span, weights0.Attribute.Encoding))
			{
				throw new ArgumentException($"Weight Sum invalid at Index {num}", "weights1");
			}
			num++;
		}
	}

	private static bool _CheckWeightSum(ReadOnlySpan<byte> src, EncodingType encoding)
	{
		switch (encoding)
		{
		case EncodingType.UNSIGNED_BYTE:
		{
			ReadOnlySpan<byte> readOnlySpan3 = src;
			int num6 = 0;
			for (int k = 0; k < readOnlySpan3.Length; k++)
			{
				num6 += readOnlySpan3[k];
			}
			return num6 == 255;
		}
		case EncodingType.UNSIGNED_SHORT:
		{
			ReadOnlySpan<ushort> readOnlySpan2 = MemoryMarshal.Cast<byte, ushort>(src);
			int num5 = 0;
			for (int j = 0; j < readOnlySpan2.Length; j++)
			{
				num5 += readOnlySpan2[j];
			}
			return num5 == 65535;
		}
		case EncodingType.FLOAT:
		{
			ReadOnlySpan<float> readOnlySpan = MemoryMarshal.Cast<byte, float>(src);
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				float num3 = readOnlySpan[i];
				if (float.IsNaN(num3))
				{
					return false;
				}
				if (num3 < 0f || num3 > 1f)
				{
					return false;
				}
				if (num3 > 0f)
				{
					num2 += num3;
					num += 1f;
				}
			}
			float num4 = 2E-07f * num;
			return Math.Abs(num2 - 1f) <= num4;
		}
		default:
			return false;
		}
	}

	public static void VerifyAccessorBounds(MemoryAccessor memory, IReadOnlyList<double> min, IReadOnlyList<double> max)
	{
		Guard.NotNull(memory, "memory");
		Guard.NotNull(min, "min");
		Guard.NotNull(max, "max");
		if (min.Count == 0 && max.Count == 0)
		{
			return;
		}
		int num = memory.Attribute.Dimensions.DimCount();
		if (min.Count != num)
		{
			throw new ArgumentException($"min size mismatch; expected {num} but found {min.Count}", "min");
		}
		if (max.Count != num)
		{
			throw new ArgumentException($"max size mismatch; expected {num} but found {max.Count}", "max");
		}
		for (int i = 0; i < min.Count; i++)
		{
		}
		float[] array = min.Select((double item) => (float)item).ToArray();
		float[] array2 = max.Select((double item) => (float)item).ToArray();
		MultiArray multiArray = new MultiArray(memory.Data, memory.Attribute.ByteOffset, memory.Attribute.ItemsCount, memory.Attribute.ByteStride, num, memory.Attribute.Encoding, normalized: false);
		float[] array3 = new float[num];
		for (int num2 = 0; num2 < multiArray.Count; num2++)
		{
			multiArray.CopyItemTo(num2, array3);
			for (int num3 = 0; num3 < array3.Length; num3++)
			{
				float num4 = array3[num3];
				float num5 = array[num3];
				float num6 = array2[num3];
				if (num4 < num5 || num4 > num6)
				{
					throw new ArgumentOutOfRangeException("memory", $"Value[{num2}] is out of bounds. {num5} <= {num4} <= {num6}");
				}
			}
		}
	}

	public static void VerifyVertexIndices(MemoryAccessor memory, uint vertexCount)
	{
		Guard.NotNull(memory, "memory");
		uint num = 255u;
		if (memory.Attribute.Encoding == EncodingType.UNSIGNED_SHORT)
		{
			num = 65535u;
		}
		if (memory.Attribute.Encoding == EncodingType.UNSIGNED_INT)
		{
			num = uint.MaxValue;
		}
		memory.AsIntegerArray();
		IntegerArray integerArray = memory.AsIntegerArray();
		for (int i = 0; i < integerArray.Count; i++)
		{
			uint num2 = integerArray[i];
			if (num2 >= vertexCount)
			{
				throw new ArgumentException($"Value[{i}] is out of bounds {vertexCount}.", "memory");
			}
			if (num2 == num)
			{
				throw new ArgumentException($"Value[{i}] is restart value.", "memory");
			}
		}
	}
}
