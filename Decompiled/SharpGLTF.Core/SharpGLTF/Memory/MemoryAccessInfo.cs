using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Diagnostics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct MemoryAccessInfo
{
	private class AttributeComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			int num = _GetSortingScore(x);
			int value = _GetSortingScore(y);
			return num.CompareTo(value);
		}

		private static int _GetSortingScore(string attribute)
		{
			return attribute switch
			{
				"POSITION" => 0, 
				"NORMAL" => 1, 
				"TANGENT" => 2, 
				"COLOR_0" => 10, 
				"COLOR_1" => 11, 
				"COLOR_2" => 12, 
				"COLOR_3" => 13, 
				"TEXCOORD_0" => 20, 
				"TEXCOORD_1" => 21, 
				"TEXCOORD_2" => 22, 
				"TEXCOORD_3" => 23, 
				"JOINTS_0" => 50, 
				"JOINTS_1" => 51, 
				"WEIGHTS_0" => 50, 
				"WEIGHTS_1" => 51, 
				_ => 100, 
			};
		}
	}

	public string Name;

	public int ByteOffset;

	public int ItemsCount;

	public int ByteStride;

	public AttributeFormat Format;

	public readonly DimensionType Dimensions => Format.Dimensions;

	public readonly EncodingType Encoding => Format.Encoding;

	public readonly bool Normalized => Format.Normalized;

	public readonly int ByteLength => Format.ByteSize;

	public readonly int PaddedByteLength => Format.ByteSizePadded;

	public readonly int StepByteLength => Math.Max(ByteStride, Format.ByteSize);

	public readonly bool IsValidVertexAttribute
	{
		get
		{
			if (ItemsCount < 0)
			{
				return false;
			}
			if (ByteOffset < 0)
			{
				return false;
			}
			if (!ByteOffset.IsMultipleOf(4))
			{
				return false;
			}
			if (ByteStride < 0)
			{
				return false;
			}
			if (!ByteStride.IsMultipleOf(4))
			{
				return false;
			}
			if (ByteStride > 0 && ByteStride < StepByteLength)
			{
				return false;
			}
			return true;
		}
	}

	public readonly bool IsValidIndexer
	{
		get
		{
			if (ByteOffset < 0)
			{
				return false;
			}
			if (ItemsCount < 0)
			{
				return false;
			}
			if (ByteStride < 0)
			{
				return false;
			}
			if (Dimensions != DimensionType.SCALAR)
			{
				return false;
			}
			if (Normalized)
			{
				return false;
			}
			if (ByteStride == 0)
			{
				return true;
			}
			if (ByteStride == 1)
			{
				return true;
			}
			if (ByteStride == 2)
			{
				return true;
			}
			if (ByteStride == 4)
			{
				return true;
			}
			return false;
		}
	}

	internal static IComparer<string> NameComparer { get; private set; }

	internal readonly string _GetDebuggerDisplay()
	{
		return this.ToReport();
	}

	public static MemoryAccessInfo[] Create(params string[] attributes)
	{
		return attributes.Select((string item) => CreateDefaultElement(item)).ToArray();
	}

	public static MemoryAccessInfo CreateDefaultElement(string attribute)
	{
		return attribute switch
		{
			"INDEX" => new MemoryAccessInfo("INDEX", 0, 0, 0, DimensionType.SCALAR, EncodingType.UNSIGNED_INT), 
			"POSITION" => new MemoryAccessInfo("POSITION", 0, 0, 0, DimensionType.VEC3), 
			"NORMAL" => new MemoryAccessInfo("NORMAL", 0, 0, 0, DimensionType.VEC3), 
			"TANGENT" => new MemoryAccessInfo("TANGENT", 0, 0, 0, DimensionType.VEC4), 
			"TEXCOORD_0" => new MemoryAccessInfo("TEXCOORD_0", 0, 0, 0, DimensionType.VEC2), 
			"TEXCOORD_1" => new MemoryAccessInfo("TEXCOORD_1", 0, 0, 0, DimensionType.VEC2), 
			"TEXCOORD_2" => new MemoryAccessInfo("TEXCOORD_2", 0, 0, 0, DimensionType.VEC2), 
			"TEXCOORD_3" => new MemoryAccessInfo("TEXCOORD_3", 0, 0, 0, DimensionType.VEC2), 
			"COLOR_0" => new MemoryAccessInfo("COLOR_0", 0, 0, 0, DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, normalized: true), 
			"COLOR_1" => new MemoryAccessInfo("COLOR_1", 0, 0, 0, DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, normalized: true), 
			"COLOR_2" => new MemoryAccessInfo("COLOR_2", 0, 0, 0, DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, normalized: true), 
			"COLOR_3" => new MemoryAccessInfo("COLOR_3", 0, 0, 0, DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, normalized: true), 
			"JOINTS_0" => new MemoryAccessInfo("JOINTS_0", 0, 0, 0, DimensionType.VEC4, EncodingType.UNSIGNED_BYTE), 
			"JOINTS_1" => new MemoryAccessInfo("JOINTS_1", 0, 0, 0, DimensionType.VEC4, EncodingType.UNSIGNED_BYTE), 
			"WEIGHTS_0" => new MemoryAccessInfo("WEIGHTS_0", 0, 0, 0, DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, normalized: true), 
			"WEIGHTS_1" => new MemoryAccessInfo("WEIGHTS_1", 0, 0, 0, DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, normalized: true), 
			_ => throw new NotImplementedException(), 
		};
	}

	public MemoryAccessInfo(string name, int byteOffset, int itemsCount, int byteStride, AttributeFormat format)
	{
		Name = name;
		ByteOffset = byteOffset;
		ItemsCount = itemsCount;
		ByteStride = byteStride;
		Format = format;
	}

	public MemoryAccessInfo(string name, int byteOffset, int itemsCount, int byteStride, DimensionType dimensions, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
	{
		Name = name;
		ByteOffset = byteOffset;
		ItemsCount = itemsCount;
		ByteStride = byteStride;
		Format = (dim: dimensions, enc: encoding, nrm: normalized);
	}

	public readonly MemoryAccessInfo Slice(int itemStart, int itemCount)
	{
		int stepByteLength = StepByteLength;
		MemoryAccessInfo result = this;
		result.ByteOffset += itemStart * stepByteLength;
		result.ItemsCount = Math.Min(result.ItemsCount, itemCount);
		return result;
	}

	public readonly MemoryAccessInfo WithFormat(AttributeFormat newFormat)
	{
		return new MemoryAccessInfo(Name, ByteOffset, ItemsCount, ByteStride, newFormat);
	}

	public static int SetInterleavedInfo(MemoryAccessInfo[] attributes, int byteOffset, int itemsCount)
	{
		Guard.NotNull(attributes, "attributes");
		int num = 0;
		for (int i = 0; i < attributes.Length; i++)
		{
			MemoryAccessInfo memoryAccessInfo = attributes[i];
			memoryAccessInfo.ByteOffset = byteOffset;
			memoryAccessInfo.ItemsCount = itemsCount;
			int stepByteLength = memoryAccessInfo.StepByteLength;
			num += stepByteLength;
			byteOffset += stepByteLength;
			attributes[i] = memoryAccessInfo;
		}
		for (int j = 0; j < attributes.Length; j++)
		{
			MemoryAccessInfo memoryAccessInfo2 = attributes[j];
			memoryAccessInfo2.ByteStride = num;
			attributes[j] = memoryAccessInfo2;
		}
		return num;
	}

	public static MemoryAccessInfo[] Slice(MemoryAccessInfo[] attributes, int start, int count)
	{
		Guard.NotNull(attributes, "attributes");
		MemoryAccessInfo[] array = new MemoryAccessInfo[attributes.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = attributes[i].Slice(start, count);
		}
		return array;
	}

	static MemoryAccessInfo()
	{
		NameComparer = new AttributeComparer();
	}
}
