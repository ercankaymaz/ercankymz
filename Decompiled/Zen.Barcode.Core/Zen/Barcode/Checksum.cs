namespace Zen.Barcode;

public abstract class Checksum
{
	public virtual Glyph[] GetChecksum(string text)
	{
		return GetChecksum(text, allowComposite: false);
	}

	public virtual Glyph[] GetChecksum(string text, bool allowComposite)
	{
		return new Glyph[0];
	}
}
