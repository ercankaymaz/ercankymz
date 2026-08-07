// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.clsVisualVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Control;
using devDept.Geometry;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class clsVisualVars
{
  public static clsVisualVars parVisual;
  public hmiUISettings hmiButtonMenu1;
  public hmiUISettings hmiButtonMenu2;
  public hmiUISettings hmiButtonMenu3;
  public hmiUISettings hmiButtonMenu4;
  public hmiUISettings hmiButtonCommand1;
  public hmiUISettings hmiButtonCommand2;
  public hmiUISettings hmiButtonCommand3;
  public hmiUISettings hmiButtonCommand4;
  public hmiUISettings hmiButtonSystem1;
  public hmiUISettings hmiButtonSystem2;
  public hmiUISettings hmiButtonSystem3;
  public hmiUISettings hmiButtonSystem4;
  public hmiUISettings hmiButtonOk;
  public hmiUISettings hmiButtonCancel;
  public hmiUISettings hmiSpin1;
  public hmiUISettings hmiSpin2;
  public hmiUISettings hmiSpin3;
  public hmiUISettings hmiSpin4;
  public hmiUISettings hmiText1;
  public hmiUISettings hmiText2;
  public hmiUISettings hmiText3;
  public hmiUISettings hmiText4;
  public hmiUISettings hmiCheck1;
  public hmiUISettings hmiCheck2;
  public hmiUISettings hmiCheck3;
  public hmiUISettings hmiCheck4;
  public hmiUISettings hmiLabel1;
  public hmiUISettings hmiLabel2;
  public hmiUISettings hmiLabel3;
  public hmiUISettings hmiLabel4;
  public hmiUISettings hmiListbox1;
  public hmiUISettings hmiListbox2;
  public hmiUISettings hmiListbox3;
  public hmiUISettings hmiListbox4;
  public hmiUIDataGridView hmiDGV1;
  public hmiUIDataGridView hmiDGV2;
  public hmiUISettings hmiRadioButton1;
  public hmiUISettings hmiRadioButton2;
  public hmiUISettings hmiRadioButton3;
  public hmiUISettings hmiRadioButton4;
  public hmiUISettings hmiTrack1;
  public hmiUISettings hmiTrack2;
  public hmiUISettings hmiProgress1;
  public hmiUISettings hmiProgress2;
  public hmiUISettings hmiGroup1;
  public hmiUISettings hmiGroup2;
  public hmiUISettings hmiPanel1;
  public hmiUISettings hmiPanel2;
  public hmiUISettings hmiGround1;
  public hmiUISettings hmiGround2;
  public hmiUISettings hmiCombo1;
  public hmiUISettings hmiCombo2;
  public hmiUISettings hmiCombo3;
  public hmiUISettings hmiCombo4;
  public hmiUIBasicSettings hmiOn1;
  public hmiUIBasicSettings hmiOff1;
  public hmiUIBasicSettings hmiOn2;
  public hmiUIBasicSettings hmiOff2;
  public hmiUIBasicSettings hmiWarning;
  public hmiUIBasicSettings hmiError;
  public hmiUIBasicSettings hmiInfo;
  public hmiUIBasicSettings hmiStatus;
  public hmiUISettings hmiPopup1GroundProps;
  public hmiUISettings hmiPopup1GroundTopProps;
  public hmiUISettings hmiPopup1GroundBottomProps;
  public hmiUISettings hmiPopup1LabelsProps;
  public hmiUISettings hmiPopup1TextProps;
  public hmiUISettings hmiPopup1ButtonOk;
  public hmiUISettings hmiPopup1ButtonCancel;
  public hmiUISettings hmiCoords1;
  public hmiUISettings hmiCoords2;
  public hmiUISettings hmiSpeed1;
  public hmiUISettings hmiSpeedTrackSpindle1;
  public hmiUISettings hmiSpeedTrackSpindleDone1;
  public hmiUISettings hmiSpeedTrackSpindleDrawer1;
  public hmiUISettings hmiSpeedLabelSpindle1;
  public hmiUISettings hmiSpeedSpinSpindle1;
  public hmiUISettings hmiSpeedTrackSpindle2;
  public hmiUISettings hmiSpeedTrackSpindleDone2;
  public hmiUISettings hmiSpeedTrackSpindleDrawer2;
  public hmiUISettings hmiSpeedTrackFeed1;
  public hmiUISettings hmiSpeedTrackFeedDone1;
  public hmiUISettings hmiSpeedTrackFeedDrawer1;
  public hmiUISettings hmiSpeedFeedLabelProps;
  public hmiUISettings hmiSpeedSpinsProps;
  public Color colorDataFocus;

  static clsVisualVars()
  {
    buEyeItems.frmMain = (Form) null;
    buEyeItems.viewportCNC = (Design) null;
    buEyeItems.viewportCadCam = (Design) null;
    buEyeItems.viewportDialogs = (Design) null;
    buEyeItems.planeViewportDialogs = Plane.XY;
    buEyeVars.pntMouseMove = new Point3D();
  }
}
