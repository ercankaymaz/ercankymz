// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Link
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

#nullable disable
namespace SourceGrid.Cells;

public class Link : Cell
{
  public Link()
    : this((object) null)
  {
  }

  public Link(object p_Value)
    : base(p_Value)
  {
    this.View = (IView) SourceGrid.Cells.Views.Link.Default;
    this.AddController((IController) MouseCursor.Hand);
  }
}
