using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ComponentFactory.Krypton.Toolkit;

internal class PI
{
	internal struct SIZE
	{
		public int cx;

		public int cy;
	}

	internal struct POINT
	{
		public int x;

		public int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal class POINTC
	{
		public int x;

		public int y;
	}

	internal struct RECT
	{
		public int left;

		public int top;

		public int right;

		public int bottom;
	}

	internal struct MARGINS
	{
		public int leftWidth;

		public int rightWidth;

		public int topHeight;

		public int bottomHeight;
	}

	internal struct TRACKMOUSEEVENTS
	{
		public uint cbSize;

		public uint dwFlags;

		public IntPtr hWnd;

		public uint dwHoverTime;
	}

	internal struct NCCALCSIZE_PARAMS
	{
		public RECT rectProposed;

		public RECT rectBeforeMove;

		public RECT rectClientBeforeMove;

		public int lpPos;
	}

	internal struct WINDOWPOS
	{
		public IntPtr hwnd;

		public IntPtr hwndInsertAfter;

		public int x;

		public int y;

		public int cx;

		public int cy;

		public uint flags;
	}

	internal struct GUIDSTRUCT
	{
		public ushort Data1;

		public ushort Data2;

		public ushort Data3;

		public ushort Data4;

		public ushort Data5;

		public ushort Data6;

		public ushort Data7;

		public ushort Data8;
	}

	internal struct MSG
	{
		public IntPtr hwnd;

		public int message;

		public IntPtr wParam;

		public IntPtr lParam;

		public uint time;

		public POINT pt;
	}

	internal struct DTTOPTS
	{
		public int dwSize;

		public int dwFlags;

		public int crText;

		public int crBorder;

		public int crShadow;

		public int iTextShadowType;

		public POINT ptShadowOffset;

		public int iBorderSize;

		public int iFontPropId;

		public int iColorPropId;

		public int iStateId;

		public bool fApplyOverlay;

		public int iGlowSize;

		public int pfnDrawTextCallback;

		public IntPtr lParam;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal class BITMAPINFO
	{
		public int biSize;

		public int biWidth;

		public int biHeight;

		public short biPlanes;

		public short biBitCount;

		public int biCompression;

		public int biSizeImage;

		public int biXPelsPerMeter;

		public int biYPelsPerMeter;

		public int biClrUsed;

		public int biClrImportant;

		public byte bmiColors_rgbBlue;

		public byte bmiColors_rgbGreen;

		public byte bmiColors_rgbRed;

		public byte bmiColors_rgbReserved;
	}

	internal struct PAINTSTRUCT
	{
		private IntPtr hdc;

		public bool fErase;

		public RECT rcPaint;

		public bool fRestore;

		public bool fIncUpdate;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] rgbReserved;
	}

	internal struct CHARRANGE
	{
		public int cpMin;

		public int cpMax;
	}

	internal struct FORMATRANGE
	{
		public IntPtr hdc;

		public IntPtr hdcTarget;

		public RECT rc;

		public RECT rcPage;

		public CHARRANGE chrg;
	}

	internal const uint WS_POPUP = 2147483648u;

	internal const uint WS_MINIMIZE = 536870912u;

	internal const uint WS_MAXIMIZE = 16777216u;

	internal const uint WS_VISIBLE = 268435456u;

	internal const uint WS_BORDER = 8388608u;

	internal const int PRF_CLIENT = 4;

	internal const int WS_EX_TOPMOST = 8;

	internal const int WS_EX_TOOLWINDOW = 128;

	internal const int WS_EX_LAYERED = 524288;

	internal const int WS_EX_CLIENTEDGE = 512;

	internal const int SC_MINIMIZE = 61472;

	internal const int SC_MAXIMIZE = 61488;

	internal const int SC_CLOSE = 61536;

	internal const int SC_RESTORE = 61728;

	internal const int SW_SHOWNOACTIVATE = 4;

	internal const int WM_DESTROY = 2;

	internal const int WM_NCDESTROY = 130;

	internal const int WM_MOVE = 3;

	internal const int WM_SETFOCUS = 7;

	internal const int WM_KILLFOCUS = 8;

	internal const int WM_SETREDRAW = 11;

	internal const int WM_SETTEXT = 12;

	internal const int WM_PAINT = 15;

	internal const int WM_PRINTCLIENT = 792;

	internal const int WM_CTLCOLOR = 25;

	internal const int WM_ERASEBKGND = 20;

	internal const int WM_MOUSEACTIVATE = 33;

	internal const int WM_WINDOWPOSCHANGING = 70;

	internal const int WM_WINDOWPOSCHANGED = 71;

	internal const int WM_HELP = 83;

	internal const int WM_NCCALCSIZE = 131;

	internal const int WM_NCHITTEST = 132;

	internal const int WM_NCPAINT = 133;

