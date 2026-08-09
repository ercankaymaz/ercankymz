#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutWeekCorner : ViewLeaf
{
	private IKryptonMonthCalendar _calendar;

	private ViewLayoutMonths _months;

	private PaletteBorder _palette;

	public ViewLayoutWeekCorner(IKryptonMonthCalendar calendar, ViewLayoutMonths months, PaletteBorder palette)
	{
		_calendar = calendar;
		_months = months;
		_palette = palette;
	}

	public override string ToString()
	{
		return "ViewLayoutWeekCorner:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size result = new Size(_months.SizeDay.Width, _months.SizeDays.Height);
		result.Width += _palette.GetBorderWidth(State);
		return result;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
	}
}
