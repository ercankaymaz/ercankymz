// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.Unselectable
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class Unselectable : ControllerBase
{
  public static readonly Unselectable Default = new Unselectable();

  public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
  {
    base.OnFocusEntering(sender, e);
    e.Cancel = !this.CanReceiveFocus(sender, (EventArgs) e);
  }

  public override bool CanReceiveFocus(CellContext sender, EventArgs e) => false;
}
