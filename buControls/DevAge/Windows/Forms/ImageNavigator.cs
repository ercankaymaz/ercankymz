// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.ImageNavigator
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class ImageNavigator : UserControl
{
  internal Label label_0;
  internal PictureBox pictureBox_0;
  internal Button button_0;
  internal Button button_1;
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private string string_0 = "{0} of {1}";
  private Image[] image_0;
  internal int int_0 = -1;

  public ImageNavigator()
  {
    Class39.smethod_59(this);
    this.SetStyle(ControlStyles.Selectable, true);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  public string StatusFormat
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public void NextImage()
  {
    if ((this.Images == null ? 0 : (this.int_0 < this.Images.Length - 1 ? 1 : 0)) == 0)
      return;
    ++this.CurrentImageIndex;
  }

  public void PreviousImage()
  {
    if ((this.Images == null ? 0 : (this.int_0 > 0 ? 1 : 0)) == 0)
      return;
    --this.CurrentImageIndex;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Image[] Images
  {
    get => this.image_0;
    set
    {
      this.image_0 = value;
      Class39.smethod_25(this);
    }
  }

  public int CurrentImageIndex
  {
    get => this.int_0;
    set
    {
      this.int_0 = value;
      Class39.smethod_278(this);
    }
  }

  public Size ImageAreaSize
  {
    get => this.pictureBox_0.Size;
    set
    {
      this.Width += value.Width - this.pictureBox_0.Width;
      this.Height += value.Height - this.pictureBox_0.Height;
    }
  }

  public BorderStyle ImageAreaBorderStyle
  {
    get => this.pictureBox_0.BorderStyle;
    set => this.pictureBox_0.BorderStyle = value;
  }

  public PictureBoxSizeMode ImageAreaSizeMode
  {
    get => this.pictureBox_0.SizeMode;
    set => this.pictureBox_0.SizeMode = value;
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);
    Class39.smethod_25(this);
  }

  internal void method_0(object sender, EventArgs e) => this.PreviousImage();

  internal void method_1(object sender, EventArgs e) => this.NextImage();
}