	internal const int WM_NCACTIVATE = 134;

	internal const int WM_NCMOUSEMOVE = 160;

	internal const int WM_NCLBUTTONDOWN = 161;

	internal const int WM_NCLBUTTONUP = 162;

	internal const int WM_NCLBUTTONDBLCLK = 163;

	internal const int WM_NCRBUTTONDOWN = 164;

	internal const int WM_NCMBUTTONDOWN = 167;

	internal const int WM_NCMBUTTONDBLCLK = 169;

	internal const int WM_SETCURSOR = 32;

	internal const int WM_KEYDOWN = 256;

	internal const int WM_KEYUP = 257;

	internal const int WM_CHAR = 258;

	internal const int WM_DEADCHAR = 259;

	internal const int WM_SYSKEYDOWN = 260;

	internal const int WM_SYSKEYUP = 261;

	internal const int WM_SYSCHAR = 262;

	internal const int WM_SYSDEADCHAR = 263;

	internal const int WM_KEYLAST = 264;

	internal const int WM_SYSCOMMAND = 274;

	internal const int WM_HSCROLL = 276;

	internal const int WM_VSCROLL = 277;

	internal const int WM_INITMENU = 278;

	internal const int WM_CTLCOLOREDIT = 307;

	internal const int WM_MOUSEMOVE = 512;

	internal const int WM_LBUTTONDOWN = 513;

	internal const int WM_LBUTTONUP = 514;

	internal const int WM_LBUTTONDBLCLK = 515;

	internal const int WM_RBUTTONDOWN = 516;

	internal const int WM_RBUTTONUP = 517;

	internal const int WM_MBUTTONDOWN = 519;

	internal const int WM_MBUTTONUP = 520;

	internal const int WM_MOUSEWHEEL = 522;

	internal const int WM_NCMOUSELEAVE = 674;

	internal const int WM_MOUSELEAVE = 675;

	internal const int WM_PRINT = 791;

	internal const int WM_CONTEXTMENU = 123;

	internal const int MA_NOACTIVATE = 3;

	internal const int EM_FORMATRANGE = 1081;

	internal const int SWP_NOSIZE = 1;

	internal const int SWP_NOMOVE = 2;

	internal const int SWP_NOZORDER = 4;

	internal const int SWP_NOACTIVATE = 16;

	internal const int SWP_FRAMECHANGED = 32;

	internal const int SWP_NOOWNERZORDER = 512;

	internal const int SWP_SHOWWINDOW = 64;

	internal const int SWP_HIDEWINDOW = 128;

	internal const int RDW_INVALIDATE = 1;

	internal const int RDW_UPDATENOW = 256;

	internal const int RDW_FRAME = 1024;

	internal const int DCX_WINDOW = 1;

	internal const int DCX_CACHE = 2;

	internal const int DCX_CLIPSIBLINGS = 16;

	internal const int DCX_INTERSECTRGN = 128;

	internal const int TME_LEAVE = 2;

	internal const int TME_NONCLIENT = 16;

	internal const int HTNOWHERE = 0;

	internal const int HTCLIENT = 1;

	internal const int HTCAPTION = 2;

	internal const int HTSYSMENU = 3;

	internal const int HTGROWBOX = 4;

	internal const int HTSIZE = 4;

	internal const int HTMENU = 5;

	internal const int HTLEFT = 10;

	internal const int HTRIGHT = 11;

	internal const int HTTOP = 12;

	internal const int HTTOPLEFT = 13;

	internal const int HTTOPRIGHT = 14;

	internal const int HTBOTTOM = 15;

	internal const int HTBOTTOMLEFT = 16;

	internal const int HTBOTTOMRIGHT = 17;

	internal const int HTBORDER = 18;

	internal const int HTHELP = 21;

	internal const int HTIGNORE = 255;

	internal const int HTTRANSPARENT = -1;

	internal const int ULW_ALPHA = 2;

	internal const int DEVICE_BITSPIXEL = 12;

	internal const int DEVICE_PLANES = 14;

	internal const int SRCCOPY = 13369376;

	internal const int GWL_STYLE = -16;

	internal const int DTM_SETMCCOLOR = 4102;

	internal const int DTT_COMPOSITED = 8192;

	internal const int DTT_GLOWSIZE = 2048;

	internal const int DTT_TEXTCOLOR = 1;

	internal const int MCSC_BACKGROUND = 0;

	internal const int PLANES = 14;

	internal const int BITSPIXEL = 12;

	internal const byte AC_SRC_OVER = 0;

	internal const byte AC_SRC_ALPHA = 1;

	internal const uint GW_HWNDFIRST = 0u;

	internal const uint GW_HWNDLAST = 1u;

	internal const uint GW_HWNDNEXT = 2u;

	internal const uint GW_HWNDPREV = 3u;

