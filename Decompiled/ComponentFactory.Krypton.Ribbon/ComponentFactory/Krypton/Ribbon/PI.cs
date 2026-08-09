using System;
using System.Runtime.InteropServices;

namespace ComponentFactory.Krypton.Ribbon;

internal class PI
{
	internal struct RECT
	{
		public int left;

		public int top;

		public int right;

		public int bottom;
	}

	internal struct POINT
	{
		public int x;

		public int y;
	}

	internal struct TITLEBARINFOEX
	{
		public uint cbSize;

		public RECT rcTitleBar;

		public uint dwTitleBar;

		public uint dwReserved;

		public uint dwMinButton;

		public uint dwMaxButton;

		public uint dwHelpButton;

		public uint dwCloseButton;

		public RECT rcReserved1;

		public RECT rcReserved2;

		public RECT rcMinButton;

		public RECT rcMaxButton;

		public RECT rcHelpButton;

		public RECT rcCloseButton;
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

	internal const uint WS_POPUP = 2147483648u;

	internal const uint WS_SYSMENU = 524288u;

	internal const int WM_NCLBUTTONDOWN = 161;

	internal const int WM_NCRBUTTONDOWN = 164;

	internal const int WM_NCMBUTTONDOWN = 167;

	internal const int WM_NCHITTEST = 132;

	internal const int WM_KEYDOWN = 256;

	internal const int WM_KEYUP = 257;

	internal const int WM_CHAR = 258;

	internal const int WM_SYSKEYDOWN = 260;

	internal const int WM_SYSKEYUP = 261;

	internal const int WM_LBUTTONDOWN = 513;

	internal const int WM_RBUTTONDOWN = 516;

	internal const int WM_MBUTTONDOWN = 519;

	internal const int WM_MOUSEWHEEL = 522;

	internal const int WM_GETTITLEBARINFOEX = 831;

	internal const int WS_CLIPCHILDREN = 33554432;

	internal const int WS_EX_TOPMOST = 8;

	internal const int WS_EX_TOOLWINDOW = 128;

	internal const int WS_EX_LAYERED = 524288;

	internal const int WS_EX_TRANSPARENT = 32;

	internal const int SW_HIDE = 0;

	internal const int SW_SHOWNOACTIVATE = 4;

	internal const int MESSAGE_BEEP_ERROR = 16;

	internal const int HTTRANSPARENT = -1;

	internal const int HTCAPTION = 2;

	internal const int DTT_COMPOSITED = 8192;

	internal const int DTT_GLOWSIZE = 2048;

	internal const int DTT_TEXTCOLOR = 1;

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

	[DllImport("dwmapi.dll, CharSet = CharSet.Auto")]
	internal static extern int DwmDefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, out IntPtr result);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool SetMenu(HandleRef hWnd, HandleRef hMenu);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint nLong);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetFocus();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr SetFocus(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool HideCaret(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool ShowCaret(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetActiveWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern int ShowWindow(IntPtr hWnd, short cmdShow);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool MessageBeep(int type);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern uint SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TITLEBARINFOEX lParam);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern int ExcludeClipRect(IntPtr hDC, int x1, int y1, int x2, int y2);

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

	[DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
	internal static extern bool IsAppThemed();

	[DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
	internal static extern bool IsThemeActive();

	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
	internal static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hDC, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);
}
