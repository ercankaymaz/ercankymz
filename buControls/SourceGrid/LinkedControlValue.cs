// Decompiled with JetBrains decompiler
// Type: SourceGrid.LinkedControlValue
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Windows.Forms;

#nullable disable
namespace SourceGrid;

public class LinkedControlValue
{
  private Control control;
  private Position position;
  private bool bool_0;
  private LinkedControlScrollMode linkedControlScrollMode_0;

  public LinkedControlValue(Control control, Position position)
  {
    this.control = control;
    this.position = position;
    this.bool_0 = true;
    this.linkedControlScrollMode_0 = LinkedControlScrollMode.BasedOnPosition;
  }

  public Control Control => this.control;

  public Position Position
  {
    get => this.position;
    set => this.position = value;
  }

  public bool UseCellBorder
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  public LinkedControlScrollMode ScrollMode
  {
    get => this.linkedControlScrollMode_0;
    set => this.linkedControlScrollMode_0 = value;
  }

  public override string ToString() => this.Position.ToString();
}
