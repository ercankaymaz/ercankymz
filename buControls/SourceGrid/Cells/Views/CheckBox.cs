// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.CheckBox
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
public class CheckBox : Cell
{
  public static readonly CheckBox Default = new CheckBox();
  public static readonly CheckBox MiddleLeftAlign = new CheckBox();
  private ContentAlignment m_CheckBoxAlignment = ContentAlignment.MiddleCenter;
  private DevAge.Drawing.VisualElements.ICheckBox mElementCheckBox = (DevAge.Drawing.VisualElements.ICheckBox) new CheckBoxThemed();

  static CheckBox()
  {
    CheckBox.MiddleLeftAlign.CheckBoxAlignment = ContentAlignment.MiddleLeft;
    CheckBox.MiddleLeftAlign.TextAlignment = ContentAlignment.MiddleLeft;
  }

  public CheckBox()
  {
  }

  public CheckBox(CheckBox p_Source)
    : base((Cell) p_Source)
  {
    this.m_CheckBoxAlignment = p_Source.m_CheckBoxAlignment;
    this.ElementCheckBox = (DevAge.Drawing.VisualElements.ICheckBox) this.ElementCheckBox.Clone();
  }

  public ContentAlignment CheckBoxAlignment
  {
    get => this.m_CheckBoxAlignment;
    set => this.m_CheckBoxAlignment = value;
  }

  protected override void PrepareView(CellContext context)
  {
    base.PrepareView(context);
    this.PrepareVisualElementCheckBox(context);
  }

  protected override IEnumerable<IVisualElement> GetElements()
  {
    if (this.ElementCheckBox != null)
      yield return (IVisualElement) this.ElementCheckBox;
    IEnumerator<IVisualElement> enumerator = this.method_0().GetEnumerator();
    while (enumerator.MoveNext())
    {
      IVisualElement element = enumerator.Current;
      yield return element;
      element = (IVisualElement) null;
    }
    Class39.smethod_692(this);
    enumerator = (IEnumerator<IVisualElement>) null;
  }

  private IEnumerable<IVisualElement> method_0() => base.GetElements();

  public DevAge.Drawing.VisualElements.ICheckBox ElementCheckBox
  {
    get => this.mElementCheckBox;
    set => this.mElementCheckBox = value;
  }

  protected virtual void PrepareVisualElementCheckBox(CellContext context)
  {
    this.ElementCheckBox.AnchorArea = new AnchorArea(this.CheckBoxAlignment, false);
    CheckBoxStatus checkBoxStatus = ((SourceGrid.Cells.Models.ICheckBox) context.Cell.Model.FindModel(typeof (SourceGrid.Cells.Models.ICheckBox))).GetCheckBoxStatus(context);
    this.ElementCheckBox.Style = !context.CellRange.Contains(context.Grid.MouseCellPosition) ? (!checkBoxStatus.CheckEnable ? ControlDrawStyle.Disabled : ControlDrawStyle.Normal) : (!checkBoxStatus.CheckEnable ? ControlDrawStyle.Disabled : ControlDrawStyle.Hot);
    this.ElementCheckBox.CheckBoxState = checkBoxStatus.CheckState;
    this.ElementText.Value = checkBoxStatus.Caption;
  }

  public override object Clone() => (object) new CheckBox(this);
}
