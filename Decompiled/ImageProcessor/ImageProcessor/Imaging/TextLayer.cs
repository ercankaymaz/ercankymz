using System;
using System.Drawing;
using System.Drawing.Text;

namespace ImageProcessor.Imaging;

public class TextLayer : IDisposable, IEquatable<TextLayer>
{
	private bool isDisposed = false;

	public string Text { get; set; }

	public Color FontColor { get; set; } = Color.Black;

	public FontFamily FontFamily { get; set; } = new FontFamily(GenericFontFamilies.SansSerif);

	public int FontSize { get; set; } = 48;

	public FontStyle Style { get; set; } = FontStyle.Regular;

	public int Opacity { get; set; } = 100;

	public Point? Position { get; set; }

	public bool DropShadow { get; set; }

	public bool Vertical { get; set; }

	public bool RightToLeft { get; set; }

	public override bool Equals(object obj)
	{
		return obj is TextLayer other && Equals(other);
	}

	public bool Equals(TextLayer other)
	{
		int result;
		if (other != null && Text == other.Text && FontColor == other.FontColor && ((FontFamily == null || other.FontFamily == null) ? (FontFamily == other.FontFamily) : FontFamily.Equals(other.FontFamily)) && FontSize == other.FontSize && Style == other.Style && Opacity == other.Opacity)
		{
			Point? position = Position;
			Point? position2 = other.Position;
			if (position.HasValue == position2.HasValue && (!position.HasValue || position.GetValueOrDefault() == position2.GetValueOrDefault()) && DropShadow == other.DropShadow && Vertical == other.Vertical)
			{
				result = ((RightToLeft == other.RightToLeft) ? 1 : 0);
				goto IL_0104;
			}
		}
		result = 0;
		goto IL_0104;
		IL_0104:
		return (byte)result != 0;
	}

	public override int GetHashCode()
	{
		return (Text, FontColor, FontFamily, FontSize, Style, Opacity, Position, DropShadow, Vertical, RightToLeft).GetHashCode();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!isDisposed)
		{
			if (disposing)
			{
				FontFamily?.Dispose();
			}
			isDisposed = true;
		}
	}
}
