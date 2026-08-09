using System.Drawing;

namespace devDept.Serialization;

internal class SystemDrawingColorSurrogate
{
	public int Argb;

	public SystemDrawingColorSurrogate(int argb)
	{
		Argb = argb;
	}

	public static implicit operator Color(SystemDrawingColorSurrogate surrogate)
	{
		if (surrogate != null)
		{
			return Color.FromArgb(surrogate.Argb);
		}
		return Color.Empty;
	}

	public static implicit operator SystemDrawingColorSurrogate(Color source)
	{
		return new SystemDrawingColorSurrogate(source.ToArgb());
	}
}
