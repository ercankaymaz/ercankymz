// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.RichTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing.VisualElements;
using ns7;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public class RichTextBox : Cell
{
  public static readonly RichTextBox Default = new RichTextBox();
  private IRichText m_ElementRichText = (IRichText) null;
  private RotateFlipType m_RotateFlipType = RotateFlipType.RotateNoneFlipNone;

  public RichTextBox() => this.ElementRichText = (IRichText) new RichTextGDI();

  public RichTextBox(RichTextBox p_Source)
    : base((Cell) p_Source)
  {
    this.ElementRichText = (IRichText) p_Source.ElementRichText.Clone();
  }

  protected override void PrepareView(CellContext context)
  {
    this.PrepareVisualElementRichTextBox(context);
  }

  protected override IEnumerable<IVisualElement> GetElements()
  {
    if (this.ElementRichText != null)
      yield return (IVisualElement) this.ElementRichText;
    IEnumerator<IVisualElement> enumerator = this.method_0().GetEnumerator();
    while (enumerator.MoveNext())
    {
      IVisualElement element = enumerator.Current;
      yield return element;
      element = (IVisualElement) null;
    }
    Class39.smethod_415(this);
    enumerator = (IEnumerator<IVisualElement>) null;
  }

  private IEnumerable<IVisualElement> method_0() => base.GetElements();

  protected virtual void PrepareVisualElementRichTextBox(CellContext context)
  {
    this.ElementRichText.Value = context.Cell.Model.ValueModel.GetValue(context) as DevAge.Windows.Forms.RichText;
    this.ElementRichText.ForeColor = this.ForeColor;
    this.ElementRichText.TextAlignment = this.TextAlignment;
    this.ElementRichText.Font = this.GetDrawingFont(context.Grid);
    this.ElementRichText.RotateFlipType = this.RotateFlipType;
  }

  public IRichText ElementRichText
  {
    get => this.m_ElementRichText;
    set => this.m_ElementRichText = value;
  }

  public RotateFlipType RotateFlipType
  {
    get => this.m_RotateFlipType;
    set => this.m_RotateFlipType = value;
  }

  public override object Clone() => (object) new RichTextBox(this);
}
