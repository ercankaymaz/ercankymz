using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Xceed.Wpf.AvalonDock;

internal static class Win32Helper
{
	[Flags]
	internal enum SetWindowPosFlags : uint
	{
		SynchronousWindowPosition = 0x4000u,
		DeferErase = 0x2000u,
		DrawFrame = 0x20u,
		FrameChanged = 0x20u,
		HideWindow = 0x80u,
		DoNotActivate = 0x10u,
		DoNotCopyBits = 0x100u,
		IgnoreMove = 2u,
		DoNotChangeOwnerZOrder = 0x200u,
		DoNotRedraw = 8u,
		DoNotReposition = 0x200u,
		DoNotSendChangingEvent = 0x400u,
		IgnoreResize = 1u,
		IgnoreZOrder = 4u,
		ShowWindow = 0x40u
	}

	[StructLayout(LayoutKind.Sequential)]
	internal class WINDOWPOS
	{
		public IntPtr hwnd;

		public IntPtr hwndInsertAfter;

		public int x;

		public int y;

		public int cx;

		public int cy;

		public int flags;
	}

	public enum HookType
	{
		WH_JOURNALRECORD,
		WH_JOURNALPLAYBACK,
		WH_KEYBOARD,
		WH_GETMESSAGE,
		WH_CALLWNDPROC,
		WH_CBT,
		WH_SYSMSGFILTER,
		WH_MOUSE,
		WH_HARDWARE,
		WH_DEBUG,
		WH_SHELL,
		WH_FOREGROUNDIDLE,
		WH_CALLWNDPROCRET,
		WH_KEYBOARD_LL,
		WH_MOUSE_LL
	}

	public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

	[Serializable]
	internal struct RECT(int left_, int top_, int right_, int bottom_)
	{
		public int Left = left_;

		public int Top = top_;

		public int Right = right_;

		public int Bottom = bottom_;

		public int Height => Bottom - Top;

		public int Width => Right - Left;

		public Size Size => new Size((double)Width, (double)Height);

		public Point Location => new Point((double)Left, (double)Top);

		public Rect ToRectangle()
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			return new Rect((double)Left, (double)Top, (double)Right, (double)Bottom);
		}

