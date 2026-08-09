#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class MonthCalendarController : GlobalId, IMouseController, IKeyController, ISourceController, IContextMenuTarget
{
	private KryptonContextMenuMonthCalendar _monthCalendar;

	private ViewContextMenuManager _viewManager;

	private ViewLayoutMonths _months;

	private NeedPaintHandler _needPaint;

	private DateTime _selectionStart;

	private bool _mouseOver;

	private bool _captured;

	public virtual bool HasSubMenu => false;

	public Rectangle ClientRectangle => _months.ClientRectangle;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	private ViewContextMenuManager ViewManager => _viewManager;

	public MonthCalendarController(KryptonContextMenuMonthCalendar monthCalendar, ViewContextMenuManager viewManager, ViewLayoutMonths months, NeedPaintHandler needPaint)
	{
		_monthCalendar = monthCalendar;
		_viewManager = viewManager;
		_months = months;
		_needPaint = needPaint;
		_mouseOver = false;
		_captured = false;
	}

	public virtual void ShowTarget()
	{
		_months.FocusDay = _monthCalendar.SelectionStart;
		_needPaint(this, new NeedLayoutEventArgs(needLayout: false));
	}

	public virtual void ClearTarget()
	{
		_months.FocusDay = null;
		_needPaint(this, new NeedLayoutEventArgs(needLayout: false));
	}

	public void ShowSubMenu()
	{
	}

	public void ClearSubMenu()
	{
	}

	public bool MatchMnemonic(char charCode)
	{
		return false;
	}

	public void MnemonicActivate()
	{
	}

	public ViewBase GetActiveView()
	{
		return _months;
	}

	public bool DoesStackedClientMouseDownBecomeCurrent(Point pt)
	{
		return true;
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
		if (ViewManager != null)
		{
			ViewManager.SetTarget(this, startTimer: true);
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (!_mouseOver)
		{
			return;
		}
		if (_captured)
		{
			if (!(_selectionStart != DateTime.MinValue))
			{
				return;
			}
			DateTime dateTime = _months.DayNearPoint(pt);
			DateTime dateTime2 = _selectionStart;
			TimeSpan timeSpan = new TimeSpan(_months.Calendar.MaxSelectionCount - 1, 0, 0, 0);
			if (dateTime > dateTime2)
			{
				if (dateTime - dateTime2 > timeSpan)
				{
					dateTime = dateTime2 + timeSpan;
				}
				_months.FocusDay = dateTime;
			}
			else if (dateTime < dateTime2)
			{
				if (dateTime2 - dateTime > timeSpan)
				{
					dateTime = dateTime2 - timeSpan;
				}
				DateTime dateTime3 = dateTime;
				dateTime = dateTime2;
				dateTime2 = dateTime3;
				_months.FocusDay = dateTime2;
			}
			_months.Calendar.SetSelectionRange(dateTime2, dateTime);
			_needPaint(_months, new NeedLayoutEventArgs(needLayout: false));
		}
		else
		{
			_months.TrackingDay = _months.DayFromPoint(pt, exact: true);
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left)
		{
			_captured = true;
			if (c != null && c is KryptonMonthCalendar && !c.ContainsFocus)
			{
				c.Focus();
			}
			DateTime? dateTime = _months.DayFromPoint(pt, exact: false);
			if (dateTime.HasValue)
			{
				_months.Calendar.SetSelectionRange(dateTime.Value, dateTime.Value);
				_months.FocusDay = dateTime.Value;
				_months.AnchorDay = dateTime.Value;
				_selectionStart = _months.Calendar.SelectionStart;
				_needPaint(_months, new NeedLayoutEventArgs(needLayout: true));
			}
			else
			{
				_selectionStart = DateTime.MinValue;
			}
		}
		return _captured;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (!_captured)
		{
			return;
		}
		_captured = false;
		if (button == MouseButtons.Left && _monthCalendar != null && _monthCalendar.AutoClose && _months.Provider != null && _selectionStart != DateTime.MinValue && _months.Provider.ProviderCanCloseMenu)
		{
			CancelEventArgs e = new CancelEventArgs();
			_months.Provider.OnClosing(e);
			if (!e.Cancel)
			{
				_months.Provider.OnClose(new CloseReasonEventArgs(ToolStripDropDownCloseReason.ItemClicked));
			}
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (_mouseOver && !_months.ContainsRecurse(next))
		{
			_mouseOver = false;
			_months.TrackingDay = null;
			if (ViewManager != null)
			{
				ViewManager.ClearTarget(this);
			}
		}
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	public virtual void KeyDown(Control c, KeyEventArgs e)
	{
		Debug.Assert(c != null);
		Debug.Assert(e != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (_viewManager != null)
		{
			Keys keyCode = e.KeyCode;
			Keys keys = keyCode;
			if (keys == Keys.Tab)
			{
				_viewManager.KeyTab(e.Shift);
				return;
			}
		}
		DateTime dateTime = (_months.FocusDay.HasValue ? _months.FocusDay.Value : ((_monthCalendar == null) ? _months.Calendar.SelectionStart : _monthCalendar.SelectionStart));
		DateTime dateTime2 = (_months.AnchorDay.HasValue ? _months.AnchorDay.Value : ((_monthCalendar == null) ? _months.Calendar.SelectionStart : _monthCalendar.SelectionStart));
		switch (e.KeyCode)
		{
		case Keys.Left:
			dateTime = ((!e.Control) ? dateTime.AddDays(-1.0) : dateTime.AddMonths(-1));
			break;
		case Keys.Right:
			dateTime = ((!e.Control) ? dateTime.AddDays(1.0) : dateTime.AddMonths(1));
			break;
		case Keys.Up:
			dateTime = dateTime.AddDays(-7.0);
			break;
		case Keys.Down:
			dateTime = dateTime.AddDays(7.0);
			break;
		case Keys.Home:
			if (e.Control)
			{
				dateTime = dateTime.AddMonths(-1);
				dateTime = new DateTime(dateTime.Year, dateTime.Month, 1);
			}
			else
			{
				dateTime = new DateTime(dateTime.Year, dateTime.Month, 1);
			}
			break;
		case Keys.End:
			if (e.Control)
			{
				dateTime = dateTime.AddMonths(1);
				dateTime = new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1.0);
			}
			else
			{
				dateTime = new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1.0);
			}
			break;
		case Keys.Prior:
			dateTime = ((!e.Control) ? dateTime.AddMonths(-1) : dateTime.AddMonths(-1 * _months.Months));
			break;
		case Keys.Next:
			dateTime = ((!e.Control) ? dateTime.AddMonths(1) : dateTime.AddMonths(_months.Months));
			break;
		case Keys.Return:
		case Keys.Space:
			if (_monthCalendar != null && _monthCalendar.AutoClose && _months.Provider != null && _months.Provider.ProviderCanCloseMenu)
			{
				CancelEventArgs e2 = new CancelEventArgs();
				_months.Provider.OnClosing(e2);
				if (!e2.Cancel)
				{
					_months.Provider.OnClose(new CloseReasonEventArgs(ToolStripDropDownCloseReason.Keyboard));
				}
			}
			break;
		}
		if (_months.Calendar.MaxSelectionCount == 1 || !e.Shift)
		{
			_months.AnchorDay = dateTime;
			_months.FocusDay = dateTime;
			_months.Calendar.SetSelectionRange(dateTime, dateTime);
			if (_viewManager != null)
			{
				_needPaint(this, new NeedLayoutEventArgs(needLayout: true));
			}
			return;
		}
		DateTime start = _months.Calendar.SelectionStart;
		DateTime end = _months.Calendar.SelectionEnd;
		if (dateTime < dateTime2)
		{
			if ((dateTime2 - dateTime).Days >= _months.Calendar.MaxSelectionCount)
			{
				dateTime = dateTime2.AddDays(-(_months.Calendar.MaxSelectionCount - 1));
			}
			start = dateTime;
			end = dateTime2;
		}
		else if (dateTime > dateTime2)
		{
			if ((dateTime - dateTime2).Days >= _months.Calendar.MaxSelectionCount)
			{
				dateTime = dateTime2.AddDays(_months.Calendar.MaxSelectionCount - 1);
			}
			start = dateTime2;
			end = dateTime;
		}
		_months.AnchorDay = dateTime2;
		_months.FocusDay = dateTime;
		_months.Calendar.SetSelectionRange(start, end);
		if (_viewManager != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout: true));
		}
	}

	public virtual void KeyPress(Control c, KeyPressEventArgs e)
	{
	}

	public virtual bool KeyUp(Control c, KeyEventArgs e)
	{
		return false;
	}

	public virtual void GotFocus(Control c)
	{
		Debug.Assert(c != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
	}

	public virtual void LostFocus(Control c)
	{
		Debug.Assert(c != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
	}
}
