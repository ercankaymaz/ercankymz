// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlTrack
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns18;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class65))]
public class buControlTrack
{
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  private buControlDisplay buControlDisplay_2 = new buControlDisplay();
  private int int_0 = 40;
  private bool bool_0 = true;
  private bool bool_1 = true;
  private string string_0 = "%";
  private bool bool_2 = true;
  private int int_1 = 10;
  public Control Parent;

  public buControlTrack()
  {
  }

  public buControlTrack(buControlTrack track)
  {
    this.DrawerDisplay = new buControlDisplay(track.DrawerDisplay);
    this.ValueDisplay = new buControlDisplay(track.ValueDisplay);
    this.DoneDisplay = new buControlDisplay(track.DoneDisplay);
    this.DrawerWidth = track.DrawerWidth;
    this.ValueShow = track.ValueShow;
    this.ShowPersentage = track.ShowPersentage;
    this.ValueWidth = track.ValueWidth;
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay DrawerDisplay
  {
    get => this.buControlDisplay_2;
    set
    {
      this.buControlDisplay_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay DoneDisplay
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

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ValueDisplay
  {
    get => this.buControlDisplay_1;
    set
    {
      this.buControlDisplay_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool ValueShow
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

  [DefaultValue(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool ShowPersentage
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

  [DefaultValue(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool DrawerRectangle
  {
    get => this.bool_2;
    set
    {
      this.bool_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue("%")]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string PersentageChar
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

  [DefaultValue(40)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int ValueWidth
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

  [DefaultValue(10)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int DrawerWidth
  {
    get => this.int_1;
    set
    {
      this.int_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public override string ToString() => "Trackbar";
}
