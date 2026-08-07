// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.ScreenExtensions
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5;

public static class ScreenExtensions
{
  public static void GetDpi(this Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
  {
    Point point_0;
    ref Point local = ref point_0;
    Rectangle bounds = screen.Bounds;
    int x = bounds.Left + 1;
    bounds = screen.Bounds;
    int y = bounds.Top + 1;
    local = new Point(x, y);
    Class5.GetDpiForMonitor(Class5.MonitorFromPoint(point_0, 2U), dpiType, out dpiX, out dpiY);
  }
}