		public static RECT FromRectangle(Rect rectangle)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			return (RECT)new Rect(((Rect)(ref rectangle)).Left, ((Rect)(ref rectangle)).Top, ((Rect)(ref rectangle)).Right, ((Rect)(ref rectangle)).Bottom);
		}

		public override int GetHashCode()
		{
			return Left ^ ((Top << 13) | (Top >> 19)) ^ ((Width << 26) | (Width >> 6)) ^ ((Height << 7) | (Height >> 25));
		}

		public static implicit operator Rect(RECT rect)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return rect.ToRectangle();
		}

		public static implicit operator RECT(Rect rect)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return FromRectangle(rect);
		}
	}

	internal enum GetWindow_Cmd : uint
	{
		GW_HWNDFIRST,
		GW_HWNDLAST,
		GW_HWNDNEXT,
		GW_HWNDPREV,
		GW_OWNER,
		GW_CHILD,
		GW_ENABLEDPOPUP
	}

	internal struct Win32Point
	{
		public int X;

		public int Y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public class MonitorInfo
	{
		public int Size = Marshal.SizeOf(typeof(MonitorInfo));

		public RECT Monitor;

		public RECT Work;

		public uint Flags;
	}

	internal const int WS_CHILD = 1073741824;

	internal const int WS_VISIBLE = 268435456;

	internal const int WS_VSCROLL = 2097152;

	internal const int WS_BORDER = 8388608;

	internal const int WS_CLIPSIBLINGS = 67108864;

	internal const int WS_CLIPCHILDREN = 33554432;

	internal const int WS_TABSTOP = 65536;

	internal const int WS_GROUP = 131072;

	internal static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

	internal static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

	internal static readonly IntPtr HWND_TOP = new IntPtr(0);

	internal static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

	internal const int NCCALCSIZE = 131;

	internal const int WM_WINDOWPOSCHANGED = 71;

	internal const int WM_WINDOWPOSCHANGING = 70;

	internal const int WM_NCMOUSEMOVE = 160;

	internal const int WM_NCLBUTTONDOWN = 161;

	internal const int WM_NCLBUTTONUP = 162;

	internal const int WM_NCLBUTTONDBLCLK = 163;

	internal const int WM_NCRBUTTONDOWN = 164;

	internal const int WM_NCRBUTTONUP = 165;

	internal const int WM_CAPTURECHANGED = 533;

	internal const int WM_EXITSIZEMOVE = 562;

	internal const int WM_ENTERSIZEMOVE = 561;

	internal const int WM_MOVE = 3;

	internal const int WM_MOVING = 534;

	internal const int WM_KILLFOCUS = 8;

	internal const int WM_SETFOCUS = 7;

	internal const int WM_ACTIVATE = 6;

	internal const int WM_NCHITTEST = 132;

	internal const int WM_INITMENUPOPUP = 279;

	internal const int WM_KEYDOWN = 256;

	internal const int WM_KEYUP = 257;

	internal const int WA_INACTIVE = 0;

	internal const int WM_SYSCOMMAND = 274;

	internal const int SC_MAXIMIZE = 61488;

	internal const int SC_RESTORE = 61728;

	internal const int WM_CREATE = 1;

	internal const int HT_CAPTION = 2;

	public const int HCBT_SETFOCUS = 9;

	public const int HCBT_ACTIVATE = 5;

	internal const uint GW_HWNDNEXT = 2u;

	internal const uint GW_HWNDPREV = 3u;

	internal const int WM_MOUSEMOVE = 512;

	internal const int WM_LBUTTONDOWN = 513;

	internal const int WM_LBUTTONUP = 514;

	internal const int WM_LBUTTONDBLCLK = 515;

	internal const int WM_RBUTTONDOWN = 516;

	internal const int WM_RBUTTONUP = 517;

	internal const int WM_RBUTTONDBLCLK = 518;

	internal const int WM_MBUTTONDOWN = 519;

	internal const int WM_MBUTTONUP = 520;

	internal const int WM_MBUTTONDBLCLK = 521;

	internal const int WM_MOUSEWHEEL = 522;

	internal const int WM_MOUSEHWHEEL = 526;

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	internal static extern IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, IntPtr hwndParent, IntPtr hMenu, IntPtr hInst, [MarshalAs(UnmanagedType.AsAny)] object pvParam);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	internal static extern bool IsChild(IntPtr hWndParent, IntPtr hwnd);

	[DllImport("user32.dll")]
	internal static extern IntPtr SetFocus(IntPtr hWnd);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr SetActiveWindow(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	internal static extern bool DestroyWindow(IntPtr hwnd);

	[DllImport("user32.dll")]
	internal static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	internal static extern int PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

	[DllImport("user32.dll")]
	internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

	[DllImport("kernel32.dll")]
	public static extern uint GetCurrentThreadId();

	[DllImport("user32.dll")]
	public static extern IntPtr SetWindowsHookEx(HookType code, HookProc func, IntPtr hInstance, int threadID);

	[DllImport("user32.dll")]
	public static extern int UnhookWindowsHookEx(IntPtr hhook);

	[DllImport("user32.dll")]
	public static extern int CallNextHookEx(IntPtr hhook, int code, IntPtr wParam, IntPtr lParam);

	internal static RECT GetClientRect(IntPtr hWnd)
	{
		RECT lpRect = default(RECT);
		GetClientRect(hWnd, out lpRect);
		return lpRect;
	}

	internal static RECT GetWindowRect(IntPtr hWnd)
	{
		RECT lpRect = default(RECT);
		GetWindowRect(hWnd, out lpRect);
		return lpRect;
	}

	[DllImport("user32.dll")]
	internal static extern IntPtr GetTopWindow(IntPtr hWnd);

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

	internal static int MakeLParam(int LoWord, int HiWord)
	{
		return (HiWord << 16) | (LoWord & 0xFFFF);
	}

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool GetCursorPos(ref Win32Point pt);

	internal static Point GetMousePosition()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Win32Point pt = default(Win32Point);
		GetCursorPos(ref pt);
		return new Point((double)pt.X, (double)pt.Y);
	}

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool IsWindowVisible(IntPtr hWnd);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool IsWindowEnabled(IntPtr hWnd);

	[DllImport("user32.dll")]
	internal static extern IntPtr GetFocus();

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool BringWindowToTop(IntPtr hWnd);

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	internal static extern IntPtr GetParent(IntPtr hWnd);

	[DllImport("user32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

	public static void SetOwner(IntPtr childHandle, IntPtr ownerHandle)
	{
		SetWindowLong(childHandle, -8, ownerHandle.ToInt32());
	}

	public static IntPtr GetOwner(IntPtr childHandle)
	{
		return new IntPtr(GetWindowLong(childHandle, -8));
	}

	[DllImport("user32.dll")]
	public static extern IntPtr MonitorFromRect([In] ref RECT lprc, uint dwFlags);

	[DllImport("user32.dll")]
	public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetMonitorInfo(IntPtr hMonitor, [In][Out] MonitorInfo lpmi);
}
