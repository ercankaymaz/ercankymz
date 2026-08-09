using System;
using System.IO;

namespace ModuleWorks;

[Serializable]
public class Trianglef
{
	public int Idx1 { get; set; }

	public int Idx2 { get; set; }

	public int Idx3 { get; set; }

	public Vectorf Normal { get; set; }

	public Trianglef()
	{
	}

	public Trianglef(int idx1, int idx2, int idx3)
	{
		Idx1 = idx1;
		Idx2 = idx2;
		Idx3 = idx3;
	}

	public Trianglef(int idx1, int idx2, int idx3, Vectorf normal)
		: this(idx1, idx2, idx3)
	{
		Normal = normal;
	}

	public override string ToString()
	{
		return $"Indices: ({Idx1}, {Idx2}, {Idx3}), Normal: {Normal}";
	}

	public void Load(Stream stream)
	{
		using BinaryReader reader = new BinaryReader(stream);
		Load(reader);
	}

	public void Load(BinaryReader reader)
	{
		Idx1 = reader.ReadInt32();
		Idx2 = reader.ReadInt32();
		Idx3 = reader.ReadInt32();
		Normal = new Vectorf();
		Normal.Load(reader);
	}

	public unsafe int Load(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			Idx1 = *(int*)(ptr + index);
			index += 4;
			Idx2 = *(int*)(ptr + index);
			index += 4;
			Idx3 = *(int*)(ptr + index);
			index += 4;
			Normal = new Vectorf();
			index = Normal.Load(array, index);
		}
		return index;
	}

	public unsafe int Serialize(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			*(int*)(ptr + index) = Idx1;
			index += 4;
			*(int*)(ptr + index) = Idx2;
			index += 4;
			*(int*)(ptr + index) = Idx3;
			index += 4;
			index = Normal.Serialize(array, index);
		}
		return index;
	}

	public void Serialize(Stream stream)
	{
		using BinaryWriter writer = new BinaryWriter(stream);
		Serialize(writer);
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Idx1);
		writer.Write(Idx2);
		writer.Write(Idx3);
		Normal.Serialize(writer);
	}
}
