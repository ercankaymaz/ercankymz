// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_DataClass
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buControls.ClassViewer;
using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_DataClass : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  public buClassViewer buClassViewer1;

  public F_DataClass() => Class5.smethod_77(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
  }

  internal void method_1(object sender, KeyEventArgs e)
  {
    if (e.KeyCode != Keys.Escape)
      return;
    clsInit.appCommand.Reset();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
