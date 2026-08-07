// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_BendingItems
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_BendingItems : Form
{
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;

  public F_BendingItems() => Class39.smethod_791(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
