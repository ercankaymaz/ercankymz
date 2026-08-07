// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.ComboBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns7;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Cells.Views;

public class ComboBox : Cell
{
  public static readonly ComboBox Default = new ComboBox();
  private IDropDownButton idropDownButton_0 = (IDropDownButton) new DropDownButtonThemed();

  public ComboBox()
  {
    this.ElementDropDown.AnchorArea = new AnchorArea(float.NaN, 0.0f, 0.0f, 0.0f, false, false);
  }

  public ComboBox(ComboBox p_Source)
    : base((Cell) p_Source)
  {
    this.ElementDropDown = (IDropDownButton) p_Source.ElementDropDown.Clone();
  }

  protected override void PrepareView(CellContext context)
  {
    base.PrepareView(context);
    this.PrepareVisualElementDropDown(context);
  }

  protected override IEnumerable<IVisualElement> GetElements()
  {
    if (this.ElementDropDown != null)
      yield return (IVisualElement) this.ElementDropDown;
    IEnumerator<IVisualElement> enumerator = this.method_0().GetEnumerator();
    while (enumerator.MoveNext())
    {
      IVisualElement element = enumerator.Current;
      yield return element;
      element = (IVisualElement) null;
    }
    Class39.smethod_139(this);
    enumerator = (IEnumerator<IVisualElement>) null;
  }

  private IEnumerable<IVisualElement> method_0() => base.GetElements();

  public IDropDownButton ElementDropDown
  {
    get => this.idropDownButton_0;
    set => this.idropDownButton_0 = value;
  }

  protected virtual void PrepareVisualElementDropDown(CellContext context)
  {
    if (context.CellRange.Contains(context.Grid.MouseCellPosition))
      this.ElementDropDown.Style = ButtonStyle.Hot;
    else
      this.ElementDropDown.Style = ButtonStyle.Normal;
  }

  public override object Clone() => (object) new ComboBox(this);
}
