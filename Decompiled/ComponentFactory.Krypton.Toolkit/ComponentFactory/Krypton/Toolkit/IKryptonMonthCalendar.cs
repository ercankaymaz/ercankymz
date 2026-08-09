using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IKryptonMonthCalendar
{
	Control CalendarControl { get; }

	bool InDesignMode { get; }

	GetToolStripRenderer GetToolStripDelegate { get; }

	Size CalendarDimensions { get; }

	Day FirstDayOfWeek { get; }

	DateTime MinDate { get; }

	DateTime MaxDate { get; }

	DateTime TodayDate { get; }

	string TodayFormat { get; }

	DateTime? FocusDay { get; set; }

	int MaxSelectionCount { get; }

	int ScrollChange { get; }

	DateTime SelectionStart { get; }

	DateTime SelectionEnd { get; }

	DateTimeList BoldedDatesList { get; }

	int MonthlyBoldedDatesMask { get; }

	int[] AnnuallyBoldedDatesMask { get; }

	PaletteMonthCalendarRedirect StateCommon { get; }

	PaletteMonthCalendarDoubleState StateNormal { get; }

	PaletteMonthCalendarDoubleState StateDisabled { get; }

	PaletteMonthCalendarState StateTracking { get; }

	PaletteMonthCalendarState StatePressed { get; }

	PaletteMonthCalendarState StateCheckedNormal { get; }

	PaletteMonthCalendarState StateCheckedTracking { get; }

	PaletteMonthCalendarState StateCheckedPressed { get; }

	PaletteTripleOverride OverrideDisabled { get; }

	PaletteTripleOverride OverrideNormal { get; }

	PaletteTripleOverride OverrideTracking { get; }

	PaletteTripleOverride OverridePressed { get; }

	PaletteTripleOverride OverrideCheckedNormal { get; }

	PaletteTripleOverride OverrideCheckedTracking { get; }

	PaletteTripleOverride OverrideCheckedPressed { get; }

	IRenderer GetRenderer();

	void SetBoldedOverride(bool bolded);

	void SetTodayOverride(bool today);

	void SetFocusOverride(bool focus);

	void SetSelectionRange(DateTime start, DateTime end);
}
