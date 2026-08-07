// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.NativeMethods
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace PdfSharp.Internal;

internal static class NativeMethods
{
  public const int GDI_ERROR = -1;
  public const int HORZSIZE = 4;
  public const int VERTSIZE = 6;
  public const int HORZRES = 8;
  public const int VERTRES = 10;
  public const int LOGPIXELSX = 88;
  public const int LOGPIXELSY = 90;

  [DllImport("user32.dll")]
  public static extern IntPtr GetDC(IntPtr hwnd);

  [DllImport("user32.dll")]
  public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

  [DllImport("gdi32.dll", SetLastError = true)]
  public static extern int GetFontData(
    IntPtr hdc,
    uint dwTable,
    uint dwOffset,
    byte[] lpvBuffer,
    int cbData);

  [DllImport("gdi32.dll", SetLastError = true)]
  public static extern IntPtr CreateDC(string driver, string device, string port, IntPtr data);

  [DllImport("gdi32.dll", SetLastError = true)]
  public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

  [DllImport("gdi32.dll", EntryPoint = "CreateFontIndirectW")]
  public static extern IntPtr CreateFontIndirect(NativeMethods.LOGFONT lpLogFont);

  [DllImport("gdi32.dll")]
  public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

  [DllImport("gdi32.dll")]
  public static extern bool DeleteObject(IntPtr hgdiobj);

  [DllImport("gdi32.dll")]
  public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public class LOGFONT
  {
    public int lfHeight;
    public int lfWidth;
    public int lfEscapement;
    public int lfOrientation;
    public int lfWeight;
    public byte lfItalic;
    public byte lfUnderline;
    public byte lfStrikeOut;
    public byte lfCharSet;
    public byte lfOutPrecision;
    public byte lfClipPrecision;
    public byte lfQuality;
    public byte lfPitchAndFamily;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32 /*0x20*/)]
    public string lfFaceName;

    private LOGFONT(int dummy)
    {
      this.lfHeight = 0;
      this.lfWidth = 0;
      this.lfEscapement = 0;
      this.lfOrientation = 0;
      this.lfWeight = 0;
      this.lfItalic = (byte) 0;
      this.lfUnderline = (byte) 0;
      this.lfStrikeOut = (byte) 0;
      this.lfCharSet = (byte) 0;
      this.lfOutPrecision = (byte) 0;
      this.lfClipPrecision = (byte) 0;
      this.lfQuality = (byte) 0;
      this.lfPitchAndFamily = (byte) 0;
      this.lfFaceName = "";
    }

    public override string ToString()
    {
      return $"lfHeight={(object) this.lfHeight}, lfWidth={(object) this.lfWidth}, lfEscapement={(object) this.lfEscapement}, lfOrientation={(object) this.lfOrientation}, lfWeight={(object) this.lfWeight}, lfItalic={(object) this.lfItalic}, lfUnderline={(object) this.lfUnderline}, lfStrikeOut={(object) this.lfStrikeOut}, lfCharSet={(object) this.lfCharSet}, lfOutPrecision={(object) this.lfOutPrecision}, lfClipPrecision={(object) this.lfClipPrecision}, lfQuality={(object) this.lfQuality}, lfPitchAndFamily={(object) this.lfPitchAndFamily}, lfFaceName={this.lfFaceName}";
    }

    public LOGFONT()
    {
    }
  }
}
