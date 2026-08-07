// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.RichTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Windows.Forms;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells;

public class RichTextBox : Cell
{
  public RichTextBox()
    : this((RichText) null)
  {
  }

  public RichTextBox(RichText value)
    : base((object) value)
  {
    this.View = (IView) new SourceGrid.Cells.Views.RichTextBox();
    this.Model.AddModel((IModel) new SourceGrid.Cells.Models.RichTextBox());
    this.AddController((IController) SourceGrid.Cells.Controllers.RichTextBox.Default);
    this.Editor = (EditorBase) new SourceGrid.Cells.Editors.RichTextBox();
  }

  [SpecialName]
  private SourceGrid.Cells.Models.RichTextBox method_2()
  {
    return (SourceGrid.Cells.Models.RichTextBox) this.Model.FindModel(typeof (SourceGrid.Cells.Models.RichTextBox));
  }

  public Font SelectionFont
  {
    get => this.method_2().GetSelectionFont(this.GetContext());
    set => this.method_2().SetSelectionFont(this.GetContext(), value);
  }

  public Color SelectionColor
  {
    get => this.method_2().GetSelectionColor(this.GetContext());
    set => this.method_2().SetSelectionColor(this.GetContext(), value);
  }

  public int SelectionCharOffset
  {
    get => this.method_2().GetSelectionCharOffset(this.GetContext());
    set => this.method_2().SetSelectionCharOffset(this.GetContext(), value);
  }

  public HorizontalAlignment SelectionAlignment
  {
    get => this.method_2().GetSelectionAlignment(this.GetContext());
    set => this.method_2().SetSelectionAlignment(this.GetContext(), value);
  }

  public void SelectionBold()
  {
    this.SelectionFont = new Font(this.SelectionFont, this.SelectionFont.Style ^ FontStyle.Bold);
  }

  public void SelectionItalic()
  {
    this.SelectionFont = new Font(this.SelectionFont, this.SelectionFont.Style ^ FontStyle.Italic);
  }

  public void SelectionUnderline()
  {
    this.SelectionFont = new Font(this.SelectionFont, this.SelectionFont.Style ^ FontStyle.Underline);
  }

  public void InsertString(string s) => this.method_2().InsertString(this.GetContext(), s);

  public void SelectionSuperScript()
  {
    this.method_2().SetSelectionEffect(this.GetContext(), EffectType.Superscript);
  }

  public void SelectionNormalScript()
  {
    this.method_2().SetSelectionEffect(this.GetContext(), EffectType.Normal);
  }

  public void SelectionSubScript()
  {
    this.method_2().SetSelectionEffect(this.GetContext(), EffectType.Subscript);
  }

  public void SelectionNormal()
  {
    this.method_2().SetSelectionEffect(this.GetContext(), EffectType.Normal);
  }
}
