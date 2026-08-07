// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Virtual.Link
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

#nullable disable
namespace SourceGrid.Cells.Virtual;

public abstract class Link : CellVirtual
{
  public Link()
  {
    this.View = (IView) SourceGrid.Cells.Views.Link.Default;
    this.AddController((IController) MouseCursor.Hand);
  }
}
