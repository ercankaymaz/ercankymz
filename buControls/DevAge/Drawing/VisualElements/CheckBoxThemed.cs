// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.CheckBoxThemed
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class CheckBoxThemed : CheckBoxBase
{
  private CheckBox mStandardCheckBox = new CheckBox();

  public CheckBoxThemed()
  {
  }

  public CheckBoxThemed(CheckBoxThemed other)
    : base((CheckBoxBase) other)
  {
  }

  public override object Clone() => (object) new CheckBoxThemed(this);

  public override ControlDrawStyle Style
  {
    get => base.Style;
    set
    {
      base.Style = value;
      this.mStandardCheckBox.Style = value;
    }
  }

  public override DevAge.Drawing.CheckBoxState CheckBoxState
  {
    get => base.CheckBoxState;
    set
    {
      base.CheckBoxState = value;
      this.mStandardCheckBox.CheckBoxState = value;
    }
  }

  protected VisualStyleElement GetBackgroundElement()
  {
    return this.Style != ControlDrawStyle.Hot ? (this.Style != ControlDrawStyle.Pressed ? (this.Style != ControlDrawStyle.Disabled ? (this.CheckBoxState != DevAge.Drawing.CheckBoxState.Checked ? (this.CheckBoxState != DevAge.Drawing.CheckBoxState.Unchecked ? VisualStyleElement.Button.CheckBox.MixedNormal : VisualStyleElement.Button.CheckBox.UncheckedNormal) : VisualStyleElement.Button.CheckBox.CheckedNormal) : (this.CheckBoxState != DevAge.Drawing.CheckBoxState.Checked ? (this.CheckBoxState != DevAge.Drawing.CheckBoxState.Unchecked ? VisualStyleElement.Button.CheckBox.MixedDisabled : VisualStyleElement.Button.CheckBox.UncheckedDisabled) : VisualStyleElement.Button.CheckBox.CheckedDisabled)) : (this.CheckBoxState != DevAge.Drawing.CheckBoxState.Checked ? (this.CheckBoxState != DevAge.Drawing.CheckBoxState.Unchecked ? VisualStyleElement.Button.CheckBox.MixedPressed : VisualStyleElement.Button.CheckBox.UncheckedPressed) : VisualStyleElement.Button.CheckBox.CheckedPressed)) : (this.CheckBoxState != DevAge.Drawing.CheckBoxState.Checked ? (this.CheckBoxState != DevAge.Drawing.CheckBoxState.Unchecked ? VisualStyleElement.Button.CheckBox.MixedHot : VisualStyleElement.Button.CheckBox.UncheckedHot) : VisualStyleElement.Button.CheckBox.CheckedHot);
  }

  protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
  {
    return new VisualStyleRenderer(element);
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if ((!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) != 0)
      this.GetRenderer(this.GetBackgroundElement()).DrawBackground((IDeviceContext) graphics.Graphics, Rectangle.Round(area));
    else
      this.mStandardCheckBox.Draw(graphics, area);
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    return (!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) == 0 ? this.mStandardCheckBox.Measure(measure, (SizeF) Size.Empty, maxSize) : (SizeF) this.GetRenderer(this.GetBackgroundElement()).GetPartSize((IDeviceContext) measure.Graphics, ThemeSizeType.True);
  }
}
