using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class NullContentValues : IContentValues
{
	public virtual string GetShortText()
	{
		return string.Empty;
	}

	public virtual Image GetImage(PaletteState state)
	{
		return null;
	}

	public virtual Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public virtual string GetLongText()
	{
		return string.Empty;
	}
}
