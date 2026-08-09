using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.TrueType;
using UglyToad.PdfPig.Fonts.TrueType.Subsetting;
using UglyToad.PdfPig.Fonts.TrueType.Tables;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer.Fonts;

internal class TrueTypeWritingFont : IWritingFont
{
	private readonly TrueTypeFont font;

	private readonly ReadOnlyMemory<byte> fontFileBytes;

	private readonly object mappingLock = new object();

	private readonly Dictionary<char, byte> characterMapping = new Dictionary<char, byte>();

	private int characterMappingCounter = 1;

	public bool HasWidths { get; } = true;

	public string Name => font.Name;

	public TrueTypeWritingFont(TrueTypeFont font, ReadOnlyMemory<byte> fontFileBytes)
	{
		this.font = font;
		this.fontFileBytes = fontFileBytes;
	}

	public bool TryGetBoundingBox(char character, out PdfRectangle boundingBox)
	{
		return font.TryGetBoundingBox(character, out boundingBox);
	}

	public bool TryGetAdvanceWidth(char character, out double width)
	{
		return font.TryGetAdvanceWidth(character, out width);
	}

	public TransformationMatrix GetFontMatrix()
	{
		int unitsPerEm = font.GetUnitsPerEm();
		return TransformationMatrix.FromValues(1.0 / (double)unitsPerEm, 0.0, 0.0, 1.0 / (double)unitsPerEm, 0.0, 0.0);
	}

	public IndirectReferenceToken WriteFont(IPdfStreamWriter writer, IndirectReferenceToken? reservedIndirect = null)
	{
		TrueTypeSubsetEncoding newEncoding = new TrueTypeSubsetEncoding(characterMapping.Keys.ToList());
		StreamToken token = DataCompresser.CompressToStream(TrueTypeSubsetter.Subset(fontFileBytes.ToArray(), newEncoding));
		IndirectReferenceToken value = writer.WriteToken(token);
		NameToken value2 = NameToken.Create(font.TableRegister.NameTable.GetPostscriptName());
		PostScriptTable postScriptTable = font.TableRegister.PostScriptTable;
		HorizontalHeaderTable horizontalHeaderTable = font.TableRegister.HorizontalHeaderTable;
		PdfRectangle bounds = font.TableRegister.HeaderTable.Bounds;
		double num = 1000.0 / (double)(int)font.TableRegister.HeaderTable.UnitsPerEm;
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Type,
				NameToken.FontDescriptor
			},
			{
				NameToken.FontName,
				value2
			},
			{
				NameToken.Flags,
				new NumericToken(4)
			},
			{
				NameToken.FontBbox,
				GetBoundingBox(bounds, num)
			},
			{
				NameToken.ItalicAngle,
				new NumericToken(postScriptTable.ItalicAngle)
			},
			{
				NameToken.Ascent,
				new NumericToken(Math.Round((double)horizontalHeaderTable.Ascent * num, 2))
			},
			{
				NameToken.Descent,
				new NumericToken(Math.Round((double)horizontalHeaderTable.Descent * num, 2))
			},
			{
				NameToken.CapHeight,
				new NumericToken(90)
			},
			{
				NameToken.StemV,
				new NumericToken(90)
			},
			{
				NameToken.FontFile2,
				value
			}
		};
		if ((font.TableRegister.Os2Table ?? throw new InvalidFontFormatException("Embedding TrueType font requires OS/2 table.")) is Os2Version2To4OpenTypeTable os2Version2To4OpenTypeTable)
		{
			dictionary[NameToken.CapHeight] = new NumericToken(os2Version2To4OpenTypeTable.CapHeight);
			dictionary[NameToken.Xheight] = new NumericToken(os2Version2To4OpenTypeTable.XHeight);
		}
		dictionary[NameToken.StemV] = new NumericToken(bounds.Width * num * 0.13);
		int num2 = 0;
		List<NumericToken> list = new List<NumericToken> { NumericToken.Zero };
		foreach (KeyValuePair<char, byte> item in characterMapping)
		{
			if (item.Value > num2)
			{
				num2 = item.Value;
			}
			int index = font.WindowsUnicodeCMap.CharacterCodeToGlyphIndex(item.Key);
			double value3 = Math.Round((double)(int)font.TableRegister.HorizontalMetricsTable.GetAdvanceWidth(index) * num, 2);
			list.Add(new NumericToken(value3));
		}
		IndirectReferenceToken value4 = writer.WriteToken(new DictionaryToken(dictionary));
		StreamToken token2 = DataCompresser.CompressToStream(ToUnicodeCMapBuilder.ConvertToCMapStream(characterMapping));
		IndirectReferenceToken value5 = writer.WriteToken(token2);
		DictionaryToken token3 = new DictionaryToken(new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Type,
				NameToken.Font
			},
			{
				NameToken.Subtype,
				NameToken.TrueType
			},
			{
				NameToken.BaseFont,
				value2
			},
			{
				NameToken.FontDescriptor,
				value4
			},
			{
				NameToken.FirstChar,
				new NumericToken(0)
			},
			{
				NameToken.LastChar,
				new NumericToken(num2)
			},
			{
				NameToken.Widths,
				new ArrayToken(list)
			},
			{
				NameToken.ToUnicode,
				value5
			}
		});
		if (reservedIndirect != null)
		{
			return writer.WriteToken(token3, reservedIndirect);
		}
		return writer.WriteToken(token3);
	}

	public byte GetValueForCharacter(char character)
	{
		lock (mappingLock)
		{
			if (characterMapping.TryGetValue(character, out var value))
			{
				return value;
			}
			if (characterMappingCounter > 255)
			{
				throw new NotSupportedException("Cannot support more than 255 separate characters in a simple TrueType font, please submit an issue since we will need to add support for composite fonts with multi-byte character identifiers.");
			}
			byte b = (byte)characterMappingCounter++;
			characterMapping[character] = b;
			return b;
		}
	}

	private static ArrayToken GetBoundingBox(PdfRectangle boundingBox, double scaling)
	{
		return new ArrayToken(new NumericToken[4]
		{
			new NumericToken(Math.Round(boundingBox.Left * scaling, 2)),
			new NumericToken(Math.Round(boundingBox.Bottom * scaling, 2)),
			new NumericToken(Math.Round(boundingBox.Right * scaling, 2)),
			new NumericToken(Math.Round(boundingBox.Top * scaling, 2))
		});
	}
}
