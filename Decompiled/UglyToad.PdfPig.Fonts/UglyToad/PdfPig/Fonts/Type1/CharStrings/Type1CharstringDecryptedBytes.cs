using System;
using System.Globalization;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings;

internal sealed class Type1CharstringDecryptedBytes
{
	public enum SourceType
	{
		Subroutine,
		Charstring
	}

	private readonly byte[] bytes;

	public ReadOnlySpan<byte> Bytes => bytes;

	public int Index { get; }

	public string Name { get; }

	public SourceType Source { get; }

	public Type1CharstringDecryptedBytes(byte[] bytes, int index)
	{
		this.bytes = bytes ?? throw new ArgumentNullException("bytes");
		Index = index;
		Name = ".notdef";
		Source = SourceType.Subroutine;
	}

	public Type1CharstringDecryptedBytes(string name, byte[] bytes, int index)
	{
		this.bytes = bytes ?? throw new ArgumentNullException("bytes");
		Index = index;
		Name = name ?? index.ToString(CultureInfo.InvariantCulture);
		Source = SourceType.Charstring;
	}

	public override string ToString()
	{
		return $"{Name} {Source} {Index} {Bytes.Length} bytes";
	}
}
