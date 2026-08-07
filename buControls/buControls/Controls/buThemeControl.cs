// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buThemeControl
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public class buThemeControl : Component
{
  private ThemeType themeType_0 = ThemeType.Standart;
  private bool bool_0 = false;
  private ContainerControl containerControl_0 = (ContainerControl) null;

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(false)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool Enable
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  [DefaultValue(ThemeType.Standart)]
  [Browsable(true)]
  public ThemeType Theme
  {
    get => this.themeType_0;
    set
    {
      this.themeType_0 = value;
      Class39.smethod_164(this.ContainerControl.Controls, this);
    }
  }

  public ContainerControl ContainerControl
  {
    get => this.containerControl_0;
    set
    {
      this.containerControl_0 = value;
      Class39.smethod_164(this.ContainerControl.Controls, this);
    }
  }

  public override ISite Site
  {
    get => base.Site;
    set
    {
      base.Site = value;
      if (value == null || !(value.GetService(typeof (IDesignerHost)) is IDesignerHost service))
        return;
      IComponent rootComponent = service.RootComponent;
      if (!(rootComponent is ContainerControl))
        return;
      this.ContainerControl = rootComponent as ContainerControl;
    }
  }
}
