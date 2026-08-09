using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Windows.Forms.RibbonHelpers;

internal class GlobalHook : IDisposable
{
	public enum HookTypes
	{
		Mouse,
		Keyboard
	}

	internal delegate IntPtr HookProcCallBack(int nCode, IntPtr wParam, IntPtr lParam);

	private HookProcCallBack _HookProc;

	private IntPtr _handle;

	private HookTypes _hookType;

	public event MouseEventHandler MouseClick;

	public event MouseEventHandler MouseDoubleClick;

	public event MouseEventHandler MouseWheel;

	public event MouseEventHandler MouseDown;

	public event MouseEventHandler MouseUp;

	public event MouseEventHandler MouseMove;

	public event KeyEventHandler KeyDown;

	public event KeyEventHandler KeyUp;

	public event KeyPressEventHandler KeyPress;

	public GlobalHook(HookTypes hookType)
	{
		_hookType = hookType;
		InstallHook();
	}

	~GlobalHook()
	{
		Dispose(disposing: false);
	}

	protected virtual void OnMouseClick(MouseEventArgs e)
	{
		if (this.MouseClick != null)
		{
			this.MouseClick(this, e);
		}
	}

	protected virtual void OnMouseDoubleClick(MouseEventArgs e)
	{
		if (this.MouseDoubleClick != null)
		{
			this.MouseDoubleClick(this, e);
		}
	}

	protected virtual void OnMouseWheel(MouseEventArgs e)
	{
		if (this.MouseWheel != null)
		{
			this.MouseWheel(this, e);
		}
	}

	protected virtual void OnMouseDown(MouseEventArgs e)
	{
		if (this.MouseDown != null)
		{
			this.MouseDown(this, e);
		}
	}

	protected virtual void OnMouseUp(MouseEventArgs e)
	{
		if (this.MouseUp != null)
		{
			this.MouseUp(this, e);
		}
	}

	protected virtual void OnMouseMove(MouseEventArgs e)
	{
		if (this.MouseMove != null)
		{
			this.MouseMove(this, e);
		}
	}

	protected virtual void OnKeyDown(KeyEventArgs e)
	{
		if (this.KeyDown != null)
		{
			this.KeyDown(this, e);
		}
	}

	protected virtual void OnKeyUp(KeyEventArgs e)
	{
		if (this.KeyUp != null)
		{
			this.KeyUp(this, e);
		}
	}

	protected virtual void OnKeyPress(KeyPressEventArgs e)
	{
		if (this.KeyPress != null)
		{
			this.KeyPress(this, e);
		}
	}

	private IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
	{
		if (code < 0)
		{
			return WinApi.CallNextHookEx(_handle, code, wParam, lParam);
		}
		return _hookType switch
		{
			HookTypes.Mouse => MouseProc(code, wParam, lParam), 
			HookTypes.Keyboard => KeyboardProc(code, wParam, lParam), 
			_ => throw new ArgumentException("HookType not supported"), 
		};
	}

