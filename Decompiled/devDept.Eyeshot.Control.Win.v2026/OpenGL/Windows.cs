using System;
using System.Runtime.InteropServices;

namespace OpenGL;

public class Windows
{
	[DllImport("User32")]
	public static extern IntPtr GetDC(IntPtr hwnd);

	[DllImport("User32")]
	public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hDC);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWindow(IntPtr hWnd);

	[DllImport("GDI32")]
	public static extern int ChoosePixelFormat(IntPtr dc, [In][MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor pfd);

	[DllImport("GDI32")]
	public static extern int DescribePixelFormat(IntPtr dc, int iPixelFormat, short nBytes, [Out][MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor pfd);

	[DllImport("GDI32")]
	public static extern bool SetPixelFormat(IntPtr dc, int format, [In][MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor pfd);

	[DllImport("GDI32")]
	public static extern void SwapBuffers(IntPtr dc);

	[DllImport("Kernel32")]
	public static extern IntPtr GetProcAddress(IntPtr handle, string funcname);

	[DllImport("Kernel32")]
	public static extern IntPtr LoadLibrary(string funcname);

	[DllImport("Kernel32")]
	public static extern bool FreeLibrary(IntPtr handle);

	[DllImport("GDI32")]
	public static extern IntPtr SelectObject(IntPtr dc, IntPtr obj);

	[DllImport("GDI32")]
	public static extern bool DeleteObject(IntPtr objectHandle);

	[DllImport("GDI32")]
	public static extern IntPtr GetStockObject(IntPtr obj);

	[DllImport("GDI32")]
	public static extern IntPtr CreateFont(int height, int width, int esc, int orientation, int fnwidth, int italic, int underline, int strikeout, int charset, int precision, int clipprecision, int quality, int pitch, string face);

	[DllImport("GDI32")]
	public static extern bool GetTextExtentPoint32(IntPtr dc, string text, int length, out CharSize result);

	[DllImport("Kernel32")]
	public static extern int GetLastError();
}
