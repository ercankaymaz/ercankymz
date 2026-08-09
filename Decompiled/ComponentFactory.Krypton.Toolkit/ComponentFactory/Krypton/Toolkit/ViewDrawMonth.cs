using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMonth : ViewLayoutStack, IContentValues
{
	public class CalendarButtonSpecCollection : ButtonSpecCollection<ButtonSpecCalendar>
	{
		public CalendarButtonSpecCollection(ViewDrawMonth owner)
			: base((object)owner)
		{
		}
	}

	private IKryptonMonthCalendar _calendar;

	private ViewLayoutMonths _months;

	private ViewDrawDocker _drawHeader;

	private PaletteBorderInheritForced _borderForced;

	private ViewDrawContent _drawContent;

	private ViewDrawMonthDayNames _drawMonthDayNames;

	private ViewDrawBorderEdge _drawBorderEdge;

	private ViewDrawMonthDays _drawMonthDays;

	private ViewLayoutWeekCorner _drawWeekCorner;

	private ViewDrawWeekNumbers _drawWeekNumbers;

	private ViewLayoutStack _numberStack;

	private PaletteBorderEdgeRedirect _borderEdgeRedirect;

	private PaletteBorderEdge _borderEdge;

	private ButtonSpecManagerDraw _buttonManager;

	private CalendarButtonSpecCollection _buttonSpecs;

	private ButtonSpecCalendar _arrowPrev;

	private ButtonSpecCalendar _arrowNext;

	private string _header;

	public ViewDrawMonthDays ViewDrawMonthDays => _drawMonthDays;

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			_drawContent.Enabled = value;
			_drawHeader.Enabled = value;
			_drawMonthDayNames.Enabled = value;
			_drawBorderEdge.Enabled = value;
			_drawMonthDays.Enabled = value;
			base.Enabled = value;
		}
	}

	public bool FirstMonth
	{
		set
		{
			_drawMonthDays.FirstMonth = value;
			_drawWeekNumbers.FirstMonth = value;
		}
	}

	public bool LastMonth
	{
		set
		{
			_drawMonthDays.LastMonth = value;
			_drawWeekNumbers.LastMonth = value;
		}
	}

	public DateTime Month
	{
		set
		{
			_header = value.ToString(CultureInfo.CurrentCulture.DateTimeFormat.YearMonthPattern);
			_drawMonthDays.Month = value;
			_drawWeekNumbers.Month = value;
		}
	}

	public ViewDrawMonth(IKryptonMonthCalendar calendar, ViewLayoutMonths months, PaletteRedirect redirector, NeedPaintHandler needPaintDelegate)
		: base(horizontal: false)
	{
		_calendar = calendar;
		_months = months;
		_drawContent = new ViewDrawContent(_calendar.StateNormal.Header.Content, this, VisualOrientation.Top);
		_borderForced = new PaletteBorderInheritForced(_calendar.StateNormal.Header.Border);
		_borderForced.ForceBorderEdges(PaletteDrawBorders.None);
		_drawHeader = new ViewDrawDocker(_calendar.StateNormal.Header.Back, _borderForced, null);
		_drawHeader.Add(_drawContent, ViewDockStyle.Fill);
		Add(_drawHeader);
		_arrowPrev = new ButtonSpecCalendar(this, PaletteButtonSpecStyle.Previous, RelativeEdgeAlign.Near);
		_arrowNext = new ButtonSpecCalendar(this, PaletteButtonSpecStyle.Next, RelativeEdgeAlign.Far);
		_arrowPrev.Click += OnPrevMonth;
		_arrowNext.Click += OnNextMonth;
		_buttonSpecs = new CalendarButtonSpecCollection(this);
		_buttonSpecs.Add(_arrowPrev);
		_buttonSpecs.Add(_arrowNext);
		_buttonManager = new ButtonSpecManagerDraw(_calendar.CalendarControl, redirector, null, _buttonSpecs, new ViewDrawDocker[1] { _drawHeader }, new IPaletteMetric[1] { _calendar.StateCommon }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetCalendar }, new PaletteMetricPadding[1], _calendar.GetToolStripDelegate, needPaintDelegate);
		ViewLayoutStack viewLayoutStack = new ViewLayoutStack(horizontal: true);
		ViewLayoutStack viewLayoutStack2 = new ViewLayoutStack(horizontal: true);
		ViewLayoutStack viewLayoutStack3 = new ViewLayoutStack(horizontal: false);
		_numberStack = new ViewLayoutStack(horizontal: false);
		viewLayoutStack2.Add(_numberStack);
		viewLayoutStack2.Add(viewLayoutStack3);
		_drawMonthDayNames = new ViewDrawMonthDayNames(_calendar, _months);
		_drawWeekCorner = new ViewLayoutWeekCorner(_calendar, _months, _calendar.StateNormal.Header.Border);
		viewLayoutStack.Add(_drawWeekCorner);
		viewLayoutStack.Add(_drawMonthDayNames);
		Add(viewLayoutStack);
		Add(viewLayoutStack2);
		_borderEdgeRedirect = new PaletteBorderEdgeRedirect(_calendar.StateNormal.Header.Border, null);
		_borderEdge = new PaletteBorderEdge(_borderEdgeRedirect, null);
		_drawBorderEdge = new ViewDrawBorderEdge(_borderEdge, Orientation.Vertical);
		_drawWeekNumbers = new ViewDrawWeekNumbers(_calendar, _months);
		ViewLayoutDocker item = new ViewLayoutDocker
		{
			{
				_drawWeekNumbers,
				ViewDockStyle.Left
			},
			{
				new ViewLayoutSeparator(0, 4),
				ViewDockStyle.Top
			},
			{
				_drawBorderEdge,
				ViewDockStyle.Fill
			},
			{
				new ViewLayoutSeparator(0, 4),
				ViewDockStyle.Bottom
			}
		};
		_numberStack.Add(item);
		PaletteBorderEdgeRedirect inherit = new PaletteBorderEdgeRedirect(_calendar.StateNormal.Header.Border, null);
		PaletteBorderEdge palette = new PaletteBorderEdge(inherit, null);
		ViewDrawBorderEdge item2 = new ViewDrawBorderEdge(palette, Orientation.Horizontal);
		viewLayoutStack3.Add(new ViewLayoutDocker
		{
			{
				new ViewLayoutSeparator(4, 1),
				ViewDockStyle.Left
			},
			{
				item2,
				ViewDockStyle.Fill
			},
			{
				new ViewLayoutSeparator(4, 1),
				ViewDockStyle.Right
			},
			{
				new ViewLayoutSeparator(1, 3),
				ViewDockStyle.Bottom
			}
		});
		_drawMonthDays = new ViewDrawMonthDays(_calendar, _months);
		viewLayoutStack3.Add(_drawMonthDays);
		_buttonManager.RecreateButtons();
	}

	public override string ToString()
	{
		return "ViewDrawMonth:" + base.Id;
	}

	public void UpdateButtons(bool prev, bool next)
	{
		_arrowPrev.Visible = prev;
		_arrowNext.Visible = next;
		_buttonManager.RefreshButtons();
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		UpdateWeekNumberViews();
		return base.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		UpdateWeekNumberViews();
		base.Layout(context);
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
		return _header;
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	private void UpdateWeekNumberViews()
	{
		bool showWeekNumbers = _months.ShowWeekNumbers;
		_drawWeekCorner.Visible = showWeekNumbers;
		_numberStack.Visible = showWeekNumbers;
	}

	private void OnNextMonth(object sender, EventArgs e)
	{
		_months.NextMonth();
	}

	private void OnPrevMonth(object sender, EventArgs e)
	{
		_months.PrevMonth();
	}
}
