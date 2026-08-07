// Decompiled with JetBrains decompiler
// Type: SourceGrid.RowInfo
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.ComponentModel;

#nullable disable
namespace SourceGrid;

public class RowInfo
{
  private int int_0;
  private GridVirtual p_Grid;
  private object object_0;
  private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;

  public RowInfo(GridVirtual p_Grid)
  {
    this.p_Grid = p_Grid;
    this.int_0 = this.Grid.DefaultHeight;
  }

  public int Height
  {
    get => this.int_0;
    set
    {
      if (value < 0)
        value = 0;
      if (this.int_0 == value)
        return;
      this.int_0 = value;
      ((RowInfoCollection) this.p_Grid.Rows).OnRowHeightChanged(new RowInfoEventArgs(this));
    }
  }

  public int Index => ((RowInfoCollection) this.Grid.Rows).IndexOf(this);

  [Browsable(false)]
  public GridVirtual Grid => this.p_Grid;

  public Range Range
  {
    get
    {
      if (this.p_Grid == null)
        throw new SourceGridException("Invalid Grid object");
      return new Range(this.Index, 0, this.Index, this.Grid.Columns.Count - 1);
    }
  }

  [Browsable(false)]
  public object Tag
  {
    get => this.object_0;
    set => this.object_0 = value;
  }

  public AutoSizeMode AutoSizeMode
  {
    get => this.autoSizeMode_0;
    set => this.autoSizeMode_0 = value;
  }

  public bool Visible
  {
    get => this.Grid.Rows.IsRowVisible(this.Index);
    set => this.Grid.Rows.ShowRow(this.Index, value);
  }
}
