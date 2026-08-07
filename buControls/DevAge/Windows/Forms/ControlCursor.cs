// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.ControlCursor
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public class ControlCursor
{
  private Cursor pCursor;
  private Cursor cursor_0;
  private Control control_0;

  public ControlCursor(Cursor pCursor) => this.pCursor = pCursor;

  public void ApplyCursor(Control control)
  {
    if (this.control_0 != null)
      return;
    this.control_0 = control;
    this.cursor_0 = this.control_0.Cursor;
    this.control_0.Cursor = this.pCursor;
  }

  public void ResetCursor()
  {
    if ((this.control_0 == null ? 0 : (this.control_0.Cursor == this.pCursor ? 1 : 0)) == 0)
      return;
    this.control_0.Cursor = this.cursor_0;
    this.control_0 = (Control) null;
  }
}
