using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.AdobeFontMetrics;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer.Fonts;

internal sealed class Standard14WritingFont : IWritingFont
{
	private readonly AdobeFontMetrics metrics;

	public bool HasWidths { get; }

	public string Name => metrics.FontName;

	public Standard14WritingFont(AdobeFontMetrics metrics)
	{
		this.metrics = metrics;
	}

	public bool TryGetBoundingBox(char character, out PdfRectangle boundingBox)
	{
		boundingBox = default(PdfRectangle);
		int code = CodeMapIfUnicode(character);
		if (code == -1)
		{
			return false;
		}
		AdobeFontMetricsIndividualCharacterMetric adobeFontMetricsIndividualCharacterMetric = (from v in metrics.CharacterMetrics
			where v.Value.CharacterCode == code
			select v.Value).FirstOrDefault();
		if (adobeFontMetricsIndividualCharacterMetric == null)
		{
			return false;
		}
		boundingBox = new PdfRectangle(adobeFontMetricsIndividualCharacterMetric.BoundingBox.Left, adobeFontMetricsIndividualCharacterMetric.BoundingBox.Bottom, adobeFontMetricsIndividualCharacterMetric.BoundingBox.Left + adobeFontMetricsIndividualCharacterMetric.Width.X, adobeFontMetricsIndividualCharacterMetric.BoundingBox.Top);
		return true;
	}

	public bool TryGetAdvanceWidth(char character, out double width)
	{
		width = 0.0;
		if (!TryGetBoundingBox(character, out var boundingBox))
		{
			return false;
		}
		width = boundingBox.Width;
		return true;
	}

	public TransformationMatrix GetFontMatrix()
	{
		return TransformationMatrix.FromValues(0.001, 0.0, 0.0, 0.001, 0.0, 0.0);
	}

	public IndirectReferenceToken WriteFont(IPdfStreamWriter writer, IndirectReferenceToken? reservedIndirect = null)
	{
		NameToken value = NameToken.StandardEncoding;
		if (string.Equals(metrics.FontName, "Symbol", StringComparison.OrdinalIgnoreCase) || string.Equals(metrics.FontName, "ZapfDingbats", StringComparison.OrdinalIgnoreCase))
		{
			value = NameToken.Create("FontSpecific");
		}
		DictionaryToken token = new DictionaryToken(new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Type,
				NameToken.Font
			},
			{
				NameToken.Subtype,
				NameToken.Type1
			},
			{
				NameToken.BaseFont,
				NameToken.Create(metrics.FontName)
			},
			{
				NameToken.Encoding,
				value
			}
		});
		if (reservedIndirect != null)
		{
			return writer.WriteToken(token, reservedIndirect);
		}
		return writer.WriteToken(token);
	}

	public byte GetValueForCharacter(char character)
	{
		int characterCode = CodeMapIfUnicode(character);
		return (byte)((from v in metrics.CharacterMetrics
			where v.Value.CharacterCode == characterCode
			select v.Value).FirstOrDefault() ?? throw new NotSupportedException($"Font '{metrics.FontName}' does NOT have character '{character}' (0x{(int)character:X}).")).CharacterCode;
	}

	private int UnicodeToSymbolCode(char character)
	{
		string text = GlyphList.AdobeGlyphList.UnicodeCodePointToName(character);
		if (string.Equals(text, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return -1;
		}
		int code = SymbolEncoding.Instance.GetCode(text);
		_ = -1;
		return code;
	}

	private int UnicodeToZapfDingbats(char character)
	{
		string text = GlyphList.ZapfDingbats.UnicodeCodePointToName(character);
		if (string.Equals(text, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return -1;
		}
		int code = ZapfDingbatsEncoding.Instance.GetCode(text);
		_ = -1;
		return code;
	}

	private int UnicodeToStandardEncoding(char character)
	{
		string text = GlyphList.AdobeGlyphList.UnicodeCodePointToName(character);
		if (string.Equals(text, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return -1;
		}
		StandardEncoding instance = StandardEncoding.Instance;
		int code = instance.GetCode(text);
		if (code == -1)
		{
			string name = (char.IsUpper(text[0]) ? (char.ToLower(text[0]) + text.Substring(1)) : (char.ToUpper(text[0]) + text.Substring(1)));
			code = instance.GetCode(name);
			_ = -1;
		}
		return code;
	}

	private int CodeMapIfUnicode(char character)
	{
		int i = character;
		if (string.Equals(metrics.FontName, "ZapfDingbats", StringComparison.OrdinalIgnoreCase))
		{
			return (i < 255) ? i : UnicodeToZapfDingbats(character);
		}
		if (string.Equals(metrics.FontName, "Symbol", StringComparison.OrdinalIgnoreCase))
		{
			if (i == 172)
			{
				return 216;
			}
			if (i == 247)
			{
				return 184;
			}
			if (i == 181)
			{
				return 109;
			}
			if (i == 215)
			{
				return 180;
			}
			return (i < 255) ? i : UnicodeToSymbolCode(character);
		}
		if (i == 198)
		{
			return 225;
		}
		if (i == 180)
		{
			return 194;
		}
		if (i == 183)
		{
			return 180;
		}
		if (i == 184)
		{
			return 203;
		}
		if (i == 164)
		{
			return 168;
		}
		if (i == 168)
		{
			return 200;
		}
		if (i == 96)
		{
			return 193;
		}
		if (i == 175)
		{
			return 197;
		}
		if (i == 170)
		{
			return 227;
		}
		if (i == 186)
		{
			return 235;
		}
		if (i == 248)
		{
			return 249;
		}
		if (i == 39)
		{
			return 169;
		}
		return metrics.CharacterMetrics.Any<KeyValuePair<string, AdobeFontMetricsIndividualCharacterMetric>>((KeyValuePair<string, AdobeFontMetricsIndividualCharacterMetric> v) => v.Value.CharacterCode == i) ? i : UnicodeToStandardEncoding(character);
	}
}
