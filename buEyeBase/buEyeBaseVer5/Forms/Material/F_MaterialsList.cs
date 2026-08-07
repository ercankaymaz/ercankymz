// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Material.F_MaterialsList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Material;

public class F_MaterialsList : Form
{
  public buButton btn_popupviewright;
  public buLabel lbl_coords;
  public static byte f0018BA;
  public FormProperties PropertiesForm;
  public string Caption;
  public bool Caps;
  public string Value;
  public bool CheckNumeric;
  public bool ShowInitValue;
  public char PasswordChar;
  public double MaxValue;
  public double MinValue;
  private bool \u0001;

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_OperationList) this).\u0001.Enabled = false;
    ((F_OperationList) this).\u0001.Items.Clear();
    if (((F_ProfileAdd) this).SelectedPlane >= 0 && ((F_ProfileAdd) this).SelectedPlane <= ((F_OperationList) this).\u0001.Items.Count - 1)
      ((F_OperationList) this).\u0001.SelectedIndex = ((F_ProfileAdd) this).SelectedPlane;
    for (int index = 0; index <= ((F_ProfileAdd) this).PreviewEnts.Count - 1; ++index)
    {
      Entity entity = buVector5.CopyEntities(((F_ProfileAdd) this).PreviewEnts[index]);
      CustomData customData = (CustomData) new ClipperOffset();
      ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Profile);
      entity.EntityData = (object) customData;
      ((F_OperationList) this).\u0001.Entities.Add(entity);
    }
    buCall.\u0001.BoxSizeCalculate(((F_ProfileAdd) this).PreviewEnts, ref ((F_OperationList) this).\u0001, ref ((F_OperationList) this).\u0002);
    ((F_OperationList) this).\u0001.ActiveViewport.ViewCubeIcon.Visible = false;
    ((F_OperationList) this).\u0001.SetView(viewType.vcFrontFaceTopLeft);
    ((F_OperationList) this).\u0001.ZoomFit();
    ((F_OperationList) this).\u0001.ZoomOut(2);
    ((F_OperationList) this).\u0001.Invalidate();
    for (int index = 0; index <= ((F_ProfileAdd) this).Planes.Count - 1; ++index)
      \u0007.\u0001.\u0001(false, ((F_ProfileAdd) this).Planes[index], (F_SelectedPlanes) this);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_ProfileAdd) this).PropertiesForm.Inited = false;
    ((F_OperationList) this).\u0001.Entities.ClearSelection();
    if (((F_OperationList) this).\u0001.SelectedIndex >= 0 & ((F_OperationList) this).\u0001.SelectedIndex <= ((F_OperationList) this).\u0001.Entities.Count - 1)
    {
      for (int index = 0; index <= ((F_OperationList) this).\u0001.Entities.Count - 1; ++index)
      {
        if ((((F_OperationList) this).\u0001.Entities[index].EntityData == null ? 0 : (((F_OperationList) this).\u0001.Entities[index].EntityData is CustomData ? 1 : 0)) != 0 && ((DiemakerGrindingShapeSettings) (((F_OperationList) this).\u0001.Entities[index].EntityData as CustomData)).get_RefIndex() == ((F_OperationList) this).\u0001.SelectedIndex)
          ((F_OperationList) this).\u0001.Entities[index].Selected = true;
      }
      ((F_OperationList) this).\u0001.Value = (Decimal) ((GCodeConverter) ((F_ProfileAdd) this).Planes[((F_OperationList) this).\u0001.SelectedIndex]).Angle;
      ((F_OperationList) this).\u0002.Value = (Decimal) ((ColorType) ((F_ProfileAdd) this).Planes[((F_OperationList) this).\u0001.SelectedIndex]).pntPlane.X;
      ((F_OperationList) this).\u0003.Value = (Decimal) ((ColorType) ((F_ProfileAdd) this).Planes[((F_OperationList) this).\u0001.SelectedIndex]).pntPlane.Y;
      ((F_OperationList) this).\u0004.Value = (Decimal) ((ColorType) ((F_ProfileAdd) this).Planes[((F_OperationList) this).\u0001.SelectedIndex]).pntPlane.Z;
      ((F_ProfileAdd) this).SelectedPlane = ((F_OperationList) this).\u0001.SelectedIndex;
    }
    ((F_OperationList) this).\u0001.Invalidate();
    ((F_ProfileAdd) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (control.Name == ((F_OperationList) this).\u0001.Name)
    {
      ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_OperationList) this).\u0002.Name)
    {
      ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_OperationList) this).\u0010.Name)
    {
      if (!((F_OperationList) this).\u0002.Visible)
        ((F_OperationList) this).\u0002.Visible = true;
      else
        ((F_OperationList) this).\u0002.Visible = false;
    }
    if (control.Name == ((F_OperationList) this).\u000F.Name)
    {
      SelectedPlaneInfo selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings();
      \u0007.\u0001.\u0001(true, ((F_ProfileAdd) this).Planes.Count, (F_SelectedPlanes) this, ref selectedPlaneInfo, ProfilePlaneDef.Top0);
      ((F_ProfileAdd) this).Planes.Add(selectedPlaneInfo);
      \u0007.\u0001.\u0001(false, selectedPlaneInfo, (F_SelectedPlanes) this);
      ((F_OperationList) this).\u0002.Visible = false;
    }
    if (control.Name == ((F_OperationList) this).\u000E.Name)
    {
      SelectedPlaneInfo selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings();
      \u0007.\u0001.\u0001(true, ((F_ProfileAdd) this).Planes.Count, (F_SelectedPlanes) this, ref selectedPlaneInfo, ProfilePlaneDef.Back45);
      ((F_ProfileAdd) this).Planes.Add(selectedPlaneInfo);
      \u0007.\u0001.\u0001(false, selectedPlaneInfo, (F_SelectedPlanes) this);
      ((F_OperationList) this).\u0002.Visible = false;
    }
    if (control.Name == ((F_OperationList) this).\u0008.Name)
    {
      SelectedPlaneInfo selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings();
      \u0007.\u0001.\u0001(true, ((F_ProfileAdd) this).Planes.Count, (F_SelectedPlanes) this, ref selectedPlaneInfo, ProfilePlaneDef.Back90);
      ((F_ProfileAdd) this).Planes.Add(selectedPlaneInfo);
      \u0007.\u0001.\u0001(false, selectedPlaneInfo, (F_SelectedPlanes) this);
      ((F_OperationList) this).\u0002.Visible = false;
    }
    if (control.Name == ((F_OperationList) this).\u0007.Name)
    {
      SelectedPlaneInfo selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings();
      \u0007.\u0001.\u0001(true, ((F_ProfileAdd) this).Planes.Count, (F_SelectedPlanes) this, ref selectedPlaneInfo, ProfilePlaneDef.Front45);
      ((F_ProfileAdd) this).Planes.Add(selectedPlaneInfo);
      \u0007.\u0001.\u0001(false, selectedPlaneInfo, (F_SelectedPlanes) this);
      ((F_OperationList) this).\u0002.Visible = false;
    }
    if (control.Name == ((F_OperationList) this).\u0006.Name)
    {
      SelectedPlaneInfo selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings();
      \u0007.\u0001.\u0001(true, ((F_ProfileAdd) this).Planes.Count, (F_SelectedPlanes) this, ref selectedPlaneInfo, ProfilePlaneDef.Front90);
      ((F_ProfileAdd) this).Planes.Add(selectedPlaneInfo);
      \u0007.\u0001.\u0001(false, selectedPlaneInfo, (F_SelectedPlanes) this);
      ((F_OperationList) this).\u0002.Visible = false;
    }
    if (control.Name == ((F_OperationList) this).\u0011.Name)
      ((F_OperationList) this).\u0001.Value = ((F_OperationList) this).\u0001.Value - (Decimal) ((F_OperationList) this).Increment;
    if (control.Name == ((F_OperationList) this).\u0012.Name)
      ((F_OperationList) this).\u0001.Value = ((F_OperationList) this).\u0001.Value + (Decimal) ((F_OperationList) this).Increment;
    if (control.Name == ((F_OperationList) this).\u0014.Name)
      ((F_OperationList) this).\u0002.Value = ((F_OperationList) this).\u0002.Value - (Decimal) ((F_OperationList) this).Increment;
    if (control.Name == ((F_OperationList) this).\u0013.Name)
      ((F_OperationList) this).\u0002.Value = ((F_OperationList) this).\u0002.Value + (Decimal) ((F_OperationList) this).Increment;
    if (control.Name == ((F_OperationList) this).\u0016.Name)
      ((F_OperationList) this).\u0003.Value = ((F_OperationList) this).\u0003.Value - (Decimal) ((F_OperationList) this).Increment;
    if (control.Name == ((F_OperationList) this).\u0015.Name)
      ((F_OperationList) this).\u0003.Value = ((F_OperationList) this).\u0003.Value + (Decimal) ((F_OperationList) this).Increment;
    if (control.Name == ((F_OperationList) this).\u0018.Name)
      ((F_OperationList) this).\u0004.Value = ((F_OperationList) this).\u0004.Value - (Decimal) ((F_OperationList) this).Increment;
    if (control.Name == ((F_OperationList) this).\u0017.Name)
      ((F_OperationList) this).\u0004.Value = ((F_OperationList) this).\u0004.Value + (Decimal) ((F_OperationList) this).Increment;
    if (control.Name == ((F_OperationList) this).\u000F.Name)
    {
      ((F_OperationList) this).Increment = 0.1;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SelectedPlanes) this);
    }
    if (control.Name == ((F_OperationList) this).\u0010.Name)
    {
      ((F_OperationList) this).Increment = 0.5;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SelectedPlanes) this);
    }
    if (control.Name == ((F_OperationList) this).\u000E.Name)
    {
      ((F_OperationList) this).Increment = 1.0;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SelectedPlanes) this);
    }
    if (control.Name == ((F_OperationList) this).\u0008.Name)
    {
      ((F_OperationList) this).Increment = 5.0;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SelectedPlanes) this);
    }
    if (control.Name == ((F_OperationList) this).\u0007.Name)
    {
      ((F_OperationList) this).Increment = 10.0;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SelectedPlanes) this);
    }
    if (control.Name == ((F_OperationList) this).\u0003.Name && buNumeric5.MessageBoxQuestion(AppLanguage.CadCamMessages[97]) == DialogResult.Yes && ((F_ProfileAdd) this).SelectedPlane >= 0 & ((F_ProfileAdd) this).SelectedPlane <= ((F_ProfileAdd) this).Planes.Count - 1)
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((F_ProfileAdd) this).SelectedPlane, false, (F_SelectedPlanes) this);
    if (control.Name == ((F_OperationList) this).\u0004.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = ((F_OperationList) this).pathString;
      openFileDialog.Filter = "buCad/Cam Plane File (*.buplane)|*.buplane";
      openFileDialog.FilterIndex = 1;
      openFileDialog.Multiselect = false;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        ((F_OperationList) this).pathString = buFile5.bunesting.GetPath(openFileDialog.FileName);
        buGCodeCreate.OpenPlaneFile(openFileDialog.FileName, ref ((F_ProfileAdd) this).Planes);
        this.\u0002((object) null, (EventArgs) null);
      }
    }
    if (!(control.Name == ((F_OperationList) this).\u0005.Name))
      return;
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = ((F_OperationList) this).pathString;
    saveFileDialog.Filter = "buCad/Cam Plane File (*.buplane)|*.buplane";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    buGCodeCreate.SavePlaneFile(saveFileDialog.FileName, ((F_ProfileAdd) this).Planes);
    ((F_OperationList) this).pathString = buFile5.bunesting.GetPath(saveFileDialog.FileName);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ProfileAdd) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ProfileAdd) this).PropertiesForm.Inited || !(((F_ProfileAdd) this).SelectedPlane >= 0 & ((F_ProfileAdd) this).SelectedPlane <= ((F_ProfileAdd) this).Planes.Count - 1))
      return;
    ((F_ProfileAdd) this).PropertiesForm.Inited = false;
    SelectedPlaneInfo plane = ((F_ProfileAdd) this).Planes[((F_ProfileAdd) this).SelectedPlane];
    ((ColorType) plane).pntPlane.X = (double) ((F_OperationList) this).\u0002.Value;
    ((ColorType) plane).pntPlane.Y = (double) ((F_OperationList) this).\u0003.Value;
    ((ColorType) plane).pntPlane.Z = (double) ((F_OperationList) this).\u0004.Value;
    ((GCodeConverter) plane).Angle = (double) ((F_OperationList) this).\u0001.Value;
    ProfilePlaneDef planeType = ((GCodeConverter) plane).PlaneType;
    \u0007.\u0001.\u0001(false, ((GCodeConverter) plane).Index, (F_SelectedPlanes) this, ref plane, planeType);
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((F_ProfileAdd) this).SelectedPlane, true, (F_SelectedPlanes) this);
    \u0007.\u0001.\u0001(true, plane, (F_SelectedPlanes) this);
    ((F_ProfileAdd) this).PropertiesForm.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_OperationList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_OperationList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m000DBD();

  public F_MaterialsList()
  {
    ((F_OperationList) this).FormCloseMode = FormCloseModeType.Dispose;
    ((F_OperationList) this).Result = DialogResult.None;
    ((F_OperationList) this).SelectedType = ProfileNewType.Rectangle;
    ((F_OperationList) this).XDirRefType = LeftRightType.Left;
    ((F_OperationList) this).RightProfile = false;
    ((F_OperationList) this).PreviewEnts = new List<Entity>();
    ((F_OperationList) this).ItemName = "";
    ((F_OperationList) this).ItemLength = "";
    ((F_OperationList) this).ItemWidth = 100.0;
    ((F_OperationList) this).ItemHeight = 100.0;
    ((F_OperationList) this).ItemThickness = 2.0;
    ((F_OperationList) this).ItemRadius = 100.0;
    ((F_OperationList) this).ItemDiameter = 100.0;
    ((F_OperationList) this).StandartProfileIndex = -1;
    ((F_OperationList) this).MaxClamper = 4;
    ((F_OperationList) this).\u0001 = (Design) null;
    ((F_OperationList) this).\u0001 = (Timer) null;
    ((F_OperationList) this).\u0001 = false;
    ((F_OperationList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_NewProfile) this);
  }
}
