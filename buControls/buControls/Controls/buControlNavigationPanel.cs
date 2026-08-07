// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlNavigationPanel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns16;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class66))]
public class buControlNavigationPanel
{
  private int int_0 = 50;
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  public Control Parent;

  public buControlNavigationPanel()
  {
  }

  public buControlNavigationPanel(buControlNavigationPanel navigation)
  {
    this.ButtonSize = navigation.ButtonSize;
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonDisplay
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
  [DefaultValue(50)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int ButtonSize
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

  public override string ToString() => "S : " + this.ButtonSize.ToString();
}
