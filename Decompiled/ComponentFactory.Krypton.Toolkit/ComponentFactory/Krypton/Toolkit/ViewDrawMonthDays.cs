#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMonthDays : ViewLeaf, IContentValues
{
	private static readonly int WEEKS = 6;

	private static readonly int WEEKDAYS = 7;

	private static readonly int DAYS = 42;

	private static readonly TimeSpan TIMESPAN_1DAY = new TimeSpan(1, 0, 0, 0);

	private IKryptonMonthCalendar _calendar;

	private ViewLayoutMonths _months;

	private IDisposable[] _dayMementos;

	private Rectangle[] _dayRects;

	private DateTime _lastDay;

	private DateTime _firstDay;

	private DateTime _month;

	private bool _firstMonth;

	private bool _lastMonth;

	private string _drawText;

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
		}
	}

	public ViewDrawMonthDays(IKryptonMonthCalendar calendar, ViewLayoutMonths months)
	{
		_calendar = calendar;
		_months = months;
		_dayMementos = new IDisposable[DAYS];
		_dayRects = new Rectangle[DAYS];
	}

	public override string ToString()
	{
		return "ViewDrawMonthDays:" + base.Id;
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

	public DateTime? DayFromPoint(Point pt, bool exact)
	{
		for (int i = 0; i < DAYS; i++)
		{
			if (_dayMementos[i] != null && _dayRects[i].Contains(pt))
			{
				DateTime dateTime = _firstDay.AddDays(i);
				if (!exact || (dateTime >= _month && dateTime <= _lastDay))
				{
					return dateTime;
				}
			}
		}
		return null;
	}

	public DateTime DayNearPoint(Point pt)
	{
		DateTime dateTime = _month;
		DateTime? dateTime2 = DayFromPoint(pt, exact: true);
		if (dateTime2.HasValue)
		{
			dateTime = dateTime2.Value;
		}
		else if (pt.Y > ClientLocation.Y)
		{
			if (pt.Y > ClientRectangle.Bottom)
			{
				dateTime = _month.AddMonths(1).AddDays(-1.0);
			}
			else
			{
				for (int i = 0; i < WEEKS; i++)
				{
					if (pt.Y < _dayRects[i * WEEKDAYS].Bottom)
					{
						DateTime dateTime3 = _firstDay.AddDays(i * WEEKDAYS);
						if (pt.X < ClientLocation.X)
						{
							dateTime = dateTime3;
							break;
						}
						if (pt.X >= ClientRectangle.Right)
						{
							dateTime = dateTime3.AddDays(WEEKDAYS - 1);
							break;
						}
						int num = (pt.X - ClientLocation.X) / _dayRects[i * WEEKDAYS].Width;
						dateTime = dateTime3.AddDays(num);
						break;
					}
				}
			}
		}
		if (dateTime > _lastDay)
		{
			return _lastDay;
		}
		if (dateTime < _month)
		{
			return _month;
		}
		return dateTime;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return new Size(_months.SizeDays.Width * WEEKDAYS, _months.SizeDays.Height * WEEKS);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		DateTime date = _calendar.MinDate.Date;
		DateTime date2 = _calendar.MaxDate.Date;
		DateTime date3 = _calendar.SelectionStart.Date;
		DateTime date4 = _calendar.SelectionEnd.Date;
		ClientRectangle = context.DisplayRectangle;
		int x = ClientLocation.X;
		int x2 = ClientLocation.X + (_months.SizeDays.Width - _months.SizeDay.Width) / 2;
		Rectangle rectangle = new Rectangle(x, ClientLocation.Y, _months.SizeDays.Width, _months.SizeDays.Height);
		Rectangle availableRect = new Rectangle(x2, ClientLocation.Y, _months.SizeDay.Width, _months.SizeDays.Height);
		DateTime todayDate = _calendar.TodayDate;
		DateTime firstDay = _firstDay;
		for (int i = 0; i < WEEKS; i++)
		{
			for (int j = 0; j < WEEKDAYS; j++)
			{
				int num = i * WEEKDAYS + j;
				_drawText = firstDay.Day.ToString();
				if (_dayMementos[num] != null)
				{
					_dayMementos[num].Dispose();
					_dayMementos[num] = null;
				}
				bool flag = false;
				PaletteState paletteState = PaletteState.Normal;
				IPaletteTriple paletteTriple = _calendar.OverrideNormal;
				if (firstDay < date || firstDay > date2)
				{
					flag = true;
				}
				else
				{
					_calendar.SetFocusOverride(focus: false);
					_calendar.SetBoldedOverride(BoldedDate(firstDay));
					_calendar.SetTodayOverride(_months.ShowTodayCircle && firstDay == todayDate);
					if (firstDay.Month != _month.Month)
					{
						if ((i < 3 && _firstMonth) || (i > 3 && _lastMonth))
						{
							paletteState = PaletteState.Disabled;
							paletteTriple = _calendar.OverrideDisabled;
						}
						else
						{
							flag = true;
						}
					}
					else if (firstDay >= date3 && firstDay <= date4)
					{
						_calendar.SetFocusOverride(_months.FocusDay.HasValue && _months.FocusDay.Value == firstDay);
						if (_months.TrackingDay.HasValue && _months.TrackingDay.Value == firstDay)
						{
							paletteState = PaletteState.CheckedTracking;
							paletteTriple = _calendar.OverrideCheckedTracking;
						}
						else
						{
							paletteState = PaletteState.CheckedNormal;
							paletteTriple = _calendar.OverrideCheckedNormal;
						}
					}
					else if (_months.TrackingDay.HasValue && _months.TrackingDay.Value == firstDay)
					{
						paletteState = PaletteState.Tracking;
						paletteTriple = _calendar.OverrideTracking;
					}
				}
				if (!flag)
				{
					_dayMementos[num] = context.Renderer.RenderStandardContent.LayoutContent(context, availableRect, paletteTriple.PaletteContent, this, VisualOrientation.Top, paletteState, composition: false);
					if (paletteState != PaletteState.Disabled)
					{
						_lastDay = firstDay;
					}
				}
				_dayRects[num] = rectangle;
				rectangle.X += _months.SizeDays.Width;
				availableRect.X += _months.SizeDays.Width;
				firstDay += TIMESPAN_1DAY;
			}
			rectangle.X = x;
			rectangle.Y += _months.SizeDays.Height;
			availableRect.X = x2;
			availableRect.Y += _months.SizeDays.Height;
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		DateTime date = _calendar.MinDate.Date;
		DateTime date2 = _calendar.MaxDate.Date;
		DateTime date3 = _calendar.SelectionStart.Date;
		DateTime date4 = _calendar.SelectionEnd.Date;
		int x = ClientLocation.X;
		int x2 = ClientLocation.X + (_months.SizeDays.Width - _months.SizeDay.Width) / 2;
		Rectangle rect = new Rectangle(x, ClientLocation.Y, _months.SizeDays.Width, _months.SizeDays.Height);
		Rectangle displayRect = new Rectangle(x2, ClientLocation.Y, _months.SizeDay.Width, _months.SizeDays.Height);
		DateTime todayDate = _calendar.TodayDate;
		DateTime firstDay = _firstDay;
		for (int i = 0; i < WEEKS; i++)
		{
			for (int j = 0; j < WEEKDAYS; j++)
			{
				int num = i * WEEKDAYS + j;
				if (_dayMementos[num] != null)
				{
					bool flag = false;
					PaletteState state = PaletteState.Normal;
					IPaletteTriple paletteTriple = _calendar.OverrideNormal;
					if (firstDay < date || firstDay > date2)
					{
						flag = true;
					}
					else
					{
						_calendar.SetFocusOverride(focus: false);
						_calendar.SetBoldedOverride(BoldedDate(firstDay));
						_calendar.SetTodayOverride(_months.ShowTodayCircle && firstDay == todayDate);
						if (firstDay.Month != _month.Month)
						{
							if ((i < 3 && _firstMonth) || (i > 3 && _lastMonth))
							{
								state = PaletteState.Disabled;
								paletteTriple = _calendar.OverrideDisabled;
							}
							else
							{
								flag = true;
							}
						}
						else if (firstDay >= date3 && firstDay <= date4)
						{
							_calendar.SetFocusOverride(_months.FocusDay.HasValue && _months.FocusDay.Value == firstDay);
							if (_months.TrackingDay.HasValue && _months.TrackingDay.Value == firstDay)
							{
								state = PaletteState.CheckedTracking;
								paletteTriple = _calendar.OverrideCheckedTracking;
							}
							else
							{
								state = PaletteState.CheckedNormal;
								paletteTriple = _calendar.OverrideCheckedNormal;
							}
						}
						else if (_months.TrackingDay.HasValue && _months.TrackingDay.Value == firstDay)
						{
							state = PaletteState.Tracking;
							paletteTriple = _calendar.OverrideTracking;
						}
					}
					if (!flag)
					{
						if (paletteTriple.PaletteBack.GetBackDraw(state) == InheritBool.True)
						{
							using GraphicsPath path = context.Renderer.RenderStandardBorder.GetBackPath(context, rect, paletteTriple.PaletteBorder, VisualOrientation.Top, state);
							context.Renderer.RenderStandardBack.DrawBack(context, rect, path, paletteTriple.PaletteBack, VisualOrientation.Top, state, null);
						}
						if (paletteTriple.PaletteBorder.GetBorderDraw(state) == InheritBool.True)
						{
							context.Renderer.RenderStandardBorder.DrawBorder(context, rect, paletteTriple.PaletteBorder, VisualOrientation.Top, state);
						}
						if (paletteTriple.PaletteContent.GetContentDraw(state) == InheritBool.True)
						{
							context.Renderer.RenderStandardContent.DrawContent(context, displayRect, paletteTriple.PaletteContent, _dayMementos[num], VisualOrientation.Top, state, composition: false, allowFocusRect: true);
						}
					}
				}
				rect.X += _months.SizeDays.Width;
				displayRect.X += _months.SizeDays.Width;
				firstDay += TIMESPAN_1DAY;
			}
			rect.X = x;
			rect.Y += _months.SizeDays.Height;
			displayRect.X = x2;
			displayRect.Y += _months.SizeDays.Height;
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

	private bool BoldedDate(DateTime date)
	{
		int num = 1 << date.Day - 1;
		if ((num & _calendar.MonthlyBoldedDatesMask) != 0)
		{
			return true;
		}
		if ((num & _calendar.AnnuallyBoldedDatesMask[date.Month - 1]) != 0)
		{
			return true;
		}
		foreach (DateTime boldedDates in _calendar.BoldedDatesList)
		{
			if (boldedDates == date)
			{
				return true;
			}
		}
		return false;
	}
}
