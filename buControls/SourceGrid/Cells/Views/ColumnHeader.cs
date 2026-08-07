// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.ColumnHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns7;
using SourceGrid.Cells.Models;
using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public class ColumnHeader : Header
{
  public static readonly ColumnHeader Default = new ColumnHeader();
  private ISortIndicator mElementSort = (ISortIndicator) new SortIndicator();

  public ColumnHeader() => this.Background = (IColumnHeader) new ColumnHeaderThemed();

  public ColumnHeader(ColumnHeader p_Source)
    : base((Header) p_Source)
  {
  }

  public override object Clone() => (object) new ColumnHeader(this);

  public IColumnHeader Background
  {
    get => (IColumnHeader) base.Background;
    set => this.Background = (IHeader) value;
  }

  protected override void PrepareView(CellContext context)
  {
    base.PrepareView(context);
    this.PrepareVisualElementSortIndicator(context);
  }

  protected override IEnumerable<IVisualElement> GetElements()
  {
    if (this.ElementSort != null)
      yield return (IVisualElement) this.ElementSort;
    IEnumerator<IVisualElement> enumerator = this.method_0().GetEnumerator();
    while (enumerator.MoveNext())
    {
      IVisualElement element = enumerator.Current;
      yield return element;
      element = (IVisualElement) null;
    }
    Class39.smethod_157(this);
    enumerator = (IEnumerator<IVisualElement>) null;
  }

  private IEnumerable<IVisualElement> method_0() => base.GetElements();

  public ISortIndicator ElementSort
  {
    get => this.mElementSort;
    set => this.mElementSort = value;
  }

  protected virtual void PrepareVisualElementSortIndicator(CellContext context)
  {
    ISortableHeader model = (ISortableHeader) context.Cell.Model.FindModel(typeof (ISortableHeader));
    if (model != null)
      this.ElementSort.SortStyle = model.GetSortStatus(context).Style;
    else
      this.ElementSort.SortStyle = HeaderSortStyle.None;
  }
}
