using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

internal static class _BinarySerialization
{
	public const uint GLTFHEADER = 1179937895u;

	public const uint GLTFVERSION2 = 2u;

	public const uint CHUNKJSON = 1313821514u;

	public const uint CHUNKBIN = 5130562u;

	public static Memory<byte> ReadBytesToEnd(this Stream s)
	{
		using MemoryStream memoryStream = new MemoryStream();
		s.CopyTo(memoryStream);
		if (memoryStream.TryGetBuffer(out var buffer))
		{
			return buffer;
		}
		return memoryStream.ToArray();
	}

	internal static bool _TryReadUInt32(this BinaryReader r, out uint result)
	{
		try
		{
			result = r.ReadUInt32();
			return true;
		}
		catch (EndOfStreamException)
		{
			result = 0u;
			return false;
		}
	}

	internal static bool _Identify(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		Guard.IsTrue(stream.CanSeek, "stream", "A seekable stream is required for glTF/GLB format identification");
		long position = stream.Position;
		int num = stream.ReadByte();
		int num2 = stream.ReadByte();
		int num3 = stream.ReadByte();
		int num4 = stream.ReadByte();
		stream.Position = position;
		return IsBinaryHeader((byte)num, (byte)num2, (byte)num3, (byte)num4);
	}

	internal static bool IsBinaryHeader(ReadOnlySpan<byte> span)
	{
		if (span.Length < 4)
		{
			return false;
		}
		return IsBinaryHeader(span[0], span[1], span[2], span[3]);
	}

	public static bool IsBinaryHeader(byte a, byte b, byte c, byte d)
	{
		uint num = 0u;
		num |= a;
		num |= (uint)(b << 8);
		num |= (uint)(c << 16);
		num |= (uint)(d << 24);
		return num == 1179937895;
	}

	public static IReadOnlyDictionary<uint, byte[]> ReadBinaryFile(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		using BinaryReader binaryReader = new BinaryReader(stream, Encoding.ASCII);
		long remaining = _ReadBinaryHeader(binaryReader);
		Dictionary<uint, byte[]> dictionary = new Dictionary<uint, byte[]>();
		while (remaining >= 4)
		{
			remaining -= 4L;
			if (!binaryReader._TryReadUInt32(out var result))
			{
				break;
			}
			if (result == 0)
			{
				throw new SchemaException(null, "The chunk must non zero size.");
			}
			if ((result & 3) != 0)
			{
				throw new SchemaException(null, $"The chunk must be padded to 4 bytes: {result}");
			}
			_checkCanRead(4L);
			uint num = binaryReader.ReadUInt32();
			if (dictionary.ContainsKey(num))
			{
				throw new SchemaException(null, $"Duplicated chunk found {num}");
			}
			_checkCanRead(result);
			byte[] value = binaryReader.ReadBytes((int)result);
			dictionary[num] = value;
		}
		if (!dictionary.ContainsKey(1313821514u))
		{
			throw new SchemaException(null, "JSON Chunk chunk not found");
		}
		return dictionary;
		void _checkCanRead(long count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count > int.MaxValue)
			{
				throw new SchemaException(null, $"{count} bytes to read exceeds maximum capacity.");
			}
			if (remaining < count)
			{
				throw new SchemaException(null, "unexpected End of GLB block.");
			}
			remaining -= count;
		}
	}

	private static long _ReadBinaryHeader(BinaryReader binaryReader)
	{
		Guard.NotNull(binaryReader, "binaryReader");
		uint num = binaryReader.ReadUInt32();
		if (num != 1179937895)
		{
			throw new SchemaException(null, $"Unexpected magic number: {num}");
		}
		uint num2 = binaryReader.ReadUInt32();
		if (num2 != 2)
		{
			throw new SchemaException(null, $"Unknown version number: {num2}");
		}
		uint num3 = binaryReader.ReadUInt32();
		try
		{
			if (binaryReader.BaseStream.CanSeek)
			{
				uint num4 = (uint)binaryReader.BaseStream.Length;
				if (num3 > num4)
				{
					throw new SchemaException(null, $"The specified length of the file ({num3}) is not equal to the actual length of the file ({num4}).");
				}
			}
		}
		catch (NotSupportedException)
		{
		}
		return num3 - 12;
	}

	public static Exception IsBinaryCompatible(ModelRoot model)
	{
		try
		{
			Guard.NotNull(model, "model");
			Guard.IsTrue(model.LogicalBuffers.Count <= 1, "model", string.Format("GLB format only supports one binary buffer, {0} found. It can be solved by calling {1} and {2}", model.LogicalBuffers.Count, "MergeImages", "MergeBuffers"));
		}
		catch (ArgumentException result)
		{
			return result;
		}
		return null;
	}

	public static void WriteBinaryModel(this BinaryWriter binaryWriter, ModelRoot model)
	{
		Exception ex = IsBinaryCompatible(model);
		if (ex != null)
		{
			throw ex;
		}
		string s = model._GetJSON(indented: false);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		int num = bytes.Length & 3;
		if (num != 0)
		{
			num = 4 - num;
		}
		byte[] array = ((model.LogicalBuffers.Count > 0) ? model.LogicalBuffers[0].Content : null);
		if (array != null && array.Length == 0)
		{
			array = null;
		}
		int num2 = ((array != null) ? (array.Length & 3) : 0);
		if (num2 != 0)
		{
			num2 = 4 - num2;
		}
		int num3 = 12;
		num3 += 8 + bytes.Length + num;
		if (array != null)
		{
			num3 += 8 + array.Length + num2;
		}
		binaryWriter.Write(1179937895u);
		binaryWriter.Write(2u);
		binaryWriter.Write(num3);
		binaryWriter.Write(bytes.Length + num);
		binaryWriter.Write(1313821514u);
		binaryWriter.Write(bytes);
		for (int i = 0; i < num; i++)
		{
			binaryWriter.Write((byte)32);
		}
		if (array != null)
		{
			binaryWriter.Write(array.Length + num2);
			binaryWriter.Write(5130562u);
			binaryWriter.Write(array);
			for (int j = 0; j < num2; j++)
			{
				binaryWriter.Write((byte)0);
			}
		}
	}
}
