using System.Windows.Forms;
using DevAge.Drawing;

namespace DevAge.Windows.Forms;

public class Utilities
{
	public static HorizontalAlignment ContentToHorizontalAlignment(ContentAlignment a)
	{
		if (!DevAge.Drawing.Utilities.IsLeft(a))
		{
			if (!DevAge.Drawing.Utilities.IsRight(a))
			{
				return HorizontalAlignment.Center;
			}
			return HorizontalAlignment.Right;
		}
		return HorizontalAlignment.Left;
	}

	public static TextFormatFlags ContentAligmentToTextFormatFlags(ContentAlignment a)
	{
		TextFormatFlags textFormatFlags = TextFormatFlags.Default;
		textFormatFlags = (DevAge.Drawing.Utilities.IsBottom(a) ? (textFormatFlags | TextFormatFlags.Bottom) : (DevAge.Drawing.Utilities.IsTop(a) ? (textFormatFlags | TextFormatFlags.Default) : (textFormatFlags | TextFormatFlags.VerticalCenter)));
		if (!DevAge.Drawing.Utilities.IsLeft(a))
		{
			if (!DevAge.Drawing.Utilities.IsRight(a))
			{
				return textFormatFlags | TextFormatFlags.HorizontalCenter;
			}
			return textFormatFlags | TextFormatFlags.Right;
		}
		return textFormatFlags | TextFormatFlags.Default;
	}
}
