// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlLanguage
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns16;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class47))]
public class buControlLanguage
{
  private string string_0 = "";
  private string string_1 = "";
  private string string_2 = "";
  private string string_3 = "";
  private string string_4 = "";
  private string string_5 = "";
  private bool bool_0 = false;
  private int int_0 = 0;
  public Control Parent = (Control) null;

  public buControlLanguage()
  {
  }

  public buControlLanguage(buControlLanguage control)
  {
    this.Language1 = control.Language1;
    this.Language2 = control.Language2;
    this.Language3 = control.Language3;
    this.Language4 = control.Language4;
    this.Language5 = control.Language5;
    this.Language6 = control.Language1;
    this.MultiLanguageEnable = control.MultiLanguageEnable;
    this.SelectedLanguage = control.SelectedLanguage;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Language1
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
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Language2
  {
    get => this.string_1;
    set
    {
      this.string_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Language3
  {
    get => this.string_2;
    set
    {
      this.string_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Language4
  {
    get => this.string_3;
    set
    {
      this.string_3 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Language5
  {
    get => this.string_4;
    set
    {
      this.string_4 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Language6
  {
    get => this.string_5;
    set
    {
      this.string_5 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(false)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool MultiLanguageEnable
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
  [DefaultValue(0)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int SelectedLanguage
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

  public override string ToString() => this.MultiLanguageEnable.ToString();
}
