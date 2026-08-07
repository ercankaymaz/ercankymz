// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_NewProfile
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_NewProfile : Form
{
  internal Label \u0002;
  internal Button \u0001;
  internal Button \u0002;
  internal Label \u0003;
  internal Button \u0003;
  internal Label \u0004;
  internal Button \u0004;
  internal ImageList \u0001;
  public FormProperties Properties;
  public static List<string> Captions;
  public int ClamperSet;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Label label1;
  public NumericUpDown spn_priority;
  public static byte f0016CB;
  public FormProperties Properties;
  public static List<string> Captions;
  public int Priority;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Label label1;
  public NumericUpDown spn_priority;
  public static byte f0016D5;
  public FormProperties Properties;
  public static List<string> Captions;
  public ProfileRuntimeSettings RuntimeVar;
  internal IContainer \u0001;
  public Label lbl_Startoffset;
  public NumericUpDown spn_startoffset;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  public static byte f0016E1;
  public FormProperties Properties;
  public static List<string> Captions;
  public ProfileMirror MirrorData;
  public bool YDirectionFrontBack;
  internal IContainer \u0001;
  public Label label4;
  public NumericUpDown spn_dis;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Panel \u0002;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal Panel \u0003;
  public Panel panel4;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal CheckBox \u0001;
  public static byte f0016F8;
  public FormProperties Properties;
  public static List<string> Captions;
  public ProfileOperationData OperationData;
  public List<SelectedPlaneInfo> selectedPlanes;
  public ProfileItem Profile;
  public bool ShowCount;
  public bool UseOriginalPlane;
  public int Count;
  public double DistanceHor;
  public double DistanceVer;
  public bool UseDistance;
  internal IContainer \u0001;
  public Panel panel4;
  public Label label4;
  public NumericUpDown spn_x;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Label label1;
  public NumericUpDown spn_y;

  public void ShapeToDataGrid(int Index)
  {
    bool inited = ((F_PlaneMoveRotate) this).PropertiesForm.Inited;
    ((F_ProfileTemplate) this).dgv_data.Rows.Clear();
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Side)
    {
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001("Z", ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Height, ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchHeight, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchDepth, (F_NotchList) this));
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Length)
    {
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001("X", ((F_ProfileFreeDrawCmd) this).parShape.pntBase.X, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001("Z", ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Width, ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchWidth, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Height, ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchHeight, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchDepth, (F_NotchList) this));
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001("Y", ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchStartHeight, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Height, ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchHeight, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchDepth, (F_NotchList) this));
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Horizontal)
    {
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001("X", ((F_ProfileFreeDrawCmd) this).parShape.pntBase.X, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001("Y", ((F_ProfileFreeDrawCmd) this).parShape.pntBase.Y, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Width, ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchWidth, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Height, ((CustomDataAdd) ((F_ProfileFreeDrawCmd) this).parShape).NotchHeight, (F_NotchList) this));
      ((F_ProfileTemplate) this).dgv_data.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, ((MachineConfigSettings) ((F_ProfileFreeDrawCmd) this).parShape).NotchDepth, (F_NotchList) this));
    }
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchUpDown == UpDownLocationType.Up)
      ((F_ProfileMirror) this).radio_kertmeLup.Checked = true;
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchUpDown == UpDownLocationType.Down)
      ((F_ProfileMirror) this).radio_kertmeLdown.Checked = true;
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchFrontBack == FrontBackType.Front)
      ((F_ProfileMirror) this).radio_front.Checked = true;
    if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchFrontBack == FrontBackType.Back)
      ((F_ProfileMirror) this).radio_back.Checked = true;
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = inited;
  }

  private void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_PlaneMoveRotate) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    ((F_SelectedPlanes) this).DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    // ISSUE: reference to a compiler-generated field
    if (((F_PlaneMoveRotate) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
    if (MarbleItem.OperationEditing & ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).UpdateEditOperationWithoutOk)
      ((ShapeRuntimeData) Data2).Finished = true;
    // ISSUE: reference to a compiler-generated field
    ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
  }

  private void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_PlaneMoveRotate) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0 & ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex != obj1.RowIndex))
      return;
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    ((CreateProfileFromDataOptions) buCall.\u0001).FindNotchDataValueType(((F_ProfileFreeDrawCmd) this).parShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_PlaneMoveRotate) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
    ((ShapeRuntimeData) Data2).Command = "DrawDim";
    ((ShapeRuntimeData) Data2).ValueType = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType;
    // ISSUE: reference to a compiler-generated field
    ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
  }

  private void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_PlaneMoveRotate) this).PropertiesForm.Inited || obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
      ;
  }

  private void \u0004([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_PlaneMoveRotate) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0 & ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex != obj1.RowIndex))
      return;
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    ((CreateProfileFromDataOptions) buCall.\u0001).FindNotchDataValueType(((F_ProfileFreeDrawCmd) this).parShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_PlaneMoveRotate) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
    ((ShapeRuntimeData) Data2).Command = "DrawDim";
    ((ShapeRuntimeData) Data2).ValueType = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType;
    // ISSUE: reference to a compiler-generated field
    ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ProfileMirror) this).radio_kertmeLdown.Name)
    {
      if (((F_ProfileMirror) this).radio_kertmeLdown.Checked)
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchUpDown = UpDownLocationType.Down;
      else
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchUpDown = UpDownLocationType.Up;
      // ISSUE: reference to a compiler-generated field
      if (((F_PlaneMoveRotate) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
        ((ShapeRuntimeData) Data2).Parameters.selectedPlane = planeBoxNames.Top;
        // ISSUE: reference to a compiler-generated field
        ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control.Name == ((F_ProfileMirror) this).radio_kertmeLup.Name)
    {
      if (((F_ProfileMirror) this).radio_kertmeLup.Checked)
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchUpDown = UpDownLocationType.Up;
      else
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchUpDown = UpDownLocationType.Down;
      // ISSUE: reference to a compiler-generated field
      if (((F_PlaneMoveRotate) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
        ((ShapeRuntimeData) Data2).Parameters.selectedPlane = planeBoxNames.Top;
        // ISSUE: reference to a compiler-generated field
        ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control.Name == ((F_ProfileMirror) this).radio_front.Name)
    {
      if (((F_ProfileMirror) this).radio_front.Checked)
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchFrontBack = FrontBackType.Front;
      else
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchFrontBack = FrontBackType.Back;
      // ISSUE: reference to a compiler-generated field
      if (((F_PlaneMoveRotate) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
        ((ShapeRuntimeData) Data2).Parameters.selectedPlane = planeBoxNames.Top;
        // ISSUE: reference to a compiler-generated field
        ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (!(control.Name == ((F_ProfileMirror) this).radio_back.Name))
      return;
    if (((F_ProfileMirror) this).radio_back.Checked)
      ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchFrontBack = FrontBackType.Back;
    else
      ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchFrontBack = FrontBackType.Front;
    // ISSUE: reference to a compiler-generated field
    if (((F_PlaneMoveRotate) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2_1 = (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
    ((ShapeRuntimeData) Data2_1).Parameters.selectedPlane = planeBoxNames.Top;
    // ISSUE: reference to a compiler-generated field
    ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2_1, (object) null);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ProfileTemplate) this).btn_ok.Name)
    {
      ((F_PlaneMoveRotate) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ProfileFreeDrawCmd) this).ClosePageAfterOk)
      {
        if (((F_PlaneMoveRotate) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_PlaneMoveRotate) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_PlaneMoveRotate) this).\u0001 != null)
      {
        ((F_SelectedPlanes) this).DataGridValuesToShape(-1, -1);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
        ((ShapeRuntimeData) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control2.Name == ((F_ProfileTemplate) this).btn_cancel.Name)
    {
      ((F_PlaneMoveRotate) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_PlaneMoveRotate) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_PlaneMoveRotate) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      {
        this.Visible = false;
        if (this.Owner != null)
          this.Owner.Focus();
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_PlaneMoveRotate) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_PlaneMoveRotate) this).\u0001();
      }
    }
    if (control2.Name == ((F_ProfilePriority) this).btn_camsettings.Name)
    {
      F_NotchCamSettings notchCamSettings = (F_NotchCamSettings) new F_ProfilePatternCopy();
      ((F_Clampers) notchCamSettings).CamPar = (camParameters5) new camRuntime5(((F_ProfileFreeDrawCmd) this).parShape.CamPars);
      notchCamSettings.StartPosition = FormStartPosition.CenterScreen;
      ((F_ProfilePatternCopy) notchCamSettings).Init();
      int num = (int) notchCamSettings.ShowDialog();
      // ISSUE: reference to a compiler-generated field
      if (((F_Clampers) notchCamSettings).Properties.Result == DialogResult.OK && ((F_PlaneMoveRotate) this).\u0001 != null)
      {
        ((F_ProfileFreeDrawCmd) this).parShape.CamPars = (camParameters5) new camRuntime5(((F_Clampers) notchCamSettings).CamPar);
        // ISSUE: reference to a compiler-generated field
        ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
      }
      this.Focus();
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_ProfilePriority) this).btn_toolsettings.Name && ((F_PlaneMoveRotate) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_PlaneMoveRotate) this).\u0001((object) "ToolEdit", (object) "");
    }
    if (control2.Name == ((F_ProfileTemplate) this).btn_left.Name)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Side)
      {
        int indexRow = -1;
        int indexCol = -1;
        this.GetRowColIndex(ref indexRow, ref indexCol);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
        ((F_ProfileFreeDrawCmd) this).parShape.selectedPlane = planeBoxNames.Top;
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Left;
        ((F_SelectedPlanes) this).PlaneColorUpdate();
        this.ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
        // ISSUE: reference to a compiler-generated field
        if (((F_PlaneMoveRotate) this).\u0001 != null)
        {
          this.SetRowColIndex(indexRow, indexCol);
          // ISSUE: reference to a compiler-generated field
          ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
        }
      }
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Vertical)
      {
        int indexRow = -1;
        int indexCol = -1;
        this.GetRowColIndex(ref indexRow, ref indexCol);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
        ((F_ProfileFreeDrawCmd) this).parShape.selectedPlane = planeBoxNames.Top;
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Left;
        ((F_SelectedPlanes) this).PlaneColorUpdate();
        this.ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
        // ISSUE: reference to a compiler-generated field
        if (((F_PlaneMoveRotate) this).\u0001 != null)
        {
          this.SetRowColIndex(indexRow, indexCol);
          // ISSUE: reference to a compiler-generated field
          ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
        }
      }
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Horizontal)
      {
        int indexRow = -1;
        int indexCol = -1;
        this.GetRowColIndex(ref indexRow, ref indexCol);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
        ((F_ProfileFreeDrawCmd) this).parShape.selectedPlane = planeBoxNames.Top;
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Left;
        ((F_SelectedPlanes) this).PlaneColorUpdate();
        this.ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
        // ISSUE: reference to a compiler-generated field
        if (((F_PlaneMoveRotate) this).\u0001 != null)
        {
          this.SetRowColIndex(indexRow, indexCol);
          // ISSUE: reference to a compiler-generated field
          ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
        }
      }
    }
    if (control2.Name == ((F_ProfileTemplate) this).btn_right.Name)
    {
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Side)
      {
        int indexRow = -1;
        int indexCol = -1;
        this.GetRowColIndex(ref indexRow, ref indexCol);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
        ((F_ProfileFreeDrawCmd) this).parShape.selectedPlane = planeBoxNames.Top;
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Right;
        ((F_SelectedPlanes) this).PlaneColorUpdate();
        this.ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
        // ISSUE: reference to a compiler-generated field
        if (((F_PlaneMoveRotate) this).\u0001 != null)
        {
          this.SetRowColIndex(indexRow, indexCol);
          // ISSUE: reference to a compiler-generated field
          ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
        }
      }
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Vertical)
      {
        int indexRow = -1;
        int indexCol = -1;
        this.GetRowColIndex(ref indexRow, ref indexCol);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
        ((F_ProfileFreeDrawCmd) this).parShape.selectedPlane = planeBoxNames.Top;
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Right;
        ((F_SelectedPlanes) this).PlaneColorUpdate();
        this.ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
        // ISSUE: reference to a compiler-generated field
        if (((F_PlaneMoveRotate) this).\u0001 != null)
        {
          this.SetRowColIndex(indexRow, indexCol);
          // ISSUE: reference to a compiler-generated field
          ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
        }
      }
      if (((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Horizontal)
      {
        int indexRow = -1;
        int indexCol = -1;
        this.GetRowColIndex(ref indexRow, ref indexCol);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
        ((F_ProfileFreeDrawCmd) this).parShape.selectedPlane = planeBoxNames.Top;
        ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchSideLocation = ProfileNotchLocationType.Right;
        ((F_SelectedPlanes) this).PlaneColorUpdate();
        this.ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
        ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
        // ISSUE: reference to a compiler-generated field
        if (((F_PlaneMoveRotate) this).\u0001 != null)
        {
          this.SetRowColIndex(indexRow, indexCol);
          // ISSUE: reference to a compiler-generated field
          ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
        }
      }
    }
    if (control2.Name == ((F_ProfileTemplate) this).btn_front.Name && ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType == ProfileNotchOperationType.Length)
    {
      int indexRow = -1;
      int indexCol = -1;
      this.GetRowColIndex(ref indexRow, ref indexCol);
      ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
      ((F_ProfileFreeDrawCmd) this).parShape.selectedPlane = planeBoxNames.Top;
      ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchLengthLocation = ProfileNotchLocationType.Front;
      ((F_SelectedPlanes) this).PlaneColorUpdate();
      this.ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
      ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
      // ISSUE: reference to a compiler-generated field
      if (((F_PlaneMoveRotate) this).\u0001 != null)
      {
        this.SetRowColIndex(indexRow, indexCol);
        // ISSUE: reference to a compiler-generated field
        ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
      }
    }
    if (!(control2.Name == ((F_ProfileTemplate) this).btn_back.Name) || ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType != ProfileNotchOperationType.Length)
      return;
    int indexRow1 = -1;
    int indexCol1 = -1;
    this.GetRowColIndex(ref indexRow1, ref indexCol1);
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
    ((F_ProfileFreeDrawCmd) this).parShape.selectedPlane = planeBoxNames.Top;
    ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchLengthLocation = ProfileNotchLocationType.Back;
    ((F_SelectedPlanes) this).PlaneColorUpdate();
    this.ShapeToDataGrid(((F_ProfileClamperSet) this).\u0001);
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
    // ISSUE: reference to a compiler-generated field
    if (((F_PlaneMoveRotate) this).\u0001 == null)
      return;
    this.SetRowColIndex(indexRow1, indexCol1);
    // ISSUE: reference to a compiler-generated field
    ((F_PlaneMoveRotate) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape), (object) null);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_PlaneMoveRotate) this).PropertiesForm.Inited)
      return;
    if (((F_ProfilePriority) this).cmb_tools.SelectedIndex >= 0 & ((F_ProfilePriority) this).cmb_tools.SelectedIndex <= ((F_ProfileFreeDrawCmd) this).Tools.Count - 1)
      ((F_ProfileFreeDrawCmd) this).activeTool = (ToolBase5) new ToolGeometry5(((F_ProfileFreeDrawCmd) this).Tools[((F_ProfilePriority) this).cmb_tools.SelectedIndex]);
    // ISSUE: reference to a compiler-generated field
    if (((F_PlaneMoveRotate) this).\u0001 != null & ((F_ProfileFreeDrawCmd) this).activeTool != null)
    {
      ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
      ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
      ((ShapeRuntimeData) Data2).ToolName = ((ToolCamData5) ((ToolGeometry5) ((F_ProfileFreeDrawCmd) this).activeTool).Data).Name;
      ((ShapeRuntimeData) Data2).ToolChangeForced = true;
      ((ShapeRuntimeData) Data2).ToolIndex = ((F_ProfilePriority) this).cmb_tools.SelectedIndex;
      // ISSUE: reference to a compiler-generated field
      ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
    }
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
    ((F_SelectedPlanes) this).Apply();
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] ListViewItemSelectionChangedEventArgs obj1)
  {
    if (!((F_PlaneMoveRotate) this).PropertiesForm.Inited || !(obj1.ItemIndex >= 0 & obj1.IsSelected))
      return;
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = false;
    if (obj1.ItemIndex == 0)
      ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType = ProfileNotchOperationType.Side;
    if (obj1.ItemIndex == 1)
      ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType = ProfileNotchOperationType.Length;
    if (obj1.ItemIndex == 2)
      ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType = ProfileNotchOperationType.Vertical;
    if (obj1.ItemIndex == 3)
      ((dynamicInfo) ((F_ProfileFreeDrawCmd) this).parShape).NotchOPType = ProfileNotchOperationType.Horizontal;
    ((F_SelectedPlanes) this).PlaneColorUpdate();
    this.ShapeToDataGrid(obj1.ItemIndex);
    ((F_ProfileClamperSet) this).\u0001 = obj1.ItemIndex;
    ((F_PlaneMoveRotate) this).PropertiesForm.Inited = true;
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = 0;
    ((CreateProfileFromDataOptions) buCall.\u0001).FindNotchDataValueType(((F_ProfileFreeDrawCmd) this).parShape, 0, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_PlaneMoveRotate) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    ((F_ProfileFreeDrawCmd) this).parShape.ValueType = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ProfileFreeDrawCmd) this).parShape);
    ((ShapeRuntimeData) Data2).ValueType = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType;
    // ISSUE: reference to a compiler-generated field
    ((F_PlaneMoveRotate) this).\u0001((object) null, (object) Data2, (object) null);
  }

  public void GetRowColIndex(ref int indexRow, ref int indexCol)
  {
    indexCol = -1;
    indexRow = -1;
    if (((F_ProfileTemplate) this).dgv_data.CurrentCell == null)
      return;
    indexRow = ((F_ProfileTemplate) this).dgv_data.CurrentCell.RowIndex;
    indexCol = ((F_ProfileTemplate) this).dgv_data.CurrentCell.ColumnIndex;
  }

  public void SetRowColIndex(int indexRow, int indexCol)
  {
    if (!(indexRow >= 0 & indexRow <= ((F_ProfileTemplate) this).dgv_data.Rows.Count - 1) || !(indexCol >= 0 & indexCol <= ((F_ProfileTemplate) this).dgv_data.Columns.Count - 1))
      return;
    ((F_ProfileTemplate) this).dgv_data.CurrentCell = ((F_ProfileTemplate) this).dgv_data.Rows[indexRow].Cells[indexCol];
  }
}
