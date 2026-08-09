using System;

namespace UglyToad.PdfPig.Fonts.TrueType.Glyphs;

[Flags]
public enum CompositeGlyphFlags : ushort
{
	Args1And2AreWords = 1,
	ArgsAreXAndYValues = 2,
	RoundXAndYToGrid = 4,
	WeHaveAScale = 8,
	Reserved = 0x10,
	MoreComponents = 0x20,
	WeHaveAnXAndYScale = 0x40,
	WeHaveATwoByTwo = 0x80,
	WeHaveInstructions = 0x100,
	UseMyMetrics = 0x200
}
