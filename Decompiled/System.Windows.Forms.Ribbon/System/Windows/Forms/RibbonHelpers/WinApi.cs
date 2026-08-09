using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;

namespace System.Windows.Forms.RibbonHelpers;

public static class WinApi
{
	[StructLayout(LayoutKind.Sequential)]
	internal class MouseLLHookStruct
	{
		public POINT pt;

		public int mouseData;

		public int flags;

		public int time;

		public int extraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal class KeyboardLLHookStruct
	{
		public int vkCode;

		public int scanCode;

		public int flags;

		public int time;

		public int dwExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal class MouseHookStruct
	{
		public POINT pt;

		public int hwnd;

		public int wHitTestCode;

		public int dwExtraInfo;
	}

	internal struct POINT(int x, int y)
	{
		public int x = x;

		public int y = y;
	}

	internal struct DTTOPTS
	{
		public uint dwSize;

		public uint dwFlags;

		public uint crText;

		public uint crBorder;

		public uint crShadow;

		public int iTextShadowType;

		public POINT ptShadowOffset;

		public int iBorderSize;

		public int iFontPropId;

		public int iColorPropId;

		public int iStateId;

		public int fApplyOverlay;

		public int iGlowSize;

		public IntPtr pfnDrawTextCallback;

		public int lParam;
	}

	private struct RGBQUAD
	{
		public readonly byte rgbBlue;

		public readonly byte rgbGreen;

		public readonly byte rgbRed;

		public readonly byte rgbReserved;
	}

	private struct BITMAPINFOHEADER
	{
		public int biSize;

		public int biWidth;

		public int biHeight;

		public short biPlanes;

		public short biBitCount;

		public int biCompression;

		public readonly int biSizeImage;

		public readonly int biXPelsPerMeter;

		public readonly int biYPelsPerMeter;

		public readonly int biClrUsed;

		public readonly int biClrImportant;
	}

	private struct BITMAPINFO
	{
		public BITMAPINFOHEADER bmiHeader;

		public readonly RGBQUAD bmiColors;
	}

	public struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;

		public RECT(int left, int top, int right, int bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}

		public RECT(Rectangle rectangle)
		{
			Left = rectangle.X;
			Top = rectangle.Y;
			Right = rectangle.Right;
			Bottom = rectangle.Bottom;
		}
	}

	internal struct NCCALCSIZE_PARAMS
	{
		public RECT rect0;

		public RECT rect1;

		public RECT rect2;

		public IntPtr lppos;
	}

	internal struct MARGINS(int Left, int Right, int Top, int Bottom)
	{
		public int cxLeftWidth = Left;

		public int cxRightWidth = Right;

		public int cyTopHeight = Top;

		public int cyBottomHeight = Bottom;
	}

	[Flags]
	internal enum DCX
	{
		DCX_CACHE = 2,
		DCX_CLIPCHILDREN = 8,
		DCX_CLIPSIBLINGS = 0x10,
		DCX_EXCLUDERGN = 0x40,
		DCX_EXCLUDEUPDATE = 0x100,
		DCX_INTERSECTRGN = 0x80,
		DCX_INTERSECTUPDATE = 0x200,
		DCX_LOCKWINDOWUPDATE = 0x400,
		DCX_NORECOMPUTE = 0x100000,
		DCX_NORESETATTRS = 4,
		DCX_PARENTCLIP = 0x20,
		DCX_VALIDATE = 0x200000,
		DCX_WINDOW = 1
	}

