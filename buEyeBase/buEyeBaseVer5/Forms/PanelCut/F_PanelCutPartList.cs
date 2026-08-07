// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.PanelCut.F_PanelCutPartList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.MortiseTenon;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.PanelCut;

public class F_PanelCutPartList : Form
{
  internal Label \u0016;
  internal Label \u0017;
  internal Panel \u0010;
  public NumericUpDown spn_supportblocky2W;
  public NumericUpDown spn_supportblockzW;
  public NumericUpDown spn_supportblocky1W;
  public NumericUpDown spn_supportblocky2H;
  public NumericUpDown spn_supportblockzH;
  public NumericUpDown spn_supportblocky1H;
  public NumericUpDown spn_rightangle;
  public NumericUpDown spn_leftangle;
  public RadioButton radio_rightholder;
  public RadioButton radio_leftholder;
  internal Label \u0018;
  internal NumericUpDown \u000E;
  public CheckBox chk_multilymirror;
  public NumericUpDown spn_multiplyspace;
  public Label lbl_multiplyspace;
  public NumericUpDown spn_multiplycount;
  public Label lbl_multiplycount;
  public CheckBox chk_multiplyprofile;
  public static byte f0017F6;
  public F_NewProfile FrmNewProfile;
  public FormProperties PropertiesForm;
  public List<buEntity> EntitiesTransformed;
  public List<LayerBase5> Layers;
  public List<MaterialSkin> Materials;
  public int MaterialIndex;
  public bool RigthProfile;
  public bool BoxProfile;
  public ProfileItem Profile;
  public ProfileSettings ProfileSet;
  public ProfileRuntimeSettings ProfileRunTimeSet;
  public string strDelete;
  internal Design \u0001;
  private List<string> \u0001;
  private int \u0001;
  private int \u0002;
  private string \u0001;
  internal Point3D \u0001;
  internal Point3D \u0002;
  internal Point3D \u0003;
  internal List<string> \u0002;
  private Timer \u0001;
  private ProfileItem \u0001;
  internal IContainer \u0001;
  internal TextBox \u0001;
  internal Label \u0001;
  internal Panel \u0001;
  internal Label \u0002;
  internal Panel \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Panel \u0003;
  internal Label \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal NumericUpDown \u0001;
  internal Button \u0008;
  internal Label \u0004;
  internal ComboBox \u0001;
  internal Label \u0005;
  internal ComboBox \u0002;
  internal Label \u0006;
  internal TextBox \u0002;
  internal Label \u0007;
  internal Label \u0008;
  internal Label \u000E;
  internal TextBox \u0003;
  internal NumericUpDown \u0002;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NewProfile) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NewProfile) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_PanelCutPartList() => F_NewProfile.Captions = new List<string>();

  public F_PanelCutPartList()
  {
    ((F_NewProfile) this).Properties = new FormProperties();
    ((F_NewProfile) this).MirrorData = (ProfileMirror) new MarbleImageSettings();
    ((F_NewProfile) this).YDirectionFrontBack = false;
    ((F_NewProfile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ProfileMirror) this);
  }

  public void Init()
  {
    ((F_NewProfile) this).Properties.Inited = false;
    if (((F_NewProfile) this).Properties.Height > 10)
      this.Height = ((F_NewProfile) this).Properties.Height;
    if (((F_NewProfile) this).Properties.Width > 10)
      this.Width = ((F_NewProfile) this).Properties.Width;
    this.TopMost = ((F_NewProfile) this).Properties.TopMost;
    this.StartPosition = ((F_NewProfile) this).Properties.FormPosition;
    ((F_NewProfile) this).\u0001.Checked = ((F_NewProfile) this).YDirectionFrontBack;
    ((F_NewProfile) this).spn_dis.Value = (Decimal) ((MarbleRuntimeSettings) ((F_NewProfile) this).MirrorData).MirrorDistance;
    if (((MarbleRuntimeSettings) ((F_NewProfile) this).MirrorData).MirrorAxis == MirrorAxisXYType.X)
    {
      ((F_NewProfile) this).\u0004.Checked = true;
      ((F_NewProfile) this).\u0005.Checked = false;
    }
    else
    {
      ((F_NewProfile) this).\u0004.Checked = false;
      ((F_NewProfile) this).\u0005.Checked = true;
    }
    if (((MarbleRuntimeSettings) ((F_NewProfile) this).MirrorData).MirrorLocation == MinCenterMaxType.Min)
    {
      ((F_NewProfile) this).\u0002.Checked = true;
      ((F_NewProfile) this).\u0003.Checked = false;
      ((F_NewProfile) this).\u0001.Checked = false;
    }
    else if (((MarbleRuntimeSettings) ((F_NewProfile) this).MirrorData).MirrorLocation == MinCenterMaxType.Center)
    {
      ((F_NewProfile) this).\u0002.Checked = false;
      ((F_NewProfile) this).\u0003.Checked = true;
      ((F_NewProfile) this).\u0001.Checked = false;
    }
    else if (((MarbleRuntimeSettings) ((F_NewProfile) this).MirrorData).MirrorLocation == MinCenterMaxType.Max)
    {
      ((F_NewProfile) this).\u0002.Checked = false;
      ((F_NewProfile) this).\u0003.Checked = false;
      ((F_NewProfile) this).\u0001.Checked = true;
    }
    if (((MarbleRuntimeSettings) ((F_NewProfile) this).MirrorData).Mode == MirrorModeType.FromCenter)
    {
      ((F_NewProfile) this).\u0006.Checked = true;
      ((F_NewProfile) this).\u0007.Checked = false;
      ((F_NewProfile) this).\u0003.Enabled = false;
    }
    else
    {
      ((F_NewProfile) this).\u0006.Checked = false;
      ((F_NewProfile) this).\u0007.Checked = true;
      ((F_NewProfile) this).\u0003.Enabled = true;
    }
    ((F_NewProfile) this).Properties.Result = DialogResult.None;
    ((F_NewProfile) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_NewProfile.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NewProfile) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NewProfile) this).Properties.Result = DialogResult.Cancel;
    if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NewProfile) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_NewProfile) this).btn_ok.Name)
    {
      if (!((F_NewProfile) this).Properties.Inited)
        return;
      if (((F_NewProfile) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_ProfileMirror) this);
      ((F_NewProfile) this).Properties.Result = DialogResult.OK;
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_NewProfile) this).btn_cancel.Name))
      return;
    ((F_NewProfile) this).Properties.Result = DialogResult.Cancel;
    if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NewProfile) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_NewProfile) this).\u0006.Checked)
      ((F_NewProfile) this).\u0003.Enabled = false;
    else
      ((F_NewProfile) this).\u0003.Enabled = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NewProfile) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NewProfile) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_PanelCutPartList() => F_NewProfile.Captions = new List<string>();

  public F_PanelCutPartList()
  {
    ((F_NewProfile) this).Properties = new FormProperties();
    ((F_NewProfile) this).OperationData = (ProfileOperationData) new buMarbleCalc();
    ((F_NewProfile) this).selectedPlanes = new List<SelectedPlaneInfo>();
    ((F_NewProfile) this).Profile = (ProfileItem) new PanelCutRuntimeSettings();
    ((F_NewProfile) this).ShowCount = true;
    ((F_NewProfile) this).UseOriginalPlane = false;
    ((F_NewProfile) this).Count = 1;
    ((F_NewProfile) this).DistanceHor = 0.0;
    ((F_NewProfile) this).DistanceVer = 0.0;
    ((F_NewProfile) this).UseDistance = false;
    ((F_NewProfile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ProfileCopy) this);
  }

  public void Init()
  {
    ((F_NewProfile) this).Properties.Inited = false;
    if (((F_NewProfile) this).Properties.Height > 10)
      this.Height = ((F_NewProfile) this).Properties.Height;
    if (((F_NewProfile) this).Properties.Width > 10)
      this.Width = ((F_NewProfile) this).Properties.Width;
    this.TopMost = ((F_NewProfile) this).Properties.TopMost;
    this.StartPosition = ((F_NewProfile) this).Properties.FormPosition;
    if (((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Bottom | ((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Free)
    {
      ((F_NewProfile) this).spn_x.Value = (Decimal) ((ProfileOnlineOpOptions) ((F_NewProfile) this).OperationData).basePosition.X;
      ((F_NewProfile) this).spn_y.Value = Math.Abs((Decimal) ((ProfileOnlineOpOptions) ((F_NewProfile) this).OperationData).basePosition.Y);
    }
    else
    {
      ((F_NewProfile) this).spn_x.Value = (Decimal) ((ProfileOnlineOpOptions) ((F_NewProfile) this).OperationData).basePosition.X;
      ((F_NewProfile) this).spn_y.Value = Math.Abs((Decimal) ((ProfileOnlineOpOptions) ((F_NewProfile) this).OperationData).basePosition.Z);
    }
    ((F_ProfileAdd) this).spn_count.Value = (Decimal) ((F_NewProfile) this).Count;
    ((F_ProfileAdd) this).spn_distancehor.Value = (Decimal) ((F_NewProfile) this).DistanceHor;
    ((F_ProfileAdd) this).spn_distancever.Value = (Decimal) ((F_NewProfile) this).DistanceVer;
    if (((F_NewProfile) this).UseDistance)
    {
      ((F_ProfileAdd) this).\u0001.Checked = true;
      ((F_ProfileAdd) this).\u0002.Checked = false;
    }
    else
    {
      ((F_ProfileAdd) this).\u0001.Checked = false;
      ((F_ProfileAdd) this).\u0002.Checked = true;
    }
    ((F_ProfileAdd) this).btn_planetop.BackColor = Color.Gainsboro;
    ((F_ProfileAdd) this).btn_planebottom.BackColor = Color.Gainsboro;
    ((F_ProfileAdd) this).btn_planeback.BackColor = Color.Gainsboro;
    ((F_ProfileAdd) this).btn_planefront.BackColor = Color.Gainsboro;
    ((F_ProfileAdd) this).btn_planefree.BackColor = Color.Gainsboro;
    ((F_ProfileAdd) this).lbl_count.Visible = ((F_NewProfile) this).ShowCount;
    ((F_ProfileAdd) this).spn_count.Visible = ((F_NewProfile) this).ShowCount;
    if (((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Top)
      ((F_ProfileAdd) this).btn_planetop.BackColor = Color.Gold;
    if (((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Bottom)
      ((F_ProfileAdd) this).btn_planebottom.BackColor = Color.Gold;
    if (((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Front)
      ((F_ProfileAdd) this).btn_planefront.BackColor = Color.Gold;
    if (((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Back)
      ((F_ProfileAdd) this).btn_planeback.BackColor = Color.Gold;
    if (((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Free)
      ((F_ProfileAdd) this).btn_planefree.BackColor = Color.Gold;
    ((F_ProfileAdd) this).\u0001.Checked = ((F_NewProfile) this).UseOriginalPlane;
    ((F_NewProfile) this).Properties.Result = DialogResult.None;
    ((F_NewProfile) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NewProfile) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NewProfile) this).Properties.Result = DialogResult.Cancel;
    if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NewProfile) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_NewProfile) this).btn_ok.Name)
    {
      if (!((F_NewProfile) this).Properties.Inited)
        return;
      if (((F_NewProfile) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_ProfileCopy) this);
      if (((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName == planeNames.Bottom)
        ((ProfilePatternCopy) ((F_NewProfile) this).OperationData).Position.Y = -Math.Abs(((ProfilePatternCopy) ((F_NewProfile) this).OperationData).Position.Y);
      ((F_NewProfile) this).Properties.Result = DialogResult.OK;
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_NewProfile) this).btn_cancel.Name)
    {
      ((F_NewProfile) this).Properties.Result = DialogResult.Cancel;
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_ProfileAdd) this).btn_planetop.Name | control2.Name == ((F_ProfileAdd) this).btn_planebottom.Name | control2.Name == ((F_ProfileAdd) this).btn_planeback.Name | control2.Name == ((F_ProfileAdd) this).btn_planefront.Name | control2.Name == ((F_ProfileAdd) this).btn_planefree.Name)
    {
      ((F_ProfileAdd) this).btn_planetop.BackColor = Color.Gainsboro;
      ((F_ProfileAdd) this).btn_planebottom.BackColor = Color.Gainsboro;
      ((F_ProfileAdd) this).btn_planeback.BackColor = Color.Gainsboro;
      ((F_ProfileAdd) this).btn_planefront.BackColor = Color.Gainsboro;
      ((F_ProfileAdd) this).btn_planefree.BackColor = Color.Gainsboro;
    }
    if (control2.Name == ((F_ProfileAdd) this).btn_planetop.Name)
    {
      ((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName = planeNames.Top;
      ((F_ProfileAdd) this).btn_planetop.BackColor = Color.Gold;
    }
    if (control2.Name == ((F_ProfileAdd) this).btn_planebottom.Name)
    {
      ((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName = planeNames.Bottom;
      ((F_ProfileAdd) this).btn_planebottom.BackColor = Color.Gold;
    }
    if (control2.Name == ((F_ProfileAdd) this).btn_planeback.Name)
    {
      ((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName = planeNames.Back;
      ((F_ProfileAdd) this).btn_planeback.BackColor = Color.Gold;
    }
    if (control2.Name == ((F_ProfileAdd) this).btn_planefront.Name)
    {
      ((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName = planeNames.Front;
      ((F_ProfileAdd) this).btn_planefront.BackColor = Color.Gold;
    }
    if (control2.Name == ((F_ProfileAdd) this).btn_planefree.Name)
    {
      ((ProfileMirror) ((F_NewProfile) this).OperationData).selectedPlaneName = planeNames.Free;
      ((F_ProfileAdd) this).btn_planefree.BackColor = Color.Gold;
    }
    if (!(control2.Name == ((F_ProfileAdd) this).btn_planeselect.Name))
      return;
    F_SelectedPlanes fSelectedPlanes = (F_SelectedPlanes) new F_SlotNoDepth();
    for (int index = 0; index <= ((F_NewProfile) this).selectedPlanes.Count - 1; ++index)
      ((F_ProfileAdd) fSelectedPlanes).Planes.Add((SelectedPlaneInfo) new hmiUISettings(((F_NewProfile) this).selectedPlanes[index]));
    for (int index = 0; index <= ((ProfileSettings) ((F_NewProfile) this).Profile).Drawings.Count - 1; ++index)
    {
      // ISSUE: reference to a compiler-generated field
      if (((buMarbleCalc.\u0001) ((ProfileSettings) ((F_NewProfile) this).Profile).Drawings[index]).SolidEntity != null)
      {
        // ISSUE: reference to a compiler-generated field
        Entity entity = buVector5.CopyEntities(((buMarbleCalc.\u0001) ((ProfileSettings) ((F_NewProfile) this).Profile).Drawings[index]).SolidEntity);
        entity.ColorMethod = colorMethodType.byEntity;
        entity.Color = Color.FromArgb(180, ((ProfileSettings) ((F_NewProfile) this).Profile).colorProfile);
        entity.LayerName = "Default";
        ((F_ProfileAdd) fSelectedPlanes).PreviewEnts.Add(entity);
      }
    }
    if (((ProfileSettings) ((F_NewProfile) this).Profile).Operations.Count > 0)
    {
      for (int index1 = 0; index1 <= ((ProfileSettings) ((F_NewProfile) this).Profile).Operations.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((ProfileRuntimeSettings) ((ProfileSettings) ((F_NewProfile) this).Profile).Operations[index1]).EntityMultiSolidDepth.Count - 1; ++index2)
        {
          Entity copiedEnt = (Entity) null;
          buVector5.CopyEntities(((ProfileRuntimeSettings) ((ProfileSettings) ((F_NewProfile) this).Profile).Operations[index1]).EntityMultiSolidDepth[index2], ref copiedEnt);
          copiedEnt.ColorMethod = colorMethodType.byEntity;
          copiedEnt.Color = Color.Cyan;
          copiedEnt.LayerName = "Default";
          ((F_ProfileAdd) fSelectedPlanes).PreviewEnts.Add(copiedEnt);
        }
      }
    }
    ((F_SlotNoDepth) fSelectedPlanes).Init();
    fSelectedPlanes.TopMost = true;
    int num = (int) fSelectedPlanes.ShowDialog();
    if (((F_ProfileAdd) fSelectedPlanes).PropertiesForm.Result != DialogResult.OK)
      return;
    ((F_NewProfile) this).selectedPlanes.Clear();
    ((F_NewProfile) this).selectedPlanes = new List<SelectedPlaneInfo>();
    for (int index = 0; index <= ((F_ProfileAdd) fSelectedPlanes).Planes.Count - 1; ++index)
      ((F_NewProfile) this).selectedPlanes.Add((SelectedPlaneInfo) new hmiUISettings(((F_ProfileAdd) fSelectedPlanes).Planes[index]));
    if (((F_ProfileAdd) fSelectedPlanes).Planes.Count <= 0 || ((F_ProfileAdd) fSelectedPlanes).SelectedPlane < 0)
      return;
    SelectedPlaneInfo selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings(((F_ProfileAdd) fSelectedPlanes).Planes[((F_ProfileAdd) fSelectedPlanes).SelectedPlane]);
    ((ProfileSettings) ((F_NewProfile) this).Profile).selectedFreePlanes.Clear();
    ((ProfileSettings) ((F_NewProfile) this).Profile).selectedFreePlanes.Add(selectedPlaneInfo);
    ((ProfilePatternCopy) ((F_NewProfile) this).OperationData).selectedPlane = (Plane) ((WriteDxfDwgPropeties) ((ProfileSettings) ((F_NewProfile) this).Profile).selectedFreePlanes[0]).refPlane.Clone();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NewProfile) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NewProfile) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_PanelCutPartList() => F_NewProfile.Captions = new List<string>();

  public F_PanelCutPartList()
  {
    ((F_ProfileAdd) this).Properties = new FormProperties();
    ((F_ProfileAdd) this).OperationData = (ProfileOperationData) new buMarbleCalc();
    ((F_ProfileAdd) this).CircularArrayVisible = false;
    ((F_ProfileAdd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ProfileArrayCircular) this);
  }
}
