using System;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Parser.Parts;

internal static class ObjectHelper
{
	private const long ObjectNumberThreshold = 10000000000L;

	private const long GenerationNumberThreshold = 65535L;

	public static long ReadObjectNumber(IInputBytes bytes)
	{
		long num = ReadHelper.ReadLong(bytes);
		if (num < 0 || num >= 10000000000L)
		{
			throw new FormatException($"Object Number '{num}' has more than 10 digits or is negative");
		}
		return num;
	}

	public static int ReadGenerationNumber(IInputBytes bytes)
	{
		int num = ReadHelper.ReadInt(bytes);
		if (num < 0 || (long)num > 65535L)
		{
			throw new FormatException($"Generation Number '{num}' has more than 5 digits");
		}
		return num;
	}

	public static string CreateObjectString(long objectId, long genId)
	{
		return $"{objectId} {genId} obj";
	}
}