	public enum SystemMetric
	{
		SM_ARRANGE = 56,
		SM_CLEANBOOT = 67,
		SM_CMONITORS = 80,
		SM_CMOUSEBUTTONS = 43,
		SM_CXBORDER = 5,
		SM_CXCURSOR = 13,
		SM_CXDLGFRAME = 7,
		SM_CXDOUBLECLK = 36,
		SM_CXDRAG = 68,
		SM_CXEDGE = 45,
		SM_CXFIXEDFRAME = 7,
		SM_CXFOCUSBORDER = 83,
		SM_CXFRAME = 32,
		SM_CXFULLSCREEN = 16,
		SM_CXHSCROLL = 21,
		SM_CXHTHUMB = 10,
		SM_CXICON = 11,
		SM_CXICONSPACING = 38,
		SM_CXMAXIMIZED = 61,
		SM_CXMAXTRACK = 59,
		SM_CXMENUCHECK = 71,
		SM_CXMENUSIZE = 54,
		SM_CXMIN = 28,
		SM_CXMINIMIZED = 57,
		SM_CXMINSPACING = 47,
		SM_CXMINTRACK = 34,
		SM_CXPADDEDBORDER = 92,
		SM_CXSCREEN = 0,
		SM_CXSIZE = 30,
		SM_CXSIZEFRAME = 32,
		SM_CXSMICON = 49,
		SM_CXSMSIZE = 52,
		SM_CXVIRTUALSCREEN = 78,
		SM_CXVSCROLL = 2,
		SM_CYBORDER = 6,
		SM_CYCAPTION = 4,
		SM_CYCURSOR = 14,
		SM_CYDLGFRAME = 8,
		SM_CYDOUBLECLK = 37,
		SM_CYDRAG = 69,
		SM_CYEDGE = 46,
		SM_CYFIXEDFRAME = 8,
		SM_CYFOCUSBORDER = 84,
		SM_CYFRAME = 33,
		SM_CYFULLSCREEN = 17,
		SM_CYHSCROLL = 3,
		SM_CYICON = 12,
		SM_CYICONSPACING = 39,
		SM_CYKANJIWINDOW = 18,
		SM_CYMAXIMIZED = 62,
		SM_CYMAXTRACK = 60,
		SM_CYMENU = 15,
		SM_CYMENUCHECK = 72,
		SM_CYMENUSIZE = 55,
		SM_CYMIN = 29,
		SM_CYMINIMIZED = 58,
		SM_CYMINSPACING = 48,
		SM_CYMINTRACK = 35,
		SM_CYSCREEN = 1,
		SM_CYSIZE = 31,
		SM_CYSIZEFRAME = 33,
		SM_CYSMCAPTION = 51,
		SM_CYSMICON = 50,
		SM_CYSMSIZE = 53,
		SM_CYVIRTUALSCREEN = 79,
		SM_CYVSCROLL = 20,
		SM_CYVTHUMB = 9,
		SM_DBCSENABLED = 42,
		SM_DEBUG = 22,
		SM_DIGITIZER = 94,
		SM_IMMENABLED = 82,
		SM_MAXIMUMTOUCHES = 95,
		SM_MEDIACENTER = 87,
		SM_MENUDROPALIGNMENT = 40,
		SM_MIDEASTENABLED = 74,
		SM_MOUSEPRESENT = 19,
		SM_MOUSEHORIZONTALWHEELPRESENT = 91,
		SM_MOUSEWHEELPRESENT = 75,
		SM_NETWORK = 63,
		SM_PENWINDOWS = 41,
		SM_REMOTECONTROL = 8193,
		SM_REMOTESESSION = 4096,
		SM_SAMEDISPLAYFORMAT = 81,
		SM_SECURE = 44,
		SM_SERVERR2 = 89,
		SM_SHOWSOUNDS = 70,
		SM_SHUTTINGDOWN = 8192,
		SM_SLOWMACHINE = 73,
		SM_STARTER = 88,
		SM_SWAPBUTTON = 23,
		SM_TABLETPC = 86,
		SM_XVIRTUALSCREEN = 76,
		SM_YVIRTUALSCREEN = 77
	}

	public enum HitTest
	{
		HTBORDER = 18,
		HTBOTTOM = 15,
		HTBOTTOMLEFT = 16,
		HTBOTTOMRIGHT = 17,
		HTCAPTION = 2,
		HTCLIENT = 1,
		HTCLOSE = 20,
		HTERROR = -2,
		HTGROWBOX = 4,
		HTHELP = 21,
		HTHSCROLL = 6,
		HTLEFT = 10,
		HTMENU = 5,
		HTMAXBUTTON = 9,
		HTMINBUTTON = 8,
		HTNOWHERE = 0,
		HTREDUCE = 8,
		HTRIGHT = 11,
		HTSIZE = 4,
		HTSYSMENU = 3,
		HTTOP = 12,
		HTTOPLEFT = 13,
		HTTOPRIGHT = 14,
		HTTRANSPARENT = -1,
		HTVSCROLL = 7,
		HTZOOM = 9
	}

