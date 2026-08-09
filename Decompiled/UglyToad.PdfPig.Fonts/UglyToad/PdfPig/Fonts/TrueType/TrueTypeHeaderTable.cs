using System;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType;

public readonly struct TrueTypeHeaderTable : IWriteable
{
	public const string Cmap = "cmap";

	public const string Glyf = "glyf";

	public const string Head = "head";

	public const string Hhea = "hhea";

	public const string Hmtx = "hmtx";

	public const string Loca = "loca";

	public const string Maxp = "maxp";

	public const string Name = "name";

	public const string Post = "post";

	public const string Os2 = "OS/2";

	public const string Cvt = "cvt ";

	public const string Ebdt = "EBDT";

	public const string Eblc = "EBLC";

	public const string Ebsc = "EBSC";

	public const string Fpgm = "fpgm";

	public const string Gasp = "gasp";

	public const string Hdmx = "hdmx";

	public const string Kern = "kern";

	public const string Ltsh = "LTSH";

	public const string Prep = "prep";

	public const string Pclt = "PCLT";

	public const string Vdmx = "VDMX";

	public const string Vhea = "vhea";

	public const string Vmtx = "vmtx";

	public const string Cff = "cff ";

	public string Tag { get; }

	public uint CheckSum { get; }

	public uint Offset { get; }

	public uint Length { get; }

	public TrueTypeHeaderTable(string tag, uint checkSum, uint offset, uint length)
	{
		if (tag == null)
		{
			throw new ArgumentNullException("tag");
		}
		if (tag.Length != 4)
		{
			throw new ArgumentException("A TrueType table tag must be a uint32, 4 bytes long, instead got: " + tag + ".", "tag");
		}
		Tag = tag;
		CheckSum = checkSum;
		Offset = offset;
		Length = length;
	}

	public static TrueTypeHeaderTable GetEmptyHeaderTable(string tag)
	{
		return new TrueTypeHeaderTable(tag, 0u, 0u, 0u);
	}

	public void Write(Stream stream)
	{
		for (int i = 0; i < Tag.Length; i++)
		{
			stream.WriteByte((byte)Tag[i]);
		}
		stream.WriteUInt(CheckSum);
		stream.WriteUInt(Offset);
		stream.WriteUInt(Length);
	}

	public override string ToString()
	{
		return $"{Tag} - Offset: {Offset} Length: {Length} Checksum: {CheckSum}";
	}
}
