// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Plane.F_PlaneSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Plane;

public class F_PlaneSelection : Form
{
  public ProfilePlaneData Plane = new ProfilePlaneData();
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  internal Panel panel_0;
  internal PictureBox pictureBox_0;
  internal Label label_0;
  public NumericUpDown spn_planeegillen;
  public Button btn_planeegiksettings;
  public Button btn_planeegik;
  public Button btn_planeleft;
  public Button btn_planeright;
  public Button btn_planebottom;
  internal Label label_1;
  public Button btn_planetop;
  public Button btn_cancel;
  public Button btn_ok;

  public F_PlaneSelection() => Class39.smethod_426(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.btn_planebottom.BackColor = Color.LightGray;
    this.btn_planetop.BackColor = Color.LightGray;
    this.btn_planeright.BackColor = Color.LightGray;
    this.btn_planeleft.BackColor = Color.LightGray;
    this.btn_planeegik.BackColor = Color.LightGray;
    if (this.Plane.PlaneSelectedName == planeNames.Top)
      this.btn_planetop.BackColor = Color.Gold;
    if (this.Plane.PlaneSelectedName == planeNames.Bottom)
      this.btn_planebottom.BackColor = Color.Gold;
    if (this.Plane.PlaneSelectedName == planeNames.Left)
      this.btn_planeleft.BackColor = Color.Gold;
    if (this.Plane.PlaneSelectedName == planeNames.Right)
      this.btn_planeright.BackColor = Color.Gold;
    if (this.Plane.PlaneSelectedName == planeNames.Free)
      this.btn_planeegik.BackColor = Color.Gold;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_PlaneSelection.Captions.Count >= 1)
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
    this.btn_planebottom.BackColor = Color.LightGray;
    this.btn_planetop.BackColor = Color.LightGray;
    this.btn_planeright.BackColor = Color.LightGray;
    this.btn_planeleft.BackColor = Color.LightGray;
    this.btn_planeegik.BackColor = Color.LightGray;
    if (control2.Name == this.btn_planetop.Name)
    {
      this.btn_planebottom.BackColor = Color.LightGray;
      this.btn_planetop.BackColor = Color.LightGray;
      this.btn_planeright.BackColor = Color.LightGray;
      this.btn_planeleft.BackColor = Color.LightGray;
      this.btn_planeegik.BackColor = Color.LightGray;
      this.Plane.PlaneSelectedName = planeNames.Top;
      this.btn_planetop.BackColor = Color.Gold;
    }
    if (control2.Name == this.btn_planebottom.Name)
    {
      this.btn_planebottom.BackColor = Color.LightGray;
      this.btn_planetop.BackColor = Color.LightGray;
      this.btn_planeright.BackColor = Color.LightGray;
      this.btn_planeleft.BackColor = Color.LightGray;
      this.btn_planeegik.BackColor = Color.LightGray;
      this.Plane.PlaneSelectedName = planeNames.Top;
      this.btn_planebottom.BackColor = Color.Gold;
    }
    if (control2.Name == this.btn_planeleft.Name)
    {
      this.btn_planebottom.BackColor = Color.LightGray;
      this.btn_planetop.BackColor = Color.LightGray;
      this.btn_planeright.BackColor = Color.LightGray;
      this.btn_planeleft.BackColor = Color.LightGray;
      this.btn_planeegik.BackColor = Color.LightGray;
      this.Plane.PlaneSelectedName = planeNames.Top;
      this.btn_planeleft.BackColor = Color.Gold;
    }
    if (control2.Name == this.btn_planeright.Name)
    {
      this.btn_planebottom.BackColor = Color.LightGray;
      this.btn_planetop.BackColor = Color.LightGray;
      this.btn_planeright.BackColor = Color.LightGray;
      this.btn_planeleft.BackColor = Color.LightGray;
      this.btn_planeegik.BackColor = Color.LightGray;
      this.Plane.PlaneSelectedName = planeNames.Top;
      this.btn_planeright.BackColor = Color.Gold;
    }
    if (control2.Name == this.btn_planeegik.Name)
    {
      this.btn_planebottom.BackColor = Color.LightGray;
      this.btn_planetop.BackColor = Color.LightGray;
      this.btn_planeright.BackColor = Color.LightGray;
      this.btn_planeleft.BackColor = Color.LightGray;
      this.btn_planeegik.BackColor = Color.LightGray;
      this.Plane.PlaneSelectedName = planeNames.Top;
      this.btn_planeegik.BackColor = Color.Gold;
    }
    if (control2.Name == this.btn_planeegik.Name)
    {
      this.btn_planebottom.BackColor = Color.LightGray;
      this.btn_planetop.BackColor = Color.LightGray;
      this.btn_planeright.BackColor = Color.LightGray;
      this.btn_planeleft.BackColor = Color.LightGray;
      this.btn_planeegik.BackColor = Color.LightGray;
      this.Plane.PlaneSelectedName = planeNames.Top;
      this.btn_planeegik.BackColor = Color.Gold;
    }
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_611(this);
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
