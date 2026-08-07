// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Profile.F_ProfileERPList
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using devDept.Eyeshot.Control;
using ns8;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Profile;

public class F_ProfileERPList : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public string pathString = Application.StartupPath;
  public Design viewportPort = (Design) null;
  public int SelectedJob = -1;
  public bool isLeftHolder = true;
  private Timer timer_0 = new Timer();
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal ImageList imageList_0;
  internal ImageList imageList_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  public ListBox lst_items;
  public Panel pnl_viewport;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;
  internal Button button_9;
  internal Button button_10;
  internal Button button_11;
  internal Button button_12;
  internal Button button_13;
  internal Button button_14;
  internal Button button_15;
  internal Button button_16;
  internal Button button_17;
  public CheckBox chk_deleteloaded;
  public RadioButton radio_leftholder;
  public RadioButton radio_rightholder;
  internal Button button_18;

  public F_ProfileERPList() => Class5.smethod_156(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.isLeftHolder)
    {
      this.radio_leftholder.Checked = true;
      this.radio_rightholder.Checked = false;
    }
    else
    {
      this.radio_leftholder.Checked = false;
      this.radio_rightholder.Checked = true;
    }
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.timer_0.Interval = 100;
    this.timer_0.Enabled = true;
    Class5.smethod_142(this);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  private void timer_0_Tick(object sender, EventArgs e) => this.timer_0.Enabled = false;

  internal void method_1(object sender, EventArgs e)
  {
    this.PropertiesForm.Inited = false;
    clsInit.appProfile.doJobListChanged(this.lst_items.SelectedIndex);
    this.SelectedJob = this.lst_items.SelectedIndex;
    this.PropertiesForm.Inited = true;
  }

  internal void method_2(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.button_0.Name)
    {
      if (this.radio_leftholder.Checked)
        this.isLeftHolder = true;
      if (this.radio_rightholder.Checked)
        this.isLeftHolder = false;
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_1.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_2.Name)
      clsInit.appProfile.doJobListDelete(this.lst_items.SelectedIndex);
    if (control2.Name == this.button_18.Name)
      clsInit.appProfile.doJobListDeleteAll();
    if (control2.Name == this.button_3.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = this.pathString;
      openFileDialog.Filter = "Profile List (*.profilelist)|*.profilelist";
      openFileDialog.FilterIndex = 1;
      openFileDialog.Multiselect = false;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        this.pathString = buFile5.GetPath(openFileDialog.FileName);
        clsInit.appProfile.doJobListOpen(openFileDialog.FileName);
      }
    }
    if (control2.Name == this.button_4.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = this.pathString;
      saveFileDialog.Filter = "Profile List (*.profilelist)|*.profilelist";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        this.pathString = buFile5.GetPath(saveFileDialog.FileName);
        clsInit.appProfile.doJobListSave(saveFileDialog.FileName);
      }
    }
    if (control2.Name == this.button_12.Name)
      buEyeShotFunctions.ViewZoomIn(ref this.viewportPort);
    if (control2.Name == this.button_14.Name)
      buEyeShotFunctions.ViewZoomNormal(ref this.viewportPort);
    if (control2.Name == this.button_11.Name)
      buEyeShotFunctions.ViewZoomOut(ref this.viewportPort);
    if (control2.Name == this.button_15.Name)
      buEyeShotFunctions.ViewZoomWindow(ref this.viewportPort);
    if (control2.Name == this.button_5.Name)
      buEyeShotFunctions.ViewTop(ref this.viewportPort, true);
    if (control2.Name == this.button_6.Name)
      buEyeShotFunctions.ViewBottom(ref this.viewportPort, true);
    if (control2.Name == this.button_7.Name)
      buEyeShotFunctions.Viewfront(ref this.viewportPort, true);
    if (control2.Name == this.button_10.Name)
      buEyeShotFunctions.ViewBack(ref this.viewportPort, true);
    if (control2.Name == this.button_8.Name)
      buEyeShotFunctions.ViewRight(ref this.viewportPort, true);
    if (control2.Name == this.button_9.Name)
      buEyeShotFunctions.ViewLeft(ref this.viewportPort, true);
    if (control2.Name == this.button_13.Name)
      buEyeShotFunctions.ViewProfile(ref this.viewportPort, true);
    if (control2.Name == this.button_16.Name)
      buEyeShotFunctions.ViewRotate(ref this.viewportPort);
    if (!(control2.Name == this.button_17.Name))
      return;
    buEyeShotFunctions.ViewPan(ref this.viewportPort);
  }

  internal void method_3(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
