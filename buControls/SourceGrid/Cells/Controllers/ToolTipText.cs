// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.ToolTipText
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class ToolTipText : ControllerBase
{
  public static readonly ToolTipText Default = new ToolTipText();
  private string string_0 = string.Empty;
  private ToolTipIcon toolTipIcon_0 = ToolTipIcon.None;
  private bool bool_0 = false;
  private Color color_0 = Color.Empty;
  private Color color_1 = Color.Empty;

  public override void OnMouseEnter(CellContext sender, EventArgs e)
  {
    base.OnMouseEnter(sender, e);
    this.ApplyToolTipText(sender, e);
  }

  public override void OnMouseLeave(CellContext sender, EventArgs e)
  {
    base.OnMouseLeave(sender, e);
    this.ResetToolTipText(sender, e);
  }

  public string ToolTipTitle
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public ToolTipIcon ToolTipIcon
  {
    get => this.toolTipIcon_0;
    set => this.toolTipIcon_0 = value;
  }

  public bool IsBalloon
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  public Color BackColor
  {
    get => this.color_0;
    set => this.color_0 = value;
  }

  public Color ForeColor
  {
    get => this.color_1;
    set => this.color_1 = value;
  }

  protected virtual void ApplyToolTipText(CellContext sender, EventArgs e)
  {
    IToolTipText model;
    if ((model = (IToolTipText) sender.Cell.Model.FindModel(typeof (IToolTipText))) == null)
      return;
    string toolTipText = model.GetToolTipText(sender);
    if ((toolTipText == null ? 0 : (toolTipText.Length > 0 ? 1 : 0)) == 0)
      return;
    sender.Grid.ToolTipText = toolTipText;
    sender.Grid.ToolTip.ToolTipTitle = this.ToolTipTitle;
    sender.Grid.ToolTip.ToolTipIcon = this.ToolTipIcon;
    sender.Grid.ToolTip.IsBalloon = this.IsBalloon;
    if (!this.BackColor.IsEmpty)
      sender.Grid.ToolTip.BackColor = this.BackColor;
    if (this.ForeColor.IsEmpty)
      return;
    sender.Grid.ToolTip.ForeColor = this.ForeColor;
  }

  protected virtual void ResetToolTipText(CellContext sender, EventArgs e)
  {
    if (sender.Cell.Model.FindModel(typeof (IToolTipText)) == null)
      return;
    sender.Grid.ToolTipText = (string) null;
  }
}
