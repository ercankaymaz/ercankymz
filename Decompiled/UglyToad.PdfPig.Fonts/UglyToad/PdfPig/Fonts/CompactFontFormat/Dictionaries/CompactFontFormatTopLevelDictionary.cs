using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;

internal sealed class CompactFontFormatTopLevelDictionary
{
	public readonly struct SizeAndOffset
	{
		public int Size { get; }

		public int Offset { get; }

		public SizeAndOffset(int size, int offset)
		{
			Size = size;
			Offset = offset;
		}

		public override string ToString()
		{
			return $"Size: {Size}, Offset: {Offset}";
		}
	}

	public const int UnsetOffset = -1;

	public string Version { get; set; }

	public string Notice { get; set; }

	public string Copyright { get; set; }

	public string FullName { get; set; }

	public string FamilyName { get; set; }

	public string Weight { get; set; }

	public bool IsFixedPitch { get; set; }

	public double ItalicAngle { get; set; }

	public double UnderlinePosition { get; set; } = -100.0;

	public double UnderlineThickness { get; set; } = 50.0;

	public double PaintType { get; set; }

	public CompactFontFormatCharStringType CharStringType { get; set; } = CompactFontFormatCharStringType.Type2;

	public TransformationMatrix? FontMatrix { get; set; }

	public double StrokeWidth { get; set; }

	public double UniqueId { get; set; }

	public PdfRectangle FontBoundingBox { get; set; } = new PdfRectangle(0, 0, 0, 0);

	public double[] Xuid { get; set; }

	public int CharSetOffset { get; set; } = -1;

	public int EncodingOffset { get; set; } = -1;

	public SizeAndOffset? PrivateDictionaryLocation { get; set; }

	public int CharStringsOffset { get; set; } = -1;

	public int SyntheticBaseFontIndex { get; set; }

	public string PostScript { get; set; }

	public string BaseFontName { get; set; }

	public double[] BaseFontBlend { get; set; }

	public bool IsCidFont { get; set; }

	public CidFontOperators CidFontOperators { get; set; } = new CidFontOperators();
}
