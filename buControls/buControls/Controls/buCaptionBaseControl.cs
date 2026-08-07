// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buCaptionBaseControl
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.ComponentModel;

#nullable disable
namespace buControls.Controls;

public abstract class buCaptionBaseControl : buControl
{
  private buControlCaption buControlCaption_0 = new buControlCaption();
  private buControlUnit buControlUnit_0 = new buControlUnit();
  private buControlCheckTick buControlCheckTick_0 = new buControlCheckTick();
  private buControlFocus buControlFocus_0 = new buControlFocus();

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlCaption Caption
  {
    get => this.buControlCaption_0;
    set
    {
      this.buControlCaption_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlUnit Unit
  {
    get => this.buControlUnit_0;
    set
    {
      this.buControlUnit_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlCheckTick CheckTick
  {
    get => this.buControlCheckTick_0;
    set
    {
      this.buControlCheckTick_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlFocus FocusControl
  {
    get => this.buControlFocus_0;
    set
    {
      this.buControlFocus_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }
}
