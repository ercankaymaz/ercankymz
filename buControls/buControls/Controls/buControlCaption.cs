// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlCaption
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns19;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class57))]
public class buControlCaption
{
  private bool bool_0 = false;
  private string string_0 = "";
  private int int_0 = 80 /*0x50*/;
  private double double_0 = 50.0;
  private bool bool_1 = false;
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  public Control Parent;

  public buControlCaption()
  {
  }

  public buControlCaption(buControlCaption caption)
  {
    this.Display = new buControlDisplay(caption.Display);
    this.OnTop = caption.OnTop;
    this.Visible = caption.Visible;
    this.Caption = caption.Caption;
    this.Width = caption.Width;
    this.HeightPersentage = caption.HeightPersentage;
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay Display
  {
    get => this.buControlDisplay_0;
    set
    {
      this.buControlDisplay_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(false)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool OnTop
  {
    get => this.bool_1;
    set
    {
      this.bool_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(false)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool Visible
  {
    get => this.bool_0;
    set
    {
      this.bool_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Caption
  {
    get => this.string_0;
    set
    {
      this.string_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(80 /*0x50*/)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int Width
  {
    get => this.int_0;
    set
    {
      this.int_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(50)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double HeightPersentage
  {
    get => this.double_0;
    set
    {
      this.double_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public override string ToString() => $"{this.Caption} Width : {this.Width.ToString()}";
}
