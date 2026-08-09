namespace Zen.Barcode;

public interface IVaryLengthGlyph : IBarGlyph, IGlyph
{
	short BitEncodingWidth { get; }
}
