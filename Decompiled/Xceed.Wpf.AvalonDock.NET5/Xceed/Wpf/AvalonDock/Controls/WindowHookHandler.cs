using System;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class WindowHookHandler
{
	private IntPtr _windowHook;

	private Win32Helper.HookProc _hookProc;

	private ReentrantFlag _insideActivateEvent = new ReentrantFlag();

	public event EventHandler<FocusChangeEventArgs> FocusChanged;

	public void Attach()
	{
		_hookProc = HookProc;
		_windowHook = Win32Helper.SetWindowsHookEx(Win32Helper.HookType.WH_CBT, _hookProc, IntPtr.Zero, (int)Win32Helper.GetCurrentThreadId());
	}

	public void Detach()
	{
		Win32Helper.UnhookWindowsHookEx(_windowHook);
	}

	public int HookProc(int code, IntPtr wParam, IntPtr lParam)
	{
		switch (code)
		{
		case 9:
			if (this.FocusChanged != null)
			{
				this.FocusChanged(this, new FocusChangeEventArgs(wParam, lParam));
			}
			break;
		case 5:
			if (_insideActivateEvent.CanEnter)
			{
				using (_insideActivateEvent.Enter())
				{
				}
			}
			break;
		}
		return Win32Helper.CallNextHookEx(_windowHook, code, wParam, lParam);
	}
}
