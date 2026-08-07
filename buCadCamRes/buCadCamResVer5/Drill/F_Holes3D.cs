// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Drill.F_Holes3D
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Holes;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Drill;

public class F_Holes3D : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public List<DrillItem> Items = new List<DrillItem>();
  public DrillJob Job = new DrillJob();
  public DrillJob tempJob = new DrillJob();
  public DrillRuntimeSettings settingRuntime = new DrillRuntimeSettings();
  public DrillCNCSettings settingCNC = new DrillCNCSettings();
  public static List<string> Captions = new List<string>();
  private Timer timer_0 = new Timer();
  private drillFocusedData drillFocusedData_0 = drillFocusedData.None;
  private double double_0 = -1.0;
  private double double_1 = 0.0;
  private bool bool_0 = false;
  private F_HolesTemp f_HolesTemp_0 = (F_HolesTemp) null;
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList imageList_1;
  internal Panel panel_0;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal Panel panel_1;
  internal PictureBox pictureBox_0;
  internal Label label_6;
  public Button btn_cornerrightBottom;
  public Button btn_cornerleftTop;
  public Button btn_cornerrightTop;
  public Button btn_cornerleftBottom;
  public Button btn_top;
  public Button btn_bottom;
  public Button btn_left;
  public Button btn_right;
  public Button btn_back;
  public Button btn_front;

  public F_Holes3D() => Class5.smethod_10(this);

  public event OkCommandWithThreeDataEventHandler DataChanged;

  public event CancelCommandEventHandler DataCancel;

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_Holes3D.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }

  public void AddControlsFromCommand() => this.panel_0.Controls.Clear();

  public void Apply()
  {
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control = new Control();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
