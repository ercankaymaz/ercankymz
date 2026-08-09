using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands;
using UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Arithmetic;
using UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Hint;
using UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;
using UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.StartFinishOutline;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings;

internal static class Type1CharStringParser
{
	public static Type1CharStrings Parse(IReadOnlyList<Type1CharstringDecryptedBytes> charStrings, IReadOnlyList<Type1CharstringDecryptedBytes> subroutines)
	{
		if (charStrings == null)
		{
			throw new ArgumentNullException("charStrings");
		}
		if (subroutines == null)
		{
			throw new ArgumentNullException("subroutines");
		}
		Dictionary<string, Type1CharStrings.CommandSequence> dictionary = new Dictionary<string, Type1CharStrings.CommandSequence>(charStrings.Count);
		Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
		for (int i = 0; i < charStrings.Count; i++)
		{
			Type1CharstringDecryptedBytes type1CharstringDecryptedBytes = charStrings[i];
			IReadOnlyList<Union<double, LazyType1Command>> commands = ParseSingle(type1CharstringDecryptedBytes.Bytes);
			dictionary[type1CharstringDecryptedBytes.Name] = new Type1CharStrings.CommandSequence(commands);
			dictionary2[i] = type1CharstringDecryptedBytes.Name;
		}
		Dictionary<int, Type1CharStrings.CommandSequence> dictionary3 = new Dictionary<int, Type1CharStrings.CommandSequence>(subroutines.Count);
		foreach (Type1CharstringDecryptedBytes subroutine in subroutines)
		{
			IReadOnlyList<Union<double, LazyType1Command>> commands2 = ParseSingle(subroutine.Bytes);
			dictionary3[subroutine.Index] = new Type1CharStrings.CommandSequence(commands2);
		}
		return new Type1CharStrings(dictionary, dictionary2, dictionary3);
	}

	private static IReadOnlyList<Union<double, LazyType1Command>> ParseSingle(ReadOnlySpan<byte> charStringBytes)
	{
		List<Union<double, LazyType1Command>> list = new List<Union<double, LazyType1Command>>();
		for (int i = 0; i < charStringBytes.Length; i++)
		{
			byte b = charStringBytes[i];
			if (b <= 31)
			{
				LazyType1Command command = GetCommand(b, charStringBytes, ref i);
				if (command != null)
				{
					list.Add(new Union<double, LazyType1Command>.Case2(command));
				}
			}
			else
			{
				int num = InterpretNumber(b, charStringBytes, ref i);
				list.Add(new Union<double, LazyType1Command>.Case1(num));
			}
		}
		return list;
	}

	private static int InterpretNumber(byte b, ReadOnlySpan<byte> bytes, ref int i)
	{
		if (b >= 32 && b <= 246)
		{
			return b - 139;
		}
		if (b >= 247 && b <= 250)
		{
			byte b2 = bytes[++i];
			return (b - 247) * 256 + b2 + 108;
		}
		if (b >= 251 && b <= 254)
		{
			byte b3 = bytes[++i];
			return -((b - 251) * 256) - b3 - 108;
		}
		return (bytes[++i] << 24) | (bytes[++i] << 16) | (bytes[++i] << 8) | bytes[++i];
	}

	public static LazyType1Command GetCommand(byte v, ReadOnlySpan<byte> bytes, ref int i)
	{
		switch (v)
		{
		case 1:
			return HStemCommand.Lazy;
		case 3:
			return VStemCommand.Lazy;
		case 4:
			return VMoveToCommand.Lazy;
		case 5:
			return RLineToCommand.Lazy;
		case 6:
			return HLineToCommand.Lazy;
		case 7:
			return VLineToCommand.Lazy;
		case 8:
			return RelativeRCurveToCommand.Lazy;
		case 9:
			return ClosePathCommand.Lazy;
		case 10:
			return CallSubrCommand.Lazy;
		case 11:
			return ReturnCommand.Lazy;
		case 13:
			return HsbwCommand.Lazy;
		case 14:
			return EndCharCommand.Lazy;
		case 21:
			return RMoveToCommand.Lazy;
		case 22:
			return HMoveToCommand.Lazy;
		case 30:
			return VhCurveToCommand.Lazy;
		case 31:
			return HvCurveToCommand.Lazy;
		case 12:
			switch (bytes[++i])
			{
			case 0:
				return DotSectionCommand.Lazy;
			case 1:
				return VStem3Command.Lazy;
			case 2:
				return HStem3Command.Lazy;
			case 6:
				return SeacCommand.Lazy;
			case 7:
				return SbwCommand.Lazy;
			case 12:
				return DivCommand.Lazy;
			case 16:
				return CallOtherSubrCommand.Lazy;
			case 17:
				return PopCommand.Lazy;
			case 33:
				return SetCurrentPointCommand.Lazy;
			}
			break;
		}
		return null;
	}
}
