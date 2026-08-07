// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionCommands
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using buControls.Controls;
using buControls.Forms.WinControlForms.Settings;
using buCore;
using buHandler;
using buOpcUA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buMotion;

public class buMotionCommands
{
  public static byte f00006B;
  private static string \u0001 = nameof (buMotionCommands);

  public event MotionCommandEventHandler clickAlarmReset;

  public event MotionActionEventHandler MotionCommandEvents;

  public void SetAxisEnable(CodesysAxis refAxis, bool Condition)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      string callMethod = $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}";
      buLog.addLog("Axis Enable", "Condition : " + Condition.ToString(), callMethod);
      this.writeBOOLVar(CodesysVariableBaseType.Global, Condition, refAxis.Strings.strRuntimeVar + "boolAX.bEnable");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (SetAxisEnable), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void SetAxisHomingDone(CodesysAxis refAxis, bool Condition, string VarName = "")
  {
    try
    {
      if (!AppBool.Connected)
        return;
      string callMethod = $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}";
      buLog.addLog("Axis Hming Done", "Condition : " + Condition.ToString(), callMethod);
      this.writeBOOLVar(CodesysVariableBaseType.Global, Condition, refAxis.Strings.strRuntimeVar + "boolAX.bHomingDone");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (SetAxisHomingDone), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void GoAxisHoming(CodesysAxis refAxis, bool Condition, string VarName = "")
  {
    try
    {
      if (!AppBool.Connected)
        return;
      string callMethod = $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}";
      buLog.addLog("Axis Go Homing", "Condition : " + Condition.ToString(), callMethod);
      this.writeBOOLVar(CodesysVariableBaseType.Global, Condition, refAxis.Strings.strRuntimeVar + "exeAX.GoHoming");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (GoAxisHoming), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void jogForward(CodesysAxis refAxis, double Velocity, bool Condition)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      double Val = refAxis.Jogs.jogVelocity;
      if (Velocity != 0.0)
        Val = Velocity;
      string callMethod = $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}";
      buLog.addLog(nameof (jogForward), $"velJog : {Val.ToString()} - Condition : {Condition.ToString()}", callMethod);
      this.writeLREALVar(CodesysVariableBaseType.Global, Val, refAxis.Strings.strRuntimeVar + "MovePars.velJog");
      this.writeBOOLVar(CodesysVariableBaseType.Global, Condition, refAxis.Strings.strRunExe + "GoFwdJog");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (jogForward), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void jogBackward(CodesysAxis refAxis, double Velocity, bool Condition)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      double Val = refAxis.Jogs.jogVelocity;
      if (Velocity != 0.0)
        Val = Velocity;
      string callMethod = $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}";
      buLog.addLog(nameof (jogBackward), $"velJog : {Val.ToString()} - Condition : {Condition.ToString()}", callMethod);
      this.writeLREALVar(CodesysVariableBaseType.Global, Val, refAxis.Strings.strRuntimeVar + "MovePars.velJog");
      this.writeBOOLVar(CodesysVariableBaseType.Global, Condition, refAxis.Strings.strRunExe + "GoBwdJog");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (jogBackward), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void jogStop(CodesysAxis refAxis)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, refAxis.Strings.strRunExe + "GoBwdJog");
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, refAxis.Strings.strRunExe + "GoFwdJog");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (jogStop), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void moveAbsolute(CodesysAxis refAxis, double Velocity, double Position, bool Condition)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      double Val = refAxis.Moves.moveVelocity;
      if (Velocity != 0.0)
        Val = Velocity;
      string callMethod = $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}";
      buLog.addLog(nameof (moveAbsolute), $"vel: {Val.ToString()} - Pos: {Position.ToString()} - Condition : {Condition.ToString()}", callMethod);
      this.writeLREALVar(CodesysVariableBaseType.Global, Val, refAxis.Strings.strRuntimeVar + "MovePars.velAbsolute");
      this.writeLREALVar(CodesysVariableBaseType.Global, Position, refAxis.Strings.strRuntimeVar + "MovePars.posAbsolute");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, refAxis.Strings.strRunExe + "GoAbs");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (moveAbsolute), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void moveIncremental(
    CodesysAxis refAxis,
    double Velocity,
    double Distance,
    double Dir,
    bool Condition)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      double Val = refAxis.Moves.moveVelocity;
      if (Velocity != 0.0)
        Val = Velocity;
      string callMethod = $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}";
      buLog.addLog(nameof (moveIncremental), $"vel: {Val.ToString()} - Dis: {Distance.ToString()} - Condition : {Condition.ToString()}", callMethod);
      this.writeLREALVar(CodesysVariableBaseType.Global, Val, refAxis.Strings.strRuntimeVar + "MovePars.velRelative");
      this.writeLREALVar(CodesysVariableBaseType.Global, Distance * Dir, refAxis.Strings.strRuntimeVar + "MovePars.posRelative");
      Thread.Sleep(500);
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, refAxis.Strings.strRunExe + "GoRel");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (moveIncremental), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void Stop(CodesysAxis refAxis)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      buLog.addLog("stop", "", $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, refAxis.Strings.strRunExe + nameof (Stop));
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (Stop), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void AutoTest(
    CodesysAxis refAxis,
    double Velocity,
    double Position1,
    double Position2,
    bool Condition)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      double Val = refAxis.Moves.moveVelocity;
      if (Velocity != 0.0)
        Val = Velocity;
      string callMethod = $"{refAxis.Base.baseName} - {refAxis.Base.baseNo.ToString()}";
      buLog.addLog(nameof (AutoTest), $"vel: {Val.ToString()} - Pos1: {Position1.ToString()} - Pos2: {Position2.ToString()} - Condition : {Condition.ToString()}", callMethod);
      this.writeLREALVar(CodesysVariableBaseType.Global, Val, refAxis.Strings.strRuntimeVar + "MovePars.velAbsolute");
      this.writeLREALVar(CodesysVariableBaseType.Global, Position1, refAxis.Strings.strRuntimeVar + "setMisc.TestPosition1");
      this.writeLREALVar(CodesysVariableBaseType.Global, Position2, refAxis.Strings.strRuntimeVar + "setMisc.TestPosition2");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, refAxis.Strings.strRunExe + "GoAutoPosition");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, "moveAbsolute", "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void getAxesEnabled(ref CodesysAxesData refData, ref bool Value, string VarName = "")
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, StringSystem.strSystemRuntimeVar + "boolData.bAxesEnabled", ref Value);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, "getAxesEnabledAll", "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void getHomingDone(ref CodesysAxesData refData, ref bool Value, string VarName = "")
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, StringSystem.strSystemRuntimeVar + "boolData.bHomingDone", ref Value);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (getHomingDone), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void getFileLoaded(ref CodesysAxesData refData, ref bool Value, string VarName = "")
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, StringSystem.strSystemRuntimeVar + "boolData.bFileLoaded", ref Value);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (getFileLoaded), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void getRun(ref CodesysAxesData refData, ref bool Value, string VarName = "")
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, StringSystem.strSystemRuntimeVar + "boolData.bRun", ref Value);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (getRun), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void getPaused(ref CodesysAxesData refData, ref bool Value, string VarName = "")
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, StringSystem.strSystemRuntimeVar + "boolData.bPause", ref Value);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (getPaused), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void StartAuto()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      buLog.addLog(nameof (StartAuto), "", "");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.Start");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (StartAuto), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void Stop()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      buLog.addLog(nameof (Stop), "", "");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.Stop");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (Stop), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void PauseAuto(bool Condition)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      buLog.addLog(nameof (PauseAuto), Condition.ToString(), "");
      if (Condition)
        this.writeBOOLVar(CodesysVariableBaseType.Global, Condition, "sysRun.exeCmd.Pause");
      else
        this.writeBOOLVar(CodesysVariableBaseType.Global, Condition, "sysRun.boolData.bPause");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (PauseAuto), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void SetStateOfCheckBoxControl(Control.ControlCollection Controls, int Index, bool State)
  {
    try
    {
      for (int index = 1; index <= Controls.Count - 1; ++index)
      {
        if (Controls[index].Tag != null)
        {
          if (Controls[index] is buCheckBox)
          {
            int num = int.Parse(Controls[index].Tag.ToString());
            bool flag = true;
            if (((buControl) Controls[index]).Aux.Explanation.Length > 0)
            {
              flag = false;
              if (((buControl) Controls[index]).Aux.Explanation == "DI" | ((buControl) Controls[index]).Aux.Explanation == "DO")
                flag = true;
            }
            if (num == Index & flag)
              ((buCheckBox) Controls[index]).Check = State;
          }
          else if (Controls[index] is CheckBox && int.Parse(Controls[index].Tag.ToString()) == Index)
            ((CheckBox) Controls[index]).Checked = State;
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"Index: {Index.ToString()} - State: {State.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void SetStateOfControlAsImage(
    Control.ControlCollection Controls,
    int SourceIndex,
    string Name,
    Image image)
  {
    try
    {
      for (int index = 1; index <= Controls.Count - 1; ++index)
      {
        if (Controls[index].Tag != null)
        {
          if (Controls[index] is buControl)
          {
            int num = int.Parse(Controls[index].Tag.ToString());
            bool flag = true;
            if (((buControl) Controls[index]).Aux.Explanation.Length > 0)
            {
              flag = false;
              if (((buControl) Controls[index]).Aux.Explanation == "DI" | ((buControl) Controls[index]).Aux.Explanation == "DO")
                flag = true;
            }
            if (num == SourceIndex & flag)
            {
              ((buControl) Controls[index]).Image = image;
              if (Name.Trim().Length > 0)
                Controls[index].Text = Name;
            }
          }
          else if (Controls[index] is Button)
          {
            if (int.Parse(Controls[index].Tag.ToString()) == SourceIndex)
            {
              ((ButtonBase) Controls[index]).Image = image;
              if (Name.Trim().Length > 0)
                Controls[index].Text = Name;
            }
          }
          else if (Controls[index] is PictureBox && int.Parse(Controls[index].Tag.ToString()) == SourceIndex)
            ((PictureBox) Controls[index]).Image = image;
        }
      }
    }
    catch (Exception ex)
    {
      string str = "Index: " + SourceIndex.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void SetStateOfControlAsImage(
    Control.ControlCollection Controls,
    int Index,
    bool State,
    Image image)
  {
    try
    {
      for (int index = 1; index <= Controls.Count - 1; ++index)
      {
        if (Controls[index].Tag != null)
        {
          if (Controls[index] is buControl)
          {
            int num = int.Parse(Controls[index].Tag.ToString());
            bool flag = true;
            if (((buControl) Controls[index]).Aux.Explanation.Length > 0)
            {
              flag = false;
              if (((buControl) Controls[index]).Aux.Explanation == "DI" | ((buControl) Controls[index]).Aux.Explanation == "DO")
                flag = true;
            }
            if (num == Index & flag)
              ((buControl) Controls[index]).Image = image;
          }
          else if (Controls[index] is Button)
          {
            if (int.Parse(Controls[index].Tag.ToString()) == Index)
              ((ButtonBase) Controls[index]).Image = image;
          }
          else if (Controls[index] is PictureBox && int.Parse(Controls[index].Tag.ToString()) == Index)
            ((PictureBox) Controls[index]).Image = image;
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"Index: {Index.ToString()} - State: {State.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void SetStateOfControlAsColor(
    Control.ControlCollection Controls,
    int Index,
    bool State,
    Color onColor,
    Color offColor)
  {
    try
    {
      for (int index = 1; index <= Controls.Count - 1; ++index)
      {
        if (Controls[index].Tag != null)
        {
          if (Controls[index] is buControl)
          {
            int num = int.Parse(Controls[index].Tag.ToString());
            bool flag = true;
            if (((buControl) Controls[index]).Aux.Explanation.Length > 0)
            {
              flag = false;
              if (((buControl) Controls[index]).Aux.Explanation == "DI" | ((buControl) Controls[index]).Aux.Explanation == "DO")
                flag = true;
            }
            if (num == Index & flag)
            {
              if (State)
                ((buControl) Controls[index]).Display.BackColor = onColor;
              else
                ((buControl) Controls[index]).Display.BackColor = offColor;
            }
          }
          else if (Controls[index] != null && int.Parse(Controls[index].Tag.ToString()) == Index)
            Controls[index].BackColor = !State ? offColor : onColor;
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"Index: {Index.ToString()} - State: {State.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void CreateAxesSettingFile(List<CodesysAxesData> AppAxis, ref string Codes)
  {
    Codes = "";
    for (int index = 0; index <= AppAxis.Count - 1; ++index)
    {
      Codes = $"{Codes}<AXIS>{Environment.NewLine}";
      Codes = Codes + AppAxis[index].AxisPar.Sets.ToFileString(1) + Environment.NewLine;
      Codes = Codes + AppAxis[index].AxisPar.Jogs.ToFileString(1) + Environment.NewLine;
      Codes = Codes + AppAxis[index].AxisPar.Moves.ToFileString(1) + Environment.NewLine;
      Codes = Codes + AppAxis[index].AxisPar.Homings.ToFileString(1) + Environment.NewLine;
      Codes = Codes + AppAxis[index].AxisPar.Cnc.ToFileString(1) + Environment.NewLine;
      Codes = Codes + AppAxis[index].AxisPar.Gear.ToFileString(1) + Environment.NewLine;
      Codes = Codes + AppAxis[index].AxisPar.Base.ToFileString(1) + Environment.NewLine;
      Codes = Codes + AppAxis[index].AxisPar.Test.ToFileString(1) + Environment.NewLine;
      Codes = $"{Codes}</AXIS>{Environment.NewLine}";
    }
  }

  public DialogResult ShowCodesysSettings(ref CodesysMachine cMachine)
  {
    string str = nameof (ShowCodesysSettings);
    try
    {
      F_SettingsTreeView settingsTreeView = new F_SettingsTreeView();
      settingsTreeView.CaptionHeader.Clear();
      settingsTreeView.Classes = new List<object>();
      settingsTreeView.Classes.Add((object) new PlcDeviceData(cMachine.PLCSettings));
      settingsTreeView.Classes.Add((object) new setMotionProgramVar(cMachine.ProgramSettings));
      settingsTreeView.Classes.Add((object) new MachineSettings(cMachine.MachineSetting));
      settingsTreeView.Classes.Add((object) new CodesysSystemSets(cMachine.varSystem));
      settingsTreeView.Classes.Add((object) new HandWheelSettings(cMachine.varHandWheel));
      settingsTreeView.Classes.Add((object) new JogSettings(cMachine.varJog));
      settingsTreeView.Init();
      settingsTreeView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) settingsTreeView.ShowDialog();
      if (settingsTreeView.Result == DialogResult.OK)
      {
        cMachine.PLCSettings = new PlcDeviceData((PlcDeviceData) settingsTreeView.Classes[0]);
        cMachine.ProgramSettings = new setMotionProgramVar((setMotionProgramVar) settingsTreeView.Classes[1]);
        cMachine.MachineSetting = new MachineSettings((MachineSettings) settingsTreeView.Classes[2]);
        cMachine.varSystem = new CodesysSystemSets((CodesysSystemSets) settingsTreeView.Classes[3]);
        cMachine.varHandWheel = new HandWheelSettings((HandWheelSettings) settingsTreeView.Classes[4]);
        cMachine.varJog = new JogSettings((JogSettings) settingsTreeView.Classes[5]);
        buLogVer5.addToLog(buMotionCommands.\u0001, str, "Ok", "MachineParameterChanged", 0.0, 0.0, true);
      }
      return settingsTreeView.Result;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionCommands.\u0001, str, "Error", "", 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
      return DialogResult.Cancel;
    }
  }

  public DialogResult ShowAxesSettings(ref CodesysMachine cMachine)
  {
    string str1 = nameof (ShowAxesSettings);
    try
    {
      F_SettingsTreeView settingsTreeView = new F_SettingsTreeView();
      settingsTreeView.CaptionHeader.Clear();
      settingsTreeView.Classes = new List<object>();
      for (int index = 0; index <= cMachine.AppAxis.Count - 1; ++index)
      {
        string str2 = cMachine.AppAxis[index].AxisPar.Base.baseName.Trim();
        if (str2.Length <= 0)
          str2 = (index + 1).ToString() + ".";
        settingsTreeView.CaptionHeader.Add($"{str2} {AppLanguage.CadCamDynamic[266]} - {AppLanguage.CadCamDynamic[105]}");
        CodesysAxis codesysAxis1 = new CodesysAxis();
        CodesysAxis codesysAxis2 = new CodesysAxis(cMachine.AppAxis[index].AxisPar);
        settingsTreeView.Classes.Add((object) codesysAxis2);
      }
      settingsTreeView.CaptionHeader.Add("CNC - " + AppLanguage.CadCamDynamic[105]);
      settingsTreeView.Classes.Add((object) new CodesysCNCSets(cMachine.varCNC));
      settingsTreeView.Init();
      settingsTreeView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) settingsTreeView.ShowDialog();
      if (settingsTreeView.Result == DialogResult.OK)
      {
        for (int index = 0; index <= cMachine.AppAxis.Count - 1; ++index)
          cMachine.AppAxis[index].AxisPar = new CodesysAxis((CodesysAxis) settingsTreeView.Classes[index]);
        cMachine.varCNC = new CodesysCNCSets((CodesysCNCSets) settingsTreeView.Classes[settingsTreeView.Classes.Count - 1]);
        buLogVer5.addToLog(buMotionCommands.\u0001, str1, "Ok", "AxesParameterChanged", 0.0, 0.0, true);
      }
      return settingsTreeView.Result;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionCommands.\u0001, str1, "Error", "", 0.0, 0.0, true);
      buException.throwException(ex, str1, true, "");
      return DialogResult.Cancel;
    }
  }

  public void MarbleSystemBoolConversion(bool[] SystemBoolBlock, ref CodesysMachine Mach)
  {
    if (SystemBoolBlock == null)
      return;
    for (int index = 0; index <= SystemBoolBlock.Length - 1; ++index)
    {
      if (index == 0)
        Mach.runSystem.Alarm = SystemBoolBlock[index];
      if (index == 1)
        Mach.runSystem.Run = SystemBoolBlock[index];
      if (index == 2)
        Mach.runSystem.Pause = SystemBoolBlock[index];
      if (index == 3)
        Mach.runSystem.HomingDone = SystemBoolBlock[index];
      if (index == 4)
        Mach.runSystem.Enabled = SystemBoolBlock[index];
      if (index == 5)
        Mach.runSystem.WarningOccured = SystemBoolBlock[index];
      if (index == 6)
        Mach.runSystem.GantryOk = SystemBoolBlock[index];
      if (index == 7)
        Mach.runSystem.FileLoaded = SystemBoolBlock[index];
      if (index == 8)
        Mach.runSystem.Water = SystemBoolBlock[index];
      if (index == 9)
        Mach.runSystem.Laser = SystemBoolBlock[index];
      if (index == 10)
        Mach.runSystem.Spindle = SystemBoolBlock[index];
      if (index == 11)
        Mach.runSystem.Saw = SystemBoolBlock[index];
      if (index == 12)
        Mach.runSystem.MAcOk = SystemBoolBlock[index];
      if (index == 13)
        Mach.runSystem.InitDone = SystemBoolBlock[index];
      if (index == 14)
        Mach.runSystem.Auto = SystemBoolBlock[index];
      if (index == 15)
        Mach.runSystem.Manuel = SystemBoolBlock[index];
      if (index == 16 /*0x10*/)
        Mach.runSystem.Pens = SystemBoolBlock[index];
      if (index == 17)
        Mach.runSystem.Move = SystemBoolBlock[index];
      if (index == 18)
        Mach.runSystem.RtcpActivated = SystemBoolBlock[index];
      if (index == 19)
        Mach.runSystem.Calculated = SystemBoolBlock[index];
      if (index == 20)
        Mach.runSystem.ToolUpdate = SystemBoolBlock[index];
      if (index == 21)
        Mach.runSystem.SawUpdate = SystemBoolBlock[index];
      if (index == 22)
        Mach.runSystem.PartZero = SystemBoolBlock[index];
      if (index == 23)
        Mach.runSystem.ParameterUpdated = SystemBoolBlock[index];
      if (index == 24)
        Mach.runSystem.HandWheelActivated = SystemBoolBlock[index];
      if (index == 25)
        Mach.runSystem.Finished = SystemBoolBlock[index];
      if (index == 26)
        Mach.runSystem.SimulatedAxes = SystemBoolBlock[index];
      if (index == 27)
        Mach.runSystem.SimulatedIO = SystemBoolBlock[index];
      if (index == 28)
        Mach.runSystem.CameraReady = SystemBoolBlock[index];
      if (index == 29)
        Mach.runSystem.WagonUp = SystemBoolBlock[index];
      if (index == 30)
        Mach.runSystem.SemiAuto = SystemBoolBlock[index];
      if (index == 31 /*0x1F*/)
        Mach.runSystem.CruiseControl = SystemBoolBlock[index];
    }
  }

  public void SetBBB(int Year, int Month, int Day)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, true, "sysSet.BBBSet.bBBBEnable");
      this.writeDINTVar(CodesysVariableBaseType.Persistent, Year, "sysSet.BBBSet.dtTimeBBB.Year");
      this.writeDINTVar(CodesysVariableBaseType.Persistent, Month, "sysSet.BBBSet.dtTimeBBB.Month");
      this.writeDINTVar(CodesysVariableBaseType.Persistent, Day, "sysSet.BBBSet.dtTimeBBB.Day");
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.BBBRun.stpCheckBBB");
      buLog.addLog(nameof (SetBBB));
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (SetBBB), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ResetBBB()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Persistent, false, "sysSet.BBBSet.bBBBEnable");
      this.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.BBBRun.stpCheckBBB");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ResetBBB), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public string CheckBBB()
  {
    try
    {
      int num1 = 0;
      int Val1 = 0;
      int Val2 = 0;
      int Val3 = 0;
      bool Val4 = false;
      if (!AppBool.Connected)
        return "";
      do
      {
        this.readDINTVar(CodesysVariableBaseType.Persistent, "sysSet.BBBSet.dtTimeBBB.Year", ref Val1);
        this.readDINTVar(CodesysVariableBaseType.Persistent, "sysSet.BBBSet.dtTimeBBB.Month", ref Val2);
        this.readDINTVar(CodesysVariableBaseType.Persistent, "sysSet.BBBSet.dtTimeBBB.Day", ref Val3);
        this.readBOOLVar(CodesysVariableBaseType.Persistent, "sysSet.BBBSet.bBBBEnable", ref Val4);
        buLog.addLog(nameof (CheckBBB));
        ++num1;
      }
      while (Val1 <= 1 && num1 <= 3);
      int num2 = Val1 - 2000 + 5;
      string str1 = Val2.ToString();
      string str2 = Val3.ToString();
      if (str1.Length == 1)
        str1 = "0" + str1;
      if (str2.Length == 1)
        str2 = "0" + str2;
      string str3 = Val4 ? "111" : "000";
      return $"1357{num2.ToString()}{str1}{str2}{str3}";
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (CheckBBB), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
      return "";
    }
  }

  public string RemainBBB()
  {
    try
    {
      if (!AppBool.Connected)
        return "";
      int Val = 0;
      this.readDINTVar(CodesysVariableBaseType.Global, "sysRun.BBBRun.diRemainDay", ref Val);
      return Val.ToString();
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (RemainBBB), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
      return "";
    }
  }

  public void DebugCommands(string Command, ref string Result)
  {
    try
    {
      if (Command.ToLower() == "resetbbb")
      {
        this.ResetBBB();
        Result = "Ok";
      }
      else if (Command.ToLower() == "checkbbb")
      {
        string str = this.CheckBBB();
        Result = str + " - Ok";
      }
      else if (Command.ToLower() == "remainbbb")
      {
        string str = this.RemainBBB();
        Result = str + " - Ok";
      }
      else if (Command.ToLower().IndexOf("setbbb(") >= 0)
      {
        string[] strArray = buString.FindStringBetweenTwoChar(Command, "(", ")").Split('-');
        if (strArray != null)
        {
          if (strArray.Length == 3)
          {
            int result1 = 2000;
            int result2 = 1;
            int result3 = 1;
            int.TryParse(strArray[0], out result1);
            int.TryParse(strArray[1], out result2);
            int.TryParse(strArray[2], out result3);
            this.SetBBB(result1, result2, result3);
            Result = "Ok";
          }
          else
            Result = "Date Error = " + strArray.Length.ToString();
        }
        else
          Result = "Error";
      }
      else
        Result = "Error";
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (DebugCommands), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public string MacGetAddress()
  {
    try
    {
      if (!AppBool.Connected)
        return "";
      string Val = "";
      this.readSTRINGVar(CodesysVariableBaseType.Global, "sysRun.miscInfo.sMacFull", ref Val);
      return Val;
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (MacGetAddress), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
      return "";
    }
  }

  public void ReadWatchVariables(ref List<WatchItem> WatchList)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      for (int index = 0; index <= WatchList.Count - 1; ++index)
      {
        if (WatchList[index].Name.Length > 2 & WatchList[index].VarType == VariableType.Bool)
        {
          bool Val = false;
          if (this.readBOOLVar(CodesysVariableBaseType.None, WatchList[index].Name, ref Val) == "Ok")
          {
            WatchList[index].Status = "Ok";
            WatchList[index].CommStatus = true;
          }
          else
          {
            WatchList[index].Status = "Error";
            WatchList[index].CommStatus = false;
          }
          WatchList[index].Value = !Val ? 0.0 : 1.0;
          if (WatchList[index].Value > WatchList[index].MaxValue)
            WatchList[index].MaxValue = WatchList[index].Value;
          if (WatchList[index].Value < WatchList[index].MinValue)
            WatchList[index].MinValue = WatchList[index].Value;
          WatchList[index].ValueString = Val.ToString();
        }
        if (WatchList[index].Name.Length > 2 & WatchList[index].VarType == VariableType.DINT)
        {
          int Val = 0;
          if (this.readDINTVar(CodesysVariableBaseType.None, WatchList[index].Name, ref Val) == "Ok")
          {
            WatchList[index].Status = "Ok";
            WatchList[index].CommStatus = true;
          }
          else
          {
            WatchList[index].Status = "Error";
            WatchList[index].CommStatus = false;
          }
          WatchList[index].ValueString = Val.ToString();
          WatchList[index].Value = (double) Val;
          if ((double) Val > WatchList[index].MaxValue)
            WatchList[index].MaxValue = (double) Val;
          if ((double) Val < WatchList[index].MinValue)
            WatchList[index].MinValue = (double) Val;
        }
        if (WatchList[index].Name.Length > 2 & WatchList[index].VarType == VariableType.LREAL)
        {
          double Val = 0.0;
          if (this.readLREALVar(CodesysVariableBaseType.None, WatchList[index].Name, ref Val) == "Ok")
          {
            WatchList[index].Status = "Ok";
            WatchList[index].CommStatus = true;
          }
          else
          {
            WatchList[index].Status = "Error";
            WatchList[index].CommStatus = false;
          }
          WatchList[index].Value = Val;
          WatchList[index].ValueString = Val.ToString();
          if (Val > WatchList[index].MaxValue)
            WatchList[index].MaxValue = Val;
          if (Val < WatchList[index].MinValue)
            WatchList[index].MinValue = Val;
        }
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadWatchVariables), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void AxisCalibration(
    double SetPosition,
    double MeasuredPosition,
    bool isUnit,
    ref double calcUnit,
    ref double calcGearBox)
  {
    if (!(SetPosition != 0.0 & MeasuredPosition != 0.0))
      return;
    if (isUnit)
    {
      double num = SetPosition / MeasuredPosition;
      calcUnit /= num;
    }
    else
    {
      double num = MeasuredPosition / SetPosition;
      calcGearBox *= num;
    }
  }

  public string WarningDecode(AppWarning warning)
  {
    string str = "";
    if (warning.Axis.Trim().Length > 0)
      str = $"{str}[ {warning.Axis} ]";
    if (warning.Text.Trim().Length > 0)
      str = str.Length <= 0 ? warning.Text : $"{str} - {warning.Text}";
    if (warning.ID != 0)
      str = str.Length <= 0 ? "ID: " + warning.ID.ToString() : $"{str} - ID: {warning.ID.ToString()}";
    if (warning.Option != 0)
      str = str.Length <= 0 ? "Opt: " + warning.Aux.ToString() : $"{str} - Opt: {warning.Option.ToString()}";
    if (warning.Aux.Trim().Length > 0)
      str = str.Length <= 0 ? "Aux: " + warning.Aux : $"{str} - Aux: {warning.Aux}";
    return str;
  }

  public string CoordinateReadModeToString(CoordinateShowMode Mode)
  {
    string str;
    switch (Mode)
    {
      case CoordinateShowMode.Machine:
        str = buLangTranslate.preDef.Machine;
        break;
      case CoordinateShowMode.Part:
        str = buLangTranslate.preDef.Part;
        break;
      case CoordinateShowMode.DistanceToGo:
        str = buLangTranslate.preDef.ToGo;
        break;
      case CoordinateShowMode.Current:
        str = buLangTranslate.preDef.Current;
        break;
      case CoordinateShowMode.Speed:
        str = buLangTranslate.preDef.Speed;
        break;
      case CoordinateShowMode.FollowingError:
        str = buLangTranslate.preDef.FollowingError;
        break;
      default:
        str = buLangTranslate.preDef.Unknown;
        break;
    }
    return str;
  }

  public void ReadAlarmList(ref List<AppAlarm> AlarmList)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      AlarmList.Clear();
      for (int index = 0; index < 10; ++index)
      {
        AppAlarm Alarm = new AppAlarm();
        string Val1 = "";
        string Val2 = "";
        this.readDINTVar(CodesysVariableBaseType.Global, $"sysRun.Alarms.AlarmList[{index.ToString()}].ID", ref Alarm.ID);
        this.readLREALVar(CodesysVariableBaseType.Global, $"sysRun.Alarms.AlarmList[{index.ToString()}].Code", ref Alarm.Code);
        this.readBOOLVar(CodesysVariableBaseType.Global, $"sysRun.Alarms.AlarmList[{index.ToString()}].Occured", ref Alarm.Occured);
        this.readSTRINGVar(CodesysVariableBaseType.Global, $"sysRun.Alarms.AlarmList[{index.ToString()}].AX", ref Val2);
        this.readSTRINGVar(CodesysVariableBaseType.Global, $"sysRun.Alarms.AlarmList[{index.ToString()}].Text", ref Val1);
        if (Alarm.Occured)
        {
          string str = "";
          if (Alarm.ID >= 300 & Alarm.ID < 400)
            str = $"Axis = {Val2} - ";
          else if (Val2.Length > 0)
            str = $"Axis = {Val2} - ";
          Alarm.Text = $"{str}ID : {Alarm.ID.ToString()} - {Val1}";
          AppAlarm.AppendLogFile(AppPath.Log + "\\logAlarm.csv", Alarm);
          AlarmList.Add(Alarm);
        }
        else
          index = 100;
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadAlarmList), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ReadWarningList(ref List<AppWarning> WarningList)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      WarningList.Clear();
      for (int index = 0; index < 50; ++index)
      {
        AppWarning Warning = new AppWarning();
        string Val1 = "";
        string Val2 = "";
        this.readDINTVar(CodesysVariableBaseType.Global, $"sysRun.Warnings.WarningList[{index.ToString()}].ID", ref Warning.ID);
        this.readSTRINGVar(CodesysVariableBaseType.Global, $"sysRun.Warnings.WarningList[{index.ToString()}].Text", ref Val1);
        this.readSTRINGVar(CodesysVariableBaseType.Global, $"sysRun.Warnings.WarningList[{index.ToString()}].AX", ref Val2);
        this.readBOOLVar(CodesysVariableBaseType.Global, $"sysRun.Warnings.WarningList[{index.ToString()}].Occured", ref Warning.Occured);
        if (Warning.Occured)
        {
          Warning.Text = $"AX: [{Val2}] - ID : {Warning.ID.ToString()} - {Val1}";
          WarningList.Add(Warning);
          AppWarning.AppendLogFile(AppPath.Log + "\\logWarning.csv", Warning);
        }
        else
          index = 100;
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadWarningList), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ReadWarningActive(ref AppWarning Warning)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      Warning = new AppWarning();
      this.readDINTVar(CodesysVariableBaseType.Global, "sysRun.Warnings.ActiveWarning.ID", ref Warning.ID);
      this.readSTRINGVar(CodesysVariableBaseType.Global, "sysRun.Warnings.ActiveWarning.Text", ref Warning.Text);
      this.readSTRINGVar(CodesysVariableBaseType.Global, "sysRun.Warnings.ActiveWarning.AX", ref Warning.Axis);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Warnings.ActiveWarning.Occured", ref Warning.Occured);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadWarningActive), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ResetWarningActive()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeBOOLVar(CodesysVariableBaseType.Global, false, "sysRun.Warnings.ActiveWarning.Occured");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ResetWarningActive), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void OpenKollmorgenAlarmFile(
    string FileName,
    ref List<DeviceAlarmWarningInfo> DeviceAlarms)
  {
    try
    {
      FileInfo fileInfo = new FileInfo(FileName);
      DeviceAlarms.Clear();
      DeviceAlarms = new List<DeviceAlarmWarningInfo>();
      if (!fileInfo.Exists)
        return;
      ArrayList arrayList = new ArrayList();
      TextReader textReader = (TextReader) File.OpenText(fileInfo.FullName);
      string str;
      while ((str = textReader.ReadLine()) != null)
      {
        string[] strArray = str.Split(';');
        if (strArray != null && strArray.Length >= 4)
        {
          DeviceAlarmWarningInfo alarmWarningInfo = new DeviceAlarmWarningInfo();
          alarmWarningInfo.AlarmNo = Convert.ToInt32(strArray[0]);
          if (strArray[1].ToLower() == "f")
            alarmWarningInfo.isAlarm = true;
          if (strArray[1].ToLower() == "n")
            alarmWarningInfo.isAlarm = false;
          alarmWarningInfo.AlarmName = strArray[2];
          alarmWarningInfo.AlarmDecstription = strArray[3];
          if (strArray.Length >= 5)
            alarmWarningInfo.AlarmDecstription = $"{alarmWarningInfo.AlarmDecstription} - {strArray[4]}";
          if (strArray.Length >= 6)
            alarmWarningInfo.AlarmDecstription = $"{alarmWarningInfo.AlarmDecstription} - {strArray[5]}";
          if (strArray.Length >= 7)
            alarmWarningInfo.AlarmDecstription = $"{alarmWarningInfo.AlarmDecstription} - {strArray[6]}";
          DeviceAlarms.Add(alarmWarningInfo);
        }
        arrayList.Add((object) str);
      }
      textReader.Close();
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (OpenKollmorgenAlarmFile), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void MatchKollmorgenAlarmWithID(
    double ID,
    List<DeviceAlarmWarningInfo> DeviceAlarms,
    ref string AlarmText)
  {
    try
    {
      for (int index = 0; index <= DeviceAlarms.Count - 1; ++index)
      {
        if ((double) DeviceAlarms[index].AlarmNo == ID && DeviceAlarms[index].isAlarm)
          AlarmText = $"Drive Error = {DeviceAlarms[index].AlarmNo.ToString()} : {DeviceAlarms[index].AlarmName} [ {DeviceAlarms[index].AlarmDecstription} ] ";
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (MatchKollmorgenAlarmWithID), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void resetAlarms()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      buLog.addLog(nameof (resetAlarms), "", "");
      // ISSUE: reference to a compiler-generated field
      if (this.\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.\u0001((object) null, (object) MotionCommands.AlarmReset, "AlarmReser", (object) null);
      }
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.AlarmReset");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.WarningClear");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (resetAlarms), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void resetWarning()
  {
    try
    {
      if (!AppBool.Connected)
        return;
      buLog.addLog(nameof (resetWarning), "", "");
      this.writeBOOLVar(CodesysVariableBaseType.Global, true, "sysRun.exeCmd.WarningClear");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (resetWarning), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ShowAlarmPage(List<AppAlarm> AlarmList)
  {
    if (CodesysMachine.frmAlarm == null)
      return;
    CodesysMachine.frmAlarm.Init(AlarmList);
    CodesysMachine.frmAlarm.Size = new Size(900, 350);
    CodesysMachine.frmAlarm.lst_alarm.Font = new Font(new FontFamily("Arial"), 12f, FontStyle.Bold);
    CodesysMachine.frmAlarm.lst_alarm.ItemHeight = 40;
    CodesysMachine.frmAlarm.Show();
  }

  public void ReadSystemRuntimeVariables(ref SystemRuntime runSystem)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.Alarmmm", ref runSystem.Alarm);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.bRun", ref runSystem.Run);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.bMove", ref runSystem.Move);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.bPause", ref runSystem.Pause);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.bHomingDone", ref runSystem.HomingDone);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.bFileLoaded", ref runSystem.FileLoaded);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.bAxesEnabled", ref runSystem.Enabled);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.ActiveWarning.Occured", ref runSystem.WarningOccured);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.bSimAxis", ref runSystem.SimulatedAxes);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.Alarms.bSimIO", ref runSystem.SimulatedIO);
      this.readLREALVar(CodesysVariableBaseType.Persistent, "sysSet.Feed.FeedOverride", ref runSystem.FeedOverride);
      this.readDINTVar(CodesysVariableBaseType.Global, "sysRun.Alarms.AlarmCount", ref runSystem.AlarmCount);
      this.readDINTVar(CodesysVariableBaseType.Global, "sysRun.Warnings.WarningCount", ref runSystem.WarningCount);
      this.readDINTVar(CodesysVariableBaseType.Global, "sysRun.Status", ref runSystem.Status);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadSystemRuntimeVariables), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ReadCNCRuntimeVariables(ref CncRuntime runCNC)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, "CncRunMaster.boolCNC.bSingleStep", ref runCNC.SingleStep);
      this.readBOOLVar(CodesysVariableBaseType.Global, "sysRun.exeCmd.UpdateToolAtPC", ref runCNC.SingleStep);
      this.readDINTVar(CodesysVariableBaseType.Global, "sysRun.activeData.activeLine", ref runCNC.ActiveLine);
      this.readDINTVar(CodesysVariableBaseType.Global, "sysRun.activeData.activeToolNo", ref runCNC.ActiveTool);
      this.readDINTVar(CodesysVariableBaseType.Global, "sysRun.activeData.activeMCode", ref runCNC.ActiveMCode);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadCNCRuntimeVariables), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ReadAxisGroup(ReadAxisDataBits Bits, ref List<CodesysAxesData> AppAxes)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      List<VariableLREALDef> variableLrealDefList = new List<VariableLREALDef>();
      List<VariableBOOLDef> variableBoolDefList = new List<VariableBOOLDef>();
      for (int index = 0; index <= AppAxes.Count - 1; ++index)
      {
        if (Bits.Position)
          variableLrealDefList.Add(new VariableLREALDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}activeAX.actualPosition"));
        if (Bits.OffsetedPosition & !AppAxes[index].AxisPar.Temps.DontReadOffsetedPosition)
          variableLrealDefList.Add(new VariableLREALDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}activeAX.actualOffsetedPosition"));
        if (Bits.Velocity)
          variableLrealDefList.Add(new VariableLREALDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}activeAX.actualVelocity"));
        if (Bits.Current)
          variableLrealDefList.Add(new VariableLREALDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}activeAX.actualCurrent"));
        if (Bits.FollowingError)
          variableLrealDefList.Add(new VariableLREALDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}activeAX.actualFollowError"));
        if (((typeMinMaxXYZ) Bits).DistanceToGo)
          variableLrealDefList.Add(new VariableLREALDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}activeAX.distanceToGo"));
        if (Bits.Enabled)
          variableBoolDefList.Add(new VariableBOOLDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}boolAX.bEnabled"));
        if (Bits.HomingDone)
          variableBoolDefList.Add(new VariableBOOLDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}boolAX.bHomingDone"));
        if (Bits.StandStill)
          variableBoolDefList.Add(new VariableBOOLDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}boolAX.bStandstill"));
        if (Bits.AxisError)
          variableBoolDefList.Add(new VariableBOOLDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}boolAX.bAxisError"));
        if (Bits.CommOk)
          variableBoolDefList.Add(new VariableBOOLDef($"{CodesysMachine.RootGlobalString}{AppAxes[index].AxisPar.Strings.strRuntimeVar}boolAX.bComOK"));
      }
      if (variableLrealDefList.Count > 0)
      {
        if (CodesysMachine.CommType == CommunicationType.PlcHandler)
          buPLCHandler.ReadMultiVariableLREAL(ref variableLrealDefList);
        if (CodesysMachine.CommType == CommunicationType.OPCUA)
          OPCReadWrite.ReadLREALsValueFromVariables(OpcVars.opcClient.Session, ref variableLrealDefList);
      }
      if (variableBoolDefList.Count > 0)
      {
        if (CodesysMachine.CommType == CommunicationType.PlcHandler)
          buPLCHandler.ReadMultiVariableBOOL(ref variableBoolDefList);
        if (CodesysMachine.CommType == CommunicationType.OPCUA)
          OPCReadWrite.ReadBOOLsValueFromVariables(OpcVars.opcClient.Session, ref variableBoolDefList);
      }
      for (int index1 = 0; index1 <= AppAxes.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= variableLrealDefList.Count - 1; ++index2)
        {
          string name = variableLrealDefList[index2].Name;
          if (name.IndexOf(AppAxes[index1].AxisPar.Strings.strRuntimeVar) >= 0)
          {
            if (name.IndexOf("actualPosition") >= 0)
              AppAxes[index1].AxisPar.Runtime.Actual.actualPosition = variableLrealDefList[index2].Value;
            if (name.IndexOf("actualOffsetedPosition") >= 0)
              AppAxes[index1].AxisPar.Runtime.Actual.actualOffsetedPosition = variableLrealDefList[index2].Value;
            if (name.IndexOf("actualVelocity") >= 0)
              AppAxes[index1].AxisPar.Runtime.Actual.actualVelocity = variableLrealDefList[index2].Value;
            if (name.IndexOf("actualCurrent") >= 0)
              AppAxes[index1].AxisPar.Runtime.Actual.actualCurrent = variableLrealDefList[index2].Value;
            if (name.IndexOf("actualFollowError") >= 0)
              AppAxes[index1].AxisPar.Runtime.Actual.actualFollowError = variableLrealDefList[index2].Value;
            if (name.IndexOf("distanceToGo") >= 0)
              AppAxes[index1].AxisPar.Runtime.Actual.distanceToGo = variableLrealDefList[index2].Value;
          }
        }
        for (int index3 = 0; index3 <= variableBoolDefList.Count - 1; ++index3)
        {
          string name = variableBoolDefList[index3].Name;
          if (name.IndexOf(AppAxes[index1].AxisPar.Strings.strRuntimeVar) >= 0)
          {
            if (name.IndexOf("bEnabled") >= 0)
              AppAxes[index1].AxisPar.Runtime.Bool.bEnabled = variableBoolDefList[index3].Value;
            if (name.IndexOf("bHomingDone") >= 0)
              AppAxes[index1].AxisPar.Runtime.Bool.bHomingDone = variableBoolDefList[index3].Value;
            if (name.IndexOf("bStandstill") >= 0)
              AppAxes[index1].AxisPar.Runtime.Bool.bStandstill = variableBoolDefList[index3].Value;
            if (name.IndexOf("bAxisError") >= 0)
              AppAxes[index1].AxisPar.Runtime.Bool.bAxisError = variableBoolDefList[index3].Value;
            if (name.IndexOf("bComOK") >= 0)
              AppAxes[index1].AxisPar.Runtime.Bool.bComOK = variableBoolDefList[index3].Value;
          }
        }
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, "ReadAxisData", "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ReadAxis(string AxisString, ReadAxisDataBits Bits, ref CodesysAxis Axis)
  {
    this.ReadAxisData(AxisString, Bits.Position, Bits.OffsetedPosition, Bits.Velocity, Bits.Current, Bits.FollowingError, ref Axis.Runtime.Actual);
    this.ReadAxisBoolData(AxisString, Bits.Enabled, Bits.HomingDone, Bits.StandStill, Bits.AxisError, Bits.CommOk, ref Axis.Runtime.Bool);
    this.ReadAxisInput(AxisString, Bits.InputHoming, ((typeMinMaxXYZ) Bits).InputPosLimit, Bits.InputNegLimit, ((typeMinMaxXYZ) Bits).InputCapture, ref Axis.Runtime.Input);
  }

  public void ReadAxisData(
    string AxisString,
    bool Position,
    bool OffsetedPosition,
    bool Velocity,
    bool Current,
    bool FollowingError,
    ref CodesysAxRuntimeActive AxisData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (Position)
        this.readLREALVar(CodesysVariableBaseType.Global, AxisString + "activeAX.actualPosition", ref AxisData.actualPosition);
      if (OffsetedPosition)
        this.readLREALVar(CodesysVariableBaseType.Global, AxisString + "activeAX.actualOffsetedPosition", ref AxisData.actualOffsetedPosition);
      if (Velocity)
        this.readLREALVar(CodesysVariableBaseType.Global, AxisString + "activeAX.actualVelocity", ref AxisData.actualVelocity);
      if (Current)
        this.readLREALVar(CodesysVariableBaseType.Global, AxisString + "activeAX.actualCurrent", ref AxisData.actualCurrent);
      if (!FollowingError)
        return;
      this.readLREALVar(CodesysVariableBaseType.Global, AxisString + "activeAX.actualFollowError", ref AxisData.actualFollowError);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadAxisData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ReadAxisBoolData(
    string AxisString,
    bool Enabled,
    bool HomingDone,
    bool Standstill,
    bool AxisError,
    bool CommOk,
    ref CodesysAxRuntimeBool AxisDataBool)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (Enabled)
        this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "boolAX.bEnabled", ref AxisDataBool.bEnabled);
      if (HomingDone)
        this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "boolAX.bHomingDone", ref AxisDataBool.bHomingDone);
      if (Standstill)
        this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "boolAX.bStandstill", ref AxisDataBool.bStandstill);
      if (AxisError)
        this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "boolAX.bAxisError", ref AxisDataBool.bAxisError);
      if (!CommOk)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "boolAX.bComOK", ref AxisDataBool.bComOK);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadAxisBoolData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ReadAxisInput(
    string AxisString,
    bool eHoming,
    bool ePosLimit,
    bool eNegLimit,
    bool eCapture,
    ref CodesysAxRuntimeInput AxisDataInput)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (eHoming)
        this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "eInputsAX.eHoming", ref AxisDataInput.eHoming);
      if (ePosLimit)
        this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "eInputsAX.ePositiveLimit", ref AxisDataInput.ePositiveLimit);
      if (eNegLimit)
        this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "eInputsAX.eNegativeLimit", ref AxisDataInput.eNegativeLimit);
      if (!eCapture)
        return;
      this.readBOOLVar(CodesysVariableBaseType.Global, AxisString + "eInputsAX.eCapture", ref AxisDataInput.eCapture);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadAxisInput), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void ReadIOData(ref CodesysMachine cMachine)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      for (int index = 0; index <= cMachine.Inputs.Count - 1; ++index)
      {
        this.readDINTVar(CodesysVariableBaseType.None, cMachine.Inputs[index].FullAddress + ".SourceIndex", ref cMachine.Inputs[index].SourceIndex);
        this.readBOOLVar(CodesysVariableBaseType.None, cMachine.Inputs[index].FullAddress + ".Invert", ref cMachine.Inputs[index].Invert);
      }
      for (int index = 0; index <= cMachine.Outputs.Count - 1; ++index)
      {
        this.readDINTVar(CodesysVariableBaseType.None, cMachine.Outputs[index].FullAddress + ".SourceIndex", ref cMachine.Outputs[index].SourceIndex);
        this.readBOOLVar(CodesysVariableBaseType.None, cMachine.Outputs[index].FullAddress + ".Invert", ref cMachine.Outputs[index].Invert);
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (ReadIOData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteAxisData(string AxisString, CodesysAxesData AxisData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Sets, AxisString + "setData.");
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Base, AxisString + "setBase.");
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Cnc, AxisString + "setCnc.");
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Gear, AxisString + "setGear.");
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Homings, AxisString + "setHoming.");
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Jogs, AxisString + "setJog.");
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Moves, AxisString + "setMove.");
      }
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Sets, AxisString + "setData.", OpcVars.opcClient.Session, "");
      OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Base, AxisString + "setBase.", OpcVars.opcClient.Session, "");
      OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Cnc, AxisString + "setCnc.", OpcVars.opcClient.Session, "");
      OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Gear, AxisString + "setGear.", OpcVars.opcClient.Session, "");
      OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Homings, AxisString + "setHoming.", OpcVars.opcClient.Session, "");
      OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Jogs, AxisString + "setJog.", OpcVars.opcClient.Session, "");
      OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Moves, AxisString + "setMove.", OpcVars.opcClient.Session, "");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteAxisData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteAxisData(
    string AxisString,
    CodesysAxesData AxisData,
    bool WriteBase,
    bool WriteCNC,
    bool WriteGear,
    bool WriteHoming,
    bool WriteJog,
    bool WriteMove,
    bool WriteMisc)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      List<string> collection = new List<string>();
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Sets, AxisString + "setData.");
        if (WriteBase)
          buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Base, AxisString + "setBase.");
        if (WriteCNC)
          buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Cnc, AxisString + "setCnc.");
        if (WriteGear)
          buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Gear, AxisString + "setGear.");
        if (WriteHoming)
          buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Homings, AxisString + "setHoming.");
        if (WriteJog)
          buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Jogs, AxisString + "setJog.");
        if (WriteMove)
          buPLCHandler.ClassToPLC((object) AxisData.AxisPar.Moves, AxisString + "setMove.");
        if (WriteMisc)
          buPLCHandler.ClassToPLC((object) AxisData.AxisPar.MiscSet, AxisString + "setMisc.");
      }
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      string plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Sets, AxisString + "setData.", OpcVars.opcClient.Session, "");
      if (OPCReadWrite.ErrorList.Count > 0)
      {
        collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
        OPCReadWrite.ErrorList.Clear();
      }
      if (WriteBase)
      {
        plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Base, AxisString + "setBase.", OpcVars.opcClient.Session, "");
        if (OPCReadWrite.ErrorList.Count > 0)
        {
          collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
          OPCReadWrite.ErrorList.Clear();
        }
      }
      if (WriteCNC)
      {
        plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Cnc, AxisString + "setCnc.", OpcVars.opcClient.Session, "");
        if (OPCReadWrite.ErrorList.Count > 0)
        {
          collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
          OPCReadWrite.ErrorList.Clear();
        }
      }
      if (WriteGear)
      {
        plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Gear, AxisString + "setGear.", OpcVars.opcClient.Session, "");
        if (OPCReadWrite.ErrorList.Count > 0)
        {
          collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
          OPCReadWrite.ErrorList.Clear();
        }
      }
      if (WriteHoming)
      {
        plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Homings, AxisString + "setHoming.", OpcVars.opcClient.Session, "");
        if (OPCReadWrite.ErrorList.Count > 0)
        {
          collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
          OPCReadWrite.ErrorList.Clear();
        }
      }
      if (WriteJog)
      {
        plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Jogs, AxisString + "setJog.", OpcVars.opcClient.Session, "");
        if (OPCReadWrite.ErrorList.Count > 0)
        {
          collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
          OPCReadWrite.ErrorList.Clear();
        }
      }
      if (WriteMove)
      {
        plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Moves, AxisString + "setMove.", OpcVars.opcClient.Session, "");
        if (OPCReadWrite.ErrorList.Count > 0)
        {
          collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
          OPCReadWrite.ErrorList.Clear();
        }
      }
      if (WriteMisc)
      {
        plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.MiscSet, AxisString + "setMisc.", OpcVars.opcClient.Session, "");
        if (OPCReadWrite.ErrorList.Count > 0)
        {
          collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
          OPCReadWrite.ErrorList.Clear();
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (collection.Count <= 0 || this.\u0001 == null)
        return;
      MotionCommandEventArg e = new MotionCommandEventArg(MotionCommands.ShowWarningList, plc, 0.0);
      e.ErrorList.AddRange((IEnumerable<string>) collection);
      // ISSUE: reference to a compiler-generated field
      this.\u0001(e);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteAxisData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteAxisMiscData(string AxisString, CodesysAxesData AxisData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      List<string> collection = new List<string>();
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
        buPLCHandler.ClassToPLC((object) AxisData.AxisPar.MiscSet, AxisString + "setMisc.");
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.MiscSet, AxisString + "setMisc.", OpcVars.opcClient.Session, "");
      string plc = OPCReadWrite.ClassToPLC((object) AxisData.AxisPar.Sets, AxisString + "setData.", OpcVars.opcClient.Session, "");
      if (OPCReadWrite.ErrorList.Count > 0)
      {
        collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
        OPCReadWrite.ErrorList.Clear();
      }
      // ISSUE: reference to a compiler-generated field
      if (collection.Count <= 0 || (this.\u0001 == null ? 0 : (plc != "Ok" ? 1 : 0)) == 0)
        return;
      MotionCommandEventArg e = new MotionCommandEventArg(MotionCommands.ShowWarningList, plc, 0.0);
      e.ErrorList.AddRange((IEnumerable<string>) collection);
      // ISSUE: reference to a compiler-generated field
      this.\u0001(e);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteAxisMiscData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteCNCDataFullSTring(string AxisString, CodesysCNCSets CNCData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      List<string> collection = new List<string>();
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
        buPLCHandler.ClassToPLC((object) CNCData, AxisString);
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      string plc = OPCReadWrite.ClassToPLC((object) CNCData, AxisString, OpcVars.opcClient.Session, "");
      if (OPCReadWrite.ErrorList.Count > 0)
      {
        collection.AddRange((IEnumerable<string>) OPCReadWrite.ErrorList);
        OPCReadWrite.ErrorList.Clear();
      }
      // ISSUE: reference to a compiler-generated field
      if (collection.Count <= 0 || (this.\u0001 == null ? 0 : (plc != "Ok" ? 1 : 0)) == 0)
        return;
      MotionCommandEventArg e = new MotionCommandEventArg(MotionCommands.ShowWarningList, plc, 0.0);
      e.ErrorList.AddRange((IEnumerable<string>) collection);
      // ISSUE: reference to a compiler-generated field
      this.\u0001(e);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteCNCDataFullSTring), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteCNCData(string AxisString, CodesysCNCSets CNCData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      List<string> stringList = new List<string>();
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
        buPLCHandler.ClassToPLC((object) CNCData, AxisString + "CncSetMaster.");
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      OPCReadWrite.ClassToPLC((object) CNCData, AxisString + "CncSetMaster.", OpcVars.opcClient.Session, "");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteCNCData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteCNCData(string AxisString, string Index, CodesysCNCSets CNCData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      List<string> stringList = new List<string>();
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
        buPLCHandler.ClassToPLC((object) CNCData, $"{AxisString}CncSetMaster{Index}.");
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      OPCReadWrite.ClassToPLC((object) CNCData, $"{AxisString}CncSetMaster{Index}.", OpcVars.opcClient.Session, "");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteCNCData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteSystemData(string pathtring, CodesysSystemSets SystemData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      List<string> stringList = new List<string>();
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        buPLCHandler.ClassToPLC((object) SystemData.Feed, pathtring + "sysSet.Feed.");
        buPLCHandler.ClassToPLC((object) SystemData.Spindle, pathtring + "sysSet.Spindle.");
        buPLCHandler.ClassToPLC((object) SystemData.SpindleSaw, pathtring + "sysSet.SpindleSaw.");
        buPLCHandler.ClassToPLC((object) SystemData.Times, pathtring + "sysSet.Times.");
        buPLCHandler.ClassToPLC((object) SystemData.Tool, pathtring + "sysSet.Tool.");
        buPLCHandler.ClassToPLC((object) SystemData.Offset, pathtring + "sysSet.Offset.");
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        OPCReadWrite.ClassToPLC((object) SystemData.Feed, pathtring + "sysSet.Feed.", OpcVars.opcClient.Session, "");
        OPCReadWrite.ClassToPLC((object) SystemData.Spindle, pathtring + "sysSet.Spindle.", OpcVars.opcClient.Session, "");
        OPCReadWrite.ClassToPLC((object) SystemData.SpindleSaw, pathtring + "sysSet.SpindleSaw.", OpcVars.opcClient.Session, "");
        OPCReadWrite.ClassToPLC((object) SystemData.Times, pathtring + "sysSet.Times.", OpcVars.opcClient.Session, "");
        OPCReadWrite.ClassToPLC((object) SystemData.Tool, pathtring + "sysSet.Tool.", OpcVars.opcClient.Session, "");
        OPCReadWrite.ClassToPLC((object) SystemData.Offset, pathtring + "sysSet.Offset.", OpcVars.opcClient.Session, "");
      }
      this.writeDINTVar(CodesysVariableBaseType.None, SystemData.EthercatSyncTime, pathtring + "sysSet.EthercatSyncTime");
      this.writeBOOLVar(CodesysVariableBaseType.None, SystemData.EnableAxesAfterInit, pathtring + "sysSet.EnableAxesAfterInit");
      this.writeBOOLVar(CodesysVariableBaseType.None, SystemData.FairLoopMode, pathtring + "sysSet.FairLoopMode");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteSystemData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteSystemData(
    string pathtring,
    CodesysSystemSets SystemData,
    bool WriteFeed,
    bool WriteSpindle,
    bool WriteSpileSaw,
    bool WriteTime,
    bool WriteTool)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      List<string> stringList = new List<string>();
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
      {
        if (WriteFeed)
          buPLCHandler.ClassToPLC((object) SystemData.Feed, pathtring + "sysSet.Feed.");
        if (WriteSpindle)
          buPLCHandler.ClassToPLC((object) SystemData.Spindle, pathtring + "sysSet.Spindle.");
        if (WriteSpileSaw)
          buPLCHandler.ClassToPLC((object) SystemData.SpindleSaw, pathtring + "sysSet.SpindleSaw.");
        if (WriteTime)
          buPLCHandler.ClassToPLC((object) SystemData.Times, pathtring + "sysSet.Times.");
        if (WriteTool)
          buPLCHandler.ClassToPLC((object) SystemData.Tool, pathtring + "sysSet.Tool.");
      }
      if (CodesysMachine.CommType == CommunicationType.OPCUA)
      {
        if (WriteFeed)
          OPCReadWrite.ClassToPLC((object) SystemData.Feed, pathtring + "sysSet.Feed.", OpcVars.opcClient.Session, "");
        if (WriteSpindle)
          OPCReadWrite.ClassToPLC((object) SystemData.Spindle, pathtring + "sysSet.Spindle.", OpcVars.opcClient.Session, "");
        if (WriteSpileSaw)
          OPCReadWrite.ClassToPLC((object) SystemData.SpindleSaw, pathtring + "sysSet.SpindleSaw.", OpcVars.opcClient.Session, "");
        if (WriteTime)
          OPCReadWrite.ClassToPLC((object) SystemData.Times, pathtring + "sysSet.Times.", OpcVars.opcClient.Session, "");
        if (WriteTool)
          OPCReadWrite.ClassToPLC((object) SystemData.Tool, pathtring + "sysSet.Tool.", OpcVars.opcClient.Session, "");
      }
      this.writeDINTVar(CodesysVariableBaseType.None, SystemData.EthercatSyncTime, pathtring + "sysSet.EthercatSyncTime");
      this.writeBOOLVar(CodesysVariableBaseType.None, SystemData.EnableAxesAfterInit, pathtring + "sysSet.EnableAxesAfterInit");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteSystemData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteHandwheelData(string AxisString, HandWheelSettings HandwheelData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
        buPLCHandler.ClassToPLC((object) HandwheelData, AxisString + "HandWheelSet.");
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      OPCReadWrite.ClassToPLC((object) HandwheelData, AxisString + "HandWheelSet.", OpcVars.opcClient.Session, "");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteHandwheelData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteAlarmActionData(string AxisString, AlarmActionSettings AlarmActionData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
        buPLCHandler.ClassToPLC((object) AlarmActionData, AxisString + "AppAlarms.", ".Act");
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      OPCReadWrite.ClassToPLC((object) AlarmActionData, AxisString + "AppAlarms.", OpcVars.opcClient.Session, ".Act");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteAlarmActionData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteJogData(string AxisString, JogSettings JogData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (CodesysMachine.CommType == CommunicationType.PlcHandler)
        buPLCHandler.ClassToPLC((object) JogData, AxisString + "JogSet.");
      if (CodesysMachine.CommType != CommunicationType.OPCUA)
        return;
      OPCReadWrite.ClassToPLC((object) JogData, AxisString + "JogSet.", OpcVars.opcClient.Session, "");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteJogData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteG54Data(string PathString, int G54Count, Pnt9D[] G54List)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.WriteG54Data(PathString, G54Count, true, true, G54List);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteG54Data), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteG54Data(string PathString, int G54Count, Pnt9DS[] G54List)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.WriteG54Data(PathString, G54Count, true, true, G54List);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteG54Data), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteParkData(string PathString, int G54Count, Pnt9DS[] G54List)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.WriteParkData(PathString, G54Count, true, true, G54List);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, "WriteG54Data", "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteG54Data(
    string PathString,
    int G54Count,
    bool WriteABC,
    bool WriteUVW,
    Pnt9D[] G54List)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      for (int index = 0; index <= G54Count - 1; ++index)
      {
        if (index <= 9)
        {
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].X, $"{PathString}sysSet.G54Offset[{index.ToString()}].X");
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].Y, $"{PathString}sysSet.G54Offset[{index.ToString()}].Y");
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].Z, $"{PathString}sysSet.G54Offset[{index.ToString()}].Z");
          if (WriteABC)
          {
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].A, $"{PathString}sysSet.G54Offset[{index.ToString()}].A");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].B, $"{PathString}sysSet.G54Offset[{index.ToString()}].B");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].C, $"{PathString}sysSet.G54Offset[{index.ToString()}].C");
          }
          if (WriteUVW)
          {
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].U, $"{PathString}sysSet.G54Offset[{index.ToString()}].U");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].V, $"{PathString}sysSet.G54Offset[{index.ToString()}].V");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].W, $"{PathString}sysSet.G54Offset[{index.ToString()}].W");
          }
        }
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteG54Data), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteG54Data(
    string PathString,
    int G54Count,
    bool WriteABC,
    bool WriteUVW,
    Pnt9DS[] G54List)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      for (int index = 0; index <= G54Count - 1; ++index)
      {
        if (index <= 9)
        {
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].X, $"{PathString}sysSet.G54Offset[{index.ToString()}].X");
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].Y, $"{PathString}sysSet.G54Offset[{index.ToString()}].Y");
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].Z, $"{PathString}sysSet.G54Offset[{index.ToString()}].Z");
          if (WriteABC)
          {
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].A, $"{PathString}sysSet.G54Offset[{index.ToString()}].A");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].B, $"{PathString}sysSet.G54Offset[{index.ToString()}].B");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].C, $"{PathString}sysSet.G54Offset[{index.ToString()}].C");
          }
          if (WriteUVW)
          {
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].U, $"{PathString}sysSet.G54Offset[{index.ToString()}].U");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].V, $"{PathString}sysSet.G54Offset[{index.ToString()}].V");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].W, $"{PathString}sysSet.G54Offset[{index.ToString()}].W");
          }
        }
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteG54Data), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteIOData(CodesysMachine cMachine)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      for (int index = 0; index <= cMachine.Inputs.Count - 1; ++index)
      {
        this.writeDINTVar(CodesysVariableBaseType.None, cMachine.Inputs[index].SourceIndex, cMachine.Inputs[index].FullAddress + ".SourceIndex");
        this.writeBOOLVar(CodesysVariableBaseType.None, cMachine.Inputs[index].Invert, cMachine.Inputs[index].FullAddress + ".Invert");
      }
      for (int index = 0; index <= cMachine.Outputs.Count - 1; ++index)
      {
        this.writeDINTVar(CodesysVariableBaseType.None, cMachine.Outputs[index].SourceIndex, cMachine.Outputs[index].FullAddress + ".SourceIndex");
        this.writeBOOLVar(CodesysVariableBaseType.None, cMachine.Outputs[index].Invert, cMachine.Outputs[index].FullAddress + ".Invert");
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteIOData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteParkData(
    string PathString,
    int G54Count,
    bool WriteABC,
    bool WriteUVW,
    Pnt9DS[] G54List)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      for (int index = 0; index <= G54Count - 1; ++index)
      {
        if (index <= 9)
        {
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].X, $"{PathString}sysSet.ParkList[{index.ToString()}].X");
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].Y, $"{PathString}sysSet.ParkList[{index.ToString()}].Y");
          this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].Z, $"{PathString}sysSet.ParkList[{index.ToString()}].Z");
          if (WriteABC)
          {
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].A, $"{PathString}sysSet.ParkList[{index.ToString()}].A");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].B, $"{PathString}sysSet.ParkList[{index.ToString()}].B");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].C, $"{PathString}sysSet.ParkList[{index.ToString()}].C");
          }
          if (WriteUVW)
          {
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].U, $"{PathString}sysSet.ParkList[{index.ToString()}].U");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].V, $"{PathString}sysSet.ParkList[{index.ToString()}].V");
            this.writeLREALVar(CodesysVariableBaseType.None, G54List[index].W, $"{PathString}sysSet.ParkList[{index.ToString()}].W");
          }
        }
      }
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteParkData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteToolData(string PathString, ToolBase ToolData)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.WriteToolData(PathString, ToolData, true, true, true, true, true, true, true, true, true, true, true, true, true);
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteToolData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteToolData(
    string PathString,
    ToolBase ToolData,
    bool WriteDiameter,
    bool WriteLenght,
    bool WriteThickness,
    bool WriteSpindleSpeed,
    bool WriteFeed,
    bool WriteMinLength,
    bool WriteNo,
    bool WriteClone,
    bool WriteBroken,
    bool WriteAngularPos,
    bool WritePosition,
    bool WriteOffset,
    bool WriteName)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      if (WriteDiameter)
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Geometry.Diameter, PathString + ".Diameter");
      if (WriteLenght)
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Geometry.Length, PathString + ".Length");
      if (WriteThickness)
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Geometry.Thickness, PathString + ".Thickness");
      if (WriteSpindleSpeed)
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.CamData.SpindleSpeed, PathString + ".SpindleSpeed");
      if (WriteFeed)
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.CamData.FeedSpeed, PathString + ".FeedSpeed");
      if (WriteMinLength)
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Geometry.MinLength, PathString + ".MinLength");
      if (WriteNo)
        this.writeDINTVar(CodesysVariableBaseType.None, ToolData.Data.No, PathString + ".No");
      if (WriteClone)
        this.writeBOOLVar(CodesysVariableBaseType.None, ToolData.Data.Clone, PathString + ".Clone");
      if (WriteBroken)
        this.writeBOOLVar(CodesysVariableBaseType.None, ToolData.Data.Broken, PathString + ".Broken");
      if (WriteAngularPos)
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.AngularPosition, PathString + ".AngularPosition");
      if (WritePosition)
      {
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Position.X, PathString + ".XPosition");
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Position.Y, PathString + ".YPosition");
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Position.Z, PathString + ".ZPosition");
      }
      if (WriteOffset)
      {
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Offset.X, PathString + ".XOffset");
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Offset.Y, PathString + ".YOffset");
        this.writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Offset.Z, PathString + ".ZOffset");
      }
      if (!WriteName)
        return;
      this.writeSTRINGVar(CodesysVariableBaseType.None, ToolData.Data.Name, PathString + ".Name");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteToolData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void WriteKinematicData(string PathString, KinematicBase Kinematic)
  {
    try
    {
      if (!AppBool.Connected)
        return;
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetXYZ.X, PathString + "OffsetXYZ.X");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetXYZ.Y, PathString + "OffsetXYZ.Y");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetXYZ.Z, PathString + "OffsetXYZ.Z");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetABC.A, PathString + "OffsetABC.A");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetABC.B, PathString + "OffsetABC.B");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetABC.C, PathString + "OffsetABC.C");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfA.X, PathString + "RotateCenterOffsetOfA.X");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfA.Y, PathString + "RotateCenterOffsetOfA.Y");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfA.Z, PathString + "RotateCenterOffsetOfA.Z");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfB.X, PathString + "RotateCenterOffsetOfB.X");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfB.Y, PathString + "RotateCenterOffsetOfB.Y");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfB.Z, PathString + "RotateCenterOffsetOfB.Z");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfC.X, PathString + "RotateCenterOffsetOfC.X");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfC.Y, PathString + "RotateCenterOffsetOfC.Y");
      this.writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfC.Z, PathString + "RotateCenterOffsetOfC.Z");
    }
    catch (Exception ex)
    {
      CalculationErrorEventArg CalcError = new CalculationErrorEventArg(true, nameof (WriteKinematicData), "", "Exception", "", "", 0, ex);
      buException.throwException(CalcError, CalcError.ShowMessageBox);
    }
  }

  public void CreateAxesParFileItems(
    CodesysAxesData Axis,
    string AxisTag,
    ref List<string> AxisList)
  {
    AxisList.Add($"<{AxisTag}>");
    AxisList.Add($"Jog;{Axis.AxisPar.Jogs.jogVelocity.ToString()};{Axis.AxisPar.Jogs.jogAcc.ToString()};{Axis.AxisPar.Jogs.jogDec.ToString()};{Axis.AxisPar.Jogs.jogJerk.ToString()};{Axis.AxisPar.Jogs.jogDynamicVelocityFromFeed.ToString()};{Axis.AxisPar.Jogs.jogWithAbsoluteMove.ToString()};{Axis.AxisPar.Jogs.jogOverrideEnable.ToString()};{Axis.AxisPar.Jogs.jogFirstSpeedPersentage.ToString()};{Axis.AxisPar.Jogs.jogSecondSpeedPersentage.ToString()};{Axis.AxisPar.Jogs.jogFirstSpeedTimeSec.ToString()};{Axis.AxisPar.Jogs.jogSecondSpeedTimeSec.ToString()}");
    AxisList.Add($"Move;{Axis.AxisPar.Moves.moveVelocity.ToString()};{Axis.AxisPar.Moves.moveAcc.ToString()};{Axis.AxisPar.Moves.moveDec.ToString()};{Axis.AxisPar.Moves.moveJerk.ToString()};{Axis.AxisPar.Moves.moveDynamicVelocityFromFeed.ToString()};{Axis.AxisPar.Moves.moveOverrideEnable.ToString()}");
    AxisList.Add($"Homing;{Axis.AxisPar.Homings.homingFastVelocity.ToString()};{Axis.AxisPar.Homings.homingSlowVelocity.ToString()};{Axis.AxisPar.Homings.homingSetPosition.ToString()};{Axis.AxisPar.Homings.homingOffset.ToString()};{Axis.AxisPar.Homings.homingAcc.ToString()};{Axis.AxisPar.Homings.homingDec.ToString()};{Axis.AxisPar.Homings.homingJerk.ToString()};{Axis.AxisPar.Homings.homingDelay.ToString()};{Axis.AxisPar.Homings.homingTimeoutSec.ToString()};{Axis.AxisPar.Homings.homingMode.ToString()};{Axis.AxisPar.Homings.homingMethod.ToString()};{Axis.AxisPar.Homings.homingDriveHomeMode.ToString()};{Axis.AxisPar.Homings.homingReverseDir.ToString()};{Axis.AxisPar.Homings.homingSwitchNC.ToString()};{Axis.AxisPar.Homings.homingDisableLimits.ToString()};{Axis.AxisPar.Homings.homingUseSecondSlowSpeed.ToString()};{Axis.AxisPar.Homings.homingAbsoluteHomePosition.ToString()}");
    AxisList.Add($"Set;{Axis.AxisPar.Sets.setUnit.ToString()};{Axis.AxisPar.Sets.setPulse.ToString()};{Axis.AxisPar.Sets.setGearRatio.ToString()};{Axis.AxisPar.Sets.setReverseDirection.ToString()};{Axis.AxisPar.Sets.setEmergencyDec.ToString()};{Axis.AxisPar.Sets.setMaxVelocity.ToString()};{Axis.AxisPar.Sets.setMaxAcc.ToString()};{Axis.AxisPar.Sets.setMaxDec.ToString()};{Axis.AxisPar.Sets.setMaxJerk.ToString()};{Convert.ToInt32((object) Axis.AxisPar.Sets.setRampType).ToString()};{Axis.AxisPar.Sets.setSoftLimitEnable.ToString()};{Axis.AxisPar.Sets.setSoftLimitControlFromPLC.ToString()};{Axis.AxisPar.Sets.setSoftLimitNegative.ToString()};{Axis.AxisPar.Sets.setSoftLimitPositive.ToString()};{Axis.AxisPar.Sets.setSoftLimitErrorDec.ToString()};{Axis.AxisPar.Sets.setSoftLimitErrorDecEnable.ToString()};{Axis.AxisPar.Sets.setSoftLimitErrorMaxDistance.ToString()};{Axis.AxisPar.Sets.setHardLimitEnable.ToString()};{Axis.AxisPar.Sets.setDataLimitNegative.ToString()};{Axis.AxisPar.Sets.setDataLimitPositive.ToString()};{Axis.AxisPar.Sets.setParkPosition.ToString()};{Axis.AxisPar.Sets.setGantryEnable.ToString()};{Axis.AxisPar.Sets.setGantryNumerator.ToString()};{Axis.AxisPar.Sets.setGantryDenumerator.ToString()};{Convert.ToInt32((object) Axis.AxisPar.Sets.setAxesType).ToString()}");
    AxisList.Add($"Base;{Axis.AxisPar.Base.baseChar};{Axis.AxisPar.Base.baseName};{Axis.AxisPar.Base.baseNo.ToString()};{Axis.AxisPar.Base.baseRotaryAxis.ToString()};{Axis.AxisPar.Base.baseUnit}");
    AxisList.Add($"Gear;{Axis.AxisPar.Gear.gearNumerator.ToString()};{Axis.AxisPar.Gear.gearDenominator.ToString()};{Axis.AxisPar.Gear.gearAcc.ToString()};{Axis.AxisPar.Gear.gearDec.ToString()};{Axis.AxisPar.Gear.gearJerk.ToString()}");
    AxisList.Add($"Cnc;{Axis.AxisPar.Cnc.cncMaxFeed.ToString()};{Axis.AxisPar.Cnc.cncMaxAccDec.ToString()};{Axis.AxisPar.Cnc.cncMaxDifferance.ToString()};{Axis.AxisPar.Cnc.cncIncludePathSettings.ToString()};{Axis.AxisPar.Cnc.cncStrictlyHoldAccDecABC.ToString()}");
    AxisList.Add($"Misc;{Axis.AxisPar.MiscSet.TestPosition1.ToString()};{Axis.AxisPar.MiscSet.TestPosition2.ToString()};{Axis.AxisPar.MiscSet.TestReleativePosition.ToString()};{Axis.AxisPar.MiscSet.TestWaitTime.ToString()}");
    AxisList.Add($"</{AxisTag}>");
  }

  public void CreateCodesysDefaultParameters(
    List<DefaultParameter> Parameters,
    string FileName,
    ref List<string> listParameters)
  {
    listParameters.Clear();
    for (int index1 = 0; index1 <= Parameters.Count - 1; ++index1)
    {
      List<VariableDef> getVars = new List<VariableDef>();
      buMotionCommands.GetClassToVariables(((ReadAxisDataBits) Parameters[index1]).Parameter, ref getVars);
      for (int index2 = 0; index2 <= getVars.Count - 1; ++index2)
      {
        string str = $"{((ReadAxisDataBits) Parameters[index1]).Defination}{getVars[index2].Name} := {getVars[index2].Value.ToString()};";
        listParameters.Add(str);
      }
      listParameters.Add(" ");
    }
    if (FileName.Length <= 0)
      return;
    buFile.SaveToFile(listParameters, FileName);
  }

  public void CreateCodesysDefaultParameters(
    object Parameters,
    string FileName,
    ref List<string> listParameters)
  {
    List<VariableDef> getVars = new List<VariableDef>();
    listParameters.Clear();
    buMotionCommands.GetClassToVariables(Parameters, ref getVars);
    for (int index = 0; index <= getVars.Count - 1; ++index)
    {
      string str = $"{getVars[index].Name} := {getVars[index].Value.ToString()}";
      listParameters.Add(str);
    }
    if (FileName.Length <= 0)
      return;
    buFile.SaveToFile(listParameters, FileName);
  }

  public static int GetClassToVariables(object Variable, ref List<VariableDef> getVars)
  {
    int tickCount = Environment.TickCount;
    try
    {
      if (Variable == null)
      {
        int num = (int) MessageBox.Show("Variable is Null - ClassToPLC");
        return -1;
      }
      object obj1 = Variable;
      if (obj1 == null)
        return -1;
      FieldInfo[] fields = obj1.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          FieldInfo fieldInfo = fields[index];
          string name1 = fieldInfo.Name;
          string name2 = fieldInfo.Name;
          if (fieldInfo.FieldType.ToString().IndexOf("List") < 0)
          {
            object obj2 = fieldInfo.GetValue(obj1);
            if (fieldInfo.FieldType.BaseType == typeof (Enum))
            {
              double int32 = (double) Convert.ToInt32(obj2);
              getVars.Add(new VariableDef(name1, (object) int32));
            }
            if (obj2.GetType() == typeof (double))
            {
              double val = Convert.ToDouble(obj2);
              getVars.Add(new VariableDef(name1, (object) val));
            }
            if (obj2.GetType() == typeof (float))
            {
              double single = (double) Convert.ToSingle(obj2);
              getVars.Add(new VariableDef(name1, (object) single));
            }
            if (obj2.GetType() == typeof (int))
            {
              double int32 = (double) Convert.ToInt32(obj2);
              getVars.Add(new VariableDef(name1, (object) int32));
            }
            if (obj2.GetType() == typeof (short))
            {
              double int16 = (double) Convert.ToInt16(obj2);
              getVars.Add(new VariableDef(name1, (object) int16));
            }
            if (obj2.GetType() == typeof (bool))
            {
              bool boolean = Convert.ToBoolean(obj2);
              getVars.Add(new VariableDef(name1, (object) boolean));
            }
            if (obj2.GetType() == typeof (string))
            {
              string val = Convert.ToString(obj2);
              getVars.Add(new VariableDef(name1, (object) val));
            }
          }
        }
      }
      return 1;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, "ClassToPLC", false, "Variable : " + Variable.ToString());
      return -1;
    }
  }

  public static void OpenRuntimeMachine(ref setMotionRuntimeVar varRuntime)
  {
    string str1 = nameof (OpenRuntimeMachine);
    try
    {
      if (new FileInfo(AppPath.Base + "\\_offline.dll").Exists)
        AppBool.Offline = true;
      if (!new DirectoryInfo(AppPath.Base).Exists)
      {
        buLogVer5.addToLog(buMotionCommands.\u0001, str1, "", "Base Path Missing");
        buString.MessageBoxError("Base Path Missing");
      }
      FileInfo fileInfo = new FileInfo(AppPath.Settings + "\\Runtime.prm");
      if (fileInfo.Exists)
      {
        ArrayList AL = new ArrayList();
        TextReader textReader = (TextReader) File.OpenText(fileInfo.FullName);
        string str2;
        while ((str2 = textReader.ReadLine()) != null)
          AL.Add((object) str2);
        textReader.Close();
        buLogVer5.addToLog(buMotionCommands.\u0001, str1, "", "Runtime File Opened");
        try
        {
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) varRuntime);
          if (varRuntime.MachineID <= 0)
          {
            int num = (int) MessageBox.Show("Opppsss Machine ID = 0");
          }
          buLogVer5.addToLog(buMotionCommands.\u0001, str1, "", "Runtime Parameter Decoded Good");
          AppPath.Machine = $"{AppPath.Base}\\Machines\\{varRuntime.MachineID.ToString()}";
          AppPath.MachineSettings = AppPath.Machine + "\\Settings";
          AppPath.MachineJob = AppPath.Machine + "\\Job";
          AppPath.MachineTool = AppPath.Machine + "\\Tools";
          AppPath.MachineCounter = AppPath.Machine + "\\Counters";
          AppPath.MachineBackup = AppPath.Machine + "\\Backup";
          AppPath.MachineKinematic = AppPath.Machine + "\\Kinematic";
          AppPath.MachinePostProcessor = AppPath.Machine + "\\Post";
        }
        catch (Exception ex)
        {
          buLogVer5.addToLog(buMotionCommands.\u0001, str1, "", "Runtime Parameter Decoder Error");
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Parameter Open");
        }
      }
      else
      {
        buLogVer5.addToLog(buMotionCommands.\u0001, str1, "", "Runtime File Mising");
        buString.MessageBoxError("Main Program Runtime Parameter File Missing");
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionCommands.\u0001, str1, "Error");
      buException.throwException(ex, str1, true, "");
    }
  }

  public static void LoadMotionLanguage(int Language, bool DeveloperPCMode)
  {
    string str = nameof (LoadMotionLanguage);
    try
    {
      FileInfo fileInfo = DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buMotion.lng") : new FileInfo(AppPath.Language + "\\buMotion.lng");
      if (fileInfo.Exists)
      {
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        List<string> stringList3 = new List<string>();
        List<string> stringList4 = new List<string>();
        List<string> stringList5 = new List<string>();
        List<string> stringList6 = new List<string>();
        AppLanguage.SystemStatus.Clear();
        AppLanguage.SystemMessages.Clear();
        AppLanguage.SystemError.Clear();
        AppLanguage.SystemWarning.Clear();
        AppLanguage.AxesError.Clear();
        AppLanguage.AxesWarning.Clear();
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), Language, ref AppLanguage.SystemMessages);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), Language, ref AppLanguage.SystemStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Error>", "</Error>", StringList), Language, ref AppLanguage.SystemError);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Warning>", "</Warning>", StringList), Language, ref AppLanguage.SystemWarning);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisError>", "</AxisError>", StringList), Language, ref AppLanguage.AxesError);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisWarning>", "</AxisWarning>", StringList), Language, ref AppLanguage.AxesWarning);
        StringList.Clear();
        buMotionLangDefination.LoadStatus(AppLanguage.SystemStatus);
        buMotionStatusLang.LoadAxisError(AppLanguage.AxesError);
        buMotionWarningLang.LoadAxisWarning(AppLanguage.AxesWarning);
        buMotionLangDefination.LoadError(AppLanguage.SystemError);
        buMotionErrorLang.LoadMessage(AppLanguage.SystemMessages);
        buMotionLangDefination.LoadWarning(AppLanguage.SystemWarning);
        buLogVer5.addToLog(buMotionCommands.\u0001, str, "", "buMotion Language Loaded");
      }
      else
      {
        buLogVer5.addToLog(buMotionCommands.\u0001, str, "", "buMotion Language File Missing");
        buString.MessageBoxError("Language buMotion File Missing");
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionCommands.\u0001, str, "Error");
      buException.throwException(ex, str, true, "");
    }
  }

  public string readVar(
    CodesysVariableBaseType BaseType,
    VariableType VarType,
    string Address,
    ref object Val)
  {
    string str1 = "readDINTVar";
    try
    {
      string message = "None:" + Address;
      if (AppBool.Connected)
      {
        string str2 = "";
        switch (CodesysMachine.CommType)
        {
          case CommunicationType.PlcHandler:
            if (BaseType == CodesysVariableBaseType.Global)
              str2 = CodesysMachine.RootGlobalString;
            if (BaseType == CodesysVariableBaseType.Persistent)
              str2 = CodesysMachine.RootPersistentString;
            if (BaseType == CodesysVariableBaseType.IO)
              str2 = CodesysMachine.RootIOString;
            if (BaseType == CodesysVariableBaseType.CNC)
              str2 = CodesysMachine.RootCNCString;
            string VarName = str2 + Address;
            int num1 = 1;
            if (VarName.Length > 1)
            {
              if (VarType == VariableType.DINT)
              {
                int num2 = 0;
                num1 = buPLCHandler.ReadVariableDINT(VarName, ref num2);
                Val = (object) num2;
              }
              if (VarType == VariableType.INT)
              {
                short num3 = 0;
                num1 = buPLCHandler.ReadVariableINT(VarName, ref num3);
                Val = (object) num3;
              }
              if (VarType == VariableType.REAL)
              {
                float num4 = 0.0f;
                num1 = buPLCHandler.ReadVariableREAL(VarName, ref num4);
                Val = (object) num4;
              }
              if (VarType == VariableType.LREAL)
              {
                double num5 = 0.0;
                num1 = buPLCHandler.ReadVariableLREAL(VarName, ref num5);
                Val = (object) num5;
              }
              if (VarType == VariableType.Bool)
              {
                bool flag = false;
                num1 = buPLCHandler.ReadVariableBOOL(VarName, ref flag);
                Val = (object) flag;
              }
              if (VarType == VariableType.STRING)
              {
                string str3 = "";
                num1 = buPLCHandler.ReadVariableSTRING(VarName, ref str3);
                Val = (object) str3;
              }
            }
            message = num1 != 0 ? $"{buLangTranslate.preDef.Error}: {VarName}" : "Ok";
            break;
          case CommunicationType.OPCUA:
            if (BaseType == CodesysVariableBaseType.Global)
              str2 = OpcVars.pathCodesysGvl;
            if (BaseType == CodesysVariableBaseType.Persistent)
              str2 = OpcVars.pathCodesysPersistent;
            if (BaseType == CodesysVariableBaseType.IO)
              str2 = OpcVars.pathCodesysIO;
            if (BaseType == CodesysVariableBaseType.CNC)
              str2 = OpcVars.pathCodesysCNC;
            string nodeid = str2 + Address;
            if (nodeid.Length > 1)
            {
              if (!OpcVars.opcClient.IsConnected)
                ;
              if (VarType == VariableType.INT)
              {
                short num6 = 0;
                message = OPCReadWrite.ReadINTValue(OpcVars.opcClient.Session, nodeid, ref num6);
                Val = (object) num6;
              }
              if (VarType == VariableType.DINT)
              {
                int num7 = 0;
                message = OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, nodeid, ref num7);
                Val = (object) num7;
              }
              if (VarType == VariableType.REAL)
              {
                float num8 = 0.0f;
                message = OPCReadWrite.ReadREALValue(OpcVars.opcClient.Session, nodeid, ref num8);
                Val = (object) num8;
              }
              if (VarType == VariableType.LREAL)
              {
                double num9 = 0.0;
                message = OPCReadWrite.ReadLREALValue(OpcVars.opcClient.Session, nodeid, ref num9);
                Val = (object) num9;
              }
              if (VarType == VariableType.Bool)
              {
                bool flag = false;
                message = OPCReadWrite.ReadBOOLValue(OpcVars.opcClient.Session, nodeid, ref flag);
                Val = (object) flag;
              }
              if (VarType == VariableType.STRING)
              {
                string str4 = "";
                message = OPCReadWrite.ReadSTRINGValue(OpcVars.opcClient.Session, nodeid, ref str4);
                Val = (object) str4;
              }
              if (message != "Ok")
              {
                message = $"{message} - {nodeid}";
                break;
              }
              break;
            }
            break;
          default:
            message = $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Unknown} {buLangTranslate.preDef.Communication}";
            break;
        }
        // ISSUE: reference to a compiler-generated field
        if (message != "Ok" && this.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.\u0001(new MotionCommandEventArg(MotionCommands.ShowWarning, message, 0.0));
        }
        return message;
      }
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Communication} {buLangTranslate.preDef.Offline}";
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string readDINTVar(CodesysVariableBaseType VarBaseType, string Address, ref int Val)
  {
    string str1 = nameof (readDINTVar);
    try
    {
      object Val1 = (object) null;
      string str2 = this.readVar(VarBaseType, VariableType.DINT, Address, ref Val1);
      if ((Val1 == null ? 0 : (Val1.GetType() == typeof (int) ? 1 : 0)) != 0)
        Val = Convert.ToInt32(Val1);
      else
        str2 = $"{buLangTranslate.preDef.Type} {buLangTranslate.preDef.Mismatch} : {Address}";
      return str2;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string readINTVar(CodesysVariableBaseType VarBaseType, string Address, ref short Val)
  {
    string str1 = nameof (readINTVar);
    try
    {
      object Val1 = (object) null;
      string str2 = this.readVar(VarBaseType, VariableType.INT, Address, ref Val1);
      if ((Val1 == null ? 0 : (Val1.GetType() == typeof (short) ? 1 : 0)) != 0)
        Val = Convert.ToInt16(Val1);
      else
        str2 = $"{buLangTranslate.preDef.Type} {buLangTranslate.preDef.Mismatch} : {Address}";
      return str2;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string readREALVar(CodesysVariableBaseType VarBaseType, string Address, ref float Val)
  {
    string str1 = nameof (readREALVar);
    try
    {
      object Val1 = (object) null;
      string str2 = this.readVar(VarBaseType, VariableType.REAL, Address, ref Val1);
      if ((Val1 == null ? 0 : (Val1.GetType() == typeof (float) ? 1 : 0)) != 0)
        Val = Convert.ToSingle(Val1);
      else
        str2 = $"{buLangTranslate.preDef.Type} {buLangTranslate.preDef.Mismatch} : {Address}";
      return str2;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string readLREALVar(CodesysVariableBaseType VarBaseType, string Address, ref double Val)
  {
    string str1 = nameof (readLREALVar);
    try
    {
      object Val1 = (object) null;
      string str2 = this.readVar(VarBaseType, VariableType.LREAL, Address, ref Val1);
      if ((Val1 == null ? 0 : (Val1.GetType() == typeof (double) ? 1 : 0)) != 0)
        Val = Convert.ToDouble(Val1);
      else
        str2 = $"{buLangTranslate.preDef.Type} {buLangTranslate.preDef.Mismatch} : {Address}";
      return str2;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string readBOOLVar(CodesysVariableBaseType VarBaseType, string Address, ref bool Val)
  {
    string str1 = nameof (readBOOLVar);
    try
    {
      object Val1 = (object) null;
      string str2 = this.readVar(VarBaseType, VariableType.Bool, Address, ref Val1);
      if ((Val1 == null ? 0 : (Val1.GetType() == typeof (bool) ? 1 : 0)) != 0)
        Val = Convert.ToBoolean(Val1);
      else
        str2 = $"{buLangTranslate.preDef.Type} {buLangTranslate.preDef.Mismatch} : {Address}";
      return str2;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string readSTRINGVar(CodesysVariableBaseType VarBaseType, string Address, ref string Val)
  {
    string str1 = nameof (readSTRINGVar);
    try
    {
      object Val1 = (object) null;
      string str2 = this.readVar(VarBaseType, VariableType.STRING, Address, ref Val1);
      if ((Val1 == null ? 0 : (Val1.GetType() == typeof (string) ? 1 : 0)) != 0)
        Val = Convert.ToString(Val1);
      else
        str2 = $"{buLangTranslate.preDef.Type} {buLangTranslate.preDef.Mismatch} : {Address}";
      return str2;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string writeVar(
    CodesysVariableBaseType VarBaseType,
    VariableType VarType,
    object Val,
    string Address)
  {
    string str1 = nameof (writeVar);
    try
    {
      string message = "None:" + Address;
      if (AppBool.Connected)
      {
        string str2 = "";
        switch (CodesysMachine.CommType)
        {
          case CommunicationType.PlcHandler:
            if (VarBaseType == CodesysVariableBaseType.Global)
              str2 = CodesysMachine.RootGlobalString;
            if (VarBaseType == CodesysVariableBaseType.Persistent)
              str2 = CodesysMachine.RootPersistentString;
            if (VarBaseType == CodesysVariableBaseType.IO)
              str2 = CodesysMachine.RootIOString;
            if (VarBaseType == CodesysVariableBaseType.CNC)
              str2 = CodesysMachine.RootCNCString;
            string VarName = str2 + Address;
            int num = 1;
            if (VarName.Length > 1)
            {
              if (VarType == VariableType.Bool)
                num = buPLCHandler.WriteVariableBOOL(VarName, Val);
              if (VarType == VariableType.INT)
                num = buPLCHandler.WriteVariableINT(VarName, Val);
              if (VarType == VariableType.DINT)
                num = buPLCHandler.WriteVariableDINT(VarName, Val);
              if (VarType == VariableType.REAL)
                num = buPLCHandler.WriteVariableREAL(VarName, Val);
              if (VarType == VariableType.LREAL)
                num = buPLCHandler.WriteVariableLREAL(VarName, Val);
              if (VarType == VariableType.STRING)
                num = buPLCHandler.WriteVariableSTRING(VarName, Val);
            }
            message = num != 0 ? $"{buLangTranslate.preDef.Error}: {VarName}" : "Ok";
            break;
          case CommunicationType.OPCUA:
            if (VarBaseType == CodesysVariableBaseType.Global)
              str2 = OpcVars.pathCodesysGvl;
            if (VarBaseType == CodesysVariableBaseType.Persistent)
              str2 = OpcVars.pathCodesysPersistent;
            if (VarBaseType == CodesysVariableBaseType.IO)
              str2 = OpcVars.pathCodesysIO;
            if (VarBaseType == CodesysVariableBaseType.CNC)
              str2 = OpcVars.pathCodesysCNC;
            string nodeid = str2 + Address;
            if (nodeid.Length > 1)
            {
              if (!OpcVars.opcClient.IsConnected)
                ;
              if (VarType == VariableType.DINT)
                message = OPCReadWrite.WriteDINTValue(Convert.ToInt32(Val), nodeid, OpcVars.opcClient.Session);
              if (VarType == VariableType.INT)
                message = OPCReadWrite.WriteINTValue(Convert.ToInt16(Val), nodeid, OpcVars.opcClient.Session);
              if (VarType == VariableType.REAL)
                message = OPCReadWrite.WriteREALValue(Convert.ToSingle(Val), nodeid, OpcVars.opcClient.Session);
              if (VarType == VariableType.LREAL)
                message = OPCReadWrite.WriteLREALValue(Convert.ToDouble(Val), nodeid, OpcVars.opcClient.Session);
              if (VarType == VariableType.Bool)
                message = OPCReadWrite.WriteBOOLValue(Convert.ToBoolean(Val), nodeid, OpcVars.opcClient.Session);
              if (VarType == VariableType.STRING)
                message = OPCReadWrite.WriteSTRINGValue(Convert.ToString(Val), nodeid, OpcVars.opcClient.Session);
              if (message != "Ok")
              {
                message = $"{buLangTranslate.preDef.Error} : {message} - {nodeid}";
                break;
              }
              break;
            }
            break;
          default:
            message = $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Unknown} {buLangTranslate.preDef.Communication}";
            break;
        }
        // ISSUE: reference to a compiler-generated field
        if (message != "Ok" && this.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.\u0001(new MotionCommandEventArg(MotionCommands.ShowWarning, message, 0.0));
        }
        return message;
      }
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Communication} {buLangTranslate.preDef.Offline}";
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string writeDINTVar(CodesysVariableBaseType VarBaseType, int Val, string Address)
  {
    string str = "writeDINTVar_";
    try
    {
      object Val1 = (object) Val;
      return this.writeVar(VarBaseType, VariableType.DINT, Val1, Address);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string writeINTVar(CodesysVariableBaseType VarBaseType, short Val, string Address)
  {
    string str = "writeINTVar_";
    try
    {
      object Val1 = (object) Val;
      return this.writeVar(VarBaseType, VariableType.INT, Val1, Address);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string writeREALVar(CodesysVariableBaseType VarBaseType, float Val, string Address)
  {
    string str = "writeREALVar_";
    try
    {
      object Val1 = (object) Val;
      return this.writeVar(VarBaseType, VariableType.REAL, Val1, Address);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string writeLREALVar(CodesysVariableBaseType VarBaseType, double Val, string Address)
  {
    string str = "writeLREALVar_";
    try
    {
      object Val1 = (object) Val;
      return this.writeVar(VarBaseType, VariableType.LREAL, Val1, Address);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string writeBOOLVar(CodesysVariableBaseType VarBaseType, bool Val, string Address)
  {
    string str = "writeBOOLVar_";
    try
    {
      object Val1 = (object) Val;
      return this.writeVar(VarBaseType, VariableType.Bool, Val1, Address);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public string writeSTRINGVar(CodesysVariableBaseType VarBaseType, string Val, string Address)
  {
    string str = "writeSTRINGVar_";
    try
    {
      object Val1 = (object) Val;
      return this.writeVar(VarBaseType, VariableType.STRING, Val1, Address);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((DefaultParameter) this).\u0002, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
      return $"{buLangTranslate.preDef.Error}: {buLangTranslate.preDef.Exception}";
    }
  }

  public buMotionCommands()
  {
    ((DefaultParameter) this).\u0002 = nameof (buMotionCommands);
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