	private static class OSVersion
	{
		private static string id;

		private static string caption;

		private static Version version;

		public static string Caption
		{
			get
			{
				if (caption == null)
				{
					init();
				}
				return caption;
			}
		}

		public static Version Version
		{
			get
			{
				if (version == null)
				{
					init();
				}
				return version;
			}
		}

		public static string ReleaseId
		{
			get
			{
				if (id == null)
				{
					init();
				}
				return id;
			}
		}

		private static void init()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
			string text = (string)registryKey.GetValue("ProductName");
			string text2 = (string)registryKey.GetValue("CurrentVersion");
			string text3 = (string)registryKey.GetValue("CurrentBuild");
			string text4 = (string)registryKey.GetValue("ReleaseId");
			caption = (string.IsNullOrEmpty(text) ? "Unknown" : text);
			id = (string.IsNullOrEmpty(text4) ? string.Empty : text4);
			version = new Version(string.IsNullOrEmpty(text2) ? "0.0" : (text2 + "." + (string.IsNullOrEmpty(text3) ? "0" : text3) + ".0"));
		}
	}

	public const int SWP_NOSIZE = 1;

	public const int SWP_NOMOVE = 2;

	public const int SWP_NOZORDER = 4;

	public const int SWP_NOREDRAW = 8;

	public const int SWP_NOACTIVATE = 16;

	public const int SWP_FRAMECHANGED = 32;

	public const int SWP_DRAWFRAME = 32;

	public const int SWP_SHOWWINDOW = 64;

	public const int SWP_HIDEWINDOW = 128;

	public const int SWP_NOCOPYBITS = 256;

	public const int SWP_NOOWNERZORDER = 512;

	public const int SWP_NOREPOSITION = 512;

	public const int SWP_NOSENDCHANGING = 1024;

	public const int WM_MOUSEFIRST = 512;

	public const int WM_MOUSEMOVE = 512;

	public const int WM_LBUTTONDOWN = 513;

	public const int WM_LBUTTONUP = 514;

	public const int WM_LBUTTONDBLCLK = 515;

	public const int WM_RBUTTONDOWN = 516;

	public const int WM_RBUTTONUP = 517;

	public const int WM_RBUTTONDBLCLK = 518;

	public const int WM_MBUTTONDOWN = 519;

	public const int WM_MBUTTONUP = 520;

	public const int WM_MBUTTONDBLCLK = 521;

	public const int WM_MOUSEWHEEL = 522;

	public const int WM_XBUTTONDOWN = 523;

	public const int WM_XBUTTONUP = 524;

	public const int WM_XBUTTONDBLCLK = 525;

	public const int WM_MOUSELAST = 525;

	public const int WM_KEYDOWN = 256;

	public const int WM_KEYUP = 257;

	public const int WM_SYSKEYDOWN = 260;

	public const int WM_SYSKEYUP = 261;

	public const byte VK_SHIFT = 16;

	public const byte VK_CAPITAL = 20;

	public const byte VK_NUMLOCK = 144;

	private const int DTT_COMPOSITED = 8192;

	private const int DTT_GLOWSIZE = 2048;

	private const int DT_SINGLELINE = 32;

	private const int DT_CENTER = 1;

	private const int DT_VCENTER = 4;

	private const int DT_NOPREFIX = 2048;

	public const int CS_DROPSHADOW = 131072;

	public const int WH_MOUSE_LL = 14;

	public const int WH_KEYBOARD_LL = 13;

	public const int WH_MOUSE = 7;

	public const int WH_KEYBOARD = 2;

	public const int WM_NCLBUTTONDOWN = 161;

	public const int WM_NCLBUTTONUP = 162;

	internal const int WM_NCRBUTTONUP = 165;

	public const int WM_SIZE = 5;

	public const int WM_ERASEBKGND = 20;

	public const int WM_NCCALCSIZE = 131;

	public const int WM_NCHITTEST = 132;

