#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawWeekNumbers : ViewLeaf, IContentValues
{
	private static readonly int WEEKS = 6;

	private static readonly TimeSpan TIMESPAN_1DAY = new TimeSpan(1, 0, 0, 0);

	private static readonly TimeSpan TIMESPAN_6DAYS = new TimeSpan(6, 0, 0, 0);

	private static readonly TimeSpan TIMESPAN_1WEEK = new TimeSpan(7, 0, 0, 0);

	private IKryptonMonthCalendar _calendar;

	private ViewLayoutMonths _months;

	private IDisposable[] _dayMementos;

	private string _drawText;

	private DateTime _firstDay;

	private DateTime _weekDay;

	private DateTime _month;

	private bool _firstMonth;

	private bool _lastMonth;

	public bool FirstMonth
	{
		set
		{
			_firstMonth = value;
		}
	}

	public bool LastMonth
	{
		set
		{
			_lastMonth = value;
		}
	}

	public DateTime Month
	{
		set
		{
			_month = value;
			_firstDay = new DateTime(value.Year, value.Month, 1);
			_firstDay -= TIMESPAN_1DAY;
			while (_firstDay.DayOfWeek != _months.DisplayDayOfWeek)
			{
				_firstDay -= TIMESPAN_1DAY;
			}
			DateTime dateTime = new DateTime(value.Year, 1, 1);
			_weekDay = _firstDay;
			while (_weekDay.DayOfWeek != dateTime.DayOfWeek)
			{
				_weekDay += TIMESPAN_1DAY;
			}
		}
	}

	public ViewDrawWeekNumbers(IKryptonMonthCalendar calendar, ViewLayoutMonths months)
	{
		_drawText = string.Empty;
		_calendar = calendar;
		_months = months;
		_dayMementos = new IDisposable[WEEKS];
	}

	public override string ToString()
	{
		return "ViewDrawWeekNumbers:" + base.Id;
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
		return new Size(_months.SizeDay.Width, _months.SizeDays.Height * WEEKS);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		_calendar.SetFocusOverride(focus: false);
		_calendar.SetBoldedOverride(bolded: false);
		Rectangle availableRect = new Rectangle(ClientLocation.X, ClientLocation.Y, _months.SizeDay.Width, _months.SizeDays.Height);
		DateTime weekDay = _weekDay;
		DateTime firstDay = _firstDay;
		for (int i = 0; i < WEEKS; i++)
		{
			DateTime weekDate = weekDay;
			if (DisplayWeekNumber(firstDay, ref weekDate))
			{
				_drawText = GetWeekNumber(weekDate).ToString();
				if (_dayMementos[i] != null)
				{
					_dayMementos[i].Dispose();
					_dayMementos[i] = null;
				}
				PaletteState state = ((!Enabled) ? PaletteState.Disabled : PaletteState.Normal);
				IPaletteTriple paletteTriple = (Enabled ? _calendar.StateNormal.Day : _calendar.StateDisabled.Day);
				_dayMementos[i] = context.Renderer.RenderStandardContent.LayoutContent(context, availableRect, paletteTriple.PaletteContent, this, VisualOrientation.Top, state, composition: false);
			}
			weekDay += TIMESPAN_1WEEK;
			firstDay += TIMESPAN_1WEEK;
			availableRect.Y += _months.SizeDays.Height;
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		_calendar.SetFocusOverride(focus: false);
		_calendar.SetBoldedOverride(bolded: false);
		Rectangle rectangle = new Rectangle(ClientLocation.X, ClientLocation.Y, _months.SizeDay.Width, _months.SizeDays.Height);
		DateTime weekDay = _weekDay;
		DateTime firstDay = _firstDay;
		for (int i = 0; i < WEEKS; i++)
		{
			DateTime weekDate = weekDay;
			if (DisplayWeekNumber(firstDay, ref weekDate))
			{
				_drawText = GetWeekNumber(weekDate).ToString();
				PaletteState state = ((!Enabled) ? PaletteState.Disabled : PaletteState.Normal);
				IPaletteTriple paletteTriple = (Enabled ? _calendar.StateNormal.Day : _calendar.StateDisabled.Day);
				if (paletteTriple.PaletteBack.GetBackDraw(state) == InheritBool.True)
				{
					using GraphicsPath path = context.Renderer.RenderStandardBorder.GetBackPath(context, rectangle, paletteTriple.PaletteBorder, VisualOrientation.Top, state);
					context.Renderer.RenderStandardBack.DrawBack(context, rectangle, path, paletteTriple.PaletteBack, VisualOrientation.Top, state, null);
				}
				if (paletteTriple.PaletteBorder.GetBorderDraw(state) == InheritBool.True)
				{
					context.Renderer.RenderStandardBorder.DrawBorder(context, rectangle, paletteTriple.PaletteBorder, VisualOrientation.Top, state);
				}
				if (paletteTriple.PaletteContent.GetContentDraw(state) == InheritBool.True)
				{
					context.Renderer.RenderStandardContent.DrawContent(context, rectangle, paletteTriple.PaletteContent, _dayMementos[i], VisualOrientation.Top, state, composition: false, allowFocusRect: true);
				}
			}
			weekDay += TIMESPAN_1WEEK;
			firstDay += TIMESPAN_1WEEK;
			rectangle.Y += _months.SizeDays.Height;
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

	private int GetWeekNumber(DateTime dt)
	{
		return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dt, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, _months.DisplayDayOfWeek);
	}

	private bool DisplayWeekNumber(DateTime displayDate, ref DateTime weekDate)
	{
		if (displayDate < _month)
		{
			displayDate += TIMESPAN_6DAYS;
			if (displayDate < _month)
			{
				return _firstMonth;
			}
			weekDate = _month;
		}
		else
		{
			DateTime dateTime = _month.AddMonths(1);
			DateTime dateTime2 = displayDate + TIMESPAN_6DAYS;
			if (dateTime2 >= dateTime)
			{
				if (displayDate >= dateTime)
				{
					return _lastMonth;
				}
				weekDate = dateTime.AddDays(-1.0);
			}
		}
		return true;
	}
}
