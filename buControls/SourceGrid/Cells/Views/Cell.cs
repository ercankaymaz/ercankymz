// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.Cell
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public class Cell : ViewBase
{
  public static readonly Cell Default = new Cell();
  private IText mElementText = (IText) new TextGDI();
  private DevAge.Drawing.VisualElements.IImage mElementImage = (DevAge.Drawing.VisualElements.IImage) new DevAge.Drawing.VisualElements.Image();

  public Cell() => this.ElementsDrawMode = ElementsDrawMode.Align;

  public Cell(Cell p_Source)
    : base((ViewBase) p_Source)
  {
    this.ElementImage = (DevAge.Drawing.VisualElements.IImage) p_Source.ElementImage.Clone();
    this.ElementText = (IText) p_Source.ElementText.Clone();
  }

  public override object Clone() => (object) new Cell(this);

  protected override IEnumerable<IVisualElement> GetElements()
  {
    if (this.ElementImage != null)
      yield return (IVisualElement) this.ElementImage;
    if (this.ElementText != null)
      yield return (IVisualElement) this.ElementText;
  }

  protected override void PrepareView(CellContext context)
  {
    base.PrepareView(context);
    this.PrepareVisualElementText(context);
    this.PrepareVisualElementImage(context);
  }

  public IText ElementText
  {
    get => this.mElementText;
    set => this.mElementText = value;
  }

  protected virtual void PrepareVisualElementText(CellContext context)
  {
    if (this.ElementText is DevAge.Drawing.VisualElements.TextRenderer)
    {
      DevAge.Drawing.VisualElements.TextRenderer elementText = (DevAge.Drawing.VisualElements.TextRenderer) this.ElementText;
      elementText.TextFormatFlags = TextFormatFlags.NoPrefix;
      if (this.WordWrap)
        elementText.TextFormatFlags |= TextFormatFlags.WordBreak;
      if (this.TrimmingMode == TrimmingMode.Char)
        elementText.TextFormatFlags |= TextFormatFlags.EndEllipsis;
      else if (this.TrimmingMode == TrimmingMode.Word)
        elementText.TextFormatFlags |= TextFormatFlags.WordEllipsis;
      elementText.TextFormatFlags |= DevAge.Windows.Forms.Utilities.ContentAligmentToTextFormatFlags(this.TextAlignment);
    }
    else if (this.ElementText is TextGDI)
    {
      TextGDI elementText = (TextGDI) this.ElementText;
      elementText.StringFormat.FormatFlags = !this.WordWrap ? StringFormatFlags.NoWrap : (StringFormatFlags) 0;
      elementText.StringFormat.Trimming = this.TrimmingMode != TrimmingMode.Char ? (this.TrimmingMode != TrimmingMode.Word ? StringTrimming.None : StringTrimming.EllipsisWord) : StringTrimming.EllipsisCharacter;
      elementText.Alignment = this.TextAlignment;
    }
    this.ElementText.Font = this.GetDrawingFont(context.Grid);
    this.ElementText.ForeColor = this.ForeColor;
    this.ElementText.Value = context.DisplayText;
  }

  public DevAge.Drawing.VisualElements.IImage ElementImage
  {
    get => this.mElementImage;
    set => this.mElementImage = value;
  }

  protected virtual void PrepareVisualElementImage(CellContext context)
  {
    this.ElementImage.AnchorArea = new AnchorArea(this.ImageAlignment, this.ImageStretch);
    System.Drawing.Image image = (System.Drawing.Image) null;
    SourceGrid.Cells.Models.IImage model = (SourceGrid.Cells.Models.IImage) context.Cell.Model.FindModel(typeof (SourceGrid.Cells.Models.IImage));
    if (model != null)
      image = model.GetImage(context);
    this.ElementImage.Value = image;
  }
}
