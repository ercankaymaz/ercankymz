#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ComponentFactory.Krypton.Toolkit;

public class AccurateText : GlobalId
{
	private static readonly int GLOW_EXTRA_WIDTH = 14;

	private static readonly int GLOW_EXTRA_HEIGHT = 3;

	public static AccurateTextMemento MeasureString(Graphics g, RightToLeft rtl, string text, Font font, PaletteTextTrim trim, PaletteRelativeAlign align, PaletteTextHotkeyPrefix prefix, TextRenderingHint hint, bool composition, bool disposeFont)
	{
		Debug.Assert(g != null);
		Debug.Assert(text != null);
		Debug.Assert(font != null);
		if (g == null)
		{
			throw new ArgumentNullException("g");
		}
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (text.Length == 0)
		{
			return AccurateTextMemento.Empty;
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.FormatFlags = StringFormatFlags.NoClip;
		if (rtl == RightToLeft.Yes)
		{
			stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
		}
		switch (align)
		{
		case PaletteRelativeAlign.Near:
			stringFormat.Alignment = ((rtl == RightToLeft.Yes) ? StringAlignment.Far : StringAlignment.Near);
			break;
		case PaletteRelativeAlign.Center:
			stringFormat.Alignment = StringAlignment.Center;
			break;
		case PaletteRelativeAlign.Far:
			stringFormat.Alignment = ((rtl != RightToLeft.Yes) ? StringAlignment.Far : StringAlignment.Near);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		switch (trim)
		{
		case PaletteTextTrim.Character:
			stringFormat.Trimming = StringTrimming.Character;
			break;
		case PaletteTextTrim.EllipsisCharacter:
			stringFormat.Trimming = StringTrimming.EllipsisCharacter;
			break;
		case PaletteTextTrim.EllipsisPath:
			stringFormat.Trimming = StringTrimming.EllipsisPath;
			break;
		case PaletteTextTrim.EllipsisWord:
			stringFormat.Trimming = StringTrimming.EllipsisWord;
			break;
		case PaletteTextTrim.Word:
			stringFormat.Trimming = StringTrimming.Word;
			break;
		case PaletteTextTrim.Hide:
			stringFormat.Trimming = StringTrimming.None;
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		switch (prefix)
		{
		case PaletteTextHotkeyPrefix.None:
			stringFormat.HotkeyPrefix = HotkeyPrefix.None;
			break;
		case PaletteTextHotkeyPrefix.Hide:
			stringFormat.HotkeyPrefix = HotkeyPrefix.Hide;
			break;
		case PaletteTextHotkeyPrefix.Show:
			stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		text = text.Replace("\t", "    ");
		using (new GraphicsTextHint(g, hint))
		{
			SizeF sizeF = Size.Empty;
			try
			{
				sizeF = g.MeasureString(text, font, int.MaxValue, stringFormat);
				if (composition)
				{
					sizeF.Width += GLOW_EXTRA_WIDTH;
				}
			}
			catch
			{
			}
			return new AccurateTextMemento(text, font, sizeF, stringFormat, hint, disposeFont);
		}
	}

	public static bool DrawString(Graphics g, Brush brush, Rectangle rect, RightToLeft rtl, VisualOrientation orientation, bool composition, PaletteState state, AccurateTextMemento memento)
	{
		Debug.Assert(g != null);
		Debug.Assert(memento != null);
		if (g == null)
		{
			throw new ArgumentNullException("g");
		}
		if (memento == null)
		{
			throw new ArgumentNullException("memento");
		}
		bool result = true;
		if (rect.Width > 0 && rect.Height > 0 && !memento.IsEmpty)
		{
			int num = 0;
			int num2 = 0;
			float num3 = 0f;
			switch (orientation)
			{
			case VisualOrientation.Bottom:
				num = rect.X * 2 + rect.Width;
				num2 = rect.Y * 2 + rect.Height;
				num3 = 180f;
				break;
			case VisualOrientation.Left:
				rect = new Rectangle(rect.X, rect.Y, rect.Height, rect.Width);
				num = rect.X - rect.Y - 1;
				num2 = rect.X + rect.Y + rect.Width;
				num3 = 270f;
				break;
			case VisualOrientation.Right:
				rect = new Rectangle(rect.X, rect.Y, rect.Height, rect.Width);
				num = rect.X + rect.Y + rect.Height + 1;
				num2 = -(rect.X - rect.Y);
				num3 = 90f;
				break;
			}
			if (num != 0 || num2 != 0)
			{
				g.TranslateTransform(num, num2);
			}
			if (num3 != 0f)
			{
				g.RotateTransform(num3);
			}
			try
			{
				if (composition)
				{
					DrawCompositionGlowingText(g, memento.Text, memento.Font, rect, state, SystemColors.ActiveCaptionText, copyBackground: true);
				}
				else
				{
					g.DrawString(memento.Text, memento.Font, brush, rect, memento.Format);
				}
			}
			catch
			{
				result = false;
			}
			finally
			{
				if (num3 != 0f)
				{
					g.RotateTransform(0f - num3);
				}
				if (num != 0 || num2 != 0)
				{
					g.TranslateTransform(-num, -num2);
				}
			}
		}
		return result;
	}

	public static void DrawCompositionGlowingText(Graphics g, string text, Font font, Rectangle bounds, PaletteState state, Color color, bool copyBackground)
	{
		try
		{
			IntPtr hdc = g.GetHdc();
			IntPtr intPtr = PI.CreateCompatibleDC(hdc);
			PI.BITMAPINFO bITMAPINFO = new PI.BITMAPINFO();
			bITMAPINFO.biSize = Marshal.SizeOf((object)bITMAPINFO);
			bITMAPINFO.biWidth = bounds.Width;
			bITMAPINFO.biHeight = -(bounds.Height + GLOW_EXTRA_HEIGHT * 2);
			bITMAPINFO.biCompression = 0;
			bITMAPINFO.biBitCount = 32;
			bITMAPINFO.biPlanes = 1;
			IntPtr hObject = PI.CreateDIBSection(hdc, bITMAPINFO, 0u, 0, IntPtr.Zero, 0u);
			PI.SelectObject(intPtr, hObject);
			if (copyBackground)
			{
				PI.BitBlt(intPtr, 0, 0, bounds.Width, bounds.Height + GLOW_EXTRA_HEIGHT * 2, hdc, bounds.X, bounds.Y - GLOW_EXTRA_HEIGHT, 13369376);
			}
			IntPtr hObject2 = font.ToHfont();
			PI.SelectObject(intPtr, hObject2);
			VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer((state == PaletteState.Normal) ? VisualStyleElement.Window.Caption.Active : VisualStyleElement.Window.Caption.Inactive);
			PI.RECT pRect = new PI.RECT
			{
				left = 0,
				top = 0,
				right = bounds.Right - bounds.Left,
				bottom = bounds.Bottom - bounds.Top + GLOW_EXTRA_HEIGHT * 2
			};
			PI.DTTOPTS pOptions = new PI.DTTOPTS
			{
				dwSize = Marshal.SizeOf(typeof(PI.DTTOPTS)),
				dwFlags = 10241,
				crText = ColorTranslator.ToWin32(color),
				iGlowSize = 11
			};
			TextFormatFlags dwFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter;
			PI.DrawThemeTextEx(visualStyleRenderer.Handle, intPtr, 0, 0, text, -1, (int)dwFlags, ref pRect, ref pOptions);
			PI.BitBlt(hdc, bounds.Left, bounds.Top - GLOW_EXTRA_HEIGHT, bounds.Width, bounds.Height + GLOW_EXTRA_HEIGHT * 2, intPtr, 0, 0, 13369376);
			PI.DeleteObject(hObject2);
			PI.DeleteObject(hObject);
			PI.DeleteDC(intPtr);
			g.ReleaseHdc(hdc);
		}
		catch
		{
		}
	}
}
