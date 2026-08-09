#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMenuMonthCalendar : ViewComposite, IKryptonMonthCalendar
{
	private KryptonContextMenuMonthCalendar _monthCalendar;

	private IContextMenuProvider _provider;

	private ViewLayoutMonths _layoutMonths;

	private DateTime _minDate;

	private DateTime _maxDate;

	private DateTime _todayDate;

	private string _todayFormat;

	private Day _firstDayOfWeek;

	private Size _dimensions;

	private bool _itemEnabled;

	private int _maxSelectionCount;

	private int _scrollChange;

	private string _todayText;

	public Control CalendarControl => _provider.ProviderViewManager.Control;

	public bool InDesignMode => false;

	public GetToolStripRenderer GetToolStripDelegate
	{
		get
		{
			VisualContextMenu visualContextMenu = (VisualContextMenu)_provider.ProviderViewManager.Control;
			return visualContextMenu.CreateToolStripRenderer;
		}
	}

	public Size CalendarDimensions => _dimensions;

	public Day FirstDayOfWeek => _firstDayOfWeek;

	public DateTime MinDate => _minDate;

	public DateTime MaxDate => _maxDate;

	public DateTime TodayDate => _todayDate;

	public string TodayFormat => _todayFormat;

	public DateTime? FocusDay
	{
		get
		{
			return _monthCalendar.FocusDay;
		}
		set
		{
			_monthCalendar.FocusDay = value;
		}
	}

	public int MaxSelectionCount => _maxSelectionCount;

	public string TodayText => _todayText;

	public int ScrollChange => _scrollChange;

	public DateTime SelectionStart => _monthCalendar.SelectionStart;

	public DateTime SelectionEnd => _monthCalendar.SelectionEnd;

	public PaletteMonthCalendarRedirect StateCommon => _monthCalendar.StateCommon;

	public PaletteMonthCalendarDoubleState StateNormal => _monthCalendar.StateNormal;

	public PaletteMonthCalendarDoubleState StateDisabled => _monthCalendar.StateDisabled;

	public PaletteMonthCalendarState StateTracking => _monthCalendar.StateTracking;

	public PaletteMonthCalendarState StatePressed => _monthCalendar.StatePressed;

	public PaletteMonthCalendarState StateCheckedNormal => _monthCalendar.StateCheckedNormal;

	public PaletteMonthCalendarState StateCheckedTracking => _monthCalendar.StateCheckedTracking;

	public PaletteMonthCalendarState StateCheckedPressed => _monthCalendar.StateCheckedPressed;

	public PaletteTripleOverride OverrideDisabled => _monthCalendar.OverrideDisabled;

	public PaletteTripleOverride OverrideNormal => _monthCalendar.OverrideNormal;

	public PaletteTripleOverride OverrideTracking => _monthCalendar.OverrideTracking;

	public PaletteTripleOverride OverridePressed => _monthCalendar.OverridePressed;

	public PaletteTripleOverride OverrideCheckedNormal => _monthCalendar.OverrideCheckedNormal;

	public PaletteTripleOverride OverrideCheckedTracking => _monthCalendar.OverrideCheckedTracking;

	public PaletteTripleOverride OverrideCheckedPressed => _monthCalendar.OverrideCheckedPressed;

	public DateTimeList BoldedDatesList => _monthCalendar.BoldedDatesList;

	public int MonthlyBoldedDatesMask => _monthCalendar.MonthlyBoldedDatesMask;

	public int[] AnnuallyBoldedDatesMask => _monthCalendar.AnnuallyBoldedDatesMask;

	public ViewDrawMenuMonthCalendar(IContextMenuProvider provider, KryptonContextMenuMonthCalendar monthCalendar)
	{
		_provider = provider;
		_monthCalendar = monthCalendar;
		_firstDayOfWeek = _monthCalendar.FirstDayOfWeek;
		_minDate = _monthCalendar.MinDate;
		_maxDate = _monthCalendar.MaxDate;
		_todayDate = _monthCalendar.TodayDate;
		_maxSelectionCount = _monthCalendar.MaxSelectionCount;
		_scrollChange = _monthCalendar.ScrollChange;
		_todayText = _monthCalendar.TodayText;
		_todayFormat = _monthCalendar.TodayFormat;
		_dimensions = _monthCalendar.CalendarDimensions;
		_itemEnabled = provider.ProviderEnabled && _monthCalendar.Enabled;
		_monthCalendar.SetPaletteRedirect(provider.ProviderRedirector);
		_layoutMonths = new ViewLayoutMonths(provider, monthCalendar, provider.ProviderViewManager, this, provider.ProviderRedirector, provider.ProviderNeedPaintDelegate);
		_layoutMonths.CloseOnTodayClick = _monthCalendar.CloseOnTodayClick;
		_layoutMonths.ShowWeekNumbers = _monthCalendar.ShowWeekNumbers;
		_layoutMonths.ShowTodayCircle = _monthCalendar.ShowTodayCircle;
		_layoutMonths.ShowToday = _monthCalendar.ShowToday;
		_layoutMonths.Enabled = _itemEnabled;
		Add(_layoutMonths);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewDrawMenuMonthCalendar:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}

	public IRenderer GetRenderer()
	{
		VisualContextMenu visualContextMenu = (VisualContextMenu)_provider.ProviderViewManager.Control;
		return visualContextMenu.Renderer;
	}

	public void SetSelectionRange(DateTime start, DateTime end)
	{
		_monthCalendar.SetSelectionRange(start, end);
	}

	public void SetBoldedOverride(bool bolded)
	{
		_monthCalendar.SetBoldedOverride(bolded);
	}

	public void SetTodayOverride(bool today)
	{
		_monthCalendar.SetTodayOverride(today);
	}

	public void SetFocusOverride(bool focus)
	{
		_monthCalendar.SetFocusOverride(focus);
	}
}