	internal const uint GW_OWNER = 4u;

	internal const uint GW_CHILD = 5u;

	internal const uint GW_ENABLEDPOPUP = 6u;

	internal static int LOWORD(IntPtr value)
	{
		int num = (int)value.ToInt64() & 0xFFFF;
		return (num > 32767) ? (num - 65536) : num;
	}

	internal static int HIWORD(IntPtr value)
	{
		int num = ((int)value.ToInt64() >> 16) & 0xFFFF;
		return (num > 32767) ? (num - 65536) : num;
	}

	internal static int LOWORD(int value)
	{
		return value & 0xFFFF;
	}

	internal static int HIWORD(int value)
	{
		return (value >> 16) & 0xFFFF;
	}

	internal static int MAKELOWORD(int value)
	{
		return value & 0xFFFF;
	}

	internal static int MAKEHIWORD(int value)
	{
		return (value & 0xFFFF) << 16;
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern short VkKeyScan(char ch);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr WindowFromPoint(POINT pt);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern uint SetWindowLong(IntPtr hwnd, int nIndex, int nLong);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetActiveWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern int ShowWindow(IntPtr hWnd, short cmdShow);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern ushort GetKeyState(int virtKey);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern uint SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int X, int Y, int Width, int Height, uint flags);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool RedrawWindow(IntPtr hWnd, IntPtr rectUpdate, IntPtr hRgnUpdate, uint uFlags);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool RedrawWindow(IntPtr hWnd, ref RECT rectUpdate, IntPtr hRgnUpdate, uint uFlags);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRgnClip, uint fdwOptions);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetWindowDC(IntPtr hwnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern void DisableProcessWindowsGhosting();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern void AdjustWindowRectEx(ref RECT rect, int dwStyle, bool hasMenu, int dwExSytle);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In][Out] POINTC pt, int cPoints);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool TranslateMessage([In] ref MSG lpMsg);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr BeginPaint(IntPtr hwnd, ref PAINTSTRUCT ps);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool EndPaint(IntPtr hwnd, ref PAINTSTRUCT ps);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool InflateRect(ref RECT lprc, int dx, int dy);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern uint RegisterWindowMessage(string lpString);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern int ExcludeClipRect(IntPtr hDC, int x1, int y1, int x2, int y2);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern int IntersectClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr CreateDIBSection(IntPtr hDC, BITMAPINFO pBMI, uint iUsage, int ppvBits, IntPtr hSection, uint dwOffset);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr CreateCompatibleDC(IntPtr hDC);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr DeleteObject(IntPtr hObject);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern bool DeleteDC(IntPtr hDC);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "SaveDC", ExactSpelling = true, SetLastError = true)]
	internal static extern int IntSaveDC(HandleRef hDC);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "RestoreDC", ExactSpelling = true, SetLastError = true)]
	internal static extern bool IntRestoreDC(HandleRef hDC, int nSavedDC);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern bool GetViewportOrgEx(HandleRef hDC, [In][Out] POINTC point);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "CreateRectRgn", ExactSpelling = true, SetLastError = true)]
	internal static extern IntPtr IntCreateRectRgn(int x1, int y1, int x2, int y2);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern int GetClipRgn(HandleRef hDC, HandleRef hRgn);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern bool SetViewportOrgEx(HandleRef hDC, int x, int y, [In][Out] POINTC point);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern int GetRgnBox(HandleRef hRegion, ref RECT clipRect);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern int CombineRgn(HandleRef hRgn, HandleRef hRgn1, HandleRef hRgn2, int nCombineMode);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern int SelectClipRgn(HandleRef hDC, HandleRef hRgn);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern uint SetTextColor(IntPtr hdc, int crColor);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern uint SetBkColor(IntPtr hdc, int crColor);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern IntPtr CreateSolidBrush(int crColor);

	[DllImport("dwmapi.dll", CharSet = CharSet.Auto)]
	internal static extern void DwmIsCompositionEnabled(ref bool enabled);

	[DllImport("dwmapi.dll", CharSet = CharSet.Auto)]
	internal static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

	[DllImport("dwmapi.dll", CharSet = CharSet.Auto)]
	internal static extern int DwmDefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, out IntPtr result);

	[DllImport("ole32.dll", CharSet = CharSet.Auto)]
	internal static extern void CoCreateGuid(ref GUIDSTRUCT guid);

	[DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
	internal static extern bool IsAppThemed();

	[DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
	internal static extern bool IsThemeActive();

	[DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
	internal static extern int SetWindowTheme(IntPtr hWnd, string subAppName, string subIdList);

	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
	internal static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hDC, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	internal static extern short QueryPerformanceCounter(ref long var);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	internal static extern short QueryPerformanceFrequency(ref long var);
}
