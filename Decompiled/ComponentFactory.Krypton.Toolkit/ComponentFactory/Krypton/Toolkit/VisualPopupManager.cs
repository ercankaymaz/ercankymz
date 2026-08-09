#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public class VisualPopupManager : IMessageFilter
{
	private class PopupStack : Stack<VisualPopup>
	{
	}

	[ThreadStatic]
	private static VisualPopupManager _singleton;

	private PopupStack _stack;

	private VisualPopup _current;

	private IntPtr _activeWindow;

	private bool _filtering;

	private int _suspended;

	private bool _showingCMS;

	private ContextMenuStrip _cms;

	private EventHandler _cmsFinishDelegate;

	public static VisualPopupManager Singleton
	{
		[DebuggerStepThrough]
		get
		{
			if (_singleton == null)
			{
				_singleton = new VisualPopupManager();
			}
			return _singleton;
		}
	}

	public bool IsShowingCMS => _showingCMS;

	public bool IsTracking => _current != null;

	public VisualPopup CurrentPopup
	{
		[DebuggerStepThrough]
		get
		{
			return _current;
		}
	}

	public VisualPopup[] StackedPopups => _stack.ToArray();

	private VisualPopupManager()
	{
		_stack = new PopupStack();
	}

	public Control TrackingByType(Type t)
	{
		if (IsTracking)
		{
			if (CurrentPopup.GetType() == t)
			{
				return CurrentPopup;
			}
			VisualPopup[] array = _stack.ToArray();
			for (int num = array.Length - 1; num >= 0; num--)
			{
				if (!array[num].IsDisposed && array[num].GetType() == t)
				{
					return array[num];
				}
			}
		}
		return null;
	}

	public void StartTracking(VisualPopup popup)
	{
		Debug.Assert(popup != null);
		Debug.Assert(!popup.IsDisposed);
		Debug.Assert(popup.IsHandleCreated);
		Debug.Assert(_suspended == 0);
		if (popup != null && !popup.IsDisposed && popup.IsHandleCreated && _suspended == 0)
		{
			if (_current != null)
			{
				_stack.Push(_current);
			}
			else
			{
				_activeWindow = PI.GetActiveWindow();
				FilterMessages(filter: true);
			}
			_current = popup;
		}
	}

	public void EndAllTracking()
	{
		if (_current != null)
		{
			if (!_current.IsDisposed)
			{
				_current.Dispose();
				_current = null;
			}
			while (_stack.Count > 0)
			{
				_current = _stack.Pop();
				_current.Dispose();
				_current = null;
			}
			FilterMessages(filter: false);
		}
	}

	public void EndPopupTracking(VisualPopup popup)
	{
		if (_current == null)
		{
			return;
		}
		bool flag = false;
		do
		{
			flag = _current == popup;
			if (!_current.IsDisposed)
			{
				_current.Dispose();
			}
			_current = null;
			if (_stack.Count > 0)
			{
				_current = _stack.Pop();
			}
		}
		while (!flag && _current != null);
		if (_current == null)
		{
			FilterMessages(filter: false);
		}
	}

	public void EndCurrentTracking()
	{
		if (_current != null)
		{
			if (!_current.IsDisposed)
			{
				_current.Dispose();
			}
			if (_stack.Count > 0)
			{
				_current = _stack.Pop();
				return;
			}
			_current = null;
			FilterMessages(filter: false);
		}
	}

	public void ShowContextMenuStrip(ContextMenuStrip cms, Point screenPt)
	{
		ShowContextMenuStrip(cms, screenPt, null);
	}

	public void ShowContextMenuStrip(ContextMenuStrip cms, Point screenPt, EventHandler cmsFinishDelegate)
	{
		Debug.Assert(cms != null);
		if (cms != null)
		{
			cms.Closed += OnCMSClosed;
			_cmsFinishDelegate = cmsFinishDelegate;
			_suspended++;
			FilterMessages(filter: true);
			_showingCMS = true;
			_cms = cms;
			cms.Show(screenPt);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	public bool PreFilterMessage(ref Message m)
	{
		if (_suspended > 0)
		{
			if (m.Msg == 160)
			{
				return true;
			}
			if (m.Msg == 512)
			{
				return ProcessMouseMoveWithCMS(ref m);
			}
			return false;
		}
		if (_current != null)
		{
			if (_current.IsDisposed)
			{
				EndCurrentTracking();
				return false;
			}
			IntPtr activeWindow = PI.GetActiveWindow();
			if (activeWindow != _activeWindow)
			{
				if (activeWindow == _current.Handle && _current.AllowBecomeActiveWhenCurrent)
				{
					_activeWindow = _current.Handle;
				}
				else
				{
					bool flag = _current.ContainsFocus;
					if (!flag)
					{
						VisualPopup[] array = _stack.ToArray();
						for (int num = array.Length - 1; num >= 0; num--)
						{
							if (!array[num].IsDisposed && array[num].ContainsFocus)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						EndAllTracking();
						return false;
					}
				}
			}
			if (!IsKeyOrMouseMessage(ref m))
			{
				return false;
			}
			switch (m.Msg)
			{
			case 256:
			case 260:
				if (!_current.KeyboardInert)
				{
					if (!_current.ContainsFocus)
					{
						PI.MSG lpMsg = new PI.MSG
						{
							hwnd = m.HWnd,
							message = m.Msg,
							lParam = m.LParam,
							wParam = m.WParam
						};
						PI.TranslateMessage(ref lpMsg);
					}
					return ProcessKeyboard(ref m);
				}
				break;
			case 257:
			case 258:
			case 259:
			case 261:
			case 262:
			case 263:
				if (!_current.KeyboardInert)
				{
					return ProcessKeyboard(ref m);
				}
				break;
			case 160:
			case 512:
				return ProcessMouseMove(ref m);
			case 513:
			case 516:
			case 519:
				return ProcessClientMouseDown(ref m);
			case 161:
			case 164:
			case 167:
				return ProcessNonClientMouseDown(ref m);
			}
		}
		return false;
	}

	private bool ProcessKeyboard(ref Message m)
	{
		if (!_current.ContainsFocus)
		{
			PI.SendMessage(_current.Handle, m.Msg, m.WParam, m.LParam);
			return true;
		}
		return false;
	}

	private bool ProcessClientMouseDown(ref Message m)
	{
		bool flag = false;
		Point pt = CommonHelper.ClientMouseMessageToScreenPt(m);
		if (m.HWnd == _current.Handle)
		{
			if (_current.DoesCurrentMouseDownEndAllTracking(m, ScreenPtToClientPt(pt)))
			{
				EndAllTracking();
			}
		}
		else
		{
			if (_current.DoesCurrentMouseDownContinueTracking(m, ScreenPtToClientPt(pt)))
			{
				return flag;
			}
			VisualPopup[] array = _stack.ToArray();
			foreach (VisualPopup visualPopup in array)
			{
				if (visualPopup.IsDisposed || !visualPopup.RectangleToScreen(visualPopup.ClientRectangle).Contains(pt))
				{
					continue;
				}
				if (visualPopup.DoesStackedClientMouseDownBecomeCurrent(m, ScreenPtToClientPt(pt, visualPopup.Handle)))
				{
					while (_current != null && _current != visualPopup)
					{
						_current.Dispose();
						if (_stack.Count > 0)
						{
							_current = _stack.Pop();
						}
					}
				}
				return flag;
			}
			if (_current != null)
			{
				flag = _current.DoesMouseDownGetEaten(m, pt);
				if (!flag)
				{
					foreach (VisualPopup visualPopup2 in array)
					{
						if (!visualPopup2.IsDisposed)
						{
							flag = visualPopup2.DoesMouseDownGetEaten(m, pt);
							if (flag)
							{
								break;
							}
						}
					}
				}
			}
			EndAllTracking();
		}
		return flag;
	}

	private bool ProcessNonClientMouseDown(ref Message m)
	{
		Point pt = new Point(PI.LOWORD((int)m.LParam), PI.HIWORD((int)m.LParam));
		if (_current.DoesCurrentMouseDownEndAllTracking(m, ScreenPtToClientPt(pt)))
		{
			EndAllTracking();
		}
		bool flag = false;
		if (_current != null)
		{
			flag = _current.DoesMouseDownGetEaten(m, pt);
			if (!flag)
			{
				VisualPopup[] array = _stack.ToArray();
				foreach (VisualPopup visualPopup in array)
				{
					if (!visualPopup.IsDisposed)
					{
						flag = visualPopup.DoesMouseDownGetEaten(m, pt);
						if (flag)
						{
							break;
						}
					}
				}
			}
		}
		return flag;
	}

	private bool ProcessMouseMove(ref Message m)
	{
		if (m.HWnd != _current.Handle)
		{
			Point pt = CommonHelper.ClientMouseMessageToScreenPt(m);
			if (_current.AllowMouseMove(m, pt))
			{
				return false;
			}
			VisualPopup[] array = _stack.ToArray();
			for (int num = array.Length - 1; num >= 0; num--)
			{
				if (!array[num].IsDisposed && array[num].AllowMouseMove(m, pt))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private bool ProcessMouseMoveWithCMS(ref Message m)
	{
		if (_current == null)
		{
			return false;
		}
		Point point = CommonHelper.ClientMouseMessageToScreenPt(m);
		IntPtr intPtr = PI.WindowFromPoint(new PI.POINT
		{
			x = point.X,
			y = point.Y
		});
		if (_current.Handle == intPtr)
		{
			return true;
		}
		VisualPopup[] array = _stack.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].IsDisposed && array[i].Handle == intPtr)
			{
				return true;
			}
		}
		return false;
	}

	private Point ScreenPtToClientPt(Point pt)
	{
		return ScreenPtToClientPt(pt, _current.Handle);
	}

	private Point ScreenPtToClientPt(Point pt, IntPtr handle)
	{
		PI.POINTC pOINTC = new PI.POINTC();
		pOINTC.x = pt.X;
		pOINTC.y = pt.Y;
		if (pOINTC.x >= 32767)
		{
			pOINTC.x -= 65536;
		}
		if (pOINTC.y >= 32767)
		{
			pOINTC.y -= 65536;
		}
		PI.POINTC pOINTC2 = new PI.POINTC();
		pOINTC2.x = 0;
		pOINTC2.y = 0;
		PI.MapWindowPoints(IntPtr.Zero, handle, pOINTC2, 1);
		pOINTC.x += pOINTC2.x;
		pOINTC.y += pOINTC2.y;
		return new Point(pOINTC.x, pOINTC.y);
	}

	private bool IsKeyOrMouseMessage(ref Message m)
	{
		if (m.Msg >= 512 && m.Msg <= 522)
		{
			return true;
		}
		if (m.Msg >= 160 && m.Msg <= 169)
		{
			return true;
		}
		if (m.Msg >= 256 && m.Msg <= 264)
		{
			return true;
		}
		return false;
	}

	private void FilterMessages(bool filter)
	{
		if (filter != _filtering)
		{
			if (filter)
			{
				Application.AddMessageFilter(this);
				_filtering = true;
			}
			else
			{
				Application.RemoveMessageFilter(this);
				_filtering = false;
			}
		}
	}

	private void OnCMSClosed(object sender, ToolStripDropDownClosedEventArgs e)
	{
		ContextMenuStrip contextMenuStrip = sender as ContextMenuStrip;
		contextMenuStrip.Closed -= OnCMSClosed;
		_suspended--;
		if (_filtering && _current == null)
		{
			Application.RemoveMessageFilter(this);
			_filtering = false;
		}
		_cms = null;
		_showingCMS = false;
		if (_cmsFinishDelegate != null)
		{
			_cmsFinishDelegate(this, e);
			_cmsFinishDelegate = null;
		}
	}
}
