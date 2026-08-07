// Decompiled with JetBrains decompiler
// Type: SourceGrid.ColumnInfoCollection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace SourceGrid;

public class ColumnInfoCollection(GridVirtual grid) : ColumnsBase(grid), IEnumerable
{
  private List<ColumnInfo> list_0 = new List<ColumnInfo>();

  public bool IsValidRange(int p_StartIndex, int p_Count)
  {
    return (p_StartIndex >= this.Count || p_StartIndex < 0 || p_Count <= 0 ? 0 : (p_StartIndex + p_Count <= this.Count ? 1 : 0)) != 0;
  }

  public bool IsValidRangeForInsert(int p_StartIndex, int p_Count)
  {
    return (p_StartIndex > this.Count || p_StartIndex < 0 ? 0 : (p_Count > 0 ? 1 : 0)) != 0;
  }

  public void Add(ColumnInfo column) => this.Insert(this.Count, column);

  public void Insert(int index, ColumnInfo dataGridColumn)
  {
    this.InsertRange(index, dataGridColumn);
  }

  public void InsertRange(int p_StartIndex, params ColumnInfo[] columns)
  {
    if (!this.IsValidRangeForInsert(p_StartIndex, columns.Length))
      throw new SourceGridException("Invalid index");
    for (int index = 0; index < columns.Length; ++index)
      this.list_0.Insert(p_StartIndex + index, columns[index]);
    this.PerformLayout();
    this.OnColumnsAdded(new IndexRangeEventArgs(p_StartIndex, columns.Length));
  }

  public void Remove(int p_Index) => this.RemoveRange(p_Index, 1);

  public virtual void RemoveRange(int p_StartIndex, int p_Count)
  {
    IndexRangeEventArgs e = this.IsValidRange(p_StartIndex, p_Count) ? new IndexRangeEventArgs(p_StartIndex, p_Count) : throw new SourceGridException("Invalid index");
    this.OnColumnsRemoving(e);
    this.list_0.RemoveRange(p_StartIndex, p_Count);
    this.OnColumnsRemoved(e);
    this.PerformLayout();
  }

  public void Move(int p_CurrentColumnPosition, int p_NewColumnPosition)
  {
    if (p_CurrentColumnPosition == p_NewColumnPosition)
      return;
    if (p_CurrentColumnPosition < p_NewColumnPosition)
    {
      for (int p_ColumnIndex1 = p_CurrentColumnPosition; p_ColumnIndex1 < p_NewColumnPosition; ++p_ColumnIndex1)
        this.Swap(p_ColumnIndex1, p_ColumnIndex1 + 1);
    }
    else
    {
      for (int p_ColumnIndex1 = p_CurrentColumnPosition; p_ColumnIndex1 > p_NewColumnPosition; --p_ColumnIndex1)
        this.Swap(p_ColumnIndex1, p_ColumnIndex1 - 1);
    }
  }

  public void Swap(int p_ColumnIndex1, int p_ColumnIndex2)
  {
    if (p_ColumnIndex1 == p_ColumnIndex2)
      return;
    ColumnInfo columnInfo1 = this[p_ColumnIndex1];
    ColumnInfo columnInfo2 = this[p_ColumnIndex2];
    this.list_0[p_ColumnIndex1] = columnInfo2;
    this.list_0[p_ColumnIndex2] = columnInfo1;
    this.PerformLayout();
  }

  public event IndexRangeEventHandler ColumnsAdded;

  protected virtual void OnColumnsAdded(IndexRangeEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.indexRangeEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.indexRangeEventHandler_0((object) this, e);
    }
    this.ColumnsChanged();
  }

  public event IndexRangeEventHandler ColumnsRemoved;

  protected virtual void OnColumnsRemoved(IndexRangeEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.indexRangeEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.indexRangeEventHandler_1((object) this, e);
    }
    this.ColumnsChanged();
  }

  public event IndexRangeEventHandler ColumnsRemoving;

  protected virtual void OnColumnsRemoving(IndexRangeEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.indexRangeEventHandler_2 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.indexRangeEventHandler_2((object) this, e);
  }

  public ColumnInfo this[int p]
  {
    get
    {
      return p >= 0 ? (p < this.list_0.Count ? this.list_0[p] : (ColumnInfo) null) : (ColumnInfo) null;
    }
  }

  protected override void OnLayout() => base.OnLayout();

  public event ColumnInfoEventHandler ColumnWidthChanged;

  public void OnColumnWidthChanged(ColumnInfoEventArgs e)
  {
    this.PerformLayout();
    // ISSUE: reference to a compiler-generated field
    if (this.columnInfoEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.columnInfoEventHandler_0((object) this, e);
  }

  public int IndexOf(ColumnInfo p_Info) => this.list_0.IndexOf(p_Info);

  public void AutoSizeView()
  {
    RowsBase rows = this.Grid.Rows;
    Rectangle displayRectangle = this.Grid.DisplayRectangle;
    int y = displayRectangle.Y;
    displayRectangle = this.Grid.DisplayRectangle;
    int height = displayRectangle.Height;
    List<int> intList = rows.RowsInsideRegion(y, height, true, false);
    if (intList.Count <= 0)
      return;
    this.AutoSize(false, intList[0], intList[intList.Count - 1]);
  }

  public void Clear()
  {
    if (this.Count <= 0)
      return;
    this.RemoveRange(0, this.Count);
  }

  public override int GetWidth(int column) => this.IsColumnVisible(column) ? this[column].Width : 0;

  public override void SetWidth(int column, int width) => this[column].Width = width;

  public override AutoSizeMode GetAutoSizeMode(int column) => this[column].AutoSizeMode;

  public override bool IsColumnVisible(int column) => this[column].Visible;

  public override void HideColumn(int column) => this[column].Visible = false;

  public override void ShowColumn(int column) => this[column].Visible = true;

  public override int Count => this.list_0.Count;

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.list_0.GetEnumerator();
}