	private IntPtr KeyboardProc(int code, IntPtr wParam, IntPtr lParam)
	{
		WinApi.KeyboardLLHookStruct keyboardLLHookStruct = (WinApi.KeyboardLLHookStruct)Marshal.PtrToStructure(lParam, typeof(WinApi.KeyboardLLHookStruct));
		int num = wParam.ToInt32();
		bool flag = false;
		switch (num)
		{
		case 256:
		case 260:
		{
			KeyEventArgs e2 = new KeyEventArgs((Keys)keyboardLLHookStruct.vkCode);
			OnKeyDown(e2);
			flag = e2.Handled;
			break;
		}
		case 257:
		case 261:
		{
			KeyEventArgs e = new KeyEventArgs((Keys)keyboardLLHookStruct.vkCode);
			OnKeyUp(e);
			flag = e.Handled;
			break;
		}
		}
		if (num == 256 && this.KeyPress != null)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[2];
			WinApi.GetKeyboardState(array);
			int num2 = WinApi.ToAscii(keyboardLLHookStruct.vkCode, keyboardLLHookStruct.scanCode, array, array2, keyboardLLHookStruct.flags);
			if (num2 == 1 || num2 == 2)
			{
				bool num3 = (WinApi.GetKeyState(16) & 0x80) == 128;
				bool flag2 = WinApi.GetKeyState(20) != 0;
				char c = (char)array2[0];
				if ((num3 ^ flag2) && char.IsLetter(c))
				{
					c = char.ToUpper(c);
				}
				KeyPressEventArgs e3 = new KeyPressEventArgs(c);
				OnKeyPress(e3);
				flag |= e3.Handled;
			}
		}
		if (!flag)
		{
			return WinApi.CallNextHookEx(_handle, code, wParam, lParam);
		}
		return (IntPtr)1;
	}

	private IntPtr MouseProc(int code, IntPtr wParam, IntPtr lParam)
	{
		WinApi.MouseLLHookStruct obj = (WinApi.MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(WinApi.MouseLLHookStruct));
		int num = wParam.ToInt32();
		int x = obj.pt.x;
		int y = obj.pt.y;
		int delta = (short)((obj.mouseData >> 16) & 0xFFFF);
		switch (num)
		{
		case 522:
			OnMouseWheel(new MouseEventArgs(MouseButtons.None, 0, x, y, delta));
			break;
		case 512:
			OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, x, y, delta));
			break;
		case 515:
			OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Left, 0, x, y, delta));
			break;
		case 513:
			OnMouseDown(new MouseEventArgs(MouseButtons.Left, 0, x, y, delta));
			break;
		case 514:
			OnMouseUp(new MouseEventArgs(MouseButtons.Left, 0, x, y, delta));
			OnMouseClick(new MouseEventArgs(MouseButtons.Left, 0, x, y, delta));
			break;
		case 521:
			OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Middle, 0, x, y, delta));
			break;
		case 519:
			OnMouseDown(new MouseEventArgs(MouseButtons.Middle, 0, x, y, delta));
			break;
		case 520:
			OnMouseUp(new MouseEventArgs(MouseButtons.Middle, 0, x, y, delta));
			break;
		case 518:
			OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Right, 0, x, y, delta));
			break;
		case 516:
			OnMouseDown(new MouseEventArgs(MouseButtons.Right, 0, x, y, delta));
			break;
		case 517:
			OnMouseUp(new MouseEventArgs(MouseButtons.Right, 0, x, y, delta));
			break;
		case 525:
			OnMouseDoubleClick(new MouseEventArgs(MouseButtons.XButton1, 0, x, y, delta));
			break;
		case 523:
			OnMouseDown(new MouseEventArgs(MouseButtons.XButton1, 0, x, y, delta));
			break;
		case 524:
			OnMouseUp(new MouseEventArgs(MouseButtons.XButton1, 0, x, y, delta));
			break;
		}
		return WinApi.CallNextHookEx(_handle, code, wParam, lParam);
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	private void InstallHook()
	{
		if (_handle != IntPtr.Zero)
		{
			throw new InvalidOperationException("Hook is already installed");
		}
		int num = 0;
		num = _hookType switch
		{
			HookTypes.Mouse => 14, 
			HookTypes.Keyboard => 13, 
			_ => throw new ArgumentException("HookType is not supported"), 
		};
		_HookProc = HookProc;
		_handle = WinApi.SetWindowsHookEx(num, _HookProc, Process.GetCurrentProcess().MainModule.BaseAddress, 0);
		int lastWin32Error = Marshal.GetLastWin32Error();
		if (_handle == IntPtr.Zero)
		{
			throw new Win32Exception(lastWin32Error);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	private void Unhook()
	{
		if (!(_handle != IntPtr.Zero))
		{
			return;
		}
		try
		{
			if (!WinApi.UnhookWindowsHookEx(_handle))
			{
				Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
				if (ex.NativeErrorCode != 0)
				{
					throw ex;
				}
			}
			_handle = IntPtr.Zero;
		}
		catch (Exception)
		{
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (_handle != IntPtr.Zero)
		{
			Unhook();
		}
	}
}
