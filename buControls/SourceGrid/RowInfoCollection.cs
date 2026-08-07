// Decompiled with JetBrains decompiler
// Type: SourceGrid.RowInfoCollection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace SourceGrid;

public abstract class RowInfoCollection : RowsBase, IEnumerable, IEnumerable<RowInfo>
{
  private List<RowInfo> list_0 = new List<RowInfo>();

  public RowInfoCollection(GridVirtual grid)
    : base(grid)
  {
    this.m_HiddenRowsCoordinator = (IHiddenRowCoordinator) new RowInfoCollectoinHiddenRowCoordinator(this);
  }

  public bool IsValidRange(int p_StartIndex, int p_Count)
  {
    return (p_StartIndex >= this.Count || p_StartIndex < 0 || p_Count <= 0 ? 0 : (p_StartIndex + p_Count <= this.Count ? 1 : 0)) != 0;
  }

  public bool IsValidRangeForInsert(int p_StartIndex, int p_Count)
  {
    return (p_StartIndex > this.Count || p_StartIndex < 0 ? 0 : (p_Count > 0 ? 1 : 0)) != 0;
  }

  protected void InsertRange(int p_StartIndex, RowInfo[] rows)
  {
    if (!this.IsValidRangeForInsert(p_StartIndex, rows.Length))
      throw new SourceGridException("Invalid index");
    for (int index = 0; index < rows.Length; ++index)
      this.list_0.Insert(p_StartIndex + index, rows[index]);
    this.PerformLayout();
    this.OnRowsAdded(new IndexRangeEventArgs(p_StartIndex, rows.Length));
  }

  public void Remove(int p_Index) => this.RemoveRange(p_Index, 1);

  public virtual void RemoveRange(int p_StartIndex, int p_Count)
  {
    IndexRangeEventArgs e = this.IsValidRange(p_StartIndex, p_Count) ? new IndexRangeEventArgs(p_StartIndex, p_Count) : throw new SourceGridException("Invalid index");
    this.OnRowsRemoving(e);
    this.list_0.RemoveRange(p_StartIndex, p_Count);
    this.OnRowsRemoved(e);
    this.PerformLayout();
  }

  public void Move(int p_CurrentRowPosition, int p_NewRowPosition)
  {
    if (p_CurrentRowPosition == p_NewRowPosition)
      return;
    if (p_CurrentRowPosition < p_NewRowPosition)
    {
      for (int p_RowIndex1 = p_CurrentRowPosition; p_RowIndex1 < p_NewRowPosition; ++p_RowIndex1)
        this.Swap(p_RowIndex1, p_RowIndex1 + 1);
    }
    else
    {
      for (int p_RowIndex1 = p_CurrentRowPosition; p_RowIndex1 > p_NewRowPosition; --p_RowIndex1)
        this.Swap(p_RowIndex1, p_RowIndex1 - 1);
    }
  }

  public virtual void Swap(int p_RowIndex1, int p_RowIndex2)
  {
    if (p_RowIndex1 == p_RowIndex2)
      return;
    RowInfo rowInfo1 = this[p_RowIndex1];
    RowInfo rowInfo2 = this[p_RowIndex2];
    this.list_0[p_RowIndex1] = rowInfo2;
    this.list_0[p_RowIndex2] = rowInfo1;
    this.PerformLayout();
  }

  public event IndexRangeEventHandler RowsAdded;

  protected virtual void OnRowsAdded(IndexRangeEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.indexRangeEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.indexRangeEventHandler_0((object) this, e);
    }
    this.RowsChanged();
  }

  public event IndexRangeEventHandler RowsRemoved;

  protected virtual void OnRowsRemoved(IndexRangeEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.indexRangeEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.indexRangeEventHandler_1((object) this, e);
    }
    this.RowsChanged();
  }

  public event IndexRangeEventHandler RowsRemoving;

  protected virtual void OnRowsRemoving(IndexRangeEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.indexRangeEventHandler_2 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.indexRangeEventHandler_2((object) this, e);
  }

  public RowInfo this[int p]
  {
    get => p >= 0 ? (p < this.list_0.Count ? this.list_0[p] : (RowInfo) null) : (RowInfo) null;
  }

  protected override void OnLayout() => base.OnLayout();

  public event RowInfoEventHandler RowHeightChanged;

  public void OnRowHeightChanged(RowInfoEventArgs e)
  {
    this.PerformLayout();
    // ISSUE: reference to a compiler-generated field
    if (this.rowInfoEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.rowInfoEventHandler_0((object) this, e);
  }

  public int IndexOf(RowInfo p_Info) => this.list_0.IndexOf(p_Info);

  public void AutoSizeView()
  {
    ColumnsBase columns = this.Grid.Columns;
    Rectangle displayRectangle = this.Grid.DisplayRectangle;
    int x = displayRectangle.X;
    displayRectangle = this.Grid.DisplayRectangle;
    int width = displayRectangle.Width;
    List<int> intList = columns.ColumnsInsideRegion(x, width, true, false);
    if (intList.Count <= 0)
      return;
    this.AutoSize(false, intList[0], intList[intList.Count - 1]);
  }

  public void Clear()
  {
    if (this.Count == 0)
      return;
    this.Grid.LinkedControls.Clear();
    this.RemoveRange(0, this.Count);
  }

  public override int GetHeight(int row) => this[row].Height;

  public override void SetHeight(int row, int height) => this[row].Height = height;

  public override AutoSizeMode GetAutoSizeMode(int row) => this[row].AutoSizeMode;

  public override int Count => this.list_0.Count;

  public IEnumerator<RowInfo> GetEnumerator() => (IEnumerator<RowInfo>) this.list_0.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.list_0.GetEnumerator();
}
