// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.RowHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing.VisualElements;
using System;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public class RowHeader : Header
{
  public static readonly RowHeader Default = new RowHeader();

  public RowHeader() => this.Background = (IRowHeader) new RowHeaderThemed();

  public RowHeader(RowHeader p_Source)
    : base((Header) p_Source)
  {
  }

  public override object Clone() => (object) new RowHeader(this);

  public IRowHeader Background
  {
    get => (IRowHeader) base.Background;
    set => this.Background = (IHeader) value;
  }

  protected override void PrepareView(CellContext context) => base.PrepareView(context);
}
