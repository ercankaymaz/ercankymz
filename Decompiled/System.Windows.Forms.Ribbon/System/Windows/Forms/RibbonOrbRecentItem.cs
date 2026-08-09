using System.Drawing;

namespace System.Windows.Forms;

public class RibbonOrbRecentItem : RibbonButton
{
	public RibbonOrbRecentItem()
	{
	}

	public RibbonOrbRecentItem(string text)
		: this()
	{
		Text = text;
	}

	internal override Rectangle OnGetImageBounds(RibbonElementSizeMode sMode, Rectangle bounds)
	{
		return Rectangle.Empty;
	}

	internal override Rectangle OnGetTextBounds(RibbonElementSizeMode sMode, Rectangle bounds)
	{
		Rectangle result = base.OnGetTextBounds(sMode, bounds);
		result.X = base.Bounds.Left + 3;
		return result;
	}
}
