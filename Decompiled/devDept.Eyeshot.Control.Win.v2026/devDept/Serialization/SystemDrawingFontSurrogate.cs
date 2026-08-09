using System.Drawing;

namespace devDept.Serialization;

internal class SystemDrawingFontSurrogate
{
	public string FamilyName;

	public float SizeInPoints;

	public FontStyle Style;

	public SystemDrawingFontSurrogate(string fontFamilyName, float sizeInPoints, FontStyle fontStyle)
	{
		FamilyName = fontFamilyName;
		SizeInPoints = sizeInPoints;
		Style = fontStyle;
	}

	public static implicit operator Font(SystemDrawingFontSurrogate surrogate)
	{
		if (surrogate != null)
		{
			return new Font(new FontFamily(surrogate.FamilyName), surrogate.SizeInPoints, surrogate.Style);
		}
		return null;
	}

	public static implicit operator SystemDrawingFontSurrogate(Font source)
	{
		if (source != null)
		{
			return new SystemDrawingFontSurrogate(source.FontFamily.Name, source.SizeInPoints, source.Style);
		}
		return null;
	}
}
