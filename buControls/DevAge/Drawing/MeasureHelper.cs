// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.MeasureHelper
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Drawing;

public class MeasureHelper : IDisposable
{
  private Bitmap bitmap_0;
  private Graphics graphics;
  private bool bool_0;

  public MeasureHelper(Control control)
  {
    this.graphics = control.CreateGraphics();
    this.bool_0 = true;
  }

  public MeasureHelper(Graphics graphics)
  {
    this.graphics = graphics;
    this.bool_0 = false;
  }

  public MeasureHelper(GraphicsCache graphics)
  {
    this.graphics = graphics.Graphics;
    this.bool_0 = false;
  }

  public void Dispose()
  {
    if ((this.graphics == null ? 0 : (this.bool_0 ? 1 : 0)) != 0)
    {
      this.graphics.Dispose();
      this.graphics = (Graphics) null;
    }
    if (this.bitmap_0 == null)
      return;
    this.bitmap_0.Dispose();
    this.bitmap_0 = (Bitmap) null;
  }

  public Graphics Graphics => this.graphics;
}
