using System;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Subsetting;

internal class TrueTypeOffsetSubtable : IWriteable
{
	private static readonly byte[] VersionHeader = new byte[4] { 0, 1, 0, 0 };

	private readonly byte numberOfTables;

	public TrueTypeOffsetSubtable(byte numberOfTables)
	{
		this.numberOfTables = numberOfTables;
	}

	public void Write(Stream stream)
	{
		stream.Write(VersionHeader, 0, VersionHeader.Length);
		stream.WriteUShort(numberOfTables);
		ushort highestPowerOf = GetHighestPowerOf2(numberOfTables);
		ushort num = (ushort)(highestPowerOf * 16);
		ushort value = (ushort)Math.Log((int)highestPowerOf, 2.0);
		ushort value2 = (ushort)(numberOfTables * 16 - num);
		stream.WriteUShort(num);
		stream.WriteUShort(value);
		stream.WriteUShort(value2);
	}

	private static ushort GetHighestPowerOf2(int numberOfTables)
	{
		ushort result = 1;
		for (int i = 0; i < 16; i++)
		{
			ushort num = (ushort)(1 << i);
			if (num > numberOfTables)
			{
				break;
			}
			result = num;
		}
		return result;
	}
}
