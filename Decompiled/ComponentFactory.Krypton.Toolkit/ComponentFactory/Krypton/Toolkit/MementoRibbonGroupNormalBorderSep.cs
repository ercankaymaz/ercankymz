using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupNormalBorderSep : MementoRectFiveColor
{
	public LinearGradientBrush totalBrush;

	public LinearGradientBrush innerBrush;

	public LinearGradientBrush trackSepBrush;

	public LinearGradientBrush trackFillBrush;

	public PathGradientBrush trackHighlightBrush;

	public LinearGradientBrush pressedFillBrush;

	public Pen innerPen;

	public Pen trackSepPen;

	public Pen trackBottomPen;

	private bool _tracking;

	private bool _dark;

	public MementoRibbonGroupNormalBorderSep(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5, bool tracking, bool dark)
		: base(r, color1, color2, color3, color4, color5)
	{
		_tracking = tracking;
		_dark = dark;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5, bool tracking, bool dark)
	{
		bool result = UseCachedValues(r, color1, color2, color3, color4, color5) && _tracking == tracking && _dark == dark;
		_tracking = tracking;
		_dark = dark;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (totalBrush != null)
		{
			totalBrush.Dispose();
			innerBrush.Dispose();
			trackSepBrush.Dispose();
			trackFillBrush.Dispose();
			pressedFillBrush.Dispose();
			trackHighlightBrush.Dispose();
			innerPen.Dispose();
			trackSepPen.Dispose();
			trackBottomPen.Dispose();
			totalBrush = null;
			innerBrush = null;
			trackSepBrush = null;
			trackFillBrush = null;
			pressedFillBrush = null;
			trackHighlightBrush = null;
			innerPen = null;
			trackSepPen = null;
			trackBottomPen = null;
		}
		base.Dispose(disposing);
	}
}
