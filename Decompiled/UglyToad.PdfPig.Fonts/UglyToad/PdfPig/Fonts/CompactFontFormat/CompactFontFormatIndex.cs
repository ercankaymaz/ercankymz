using System;
using System.Collections;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal class CompactFontFormatIndex : IReadOnlyList<ReadOnlyMemory<byte>>, IReadOnlyCollection<ReadOnlyMemory<byte>>, IEnumerable<ReadOnlyMemory<byte>>, IEnumerable
{
	private readonly byte[][] bytes;

	public int Count => bytes.Length;

	public ReadOnlyMemory<byte> this[int index] => bytes[index];

	public static CompactFontFormatIndex None { get; } = new CompactFontFormatIndex(Array.Empty<byte[]>());

	public CompactFontFormatIndex(byte[][] bytes)
	{
		this.bytes = bytes ?? Array.Empty<byte[]>();
	}

	public IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
	{
		byte[][] array = bytes;
		foreach (byte[] array2 in array)
		{
			yield return new ReadOnlyMemory<byte>(array2);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		byte[][] array = bytes;
		foreach (byte[] array2 in array)
		{
			yield return new ReadOnlyMemory<byte>(array2);
		}
	}
}
