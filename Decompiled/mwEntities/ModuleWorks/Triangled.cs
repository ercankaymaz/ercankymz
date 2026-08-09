using System;

namespace ModuleWorks;

[Serializable]
public class Triangled
{
	public int Idx1 { get; set; }

	public int Idx2 { get; set; }

	public int Idx3 { get; set; }

	public Vectord Normal { get; set; }

	public Triangled()
	{
	}

	public Triangled(int idx1, int idx2, int idx3)
	{
		Idx1 = idx1;
		Idx2 = idx2;
		Idx3 = idx3;
	}

	public Triangled(int idx1, int idx2, int idx3, Vectord normal)
		: this(idx1, idx2, idx3)
	{
		Normal = normal;
	}

	public override string ToString()
	{
		return $"Indices: ({Idx1}, {Idx2}, {Idx3}), Normal: {Normal}";
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
			Normal = new Vectord();
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
}
