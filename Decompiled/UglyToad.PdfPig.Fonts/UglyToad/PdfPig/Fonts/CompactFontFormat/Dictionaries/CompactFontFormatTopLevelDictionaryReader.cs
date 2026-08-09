using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;

internal class CompactFontFormatTopLevelDictionaryReader : CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>
{
	public override CompactFontFormatTopLevelDictionary Read(CompactFontFormatData data, ReadOnlySpan<string> stringIndex)
	{
		CompactFontFormatTopLevelDictionary compactFontFormatTopLevelDictionary = new CompactFontFormatTopLevelDictionary();
		ReadDictionary(compactFontFormatTopLevelDictionary, data, stringIndex);
		return compactFontFormatTopLevelDictionary;
	}

	protected override void ApplyOperation(CompactFontFormatTopLevelDictionary dictionary, List<Operand> operands, OperandKey key, ReadOnlySpan<string> stringIndex)
	{
		switch (key.Byte0)
		{
		case 0:
			dictionary.Version = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
			break;
		case 1:
			dictionary.Notice = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
			break;
		case 2:
			dictionary.FullName = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
			break;
		case 3:
			dictionary.FamilyName = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
			break;
		case 4:
			dictionary.Weight = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
			break;
		case 5:
			dictionary.FontBoundingBox = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetBoundingBox(operands);
			break;
		case 12:
			if (!key.Byte1.HasValue)
			{
				throw new InvalidOperationException("A single byte sequence beginning with 12 was found.");
			}
			switch (key.Byte1.Value)
			{
			case 0:
				dictionary.Copyright = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
				break;
			case 1:
				dictionary.IsFixedPitch = operands[0].Double == 1.0;
				break;
			case 2:
				dictionary.ItalicAngle = operands[0].Double;
				break;
			case 3:
				dictionary.UnderlinePosition = operands[0].Double;
				break;
			case 4:
				dictionary.UnderlineThickness = operands[0].Double;
				break;
			case 5:
				dictionary.PaintType = operands[0].Double;
				break;
			case 6:
				dictionary.CharStringType = (CompactFontFormatCharStringType)CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands, 2);
				break;
			case 7:
			{
				double[] array = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.ToArray(operands);
				if (array.Length == 4)
				{
					dictionary.FontMatrix = TransformationMatrix.FromArray(array);
					break;
				}
				if (array.Length == 6)
				{
					dictionary.FontMatrix = TransformationMatrix.FromArray(array);
					break;
				}
				throw new InvalidOperationException($"Expected four values for the font matrix, instead got: {array.Length}.");
			}
			case 8:
				dictionary.StrokeWidth = operands[0].Double;
				break;
			case 20:
				dictionary.SyntheticBaseFontIndex = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				break;
			case 21:
				dictionary.PostScript = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
				break;
			case 22:
				dictionary.BaseFontName = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
				break;
			case 23:
				dictionary.BaseFontBlend = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.ReadDeltaToArray(operands);
				break;
			case 30:
			{
				string registry = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
				operands.RemoveAt(0);
				string ordering = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
				operands.RemoveAt(0);
				int intOrDefault3 = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				dictionary.CidFontOperators.Ros = new RegistryOrderingSupplement
				{
					Registry = registry,
					Ordering = ordering,
					Supplement = intOrDefault3
				};
				dictionary.IsCidFont = true;
				break;
			}
			case 31:
				dictionary.CidFontOperators.Version = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				break;
			case 32:
				dictionary.CidFontOperators.Revision = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				break;
			case 33:
				dictionary.CidFontOperators.Type = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				break;
			case 34:
				dictionary.CidFontOperators.Count = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				break;
			case 35:
				dictionary.CidFontOperators.UidBase = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				break;
			case 36:
				dictionary.CidFontOperators.FontDictionaryArray = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				break;
			case 37:
				dictionary.CidFontOperators.FontDictionarySelect = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
				break;
			case 38:
				dictionary.CidFontOperators.FontName = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetString(operands, stringIndex);
				break;
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
				break;
			}
			break;
		case 13:
			dictionary.UniqueId = ((operands.Count > 0) ? operands[0].Double : 0.0);
			break;
		case 14:
			dictionary.Xuid = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.ToArray(operands);
			break;
		case 15:
			dictionary.CharSetOffset = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
			break;
		case 16:
			dictionary.EncodingOffset = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
			break;
		case 17:
			dictionary.CharStringsOffset = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
			break;
		case 18:
		{
			int intOrDefault = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
			operands.RemoveAt(0);
			int intOrDefault2 = CompactFontFormatDictionaryReader<CompactFontFormatTopLevelDictionary, CompactFontFormatTopLevelDictionary>.GetIntOrDefault(operands);
			dictionary.PrivateDictionaryLocation = new CompactFontFormatTopLevelDictionary.SizeAndOffset(intOrDefault, intOrDefault2);
			break;
		}
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
			break;
		}
	}
}