	public const int WM_NCMOUSEMOVE = 160;

	public const int WM_NCMOUSELEAVE = 674;

	public const int WM_NCPAINT = 133;

	public const int WM_NCACTIVATE = 134;

	public const int WM_SYSCOMMAND = 274;

	public const int WM_WINDOWPOSCHANGING = 70;

	public const int WM_WINDOWPOSCHANGED = 71;

	public const int WM_PAINT = 15;

	public const int WM_ACTIVATE = 6;

	public const int WM_THEMECHANGED = 794;

	internal const int MF_BYCOMMAND = 0;

	internal const int MF_BYPOSITION = 1024;

	internal const int MF_ENABLED = 0;

	internal const int MF_GRAYED = 1;

	internal const int MF_DISABLED = 2;

	public const int SC_RESTORE = 61728;

	internal const int SC_SIZE = 61440;

	internal const int SC_MOVE = 61456;

	internal const int SC_MINIMIZE = 61472;

	internal const int SC_MAXIMIZE = 61488;

	internal const int SC_CLOSE = 61536;

	public const int BI_RGB = 0;

	public const int DIB_RGB_COLORS = 0;

	public const int SRCCOPY = 13369376;

	public const uint TPM_LEFTBUTTON = 0u;

	public const uint TPM_RETURNCMD = 256u;

	private static int[] mfFlags = new int[2] { 1, 0 };

	public static bool IsWindows => Environment.OSVersion.Platform == PlatformID.Win32NT;

	public static bool IsVista
	{
		get
		{
			if (IsWindows)
			{
				return Environment.OSVersion.Version.Major >= 6;
			}
			return false;
		}
	}

	public static bool IsXP
	{
		get
		{
			if (IsWindows)
			{
				return Environment.OSVersion.Version.Major >= 5;
			}
			return false;
		}
	}

	public static string ReleaseID => OSVersion.ReleaseId;

	public static bool IsWin10
	{
		get
		{
			if (IsWindows && OSVersion.Version.Major == 6)
			{
				return OSVersion.Version.Minor == 3;
			}
			return false;
		}
	}

	public static bool IsGlassEnabled
	{
		get
		{
			if (IsVista)
			{
				int pfEnabled = 0;
				DwmIsCompositionEnabled(ref pfEnabled);
				return pfEnabled > 0;
			}
			return false;
		}
	}

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool RedrawWindow(IntPtr hWnd, [In] ref RECT lprcUpdate, IntPtr hrgnUpdate, uint flags);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

	[DllImport("user32.dll")]
	internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	[DllImport("user32")]
	internal static extern bool GetCursorPos(out POINT lpPoint);

	[DllImport("user32")]
	internal static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

	[DllImport("user32")]
	internal static extern int GetKeyboardState(byte[] pbKeyState);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	internal static extern short GetKeyState(int vKey);

	[DllImport("user32.dll")]
	internal static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

	[DllImport("user32.dll")]
	internal static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

	[DllImport("user32.dll")]
	internal static extern IntPtr SetWindowsHookEx(int idHook, GlobalHook.HookProcCallBack lpfn, IntPtr hInstance, int threadId);

	[DllImport("user32.dll")]
	internal static extern bool UnhookWindowsHookEx(IntPtr idHook);

	[DllImport("user32.dll")]
	internal static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	internal static extern IntPtr GetDC(IntPtr hdc);

	[DllImport("gdi32.dll")]
	internal static extern int SaveDC(IntPtr hdc);

	[DllImport("user32.dll")]
	internal static extern int ReleaseDC(IntPtr hdc, IntPtr state);

