#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutMonths : ViewComposite, IContentValues
{
	internal static readonly int GAP = 2;

	private IContextMenuProvider _provider;

	private IKryptonMonthCalendar _calendar;

	private ViewDrawDocker _drawHeader;

	private PaletteBorderInheritForced _borderForced;

	private MonthCalendarButtonSpecCollection _buttonSpecs;

	private ButtonSpecManagerDraw _buttonManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ViewDrawToday _drawToday;

	private ButtonSpecRemapByContentView _remapPalette;

	private ViewDrawEmptyContent _emptyContent;

	private PaletteTripleRedirect _palette;

	private ToolTipManager _toolTipManager;

	private CultureInfo _lastCultureInfo;

	private DateTime _displayMonth;

	private DayOfWeek _displayDayOfWeek;

	private string[] _dayNames;

	private string _dayOfWeekMeasure;

	private string _dayMeasure;

	private string _shortText;

	private Size _sizeDayOfWeek;

	private Size _sizeDay;

	private DateTime _oldSelectionStart;

	private DateTime _oldSelectionEnd;

	private DateTime? _oldFocusDay;

	private DateTime? _trackingDay;

	private DateTime? _anchorDay;

	private NeedPaintHandler _needPaintDelegate;

	private PaletteRedirect _redirector;

	private bool _showWeekNumbers;

	private bool _showTodayCircle;

	private bool _showToday;

	private bool _closeOnTodayClick;

	private bool _allowButtonSpecToolTips;

	private bool _firstTimeSync;

	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _allowButtonSpecToolTips;
		}
		set
		{
			_allowButtonSpecToolTips = value;
		}
	}

	public ButtonSpecManagerDraw ButtonManager => _buttonManager;

	public MonthCalendarButtonSpecCollection ButtonSpecs => _buttonSpecs;

	public IKryptonMonthCalendar Calendar => _calendar;

	public IContextMenuProvider Provider => _provider;

	public DateTime? TrackingDay
	{
		get
		{
			return _trackingDay;
		}
		set
		{
			if (value != _trackingDay)
			{
				_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: false));
				_trackingDay = value;
			}
		}
	}

	public DateTime? FocusDay
	{
		get
		{
			return _calendar.FocusDay;
		}
		set
		{
			_calendar.FocusDay = value;
		}
	}

	public DateTime? AnchorDay
	{
		get
		{
			return _anchorDay;
		}
		set
		{
			if (value != _anchorDay)
			{
				_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
				_anchorDay = value;
			}
		}
	}

	public bool ShowTodayCircle
	{
		get
		{
			return _showTodayCircle;
		}
		set
		{
			if (value != _showTodayCircle)
			{
				_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
				_showTodayCircle = value;
			}
		}
	}

	public bool ShowToday
	{
		get
		{
			return _showToday;
		}
		set
		{
			if (value != _showToday)
			{
				_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
				_showToday = value;
			}
		}
	}

	public bool CloseOnTodayClick
	{
		get
		{
			return _closeOnTodayClick;
		}
		set
		{
			_closeOnTodayClick = value;
		}
	}

	public bool ShowWeekNumbers
	{
		get
		{
			return _showWeekNumbers;
		}
		set
		{
			if (value != _showWeekNumbers)
			{
				_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
				_showWeekNumbers = value;
			}
		}
	}

	public int Months => _calendar.CalendarDimensions.Width * _calendar.CalendarDimensions.Height;

	internal Size SizeDays => _sizeDayOfWeek;

	internal Size SizeDay => _sizeDay;

	internal DayOfWeek DisplayDayOfWeek => _displayDayOfWeek;

	internal string[] DayNames => _dayNames;

	public ViewLayoutMonths(IContextMenuProvider provider, KryptonContextMenuMonthCalendar monthCalendar, ViewContextMenuManager viewManager, IKryptonMonthCalendar calendar, PaletteRedirect redirector, NeedPaintHandler needPaintDelegate)
	{
		_provider = provider;
		_calendar = calendar;
		_oldSelectionStart = _calendar.SelectionStart;
		_oldSelectionEnd = _calendar.SelectionEnd;
		_displayMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		_redirector = redirector;
		_needPaintDelegate = needPaintDelegate;
		_showToday = true;
		_showTodayCircle = true;
		_closeOnTodayClick = false;
		_firstTimeSync = true;
		_allowButtonSpecToolTips = false;
		KeyController = (IKeyController)(SourceController = (ISourceController)(MouseController = new MonthCalendarController(monthCalendar, viewManager, this, _needPaintDelegate)));
		_borderForced = new PaletteBorderInheritForced(_calendar.StateNormal.Header.Border);
		_borderForced.ForceBorderEdges(PaletteDrawBorders.None);
		_drawHeader = new ViewDrawDocker(_calendar.StateNormal.Header.Back, _borderForced, null);
		_emptyContent = new ViewDrawEmptyContent(_calendar.StateDisabled.Header.Content, _calendar.StateNormal.Header.Content);
		_drawHeader.Add(_emptyContent, ViewDockStyle.Fill);
		Add(_drawHeader);
		_buttonSpecs = new MonthCalendarButtonSpecCollection(this);
		_buttonManager = new ButtonSpecManagerDraw(_calendar.CalendarControl, redirector, _buttonSpecs, null, new ViewDrawDocker[1] { _drawHeader }, new IPaletteMetric[1] { _calendar.StateCommon }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetCalendar }, new PaletteMetricPadding[1], _calendar.GetToolStripDelegate, _needPaintDelegate);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
		_remapPalette = (ButtonSpecRemapByContentView)_buttonManager.CreateButtonSpecRemap(redirector, new ButtonSpecAny());
		_remapPalette.Foreground = _emptyContent;
		_palette = new PaletteTripleRedirect(_remapPalette, PaletteBackStyle.ButtonButtonSpec, PaletteBorderStyle.ButtonButtonSpec, PaletteContentStyle.ButtonButtonSpec, _needPaintDelegate);
		_drawToday = new ViewDrawToday(_calendar, _palette, _palette, _palette, _palette, _needPaintDelegate);
		_drawToday.Click += OnTodayClick;
		_drawHeader.Add(_drawToday, ViewDockStyle.Left);
	}

	public override string ToString()
	{
		return "ViewLayoutMonths:" + base.Id;
	}

	public void RecreateButtons()
	{
		_buttonManager.RecreateButtons();
	}

	public bool ProcessKeyDown(Control c, KeyEventArgs e)
	{
		if (FocusDay.HasValue)
		{
			KeyController.KeyDown(c, e);
			return true;
		}
		return false;
	}

	public DateTime DayNearPoint(Point pt)
	{
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current is ViewDrawMonth { ClientRectangle: var clientRectangle } viewDrawMonth && clientRectangle.Contains(pt))
				{
					return viewDrawMonth.ViewDrawMonthDays.DayNearPoint(pt);
				}
			}
		}
		int width = _calendar.CalendarDimensions.Width;
		int height = _calendar.CalendarDimensions.Height;
		int num = width - 1;
		int num2 = height - 1;
		for (int i = 0; i < width; i++)
		{
			if (pt.X < this[i + 1].ClientRectangle.Right)
			{
				num = i;
				break;
			}
		}
		for (int j = 0; j < height; j++)
		{
			if (pt.Y < this[j * width + 1].ClientRectangle.Bottom)
			{
				num2 = j;
				break;
			}
		}
		ViewDrawMonth viewDrawMonth2 = (ViewDrawMonth)this[num + num2 * width + 1];
		return viewDrawMonth2.ViewDrawMonthDays.DayNearPoint(pt);
	}

	public DateTime? DayFromPoint(Point pt, bool exact)
	{
		for (ViewBase viewBase = ViewFromPoint(pt); viewBase != null; viewBase = viewBase.Parent)
		{
			if (viewBase is ViewDrawMonthDays { ClientRectangle: var clientRectangle } viewDrawMonthDays && clientRectangle.Contains(pt))
			{
				return viewDrawMonthDays.DayFromPoint(pt, exact);
			}
		}
		return null;
	}

	public void NextMonth()
	{
		int num = _calendar.ScrollChange;
		if (num == 0)
		{
			num = 1;
		}
		DateTime displayMonth = _displayMonth.AddMonths(num);
		DateTime dateTime = displayMonth.AddMonths(_calendar.CalendarDimensions.Width * _calendar.CalendarDimensions.Height);
		DateTime dateTime2 = dateTime.AddDays(-1.0);
		DateTime dateTime3 = LastDayOfMonth(_calendar.MaxDate);
		if (!(dateTime.AddDays(-1.0) <= LastDayOfMonth(_calendar.MaxDate)))
		{
			return;
		}
		_displayMonth = displayMonth;
		if (_calendar.SelectionEnd < _displayMonth)
		{
			DateTime dateTime4 = _calendar.SelectionStart.AddMonths(num);
			DateTime dateTime5 = _calendar.SelectionEnd.AddMonths(num);
			if (dateTime4 > _calendar.MaxDate)
			{
				dateTime4 = _calendar.MaxDate;
			}
			if (dateTime5 > _calendar.MaxDate)
			{
				dateTime5 = _calendar.MaxDate;
			}
			_calendar.SetSelectionRange(dateTime4, dateTime5);
		}
		_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
	}

	public void PrevMonth()
	{
		int num = _calendar.ScrollChange;
		if (num == 0)
		{
			num = 1;
		}
		DateTime dateTime = _displayMonth.AddMonths(-num);
		if (!(dateTime >= FirstDayOfMonth(_calendar.MinDate)))
		{
			return;
		}
		_displayMonth = dateTime;
		DateTime dateTime2 = _displayMonth.AddMonths(_calendar.CalendarDimensions.Width * _calendar.CalendarDimensions.Height);
		if (_calendar.SelectionStart >= dateTime2)
		{
			DateTime dateTime3 = _calendar.SelectionStart.AddMonths(-num);
			DateTime dateTime4 = _calendar.SelectionEnd.AddMonths(-num);
			if (dateTime3 < _calendar.MinDate)
			{
				dateTime3 = _calendar.MinDate;
			}
			if (dateTime4 < _calendar.MinDate)
			{
				dateTime4 = _calendar.MinDate;
			}
			_calendar.SetSelectionRange(dateTime3, dateTime4);
		}
		_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
	}

	public Size GetSingleMonthSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		SyncData(context);
		SyncMonths();
		return this[1].GetPreferredSize(context);
	}

	public Size GetExtraSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (_drawHeader.Visible)
		{
			Size preferredSize = _drawHeader.GetPreferredSize(context);
			preferredSize.Width = 0;
			preferredSize.Height += GAP * 2;
			return preferredSize;
		}
		return Size.Empty;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		SyncData(context);
		SyncMonths();
		Size empty = Size.Empty;
		if (_drawHeader.Visible)
		{
			empty.Height = _drawHeader.GetPreferredSize(context).Height + GAP * 2;
		}
		if (Count > 1)
		{
			Size preferredSize = this[1].GetPreferredSize(context);
			empty.Width += preferredSize.Width * _calendar.CalendarDimensions.Width + GAP * _calendar.CalendarDimensions.Width + GAP;
			empty.Height += preferredSize.Height * _calendar.CalendarDimensions.Height + GAP * _calendar.CalendarDimensions.Height + GAP;
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		SyncData(context);
		SyncMonths();
		ClientRectangle = context.DisplayRectangle;
		if (_drawHeader.Visible)
		{
			Size preferredSize = _drawHeader.GetPreferredSize(context);
			context.DisplayRectangle = new Rectangle(ClientLocation.X + GAP, ClientRectangle.Bottom - GAP - preferredSize.Height, ClientSize.Width - GAP * 2, preferredSize.Height);
			_drawHeader.Layout(context);
		}
		if (Count > 1)
		{
			Size preferredSize2 = this[1].GetPreferredSize(context);
			Size calendarDimensions = _calendar.CalendarDimensions;
			int i = 0;
			int num = 1;
			for (; i < calendarDimensions.Height; i++)
			{
				for (int j = 0; j < calendarDimensions.Width; j++)
				{
					context.DisplayRectangle = new Rectangle(ClientLocation.X + j * preferredSize2.Width + GAP * (j + 1), ClientLocation.Y + i * preferredSize2.Height + GAP * (i + 1), preferredSize2.Width, preferredSize2.Height);
					this[num++].Layout(context);
				}
			}
		}
		context.DisplayRectangle = ClientRectangle;
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
		return _shortText;
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	private DateTime JustDay(DateTime dt)
	{
		return new DateTime(dt.Year, dt.Month, dt.Day);
	}

	private void OnTodayClick(object sender, EventArgs e)
	{
		DateTime todayDate = _calendar.TodayDate;
		if (todayDate >= _calendar.MinDate && todayDate <= _calendar.MaxDate)
		{
			_calendar.SetSelectionRange(todayDate, todayDate);
			_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
		}
		if (CloseOnTodayClick && Provider != null && Provider.ProviderCanCloseMenu)
		{
			CancelEventArgs e2 = new CancelEventArgs();
			Provider.OnClosing(e2);
			if (!e2.Cancel)
			{
				Provider.OnClose(new CloseReasonEventArgs(ToolStripDropDownCloseReason.ItemClicked));
			}
		}
	}

	private void SyncData(ViewLayoutContext context)
	{
		if (_lastCultureInfo == null || _lastCultureInfo != CultureInfo.CurrentCulture)
		{
			_lastCultureInfo = CultureInfo.CurrentCulture;
			_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			_dayNames = null;
		}
		if (_dayNames == null)
		{
			_dayNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
			_dayOfWeekMeasure = new string('W', Math.Max(3, _dayNames[0].Length));
			_dayMeasure = "WW";
		}
		if (_calendar.FirstDayOfWeek == Day.Default)
		{
			_displayDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
		}
		else
		{
			_displayDayOfWeek = (DayOfWeek)((int)(_calendar.FirstDayOfWeek + 1) % 6);
		}
		_sizeDayOfWeek = MaxGridCellDayOfWeek(context);
		_sizeDay = MaxGridCellDay(context);
	}

	private void SyncMonths()
	{
		this[0].Visible = _showToday || _buttonSpecs.Count > 0;
		this[0].Enabled = Enabled;
		_drawToday.Visible = _showToday;
		int months = Months;
		if (Count < months + 1)
		{
			for (int i = Count - 1; i < months; i++)
			{
				Add(new ViewDrawMonth(_calendar, this, _redirector, _needPaintDelegate));
			}
		}
		else if (Count > months + 1)
		{
			for (int num = Count - 1; num > months; num--)
			{
				this[num].Dispose();
				RemoveAt(num);
			}
		}
		if (!(_oldSelectionStart != _calendar.SelectionStart) && !(_oldSelectionEnd != _calendar.SelectionEnd))
		{
			DateTime? oldFocusDay = _oldFocusDay;
			DateTime? focusDay = FocusDay;
			if (oldFocusDay.HasValue == focusDay.HasValue && (!oldFocusDay.HasValue || !(oldFocusDay.GetValueOrDefault() != focusDay.GetValueOrDefault())) && !_firstTimeSync)
			{
				goto IL_0336;
			}
		}
		_firstTimeSync = false;
		_oldSelectionStart = _calendar.SelectionStart;
		_oldSelectionEnd = _calendar.SelectionEnd;
		_oldFocusDay = FocusDay;
		if (FocusDay.HasValue)
		{
			if (FocusDay.Value < _displayMonth)
			{
				_displayMonth = new DateTime(FocusDay.Value.Year, FocusDay.Value.Month, 1);
			}
			else
			{
				DateTime dateTime = _displayMonth.AddMonths(months);
				if (FocusDay.Value >= dateTime)
				{
					_displayMonth = new DateTime(FocusDay.Value.Year, FocusDay.Value.Month, 1).AddMonths(-(months - 1));
				}
			}
		}
		else
		{
			DateTime dateTime2 = _displayMonth.AddMonths(months - 1);
			DateTime date = _oldSelectionEnd.Date;
			DateTime dateTime3 = new DateTime(date.Year, date.Month, 1);
			if (dateTime3 >= dateTime2)
			{
				_displayMonth = dateTime3.AddMonths(-(months - 1));
			}
			if (_oldSelectionStart < _displayMonth)
			{
				_displayMonth = new DateTime(_calendar.SelectionStart.Year, _calendar.SelectionStart.Month, 1);
			}
		}
		goto IL_0336;
		IL_0336:
		DateTime month = _displayMonth;
		for (int j = 1; j < Count; j++)
		{
			ViewDrawMonth viewDrawMonth = (ViewDrawMonth)this[j];
			viewDrawMonth.Enabled = Enabled;
			viewDrawMonth.Month = month;
			viewDrawMonth.FirstMonth = j == 1;
			viewDrawMonth.LastMonth = j == Count - 1;
			viewDrawMonth.UpdateButtons(j == 1, j - 1 == _calendar.CalendarDimensions.Width - 1);
			month = month.AddMonths(1);
		}
	}

	private void OnShowToolTip(object sender, ToolTipEventArgs e)
	{
		if (base.IsDisposed)
		{
			return;
		}
		Form form = _calendar.CalendarControl.FindForm();
		if ((form != null && !form.ContainsFocus) || _calendar.InDesignMode)
		{
			return;
		}
		IContentValues contentValues = null;
		LabelStyle style = LabelStyle.ToolTip;
		ButtonSpec buttonSpec = _buttonManager.ButtonSpecFromView(e.Target);
		if (buttonSpec != null && AllowButtonSpecToolTips)
		{
			ButtonSpecToContent buttonSpecToContent = new ButtonSpecToContent(_redirector, buttonSpec);
			if (buttonSpecToContent.HasContent)
			{
				contentValues = buttonSpecToContent;
				style = buttonSpec.ToolTipStyle;
			}
		}
		if (contentValues != null)
		{
			if (_visualPopupToolTip != null)
			{
				_visualPopupToolTip.Dispose();
			}
			_visualPopupToolTip = new VisualPopupToolTip(_redirector, contentValues, _calendar.GetRenderer(), PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, CommonHelper.ContentStyleFromLabelStyle(style));
			_visualPopupToolTip.Disposed += OnVisualPopupToolTipDisposed;
			_visualPopupToolTip.ShowCalculatingSize(_calendar.CalendarControl.RectangleToScreen(e.Target.ClientRectangle));
		}
	}

	private void OnCancelToolTip(object sender, EventArgs e)
	{
		if (_visualPopupToolTip != null)
		{
			_visualPopupToolTip.Dispose();
		}
	}

	private void OnVisualPopupToolTipDisposed(object sender, EventArgs e)
	{
		VisualPopupToolTip visualPopupToolTip = (VisualPopupToolTip)sender;
		visualPopupToolTip.Disposed -= OnVisualPopupToolTipDisposed;
		_visualPopupToolTip = null;
	}

	private Size MaxGridCellDay(ViewLayoutContext context)
	{
		_shortText = _dayMeasure;
		Size contentPreferredSize = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateNormal.Day.Content, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
		Size contentPreferredSize2 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateDisabled.Day.Content, this, VisualOrientation.Top, PaletteState.Disabled, composition: false);
		Size contentPreferredSize3 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateTracking.Day.Content, this, VisualOrientation.Top, PaletteState.Disabled, composition: false);
		Size contentPreferredSize4 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StatePressed.Day.Content, this, VisualOrientation.Top, PaletteState.Disabled, composition: false);
		Size contentPreferredSize5 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateCheckedNormal.Day.Content, this, VisualOrientation.Top, PaletteState.Disabled, composition: false);
		Size contentPreferredSize6 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateCheckedTracking.Day.Content, this, VisualOrientation.Top, PaletteState.Disabled, composition: false);
		Size contentPreferredSize7 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateCheckedPressed.Day.Content, this, VisualOrientation.Top, PaletteState.Disabled, composition: false);
		contentPreferredSize.Width = Math.Max(contentPreferredSize.Width, Math.Max(contentPreferredSize2.Width, Math.Max(contentPreferredSize3.Width, Math.Max(contentPreferredSize4.Width, Math.Max(contentPreferredSize5.Width, Math.Max(contentPreferredSize6.Width, contentPreferredSize7.Width))))));
		contentPreferredSize.Height = Math.Max(contentPreferredSize.Height, Math.Max(contentPreferredSize2.Height, Math.Max(contentPreferredSize3.Height, Math.Max(contentPreferredSize4.Height, Math.Max(contentPreferredSize5.Height, Math.Max(contentPreferredSize6.Height, contentPreferredSize7.Height))))));
		return contentPreferredSize;
	}

	private Size MaxGridCellDayOfWeek(ViewLayoutContext context)
	{
		_shortText = "A";
		Size contentPreferredSize = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateNormal.DayOfWeek.Content, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
		Size contentPreferredSize2 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateDisabled.DayOfWeek.Content, this, VisualOrientation.Top, PaletteState.Disabled, composition: false);
		_shortText = "A" + _dayOfWeekMeasure;
		Size contentPreferredSize3 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateNormal.DayOfWeek.Content, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
		Size contentPreferredSize4 = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _calendar.StateDisabled.DayOfWeek.Content, this, VisualOrientation.Top, PaletteState.Disabled, composition: false);
		contentPreferredSize3.Width = Math.Max(contentPreferredSize3.Width - contentPreferredSize.Width - 3, contentPreferredSize4.Width - contentPreferredSize2.Width - 3);
		contentPreferredSize3.Height = Math.Max(contentPreferredSize3.Height, contentPreferredSize4.Height);
		return contentPreferredSize3;
	}

	private DateTime FirstDayOfMonth(DateTime dt)
	{
		dt = dt.AddDays(-(dt.Day - 1));
		return JustDay(dt);
	}

	private DateTime LastDayOfMonth(DateTime dt)
	{
		dt = dt.AddMonths(1);
		dt = dt.AddDays(-dt.Day);
		return JustDay(dt);
	}
}
