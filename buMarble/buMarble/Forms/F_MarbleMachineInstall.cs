// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleMachineInstall
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buCadCamResVer5;
using buCadCamResVer5.Marble;
using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleMachineInstall : Form
{
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal DataGridView \u0001;
  internal ImageList \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  public buButton btn_parkgetpos;
  public buButton btn_g54save;
  public buButton btn_g54open;
  public buButton btn_goposition;
  internal buLabel \u0001;
  internal DataGridView \u0002;
  internal buLabel \u0002;
  public buButton btn_stop;
  internal buLabel \u0003;
  public static byte f000521;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_vertical;
  public buButton btn_horizontal;
  public buButton btn_manuel;
  public buButton btn_main;
  public buTab buTab_Main;
  public TabPage tabPage_mainpage;
  public TabPage tabPage_horizontal;
  public TabPage tabPage_vertical;
  internal TabPage \u0001;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal PictureBox \u0001;
  internal buLabel \u0004;
  internal buLabel \u0005;
  internal buLabel \u0006;
  public buButton btn_calibx;
  public buSpin spn_calibx_measuredeval;
  public buSpin spn_calibx_moveval;
  internal buLabel \u0007;
  internal buLabel \u0008;
  internal buLabel \u000E;
  internal buLabel \u000F;
  internal buLabel \u0010;
  internal buLabel \u0011;
  public buSpin spn_calibx_gear;
  public buSpin spn_calibx_unit;
  public buSpin spn_calibx_pulse;
  public buSpin spn_calibc_pulse;
  public buSpin spn_calibc_gear;
  public buSpin spn_calibc_unit;
  public buButton btn_calibc;
  public buSpin spn_calibc_measuredeval;
  public buSpin spn_calibc_moveval;
  public buSpin spn_caliba_pulse;
  public buSpin spn_caliba_gear;
  public buSpin spn_caliba_unit;
  public buButton btn_caliba;
  public buSpin spn_caliba_measuredeval;
  public buSpin spn_caliba_moveval;
  public buSpin spn_calibz_pulse;
  public buSpin spn_calibz_gear;
  public buSpin spn_calibz_unit;
  public buButton btn_calibz;
  public buSpin spn_calibz_measuredeval;
  public buSpin spn_calibz_moveval;
  public buSpin spn_caliby_pulse;
  public buSpin spn_caliby_gear;
  public buSpin spn_caliby_unit;
  public buButton btn_caliby;
  public buSpin spn_caliby_measuredeval;
  public buSpin spn_caliby_moveval;
  public buSpin spn_kinematicsawdiameter;
  public buSpin spn_kinematicmaterialthickness;
  public buSpin spn_kinematicCDistance;
  internal buLabel \u0012;
  public buButton btn_kinematicccalculate;
  public buSpin spn_kinematicCMeasuredHeight;
  public buSpin spn_kinematicCMeasuredWidth;
  public buSpin spn_kinematicrectheight;
  public buSpin spn_kinematicrectwidth;
  public buSpin spn_kinematicsawthickness;
  public buSpin spn_kinematicoperationZ;
  public buButton btn_kinematiccodecreate;
  public buSpin spn_kinematicrectang;
  public buSpin spn_kinematicAZDistance;
  public buSpin spn_kinematicAMeasuredTargetZ;
  public buSpin spn_kinematicAYDistance;
  internal buLabel \u0013;
  public buButton btn_kinematicAcalculate;
  public buSpin spn_kinematicAMeasuredHeight;
  public buSpin spn_kinematicAMeasuredWidth;
  public buButton btn_apply;
  public buSpin spn_speedMoveXSpeed;
  public buSpin spn_speedMoveXJerk;
  public buSpin spn_speedMoveXAccDec;
  public buSpin spn_speedJogXSpeed;
  public buSpin spn_speedJogXjerk;
  public buSpin spn_speedJogXAccDec;
  internal buLabel \u0014;
  internal buLabel \u0015;
  internal buLabel \u0016;
  internal buLabel \u0017;
  internal buLabel \u0018;
  public buSpin spn_speedMoveCSpeed;
  public buSpin spn_speedMoveCJerk;
  public buSpin spn_speedMoveCAccDec;
  public buSpin spn_speedJogCSpeed;
  public buSpin spn_speedJogCJerk;
  public buSpin spn_speedJogCAccDec;
  public buSpin spn_speedMoveASpeed;
  public buSpin spn_speedMoveAJerk;
  public buSpin spn_speedMoveAAccDec;
  public buSpin spn_speedJogASpeed;
  public buSpin spn_speedJogAJerk;
  public buSpin spn_speedJogAAccDEc;
  public buSpin spn_speedMoveZSpeed;
  public buSpin spn_speedMoveZJerk;
  public buSpin spn_speedMoveZAccDEc;
  public buSpin spn_speedJogZSpeed;
  public buSpin spn_speedJogZJerk;
  public buSpin spn_speedJogZAccDEc;
  public buSpin spn_speedMoveYSpeed;
  public buSpin spn_speedMoveYJerk;
  public buSpin spn_speedMoveYAccDec;
  public buSpin spn_speedJogYSpeed;
  public buSpin spn_speedJogYJerk;
  public buSpin spn_speedJogYAccDEc;
  public buSpin spn_cncG1AccDec;
  public buSpin spn_cncG0AccDec;
  internal buLabel \u0019;
  public buSpin spn_cncJerk;
  public buSpin spn_softlimitnegx;
  public buSpin spn_softlimitposx;
  internal buLabel \u001A;
  public buButton btn_limitenablex;
  public buCheckBox chk_joglimitx;
  public buSpin spn_datalimitnegx;
  public buSpin spn_datalimitposx;
  public buCheckBox chk_softlimitx;
  internal buLabel \u001B;
  internal buLabel \u001C;
  internal buLabel \u001D;
  public buButton btn_limitdisablex;
  internal buLabel \u001E;
  public buButton btn_limitdisabley;
  public buButton btn_limitenabley;
  public buCheckBox chk_joglimity;
  public buSpin spn_datalimitnegy;
  public buSpin spn_datalimitposy;
  public buCheckBox chk_softlimity;
  public buSpin spn_softlimitnegy;
  public buSpin spn_softlimitposy;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  internal buSeparator \u0003;
  internal buSeparator \u0004;
  public buButton btn_limitdisablec;
  public buButton btn_limitenablec;
  public buCheckBox chk_joglimitc;
  public buSpin spn_datalimitnegc;
  public buSpin spn_datalimitposc;
  public buCheckBox chk_softlimitc;
  public buSpin spn_softlimitnegc;
  public buSpin spn_softlimitposc;
  public buButton btn_limitdisablea;
  public buButton btn_limitenablea;
  public buCheckBox chk_joglimita;
  public buSpin spn_datalimitnega;
  public buSpin spn_datalimitposa;
  public buCheckBox chk_softlimita;
  public buSpin spn_softlimitnega;
  public buSpin spn_softlimitposa;
  public buButton btn_limitdisablez;
  public buButton btn_limitenablez;
  public buCheckBox chk_joglimitz;
  public buSpin spn_datalimitnegz;
  public buSpin spn_datalimitposz;
  public buCheckBox chk_softlimitz;
  public buSpin spn_softlimitnegz;
  public buSpin spn_softlimitposz;
  internal buSeparator \u0005;
  internal buSeparator \u0006;
  internal buSeparator \u0007;
  internal buSeparator \u0008;
  internal buSeparator \u000E;
  internal buSeparator \u000F;
  internal buSeparator \u0010;
  internal buSeparator \u0011;
  internal buSeparator \u0012;
  public buButton btn_limitminusgetx;
  public buButton btn_limitplusgetX;
  public buButton btn_limitplusgetC;
  public buButton btn_limitminusgetC;
  public buButton btn_limitplusgetA;
  public buButton btn_limitminusgetA;
  public buButton btn_limitplusgetZ;
  public buButton btn_limitminusgetZ;
  public buButton btn_limitplusgetY;
  public buButton btn_limitminusgetY;
  public buSpin spn_speedJogX2SpeedTime;
  public buSpin spn_speedJogX2SpeedPerc;
  public buSpin spn_speedJogC2SpeedTime;
  public buSpin spn_speedJogC2SpeedPerc;
  public buSpin spn_speedJogA2SpeedTime;
  public buSpin spn_speedJogA2SpeedPerc;
  public buSpin spn_speedJogZ2SpeedTime;
  public buSpin spn_speedJogZ2SpeedPerc;
  public buSpin spn_speedJogY2SpeedTime;
  public buSpin spn_speedJogY2SpeedPerc;
  public buButton btn_positions;
  internal TabPage \u0002;
  public buButton btn_sawparkgetpos;
  public buSpin spn_SawModePositionX;
  public buSpin spn_SawModePositionC;
  public buSpin spn_SawModePositionY;
  public buSpin spn_SawModePositionA;
  public buSpin spn_SawModePositionZ;
  internal buLabel \u001F;
  internal buLabel \u007F;
  internal buLabel \u0080;
  internal buLabel \u0081;
  internal buLabel \u0082;
  internal buLabel \u0083;
  public buButton btn_generalparkgetpos;
  public buSpin spn_generalparkx;
  public buSpin spn_generalparkc;
  public buSpin spn_generalparky;
  public buSpin spn_generalparka;
  public buSpin spn_generalparkz;
  internal buLabel \u0084;
  public buSpin spn_MillingModePositionX;
  public buSpin spn_MillingModePositionC;
  public buSpin spn_MillingModePositionY;
  public buSpin spn_MillingModePositionZ;
  public buSpin spn_MillingModePositionA;
  public buSpin spn_MillingHeadModePositionX;
  public buSpin spn_MillingHeadModePositionC;
  public buSpin spn_MillingHeadModePositionY;
  public buSpin spn_MillingHeadModePositionA;
  public buSpin spn_MillingHeadModePositionZ;
  public buSpin spn_wagonposX;
  public buSpin spn_wagonposA;
  public buSpin spn_wagonposZ;
  public buSpin spn_wagonposC;
  public buSpin spn_wagonposY;
  public buSpin spn_CameraPositionA;
  public buSpin spn_CameraPositionC;
  public buSpin spn_CameraPositionX;
  public buSpin spn_CameraPositionZ;
  public buSpin spn_CameraPositionY;
  public buSpin spn_SawDiaMeasurePositionX;
  public buSpin spn_SawDiaMeasurePositionC;
  public buSpin spn_SawDiaMeasurePositionFastZ;
  public buSpin spn_SawDiaMeasurePositionA;
  public buSpin spn_SawDiaMeasurePositionY;
  public buSpin spn_MillingLenMeasurePositionX;
  public buSpin spn_MillingLenMeasurePositionC;
  public buSpin spn_MillingLenMeasurePositionFastZ;
  public buSpin spn_MillingLenMeasurePositionA;
  public buSpin spn_MillingLenMeasurePositionY;
  public buSpin spn_MillingHeadLenMeasurePositionX;
  public buSpin spn_MillingHeadLenMeasurePositionC;
  public buSpin spn_MillingHeadLenMeasurePositionFastZ;
  public buSpin spn_MillingHeadLenMeasurePositionA;
  public buSpin spn_MillingHeadLenMeasurePositionY;
  public buButton btn_millingheadmeasuregetpos;
  public buButton btn_sawmeasuregetpos;
  public buButton btn_millingmeasuregetpos;
  public buButton btn_wagongetposition;
  public buButton btn_cameragetposition;
  public buButton btn_millingparkgetpos;
  public buButton btn_millingheadparkgetpos;
  internal TabPage \u0003;
  public buButton btn_spindles;
  public buCheckBox chk_SawStopdAtCheck;
  public buCheckBox chk_SawSpeedAtCheck;
  public buSpin spn_SawStartTimerSec;
  public buSpin spn_SawStopTimerSec;
  public buSpin spn_SawMaxSpeed;
  internal buLabel \u0086;
  internal buLabel \u0087;
  public buSpin spn_SpindleCoolAfterStopTimeSec;
  public buCheckBox chk_SpindlePersentageSinglePot;
  public buCheckBox chk_SpindlePersentageFromPLC;
  public buCheckBox chk_SpindleCoolAfterStop;
  public buCheckBox chk_SpindleStopdAtCheck;

  public void FillG54()
  {
    this.\u0001.Rows.Clear();
    for (int index = 0; index <= ((F_MarbleParkList) this).Parks.Count - 1; ++index)
    {
      Image image = this.\u0001.Images[0];
      this.\u0001.Rows.Add(\u0005.\u0003.\u0001((F_MarbleParkList) this, index + 1, image, ((F_MarbleParkList) this).Parks[index].S, ((F_MarbleParkList) this).Parks[index].X, ((F_MarbleParkList) this).Parks[index].Y, ((F_MarbleParkList) this).Parks[index].Z, ((F_MarbleParkList) this).Parks[index].C, ((F_MarbleParkList) this).Parks[index].A));
      this.\u0001.Rows[this.\u0001.Rows.Count - 1].Height = 38;
      this.\u0001.Rows[this.\u0001.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
      if (index == clsAppMarbleVars.varApp.SelectedParkPosition)
        this.\u0001.Rows[this.\u0001.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
    }
    this.\u0002.Rows.Clear();
    Image image1 = (Image) null;
    this.\u0002.Rows.Add(\u0005.\u0003.\u0001((F_MarbleParkList) this, 1, this.\u0001.Images[0], $"{buLangTranslate.preDef.General} {buLangTranslate.preDef.Park}", clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition));
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].Height = 38;
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
    image1 = (Image) null;
    this.\u0002.Rows.Add(\u0005.\u0003.\u0001((F_MarbleParkList) this, 2, this.\u0001.Images[0], $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Change} {buLangTranslate.preDef.Park}", clsAppMarbleVars.varApp.SawModePositionX, clsAppMarbleVars.varApp.SawModePositionY, clsAppMarbleVars.varApp.SawModePositionZ, clsAppMarbleVars.varApp.SawModePositionC, clsAppMarbleVars.varApp.SawModePositionA));
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].Height = 38;
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
    image1 = (Image) null;
    this.\u0002.Rows.Add(\u0005.\u0003.\u0001((F_MarbleParkList) this, 3, this.\u0001.Images[0], $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Change} {buLangTranslate.preDef.Park}", clsAppMarbleVars.varApp.MillingModePositionX, clsAppMarbleVars.varApp.MillingModePositionY, clsAppMarbleVars.varApp.MillingModePositionZ, clsAppMarbleVars.varApp.MillingModePositionC, clsAppMarbleVars.varApp.MillingModePositionA));
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].Height = 38;
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
    image1 = (Image) null;
    this.\u0002.Rows.Add(\u0005.\u0003.\u0001((F_MarbleParkList) this, 4, this.\u0001.Images[0], $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Change} {buLangTranslate.preDef.Park}", clsAppMarbleVars.varApp.MillingHeadModePositionX, clsAppMarbleVars.varApp.MillingHeadModePositionY, clsAppMarbleVars.varApp.MillingHeadModePositionZ, clsAppMarbleVars.varApp.MillingHeadModePositionC, clsAppMarbleVars.varApp.MillingHeadModePositionA));
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].Height = 38;
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
    image1 = (Image) null;
    this.\u0002.Rows.Add(\u0005.\u0003.\u0001((F_MarbleParkList) this, 5, this.\u0001.Images[0], $"{buLangTranslate.preDef.Table} {buLangTranslate.preDef.Park}", clsAppMarbleVars.varApp.WagonUpPositionX, clsAppMarbleVars.varApp.WagonUpPositionY, clsAppMarbleVars.varApp.WagonUpPositionZ, clsAppMarbleVars.varApp.WagonUpPositionC, clsAppMarbleVars.varApp.WagonUpPositionA));
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].Height = 38;
    this.\u0002.Rows[this.\u0002.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_stop.Name && clsAppMarbleVars.cmdMarble != null)
        clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 2);
      if (control.Name == this.btn_ok.Name)
      {
        clsAppMarbleVars.varApp.SelectedParkPosition = ((F_MarbleParkList) this).indexPark;
        ((F_MarbleParkList) this).Apply();
        ((F_MarbleParkList) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleParkList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleParkList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_close.Name | control.Name == this.btn_cancel.Name)
      {
        ((F_MarbleParkList) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleParkList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleParkList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_g54open.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathParks;
        openFileDialog.Multiselect = false;
        openFileDialog.Filter = "Marble G54 File (*.bupark)|*.bupark";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
          buMarbleCalc.varMarbleRunSettings.pathParks = fileInfo.DirectoryName;
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(fileInfo.FullName, ref StringList);
          List<string> CalcList = new List<string>();
          buString.ListToSpecificList("<ParkPositions>", "</ParkPositions>", false, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            ((F_MarbleParkList) this).Parks.Clear();
            for (int index = 0; index <= CalcList.Count - 1; ++index)
              ((F_MarbleParkList) this).Parks.Add(Pnt9DS.DecodeFromString(CalcList[index]));
            this.FillG54();
          }
        }
      }
      if (control.Name == this.btn_g54save.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathParks;
        saveFileDialog.Filter = "Marble G54 File (*.bupark)|*.bupark";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
          buMarbleCalc.varMarbleRunSettings.pathParks = fileInfo.DirectoryName;
          ArrayList StringList = new ArrayList();
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  Marble Park List ");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "<ParkPositions>");
          for (int index = 0; index <= ((F_MarbleParkList) this).Parks.Count - 1; ++index)
            StringList.Add((object) ((F_MarbleParkList) this).Parks[index].ToDef(2));
          StringList.Add((object) "</ParkPositions>");
          buFile.SaveToFile(StringList, saveFileDialog.FileName);
        }
      }
      if (control.Name == this.btn_goposition.Name)
      {
        if (AppBool.Connected & ((F_MarbleParkList) this).indexPark >= 0 & ((F_MarbleParkList) this).ParkSelected)
        {
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[5].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, Position, true);
          }
          Thread.Sleep(300);
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[6].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar, 0.0, Position, true);
          }
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[7].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar, 0.0, Position, true);
          }
          Thread.Sleep(300);
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[4].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar, 0.0, Position, true);
          }
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[3].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar, 0.0, Position, true);
          }
        }
        if (AppBool.Connected & ((F_MarbleParkList) this).indexMachine >= 0 & ((F_MarbleParkList) this).MachineSelected)
        {
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[5].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, Position, true);
          }
          Thread.Sleep(500);
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[6].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar, 0.0, Position, true);
          }
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[7].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar, 0.0, Position, true);
          }
          Thread.Sleep(500);
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[4].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar, 0.0, Position, true);
          }
          if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bAllowToMove)
          {
            double Position = double.Parse(this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[3].Value.ToString());
            clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar, 0.0, Position, true);
          }
        }
      }
      if (!(control.Name == this.btn_parkgetpos.Name))
        return;
      if (AppBool.Connected & ((F_MarbleParkList) this).indexPark >= 0 & ((F_MarbleParkList) this).ParkSelected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[3].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[4].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[5].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[6].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          this.\u0001.Rows[((F_MarbleParkList) this).indexPark].Cells[7].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (!(AppBool.Connected & ((F_MarbleParkList) this).indexMachine >= 0 & ((F_MarbleParkList) this).MachineSelected))
        return;
      DataGridViewCell cell1 = this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[3];
      double num = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
      string str1 = num.ToString();
      cell1.Value = (object) str1;
      DataGridViewCell cell2 = this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[4];
      num = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
      string str2 = num.ToString();
      cell2.Value = (object) str2;
      DataGridViewCell cell3 = this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[5];
      num = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
      string str3 = num.ToString();
      cell3.Value = (object) str3;
      DataGridViewCell cell4 = this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[6];
      num = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
      string str4 = num.ToString();
      cell4.Value = (object) str4;
      DataGridViewCell cell5 = this.\u0002.Rows[((F_MarbleParkList) this).indexMachine].Cells[7];
      num = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      string str5 = num.ToString();
      cell5.Value = (object) str5;
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
    if (dataGridView.Name == this.\u0001.Name)
    {
      ((F_MarbleParkList) this).indexPark = obj1.RowIndex;
      ((F_MarbleParkList) this).ParkSelected = true;
      ((F_MarbleParkList) this).MachineSelected = false;
    }
    if (!(dataGridView.Name == this.\u0002.Name))
      return;
    ((F_MarbleParkList) this).indexMachine = obj1.RowIndex;
    ((F_MarbleParkList) this).ParkSelected = false;
    ((F_MarbleParkList) this).MachineSelected = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMachineInstall() => F_MarbleParkList.Captions = new List<string>();

  public F_MarbleMachineInstall() => \u0005.\u0003.\u0001(this);

  public void Init(int Index)
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.buTab_Main.ItemSize = new Size(1, 1);
    if (clsAppMarbleVars.varRuntime.AxX >= 0 & clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_calibx_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setUnit;
      this.spn_calibx_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setPulse;
      this.spn_calibx_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setGearRatio;
      this.spn_speedJogXSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogXAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogAcc;
      this.spn_speedJogXjerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveXSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveXAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveAcc;
      this.spn_speedMoveXJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveJerk;
      this.spn_speedJogX2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogX2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnegx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnegx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimitx.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimitx.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove;
      ((F_MarbleG54List) this).chk_hardlimitx.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setHardLimitEnable;
    }
    if (clsAppMarbleVars.varRuntime.AxY >= 0 & clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_caliby_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
      this.spn_caliby_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setPulse;
      this.spn_caliby_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setGearRatio;
      this.spn_speedJogYSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogYAccDEc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogAcc;
      this.spn_speedJogYJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveYSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveYAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveAcc;
      this.spn_speedMoveYJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveJerk;
      this.spn_speedJogY2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogY2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposy.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnegy.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposy.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnegy.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimity.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimity.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove;
      ((F_MarbleG54List) this).chk_hardlimity.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setHardLimitEnable;
    }
    if (clsAppMarbleVars.varRuntime.AxZ >= 0 & clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_calibz_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setUnit;
      this.spn_calibz_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setPulse;
      this.spn_calibz_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setGearRatio;
      this.spn_speedJogZSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogZAccDEc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogAcc;
      this.spn_speedJogZJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveZSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveZAccDEc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveAcc;
      this.spn_speedMoveZJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveJerk;
      this.spn_speedJogZ2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogZ2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnegz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnegz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimitz.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimitz.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove;
      ((F_MarbleG54List) this).chk_hardlimitz.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setHardLimitEnable;
    }
    if (clsAppMarbleVars.varRuntime.AxA >= 0 & clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_caliba_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit;
      this.spn_caliba_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse;
      this.spn_caliba_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio;
      this.spn_speedJogASpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogAAccDEc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogAcc;
      this.spn_speedJogAJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveASpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveAAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveAcc;
      this.spn_speedMoveAJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveJerk;
      this.spn_speedJogA2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogA2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposa.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnega.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposa.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnega.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimita.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimita.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove;
      ((F_MarbleG54List) this).chk_hardlimita.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setHardLimitEnable;
    }
    if (clsAppMarbleVars.varRuntime.AxC >= 0 & clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_calibc_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit;
      this.spn_calibc_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse;
      this.spn_calibc_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio;
      this.spn_speedJogCSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogCAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogAcc;
      this.spn_speedJogCJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveCSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveCAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveAcc;
      this.spn_speedMoveCJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveJerk;
      this.spn_speedJogC2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogC2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnegc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnegc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimitc.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimitc.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove;
      ((F_MarbleG54List) this).chk_hardlimitc.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setHardLimitEnable;
    }
    this.spn_cncG0AccDec.Value = clsAppMarbleVars.cMachine.varCNC.setG0Acc;
    this.spn_cncG1AccDec.Value = clsAppMarbleVars.cMachine.varCNC.setG1Acc;
    this.spn_cncJerk.Value = clsAppMarbleVars.cMachine.varCNC.setMaxJerk;
    this.spn_kinematicCDistance.Value = clsMarble.activeKinematic.RotateCenterOffsetOfC.Y;
    this.spn_kinematicAYDistance.Value = clsMarble.activeKinematic.RotateCenterOffsetOfA.Y;
    this.spn_kinematicAZDistance.Value = clsMarble.activeKinematic.RotateCenterOffsetOfA.Z;
    this.spn_kinematicmaterialthickness.Value = clsAppMarbleVars.varInterface.KinCalcMatThickness;
    this.spn_kinematicoperationZ.Value = clsAppMarbleVars.varInterface.KinCalcOperationZ;
    this.spn_kinematicrectang.Value = clsAppMarbleVars.varInterface.KinCalcRectAngle;
    this.spn_kinematicrectwidth.Value = clsAppMarbleVars.varInterface.KinCalcRectWidth;
    this.spn_kinematicrectheight.Value = clsAppMarbleVars.varInterface.KinCalcRectHeight;
    this.spn_kinematicsawdiameter.Value = buMarbleCalc.activeToolSaw.Geometry.Diameter;
    this.spn_kinematicsawthickness.Value = buMarbleCalc.activeToolSaw.Geometry.Thickness;
    this.spn_SawModePositionX.Value = clsAppMarbleVars.varApp.SawModePositionX;
    this.spn_SawModePositionY.Value = clsAppMarbleVars.varApp.SawModePositionY;
    this.spn_SawModePositionZ.Value = clsAppMarbleVars.varApp.SawModePositionZ;
    this.spn_SawModePositionA.Value = clsAppMarbleVars.varApp.SawModePositionA;
    this.spn_SawModePositionC.Value = clsAppMarbleVars.varApp.SawModePositionC;
    this.spn_MillingModePositionX.Value = clsAppMarbleVars.varApp.MillingModePositionX;
    this.spn_MillingModePositionY.Value = clsAppMarbleVars.varApp.MillingModePositionY;
    this.spn_MillingModePositionZ.Value = clsAppMarbleVars.varApp.MillingModePositionZ;
    this.spn_MillingModePositionA.Value = clsAppMarbleVars.varApp.MillingModePositionA;
    this.spn_MillingModePositionC.Value = clsAppMarbleVars.varApp.MillingModePositionC;
    this.spn_MillingHeadModePositionX.Value = clsAppMarbleVars.varApp.MillingHeadModePositionX;
    this.spn_MillingHeadModePositionY.Value = clsAppMarbleVars.varApp.MillingHeadModePositionY;
    this.spn_MillingHeadModePositionZ.Value = clsAppMarbleVars.varApp.MillingHeadModePositionZ;
    this.spn_MillingHeadModePositionA.Value = clsAppMarbleVars.varApp.MillingHeadModePositionA;
    this.spn_MillingHeadModePositionC.Value = clsAppMarbleVars.varApp.MillingHeadModePositionC;
    this.spn_SawDiaMeasurePositionX.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionX;
    this.spn_SawDiaMeasurePositionY.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionY;
    this.spn_SawDiaMeasurePositionFastZ.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionFastZ;
    this.spn_SawDiaMeasurePositionA.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionA;
    this.spn_SawDiaMeasurePositionC.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionC;
    this.spn_MillingLenMeasurePositionX.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionX;
    this.spn_MillingLenMeasurePositionY.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionY;
    this.spn_MillingLenMeasurePositionFastZ.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ;
    this.spn_MillingLenMeasurePositionA.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionA;
    this.spn_MillingLenMeasurePositionC.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionC;
    this.spn_MillingHeadLenMeasurePositionX.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX;
    this.spn_MillingHeadLenMeasurePositionY.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY;
    this.spn_MillingHeadLenMeasurePositionFastZ.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ;
    this.spn_MillingHeadLenMeasurePositionA.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA;
    this.spn_MillingHeadLenMeasurePositionC.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC;
    this.spn_wagonposX.Value = clsAppMarbleVars.varApp.WagonUpPositionX;
    this.spn_wagonposY.Value = clsAppMarbleVars.varApp.WagonUpPositionY;
    this.spn_wagonposZ.Value = clsAppMarbleVars.varApp.WagonUpPositionZ;
    this.spn_wagonposA.Value = clsAppMarbleVars.varApp.WagonUpPositionA;
    this.spn_wagonposC.Value = clsAppMarbleVars.varApp.WagonUpPositionC;
    this.spn_generalparkx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition;
    this.spn_generalparky.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition;
    this.spn_generalparkz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition;
    this.spn_generalparka.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition;
    this.spn_generalparkc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition;
    this.spn_SawMaxSpeed.Value = clsAppMarbleVars.varApp.SawMaxSpeed;
    this.spn_SawStartTimerSec.Value = clsAppMarbleVars.varApp.SawStartTimerSec;
    this.spn_SawStopTimerSec.Value = clsAppMarbleVars.varApp.SawStopTimerSec;
    this.chk_SawSpeedAtCheck.Check = clsAppMarbleVars.varApp.SawSpeedAtCheck;
    this.chk_SawStopdAtCheck.Check = clsAppMarbleVars.varApp.SawSpeedAtCheck;
    ((F_MarbleG54List) this).spn_SpindleMaxSpeed.Value = clsAppMarbleVars.varApp.SpindleMaxSpeed;
    ((F_MarbleG54List) this).spn_SpindleStartTimerSec.Value = clsAppMarbleVars.varApp.SpindleStartTimerSec;
    ((F_MarbleG54List) this).spn_SpindleStopTimerSec.Value = clsAppMarbleVars.varApp.SpindleStopTimerSec;
    this.spn_SpindleCoolAfterStopTimeSec.Value = clsAppMarbleVars.varApp.SpindleCoolAfterStopTimeSec;
    ((F_MarbleG54List) this).chk_SpindleSpeedAtCheck.Check = clsAppMarbleVars.varApp.SpindleSpeedAtCheck;
    this.chk_SpindleStopdAtCheck.Check = clsAppMarbleVars.varApp.SpindleStopdAtCheck;
    this.chk_SpindleCoolAfterStop.Check = clsAppMarbleVars.varApp.SpindleCoolAfterStop;
    this.chk_SpindlePersentageFromPLC.Check = clsAppMarbleVars.varApp.SpindlePersentageFromPLC;
    this.chk_SpindlePersentageSinglePot.Check = clsAppMarbleVars.varApp.SpindlePersentageSinglePot;
    this.MenuButtonColors(Index);
    this.buTab_Main.SelectedIndex = Index;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
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

  public void Apply()
  {
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.buGround1.Controls);
    if (PageIndex == 0)
    {
      this.btn_main.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_main.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_manuel.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_manuel.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      this.btn_horizontal.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_horizontal.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 3)
    {
      this.btn_vertical.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_vertical.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 4)
    {
      this.btn_positions.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_positions.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 5)
      return;
    this.btn_spindles.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_spindles.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_apply.Name)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0 & clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setUnit = this.spn_calibx_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setPulse = this.spn_calibx_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setGearRatio = this.spn_calibx_gear.Value;
        }
        if (clsAppMarbleVars.varRuntime.AxY >= 0 & clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit = this.spn_caliby_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setPulse = this.spn_caliby_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setGearRatio = this.spn_caliby_gear.Value;
          if (clsAppMarbleVars.varRuntime.AxY2 >= 0 & clsAppMarbleVars.varRuntime.AxY2 <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
            clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = !(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit > 0.0 & clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit > 0.0) ? (!(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit < 0.0 & clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit < 0.0) ? -clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit : clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit) : clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
        }
        if (clsAppMarbleVars.varRuntime.AxZ >= 0 & clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setUnit = this.spn_calibz_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setPulse = this.spn_calibz_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setGearRatio = this.spn_calibz_gear.Value;
        }
        if (clsAppMarbleVars.varRuntime.AxA >= 0 & clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = this.spn_caliba_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = this.spn_caliba_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = this.spn_caliba_gear.Value;
        }
        if (clsAppMarbleVars.varRuntime.AxC >= 0 & clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit = this.spn_calibc_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse = this.spn_calibc_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio = this.spn_calibc_gear.Value;
        }
        clsAppMarbleVars.varInterface.MachineInstallationAxesCalib = true;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_calibx.Name && clsAppMarbleVars.varRuntime.AxX >= 0 & clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = this.spn_calibx_unit.Value;
        double calcGearBox = this.spn_calibx_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(this.spn_calibx_moveval.Value, this.spn_calibx_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        this.spn_calibx_unit.Value = calcUnit;
      }
      if (control.Name == this.btn_caliby.Name && clsAppMarbleVars.varRuntime.AxY >= 0 & clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = this.spn_caliby_unit.Value;
        double calcGearBox = this.spn_caliby_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(this.spn_caliby_moveval.Value, this.spn_caliby_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        this.spn_caliby_unit.Value = calcUnit;
      }
      if (control.Name == this.btn_calibz.Name && clsAppMarbleVars.varRuntime.AxZ >= 0 & clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = this.spn_calibz_unit.Value;
        double calcGearBox = this.spn_calibz_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(this.spn_calibz_moveval.Value, this.spn_calibz_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        this.spn_calibz_unit.Value = calcUnit;
      }
      if (control.Name == this.btn_caliba.Name && clsAppMarbleVars.varRuntime.AxA >= 0 & clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = this.spn_caliba_unit.Value;
        double calcGearBox = this.spn_caliba_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(this.spn_caliba_moveval.Value, this.spn_caliba_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        this.spn_caliba_unit.Value = calcUnit;
      }
      if (!(control.Name == this.btn_calibc.Name) || !(clsAppMarbleVars.varRuntime.AxC >= 0 & clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
        return;
      double calcUnit1 = this.spn_calibc_unit.Value;
      double calcGearBox1 = this.spn_calibc_gear.Value;
      clsAppMarbleVars.cMachine.Commands.AxisCalibration(this.spn_calibc_moveval.Value, this.spn_calibc_measuredeval.Value, true, ref calcUnit1, ref calcGearBox1);
      this.spn_calibc_unit.Value = calcUnit1;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_kinematicccalculate.Name)
        this.spn_kinematicCDistance.Value -= (this.spn_kinematicCMeasuredHeight.Value - this.spn_kinematicrectwidth.Value) / 2.0;
      if (control.Name == this.btn_kinematicAcalculate.Name)
      {
        KinematicBase5 kinematicBase5_1 = new KinematicBase5(clsMarble.activeKinematic);
        kinematicBase5_1.RotateCenterOffsetOfC.Y = this.spn_kinematicCDistance.Value;
        kinematicBase5_1.RotateCenterOffsetOfA.Y = this.spn_kinematicAYDistance.Value;
        kinematicBase5_1.RotateCenterOffsetOfA.Z = this.spn_kinematicAZDistance.Value;
        MarbleTempVars.listHorizontalItems.Clear();
        MarbleTempVars.listVerticalItems.Clear();
        MarbleTempVars.ItemsSlice.Clear();
        MarbleTempVars.listHorizontalItems.Add(new marbleCuttingItems(this.spn_kinematicrectwidth.Value, 1, this.spn_kinematicrectang.Value, this.spn_kinematicrectang.Value));
        clsInit.cMarble.doMultiCut(new Pnt6D(), new Pnt6D(), buMarbleCalc.activeToolSaw, MarbleTempVars.listHorizontalItems, MarbleTempVars.listVerticalItems, buMarbleCalc.varOperation, kinematicBase5_1, new EntitiesResolution(), ref MarbleTempVars.ItemsSlice, (MarbleSliceType) 0, this.spn_kinematicrectwidth.Value, this.spn_kinematicrectwidth.Value, true);
        MarbleItem marbleItem = new MarbleItem(MarbleTempVars.ItemsSlice[0]);
        MarbleItemCam marbleItemCam = new MarbleItemCam();
        buEntity.Copy(marbleItem.ItemEntities.WireEntities, ref marbleItemCam.WireEntities);
        clsInit.cMarble.MarblecalcItemCam(buMarbleCalc.activeToolSaw, kinematicBase5_1, (MarbleJob) null, 0, false, new TpPnt9D(), marbleItem, ref marbleItemCam);
        double num1 = Math.Abs(marbleItemCam.CamBase.CamPoints[0].Points[2].P9.Y - marbleItemCam.CamBase.CamPoints[1].Points[2].P9.Y);
        double z1 = marbleItemCam.CamBase.CamPoints[0].Points[3].P9.Z;
        double num2 = this.spn_kinematicAMeasuredWidth.Value - this.spn_kinematicrectwidth.Value;
        double num3 = this.spn_kinematicAMeasuredTargetZ.Value - this.spn_kinematicoperationZ.Value;
        double num4 = 999999.0;
        for (double num5 = kinematicBase5_1.RotateCenterOffsetOfA.Z - 2.0; num5 <= kinematicBase5_1.RotateCenterOffsetOfA.Z + 2.0; num5 += 0.5)
        {
          for (double num6 = kinematicBase5_1.RotateCenterOffsetOfA.Y - 5.0; num6 <= kinematicBase5_1.RotateCenterOffsetOfA.Y + 5.0; num6 += 0.5)
          {
            marbleItemCam.CamBase = (camTp) null;
            KinematicBase5 kinematicBase5_2 = new KinematicBase5(clsMarble.activeKinematic);
            kinematicBase5_2.RotateCenterOffsetOfC.Y = this.spn_kinematicCDistance.Value;
            kinematicBase5_2.RotateCenterOffsetOfA.Y = num6;
            kinematicBase5_2.RotateCenterOffsetOfA.Z = num5;
            clsInit.cMarble.MarblecalcItemCam(buMarbleCalc.activeToolSaw, kinematicBase5_2, (MarbleJob) null, 0, false, new TpPnt9D(), marbleItem, ref marbleItemCam);
            double num7 = Math.Abs(marbleItemCam.CamBase.CamPoints[0].Points[2].P9.Y - marbleItemCam.CamBase.CamPoints[1].Points[2].P9.Y);
            double z2 = marbleItemCam.CamBase.CamPoints[0].Points[3].P9.Z;
            double num8 = Math.Abs(num7 - (num1 + num2) + (z2 - (z1 + num3)));
            if (num8 < num4)
              num4 = num8;
          }
        }
      }
      if (control.Name == this.btn_kinematiccodecreate.Name)
        ;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_limitminusgetx.Name)
      {
        this.spn_datalimitnegx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitnegx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitplusgetX.Name)
      {
        this.spn_datalimitposx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitposx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitminusgetY.Name)
      {
        this.spn_datalimitnegy.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitnegy.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitplusgetY.Name)
      {
        this.spn_datalimitposy.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitposy.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitminusgetZ.Name)
      {
        this.spn_datalimitnegz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitnegz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitplusgetZ.Name)
      {
        this.spn_datalimitposz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitposz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitminusgetA.Name)
      {
        this.spn_datalimitnega.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitnega.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitplusgetA.Name)
      {
        this.spn_datalimitposa.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitposa.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitminusgetC.Name)
      {
        this.spn_datalimitnegc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitnegc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitplusgetC.Name)
      {
        this.spn_datalimitposc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1);
        this.spn_softlimitposc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control.Name == this.btn_limitdisablex.Name)
      {
        this.chk_softlimitx.Check = false;
        this.chk_joglimitx.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitx.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitx.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_limitenablex.Name)
      {
        this.chk_softlimitx.Check = true;
        this.chk_joglimitx.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitx.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitx.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_limitdisabley.Name)
      {
        this.chk_softlimity.Check = false;
        this.chk_joglimity.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimity.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimity.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_limitenabley.Name)
      {
        this.chk_softlimity.Check = true;
        this.chk_joglimity.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimity.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimity.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_limitdisablez.Name)
      {
        this.chk_softlimitz.Check = false;
        this.chk_joglimitz.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitz.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitz.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_limitenablez.Name)
      {
        this.chk_softlimitz.Check = true;
        this.chk_joglimitz.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitz.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitz.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_limitdisablea.Name)
      {
        this.chk_softlimita.Check = false;
        this.chk_joglimita.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimita.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimita.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_limitenablea.Name)
      {
        this.chk_softlimita.Check = true;
        this.chk_joglimita.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimita.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimita.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control.Name == this.btn_limitdisablec.Name)
      {
        this.chk_softlimitc.Check = false;
        this.chk_joglimitc.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitc.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitc.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (!(control.Name == this.btn_limitenablec.Name))
        return;
      this.chk_softlimitc.Check = true;
      this.chk_joglimitc.Check = true;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitc.Check;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitc.Check;
      clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
    }
    catch (Exception ex)
    {
    }
  }
}