	[DllImport("UxTheme.dll", CharSet = CharSet.Unicode)]
	private static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);

	[DllImport("UxTheme.dll", CharSet = CharSet.Unicode)]
	internal static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags1, int dwFlags2, ref RECT pRect);

	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, IntPtr ppvBits, IntPtr hSection, uint dwOffset);

	[DllImport("gdi32.dll")]
	internal static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

	[DllImport("gdi32.dll")]
	internal static extern IntPtr CreateCompatibleDC(IntPtr hDC);

	[DllImport("gdi32.dll")]
	internal static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

	[DllImport("gdi32.dll")]
	internal static extern bool DeleteObject(IntPtr hObject);

	[DllImport("gdi32.dll")]
	internal static extern bool DeleteDC(IntPtr hdc);

	[DllImport("dwmapi.dll")]
	internal static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref MARGINS marInset);

	[DllImport("dwmapi.dll")]
	internal static extern int DwmDefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, out IntPtr result);

	[DllImport("dwmapi.dll")]
	internal static extern int DwmIsCompositionEnabled(ref int pfEnabled);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	internal static extern bool PostMessage(IntPtr hWnd, uint msg, UIntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	internal static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

	[DllImport("user32.dll")]
	internal static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

	[DllImport("user32.dll")]
	internal static extern bool SetMenuDefaultItem(IntPtr hMenu, uint uItem, uint fByPos);

	[DllImport("user32.dll")]
	internal static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

	[DllImport("user32.dll")]
	internal static extern int GetSystemMetrics(SystemMetric smIndex);

	public static void InvalidateWindow(IntPtr hDC)
	{
		RedrawWindow(hDC, IntPtr.Zero, IntPtr.Zero, 1281u);
	}

	public static void InvalidateNC(IntPtr hDC)
	{
		SetWindowPos(hDC, IntPtr.Zero, 0, 0, 0, 0, 55u);
	}

	public static short HiWord(int dwValue)
	{
		return (short)((dwValue >> 16) & 0xFFFF);
	}

	public static short LoWord(int dwValue)
	{
		return (short)(dwValue & 0xFFFF);
	}

	public static IntPtr MakeLParam(int LoWord, int HiWord)
	{
		return new IntPtr((HiWord << 16) | (LoWord & 0xFFFF));
	}

	internal static int Get_X_LParam(int dwValue)
	{
		return (short)(dwValue & 0xFFFF);
	}

	internal static int Get_Y_LParam(int dwValue)
	{
		return (short)((dwValue >> 16) & 0xFFFF);
	}

	public static void FillForGlass(Graphics g, Rectangle r)
	{
		RECT rECT = new RECT
		{
			Left = r.Left,
			Right = r.Right,
			Top = r.Top,
			Bottom = r.Bottom
		};
		IntPtr hdc = g.GetHdc();
		IntPtr intPtr = CreateCompatibleDC(hdc);
		IntPtr hObject = IntPtr.Zero;
		BITMAPINFO pbmi = new BITMAPINFO
		{
			bmiHeader = 
			{
				biHeight = -(rECT.Bottom - rECT.Top),
				biWidth = rECT.Right - rECT.Left,
				biPlanes = 1,
				biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER)),
				biBitCount = 32,
				biCompression = 0
			}
		};
		if (SaveDC(intPtr) != 0)
		{
			IntPtr intPtr2 = CreateDIBSection(intPtr, ref pbmi, 0u, (IntPtr)0, IntPtr.Zero, 0u);
			if (!(intPtr2 == IntPtr.Zero))
			{
				hObject = SelectObject(intPtr, intPtr2);
				BitBlt(hdc, rECT.Left, rECT.Top, rECT.Right - rECT.Left, rECT.Bottom - rECT.Top, intPtr, 0, 0, 13369376u);
			}
			SelectObject(intPtr, hObject);
			DeleteObject(intPtr2);
			ReleaseDC(intPtr, (IntPtr)(-1));
			DeleteDC(intPtr);
		}
		g.ReleaseHdc();
	}

	public static void DrawTextOnGlass(Graphics graphics, string text, Font font, Rectangle bounds, int glowSize)
	{
		if (!IsGlassEnabled)
		{
			return;
		}
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = graphics.GetHdc();
			IntPtr intPtr2 = CreateCompatibleDC(intPtr);
			IntPtr zero = IntPtr.Zero;
			int dwFlags = 2085;
			BITMAPINFO pbmi = new BITMAPINFO
			{
				bmiHeader = 
				{
					biHeight = -bounds.Height,
					biWidth = bounds.Width,
					biPlanes = 1,
					biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER)),
					biBitCount = 32,
					biCompression = 0
				}
			};
			if (SaveDC(intPtr2) == 0)
			{
				return;
			}
			IntPtr intPtr3 = CreateDIBSection(intPtr2, ref pbmi, 0u, (IntPtr)0, IntPtr.Zero, 0u);
			if (!(intPtr3 == IntPtr.Zero))
			{
				zero = SelectObject(intPtr2, intPtr3);
				IntPtr hObject = font.ToHfont();
				IntPtr hObject2 = SelectObject(intPtr2, hObject);
				try
				{
					VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(VisualStyleElement.Window.Caption.Active);
					DTTOPTS pOptions = new DTTOPTS
					{
						dwSize = (uint)Marshal.SizeOf(typeof(DTTOPTS)),
						dwFlags = 10240u,
						iGlowSize = glowSize
					};
					RECT pRect = new RECT(0, 0, bounds.Width, bounds.Height);
					DrawThemeTextEx(visualStyleRenderer.Handle, intPtr2, 0, 0, text, -1, dwFlags, ref pRect, ref pOptions);
					BitBlt(intPtr, bounds.Left, bounds.Top, bounds.Width, bounds.Height, intPtr2, 0, 0, 13369376u);
				}
				catch (Exception)
				{
				}
				SelectObject(intPtr2, zero);
				SelectObject(intPtr2, hObject2);
				DeleteObject(intPtr3);
				DeleteObject(hObject);
				ReleaseDC(intPtr2, (IntPtr)(-1));
				DeleteDC(intPtr2);
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				graphics.ReleaseHdc(intPtr);
			}
		}
	}

	public static void ShowSystemMenu(Form form, int xMouse, int yMouse)
	{
		IntPtr menu = GetSystemMenu(form.Handle, bRevert: false);
		FormBorderStyle formBorderStyle = form.FormBorderStyle;
		FormWindowState windowState = form.WindowState;
		if (formBorderStyle == FormBorderStyle.FixedSingle || formBorderStyle == FormBorderStyle.Sizable || formBorderStyle == FormBorderStyle.FixedToolWindow || formBorderStyle == FormBorderStyle.SizableToolWindow)
		{
			UpdateItem(61728u, windowState != FormWindowState.Normal, makeDefaultIfEnabled: true);
			UpdateItem(61456u, windowState != FormWindowState.Maximized, makeDefaultIfEnabled: false);
			UpdateItem(61440u, windowState != FormWindowState.Maximized && (formBorderStyle == FormBorderStyle.Sizable || formBorderStyle == FormBorderStyle.SizableToolWindow), makeDefaultIfEnabled: false);
			UpdateItem(61472u, form.MinimizeBox && (formBorderStyle == FormBorderStyle.FixedSingle || formBorderStyle == FormBorderStyle.Sizable), makeDefaultIfEnabled: false);
			UpdateItem(61488u, form.MaximizeBox && (formBorderStyle == FormBorderStyle.FixedSingle || formBorderStyle == FormBorderStyle.Sizable) && windowState != FormWindowState.Maximized, makeDefaultIfEnabled: true);
		}
		SetMenuDefaultItem(menu, 61536u, 0u);
		UIntPtr zero = UIntPtr.Zero;
		zero = (UIntPtr)TrackPopupMenuEx(menu, (uint)(0x100uL | (ulong)GetSystemMetrics(SystemMetric.SM_MENUDROPALIGNMENT)), xMouse, yMouse, form.Handle, IntPtr.Zero);
		if (!(zero == UIntPtr.Zero))
		{
			PostMessage(form.Handle, 274u, zero, IntPtr.Zero);
		}
		void UpdateItem(uint ID, bool enable, bool makeDefaultIfEnabled)
		{
			int num = 0;
			if (enable)
			{
				num = 1;
			}
			EnableMenuItem(menu, ID, (uint)(0 | mfFlags[num]));
			if (makeDefaultIfEnabled && enable)
			{
				SetMenuDefaultItem(menu, ID, 0u);
			}
		}
	}

	public static void ShowSystemMenu(Form form)
	{
		if (GetCursorPos(out var lpPoint))
		{
			ShowSystemMenu(form, lpPoint.x, lpPoint.y);
		}
	}
}
