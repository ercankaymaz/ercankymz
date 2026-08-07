// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.DevAgeNumericUpDown
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeNumericUpDown : NumericUpDown
{
  internal IContainer icontainer_0 = (IContainer) null;

  public DevAgeNumericUpDown()
  {
    this.icontainer_0 = (IContainer) new System.ComponentModel.Container();
    this.UserEdit = true;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.icontainer_0 != null)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }

  protected override void OnValidated(EventArgs e)
  {
    base.OnValidated(e);
    this.ParseEditText();
  }
}
