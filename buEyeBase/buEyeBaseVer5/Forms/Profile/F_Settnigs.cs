// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_Settnigs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.RollerBend;
using buEyeBaseVer5.Forms.Sewing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_Settnigs : Form
{
  public static byte f00136C;
  public FormProperties Properties;
  public static List<string> Captions = new List<string>();
  public List<SewingCode> CodesDefined;
  public List<SewingCode> Codes;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_ok;
  public Button btn_moveup;
  internal ListBox \u0001;
  internal ListBox \u0002;
  internal Label \u0001;
  internal Label \u0002;
  public Button btn_movedown;
  public Button btn_delete;
  public Button btn_clear;
  public Button btn_cancel;
  internal NumericUpDown \u0001;
  internal Label \u0003;
  public Button btn_addcodes;
  public static byte f001382;
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions;
  public double Speed = 1.0;
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  public Button btn_speed;
  internal NumericUpDown \u0001;
  public Button btn_cancel;
  internal Label \u0001;
  public static byte f00138E;
  public FormProperties Properties;
  public static List<string> Captions;
  public double FootHeight;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_footheight;
  internal NumericUpDown \u0001;
  public Button btn_cancel;
  internal Label \u0001;
  public static byte f00139A;
  public FormProperties Properties;
  public static List<string> Captions;
  public bool ShowDialog;
  public double RotateDegree;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_selectup;
  public Button btn_selectdown;
  public Button btn_ok;
  public static byte f0013A6;
  public FormProperties Properties;
  public static List<string> Captions;
  public double RotateDegree;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_rotateminus;
  internal NumericUpDown \u0001;
  public Button btn_rotateplus;
  public static byte f0013B1;
  public FormProperties Properties;
  public static List<string> Captions;
  public List<SewingJobItem> SewingTableList;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal DataGridView \u0001;
  public static byte f0013B9;
  public FormProperties Properties;
  public static List<string> Captions;
  public double MoveDis;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_yminus;
  public Button btn_xminus;
  internal NumericUpDown \u0001;
  public Button btn_yplus;
  public Button btn_xplus;
  public Button btn_anglePlus;
  public Button btn_angleMinus;
  public static byte f0013C8;
  public FormProperties Properties;
  public static List<string> Captions;
  public int StitchCount;
  public SewingAddStitchType ExtendType;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Panel \u0001;
  internal Label \u0002;
  public static byte f0013D7;
  public FormProperties Properties;
  public static List<string> Captions;
  public double PunterizWidth;
  public double PunterizHeight;
  public double PunterizLength;
  public SewingPunterizType PunterizType;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0002;
  internal NumericUpDown \u0003;
  internal Label \u0003;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal Panel \u0001;
  internal Label \u0004;
  public static byte f0013EE;
  public FormProperties Properties;
  public static List<string> Captions;
  public double StitchLength;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  public static byte f0013F8;
  public FormProperties Properties;
  public static List<string> Captions;
  public List<string> ActualCommands;
  public List<string> AllCommands;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ListBox \u0001;
  internal ListBox \u0002;
  internal Button \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Button \u0002;
  public static byte f001407;
  public static List<string> Captions;
  public FormProperties Properties;
  public List<RollerBendMove> Moves;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal DataGridView \u0001;
  public static byte f001412;
  public static List<string> Captions;
  public FormProperties Properties;
  public double Width;
  public double Height;
  public double Radius;
  public double Length;
  public double Thickness;
  public bool isHorizontal;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buSpin spn_radius;
  public buSpin spn_length;
  public buSpin spn_thickness;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_hegiht;
  public buSpin spn_width;
  public static List<string> Captions;
  public FormProperties Properties;
  public ShapeTypes ShapeType;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buButton btn_rect2edge;
  public buButton btn_halfcircle;
  public buButton btn_rect3edge;
  public buButton btn_ellipse;
  public buButton btn_triangle;
  public buButton btn_slot;
  public buButton btn_rect;
  public buButton btn_circle;
  public static List<string> Captions;
  public FormProperties Properties;
  public double Diameter;
  public double Length;
  public double Thickness;
  public bool isHorizontal;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buSpin spn_diameter;
  public buSpin spn_length;
  public buSpin spn_thickness;
  public buButton btn_ok;
  public buButton btn_cancel;
  public FormProperties Properties;
  public static List<string> Captions;
  public ProfileSettings varSettings;
  internal List<cParameter5> \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal TabPage \u0003;
  internal TabPage \u0004;
  internal TabPage \u0005;
  internal TabPage \u0006;
  internal Label \u0001;
  public NumericUpDown spn_MaterialTranspancy;
  public NumericUpDown spn_EachLayerSafeDistance;
  public NumericUpDown spn_AutoPeckingUpDefaultDistance;
  public NumericUpDown spn_EachLayerAreaDevideCount;
  public NumericUpDown spn_EachLayerMaxThickness;
  public NumericUpDown spn_EachLayerMinThickness;
  internal Label \u0002;
  public NumericUpDown spn_ProfileMaxClamper;
  internal Label \u0003;
  public NumericUpDown numericUpDown2;
  internal Label \u0004;
  public NumericUpDown spn_CutQuality;
  internal Label \u0005;
  public NumericUpDown spn_MinXMove;
  internal Label \u0006;
  internal Label \u0007;
  public Label lbl_EachLayerSafeDistance;
  public Label lbl_AutoPeckingUpDefaultDistance;
  public Label lbl_AutoPeckingAddDefault;
  public Label lbl_EachLayerConnectGap;
  public Label lbl_EachLayerAreaDevideCount;
  public Label lbl_EachLayerMaxThickness;
  public Label lbl_EachLayerMinThickness;
  public CheckBox chk_EachLayerFromArea;
  public Button btn_SupportBlockZColor;
  public Button btn_ProfileColor;
  public CheckBox chk_FindToolAuto;
  public Label lbl_FindToolAuto;
  public CheckBox chk_FindToolAutoFromDepth;
  public Label lbl_FindToolAutoFromDepth;
  internal Label \u0008;
  public NumericUpDown spn_MaxAMove;
  internal Label \u000E;
  public NumericUpDown spn_MaxZMove;
  internal Label \u000F;
  public NumericUpDown spn_MaxYMove;
  internal Label \u0010;
  public NumericUpDown spn_MaxXMove;
  internal Label \u0011;
  public NumericUpDown spn_MinAMove;
  internal Label \u0012;
  public NumericUpDown spn_MinZMove;
  internal Label \u0013;
  public NumericUpDown spn_MinYMove;
  internal TabPage \u0007;
  public CheckBox chk_ShowToolChangeInSimulation;
  public Label lbl_ShowToolChangeInSimulation;
  public Label lbl_ToolChangeX;
  public NumericUpDown spn_ToolChangeX;
  public Label lbl_ToolChangeA;
  public NumericUpDown spn_ToolChangeA;
  public Label lbl_ToolChangeZ;
  public NumericUpDown spn_ToolChangeZ;
  public Label lbl_ToolChangeY;
  public NumericUpDown spn_ToolChangeY;
  internal Label \u0014;
  public NumericUpDown spn_NotchToolNo;
  internal Label \u0015;
  public NumericUpDown spn_ToolPensDiameter;
  internal Label \u0016;
  public NumericUpDown spn_ToolHolderLength;
  internal Label \u0017;
  public NumericUpDown spn_MachineLength;
  internal Label \u0018;
  internal Label \u0019;
  public NumericUpDown spn_ProfileSizeExceedDepthLimit;
  internal Label \u001A;
  internal Label \u001B;
  internal Label \u001C;
  public NumericUpDown spn_MinProfileFilterLength;
  internal Label \u001D;
  public NumericUpDown spn_ProfileSortResolution;
  internal Label \u001E;
  public NumericUpDown spn_GapConnectionForProfile;
  internal Label \u001F;
  internal Label \u007F;
  internal Label \u0080;
  internal Label \u0081;
  public NumericUpDown spn_FirstPositionOffset;
  internal Label \u0082;
  public NumericUpDown spn_ParkPositionZ;
  internal Label \u0083;
  public NumericUpDown spn_ParkPositionY;
  internal Label \u0084;
  public NumericUpDown spn_ParkPositionX;
  internal Label \u0086;
  internal Label \u0087;
  internal Label \u0088;
  internal Label \u0089;
  internal Label \u008A;
  internal Label \u008B;
  internal Label \u008C;
  internal Label \u008D;
  internal Label \u008E;
  public NumericUpDown spn_SimilasyonClamperOpenDistance;
  internal Label \u008F;
  internal Label \u0090;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_moveup.Name && this.\u0001.SelectedIndex >= 1 & this.\u0001.SelectedIndex <= this.Codes.Count - 1)
    {
      SewingCode sewingCode = (SewingCode) new Rectangle2D(this.Codes[this.\u0001.SelectedIndex]);
      this.Codes.RemoveAt(this.\u0001.SelectedIndex);
      this.Codes.Insert(this.\u0001.SelectedIndex - 1, sewingCode);
      ((F_RollerCircle) this).FillCodes();
    }
    if (control2.Name == this.btn_movedown.Name && this.\u0001.SelectedIndex >= 0 & this.\u0001.SelectedIndex <= this.Codes.Count - 2)
    {
      SewingCode sewingCode = (SewingCode) new Rectangle2D(this.Codes[this.\u0001.SelectedIndex]);
      this.Codes.RemoveAt(this.\u0001.SelectedIndex);
      this.Codes.Insert(this.\u0001.SelectedIndex + 1, sewingCode);
      ((F_RollerCircle) this).FillCodes();
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
      \u0007.\u0001.\u0001((F_SewingCodes) this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_clear.Name)
    {
      this.Codes.Clear();
      ((F_RollerCircle) this).FillCodes();
    }
    if (control2.Name == this.btn_delete.Name && this.\u0001.SelectedIndex >= 0 & this.\u0001.SelectedIndex <= this.Codes.Count - 1)
    {
      this.Codes.RemoveAt(this.\u0001.SelectedIndex);
      ((F_RollerCircle) this).FillCodes();
    }
    if (!(control2.Name == this.btn_addcodes.Name) || !(this.\u0002.SelectedIndex >= 0 & this.\u0002.SelectedIndex <= this.CodesDefined.Count - 1))
      return;
    this.Codes.Add((SewingCode) new Rectangle2D(this.CodesDefined[this.\u0002.SelectedIndex]));
    ((F_RollerCircle) this).FillCodes();
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    this.\u0001.Value = (Decimal) Convert.ToInt32((object) ((DimensionInfo) this.CodesDefined[this.\u0002.SelectedIndex]).Codes);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_Settnigs() => \u0007.\u0001.\u0001((F_SewingSpeed) this);
}
