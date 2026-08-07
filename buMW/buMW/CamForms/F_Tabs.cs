// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_Tabs
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_Tabs : Form
{
  internal NumericUpDown \u0004;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  public ComboBox cmb_sharpcornertype;
  internal System.Windows.Forms.Label \u0006;
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
  internal System.Windows.Forms.Label \u0002;
  internal Button \u0001;
  internal Button \u0002;
  internal ListBox \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u0006;
  internal Panel \u0001;
  internal Button \u0003;
  internal Button \u0004;
  internal System.Windows.Forms.Label \u0007;

  public void ControlUpdate()
  {
    ((F_SharpCorner) this).\u0002.Enabled = false;
    ((F_SharpCorner) this).\u0003.Enabled = false;
    ((F_SharpCorner) this).\u0002.Enabled = false;
    ((F_SharpCorner) this).\u0001.Enabled = false;
    if (this.cmb_sharpcornertype.SelectedIndex == 1 | this.cmb_sharpcornertype.SelectedIndex == 2 | this.cmb_sharpcornertype.SelectedIndex == 3)
    {
      ((F_SharpCorner) this).\u0002.Enabled = true;
      ((F_SharpCorner) this).\u0003.Enabled = true;
      ((F_SharpCorner) this).\u0002.Enabled = true;
      ((F_SharpCorner) this).\u0001.Enabled = true;
    }
    if (this.\u0002.Checked)
    {
      this.\u0006.Enabled = true;
      this.\u0004.Enabled = true;
      ((F_SharpCorner) this).\u0004.Enabled = false;
      ((F_SharpCorner) this).\u0003.Enabled = false;
    }
    else
    {
      this.\u0006.Enabled = false;
      this.\u0004.Enabled = false;
      ((F_SharpCorner) this).\u0004.Enabled = true;
      ((F_SharpCorner) this).\u0003.Enabled = true;
    }
  }

  public void Apply()
  {
    if (((F_SharpCorner) this).Configration.Mode != CamMode.WireFrame)
      return;
    if (this.cmb_sharpcornertype.SelectedIndex == 0 | this.cmb_sharpcornertype.SelectedIndex == 2 | this.cmb_sharpcornertype.SelectedIndex == 3)
    {
      if (this.cmb_sharpcornertype.SelectedIndex == 0)
        ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCorners = WireframeBasedTpCalcParamsSharpCorners.WfbScExtension;
      else if (this.cmb_sharpcornertype.SelectedIndex == 2)
        ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCorners = WireframeBasedTpCalcParamsSharpCorners.WfbScLoop;
      else if (this.cmb_sharpcornertype.SelectedIndex == 3)
        ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCorners = WireframeBasedTpCalcParamsSharpCorners.WfbScBisectorLine;
      if (this.\u0002.Checked)
        ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = new PercentOrValueParameter(((F_SharpCorner) this).mwCamParameter.Units, true)
        {
          Percent = (double) this.\u0004.Value
        };
      else
        ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = new PercentOrValueParameter(((F_SharpCorner) this).mwCamParameter.Units, false)
        {
          Value = (double) this.\u0004.Value
        };
    }
    if (this.cmb_sharpcornertype.SelectedIndex == 1)
    {
      ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCorners = WireframeBasedTpCalcParamsSharpCorners.WfbScLoop;
      if (this.\u0002.Checked)
        ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLoopRadius = new PercentOrValueParameter(((F_SharpCorner) this).mwCamParameter.Units, true)
        {
          Percent = (double) this.\u0004.Value
        };
      else
        ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLoopRadius = new PercentOrValueParameter(((F_SharpCorner) this).mwCamParameter.Units, false)
        {
          Value = (double) this.\u0004.Value
        };
    }
    ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersStartAngle = (double) ((F_SharpCorner) this).\u0002.Value;
    ((F_SharpCorner) this).mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersEndAngle = (double) ((F_SharpCorner) this).\u0001.Value;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SharpCorner) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SharpCorner) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Tabs() => F_SharpCorner.Captions = new List<string>();

  public F_Tabs() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Configration.Mode == CamMode.WireFrame)
    {
      this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TabsWidth;
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TabsHeight;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TabsEntryFeedRate;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TabsExitFeedRate;
      this.\u0001.Items.Clear();
      for (int index = 0; index <= this.mwCamParameter.TabsPoints.Count<Point3d<double>>() - 1; ++index)
      {
        ListBox.ObjectCollection items = this.\u0001.Items;
        string[] strArray = new string[5];
        double num = this.mwCamParameter.TabsPoints.ElementAt<Point3d<double>>(index).X;
        strArray[0] = num.ToString();
        strArray[1] = " ; ";
        num = this.mwCamParameter.TabsPoints.ElementAt<Point3d<double>>(index).Y;
        strArray[2] = num.ToString();
        strArray[3] = " ; ";
        num = this.mwCamParameter.TabsPoints.ElementAt<Point3d<double>>(index).Z;
        strArray[4] = num.ToString();
        string str = string.Concat(strArray);
        items.Add((object) str);
      }
    }
    ((F_FeedZone) this).ControlUpdate();
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
      ((F_FeedZone) this).Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.\u0003.Name)
    {
      ListBox.ObjectCollection items = this.\u0001.Items;
      string[] strArray = new string[5];
      Decimal num = ((F_FeedZone) this).\u0007.Value;
      strArray[0] = num.ToString();
      strArray[1] = ";";
      num = ((F_FeedZone) this).\u0006.Value;
      strArray[2] = num.ToString();
      strArray[3] = ";";
      num = ((F_FeedZone) this).\u0005.Value;
      strArray[4] = num.ToString();
      string str = string.Concat(strArray);
      items.Add((object) str);
      this.\u0001.Visible = false;
    }
    if (control2.Name == this.\u0004.Name)
      this.\u0001.Visible = false;
    if (control2.Name == this.\u0001.Name)
      this.\u0001.Visible = true;
    if (!(control2.Name == this.\u0002.Name) || !(this.\u0001.SelectedIndex >= 0 & this.\u0001.SelectedIndex <= this.\u0001.Items.Count - 1))
      return;
    this.\u0001.Items.RemoveAt(this.\u0001.SelectedIndex);
  }
}
