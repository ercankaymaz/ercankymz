// Decompiled with JetBrains decompiler
// Type: SourceGrid.ColumnInfo
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.ComponentModel;

#nullable disable
namespace SourceGrid;

public class ColumnInfo
{
  private int int_0 = -1;
  private int int_1 = 0;
  private int int_2;
  private GridVirtual p_Grid;
  private object object_0;
  private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;
  private bool bool_0 = true;

  public ColumnInfo(GridVirtual p_Grid)
  {
    this.p_Grid = p_Grid;
    this.int_2 = this.Grid.DefaultWidth;
  }

  public int MaximalWidth
  {
    get => this.int_0;
    set
    {
      if (value < this.int_1)
        value = this.int_1;
      if ((value == this.int_0 ? 0 : (value >= -1 ? 1 : 0)) == 0)
        return;
      this.int_0 = value;
      if ((this.Width <= this.int_0 ? 0 : (this.int_0 > -1 ? 1 : 0)) == 0)
        return;
      this.Width = this.int_0;
    }
  }

  public int MinimalWidth
  {
    get => this.int_1;
    set
    {
      if (value < 0)
        value = 0;
      if ((value <= this.int_0 ? 0 : (this.int_0 > -1 ? 1 : 0)) != 0)
        value = this.int_0;
      if (value == this.int_1)
        return;
      this.int_1 = value;
      if ((this.Width >= this.int_1 ? 0 : (this.Visible ? 1 : 0)) == 0)
        return;
      this.Width = this.int_1;
    }
  }

  public int Width
  {
    get => this.int_2;
    set
    {
      if (value < this.int_1)
        value = this.int_1;
      if ((value <= this.int_0 ? 0 : (this.int_0 > -1 ? 1 : 0)) != 0)
        value = this.int_0;
      if (this.int_2 == value)
        return;
      this.int_2 = value;
      if (!this.Visible)
        return;
      ((ColumnInfoCollection) this.Grid.Columns).OnColumnWidthChanged(new ColumnInfoEventArgs(this));
    }
  }

  public int Index => ((ColumnInfoCollection) this.Grid.Columns).IndexOf(this);

  [Browsable(false)]
  public GridVirtual Grid => this.p_Grid;

  public Range Range
  {
    get
    {
      if (this.p_Grid == null)
        throw new SourceGridException("Invalid Grid object");
      return new Range(0, this.Index, this.Grid.Rows.Count - 1, this.Index);
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
    get => this.bool_0;
    set
    {
      if (value == this.bool_0)
        return;
      this.bool_0 = value;
      ((ColumnInfoCollection) this.Grid.Columns).OnColumnWidthChanged(new ColumnInfoEventArgs(this));
    }
  }
}
