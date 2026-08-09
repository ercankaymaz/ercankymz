using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts;

public class FontDescriptor
{
	public class Builder
	{
		public NameToken FontName { get; set; }

		public string? FontFamily { get; set; }

		public FontStretch Stretch { get; set; } = FontStretch.Normal;

		public double FontWeight { get; set; } = 400.0;

		public FontDescriptorFlags Flags { get; set; }

		public PdfRectangle BoundingBox { get; set; }

		public double ItalicAngle { get; set; }

		public double Ascent { get; set; }

		public double Descent { get; set; }

		public double Leading { get; set; }

		public double CapHeight { get; set; }

		public double XHeight { get; set; }

		public double StemVertical { get; set; }

		public double StemHorizontal { get; set; }

		public double AverageWidth { get; set; }

		public double MaxWidth { get; set; }

		public double MissingWidth { get; set; }

		public DescriptorFontFile? FontFile { get; set; }

		public string? CharSet { get; set; }

		public Builder(NameToken fontName, FontDescriptorFlags flags)
		{
			FontName = fontName;
			Flags = flags;
		}

		public FontDescriptor Build()
		{
			return new FontDescriptor(this);
		}
	}

	public NameToken FontName { get; }

	public string? FontFamily { get; }

	public FontStretch Stretch { get; }

	public double FontWeight { get; }

	public FontDescriptorFlags Flags { get; }

	public PdfRectangle BoundingBox { get; }

	public double ItalicAngle { get; }

	public double Ascent { get; }

	public double Descent { get; }

	public double Leading { get; }

	public double CapHeight { get; }

	public double XHeight { get; }

	public double StemVertical { get; }

	public double StemHorizontal { get; }

	public double AverageWidth { get; }

	public double MaxWidth { get; }

	public double MissingWidth { get; }

	public DescriptorFontFile? FontFile { get; }

	public string? CharSet { get; }

	public FontDescriptor(Builder builder)
	{
		FontName = builder.FontName;
		FontFamily = builder.FontFamily;
		Stretch = builder.Stretch;
		FontWeight = builder.FontWeight;
		Flags = builder.Flags;
		BoundingBox = builder.BoundingBox;
		ItalicAngle = builder.ItalicAngle;
		Ascent = builder.Ascent;
		Descent = builder.Descent;
		Leading = builder.Leading;
		CapHeight = builder.CapHeight;
		XHeight = builder.XHeight;
		StemVertical = builder.StemVertical;
		StemHorizontal = builder.StemHorizontal;
		AverageWidth = builder.AverageWidth;
		MaxWidth = builder.MaxWidth;
		MissingWidth = builder.MissingWidth;
		FontFile = builder.FontFile;
		CharSet = builder.CharSet;
	}

	internal FontDetails ToDetails(string? name = null)
	{
		object obj = name;
		if (obj == null)
		{
			NameToken fontName = FontName;
			obj = (((object)fontName != null) ? ((string)fontName) : string.Empty);
		}
		return new FontDetails((string?)obj, FontWeight > 500.0, (int)FontWeight, Flags.HasFlag(FontDescriptorFlags.Italic) || ItalicAngle != 0.0);
	}
}
