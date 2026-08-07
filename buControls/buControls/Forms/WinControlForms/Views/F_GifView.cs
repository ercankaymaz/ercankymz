// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Views.F_GifView
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Views;

public class F_GifView : Form
{
  public FormProperties Properties = new FormProperties();
  public Image refImage = (Image) null;
  private PictureBoxSizeMode pictureBoxSizeMode_0 = PictureBoxSizeMode.Zoom;
  private IContainer icontainer_0 = (IContainer) null;
  public PictureBox pic_view;

  public F_GifView() => Class39.smethod_740(this);

  public void Init()
  {
    this.pic_view.Image = this.refImage;
    this.pic_view.SizeMode = this.pictureBoxSizeMode_0;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
