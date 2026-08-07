// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.ColorDialogBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.ColorPicker;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox;

public class ColorDialogBox : Form
{
  public static Color Color = Color.Black;
  public static DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  public buColorPicker buColorPicker1;

  public ColorDialogBox() => Class39.smethod_392(this);

  public static Color ShowDialog(Color cColor)
  {
    ColorDialogBox.Color = cColor;
    ColorDialogBox colorDialogBox = new ColorDialogBox();
    colorDialogBox.buColorPicker1.Color = ColorDialogBox.Color;
    colorDialogBox.buColorPicker1.ColorChanged += new colorChangedEventHandler(Class39.smethod_820);
    int num = (int) colorDialogBox.ShowDialog();
    colorDialogBox.Dispose();
    return ColorDialogBox.Color;
  }

  public static DialogResult ShowDialog(ref Color cColor)
  {
    ColorDialogBox.Color = cColor;
    ColorDialogBox colorDialogBox = new ColorDialogBox();
    colorDialogBox.buColorPicker1.Color = ColorDialogBox.Color;
    colorDialogBox.buColorPicker1.ColorChanged += new colorChangedEventHandler(Class39.smethod_820);
    int num = (int) colorDialogBox.ShowDialog();
    colorDialogBox.Dispose();
    cColor = ColorDialogBox.Color;
    return ColorDialogBox.Result;
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Visible = false;
    ColorDialogBox.Result = DialogResult.Cancel;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Visible = false;
    ColorDialogBox.Result = DialogResult.OK;
  }

  internal void method_2(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
