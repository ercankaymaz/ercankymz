namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;

internal class CompactFontFormatPrivateDictionary : AdobeStylePrivateDictionary
{
	public class Builder : BaseBuilder
	{
		public double InitialRandomSeed { get; set; }

		public int? LocalSubroutineOffset { get; set; }

		public double DefaultWidthX { get; set; }

		public double NominalWidthX { get; set; }

		public CompactFontFormatPrivateDictionary Build()
		{
			return new CompactFontFormatPrivateDictionary(this);
		}
	}

	public double InitialRandomSeed { get; }

	public int? LocalSubroutineOffset { get; }

	public double DefaultWidthX { get; }

	public double NominalWidthX { get; }

	public CompactFontFormatPrivateDictionary(Builder builder)
		: base(builder)
	{
		InitialRandomSeed = builder.InitialRandomSeed;
		LocalSubroutineOffset = builder.LocalSubroutineOffset;
		DefaultWidthX = builder.DefaultWidthX;
		NominalWidthX = builder.NominalWidthX;
	}

	public static CompactFontFormatPrivateDictionary GetDefault()
	{
		return new Builder().Build();
	}
}
