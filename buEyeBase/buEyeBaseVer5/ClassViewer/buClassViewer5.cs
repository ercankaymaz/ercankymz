// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ClassViewer.buClassViewer5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buEyeBaseVer5.Forms.BarCodes;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.ClassForm;
using buEyeBaseVer5.Forms.Controls;
using buEyeBaseVer5.Forms.Printer3D;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.ClassViewer;

public class buClassViewer5 : UserControl
{
  public buSpin spn_leftcutnumberConstcusp;
  public buCheckBox chk_depthstepoverConstcusp;
  public buSpin spn_depthstepoverConstcusp;
  internal buGroup \u001E;
  public buCheckBox chk_cutorderfrombottomtotopConstcusp;
  public buCheckBox chk_cutorderfromtoptobottomConstcusp;
  public buCheckBox chk_cutorderstandartConstcusp;
  public buCheckBox chk_cutorderfromcenterawayConstcusp;
  public buCheckBox chk_cutorderfromoutsidetocenterConstcusp;
  public buSpin spn_stepoverConstcusp;
  public buCheckBox chk_edgerollingConstcusp;
  public buSpin spn_overlapConstcusp;
  public buCheckBox chk_cornerefinementConstcusp;
  public buCheckBox chk_rightcutnumberConstcusp;
  public buSpin spn_rightcutnumberConstcusp;
  public buCheckBox chk_stepdirleftConstcusp;
  public buCheckBox chk_stepdirbothConstcusp;
  public buCheckBox chk_stepdirrightConstcusp;
  internal buGroup \u001F;
  public buSpin spn_anglerangeend;
  public buSpin spn_anglerangestart;
  public buCheckBox chk_Anglerangeenable;
  public buCheckBox chk_anglerangebetweenslopeangles;
  public buCheckBox chk_anglerangeoutsideslopeangles;
  internal TabPage \u000F;
  internal buGroup \u007F;
  public buCheckBox chk_toolcentermodegeodesic;
  public buCheckBox chk_contactmodegeodesic;
  internal buGroup \u0080;
  public buCheckBox chk_cutorderwipefromdirectiongeodesic;
  public buCheckBox chk_cutorderstandartgeodesic;
  public buCheckBox chk_cutorderfromcenterawaygeodesic;
  public buCheckBox chk_cutorderfromoutsidetocentergeodesic;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_CamTriMeshSettings) this).btn_ok.Name)
      {
        ((buClassViewerColor5.ClassViewerEventHandler5) this).Apply();
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else if (control.Name == ((F_CamTriMeshSettings) this).btn_close.Name | control.Name == ((F_CamTriMeshSettings) this).btn_cancel.Name)
      {
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (!((F_CamTriMeshSettings) this).PropertiesForm.Inited)
          return;
        if (control.Name == ((F_CamTriMeshSettings) this).btn_menubutton1.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = (buButton) buControlCommands.CloneControl((buControl) ((F_CamTriMeshSettings) this).btn_menubutton1);
          ((F_CamTriMeshSettings) fControlUiButton).refButton = buButton.CopyVisual(((F_CamTriMeshSettings) this).btn_menubutton1, ((F_CamTriMeshSettings) fControlUiButton).refButton);
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_menubutton1 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_menubutton1);
            ((buFile5) clsVisualVars.parVisual.hmiButtonMenu1).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu1).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonMenu1).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu1).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_menubutton2.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_menubutton2;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_menubutton2 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_menubutton2);
            ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_menubutton3.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_menubutton3;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_menubutton3 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_menubutton3);
            ((buFile5) clsVisualVars.parVisual.hmiButtonMenu3).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu3).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonMenu3).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu3).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_menubutton4.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_menubutton4;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_menubutton4 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_menubutton4);
            ((buFile5) clsVisualVars.parVisual.hmiButtonMenu4).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu4).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonMenu4).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu4).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_systembutton1.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_systembutton1;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_systembutton1 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_systembutton1);
            ((buFile5) clsVisualVars.parVisual.hmiButtonSystem1).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonSystem1).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonSystem1).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonSystem1).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_systembutton2.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_systembutton2;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_systembutton2 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_systembutton2);
            ((buFile5) clsVisualVars.parVisual.hmiButtonSystem2).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonSystem2).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonSystem2).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonSystem2).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_systembutton3.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_systembutton3;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_systembutton3 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_systembutton3);
            ((buFile5) clsVisualVars.parVisual.hmiButtonSystem3).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonSystem3).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonSystem3).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonSystem3).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_systembutton4.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_systembutton4;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_systembutton4 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_systembutton4);
            ((buFile5) clsVisualVars.parVisual.hmiButtonSystem4).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonSystem4).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonSystem4).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonSystem4).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_commandbutton1.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_commandbutton1;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_commandbutton1 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_commandbutton1);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCommand1).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonCommand1).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCommand1).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonCommand1).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_commandbutton2.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_commandbutton2;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_commandbutton2 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_commandbutton2);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCommand2).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonCommand2).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCommand2).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonCommand2).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_commandbutton3.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_commandbutton3;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_commandbutton3 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_commandbutton3);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCommand3).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonCommand3).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCommand3).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonCommand3).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).btn_commandbutton4.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamTriMeshSettings) this).btn_commandbutton4;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).btn_commandbutton4 = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamTriMeshSettings) this).btn_commandbutton4);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCommand4).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonCommand4).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCommand4).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonCommand4).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).btn_okk.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamParallelCutSettings) this).btn_okk;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).btn_okk = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamParallelCutSettings) this).btn_okk);
            ((buFile5) clsVisualVars.parVisual.hmiButtonOk).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonOk).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonOk).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonOk).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).btn_cancell.Name)
        {
          F_ControlUIButton fControlUiButton = (F_ControlUIButton) new setDateTimeControl();
          ((F_CamTriMeshSettings) fControlUiButton).refButton = ((F_CamParallelCutSettings) this).btn_cancell;
          ((setColorComboControl) fControlUiButton).Init();
          int num = (int) fControlUiButton.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiButton).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).btn_cancell = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiButton).refButton, ((F_CamParallelCutSettings) this).btn_cancell);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCancel).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.Display, ((buFile5) clsVisualVars.parVisual.hmiButtonCancel).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiButtonCancel).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiButtonCancel).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiButton).refButton.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiButton).refButton.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiButton).refButton.ImageAlign;
          }
          fControlUiButton.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).\u0004.Name)
        {
          F_ControlUILabel fControlUiLabel = (F_ControlUILabel) new F_Printer3DSettings();
          ((F_CamTriMeshSettings) fControlUiLabel).refLabel = (buLabel) buControlCommands.CloneControl((buControl) ((F_CamTriMeshSettings) this).\u0004);
          ((F_Printer3DSettings) fControlUiLabel).Init();
          int num = (int) fControlUiLabel.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiLabel).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).\u0004 = buLabel.CopyVisual(((F_CamTriMeshSettings) fControlUiLabel).refLabel, ((F_CamTriMeshSettings) this).\u0004);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiLabel).refLabel.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.ImageAlign;
          }
          fControlUiLabel.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).\u0003.Name)
        {
          F_ControlUILabel fControlUiLabel = (F_ControlUILabel) new F_Printer3DSettings();
          ((F_CamTriMeshSettings) fControlUiLabel).refLabel = (buLabel) buControlCommands.CloneControl((buControl) ((F_CamTriMeshSettings) this).\u0003);
          ((F_Printer3DSettings) fControlUiLabel).Init();
          int num = (int) fControlUiLabel.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiLabel).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).\u0003 = buLabel.CopyVisual(((F_CamTriMeshSettings) fControlUiLabel).refLabel, ((F_CamTriMeshSettings) this).\u0003);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiLabel).refLabel.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.ImageAlign;
          }
          fControlUiLabel.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
        {
          F_ControlUILabel fControlUiLabel = (F_ControlUILabel) new F_Printer3DSettings();
          ((F_CamTriMeshSettings) fControlUiLabel).refLabel = ((F_CamTriMeshSettings) this).\u0002;
          ((F_Printer3DSettings) fControlUiLabel).Init();
          int num = (int) fControlUiLabel.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiLabel).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).\u0002 = buLabel.CopyVisual(((F_CamTriMeshSettings) fControlUiLabel).refLabel, ((F_CamTriMeshSettings) this).\u0002);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiLabel).refLabel.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.ImageAlign;
          }
          fControlUiLabel.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
        {
          F_ControlUILabel fControlUiLabel = (F_ControlUILabel) new F_Printer3DSettings();
          ((F_CamTriMeshSettings) fControlUiLabel).refLabel = ((F_CamTriMeshSettings) this).\u0001;
          ((F_Printer3DSettings) fControlUiLabel).Init();
          int num = (int) fControlUiLabel.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiLabel).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).\u0001 = buLabel.CopyVisual(((F_CamTriMeshSettings) fControlUiLabel).refLabel, ((F_CamTriMeshSettings) this).\u0001);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiLabel).refLabel.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiLabel).refLabel.ImageAlign;
          }
          fControlUiLabel.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).spn_1.Name)
        {
          F_ControlUISpin fControlUiSpin = (F_ControlUISpin) new F_BarCode();
          ((F_CamTriMeshSettings) fControlUiSpin).refSpin = new buSpin();
          ((F_CamTriMeshSettings) fControlUiSpin).refSpin = buSpin.CopyVisual(((F_CamParallelCutSettings) this).spn_1, ((F_CamTriMeshSettings) fControlUiSpin).refSpin);
          ((F_BarCode) fControlUiSpin).Init();
          int num = (int) fControlUiSpin.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiSpin).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).spn_1 = buSpin.CopyVisual(((F_CamTriMeshSettings) fControlUiSpin).refSpin, ((F_CamParallelCutSettings) this).spn_1);
            ((buFile5) clsVisualVars.parVisual.hmiSpin1).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonNormalDisplay, ((buFile5) clsVisualVars.parVisual.hmiSpin1).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiSpin1).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiSpin1).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Caption = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.Caption.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Caption);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.ImageAlign;
          }
          fControlUiSpin.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).spn_2.Name)
        {
          F_ControlUISpin fControlUiSpin = (F_ControlUISpin) new F_BarCode();
          ((F_CamTriMeshSettings) fControlUiSpin).refSpin = new buSpin();
          ((F_CamTriMeshSettings) fControlUiSpin).refSpin = buSpin.CopyVisual(((F_CamParallelCutSettings) this).spn_2, ((F_CamTriMeshSettings) fControlUiSpin).refSpin);
          ((F_BarCode) fControlUiSpin).Init();
          int num = (int) fControlUiSpin.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiSpin).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).spn_2 = buSpin.CopyVisual(((F_CamTriMeshSettings) fControlUiSpin).refSpin, ((F_CamParallelCutSettings) this).spn_2);
            ((buFile5) clsVisualVars.parVisual.hmiSpin2).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonNormalDisplay, ((buFile5) clsVisualVars.parVisual.hmiSpin2).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiSpin2).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiSpin2).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Caption = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.Caption.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Caption);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.ImageAlign;
          }
          fControlUiSpin.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).spn_3.Name)
        {
          F_ControlUISpin fControlUiSpin = (F_ControlUISpin) new F_BarCode();
          ((F_CamTriMeshSettings) fControlUiSpin).refSpin = new buSpin();
          ((F_CamTriMeshSettings) fControlUiSpin).refSpin = buSpin.CopyVisual(((F_CamParallelCutSettings) this).spn_3, ((F_CamTriMeshSettings) fControlUiSpin).refSpin);
          ((F_BarCode) fControlUiSpin).Init();
          int num = (int) fControlUiSpin.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiSpin).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).spn_3 = buSpin.CopyVisual(((F_CamTriMeshSettings) fControlUiSpin).refSpin, ((F_CamParallelCutSettings) this).spn_3);
            ((buFile5) clsVisualVars.parVisual.hmiSpin3).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonNormalDisplay, ((buFile5) clsVisualVars.parVisual.hmiSpin3).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiSpin3).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiSpin3).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Caption = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.Caption.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Caption);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.ImageAlign;
          }
          fControlUiSpin.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).spn_4.Name)
        {
          F_ControlUISpin fControlUiSpin = (F_ControlUISpin) new F_BarCode();
          ((F_CamTriMeshSettings) fControlUiSpin).refSpin = new buSpin();
          ((F_CamTriMeshSettings) fControlUiSpin).refSpin = buSpin.CopyVisual(((F_CamParallelCutSettings) this).spn_4, ((F_CamTriMeshSettings) fControlUiSpin).refSpin);
          ((F_BarCode) fControlUiSpin).Init();
          int num = (int) fControlUiSpin.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiSpin).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).spn_4 = buSpin.CopyVisual(((F_CamTriMeshSettings) fControlUiSpin).refSpin, ((F_CamParallelCutSettings) this).spn_4);
            ((buFile5) clsVisualVars.parVisual.hmiSpin4).ButtonNormal = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonNormalDisplay, ((buFile5) clsVisualVars.parVisual.hmiSpin4).ButtonNormal);
            ((buFile5) clsVisualVars.parVisual.hmiSpin4).ButtonOver = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonOverDisplay, ((buFile5) clsVisualVars.parVisual.hmiSpin4).ButtonOver);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).ButtonDown = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.ButtonDownDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).ButtonDown);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Caption = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.Caption.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Caption);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiSpin).refSpin.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiSpin).refSpin.ImageAlign;
          }
          fControlUiSpin.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0004.Name)
        {
          F_ControlUIText fControlUiText = (F_ControlUIText) new F_CamRough4XSettings();
          ((F_CamTriMeshSettings) fControlUiText).refText = new buTextBox();
          ((F_CamTriMeshSettings) fControlUiText).refText = buTextBox.CopyVisual(((F_CamParallelCutSettings) this).\u0004, ((F_CamTriMeshSettings) fControlUiText).refText);
          ((F_CamRough4XSettings) fControlUiText).Init();
          int num = (int) fControlUiText.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiText).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0004 = buTextBox.CopyVisual(((F_CamTriMeshSettings) fControlUiText).refText, ((F_CamParallelCutSettings) this).\u0004);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Caption = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiText).refText.Caption.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Caption);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiText).refText.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiText).refText.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiText).refText.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiText).refText.ImageAlign;
          }
          fControlUiText.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0003.Name)
        {
          F_ControlUIText fControlUiText = (F_ControlUIText) new F_CamRough4XSettings();
          ((F_CamTriMeshSettings) fControlUiText).refText = new buTextBox();
          ((F_CamTriMeshSettings) fControlUiText).refText = buTextBox.CopyVisual(((F_CamParallelCutSettings) this).\u0003, ((F_CamTriMeshSettings) fControlUiText).refText);
          ((F_CamRough4XSettings) fControlUiText).Init();
          int num = (int) fControlUiText.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiText).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0003 = buTextBox.CopyVisual(((F_CamTriMeshSettings) fControlUiText).refText, ((F_CamParallelCutSettings) this).\u0003);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Caption = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiText).refText.Caption.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Caption);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiText).refText.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiText).refText.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiText).refText.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiText).refText.ImageAlign;
          }
          fControlUiText.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0002.Name)
        {
          F_ControlUIText fControlUiText = (F_ControlUIText) new F_CamRough4XSettings();
          ((F_CamTriMeshSettings) fControlUiText).refText = new buTextBox();
          ((F_CamTriMeshSettings) fControlUiText).refText = buTextBox.CopyVisual(((F_CamParallelCutSettings) this).\u0002, ((F_CamTriMeshSettings) fControlUiText).refText);
          ((F_CamRough4XSettings) fControlUiText).Init();
          int num = (int) fControlUiText.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiText).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0002 = buTextBox.CopyVisual(((F_CamTriMeshSettings) fControlUiText).refText, ((F_CamParallelCutSettings) this).\u0002);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Caption = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiText).refText.Caption.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Caption);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiText).refText.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiText).refText.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiText).refText.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiText).refText.ImageAlign;
          }
          fControlUiText.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0001.Name)
        {
          F_ControlUIText fControlUiText = (F_ControlUIText) new F_CamRough4XSettings();
          ((F_CamTriMeshSettings) fControlUiText).refText = new buTextBox();
          ((F_CamTriMeshSettings) fControlUiText).refText = buTextBox.CopyVisual(((F_CamParallelCutSettings) this).\u0001, ((F_CamTriMeshSettings) fControlUiText).refText);
          ((F_CamRough4XSettings) fControlUiText).Init();
          int num = (int) fControlUiText.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiText).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0001 = buTextBox.CopyVisual(((F_CamTriMeshSettings) fControlUiText).refText, ((F_CamParallelCutSettings) this).\u0001);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Caption = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiText).refText.Caption.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Caption);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) fControlUiText).refText.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) fControlUiText).refText.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Parameters).GeometryType = ((F_CamTriMeshSettings) fControlUiText).refText.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Parameters).ImageAlignment = ((F_CamTriMeshSettings) fControlUiText).refText.ImageAlign;
          }
          fControlUiText.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).chk_1.Name)
        {
          F_ControlUICheck fControlUiCheck = (F_ControlUICheck) new F_ControlUITrack();
          ((F_ControlUISettings) fControlUiCheck).refCheck = new buCheckBox();
          ((F_ControlUISettings) fControlUiCheck).refCheck = buCheckBox.CopyVisual(((F_CamParallelCutSettings) this).chk_1, ((F_ControlUISettings) fControlUiCheck).refCheck);
          ((F_ControlUITrack) fControlUiCheck).Init();
          int num = (int) fControlUiCheck.ShowDialog();
          if (((F_ControlUISettings) fControlUiCheck).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).chk_1 = buCheckBox.CopyVisual(((F_ControlUISettings) fControlUiCheck).refCheck, ((F_CamParallelCutSettings) this).chk_1);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Caption = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.TickDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Caption);
            ((buFile5) clsVisualVars.parVisual.hmiCheck1).ButtonNormal = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.ColorModeDisplay, ((buFile5) clsVisualVars.parVisual.hmiCheck1).ButtonNormal);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Display = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Parameters).GeometryArcDiameer = ((F_ControlUISettings) fControlUiCheck).refCheck.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Parameters).GeometryType = ((F_ControlUISettings) fControlUiCheck).refCheck.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Parameters).ImageAlignment = ((F_ControlUISettings) fControlUiCheck).refCheck.ImageAlign;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Parameters).CheckColorMode = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.ColorModeEnable;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Parameters).CheckBoxVisible = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.Visible;
            if (((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.BoxSize > 0)
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Parameters).CheckBoxSize = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.BoxSize;
            if (((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.Shape == ShapeType.Rectangle)
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Parameters).CheckBoxCheckIsRectangle = true;
            else
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Parameters).CheckBoxCheckIsRectangle = false;
          }
          fControlUiCheck.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).chk_2.Name)
        {
          F_ControlUICheck fControlUiCheck = (F_ControlUICheck) new F_ControlUITrack();
          ((F_ControlUISettings) fControlUiCheck).refCheck = new buCheckBox();
          ((F_ControlUISettings) fControlUiCheck).refCheck = buCheckBox.CopyVisual(((F_CamParallelCutSettings) this).chk_2, ((F_ControlUISettings) fControlUiCheck).refCheck);
          ((F_ControlUITrack) fControlUiCheck).Init();
          int num = (int) fControlUiCheck.ShowDialog();
          if (((F_ControlUISettings) fControlUiCheck).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).chk_2 = buCheckBox.CopyVisual(((F_ControlUISettings) fControlUiCheck).refCheck, ((F_CamParallelCutSettings) this).chk_2);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Caption = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.TickDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Caption);
            ((buFile5) clsVisualVars.parVisual.hmiCheck2).ButtonNormal = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.ColorModeDisplay, ((buFile5) clsVisualVars.parVisual.hmiCheck2).ButtonNormal);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Display = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Parameters).GeometryArcDiameer = ((F_ControlUISettings) fControlUiCheck).refCheck.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Parameters).GeometryType = ((F_ControlUISettings) fControlUiCheck).refCheck.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Parameters).ImageAlignment = ((F_ControlUISettings) fControlUiCheck).refCheck.ImageAlign;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Parameters).CheckColorMode = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.ColorModeEnable;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Parameters).CheckBoxVisible = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.Visible;
            if (((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.BoxSize > 0)
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Parameters).CheckBoxSize = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.BoxSize;
            if (((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.Shape == ShapeType.Rectangle)
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Parameters).CheckBoxCheckIsRectangle = true;
            else
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Parameters).CheckBoxCheckIsRectangle = false;
          }
          fControlUiCheck.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).chk_3.Name)
        {
          F_ControlUICheck fControlUiCheck = (F_ControlUICheck) new F_ControlUITrack();
          ((F_ControlUISettings) fControlUiCheck).refCheck = new buCheckBox();
          ((F_ControlUISettings) fControlUiCheck).refCheck = buCheckBox.CopyVisual(((F_CamParallelCutSettings) this).chk_3, ((F_ControlUISettings) fControlUiCheck).refCheck);
          ((F_ControlUITrack) fControlUiCheck).Init();
          int num = (int) fControlUiCheck.ShowDialog();
          if (((F_ControlUISettings) fControlUiCheck).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).chk_3 = buCheckBox.CopyVisual(((F_ControlUISettings) fControlUiCheck).refCheck, ((F_CamParallelCutSettings) this).chk_3);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Caption = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.TickDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Caption);
            ((buFile5) clsVisualVars.parVisual.hmiCheck3).ButtonNormal = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.ColorModeDisplay, ((buFile5) clsVisualVars.parVisual.hmiCheck3).ButtonNormal);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Display = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Parameters).GeometryArcDiameer = ((F_ControlUISettings) fControlUiCheck).refCheck.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Parameters).GeometryType = ((F_ControlUISettings) fControlUiCheck).refCheck.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Parameters).ImageAlignment = ((F_ControlUISettings) fControlUiCheck).refCheck.ImageAlign;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Parameters).CheckColorMode = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.ColorModeEnable;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Parameters).CheckBoxVisible = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.Visible;
            if (((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.BoxSize > 0)
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Parameters).CheckBoxSize = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.BoxSize;
            if (((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.Shape == ShapeType.Rectangle)
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Parameters).CheckBoxCheckIsRectangle = true;
            else
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Parameters).CheckBoxCheckIsRectangle = false;
          }
          fControlUiCheck.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).chk_4.Name)
        {
          F_ControlUICheck fControlUiCheck = (F_ControlUICheck) new F_ControlUITrack();
          ((F_ControlUISettings) fControlUiCheck).refCheck = new buCheckBox();
          ((F_ControlUISettings) fControlUiCheck).refCheck = buCheckBox.CopyVisual(((F_CamParallelCutSettings) this).chk_4, ((F_ControlUISettings) fControlUiCheck).refCheck);
          ((F_ControlUITrack) fControlUiCheck).Init();
          int num = (int) fControlUiCheck.ShowDialog();
          if (((F_ControlUISettings) fControlUiCheck).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).chk_4 = buCheckBox.CopyVisual(((F_ControlUISettings) fControlUiCheck).refCheck, ((F_CamParallelCutSettings) this).chk_4);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Caption = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.TickDisplay, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Caption);
            ((buFile5) clsVisualVars.parVisual.hmiCheck4).ButtonNormal = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.ColorModeDisplay, ((buFile5) clsVisualVars.parVisual.hmiCheck4).ButtonNormal);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Display = buControlDisplay.Copy(((F_ControlUISettings) fControlUiCheck).refCheck.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Parameters).GeometryArcDiameer = ((F_ControlUISettings) fControlUiCheck).refCheck.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Parameters).GeometryType = ((F_ControlUISettings) fControlUiCheck).refCheck.Geometry.ShapeMode;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Parameters).ImageAlignment = ((F_ControlUISettings) fControlUiCheck).refCheck.ImageAlign;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Parameters).CheckColorMode = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.ColorModeEnable;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Parameters).CheckBoxVisible = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.Visible;
            if (((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.BoxSize > 0)
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Parameters).CheckBoxSize = ((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.BoxSize;
            if (((F_ControlUISettings) fControlUiCheck).refCheck.CheckTick.Shape == ShapeType.Rectangle)
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Parameters).CheckBoxCheckIsRectangle = true;
            else
              ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Parameters).CheckBoxCheckIsRectangle = false;
          }
          fControlUiCheck.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
        {
          F_ControlUIRadio fControlUiRadio = (F_ControlUIRadio) new F_CamTriMeshSettings();
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio = new RadioButton();
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.ForeColor = ((F_CamTriMeshSettings) this).\u0001.ForeColor;
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.BackColor = ((F_CamTriMeshSettings) this).\u0001.BackColor;
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font = new Font(((F_CamTriMeshSettings) this).\u0001.Font.Name, ((F_CamTriMeshSettings) this).\u0001.Font.Size, ((F_CamTriMeshSettings) this).\u0001.Font.Style);
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.TextAlign = ((F_CamTriMeshSettings) this).\u0001.TextAlign;
          ((F_CamTriMeshSettings) fControlUiRadio).Init();
          int num = (int) fControlUiRadio.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiRadio).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).\u0001.ForeColor = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.ForeColor;
            ((F_CamTriMeshSettings) this).\u0001.BackColor = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.BackColor;
            ((F_CamTriMeshSettings) this).\u0001.Font = new Font(((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Name, ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Size, ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Style);
            ((F_CamTriMeshSettings) this).\u0001.TextAlign = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.TextAlign;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton1).Display.Fonts.Alignment = ((F_CamTriMeshSettings) this).\u0001.TextAlign;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton1).Display.BackColor = ((F_CamTriMeshSettings) this).\u0001.BackColor;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton1).Display.Fonts.ForeColor = ((F_CamTriMeshSettings) this).\u0001.ForeColor;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton1).Display.Fonts.Font = new Font(((F_CamTriMeshSettings) this).\u0001.Font.Name, ((F_CamTriMeshSettings) this).\u0001.Font.Size, ((F_CamTriMeshSettings) this).\u0001.Font.Style);
          }
          fControlUiRadio.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0004.Name)
        {
          F_ControlUIRadio fControlUiRadio = (F_ControlUIRadio) new F_CamTriMeshSettings();
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio = new RadioButton();
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.ForeColor = ((F_CamParallelCutSettings) this).\u0004.ForeColor;
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.BackColor = ((F_CamParallelCutSettings) this).\u0004.BackColor;
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font = new Font(((F_CamParallelCutSettings) this).\u0004.Font.Name, ((F_CamParallelCutSettings) this).\u0004.Font.Size, ((F_CamParallelCutSettings) this).\u0004.Font.Style);
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.TextAlign = ((F_CamParallelCutSettings) this).\u0004.TextAlign;
          ((F_CamTriMeshSettings) fControlUiRadio).Init();
          int num = (int) fControlUiRadio.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiRadio).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0004.ForeColor = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.ForeColor;
            ((F_CamParallelCutSettings) this).\u0004.BackColor = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.BackColor;
            ((F_CamParallelCutSettings) this).\u0004.Font = new Font(((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Name, ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Size, ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Style);
            ((F_CamParallelCutSettings) this).\u0004.TextAlign = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.TextAlign;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton2).Display.Fonts.Alignment = ((F_CamParallelCutSettings) this).\u0004.TextAlign;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton2).Display.BackColor = ((F_CamParallelCutSettings) this).\u0004.BackColor;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton2).Display.Fonts.ForeColor = ((F_CamParallelCutSettings) this).\u0004.ForeColor;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton2).Display.Fonts.Font = new Font(((F_CamParallelCutSettings) this).\u0004.Font.Name, ((F_CamParallelCutSettings) this).\u0004.Font.Size, ((F_CamParallelCutSettings) this).\u0004.Font.Style);
          }
          fControlUiRadio.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0003.Name)
        {
          F_ControlUIRadio fControlUiRadio = (F_ControlUIRadio) new F_CamTriMeshSettings();
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio = new RadioButton();
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.ForeColor = ((F_CamParallelCutSettings) this).\u0003.ForeColor;
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.BackColor = ((F_CamParallelCutSettings) this).\u0003.BackColor;
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font = new Font(((F_CamParallelCutSettings) this).\u0003.Font.Name, ((F_CamParallelCutSettings) this).\u0003.Font.Size, ((F_CamParallelCutSettings) this).\u0003.Font.Style);
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.TextAlign = ((F_CamParallelCutSettings) this).\u0003.TextAlign;
          ((F_CamTriMeshSettings) fControlUiRadio).Init();
          int num = (int) fControlUiRadio.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiRadio).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0003.ForeColor = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.ForeColor;
            ((F_CamParallelCutSettings) this).\u0003.BackColor = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.BackColor;
            ((F_CamParallelCutSettings) this).\u0003.Font = new Font(((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Name, ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Size, ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Style);
            ((F_CamParallelCutSettings) this).\u0003.TextAlign = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.TextAlign;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton3).Display.Fonts.Alignment = ((F_CamParallelCutSettings) this).\u0003.TextAlign;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton3).Display.BackColor = ((F_CamParallelCutSettings) this).\u0003.BackColor;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton3).Display.Fonts.ForeColor = ((F_CamParallelCutSettings) this).\u0003.ForeColor;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton3).Display.Fonts.Font = new Font(((F_CamParallelCutSettings) this).\u0003.Font.Name, ((F_CamParallelCutSettings) this).\u0003.Font.Size, ((F_CamParallelCutSettings) this).\u0003.Font.Style);
          }
          fControlUiRadio.Dispose();
        }
        if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
        {
          F_ControlUIRadio fControlUiRadio = (F_ControlUIRadio) new F_CamTriMeshSettings();
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio = new RadioButton();
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.ForeColor = ((F_CamTriMeshSettings) this).\u0002.ForeColor;
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.BackColor = ((F_CamTriMeshSettings) this).\u0002.BackColor;
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font = new Font(((F_CamTriMeshSettings) this).\u0002.Font.Name, ((F_CamTriMeshSettings) this).\u0002.Font.Size, ((F_CamTriMeshSettings) this).\u0002.Font.Style);
          ((F_CamTriMeshSettings) fControlUiRadio).refRadio.TextAlign = ((F_CamParallelCutSettings) this).\u0003.TextAlign;
          ((F_CamTriMeshSettings) fControlUiRadio).Init();
          int num = (int) fControlUiRadio.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiRadio).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTriMeshSettings) this).\u0002.ForeColor = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.ForeColor;
            ((F_CamTriMeshSettings) this).\u0002.BackColor = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.BackColor;
            ((F_CamTriMeshSettings) this).\u0002.Font = new Font(((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Name, ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Size, ((F_CamTriMeshSettings) fControlUiRadio).refRadio.Font.Style);
            ((F_CamTriMeshSettings) this).\u0002.TextAlign = ((F_CamTriMeshSettings) fControlUiRadio).refRadio.TextAlign;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton4).Display.Fonts.Alignment = ((F_CamTriMeshSettings) this).\u0002.TextAlign;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton4).Display.BackColor = ((F_CamTriMeshSettings) this).\u0002.BackColor;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton4).Display.Fonts.ForeColor = ((F_CamTriMeshSettings) this).\u0002.ForeColor;
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton4).Display.Fonts.Font = new Font(((F_CamTriMeshSettings) this).\u0002.Font.Name, ((F_CamTriMeshSettings) this).\u0002.Font.Size, ((F_CamTriMeshSettings) this).\u0002.Font.Style);
          }
          fControlUiRadio.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0004.Name)
        {
          F_ControlUIListbox controlUiListbox = (F_ControlUIListbox) new F_ControlUISettings();
          ((F_CamTriMeshSettings) controlUiListbox).refList = new buListBox();
          ((F_CamTriMeshSettings) controlUiListbox).refList = buListBox.CopyVisual(((F_CamParallelCutSettings) this).\u0004, ((F_CamTriMeshSettings) controlUiListbox).refList);
          ((F_ControlUISettings) controlUiListbox).Init();
          int num = (int) controlUiListbox.ShowDialog();
          if (((F_CamTriMeshSettings) controlUiListbox).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0004 = buListBox.CopyVisual(((F_CamTriMeshSettings) controlUiListbox).refList, ((F_CamParallelCutSettings) this).\u0004);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox1).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) controlUiListbox).refList.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox1).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox1).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) controlUiListbox).refList.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox1).Parameters).GeometryType = ((F_CamTriMeshSettings) controlUiListbox).refList.Geometry.ShapeMode;
          }
          controlUiListbox.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0003.Name)
        {
          F_ControlUIListbox controlUiListbox = (F_ControlUIListbox) new F_ControlUISettings();
          ((F_CamTriMeshSettings) controlUiListbox).refList = new buListBox();
          ((F_CamTriMeshSettings) controlUiListbox).refList = buListBox.CopyVisual(((F_CamParallelCutSettings) this).\u0003, ((F_CamTriMeshSettings) controlUiListbox).refList);
          ((F_ControlUISettings) controlUiListbox).Init();
          int num = (int) controlUiListbox.ShowDialog();
          if (((F_CamTriMeshSettings) controlUiListbox).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0003 = buListBox.CopyVisual(((F_CamTriMeshSettings) controlUiListbox).refList, ((F_CamParallelCutSettings) this).\u0003);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox2).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) controlUiListbox).refList.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox2).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox2).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) controlUiListbox).refList.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox2).Parameters).GeometryType = ((F_CamTriMeshSettings) controlUiListbox).refList.Geometry.ShapeMode;
          }
          controlUiListbox.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0002.Name)
        {
          F_ControlUIListbox controlUiListbox = (F_ControlUIListbox) new F_ControlUISettings();
          ((F_CamTriMeshSettings) controlUiListbox).refList = new buListBox();
          ((F_CamTriMeshSettings) controlUiListbox).refList = buListBox.CopyVisual(((F_CamParallelCutSettings) this).\u0002, ((F_CamTriMeshSettings) controlUiListbox).refList);
          ((F_ControlUISettings) controlUiListbox).Init();
          int num = (int) controlUiListbox.ShowDialog();
          if (((F_CamTriMeshSettings) controlUiListbox).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0002 = buListBox.CopyVisual(((F_CamTriMeshSettings) controlUiListbox).refList, ((F_CamParallelCutSettings) this).\u0002);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox3).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) controlUiListbox).refList.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox3).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox3).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) controlUiListbox).refList.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox3).Parameters).GeometryType = ((F_CamTriMeshSettings) controlUiListbox).refList.Geometry.ShapeMode;
          }
          controlUiListbox.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).\u0001.Name)
        {
          F_ControlUIListbox controlUiListbox = (F_ControlUIListbox) new F_ControlUISettings();
          ((F_CamTriMeshSettings) controlUiListbox).refList = new buListBox();
          ((F_CamTriMeshSettings) controlUiListbox).refList = buListBox.CopyVisual(((F_CamParallelCutSettings) this).\u0001, ((F_CamTriMeshSettings) controlUiListbox).refList);
          ((F_ControlUISettings) controlUiListbox).Init();
          int num = (int) controlUiListbox.ShowDialog();
          if (((F_CamTriMeshSettings) controlUiListbox).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).\u0001 = buListBox.CopyVisual(((F_CamTriMeshSettings) controlUiListbox).refList, ((F_CamParallelCutSettings) this).\u0001);
            ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox4).Display = buControlDisplay.Copy(((F_CamTriMeshSettings) controlUiListbox).refList.Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox4).Display);
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox4).Parameters).GeometryArcDiameer = ((F_CamTriMeshSettings) controlUiListbox).refList.Geometry.ArcDiameter;
            ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox4).Parameters).GeometryType = ((F_CamTriMeshSettings) controlUiListbox).refList.Geometry.ShapeMode;
          }
          controlUiListbox.Dispose();
        }
        if (control.Name == ((F_Cam4And5AxisSettings) this).track_1.Name)
        {
          F_ControlUITrack fControlUiTrack = (F_ControlUITrack) new F_CamSequence();
          ((F_CamTriMeshSettings) fControlUiTrack).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiTrack1);
          ((F_CamSequence) fControlUiTrack).Init();
          int num = (int) fControlUiTrack.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiTrack).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_Cam4And5AxisSettings) this).track_1 = buTrack.CopyVisual(((F_CamTriMeshSettings) fControlUiTrack).track_ref, ((F_Cam4And5AxisSettings) this).track_1);
            clsVisualVars.parVisual.hmiTrack1 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiTrack).Settings);
          }
          fControlUiTrack.Dispose();
        }
        if (control.Name == ((F_Cam4And5AxisSettings) this).track_2.Name)
        {
          F_ControlUITrack fControlUiTrack = (F_ControlUITrack) new F_CamSequence();
          ((F_CamTriMeshSettings) fControlUiTrack).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiTrack2);
          ((F_CamSequence) fControlUiTrack).Init();
          int num = (int) fControlUiTrack.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiTrack).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_Cam4And5AxisSettings) this).track_2 = buTrack.CopyVisual(((F_CamTriMeshSettings) fControlUiTrack).track_ref, ((F_Cam4And5AxisSettings) this).track_2);
            clsVisualVars.parVisual.hmiTrack2 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiTrack).Settings);
          }
          fControlUiTrack.Dispose();
        }
        if (control.Name == ((F_Cam4And5AxisSettings) this).Progress_1.Name)
        {
          F_ControlUIProgress controlUiProgress = (F_ControlUIProgress) new F_CamParallelCutSettings();
          ((F_CamTriMeshSettings) controlUiProgress).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiProgress1);
          ((F_CamParallelCutSettings) controlUiProgress).Init();
          int num = (int) controlUiProgress.ShowDialog();
          if (((F_CamTriMeshSettings) controlUiProgress).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_Cam4And5AxisSettings) this).Progress_1 = buProgressBar.CopyVisual(((F_CamTriMeshSettings) controlUiProgress).Progress_Ref, ((F_Cam4And5AxisSettings) this).Progress_1);
            clsVisualVars.parVisual.hmiProgress1 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) controlUiProgress).Settings);
          }
          controlUiProgress.Dispose();
        }
        if (control.Name == ((F_Cam4And5AxisSettings) this).Progress_2.Name)
        {
          F_ControlUIProgress controlUiProgress = (F_ControlUIProgress) new F_CamParallelCutSettings();
          ((F_CamTriMeshSettings) controlUiProgress).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiProgress2);
          ((F_CamParallelCutSettings) controlUiProgress).Init();
          int num = (int) controlUiProgress.ShowDialog();
          if (((F_CamTriMeshSettings) controlUiProgress).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_Cam4And5AxisSettings) this).Progress_2 = buProgressBar.CopyVisual(((F_CamTriMeshSettings) controlUiProgress).Progress_Ref, ((F_Cam4And5AxisSettings) this).Progress_2);
            clsVisualVars.parVisual.hmiProgress2 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) controlUiProgress).Settings);
          }
          controlUiProgress.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).\u0002.Name)
        {
          F_ControlUIGroup fControlUiGroup = (F_ControlUIGroup) new F_CamFrontBackAll();
          ((F_CamTriMeshSettings) fControlUiGroup).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiGroup1);
          ((F_CamFrontBackAll) fControlUiGroup).Init();
          int num = (int) fControlUiGroup.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiGroup).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).\u0002 = buGroup.CopyVisual(((F_CamTriMeshSettings) fControlUiGroup).grp_ref, ((F_CamStockOffset) this).\u0002);
            clsVisualVars.parVisual.hmiGroup1 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiGroup).Settings);
          }
          fControlUiGroup.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).\u0001.Name)
        {
          F_ControlUIGroup fControlUiGroup = (F_ControlUIGroup) new F_CamFrontBackAll();
          ((F_CamTriMeshSettings) fControlUiGroup).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiGroup2);
          ((F_CamFrontBackAll) fControlUiGroup).Init();
          int num = (int) fControlUiGroup.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiGroup).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).\u0001 = buGroup.CopyVisual(((F_CamTriMeshSettings) fControlUiGroup).grp_ref, ((F_CamStockOffset) this).\u0001);
            clsVisualVars.parVisual.hmiGroup2 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiGroup).Settings);
          }
          fControlUiGroup.Dispose();
        }
        if (control.Name == ((F_Cam4And5AxisSettings) this).\u0001.Name)
        {
          F_ControlUIGround fControlUiGround = (F_ControlUIGround) new F_ControlUISpin();
          ((F_ColorDrawType) fControlUiGround).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiGround1);
          ((F_ControlUISpin) fControlUiGround).Init();
          int num = (int) fControlUiGround.ShowDialog();
          if (((F_ColorDrawType) fControlUiGround).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_Cam4And5AxisSettings) this).\u0001 = buGround.CopyVisual(((F_CamFrontBackAll) fControlUiGround).Ground_Ref, ((F_Cam4And5AxisSettings) this).\u0001);
            clsVisualVars.parVisual.hmiGround1 = (hmiUISettings) new buEyeShotFunctions(((F_ColorDrawType) fControlUiGround).Settings);
          }
          fControlUiGround.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).\u0002.Name)
        {
          F_ControlUIGround fControlUiGround = (F_ControlUIGround) new F_ControlUISpin();
          ((F_ColorDrawType) fControlUiGround).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiGround2);
          ((F_ControlUISpin) fControlUiGround).Init();
          int num = (int) fControlUiGround.ShowDialog();
          if (((F_ColorDrawType) fControlUiGround).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).\u0002 = buGround.CopyVisual(((F_CamFrontBackAll) fControlUiGround).Ground_Ref, ((F_CamStockOffset) this).\u0002);
            clsVisualVars.parVisual.hmiGround2 = (hmiUISettings) new buEyeShotFunctions(((F_ColorDrawType) fControlUiGround).Settings);
          }
          fControlUiGround.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).\u0004.Name)
        {
          F_ControlUICombo fControlUiCombo = (F_ControlUICombo) new F_Cam4And5AxisSettings();
          ((F_CamTriMeshSettings) fControlUiCombo).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiCombo1);
          ((F_Cam4And5AxisSettings) fControlUiCombo).Init();
          int num = (int) fControlUiCombo.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiCombo).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).\u0004 = buComboBox.CopyVisual(((F_CamTriMeshSettings) fControlUiCombo).Cmb_Ref, ((F_CamStockOffset) this).\u0004);
            clsVisualVars.parVisual.hmiCombo1 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiCombo).Settings);
          }
          fControlUiCombo.Dispose();
        }
        if (control.Name == ((F_CamTable) this).\u0002.Name)
        {
          F_ControlUIPanel fControlUiPanel = (F_ControlUIPanel) new F_ControlUIButton();
          ((F_CamTriMeshSettings) fControlUiPanel).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiPanel1);
          ((F_ControlUIButton) fControlUiPanel).Init();
          int num = (int) fControlUiPanel.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiPanel).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTable) this).\u0002 = buPanel.CopyVisual(((F_CamTriMeshSettings) fControlUiPanel).pnl_ref, ((F_CamTable) this).\u0002);
            clsVisualVars.parVisual.hmiPanel1 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiPanel).Settings);
          }
          fControlUiPanel.Dispose();
        }
        if (control.Name == ((F_CamTable) this).\u0001.Name)
        {
          F_ControlUIPanel fControlUiPanel = (F_ControlUIPanel) new F_ControlUIButton();
          ((F_CamTriMeshSettings) fControlUiPanel).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiPanel2);
          ((F_ControlUIButton) fControlUiPanel).Init();
          int num = (int) fControlUiPanel.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiPanel).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTable) this).\u0001 = buPanel.CopyVisual(((F_CamTriMeshSettings) fControlUiPanel).pnl_ref, ((F_CamTable) this).\u0001);
            clsVisualVars.parVisual.hmiPanel2 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiPanel).Settings);
          }
          fControlUiPanel.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).lbl_coord1.Name | control.Name == ((F_CamParallelCutSettings) this).lbl_coord1val.Name)
        {
          F_ControlUICoordinate controlUiCoordinate = (F_ControlUICoordinate) new F_ControlUIText();
          ((F_ControlUISettings) controlUiCoordinate).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiCoords1);
          ((F_ControlUIText) controlUiCoordinate).Init();
          int num = (int) controlUiCoordinate.ShowDialog();
          if (((F_ControlUISettings) controlUiCoordinate).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).lbl_coord1 = buLabel.CopyVisual(((F_ColorDrawType) controlUiCoordinate).lbl_caption, ((F_CamParallelCutSettings) this).lbl_coord1);
            ((F_CamParallelCutSettings) this).lbl_coord1val = buLabel.CopyVisual(((F_ControlUISettings) controlUiCoordinate).lbl_val, ((F_CamParallelCutSettings) this).lbl_coord1val);
            clsVisualVars.parVisual.hmiCoords1 = (hmiUISettings) new buEyeShotFunctions(((F_ControlUISettings) controlUiCoordinate).Settings);
          }
          controlUiCoordinate.Dispose();
        }
        if (control.Name == ((F_CamParallelCutSettings) this).lbl_coord2.Name | control.Name == ((F_CamParallelCutSettings) this).lbl_coord2val.Name)
        {
          F_ControlUICoordinate controlUiCoordinate = (F_ControlUICoordinate) new F_ControlUIText();
          ((F_ControlUISettings) controlUiCoordinate).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiCoords2);
          ((F_ControlUIText) controlUiCoordinate).Init();
          int num = (int) controlUiCoordinate.ShowDialog();
          if (((F_ControlUISettings) controlUiCoordinate).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamParallelCutSettings) this).lbl_coord2 = buLabel.CopyVisual(((F_ColorDrawType) controlUiCoordinate).lbl_caption, ((F_CamParallelCutSettings) this).lbl_coord2);
            ((F_CamParallelCutSettings) this).lbl_coord2val = buLabel.CopyVisual(((F_ControlUISettings) controlUiCoordinate).lbl_val, ((F_CamParallelCutSettings) this).lbl_coord2val);
            clsVisualVars.parVisual.hmiCoords2 = (hmiUISettings) new buEyeShotFunctions(((F_ControlUISettings) controlUiCoordinate).Settings);
          }
          controlUiCoordinate.Dispose();
        }
        if (control.Name == ((F_Cam4And5AxisSettings) this).spn_speed.Name | control.Name == ((F_Cam4And5AxisSettings) this).lbl_speed.Name | control.Name == ((F_Cam4And5AxisSettings) this).btn_speedminus.Name | control.Name == ((F_Cam4And5AxisSettings) this).btn_speedplus.Name | control.Name == ((F_Cam4And5AxisSettings) this).track_speed.Name)
        {
          F_ControlUISpeeds fControlUiSpeeds = (F_ControlUISpeeds) new F_CamStockOffset();
          ((F_CamTriMeshSettings) fControlUiSpeeds).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiSpeed1);
          ((F_CamStockOffset) fControlUiSpeeds).Init();
          int num = (int) fControlUiSpeeds.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiSpeeds).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_Cam4And5AxisSettings) this).track_speed = buEyeShotFunctions.hmiToBuTrack(((F_CamTriMeshSettings) fControlUiSpeeds).Settings, ((F_Cam4And5AxisSettings) this).track_speed);
            ((F_Cam4And5AxisSettings) this).lbl_speed = buLabel.CopyVisual(((F_CamTriMeshSettings) fControlUiSpeeds).lbl_speed, ((F_Cam4And5AxisSettings) this).lbl_speed);
            ((F_Cam4And5AxisSettings) this).spn_speed = buSpin.CopyVisual(((F_CamTriMeshSettings) fControlUiSpeeds).spn_speed, ((F_Cam4And5AxisSettings) this).spn_speed);
            ((F_Cam4And5AxisSettings) this).btn_speedplus = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiSpeeds).btn_plus, ((F_Cam4And5AxisSettings) this).btn_speedplus);
            ((F_Cam4And5AxisSettings) this).btn_speedminus = buButton.CopyVisual(((F_CamTriMeshSettings) fControlUiSpeeds).btn_minus, ((F_Cam4And5AxisSettings) this).btn_speedminus);
            clsVisualVars.parVisual.hmiSpeed1 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiSpeeds).Settings);
          }
          fControlUiSpeeds.Dispose();
        }
        if (control.Name == ((F_Cam4And5AxisSettings) this).track_2.Name)
        {
          F_ControlUITrack fControlUiTrack = (F_ControlUITrack) new F_CamSequence();
          ((F_CamTriMeshSettings) fControlUiTrack).Settings = (hmiUISettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiTrack2);
          ((F_CamSequence) fControlUiTrack).Init();
          int num = (int) fControlUiTrack.ShowDialog();
          if (((F_CamTriMeshSettings) fControlUiTrack).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_Cam4And5AxisSettings) this).track_2 = buTrack.CopyVisual(((F_CamTriMeshSettings) fControlUiTrack).track_ref, ((F_Cam4And5AxisSettings) this).track_2);
            clsVisualVars.parVisual.hmiTrack2 = (hmiUISettings) new buEyeShotFunctions(((F_CamTriMeshSettings) fControlUiTrack).Settings);
          }
          fControlUiTrack.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).btn_on1.Name)
        {
          F_ControlUIBasic fControlUiBasic = (F_ControlUIBasic) new F_ControlUILabel();
          ((F_CamFrontBackAll) fControlUiBasic).Settings = (hmiUIBasicSettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiOn1);
          ((F_ControlUILabel) fControlUiBasic).Init();
          int num = (int) fControlUiBasic.ShowDialog();
          if (((F_CamFrontBackAll) fControlUiBasic).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).btn_on1.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOn1).Display, ((F_CamStockOffset) this).btn_on1.Display);
            ((F_CamStockOffset) this).btn_on1.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOn1).Display, ((F_CamStockOffset) this).btn_on1.ButtonDownDisplay);
            ((F_CamStockOffset) this).btn_on1.ButtonOverDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOn1).Display, ((F_CamStockOffset) this).btn_on1.ButtonOverDisplay);
            ((F_CamStockOffset) this).btn_on1.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) fControlUiBasic).Settings).Parameters).GeometryArcDiameer;
            clsVisualVars.parVisual.hmiOn1 = (hmiUIBasicSettings) new buEyeShotFunctions(((F_CamFrontBackAll) fControlUiBasic).Settings);
          }
          fControlUiBasic.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).btn_off1.Name)
        {
          F_ControlUIBasic fControlUiBasic = (F_ControlUIBasic) new F_ControlUILabel();
          ((F_CamFrontBackAll) fControlUiBasic).Settings = (hmiUIBasicSettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiOff1);
          ((F_ControlUILabel) fControlUiBasic).Init();
          int num = (int) fControlUiBasic.ShowDialog();
          if (((F_CamFrontBackAll) fControlUiBasic).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).btn_off1.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOff1).Display, ((F_CamStockOffset) this).btn_off1.Display);
            ((F_CamStockOffset) this).btn_off1.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOff1).Display, ((F_CamStockOffset) this).btn_off1.ButtonDownDisplay);
            ((F_CamStockOffset) this).btn_off1.ButtonOverDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOff1).Display, ((F_CamStockOffset) this).btn_off1.ButtonOverDisplay);
            ((F_CamStockOffset) this).btn_off1.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) fControlUiBasic).Settings).Parameters).GeometryArcDiameer;
            clsVisualVars.parVisual.hmiOff1 = (hmiUIBasicSettings) new buEyeShotFunctions(((F_CamFrontBackAll) fControlUiBasic).Settings);
          }
          fControlUiBasic.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).btn_on2.Name)
        {
          F_ControlUIBasic fControlUiBasic = (F_ControlUIBasic) new F_ControlUILabel();
          ((F_CamFrontBackAll) fControlUiBasic).Settings = (hmiUIBasicSettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiOn2);
          ((F_ControlUILabel) fControlUiBasic).Init();
          int num = (int) fControlUiBasic.ShowDialog();
          if (((F_CamFrontBackAll) fControlUiBasic).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).btn_on2.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOn2).Display, ((F_CamStockOffset) this).btn_on2.Display);
            ((F_CamStockOffset) this).btn_on2.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOn2).Display, ((F_CamStockOffset) this).btn_on2.ButtonDownDisplay);
            ((F_CamStockOffset) this).btn_on2.ButtonOverDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOn2).Display, ((F_CamStockOffset) this).btn_on2.ButtonOverDisplay);
            ((F_CamStockOffset) this).btn_on2.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) fControlUiBasic).Settings).Parameters).GeometryArcDiameer;
            clsVisualVars.parVisual.hmiOn2 = (hmiUIBasicSettings) new buEyeShotFunctions(((F_CamFrontBackAll) fControlUiBasic).Settings);
          }
          fControlUiBasic.Dispose();
        }
        if (control.Name == ((F_CamTable) this).btn_off2.Name)
        {
          F_ControlUIBasic fControlUiBasic = (F_ControlUIBasic) new F_ControlUILabel();
          ((F_CamFrontBackAll) fControlUiBasic).Settings = (hmiUIBasicSettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiOff2);
          ((F_ControlUILabel) fControlUiBasic).Init();
          int num = (int) fControlUiBasic.ShowDialog();
          if (((F_CamFrontBackAll) fControlUiBasic).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamTable) this).btn_off2.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOff2).Display, ((F_CamTable) this).btn_off2.Display);
            ((F_CamTable) this).btn_off2.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOff2).Display, ((F_CamTable) this).btn_off2.ButtonDownDisplay);
            ((F_CamTable) this).btn_off2.ButtonOverDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiOff2).Display, ((F_CamTable) this).btn_off2.ButtonOverDisplay);
            ((F_CamTable) this).btn_off2.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) fControlUiBasic).Settings).Parameters).GeometryArcDiameer;
            clsVisualVars.parVisual.hmiOff2 = (hmiUIBasicSettings) new buEyeShotFunctions(((F_CamFrontBackAll) fControlUiBasic).Settings);
          }
          fControlUiBasic.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).\u0080.Name)
        {
          F_ControlUIBasic fControlUiBasic = (F_ControlUIBasic) new F_ControlUILabel();
          ((F_CamFrontBackAll) fControlUiBasic).Settings = (hmiUIBasicSettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiWarning);
          ((F_ControlUILabel) fControlUiBasic).Init();
          int num = (int) fControlUiBasic.ShowDialog();
          if (((F_CamFrontBackAll) fControlUiBasic).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).\u0080.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiWarning).Display, ((F_CamStockOffset) this).\u0080.Display);
            ((F_CamStockOffset) this).\u0080.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) fControlUiBasic).Settings).Parameters).GeometryArcDiameer;
            clsVisualVars.parVisual.hmiWarning = (hmiUIBasicSettings) new buEyeShotFunctions(((F_CamFrontBackAll) fControlUiBasic).Settings);
          }
          fControlUiBasic.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).\u007F.Name)
        {
          F_ControlUIBasic fControlUiBasic = (F_ControlUIBasic) new F_ControlUILabel();
          ((F_CamFrontBackAll) fControlUiBasic).Settings = (hmiUIBasicSettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiError);
          ((F_ControlUILabel) fControlUiBasic).Init();
          int num = (int) fControlUiBasic.ShowDialog();
          if (((F_CamFrontBackAll) fControlUiBasic).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).\u007F.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiError).Display, ((F_CamStockOffset) this).\u007F.Display);
            ((F_CamStockOffset) this).\u007F.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) fControlUiBasic).Settings).Parameters).GeometryArcDiameer;
            clsVisualVars.parVisual.hmiError = (hmiUIBasicSettings) new buEyeShotFunctions(((F_CamFrontBackAll) fControlUiBasic).Settings);
          }
          fControlUiBasic.Dispose();
        }
        if (control.Name == ((F_CamStockOffset) this).\u001F.Name)
        {
          F_ControlUIBasic fControlUiBasic = (F_ControlUIBasic) new F_ControlUILabel();
          ((F_CamFrontBackAll) fControlUiBasic).Settings = (hmiUIBasicSettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiInfo);
          ((F_ControlUILabel) fControlUiBasic).Init();
          int num = (int) fControlUiBasic.ShowDialog();
          if (((F_CamFrontBackAll) fControlUiBasic).PropertiesForm.Result == DialogResult.OK)
          {
            ((F_CamStockOffset) this).\u001F.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiInfo).Display, ((F_CamStockOffset) this).\u001F.Display);
            ((F_CamStockOffset) this).\u001F.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) fControlUiBasic).Settings).Parameters).GeometryArcDiameer;
            clsVisualVars.parVisual.hmiInfo = (hmiUIBasicSettings) new buEyeShotFunctions(((F_CamFrontBackAll) fControlUiBasic).Settings);
          }
          fControlUiBasic.Dispose();
        }
        if (!(control.Name == ((F_CamStockOffset) this).\u001E.Name))
          return;
        F_ControlUIBasic fControlUiBasic1 = (F_ControlUIBasic) new F_ControlUILabel();
        ((F_CamFrontBackAll) fControlUiBasic1).Settings = (hmiUIBasicSettings) new buEyeShotFunctions(clsVisualVars.parVisual.hmiStatus);
        ((F_ControlUILabel) fControlUiBasic1).Init();
        int num1 = (int) fControlUiBasic1.ShowDialog();
        if (((F_CamFrontBackAll) fControlUiBasic1).PropertiesForm.Result == DialogResult.OK)
        {
          ((F_CamStockOffset) this).\u001E.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiStatus).Display, ((F_CamStockOffset) this).\u001E.Display);
          ((F_CamStockOffset) this).\u001E.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) fControlUiBasic1).Settings).Parameters).GeometryArcDiameer;
          clsVisualVars.parVisual.hmiStatus = (hmiUIBasicSettings) new buEyeShotFunctions(((F_CamFrontBackAll) fControlUiBasic1).Settings);
        }
        fControlUiBasic1.Dispose();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    DataGridView dataGridView = obj0 as DataGridView;
    if (dataGridView.Name == ((F_CamParallelCutSettings) this).\u0002.Name)
    {
      F_ControlUIDataGridView controlUiDataGridView = (F_ControlUIDataGridView) new F_ColorType();
      ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref = buEyeShotFunctions.hmiToDataGridView(clsVisualVars.parVisual.hmiDGV1, ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref);
      ((F_CamTriMeshSettings) controlUiDataGridView).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      ((F_ColorType) controlUiDataGridView).Init();
      int num = (int) controlUiDataGridView.ShowDialog();
      if (((F_CamTriMeshSettings) controlUiDataGridView).PropertiesForm.Result == DialogResult.OK)
      {
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorHeader = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.ColumnHeadersDefaultCellStyle.BackColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorHeaderFore = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontHeader = new Font(((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontHeader.Name, ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontHeader.Size, ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontHeader.Style);
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorHeaderFore = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.RowHeadersDefaultCellStyle.ForeColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorHeader = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.RowHeadersDefaultCellStyle.BackColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorGrid = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.GridColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorBackGround = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.BackgroundColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorCellSelected = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.DefaultCellStyle.SelectionBackColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorFore = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.DefaultCellStyle.SelectionForeColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontCell = new Font(((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontCell.Name, ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontCell.Size, ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontCell.Style);
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorCell = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.DefaultCellStyle.BackColor;
        ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).colorFore = ((F_CamTriMeshSettings) controlUiDataGridView).dgv_ref.DefaultCellStyle.ForeColor;
        ((F_CamParallelCutSettings) this).\u0002 = buEyeShotFunctions.hmiToDataGridView(clsVisualVars.parVisual.hmiDGV1, ((F_CamParallelCutSettings) this).\u0002);
      }
      controlUiDataGridView.Dispose();
    }
    if (!(dataGridView.Name == ((F_CamParallelCutSettings) this).\u0001.Name))
      return;
    F_ControlUIDataGridView controlUiDataGridView1 = (F_ControlUIDataGridView) new F_ColorType();
    ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref = buEyeShotFunctions.hmiToDataGridView(clsVisualVars.parVisual.hmiDGV2, ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref);
    ((F_CamTriMeshSettings) controlUiDataGridView1).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    ((F_ColorType) controlUiDataGridView1).Init();
    int num1 = (int) controlUiDataGridView1.ShowDialog();
    if (((F_CamTriMeshSettings) controlUiDataGridView1).PropertiesForm.Result == DialogResult.OK)
    {
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorHeader = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.ColumnHeadersDefaultCellStyle.BackColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorHeaderFore = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).fontHeader = new Font(((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontHeader.Name, ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontHeader.Size, ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontHeader.Style);
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorHeaderFore = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.RowHeadersDefaultCellStyle.ForeColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorHeader = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.RowHeadersDefaultCellStyle.BackColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorGrid = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.GridColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorBackGround = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.BackgroundColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorCellSelected = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.DefaultCellStyle.SelectionBackColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorFore = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.DefaultCellStyle.SelectionForeColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).fontCell = new Font(((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontCell.Name, ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontCell.Size, ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV1).fontCell.Style);
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorCell = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.DefaultCellStyle.BackColor;
      ((buFile5.GCodeRead) clsVisualVars.parVisual.hmiDGV2).colorFore = ((F_CamTriMeshSettings) controlUiDataGridView1).dgv_ref.DefaultCellStyle.ForeColor;
      ((F_CamParallelCutSettings) this).\u0001 = buEyeShotFunctions.hmiToDataGridView(clsVisualVars.parVisual.hmiDGV1, ((F_CamParallelCutSettings) this).\u0001);
    }
    controlUiDataGridView1.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buClassViewer5() => F_CamTriMeshSettings.Captions = new List<string>();

  public buClassViewer5()
  {
    ((F_CamTable) this).Value = (ColorDrawType) new CircularSpeedReduction();
    ((F_CamTable) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_ColorDrawType) this);
  }

  public void Init()
  {
    ((F_CamSequence) this).\u0001.Color = ((hmiUIDataGridView) ((F_CamTable) this).Value).Color;
    ((F_CamSequence) this).\u0001.Value = (Decimal) ((hmiUIDataGridView) ((F_CamTable) this).Value).Transperancy;
    ((F_CamSequence) this).\u0002.Value = (Decimal) ((hmiUIDataGridView) ((F_CamTable) this).Value).Thickess;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ColorDrawType) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_CamSequence) this).\u0001.Value > 0M)
      ((hmiUIDataGridView) ((F_CamTable) this).Value).Transperancy = (int) ((F_CamSequence) this).\u0001.Value;
    if (((F_CamSequence) this).\u0002.Value > 0M)
      ((hmiUIDataGridView) ((F_CamTable) this).Value).Thickess = (double) ((F_CamSequence) this).\u0002.Value;
    ((hmiUIDataGridView) ((F_CamTable) this).Value).Color = ((F_CamSequence) this).\u0001.Color;
    this.Dispose();
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.Dispose();

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTable) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTable) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buClassViewer5() => F_CamTable.Captions = new List<string>();

  public buClassViewer5()
  {
    ((F_CamSequence) this).Value = (ColorType) new GeometryTableItem();
    ((F_CamSequence) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_ColorType) this);
  }

  public void Init()
  {
    ((F_CamSequence) this).\u0001.Color = ((hmiUIOptions) ((F_CamSequence) this).Value).Color;
    ((F_CamSequence) this).\u0001.Value = (Decimal) ((hmiUIOptions) ((F_CamSequence) this).Value).Transperancy;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ColorType) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_CamSequence) this).\u0001.Value > 0M)
      ((hmiUIOptions) ((F_CamSequence) this).Value).Transperancy = (int) ((F_CamSequence) this).\u0001.Value;
    ((hmiUIOptions) ((F_CamSequence) this).Value).Color = ((F_CamSequence) this).\u0001.Color;
    this.Dispose();
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.Dispose();

  public event buClassViewer5.ClassViewerEventHandler5 ValueChanged;

  public event EventHandler OkButtonClicked;

  public event EventHandler CancelButtonClicked;

  public delegate void ClassViewerEventHandler5();
}
