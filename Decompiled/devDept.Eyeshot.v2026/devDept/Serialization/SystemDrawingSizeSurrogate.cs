using System.Drawing;

namespace devDept.Serialization;

internal class SystemDrawingSizeSurrogate
{
	public int Width;

	public int Height;

	public SystemDrawingSizeSurrogate(int width, int height)
	{
		Width = width;
		Height = height;
	}

	public static implicit operator Size(SystemDrawingSizeSurrogate surrogate)
	{
		if (surrogate != null)
		{
			return new Size(surrogate.Width, surrogate.Height);
		}
		return Size.Empty;
	}

	public static implicit operator SystemDrawingSizeSurrogate(Size source)
	{
		return new SystemDrawingSizeSurrogate(source.Width, source.Height);
	}
}
