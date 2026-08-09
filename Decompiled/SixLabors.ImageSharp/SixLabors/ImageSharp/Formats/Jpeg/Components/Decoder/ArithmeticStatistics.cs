using System;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal class ArithmeticStatistics
{
	private readonly byte[] statistics;

	public bool IsDcStatistics { get; private set; }

	public int Identifier { get; private set; }

	public ArithmeticStatistics(bool dc, int identifier)
	{
		IsDcStatistics = dc;
		Identifier = identifier;
		statistics = (dc ? new byte[64] : new byte[256]);
	}

	public ref byte GetReference()
	{
		return ref MemoryMarshal.GetArrayDataReference<byte>(statistics);
	}

	public ref byte GetReference(int offset)
	{
		return ref statistics[offset];
	}

	public void Reset()
	{
		MemoryExtensions.AsSpan<byte>(statistics).Clear();
	}
}
