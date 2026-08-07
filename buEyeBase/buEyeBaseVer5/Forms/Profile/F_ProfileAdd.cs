// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfileAdd
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileAdd : Form
{
  public Button btn_planebottom;
  public Button btn_planeselect;
  public Button btn_planefree;
  public Button btn_planeback;
  public Button btn_planefront;
  public Button btn_planetop;
  public Label label7;
  public Label label6;
  public Label label5;
  public Label label3;
  public Label label2;
  internal CheckBox \u0001;
  public Label lbl_count;
  public NumericUpDown spn_count;
  public Label lbl_Distancehor;
  public NumericUpDown spn_distancehor;
  public Label lbl_Distancever;
  public NumericUpDown spn_distancever;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  public static byte f001721;
  public FormProperties Properties;
  public static List<string> Captions;
  public ProfileOperationData OperationData;
  public bool CircularArrayVisible;
  internal IContainer \u0001;
  public CheckBox chk_lineer;
  public Panel panel4;
  public Label label4;
  public Label label5;
  public NumericUpDown spn_linearlen;
  public NumericUpDown spn_linearcount;
  public CheckBox chk_circular;
  public Panel pnl_circular;
  public Label label3;
  public Label label1;
  public NumericUpDown spn_circularangle;
  public NumericUpDown spn_circularcount;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public static byte f001736;
  public FormProperties Properties;
  public static List<string> Captions;
  public ProfileOperationData OperationData;
  public bool CircularArrayVisible;
  internal IContainer \u0001;
  public CheckBox chk_lineer;
  public Panel panel4;
  public Label label4;
  public Label label5;
  public NumericUpDown spn_linearXlen;
  public NumericUpDown spn_linearXcount;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Label label6;
  public Label label3;
  public Label label1;
  public NumericUpDown spn_linearYlen;
  public Label label2;
  public NumericUpDown spn_linearYcount;
  public static byte f00174B;
  public FormProperties Properties;
  public static List<string> Captions;
  public ProfilePatternCopy Pattern;
  public bool ShowSeperators;
  internal IContainer \u0001;
  public Label label4;
  public Label label5;
  public NumericUpDown spn_distance;
  public NumericUpDown spn_count;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Label label1;
  public NumericUpDown spn_cutspace;
  public Label label2;
  internal CheckBox \u0001;
  public static byte f00175C;
  public FormProperties PropertiesForm;
  public SelectedPlaneInfo Plane;
  public Point3D pntMinProfile;
  public Point3D pntMaxProfile;
  public UCSObjectData VarUcs;
  public double PlaneThinkness;
  private IContainer \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal Button \u0006;
  public FormProperties PropertiesForm;
  public List<Entity> PreviewEnts;
  public List<SelectedPlaneInfo> Planes;
  public UCSObjectData UcsData;
  public double PlaneThickess;
  public int SelectedPlane;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfileClamperSet) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfileClamperSet) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ProfileAdd() => F_PlaneMoveRotate.Captions = new List<string>();

  public F_ProfileAdd()
  {
    ((F_ProfileMirror) this).Properties = new FormProperties();
    ((F_ProfileMirror) this).VarSettings = (ProfileSettings) null;
    ((F_ProfileMirror) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_OperationSettings) this);
  }

  public void Init()
  {
    ((F_ProfileMirror) this).Properties.Inited = false;
    if (((F_ProfileMirror) this).Properties.Height > 10)
      this.Height = ((F_ProfileMirror) this).Properties.Height;
    if (((F_ProfileMirror) this).Properties.Width > 10)
      this.Width = ((F_ProfileMirror) this).Properties.Width;
    this.TopMost = ((F_ProfileMirror) this).Properties.TopMost;
    this.StartPosition = ((F_ProfileMirror) this).Properties.FormPosition;
    if (((MarbleItemSettings) ((F_ProfileMirror) this).VarSettings).XDirRefType == LeftRightType.Left)
    {
      ((F_ProfileCopy) this).\u0004.Checked = true;
      ((F_ProfileCopy) this).\u0003.Checked = false;
    }
    else
    {
      ((F_ProfileCopy) this).\u0004.Checked = false;
      ((F_ProfileCopy) this).\u0003.Checked = true;
    }
    ((F_ProfileMirror) this).Properties.Result = DialogResult.None;
    ((F_ProfileMirror) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_ProfileMirror.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ProfileMirror) this).btn_ok.Name)
    {
      if (!((F_ProfileMirror) this).Properties.Inited)
        return;
      if (((F_ProfileMirror) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_OperationSettings) this);
      ((F_ProfileMirror) this).Properties.Result = DialogResult.OK;
      if (((F_ProfileMirror) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileMirror) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_ProfileMirror) this).btn_cancel.Name))
      return;
    ((F_ProfileMirror) this).Properties.Result = DialogResult.Cancel;
    if (((F_ProfileMirror) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfileMirror) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfileMirror) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfileMirror) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ProfileAdd() => F_ProfileMirror.Captions = new List<string>();

  public F_ProfileAdd()
  {
    ((F_ProfileCopy) this).Properties = new FormProperties();
    ((F_ProfileCopy) this).CamPar = new camParameters5();
    ((F_ProfileCopy) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_CamSettings) this);
  }

  public void Init()
  {
    ((F_ProfileCopy) this).Properties.Inited = false;
    if (((F_ProfileCopy) this).Properties.Height > 10)
      this.Height = ((F_ProfileCopy) this).Properties.Height;
    if (((F_ProfileCopy) this).Properties.Width > 10)
      this.Width = ((F_ProfileCopy) this).Properties.Width;
    this.TopMost = ((F_ProfileCopy) this).Properties.TopMost;
    this.StartPosition = ((F_ProfileCopy) this).Properties.FormPosition;
    ((F_ProfileArray) this).spn_spindlespeed.Value = (Decimal) ((buEyeBaseVer5.camSpeedsEnable) ((F_ProfileCopy) this).CamPar.Speeds).SpindleSpeed;
    ((F_ProfileCopy) this).spn_vellfeed.Value = (Decimal) ((F_ProfileCopy) this).CamPar.Speeds.Feed;
    ((F_ProfileCopy) this).spn_velplunge.Value = (Decimal) ((F_ProfileCopy) this).CamPar.Speeds.Plunge;
    ((F_ProfileCopy) this).spn_finishvelocity.Value = (Decimal) ((buEyeBaseVer5.camSpeedsEnable) ((F_ProfileCopy) this).CamPar.Speeds).Finish;
    ((F_ProfileCopy) this).spn_areaclearancevelocity.Value = (Decimal) ((camDistances5) ((F_ProfileCopy) this).CamPar.Speeds).AreaClearance;
    ((F_ProfileArray) this).spn_disapproach.Value = (Decimal) ((F_ProfileCopy) this).CamPar.Distances.FirstApproach;
    ((F_ProfileArray) this).spn_dissafe.Value = (Decimal) ((F_ProfileCopy) this).CamPar.Distances.Safe;
    ((F_ProfileArray) this).spn_dissmallsafe.Value = (Decimal) ((camMaterial5) ((F_ProfileCopy) this).CamPar.Distances).Rapid;
    ((F_ProfileArray) this).spn_finishoffset.Value = (Decimal) ((camStep5) ((F_ProfileCopy) this).CamPar.Offsets).FinishOffset;
    ((F_ProfilePatternCopy) this).spn_depthup.Value = (Decimal) ((F_ProfileCopy) this).CamPar.Operations.DepthUp;
    ((F_ProfileCopy) this).spn_stepstep.Value = (Decimal) ((camSpeeds5) ((F_ProfileCopy) this).CamPar.Steps).Step;
    ((F_ProfileCopy) this).spn_stepcount.Value = (Decimal) ((camSpeeds5) ((F_ProfileCopy) this).CamPar.Steps).Count;
    ((F_ProfileCopy) this).\u0001.Value = (Decimal) ((camOperation5) ((F_ProfileCopy) this).CamPar.Pockets).StepOverPersentage;
    ((F_ProfileArrayCircular) this).\u0002.Checked = ((F_ProfileCopy) this).CamPar.Operations.AreaClearanceEnable;
    ((F_ProfileArrayCircular) this).\u0003.Checked = ((F_ProfileCopy) this).CamPar.Operations.FinishEnable;
    ((F_ProfileArrayCircular) this).\u0001.Checked = ((F_ProfileCopy) this).CamPar.Steps.Enable;
    ((F_ProfileArray) this).\u0004.Checked = ((F_ProfileCopy) this).CamPar.Strategy.OpenContourTwoDirectionCut;
    ((F_ProfileArrayCircular) this).\u0003.Checked = ((buEyeBaseVer5.camSpeedsEnable) ((F_ProfileCopy) this).CamPar.Speeds).FinishEnable;
    ((F_ProfileArrayCircular) this).\u0002.Checked = ((camDistances5) ((F_ProfileCopy) this).CamPar.Speeds).AreaClearanceEnable;
    ((F_ProfileArray) this).\u0006.Checked = ((MWCalculationOptions) ((camRuntime5) ((F_ProfileCopy) this).CamPar).LeadIn).Enable;
    ((F_ProfileArray) this).\u0005.Checked = ((MWCalculationOptions) ((camOffset5) ((F_ProfileCopy) this).CamPar).LeadOut).Enable;
    ((F_ProfilePatternCopy) this).spn_overlap.Value = (Decimal) ((F_ProfileCopy) this).CamPar.Operations.Overlap;
    if (((camOperation5) ((F_ProfileCopy) this).CamPar.Pockets).PocketType == CamPocketType.WfbRghtOffset)
    {
      ((F_ProfilePatternCopy) this).\u0010.Checked = false;
      ((F_ProfilePatternCopy) this).\u0012.Checked = true;
      ((F_ProfilePatternCopy) this).\u0011.Checked = false;
    }
    else if (((camOperation5) ((F_ProfileCopy) this).CamPar.Pockets).PocketType == CamPocketType.WfbRghtParallel)
    {
      ((F_ProfilePatternCopy) this).\u0010.Checked = false;
      ((F_ProfilePatternCopy) this).\u0012.Checked = false;
      ((F_ProfilePatternCopy) this).\u0011.Checked = true;
    }
    else
    {
      ((F_ProfilePatternCopy) this).\u0010.Checked = true;
      ((F_ProfilePatternCopy) this).\u0012.Checked = false;
      ((F_ProfilePatternCopy) this).\u0011.Checked = false;
    }
    if (((camOptions5) ((F_ProfileCopy) this).CamPar.Operations).AreaClearanceDirection == InToOutType.OutToIn)
    {
      ((F_ProfileCopy) this).\u0001.Checked = true;
      ((F_ProfileCopy) this).\u0002.Checked = false;
    }
    else
    {
      ((F_ProfileCopy) this).\u0001.Checked = false;
      ((F_ProfileCopy) this).\u0002.Checked = true;
    }
    if (((camOptions5) ((F_ProfileCopy) this).CamPar.Operations).Direction == ClockDirectionType.CW)
    {
      ((F_ProfileArrayCircular) this).\u0004.Checked = true;
      ((F_ProfileArrayCircular) this).\u0003.Checked = false;
    }
    if (((camOptions5) ((F_ProfileCopy) this).CamPar.Operations).Direction == ClockDirectionType.CCW)
    {
      ((F_ProfileArrayCircular) this).\u0004.Checked = false;
      ((F_ProfileArrayCircular) this).\u0003.Checked = true;
    }
    if (((camStep5) ((F_ProfileCopy) this).CamPar.Offsets).ClosedContour == CamClosedContourType.Inner)
    {
      ((F_ProfileArrayCircular) this).\u0006.Checked = false;
      ((F_ProfileArrayCircular) this).\u0005.Checked = false;
      ((F_ProfileArrayCircular) this).\u0007.Checked = true;
    }
    if (((camStep5) ((F_ProfileCopy) this).CamPar.Offsets).ClosedContour == CamClosedContourType.Outter)
    {
      ((F_ProfileArrayCircular) this).\u0006.Checked = false;
      ((F_ProfileArrayCircular) this).\u0005.Checked = true;
      ((F_ProfileArrayCircular) this).\u0007.Checked = false;
    }
    if (((camStep5) ((F_ProfileCopy) this).CamPar.Offsets).ClosedContour == CamClosedContourType.Center)
    {
      ((F_ProfileArrayCircular) this).\u0006.Checked = true;
      ((F_ProfileArrayCircular) this).\u0005.Checked = false;
      ((F_ProfileArrayCircular) this).\u0007.Checked = false;
    }
    if (((camStep5) ((F_ProfileCopy) this).CamPar.Offsets).OpenContour == CamOpenContourType.Center)
    {
      ((F_ProfileArrayCircular) this).\u000E.Checked = true;
      ((F_ProfileArrayCircular) this).\u000F.Checked = false;
      ((F_ProfileArrayCircular) this).\u0008.Checked = false;
    }
    else if (((camStep5) ((F_ProfileCopy) this).CamPar.Offsets).OpenContour == CamOpenContourType.Left)
    {
      ((F_ProfileArrayCircular) this).\u000E.Checked = false;
      ((F_ProfileArrayCircular) this).\u000F.Checked = true;
      ((F_ProfileArrayCircular) this).\u0008.Checked = false;
    }
    else
    {
      ((F_ProfileArrayCircular) this).\u000E.Checked = false;
      ((F_ProfileArrayCircular) this).\u000F.Checked = false;
      ((F_ProfileArrayCircular) this).\u0008.Checked = true;
    }
    ((F_ProfileCopy) this).Properties.Result = DialogResult.None;
    ((F_ProfileCopy) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_ProfileCopy.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ProfileCopy) this).btn_ok.Name)
    {
      if (!((F_ProfileCopy) this).Properties.Inited)
        return;
      if (((F_ProfileCopy) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_CamSettings) this);
      ((F_ProfileCopy) this).Properties.Result = DialogResult.OK;
      if (((F_ProfileCopy) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileCopy) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_ProfileCopy) this).btn_cancel.Name))
      return;
    ((F_ProfileCopy) this).Properties.Result = DialogResult.Cancel;
    if (((F_ProfileCopy) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfileCopy) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfileCopy) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfileCopy) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public event OkCommandWithTwoDataEventHandler EditDxf;
}
