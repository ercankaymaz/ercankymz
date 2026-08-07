// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_FeedZone
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using ModuleWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_FeedZone : Form
{
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u000E;
  internal NumericUpDown \u0007;
  public static byte f000791;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_ok;
  internal ImageList \u0002;
  public Button btn_cancel;
  internal CheckBox \u0001;

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    if (((F_Tabs) this).Configration.Mode != CamMode.WireFrame)
      return;
    ((F_Tabs) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TabsWidth = (double) ((F_Tabs) this).\u0004.Value;
    ((F_Tabs) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TabsHeight = (double) ((F_Tabs) this).\u0003.Value;
    ((F_Tabs) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TabsEntryFeedRate = (double) ((F_Tabs) this).\u0002.Value;
    ((F_Tabs) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TabsExitFeedRate = (double) ((F_Tabs) this).\u0001.Value;
    List<Point3d<double>> list = ((F_Tabs) this).mwCamParameter.TabsPoints.ToList<Point3d<double>>();
    list.Clear();
    for (int index = 0; index <= ((F_Tabs) this).\u0001.Items.Count - 1; ++index)
    {
      string[] strArray = ((F_Tabs) this).\u0001.Items[index].ToString().Split(';');
      if (strArray != null && strArray.Length == 3)
      {
        double result1 = 0.0;
        double result2 = 0.0;
        double result3 = 0.0;
        double.TryParse(strArray[0], out result1);
        double.TryParse(strArray[1], out result2);
        double.TryParse(strArray[2], out result3);
        list.Add(new Point3d<double>(result1, result2, result3));
      }
    }
    ((F_Tabs) this).mwCamParameter.TabsPoints = (IEnumerable<Point3d<double>>) list;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Tabs) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Tabs) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FeedZone() => F_Tabs.Captions = new List<string>();

  public F_FeedZone() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_Fixtures) this).\u0003.Value = (Decimal) this.mwCamParameter.MachParam.FeedControlZoneParams.Offset;
    ((F_Fixtures) this).\u0001.Value = (Decimal) this.mwCamParameter.MachParam.FeedControlZoneParams.OutsideFeedRatePercentage;
    ((F_Fixtures) this).\u0002.Value = (Decimal) this.mwCamParameter.MachParam.FeedControlZoneParams.InsideFeedRatePercentage;
    ((F_Fixtures) this).ControlUpdate();
    this.\u0001.Image = (Image) null;
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
    if (control2.Name == this.btn_ok.Name)
    {
      ((F_Fixtures) this).Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
