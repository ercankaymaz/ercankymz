// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_RoundCorner
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;
using buImages;
using ModuleWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_RoundCorner : Form
{
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal CheckBox \u0001;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_Silhouette) this).PropertiesForm.TouchPad & !this.\u0001.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Silhouette) this).\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.SilhouetteOffsetTriMeshRough;
    else if (control2.Name == ((F_Silhouette) this).\u0003.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.SilhouettePartSilhouetteTriMeshRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_Silhouette) this).\u0002.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.SilhouettePartEndHeightTriMeshRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_Silhouette) this).\u0001.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.SilhouetteToolContactTriMeshRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0005.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.SilhouetteTopofVerticalWallsTriMeshRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0004.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.SilhouetteBottomofVeritcalWallsTriMeshRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    this.\u0001.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Silhouette) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Silhouette) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RoundCorner() => F_Silhouette.Captions = new List<string>();

  public F_RoundCorner() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.SplineMaxDeviation;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
    ((F_CuttingMethodAdvanced) this).\u0001.Image = (Image) null;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_CuttingMethodAdvanced) this).btn_ok.Name)
    {
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_CuttingMethodAdvanced) this).btn_cancel.Name))
      return;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.SplineMaxDeviation = (double) this.\u0001.Value;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.Controls, result, obj1.Shift);
  }
}
