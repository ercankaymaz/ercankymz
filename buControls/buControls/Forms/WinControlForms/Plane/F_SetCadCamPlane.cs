// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Plane.F_SetCadCamPlane
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Plane;

public class F_SetCadCamPlane : Form
{
  public WorkPlane Plane = new WorkPlane();
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList imageList_0;
  public Button btn_ok;
  public Button btn_planefreesettings;
  public Button btn_planefree;
  public Button btn_planezy;
  public Button btn_planeyz;
  public Button btn_planeyx;
  public Button btn_planexy;
  public Button btn_planezx;
  public Button btn_planexz;
  internal Panel panel_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  internal Label label_8;
  internal Label label_9;
  internal Label label_10;
  internal Label label_11;

  public F_SetCadCamPlane() => Class39.smethod_94(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.btn_planeyx.BackColor = Color.Gainsboro;
    this.btn_planexy.BackColor = Color.Gainsboro;
    this.btn_planeyz.BackColor = Color.Gainsboro;
    this.btn_planezy.BackColor = Color.Gainsboro;
    this.btn_planexz.BackColor = Color.Gainsboro;
    this.btn_planezx.BackColor = Color.Gainsboro;
    this.btn_planefree.BackColor = Color.Gainsboro;
    if (this.Plane.PlaneName == planeNames.Top)
      this.btn_planexy.BackColor = Color.Gold;
    else if (this.Plane.PlaneName == planeNames.Bottom)
      this.btn_planeyx.BackColor = Color.Gold;
    else if (this.Plane.PlaneName == planeNames.Front)
      this.btn_planexz.BackColor = Color.Gold;
    else if (this.Plane.PlaneName == planeNames.Back)
      this.btn_planezx.BackColor = Color.Gold;
    else if (this.Plane.PlaneName == planeNames.Left)
      this.btn_planeyz.BackColor = Color.Gold;
    else if (this.Plane.PlaneName == planeNames.Right)
      this.btn_planezy.BackColor = Color.Gold;
    else
      this.btn_planefree.BackColor = Color.Gold;
    this.numericUpDown_2.Value = (Decimal) this.Plane.Normalies.X;
    this.numericUpDown_1.Value = (Decimal) this.Plane.Normalies.Y;
    this.numericUpDown_0.Value = (Decimal) this.Plane.Normalies.Z;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_SetCadCamPlane.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.btn_planeyx.BackColor = Color.Gainsboro;
    this.btn_planexy.BackColor = Color.Gainsboro;
    this.btn_planeyz.BackColor = Color.Gainsboro;
    this.btn_planezy.BackColor = Color.Gainsboro;
    this.btn_planexz.BackColor = Color.Gainsboro;
    this.btn_planezx.BackColor = Color.Gainsboro;
    this.btn_planefree.BackColor = Color.Gainsboro;
    if (control2.Name == this.btn_planexy.Name)
    {
      this.Plane.Normalies = new Vec3D(0.0, 0.0, 1.0);
      this.btn_planexy.BackColor = Color.Gold;
      this.Plane.PlaneName = planeNames.Top;
      this.Plane.PlaneType = planeType.XY;
    }
    if (control2.Name == this.btn_planeyx.Name)
    {
      this.Plane.Normalies = new Vec3D(0.0, 0.0, -1.0);
      this.btn_planeyx.BackColor = Color.Gold;
      this.Plane.PlaneName = planeNames.Bottom;
      this.Plane.PlaneType = planeType.YZ;
    }
    if (control2.Name == this.btn_planezy.Name)
    {
      this.Plane.Normalies = new Vec3D(-1.0, 0.0, 0.0);
      this.btn_planezy.BackColor = Color.Gold;
      this.Plane.PlaneName = planeNames.Right;
      this.Plane.PlaneType = planeType.ZY;
    }
    if (control2.Name == this.btn_planeyz.Name)
    {
      this.Plane.Normalies = new Vec3D(1.0, 0.0, 0.0);
      this.btn_planeyz.BackColor = Color.Gold;
      this.Plane.PlaneName = planeNames.Left;
      this.Plane.PlaneType = planeType.YZ;
    }
    if (control2.Name == this.btn_planezx.Name)
    {
      this.Plane.Normalies = new Vec3D(0.0, 1.0, 0.0);
      this.btn_planezx.BackColor = Color.Gold;
      this.Plane.PlaneName = planeNames.Back;
      this.Plane.PlaneType = planeType.ZX;
    }
    if (control2.Name == this.btn_planexz.Name)
    {
      this.Plane.Normalies = new Vec3D(0.0, -1.0, 0.0);
      this.btn_planexz.BackColor = Color.Gold;
      this.Plane.PlaneName = planeNames.Front;
      this.Plane.PlaneType = planeType.XZ;
    }
    if (control2.Name == this.btn_planefree.Name)
    {
      this.Plane.Normalies = new Vec3D((double) this.numericUpDown_2.Value, (double) this.numericUpDown_1.Value, (double) this.numericUpDown_0.Value);
      this.Plane.PlaneName = planeNames.Free;
      this.btn_planefree.BackColor = Color.Gold;
      this.Plane.PlaneType = planeType.Angle;
    }
    if (control2.Name == this.btn_planefreesettings.Name)
    {
      if (this.panel_0.Visible)
        this.panel_0.Visible = false;
      else
        this.panel_0.Visible = true;
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
      Class39.smethod_844(this);
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
