#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMonthDayNames : ViewLeaf, IContentValues
{
	private IKryptonMonthCalendar _calendar;

	private ViewLayoutMonths _months;

	private IDisposable[] _dayMementos;

	private string _drawText;

	public ViewDrawMonthDayNames(IKryptonMonthCalendar calendar, ViewLayoutMonths months)
	{
		_calendar = calendar;
		_months = months;
		_dayMementos = new IDisposable[7];
	}

	public override string ToString()
	{
		return "ViewDrawMonthDayNames:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		for (int i = 0; i < _dayMementos.Length; i++)
		{
			if (_dayMementos[i] != null)
			{
				_dayMementos[i].Dispose();
				_dayMementos[i] = null;
			}
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size empty = Size.Empty;
		empty.Width = _months.SizeDays.Width * 7;
		empty.Height = _months.SizeDays.Height;
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		PaletteState state = ((!Enabled) ? PaletteState.Disabled : PaletteState.Normal);
		Rectangle availableRect = new Rectangle(ClientLocation, _months.SizeDays);
		int num = 0;
		int num2 = (int)_months.DisplayDayOfWeek;
		while (num < 7)
		{
			_drawText = _months.DayNames[num2 % 7];
			if (_dayMementos[num] != null)
			{
				_dayMementos[num].Dispose();
			}
			_dayMementos[num] = context.Renderer.RenderStandardContent.LayoutContent(context, availableRect, _calendar.StateNormal.DayOfWeek.Content, this, VisualOrientation.Top, state, composition: false);
			availableRect.X += _months.SizeDays.Width;
			num++;
			num2++;
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		PaletteState state = ((!Enabled) ? PaletteState.Disabled : PaletteState.Normal);
		Rectangle displayRect = new Rectangle(ClientLocation, _months.SizeDays);
		int num = 0;
		int num2 = (int)_months.DisplayDayOfWeek;
		while (num < 7)
		{
			if (_dayMementos[num2 % 7] != null)
			{
				context.Renderer.RenderStandardContent.DrawContent(context, displayRect, _calendar.StateNormal.DayOfWeek.Content, _dayMementos[num2 % 7], VisualOrientation.Top, state, composition: false, allowFocusRect: true);
			}
			displayRect.X += _months.SizeDays.Width;
			num++;
			num2++;
		}
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return _drawText;
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
