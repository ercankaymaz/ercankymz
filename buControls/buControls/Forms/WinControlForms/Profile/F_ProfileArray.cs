// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_ProfileArray
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Profile;

public class F_ProfileArray : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public ProfileOperationData OperationData = new ProfileOperationData();
  public camParameters CamPar = new camParameters();
  internal IContainer icontainer_0 = (IContainer) null;
  public CheckBox chk_lineer;
  public Panel panel4;
  public Label label4;
  public Label label5;
  public NumericUpDown spn_linearlen;
  public NumericUpDown spn_linearcount;
  public CheckBox chk_circular;
  public Panel panel3;
  public Label label3;
  public Label label1;
  public NumericUpDown spn_circularangle;
  public NumericUpDown spn_circularcount;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;

  public F_ProfileArray() => Class39.smethod_517(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.spn_circularangle.Value = (Decimal) this.OperationData.Array.CircularAngle;
    this.spn_circularcount.Value = (Decimal) this.OperationData.Array.CircularCount;
    this.spn_linearcount.Value = (Decimal) this.OperationData.Array.LineerCount;
    this.spn_linearlen.Value = (Decimal) this.OperationData.Array.LineerDistance;
    this.chk_circular.Checked = this.OperationData.Array.CircularEnable;
    this.chk_lineer.Checked = this.OperationData.Array.LineerEnable;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_ProfileArray.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
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

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_564(this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
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
