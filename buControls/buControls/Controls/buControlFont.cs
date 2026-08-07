// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlFont
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns18;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class50))]
public class buControlFont
{
  private Color color_0 = Color.Black;
  private Font font_0 = new Font("Tahoma", 12f);
  private ContentAlignment contentAlignment_0 = ContentAlignment.MiddleCenter;
  public Control Parent = (Control) null;

  public event EventHandler Changed;

  public buControlFont()
  {
  }

  public buControlFont(Color forecolor, Font fnt)
  {
    this.ForeColor = forecolor;
    this.Font = fnt;
  }

  public buControlFont(buControlFont font)
  {
    this.Font = font.Font;
    this.ForeColor = font.ForeColor;
    this.Alignment = font.Alignment;
  }

  public static void Copy(buControlFont Source, ref buControlFont Target)
  {
    Target.Font = Source.Font;
    Target.ForeColor = Source.ForeColor;
    Target.Alignment = Source.Alignment;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Font), "Tahoma, 12")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Font Font
  {
    get => this.font_0;
    set
    {
      this.font_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Black")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color ForeColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(ContentAlignment.MiddleCenter)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public ContentAlignment Alignment
  {
    get => this.contentAlignment_0;
    set
    {
      this.contentAlignment_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  protected void OnChanged()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler0 = this.eventHandler_0;
    if (eventHandler0 == null)
      return;
    eventHandler0((object) this, EventArgs.Empty);
  }

  public override string ToString()
  {
    string str = this.ForeColor.ToString();
    if (this.ForeColor.IsKnownColor)
      str = this.ForeColor.ToKnownColor().ToString();
    return $"{str} , {this.Font.Name} , {this.Font.Size.ToString()}";
  }
}
