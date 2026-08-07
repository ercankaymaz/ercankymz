// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Drill.clsDrillGoAtc
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.DialogBox;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Drill;

public class clsDrillGoAtc : clsDrill
{
  public double LastZ = 0.0;
  public drillPlaneNames LastPlane = drillPlaneNames.Top;
  private List<string> list_2 = new List<string>();
  private List<string> list_3 = new List<string>();

  public void cmdCreateCode(string strGCodes, string FileName = "")
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
    saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
    saveFileDialog.FilterIndex = 1;
    if (FileName.Length == 0)
    {
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
      buFile5.SaveToFile(strGCodes, saveFileDialog.FileName);
      if (clsItem.FrmProgress != null)
        clsItem.FrmProgress.Visible = false;
      strGCodes = "";
      clsFiles.SaveParameter();
    }
    else
    {
      buFile5.SaveToFile(strGCodes, FileName);
      if (clsItem.FrmProgress == null)
        return;
      clsItem.FrmProgress.Visible = false;
    }
  }

  public bool cmdShowTools()
  {
    if (this.FrmTools == null)
      this.FrmTools = new F_Tools();
    this.FrmTools.fileNameLeftTools = AppPath.MachineSimConfig;
    this.FrmTools.fileNameRightTools = AppPath.MachineSimConfig + "\\Tools\\GoToolGroups.step";
    this.FrmTools.fileNameBottomTools = AppPath.MachineSimConfig;
    CreateModelProperties createModelProperties = new CreateModelProperties();
    if (this.FrmTools.viewportRight == null)
    {
      this.FrmTools.viewportRight = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        OriginSymbolVisible = false,
        ViewCubeIconVisible = false,
        OrigineCaptionVisible = false,
        ToolBorVisible = false,
        BottomColor = Color.LightGray,
        MiddleColor = Color.WhiteSmoke,
        TopColor = Color.LightGray,
        PanMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      });
      this.FrmTools.viewportRight.Name = "viewportRight";
      this.FrmTools.pnl_viewportright.Controls.Add((System.Windows.Forms.Control) this.FrmTools.viewportRight);
    }
    this.FrmTools.StartPosition = FormStartPosition.CenterParent;
    this.FrmTools.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    this.FrmTools.settingRuntime = new DrillRuntimeSettings(clsDrill.varDrillRunSettings);
    this.FrmTools.UseCommponOffsetToolDrawing = true;
    this.FrmTools.isGo = true;
    if (this.FrmTools.tabControl1.TabPages.Count >= 3)
      this.FrmTools.tabControl1.TabPages.RemoveAt(2);
    if (this.FrmTools.tabControl1.TabPages.Count >= 2)
      this.FrmTools.tabControl1.TabPages.RemoveAt(1);
    this.FrmTools.ShowPlungeSpeed = true;
    this.FrmTools.ShowWaitTime = true;
    this.FrmTools.Init();
    int num = (int) this.FrmTools.ShowDialog();
    bool flag;
    if (this.FrmTools.PropertiesForm.Result == DialogResult.OK)
    {
      for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
      {
        if (clsInit.appDrill.MachType == DrillMachineType.GoWithNoAtc && clsDrill.ToolList[index].Data.No == 31 /*0x1F*/)
          clsDrill.toolTop = new ToolBase5(clsDrill.ToolList[index]);
        if (clsDrill.ToolList[index].Data.No == 95)
        {
          clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[index]);
          clsDrill.toolSlotY1.Geometry.Thickness = clsDrill.toolSlotY1.Geometry.CutLength;
          clsDrill.ToolList[index].Geometry.Thickness = clsDrill.toolSlotY1.Geometry.CutLength;
        }
      }
      clsDrill.varDrillRunSettings = new DrillRuntimeSettings(this.FrmTools.settingRuntime);
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public void cmdCreateCodes(ref List<string> SL, DrillJob Job)
  {
    SL.Clear();
    if (Job.Moves.Count == 0)
      return;
    double num1 = Job.Moves[0].X1Clamper;
    double num2 = Job.Moves[0].X2Clamper;
    int num3 = 0;
    bool flag = false;
    for (int index = 0; index <= Job.Moves.Count - 1; ++index)
    {
      if (Job.Moves[index].Command == DrillMoveCommand.Wait)
      {
        num1 = Math.Abs(Job.Moves[index].X1Clamper);
        num2 = Math.Abs(Job.Moves[index].X2Clamper);
      }
      if ((Job.Moves[index].CodeLines == null ? 0 : (Job.Moves[index].CodeLines.Count > 0 & num3 == 0 ? 1 : 0)) != 0)
        num3 = index;
      if (Job.Moves[index].Command == DrillMoveCommand.SetPiston)
      {
        if (Job.Moves[index].Tool1 >= 61 & Job.Moves[index].Tool1 <= 71)
          flag = true;
        if (Job.Moves[index].Tool1 == 95)
          flag = true;
      }
    }
    SL.Add($"(R1802 = {Job.Material.Size.Depth.ToString("f1")}" + ") { Thickness");
    SL.Add($"(R1801 = {Job.Material.Size.Height.ToString("f1")}" + ") { Panel_Y WIDTH");
    SL.Add($"(R1800 = {Job.Material.Size.Width.ToString("f1")}" + ") { Panel_X LENGTH");
    SL.Add($"(R4100 = {num2.ToString("f1")}" + ")");
    SL.Add($"(R4110 = {num1.ToString("f1")}" + ")");
    SL.Add("{" + $"PNAME = {Job.Name}");
    SL.Add("M1090 { Below Up");
    SL.Add("L ONGIRIS");
    SL.Add("M85 { MultiHole Tools Up");
    if (flag)
      SL.Add("M87");
    SL.Add("$M40 { Spindle Up");
    List<string> stringList = new List<string>();
    for (int index1 = num3; index1 <= Job.Moves.Count - 1; ++index1)
    {
      DrillMove move = Job.Moves[index1];
      if (move.Command == DrillMoveCommand.AxisMove)
      {
        if (move.CodeLines != null)
        {
          for (int index2 = 0; index2 <= move.CodeLines.Count - 1; ++index2)
            SL.Add(move.CodeLines[index2]);
        }
        if (move.pntCenter != (Point3D) null)
        {
          string str1 = "";
          string str2;
          if (move.isG0)
          {
            str2 = "G0";
          }
          else
          {
            str2 = "G1";
            string str3 = " F" + move.Feed.ToString();
          }
          if (move.EnableAxes != null)
          {
            if (move.EnableAxes.X)
              str2 = $"{str2} X{move.pntCenter.X.ToString("f3")}";
            if (move.EnableAxes.Y)
              str2 = $"{str2} Y{move.pntCenter.Y.ToString("f3")}";
            if (move.EnableAxes.Z)
              str1 = $"{str2} Z{move.pntCenter.Z.ToString("f3")}";
          }
        }
      }
      else if (move.Command == DrillMoveCommand.GCode)
      {
        if (move.CodeLines != null)
        {
          for (int index3 = 0; index3 <= move.CodeLines.Count - 1; ++index3)
            SL.Add(move.CodeLines[index3]);
        }
      }
      else if (move.Command == DrillMoveCommand.GCodeList)
      {
        if (move.CodeLines != null)
        {
          for (int index4 = 0; index4 <= move.CodeLines.Count - 1; ++index4)
            SL.Add(move.CodeLines[index4]);
        }
      }
      else
      {
        if (move.Mode == DrillCNCMode.ToolOffset)
        {
          SL.Add("M6T" + move.Tool1.ToString());
          SL.Add("M16");
        }
        if (move.Mode == DrillCNCMode.ToolReset && SL[SL.Count - 1].IndexOf("M85") == -1)
          SL.Add("M85 { MultiHole Tools Up");
        if (move.Mode == DrillCNCMode.PressPistonReset && SL[SL.Count - 1].IndexOf("144") == -1)
          SL.Add("M144 { Press Piston Reset");
        if (move.Mode == DrillCNCMode.ToolSet)
          ;
        if (move.CodeLines != null)
        {
          for (int index5 = 0; index5 <= move.CodeLines.Count - 1; ++index5)
            SL.Add(move.CodeLines[index5]);
        }
      }
    }
    SL.Add("M85 { MultiHole Tools Up");
    SL.Add("M88 { MultiHole Stop");
    SL.Add("M1090 { Below Up");
    SL.Add("$M40 { Spindle Up");
    SL.Add("M5 { Spindle Stop");
    SL.Add("L GFINPRO.ISC");
    SL.Add("$M02 { Program End");
    if (SL.Count > 0)
      ;
  }

  public bool CheckOperationsGoUltra2Top1BottomNoAtc(buShape Shape, ref List<string> Messages)
  {
    Messages.Clear();
    bool flag1;
    if (clsInit.appDrill.EditOperation)
    {
      flag1 = true;
    }
    else
    {
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      for (int index = 0; index <= clsDrill.activeJob.Items.Count - 1; ++index)
      {
        if (buShape.isSame(clsDrill.activeJob.Items[index], Shape))
        {
          Messages.Add(buDrillCalc.LangDrillMessage[61]);
          index = clsDrill.activeJob.Items.Count;
        }
        else if (clsDrill.activeJob.Items[index].ShapeGroup == ShapeGroup.Contour & Shape.ShapeGroup == ShapeGroup.Contour)
        {
          Messages.Add(buDrillCalc.LangDrillMessage[62]);
          index = clsDrill.activeJob.Items.Count;
        }
      }
      if (Shape is buShapeHole)
      {
        buShapeHole buShapeHole = Shape as buShapeHole;
        if (Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back && buShapeHole.isMilling)
          Messages.Add(buDrillCalc.LangDrillMessage[59]);
        if (Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back)
        {
          if (buShapeHole.BasePoint.X < 0.0)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[49]);
            flag2 = true;
          }
          if (buShapeHole.BasePoint.X > clsDrill.activeJob.Material.Size.Width)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[50]);
            flag2 = true;
          }
        }
        if (Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom | Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right)
        {
          if (Shape.BasePoint.Y < 0.0)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[45]);
            flag3 = true;
          }
          if (Shape.BasePoint.Y > clsDrill.activeJob.Material.Size.Height)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[46]);
            flag3 = true;
          }
        }
        if (Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back)
        {
          if (buShapeHole.BasePoint.Z < 0.0)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[56]);
            flag4 = true;
          }
          if (buShapeHole.BasePoint.Z > clsDrill.activeJob.Material.Size.Depth)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[57]);
            flag4 = true;
          }
        }
        if (buShapeHole.planeName == planeBoxNames.Top && buShapeHole.isMilling & buShapeHole.Diameter != clsDrill.toolTop.Geometry.Diameter)
          Messages.Add(buDrillCalc.LangDrillMessage[53]);
        if (buShapeHole.planeName == planeBoxNames.Bottom && buShapeHole.isMilling & buShapeHole.Diameter != clsDrill.toolBottom.Geometry.Diameter)
          Messages.Add(buDrillCalc.LangDrillMessage[53]);
        if (buShapeHole.multiCenter != null && buShapeHole.multiCenter.Count > 0)
        {
          for (int index = 0; index <= buShapeHole.multiCenter.Count - 1; ++index)
          {
            if (!flag2 && Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back)
            {
              if (-buShapeHole.multiCenter[index].Center.X < 0.0)
              {
                Messages.Add(buDrillCalc.LangDrillMessage[49]);
                flag2 = true;
              }
              if (-buShapeHole.multiCenter[index].Center.X > clsDrill.activeJob.Material.Size.Width)
              {
                Messages.Add(buDrillCalc.LangDrillMessage[50]);
                flag2 = true;
              }
            }
            if (!flag3 && Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom | Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right)
            {
              if (-buShapeHole.multiCenter[index].Center.Y < 0.0)
              {
                Messages.Add(buDrillCalc.LangDrillMessage[45]);
                flag3 = true;
              }
              if (-buShapeHole.multiCenter[index].Center.Y > clsDrill.activeJob.Material.Size.Height)
              {
                Messages.Add(buDrillCalc.LangDrillMessage[46]);
                flag3 = true;
              }
            }
            if (!flag4 && Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back)
            {
              if (buShapeHole.multiCenter[index].Center.Z < 0.0)
              {
                Messages.Add(buDrillCalc.LangDrillMessage[56]);
                flag4 = true;
              }
              if (buShapeHole.multiCenter[index].Center.Z > clsDrill.activeJob.Material.Size.Depth)
              {
                Messages.Add(buDrillCalc.LangDrillMessage[57]);
                flag4 = true;
              }
            }
          }
        }
        if (Shape is buShapeHole3)
        {
          for (int index = 0; index <= buShapeHole.entitiesShape.Count - 1; ++index)
          {
            if (buShapeHole.entitiesShape[index] is buCircle)
            {
              buCircle buCircle = buShapeHole.entitiesShape[index] as buCircle;
              if (!flag2 && Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back)
              {
                if (-buCircle.Center.X < 0.0)
                {
                  Messages.Add(buDrillCalc.LangDrillMessage[49]);
                  flag2 = true;
                }
                if (-buCircle.Center.X > clsDrill.activeJob.Material.Size.Width)
                {
                  Messages.Add(buDrillCalc.LangDrillMessage[50]);
                  flag2 = true;
                }
              }
              if (!flag3 && Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom | Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right)
              {
                if (-buCircle.Center.Y < 0.0)
                {
                  Messages.Add(buDrillCalc.LangDrillMessage[45]);
                  flag3 = true;
                }
                if (-buCircle.Center.Y > clsDrill.activeJob.Material.Size.Height)
                {
                  Messages.Add(buDrillCalc.LangDrillMessage[46]);
                  flag3 = true;
                }
              }
              if (!flag4 && Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back)
              {
                if (buCircle.Center.Z < 0.0)
                {
                  Messages.Add(buDrillCalc.LangDrillMessage[56]);
                  flag4 = true;
                }
                if (buCircle.Center.Z > clsDrill.activeJob.Material.Size.Depth)
                {
                  Messages.Add(buDrillCalc.LangDrillMessage[57]);
                  flag4 = true;
                }
              }
            }
          }
        }
      }
      if (Shape is buShapeCut)
      {
        buShapeCut buShapeCut = Shape as buShapeCut;
        if (buShapeCut.BasePoint.X < -100.0)
          Messages.Add(buDrillCalc.LangDrillMessage[43]);
        if (buShapeCut.CutType == CutTypes.CutHorizontal | buShapeCut.CutType == CutTypes.CutHorizontalLine && buShapeCut.BasePoint.X + buShapeCut.Length > clsDrill.activeJob.Material.Size.Width + 100.0)
          Messages.Add(buDrillCalc.LangDrillMessage[44]);
        if (Shape.BasePoint.Y < -40.0)
          Messages.Add(buDrillCalc.LangDrillMessage[45]);
        if (Shape.BasePoint.Y > clsDrill.activeJob.Material.Size.Height + 50.0)
          Messages.Add(buDrillCalc.LangDrillMessage[46]);
        if (buShapeCut.planeName == planeBoxNames.Back | buShapeCut.planeName == planeBoxNames.Front | buShapeCut.planeName == planeBoxNames.Left | buShapeCut.planeName == planeBoxNames.Right)
          Messages.Add(buDrillCalc.LangDrillMessage[51]);
        if (buShapeCut.planeName == planeBoxNames.Bottom && !buShapeCut.isMilling)
          Messages.Add(buDrillCalc.LangDrillMessage[52]);
        if (buShapeCut.planeName == planeBoxNames.Top)
        {
          if (buShapeCut.isMilling & buShapeCut.Diameter != buShapeCut.Tool.Geometry.Diameter)
            Messages.Add($"{buDrillCalc.LangDrillMessage[54]} {buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Diameter} : {buShapeCut.Tool.Geometry.Diameter.ToString("f1")}");
          if (!buShapeCut.isMilling & buShapeCut.Diameter != clsDrill.toolSlotY1.Geometry.Thickness)
            Messages.Add(buDrillCalc.LangDrillMessage[55]);
        }
      }
      if (Shape != null && Shape.ShapeGroup == ShapeGroup.Shape)
      {
        if (clsDrill.activeJob.Material.Size.Width > clsDrill.varDrillMachineSettings.MachineMillingStandartXMaxLimit)
          Messages.Add(buDrillCalc.LangDrillMessage[60]);
        if (Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back)
        {
          bool flag5;
          if (Shape.BasePoint.X < 0.0)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[49]);
            flag5 = true;
          }
          if (Shape.BasePoint.X > clsDrill.activeJob.Material.Size.Width)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[50]);
            flag5 = true;
          }
        }
        if (Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom | Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right)
        {
          bool flag6;
          if (Shape.BasePoint.Y < 0.0)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[45]);
            flag6 = true;
          }
          if (Shape.BasePoint.Y > clsDrill.activeJob.Material.Size.Height)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[46]);
            flag6 = true;
          }
        }
        if (Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Back)
        {
          bool flag7;
          if (Shape.BasePoint.Z < 0.0)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[56]);
            flag7 = true;
          }
          if (Shape.BasePoint.Z > clsDrill.activeJob.Material.Size.Depth)
          {
            Messages.Add(buDrillCalc.LangDrillMessage[57]);
            flag7 = true;
          }
        }
        if (Shape.planeName == planeBoxNames.Back | Shape.planeName == planeBoxNames.Front | Shape.planeName == planeBoxNames.Left | Shape.planeName == planeBoxNames.Right)
          Messages.Add(buDrillCalc.LangDrillMessage[51]);
      }
      flag1 = Messages.Count <= 0;
    }
    return flag1;
  }

  public void CreatCodeFromMove(List<DrillMove> Moves, ref List<string> SL)
  {
    SL.Clear();
    bool flag = false;
    for (int index = 0; index <= Moves.Count - 1; ++index)
    {
      string str1 = clsInit.cDrill.MoveCommandToString(Moves[index].Command);
      if (Moves[index].Command == DrillMoveCommand.ResetPiston | Moves[index].Command == DrillMoveCommand.SetPiston)
      {
        string str2 = clsInit.cDrill.DrillMoveToolsToString(Moves[index]);
        str1 = $"{str1} [ {str2} ] ";
      }
      if (Moves[index].Command == DrillMoveCommand.AxisMove)
      {
        string str3 = Moves[index].Command.ToString() + " - ";
        string str4 = "";
        string str5 = "";
        string str6 = "";
        string str7 = "";
        string str8 = "";
        string str9 = "";
        string str10 = "";
        string str11 = "";
        string str12 = "";
        string str13 = "";
        if (Moves[index].XPosition != this.NoMove)
        {
          str4 = " X: " + Moves[index].XPosition.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].XPosition, Moves[index - 1].XPosition))
            str4 = "";
        }
        if (Moves[index].X1Clamper != this.NoMove)
        {
          str5 = " X1: " + Moves[index].X1Clamper.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].X1Clamper, Moves[index - 1].X1Clamper))
            str5 = "";
        }
        if (Moves[index].X2Clamper != this.NoMove)
        {
          str6 = " X2: " + Moves[index].X2Clamper.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].X2Clamper, Moves[index - 1].X2Clamper))
            str6 = "";
        }
        if (Moves[index].Y1Position != this.NoMove)
        {
          str7 = " Y1: " + Moves[index].Y1Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].Y1Position, Moves[index - 1].Y1Position))
            str7 = "";
        }
        if (Moves[index].Y2Position != this.NoMove)
        {
          str8 = " Y2: " + Moves[index].Y2Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].Y2Position, Moves[index - 1].Y2Position))
            str8 = "";
        }
        if (Moves[index].Y3Position != this.NoMove)
        {
          str9 = " Y3: " + Moves[index].Y3Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].Y3Position, Moves[index - 1].Y3Position))
            str9 = "";
        }
        if (Moves[index].Z1Position != this.NoMove)
        {
          str10 = " Z1: " + Moves[index].Z1Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].Z1Position, Moves[index - 1].Z1Position))
            str10 = "";
        }
        if (Moves[index].Z2Position != this.NoMove)
        {
          str11 = " Z2: " + Moves[index].Z2Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].Z2Position, Moves[index - 1].Z2Position))
            str11 = "";
        }
        if (Moves[index].Z3Position != this.NoMove)
        {
          str12 = " Z3: " + Moves[index].Z3Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].Z3Position, Moves[index - 1].Z3Position))
            str12 = "";
        }
        if (Moves[index].SPosition != this.NoMove)
        {
          str13 = " S: " + Moves[index].SPosition.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal.ToString());
          if (flag && buCompare5.EQ(Moves[index].SPosition, Moves[index - 1].SPosition))
            str13 = "";
        }
        str1 = $"{str1} -{str4}{str5}{str6}{str7}{str8}{str9}{str10}{str11}{str12}{str13}";
        if (Moves[index].Command2 != DrillMoveCommand.None)
        {
          string str14 = clsInit.cDrill.MoveCommandToString(Moves[index].Command2);
          str1 = $"{str1} - {str14}";
          if (Moves[index].Command2 == DrillMoveCommand.SetPiston | Moves[index].Command2 == DrillMoveCommand.ResetPiston)
          {
            string str15 = clsInit.cDrill.DrillMoveToolsToString(Moves[index]);
            str1 = $"{str1} [ {str15} ]";
          }
        }
        flag = true;
      }
      SL.Add(str1);
    }
  }

  public void CreatCodeFromJobItem(ref DrillJob Job, bool IgnoreErrors = false)
  {
    double X1_1 = 0.0;
    double X2_1 = 0.0;
    double MaterialZeroYPos = 0.0;
    double num1 = 0.0;
    List<DrillCalcItem> lst1 = new List<DrillCalcItem>();
    List<DrillCalcItem> lst2 = new List<DrillCalcItem>();
    List<DrillCalcItem> lst3 = new List<DrillCalcItem>();
    List<DrillCalcItem> lst4 = new List<DrillCalcItem>();
    List<DrillItem> ItemShape = new List<DrillItem>();
    List<DrillItem> ItemDrillShape = new List<DrillItem>();
    List<DrillItem> ItemSlotShape = new List<DrillItem>();
    this.ItemSplited = new List<List<DrillCalcItem>>();
    List<DrillCalcItem> drillCalcItemList1 = new List<DrillCalcItem>();
    List<List<DrillCalcItem>> drillCalcItemListList = new List<List<DrillCalcItem>>();
    Job.ErrorCodes = new List<string>();
    Job.isError = false;
    Job.isLesSafe = false;
    Job.isSorted = false;
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == 95)
        clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[index]);
    }
    Job.isClamperSideDrillOpAvailable = false;
    Job.isClamperSideSlotOpAvailable = false;
    Job.isClamperSideMillingOpAvailable = false;
    Job.ItemCalc.Clear();
    for (int index1 = 0; index1 <= Job.Items.Count - 1; ++index1)
    {
      if (Job.Items[index1] is buShapeHole)
      {
        buShapeHole buShapeHole1 = Job.Items[index1] as buShapeHole;
        if (buShapeHole1.Enable)
        {
          if (buShapeHole1.planeName == planeBoxNames.Back)
            Job.isClamperSideDrillOpAvailable = true;
          if (buShapeHole1.DrillType == drillTypes.SingleHole)
          {
            if (!buShapeHole1.isMilling)
            {
              Job.ItemCalc.Add(new DrillCalcItem(buShapeHole1));
              Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
              if (Job.Items[index1].BasePoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
                Job.isClamperSideDrillOpAvailable = true;
              ++this.IDCounter;
            }
            else
            {
              DrillItem drillItem = new DrillItem((buShapeHole) Job.Items[index1]);
              if (Job.Items[index1].Tool != null)
                drillItem.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
              ItemDrillShape.Add(drillItem);
            }
          }
          if (buShapeHole1.DrillType == drillTypes.HorizontalHoles | buShapeHole1.DrillType == drillTypes.HorizontalLineHoles | buShapeHole1.DrillType == drillTypes.VerticalHoles | buShapeHole1.DrillType == drillTypes.VerticalLineHoles | buShapeHole1.DrillType == drillTypes.InclineHoles)
          {
            if (!buShapeHole1.isMilling)
            {
              for (int index2 = 0; index2 <= buShapeHole1.multiCenter.Count - 1; ++index2)
              {
                buShapeHole buShapeHole2 = new buShapeHole(buShapeHole1.Diameter, buShapeHole1.Depth);
                buShapeHole2.CalculatedPoint = new Point3D(buShapeHole1.multiCenter[index2].Center.X, buShapeHole1.multiCenter[index2].Center.Y, buShapeHole1.multiCenter[index2].Center.Z);
                buShapeHole2.planeName = buShapeHole1.planeName;
                buShapeHole2.ID = this.IDCounter;
                Job.ItemCalc.Add(new DrillCalcItem(buShapeHole2));
                Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
                if (Math.Abs(buShapeHole1.multiCenter[index2].Center.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
                  Job.isClamperSideDrillOpAvailable = true;
                ++this.IDCounter;
              }
            }
            else
            {
              for (int index3 = 0; index3 <= buShapeHole1.multiCenter.Count - 1; ++index3)
              {
                buShapeHole buShapeHole3 = new buShapeHole(buShapeHole1.Diameter, buShapeHole1.Depth);
                buShapeHole3.CalculatedPoint = new Point3D(buShapeHole1.multiCenter[index3].Center.X, buShapeHole1.multiCenter[index3].Center.Y, buShapeHole1.multiCenter[index3].Center.Z);
                buShapeHole3.ItemSize.MinBox = new Point3D(buShapeHole1.multiCenter[index3].Center.X - buShapeHole1.Diameter / 2.0, buShapeHole1.multiCenter[index3].Center.Y - buShapeHole1.Diameter / 2.0);
                buShapeHole3.ItemSize.MaxBox = new Point3D(buShapeHole1.multiCenter[index3].Center.X + buShapeHole1.Diameter / 2.0, buShapeHole1.multiCenter[index3].Center.Y + buShapeHole1.Diameter / 2.0);
                buShapeHole3.planeName = buShapeHole1.planeName;
                ItemDrillShape.Add(new DrillItem(buShapeHole3));
              }
            }
          }
          if (buShapeHole1.DrillType == drillTypes.ThreeHole)
          {
            buShapeHole3 buShapeHole3 = Job.Items[index1] as buShapeHole3;
            Point3D calcCenter1 = new Point3D();
            Point3D calcCenter2 = new Point3D();
            clsInit.cVector5.calcBuShapeHole3Point(buShapeHole3.CalculatedPoint, buShapeHole3.planeName, buShapeHole3.DistanceX, buShapeHole3.DistanceY, buShapeHole3.DiameterOutside, buShapeHole3.Hole3Angle, ref calcCenter1, ref calcCenter2);
            buShapeHole buShapeHole4 = new buShapeHole(buShapeHole3.Diameter, buShapeHole3.Depth);
            buShapeHole4.CalculatedPoint = new Point3D(buShapeHole1.CalculatedPoint.X, buShapeHole1.CalculatedPoint.Y, buShapeHole1.CalculatedPoint.Z);
            buShapeHole4.planeName = buShapeHole1.planeName;
            buShapeHole4.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole4));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole4.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
            buShapeHole buShapeHole5 = new buShapeHole(buShapeHole3.DiameterOutside, buShapeHole3.Depth);
            buShapeHole5.CalculatedPoint = new Point3D(calcCenter1.X, calcCenter1.Y, calcCenter1.Z);
            buShapeHole5.planeName = buShapeHole1.planeName;
            buShapeHole5.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole5));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole5.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
            buShapeHole buShapeHole6 = new buShapeHole(buShapeHole3.DiameterOutside, buShapeHole3.Depth);
            buShapeHole6.CalculatedPoint = new Point3D(calcCenter2.X, calcCenter2.Y, calcCenter1.Z);
            buShapeHole6.planeName = buShapeHole1.planeName;
            buShapeHole6.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole6));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole6.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
          }
        }
      }
      if (Job.Items[index1] is buShapeCut & Job.Items[index1].Enable)
      {
        buShapeCut buShapeCut1 = Job.Items[index1] as buShapeCut;
        if (buShapeCut1.CutType == CutTypes.CutHorizontal | buShapeCut1.CutType == CutTypes.CutHorizontalLine)
        {
          DrillCalcItem drillCalcItem = new DrillCalcItem(buShapeCut1);
          if (!drillCalcItem.UseMilling)
            drillCalcItem.Tool = 95;
          Job.ItemCalc.Add(drillCalcItem);
        }
        else if (Job.Items[index1].Tool != null)
        {
          if (buShapeCut1.CutType == CutTypes.CutVertical | buShapeCut1.CutType == CutTypes.CutVerticalLine | buShapeCut1.CutType == CutTypes.CutFree)
          {
            if (((buShapeCut) Job.Items[index1]).Length > 2500.0)
            {
              buShapeCut buShapeCut2 = Job.Items[index1] as buShapeCut;
              buShapeCut buShapeCut3 = new buShapeCut(Job.Items[index1]);
              buShapeCut3.Length = buShapeCut2.Length / 2.0;
              buShapeCut buShapeCut4 = new buShapeCut(Job.Items[index1]);
              ItemSlotShape.Add(new DrillItem(buShapeCut3));
            }
            else
              ItemSlotShape.Add(new DrillItem((buShapeCut) Job.Items[index1]));
          }
          else
          {
            DrillItem data = new DrillItem((buShapeCut) Job.Items[index1]);
            if (-buShapeCut1.CalculatedPoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0 | -buShapeCut1.ItemSize.MaxBox.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
            {
              if (buShapeCut1.Length < Job.Material.Size.Width * 0.25)
              {
                ItemSlotShape.Add(new DrillItem((buShapeCut) Job.Items[index1]));
              }
              else
              {
                List<Point3D> Points = new List<Point3D>();
                List<Point3D> PointsDevided = new List<Point3D>();
                Points.Add(buVector5.ToPoint3D(data.camEntities[0][0].StartPoint));
                Points.Add(buVector5.ToPoint3D(data.camEntities[0][0].EndPoint));
                double num2 = 8.0;
                if (clsDrill.activeJob.Material.Size.Width > 1000.0)
                  num2 = 8.0;
                if (clsDrill.activeJob.Material.Size.Width > 2000.0)
                  num2 = 12.0;
                clsInit.cVector5.DevidePointsByLength(Points, buShapeCut1.Length / num2, ref PointsDevided);
                if (PointsDevided.Count > 0)
                {
                  data.camEntities[0].Clear();
                  for (int index4 = 1; index4 <= PointsDevided.Count - 1; ++index4)
                  {
                    DrillItem drillItem = new DrillItem(data);
                    drillItem.camEntities = new List<List<buEntity>>();
                    List<buEntity> refEntities = new List<buEntity>();
                    refEntities.Add((buEntity) new buLine(PointsDevided[index4 - 1], PointsDevided[index4]));
                    clsInit.cVector5.BoxSizeCalculate(refEntities, ref drillItem.BoxMinOfDrawing, ref drillItem.BoxMaxOfDrawing);
                    if (buShapeCut1.CutType == CutTypes.CutHorizontal | buShapeCut1.CutType == CutTypes.CutHorizontalLine)
                    {
                      drillItem.BoxMinOfDrawing.Y = buShapeCut1.ItemSize.MinBox.Y;
                      drillItem.BoxMaxOfDrawing.Y = buShapeCut1.ItemSize.MaxBox.Y;
                    }
                    if (buShapeCut1.CutType == CutTypes.CutVertical | buShapeCut1.CutType == CutTypes.CutVerticalLine)
                    {
                      drillItem.BoxMinOfDrawing.X = buShapeCut1.ItemSize.MinBox.X;
                      drillItem.BoxMaxOfDrawing.X = buShapeCut1.ItemSize.MaxBox.X;
                    }
                    drillItem.BoxMinItem = new Point3D(-drillItem.BoxMaxOfDrawing.X, -drillItem.BoxMaxOfDrawing.Y, drillItem.BoxMinOfDrawing.Z);
                    drillItem.BoxMaxItem = new Point3D(-drillItem.BoxMinOfDrawing.X, -drillItem.BoxMinOfDrawing.Y, drillItem.BoxMaxOfDrawing.Z);
                    drillItem.camEntities.Add(refEntities);
                    ItemSlotShape.Add(drillItem);
                  }
                }
              }
            }
            else if (((buShapeCut) Job.Items[index1]).Length >= 2400.0)
            {
              buShapeCut buShapeCut5 = Job.Items[index1] as buShapeCut;
              buShapeCut buShapeCut6 = new buShapeCut(Job.Items[index1]);
              buShapeCut6.Length = buShapeCut5.Length / 2.0;
              buShapeCut buShapeCut7 = new buShapeCut(Job.Items[index1]);
              buShapeCut7.Length = buShapeCut5.Length / 2.0;
              buShapeCut7.CalculatedPoint.X -= buShapeCut7.Length;
              DrillItem drillItem1 = new DrillItem(buShapeCut7);
              if (Job.Items[index1].Tool != null)
                drillItem1.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
              ItemSlotShape.Add(drillItem1);
              DrillItem drillItem2 = new DrillItem(buShapeCut6);
              if (num1 != 0.0)
                ;
              if (Job.Items[index1].Tool != null)
                drillItem2.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
              ItemSlotShape.Add(drillItem2);
              num1 = -buShapeCut7.Length;
            }
            else if (((buShapeCut) Job.Items[index1]).Length > 2000.0 & ((buShapeCut) Job.Items[index1]).Length < 2400.0)
            {
              buShapeCut buShapeCut8 = Job.Items[index1] as buShapeCut;
              buShapeCut buShapeCut9 = new buShapeCut(Job.Items[index1]);
              buShapeCut9.Length = buShapeCut8.Length / 2.0;
              buShapeCut buShapeCut10 = new buShapeCut(Job.Items[index1]);
              buShapeCut10.Length = buShapeCut8.Length / 2.0;
              buShapeCut10.CalculatedPoint.X -= buShapeCut10.Length;
              DrillItem drillItem3 = new DrillItem(buShapeCut10);
              if (Job.Items[index1].Tool != null)
                drillItem3.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
              drillItem3.X1First = true;
              drillItem3.X1Move = -buShapeCut10.Length;
              drillItem3.X2Move = -buShapeCut10.Length;
              ItemSlotShape.Add(drillItem3);
              DrillItem drillItem4 = new DrillItem(buShapeCut9);
              if (Job.Items[index1].Tool != null)
                drillItem4.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
              if (num1 != 0.0)
              {
                drillItem4.X1First = false;
                drillItem4.X1Move = -num1;
                drillItem4.X2Move = -num1;
              }
              ItemSlotShape.Add(drillItem4);
              num1 = -buShapeCut10.Length;
            }
            else
            {
              DrillItem drillItem = new DrillItem((buShapeCut) Job.Items[index1]);
              if (Job.Items[index1].Tool != null)
                drillItem.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
              if (num1 != 0.0)
              {
                drillItem.X1First = false;
                drillItem.X1Move = -num1;
                drillItem.X2Move = -num1;
              }
              ItemSlotShape.Add(drillItem);
            }
          }
        }
      }
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Shape & Job.Items[index1].Enable)
      {
        DrillItem drillItem = new DrillItem(Job.Items[index1]);
        if (Job.Items[index1].Tool != null)
        {
          drillItem.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
          ItemShape.Add(drillItem);
        }
      }
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Profiling & Job.Items[index1].Enable)
      {
        DrillItem drillItem = new DrillItem((buShapeProfiling) Job.Items[index1]);
        if (Job.Items[index1].Tool != null)
          drillItem.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
        ItemShape.Add(drillItem);
      }
      if (Job.Items[index1] is buShapeJunction & Job.Items[index1].Enable)
      {
        buShapeJunction buShapeJunction = Job.Items[index1] as buShapeJunction;
        if (buShapeJunction.Enable)
        {
          for (int index5 = 0; index5 <= buShapeJunction.multiCenter.Count - 1; ++index5)
          {
            buShapeHole buShapeHole = new buShapeHole(buShapeJunction.multiCenter[index5].Diameter, buShapeJunction.Depth);
            buShapeHole.CalculatedPoint = new Point3D(buShapeJunction.multiCenter[index5].Center.X, buShapeJunction.multiCenter[index5].Center.Y, buShapeJunction.multiCenter[index5].Center.Z);
            buShapeHole.planeName = buShapeJunction.planeName;
            buShapeHole.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole));
            ++this.IDCounter;
          }
        }
      }
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Engraving & Job.Items[index1].Enable)
      {
        DrillItem drillItem = new DrillItem((buShapeEngrave) Job.Items[index1]);
        if (Job.Items[index1].Tool != null)
          drillItem.ToolMilling = new ToolBase5(Job.Items[index1].Tool);
        ItemShape.Add(drillItem);
      }
    }
    this.SortJobItems(ref Job);
    Job.isSorted = true;
    for (int index = 0; index <= Job.ItemCalc.Count - 1; ++index)
      Job.ItemCalc[index].Calculated = false;
    for (int index = 0; index <= Job.ItemCalc.Count - 1; ++index)
    {
      if (Job.ItemCalc[index].Enable & Job.ItemCalc[index].Type == DrillItemType.Drill)
      {
        if (Job.ItemCalc[index].planeName == planeBoxNames.Left)
          lst3.Add(new DrillCalcItem(Job.ItemCalc[index]));
        if (Job.ItemCalc[index].planeName == planeBoxNames.Right)
          lst3.Add(new DrillCalcItem(Job.ItemCalc[index]));
        if (Job.ItemCalc[index].planeName == planeBoxNames.Back)
          lst1.Add(new DrillCalcItem(Job.ItemCalc[index]));
        if (Job.ItemCalc[index].planeName == planeBoxNames.Front)
          lst2.Add(new DrillCalcItem(Job.ItemCalc[index]));
        if (Job.ItemCalc[index].planeName == planeBoxNames.Top)
          lst3.Add(new DrillCalcItem(Job.ItemCalc[index]));
        if (Job.ItemCalc[index].planeName == planeBoxNames.Bottom)
          lst3.Add(new DrillCalcItem(Job.ItemCalc[index]));
      }
      if (Job.ItemCalc[index].Enable & Job.ItemCalc[index].Type == DrillItemType.Slot)
        lst4.Add(new DrillCalcItem(Job.ItemCalc[index]));
    }
    this.FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref X1_1, ref X2_1);
    List<DrillCalcItem> drillCalcItemList2 = this.SortByXDistance(lst3, new DrillCalcItem(), SortDirection.LowerToBigger);
    Job.Codes.Clear();
    Job.Cams.Clear();
    Job.Moves.Clear();
    Job.SimulationMoves.Clear();
    Job.Moves = new List<DrillMove>();
    Job.SimulationMoves = new List<DrillMove>();
    Job.isSingleClamper = false;
    this.calcErrorList.Clear();
    bool flag1 = false;
    if (Job.FirstClamperX < -Job.Material.Size.Width && -Job.Material.Size.Width < Job.SecondClamperX & Job.SecondClamperX < 0.0)
      flag1 = true;
    if (!Job.ClampesSetByManuelly)
      this.FindFirstClamperPositionsFromFullJob(Job, ref MaterialZeroYPos, ref X1_1, ref X2_1, false);
    if (!flag1)
    {
      if (Job.isClamperSideDrillOpAvailable & Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperSingleLimit | flag1)
      {
        double X1Pos = 0.0;
        double X2Pos = 0.0;
        Job.isSingleClamper = this.isSingleClamperAvailable(Job, ref X1Pos, ref X2Pos);
        if (Job.isSingleClamper)
        {
          X1_1 = X1Pos;
          X2_1 = X2Pos;
        }
      }
    }
    else
    {
      X1_1 = Job.FirstClamperX;
      X2_1 = Job.SecondClamperX;
      Job.isSingleClamper = true;
    }
    if (Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperSingleMustLimit & !Job.isSingleClamper)
    {
      double X1Pos = 0.0;
      double X2Pos = 0.0;
      Job.isSingleClamper = this.SingleMustClamper(Job, ref X1Pos, ref X2Pos);
      if (Job.isSingleClamper)
      {
        X1_1 = X1Pos;
        X2_1 = X2Pos;
      }
      if (Job.isClamperSideDrillOpAvailable)
        this.calcErrorList.Add(buDrillCalc.LangDrillMessage[66]);
    }
    this.ItemSplited = new List<List<DrillCalcItem>>();
    List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList4 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList5 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList6 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList7 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList8 = new List<DrillCalcItem>();
    for (int index6 = 0; index6 <= drillCalcItemList2.Count - 1; ++index6)
    {
      if (drillCalcItemList3.Count == 0)
      {
        drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList2[index6]));
      }
      else
      {
        bool flag2 = false;
        if (buCompare5.EQ(drillCalcItemList3[drillCalcItemList3.Count - 1].Center.X, drillCalcItemList2[index6].Center.X, 0.01))
          flag2 = true;
        if (flag2)
        {
          drillCalcItemList3.Add(drillCalcItemList2[index6]);
        }
        else
        {
          List<DrillCalcItem> drillCalcItemList9 = new List<DrillCalcItem>();
          for (int index7 = 0; index7 <= drillCalcItemList5.Count - 1; ++index7)
            drillCalcItemList9.Add(drillCalcItemList5[index7]);
          for (int index8 = 0; index8 <= drillCalcItemList6.Count - 1; ++index8)
            drillCalcItemList9.Add(drillCalcItemList6[index8]);
          for (int index9 = 0; index9 <= drillCalcItemList4.Count - 1; ++index9)
            drillCalcItemList9.Add(drillCalcItemList4[index9]);
          for (int index10 = 0; index10 <= drillCalcItemList7.Count - 1; ++index10)
            drillCalcItemList9.Add(drillCalcItemList7[index10]);
          for (int index11 = 0; index11 <= drillCalcItemList8.Count - 1; ++index11)
            drillCalcItemList9.Add(drillCalcItemList8[index11]);
          this.ItemSplited.Add(drillCalcItemList9);
          drillCalcItemList3 = new List<DrillCalcItem>();
          drillCalcItemList3.Add(drillCalcItemList2[index6]);
          drillCalcItemList4 = new List<DrillCalcItem>();
          drillCalcItemList5 = new List<DrillCalcItem>();
          drillCalcItemList6 = new List<DrillCalcItem>();
          drillCalcItemList7 = new List<DrillCalcItem>();
          drillCalcItemList8 = new List<DrillCalcItem>();
        }
      }
      if (drillCalcItemList2[index6].planeName == planeBoxNames.Back)
        drillCalcItemList8.Add(new DrillCalcItem(drillCalcItemList2[index6]));
      if (drillCalcItemList2[index6].planeName == planeBoxNames.Front)
        drillCalcItemList7.Add(new DrillCalcItem(drillCalcItemList2[index6]));
      if (drillCalcItemList2[index6].planeName == planeBoxNames.Top)
        drillCalcItemList5.Add(new DrillCalcItem(drillCalcItemList2[index6]));
      if (drillCalcItemList2[index6].planeName == planeBoxNames.Bottom)
        drillCalcItemList6.Add(new DrillCalcItem(drillCalcItemList2[index6]));
      if (drillCalcItemList2[index6].planeName == planeBoxNames.Left | drillCalcItemList2[index6].planeName == planeBoxNames.Right)
        drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList2[index6]));
    }
    if (drillCalcItemList3.Count > 0)
    {
      List<DrillCalcItem> drillCalcItemList10 = new List<DrillCalcItem>();
      for (int index = 0; index <= drillCalcItemList5.Count - 1; ++index)
        drillCalcItemList10.Add(drillCalcItemList5[index]);
      for (int index = 0; index <= drillCalcItemList6.Count - 1; ++index)
        drillCalcItemList10.Add(drillCalcItemList6[index]);
      for (int index = 0; index <= drillCalcItemList4.Count - 1; ++index)
        drillCalcItemList10.Add(drillCalcItemList4[index]);
      for (int index = 0; index <= drillCalcItemList7.Count - 1; ++index)
        drillCalcItemList10.Add(drillCalcItemList7[index]);
      for (int index = 0; index <= drillCalcItemList8.Count - 1; ++index)
        drillCalcItemList10.Add(drillCalcItemList8[index]);
      this.ItemSplited.Add(drillCalcItemList10);
    }
    DrillMove drillMove = new DrillMove(clsDrill.activeJob.FirstClamperX, clsDrill.activeJob.SecondClamperX, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.ParkY2, clsDrill.varDrillCNCSettings.ParkY3, clsDrill.varDrillCNCSettings.ParkZ1, clsDrill.varDrillCNCSettings.ParkZ2, clsDrill.varDrillCNCSettings.ParkZ3, DrillMoveCommand.AxisMove, 0.0);
    Job.Moves.Add(drillMove);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetAll, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(X1_1, X2_1, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Wait, drillPlaneNames.Top, this.NoMove, ref Job);
    this.SplitedItems = new DrillSplitedItems();
    if (lst2.Count > 0)
    {
      List<List<DrillCalcItem>> SplitedItems = new List<List<DrillCalcItem>>();
      this.SplitItemsByDepth(this.SortByYDistance(lst2, new DrillCalcItem(), SortDirection.LowerToBigger), ref SplitedItems);
      for (int index = 0; index <= SplitedItems.Count - 1; ++index)
      {
        if (SplitedItems[index].Count > 0)
        {
          List<DrillCalcItem> CopiedItem = new List<DrillCalcItem>();
          DrillCalcItem.Copy(SplitedItems[index], ref CopiedItem);
          this.SplitedItems.lstFront.Add(CopiedItem);
        }
      }
    }
    for (int index12 = 0; index12 <= this.ItemSplited.Count - 1; ++index12)
    {
      List<DrillCalcItem> drillCalcItemList11 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList12 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList13 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList14 = new List<DrillCalcItem>();
      this.ItemSplited[index12] = this.SortByYDistance(this.ItemSplited[index12], new DrillCalcItem(), SortDirection.LowerToBigger);
      for (int index13 = 0; index13 <= this.ItemSplited[index12].Count - 1; ++index13)
      {
        if (this.ItemSplited[index12][index13].planeName == planeBoxNames.Top)
          drillCalcItemList11.Add(new DrillCalcItem(this.ItemSplited[index12][index13]));
        if (this.ItemSplited[index12][index13].planeName == planeBoxNames.Bottom)
          drillCalcItemList12.Add(new DrillCalcItem(this.ItemSplited[index12][index13]));
        if (this.ItemSplited[index12][index13].planeName == planeBoxNames.Left)
          drillCalcItemList13.Add(new DrillCalcItem(this.ItemSplited[index12][index13]));
        if (this.ItemSplited[index12][index13].planeName == planeBoxNames.Right)
          drillCalcItemList14.Add(new DrillCalcItem(this.ItemSplited[index12][index13]));
      }
      if (drillCalcItemList11.Count > 0)
        this.SplitedItems.lstTop.Add(drillCalcItemList11);
      if (drillCalcItemList12.Count > 0)
        this.SplitedItems.lstBottom.Add(drillCalcItemList12);
      if (drillCalcItemList13.Count > 0)
        this.SplitedItems.lstLeft.Add(drillCalcItemList13);
      if (drillCalcItemList14.Count > 0)
        this.SplitedItems.lstRight.Add(drillCalcItemList14);
    }
    if (lst1.Count > 0)
    {
      List<List<DrillCalcItem>> SplitedItems = new List<List<DrillCalcItem>>();
      this.SplitItemsByDepth(this.SortByYDistance(lst1, new DrillCalcItem(), SortDirection.LowerToBigger), ref SplitedItems);
      for (int index = 0; index <= SplitedItems.Count - 1; ++index)
      {
        if (SplitedItems[index].Count > 0)
        {
          List<DrillCalcItem> CopiedItem = new List<DrillCalcItem>();
          DrillCalcItem.Copy(SplitedItems[index], ref CopiedItem);
          this.SplitedItems.lstBack.Add(CopiedItem);
        }
      }
    }
    this.FoundDrills.Clear();
    this.ClearCalculatedThings();
    this.FindHolesForFrontSide();
    this.FindHolesForTopSide();
    this.FindHolesForBottomSide();
    this.FindHolesForLefttSide();
    this.FindHolesForRightSide();
    this.FindHolesForBackSide();
    this.AssingToolOffset();
    for (int index = 0; index <= this.FoundDrills.Count - 2; ++index)
    {
      if (buCompare5.EQ(this.FoundDrills[index].Items[0].OffsetedPoint.X, this.FoundDrills[index + 1].Items[0].OffsetedPoint.X, 0.01))
        this.FoundDrills[index + 1].Items[0].OffsetedPoint.X = this.FoundDrills[index].Items[0].OffsetedPoint.X + 1E-05;
    }
    this.FoundDrills = this.SortByXOffsetedDistanceDrillFound(this.FoundDrills, new DrillCalcItem(), SortDirection.LowerToBigger);
    for (int index14 = 0; index14 <= this.FoundDrills.Count - 1; ++index14)
    {
      if (this.FoundDrills[index14].Items[0].planeName == planeBoxNames.Right)
      {
        double x1 = this.FoundDrills[index14].Items[0].OffsetedPoint.X;
        int num3 = 1;
        for (int index15 = index14 + 1; index15 <= this.FoundDrills.Count - 1; ++index15)
        {
          if (this.FoundDrills[index15].Items[0].planeName == planeBoxNames.Right)
          {
            double x2 = this.FoundDrills[index15].Items[0].OffsetedPoint.X;
            if (x2 - x1 > 0.0 & x2 - x1 < 100.0)
            {
              DrillFound drillFound = new DrillFound(this.FoundDrills[index15]);
              this.FoundDrills.RemoveAt(index15);
              this.FoundDrills.Insert(index14 + num3, drillFound);
              ++num3;
            }
            else
            {
              index14 = index15 - 1;
              index15 = this.FoundDrills.Count;
            }
          }
        }
      }
    }
    if (clsDrill.varDrillCNCSettings.BackOperationsAlwaysWillLastOperation)
      this.MoveBackOperationToLast();
    this.CreateCodes(ref Job);
    for (int index16 = 0; index16 <= this.FoundDrills.Count - 1; ++index16)
    {
      for (int index17 = 0; index17 <= this.FoundDrills[index16].Items.Count - 1; ++index17)
        this.SetAsCalculatedDrillItemByID(this.FoundDrills[index16].Items[index17].ID, ref Job.ItemCalc);
    }
    for (int index = Job.ItemCalc.Count - 1; index >= 0; --index)
    {
      if (Job.ItemCalc[index].Type == DrillItemType.Drill)
      {
        if (!Job.ItemCalc[index].Enable)
          this.calcErrorList.Add($"Disabled | {Job.ItemCalc[index].planeName.ToString()} - Diameter: {Job.ItemCalc[index].Diameter.ToString("f2")} - Center ({Job.ItemCalc[index].Center.ToString()})");
        else if (!Job.ItemCalc[index].Calculated)
          this.calcErrorList.Add($"Not Calculated | {Job.ItemCalc[index].planeName.ToString()} - Diameter: {Job.ItemCalc[index].Diameter.ToString("f2")} - Center ({Job.ItemCalc[index].Center.ToString()})");
      }
    }
    if (lst4.Count > 0)
    {
      List<DrillCalcItem> drillCalcItemList15 = this.SortByYDistance(lst4, new DrillCalcItem(), SortDirection.LowerToBigger);
      List<DrillCalcItem> drillCalcItemList16 = new List<DrillCalcItem>();
      for (int index = 0; index <= drillCalcItemList15.Count - 1; ++index)
        this.CreateCodeForSlotTopSide(ref Job, ref new List<DrillCalcItem>()
        {
          drillCalcItemList15[index]
        });
      double num4 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      double num5 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      double num6 = 0.0;
      if (Job.Moves[Job.Moves.Count - 1].XPosition == this.NoMove)
      {
        num4 = Job.Moves[Job.Moves.Count - 2].X1Clamper - Job.Moves[Job.Moves.Count - 2].XPosition;
        num5 = Job.Moves[Job.Moves.Count - 2].X2Clamper - Job.Moves[Job.Moves.Count - 2].XPosition;
      }
      if (num4 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
      {
        double num7 = clsDrill.varDrillMachineSettings.MachineMinXStroke - num4;
        double num8 = num4 + num7;
        double num9 = num5 + num7;
        double num10 = num6 + num7;
      }
    }
    this.CreatCodeFromJobShapeContourAndSlotItem(ref Job);
    this.CreatCodeFromJobShapeItem(ref Job, ItemShape, ItemDrillShape, ItemSlotShape);
    if (Job.Moves.Count > 0)
    {
      double X1_2 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      double X2_2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      if (ItemShape.Count == 0 & ItemDrillShape.Count == 0 & ItemSlotShape.Count == 0)
      {
        if (X1_2 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
        {
          double num11 = X2_2 - X1_2;
          double X = clsDrill.varDrillMachineSettings.MachineMinXStroke - X1_2;
          this.AddDrillMove(clsDrill.varDrillMachineSettings.MachineMinXStroke, clsDrill.varDrillMachineSettings.MachineMinXStroke + num11, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(), ref Job);
        }
        else
          this.AddDrillMove(X1_2, X2_2, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, 0.0, new DrillMoveOptions(), ref Job);
      }
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.Finished, drillPlaneNames.Top, this.NoMove, ref Job);
    }
    this.CreatCodeFromMove(Job.Moves, ref Job.Codes);
    Job.TotalSec = 0.0;
    this.doCalculateTime(ref Job.TotalSec);
    if (this.calcErrorList.Count > 0 & !IgnoreErrors)
    {
      DialogBoxList dialogBoxList = new DialogBoxList();
      dialogBoxList.Caption = "No Tool Available for These Holes";
      dialogBoxList.Width = 500;
      dialogBoxList.lst_items.ScrollAlwaysVisible = true;
      dialogBoxList.lst_items.HorizontalScrollbar = true;
      for (int index = 0; index <= this.calcErrorList.Count - 1; ++index)
        dialogBoxList.Items.Add(this.calcErrorList[index]);
      dialogBoxList.Init();
      int num12 = (int) dialogBoxList.ShowDialog();
      Job.isError = true;
    }
    if (clsItem.FrmProgress == null)
      return;
    clsItem.FrmProgress.Visible = false;
  }

  public void CreatCodeFromJobShapeItem(
    ref DrillJob Job,
    List<DrillItem> ItemShape,
    List<DrillItem> ItemDrillShape,
    List<DrillItem> ItemSlotShape)
  {
    this.list_2.Clear();
    this.list_3.Clear();
    double num1 = 0.0;
    double num2 = 0.0;
    Point3D point3D = new Point3D();
    DrillMoveOptions drillMoveOptions = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
    if (ItemShape.Count > 0 | ItemDrillShape.Count > 0 | ItemSlotShape.Count > 0 | Job.MakeContour)
    {
      if (Job.Moves[Job.Moves.Count - 1].XPosition != 0.0)
      {
        double num3 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
        num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
        if (num3 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
        {
          double X = clsDrill.varDrillMachineSettings.MachineMinXStroke - num3;
          this.list_2.Clear();
          this.list_2.Add("G0 X" + X.ToString("f2"));
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition + X, Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition + X, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(), this.list_2, this.list_3, ref Job);
          List<string> collection = new List<string>();
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R900=" + (-X).ToString("f1"));
          this.list_2.Add("L CARPB.ISC");
          double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper + X;
          double newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + X;
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, this.list_2, this.list_3, ref Job);
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R901=" + (-X).ToString("f1"));
          this.list_2.Add("L CARPA.ISC");
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, this.list_2, this.list_3, ref Job);
          DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
          drillMove.Command = DrillMoveCommand.GCodeList;
          drillMove.pntCenter = new Point3D();
          drillMove.CodeLines = new List<string>();
          if (collection.Count > 0)
          {
            drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
            Job.Moves.Add(drillMove);
          }
        }
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition, Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, 0.0, new DrillMoveOptions(), ref Job);
      }
      if (clsInit.appDrill.MachType == DrillMachineType.GoWithNoAtc)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (clsDrill.ToolList[index].Data.No == 31 /*0x1F*/)
            clsDrill.toolTop = new ToolBase5(clsDrill.ToolList[index]);
        }
      }
      if (clsInit.appDrill.MachType == DrillMachineType.GoWithAtc)
        clsDrill.toolTop = new ToolBase5(ccVars.toolActive);
      num1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      List<DrillItem> lst = new List<DrillItem>();
      List<DrillItem> drillItemList1 = new List<DrillItem>();
      List<DrillItem> ItemShape1 = new List<DrillItem>();
      for (int index = 0; index <= ItemShape.Count - 1; ++index)
      {
        if (ItemShape[index].planeName == planeBoxNames.Top)
          drillItemList1.Add(ItemShape[index]);
        lst.Add(ItemShape[index]);
      }
      for (int index = 0; index <= ItemDrillShape.Count - 1; ++index)
      {
        if (ItemDrillShape[index].planeName == planeBoxNames.Top)
        {
          drillItemList1.Add(ItemDrillShape[index]);
          drillItemList1[drillItemList1.Count - 1].isDrill = true;
        }
        lst.Add(ItemDrillShape[index]);
      }
      for (int index = 0; index <= ItemSlotShape.Count - 1; ++index)
      {
        bool flag = false;
        if (ItemSlotShape[index].planeName == planeBoxNames.Top)
        {
          if (!(ItemSlotShape[index].Type == DrillItemType.SlotByMilling & ItemSlotShape[index].Command == drillCommands.CutHorizontal) || ItemSlotShape[index].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
            ;
          if (!flag)
          {
            if (ItemSlotShape[index].ShapeData.Length > 2000.0)
              ;
            drillItemList1.Add(ItemSlotShape[index]);
          }
        }
        if (!flag)
          lst.Add(ItemSlotShape[index]);
      }
      List<DrillItem> drillItemList2 = this.SortShapeByXDistance(lst, new DrillItem(), SortDirection.LowerToBigger);
      List<DrillItem> ItemShape2 = new List<DrillItem>();
      for (int index = 0; index <= drillItemList2.Count - 1; ++index)
      {
        if (drillItemList2[index].planeName == planeBoxNames.Top)
          ItemShape2.Add(drillItemList2[index]);
      }
      List<DrillItem> entInClamperArea = new List<DrillItem>();
      for (int index = 0; index <= drillItemList2.Count - 1; ++index)
      {
        if (drillItemList2[index].planeName == planeBoxNames.Top)
        {
          double num4 = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
          if (clsDrill.toolTop.Geometry.Length - drillItemList2[index].ShapeData.Depth - clsDrill.varDrillCNCSettings.ClamperThickness > 0.0)
            num4 = clsDrill.toolTop.Geometry.Diameter / 2.0 + 5.0;
          if (Math.Abs(drillItemList2[index].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + num4)
            entInClamperArea.Add(new DrillItem(drillItemList2[index]));
        }
      }
      double x1Clamper1 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
      double x2Clamper1 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
      this.AdjustClamperForShape(ref Job, entInClamperArea, x1Clamper1, x2Clamper1);
      if (ItemShape1.Count > 0)
      {
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.ParkY2, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, this.NoMove, ref Job);
        this.CreateCodeForSlotTopSide(ref ItemShape1, true, clsDrill.toolTop, ref Job);
        TpPnt9D LastP9 = new TpPnt9D();
        if (Job.Cams.Count > 0)
        {
          clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP9);
          string Lines = "";
          for (int index1 = 0; index1 <= Job.Cams.Count - 1; ++index1)
          {
            for (int index2 = 0; index2 <= Job.Cams[index1].CamPoints.Count - 1; ++index2)
            {
              if (Job.Cams[index1].CamPoints[index2].ToolCam != null)
              {
                Job.Cams[index1].CamPoints[index2].PreCodes.Add((object) ("M6 T" + Job.Cams[index1].CamPoints[index2].ToolCam.Data.No.ToString()));
                Job.Cams[index1].CamPoints[index2].PreCodes.Add((object) "$M39");
                double spindleSpeed = Job.Cams[index1].CamPoints[index2].ToolCam.CamData.SpindleSpeed;
                if (ItemShape1[index1].SpindleSpeed > 0.0)
                  spindleSpeed = ItemShape1[index1].SpindleSpeed;
                Job.Cams[index1].CamPoints[index2].PreCodes.Add((object) $"S{spindleSpeed.ToString()} M3");
                Job.Cams[index1].CamPoints[index2].PreCodes.Add((object) "M149");
              }
            }
          }
          Job.Cams[0].CamPoints[0].Points[0].AfterCodes.Add((object) "M1091");
          clsInit.cGcodeCreate.CreatGCode(Job.Cams, ccVars.PostActive, ref Lines);
          DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCode, Job.Moves[Job.Moves.Count - 1].XPosition);
          drillMove.pntCenter = new Point3D();
          drillMove.CodeLines = new List<string>();
          buString5.StringToListByNewLine(Lines, ref drillMove.CodeLines);
          if (drillMove.CodeLines[drillMove.CodeLines.Count - 1].Trim().Length == 0)
            drillMove.CodeLines.RemoveAt(drillMove.CodeLines.Count - 1);
          Job.Moves.Add(drillMove);
        }
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.GCode, drillPlaneNames.Top, this.NoMove, ref Job);
      }
      if (ItemShape2.Count > 0)
      {
        double x1Clamper2 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
        double x2Clamper2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
        double num5 = 0.0;
        double num6 = 0.0;
        double x = clsDrill.toolTop.Positions.CommonOffset.X;
        for (int index = 0; index <= ItemShape2.Count - 1; ++index)
        {
          if ((ItemShape2[index].ToolMilling == null ? 0 : (ItemShape2[index].ToolMilling.Data.No >= 30 & ItemShape2[index].ToolMilling.Data.No <= 40 ? 1 : 0)) != 0)
            clsDrill.toolTop = new ToolBase5(ItemShape2[index].ToolMilling);
          double ClamperMinXToToolX = 0.0;
          double ClamperMaxXToToolX = 0.0;
          double ExtraOffset = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
          if (clsDrill.toolTop.Geometry.Length - ItemShape2[index].ShapeData.Depth - clsDrill.varDrillCNCSettings.ClamperThickness > 0.0)
            ExtraOffset = clsDrill.toolTop.Geometry.Diameter / 2.0 + 5.0;
          if (Math.Abs(ItemShape2[index].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + ExtraOffset)
          {
            if (this.isItemInsideClamper(ItemShape2[index], x2Clamper2 + clsDrill.toolTop.Positions.CommonOffset.X + num6, clsDrill.toolTop, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, ExtraOffset) | Math.Abs(ClamperMaxXToToolX) < 5.0 & Math.Abs(ClamperMaxXToToolX) > 0.0 | Math.Abs(ClamperMinXToToolX) < 20.0 & Math.Abs(ClamperMinXToToolX) > 0.0)
            {
              if (x2Clamper2 + ClamperMinXToToolX < clsDrill.varDrillCNCSettings.ClamperLength / 2.0)
              {
                num6 += ClamperMinXToToolX;
                double num7 = x2Clamper2 + x + num6 + ItemShape2[index].BoxMinItem.X - clsDrill.toolTop.Positions.CommonOffset.X;
                if (num7 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset)
                {
                  double num8 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset - num7;
                  num6 += num8;
                  ClamperMinXToToolX += num8;
                }
                ItemShape2[index].X2Move = ClamperMinXToToolX;
              }
              else
                ItemShape2[index].X2Move = -ClamperMaxXToToolX;
            }
            if (this.isItemInsideClamper(ItemShape2[index], x1Clamper2 + clsDrill.toolTop.Positions.CommonOffset.X + num5, clsDrill.toolTop, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, ExtraOffset) | Math.Abs(ClamperMaxXToToolX) < 20.0 & Math.Abs(ClamperMaxXToToolX) > 0.0 | Math.Abs(ClamperMinXToToolX) < 20.0 & Math.Abs(ClamperMinXToToolX) > 0.0)
            {
              num5 += ClamperMinXToToolX;
              double num9 = x1Clamper2 + x + num5 + ItemShape2[index].BoxMinItem.X - clsDrill.toolTop.Positions.CommonOffset.X;
              if (num9 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset)
              {
                double num10 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset - num9;
                num5 += num10;
                ClamperMinXToToolX += num10;
              }
              double num11 = x2Clamper2 + num6;
              if (num11 - (x1Clamper2 + num5) < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
              {
                double num12 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (num11 - (x1Clamper2 + num5));
                num6 += num12;
                ItemShape2[index].X2Move = num12;
                ItemShape2[index].X1First = false;
              }
              ItemShape2[index].X1Move = ClamperMinXToToolX;
            }
          }
        }
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.ParkY2, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, this.NoMove, ref Job);
        this.CreateCodeForShapeTopAndBottomSide(ref ItemShape2, false, true, clsDrill.toolTop, ref Job);
        double x1Clamper3 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
        double x2Clamper3 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
        double xposition = Job.Moves[Job.Moves.Count - 1].XPosition;
        double num13 = 0.0;
        TpPnt9D LastP9 = new TpPnt9D();
        if (Job.Cams.Count > 0)
        {
          clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP9);
          string Lines = "";
          for (int index3 = 0; index3 <= Job.Cams.Count - 1; ++index3)
          {
            for (int index4 = 0; index4 <= Job.Cams[index3].CamPoints.Count - 1; ++index4)
            {
              if (Job.Cams[index3].CamPoints[index4].ToolCam != null)
              {
                Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) ("M6 T" + Job.Cams[index3].CamPoints[index4].ToolCam.Data.No.ToString()));
                Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "$M39");
                double spindleSpeed = Job.Cams[index3].CamPoints[index4].ToolCam.CamData.SpindleSpeed;
                if (ItemShape2[index3].SpindleSpeed > 0.0)
                  spindleSpeed = ItemShape2[index3].SpindleSpeed;
                Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) $"S{spindleSpeed.ToString()} M3");
                Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "M149");
                Point3D MinPoint = new Point3D();
                Point3D MaxPoint = new Point3D();
                clsInit.cVector5.BoxSizeCalculate(Job.Cams[index3].CamPoints[index4].Points, ref MinPoint, ref MaxPoint);
                for (int index5 = 0; index5 <= Job.Cams[index3].CamPoints[index4].Points.Count - 1; ++index5)
                {
                  x1Clamper3 += Job.Cams[index3].CamPoints[index4].Points[index5].P9.X - num13;
                  x2Clamper3 += Job.Cams[index3].CamPoints[index4].Points[index5].P9.X - num13;
                  xposition += Job.Cams[index3].CamPoints[index4].Points[index5].P9.X - num13;
                  num13 = Job.Cams[index3].CamPoints[index4].Points[index5].P9.X;
                }
                if (x1Clamper3 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
                  ;
                if (x2Clamper3 > clsDrill.varDrillMachineSettings.MachineMaxXStroke)
                {
                  Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "M85");
                  Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "R910=0");
                  Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "R900=850");
                  Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "L CARPB.ISC");
                  x2Clamper3 -= 850.0;
                  Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "M85");
                  Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "R910=0");
                  Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "R901=850");
                  Job.Cams[index3].CamPoints[index4].PreCodes.Add((object) "L CARPA.ISC");
                  x1Clamper3 -= 850.0;
                }
              }
            }
          }
          Job.Cams[0].CamPoints[0].Points[0].AfterCodes.Add((object) "M1091");
          clsInit.cGcodeCreate.CreatGCode(Job.Cams, ccVars.PostActive, ref Lines);
          DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCode, Job.Moves[Job.Moves.Count - 1].XPosition);
          drillMove.pntCenter = new Point3D();
          drillMove.CodeLines = new List<string>();
          buString5.StringToListByNewLine(Lines, ref drillMove.CodeLines);
          if (drillMove.CodeLines[drillMove.CodeLines.Count - 1].Trim().Length == 0)
            drillMove.CodeLines.RemoveAt(drillMove.CodeLines.Count - 1);
          Job.Moves.Add(drillMove);
        }
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.GCode, drillPlaneNames.Top, this.NoMove, ref Job);
      }
      List<DrillItem> drillItemList3 = new List<DrillItem>();
      for (int index = 0; index <= drillItemList2.Count - 1; ++index)
      {
        if (drillItemList2[index].planeName == planeBoxNames.Bottom && Math.Abs(drillItemList2[index].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.BottomKorukYMinusDistance)
          drillItemList3.Add(new DrillItem(drillItemList2[index]));
      }
      if (Job.Moves[Job.Moves.Count - 1].XPosition == 0.0)
      {
        num1 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
        num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
      }
      else
      {
        num1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
        num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      }
    }
    else
    {
      if (Job.Cams.Count <= 0)
        return;
      TpPnt9D LastP9 = new TpPnt9D();
      clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP9);
      string Lines = "";
      clsInit.cGcodeCreate.CreatGCode(Job.Cams, ccVars.PostActive, ref Lines);
      DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCode, Job.Moves[Job.Moves.Count - 1].XPosition);
      drillMove.pntCenter = new Point3D();
      drillMove.CodeLines = new List<string>();
      buString5.StringToListByNewLine(Lines, ref drillMove.CodeLines);
      drillMove.CodeLines.Insert(0, "M6 T" + clsDrill.toolTop.Data.No.ToString());
      drillMove.CodeLines.Insert(1, "$M39");
      drillMove.CodeLines.Insert(2, $"S{clsDrill.toolTop.CamData.SpindleSpeed.ToString()} M3");
      drillMove.CodeLines.Insert(3, "M149");
      drillMove.CodeLines.Insert(4, "M1091");
      if (drillMove.CodeLines[drillMove.CodeLines.Count - 1].Trim().Length == 0)
        drillMove.CodeLines.RemoveAt(drillMove.CodeLines.Count - 1);
      Job.Moves.Add(drillMove);
    }
  }

  public void AdjustClamperForShape(
    ref DrillJob Job,
    List<DrillItem> entInClamperArea,
    double lastX1,
    double lastX2)
  {
    double APos1 = 0.0;
    double num1 = 0.0;
    double num2 = 0.0;
    if (entInClamperArea.Count == 0 && Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].X1Clamper < Job.Material.Size.Width * 0.25)
    {
      DrillMove move = Job.Moves[Job.Moves.Count - 1];
      if (move.X2Clamper > move.XPosition)
        move.X2Clamper = move.XPosition - 150.0;
      if (move.X1Clamper > move.XPosition - Job.Material.Size.Width * 0.5)
        move.X1Clamper = move.XPosition - Job.Material.Size.Width + 50.0;
      if (move.X2Clamper - move.X1Clamper < clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        move.X1Clamper = move.X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
      double APos2 = Job.Moves[Job.Moves.Count - 1].X1Clamper - lastX1;
      double BPos = Job.Moves[Job.Moves.Count - 1].X2Clamper - lastX2;
      this.MoveClampers(this.NoMove, lastX2, drillPlaneNames.Top, ref Job, true);
      this.AddClamperMoveForCnc(ref Job, APos2, BPos, false);
    }
    else if (Job.Material.Size.Width > clsDrill.varDrillMachineSettings.MachineMillingStandartXStroke)
    {
      double num3 = Job.Material.Size.Width - clsDrill.varDrillMachineSettings.MachineMillingStandartXStroke;
      double num4 = lastX2 - num3;
      if (num4 - lastX1 > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
      {
        lastX2 = num4;
        double APos3 = 0.0;
        double BPos = Job.Moves[Job.Moves.Count - 1].X2Clamper - lastX2;
        this.MoveClampers(this.NoMove, lastX2, drillPlaneNames.Top, ref Job, true);
        this.AddClamperMoveForCnc(ref Job, APos3, BPos, false);
      }
      else
      {
        if (num4 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance) <= clsDrill.varDrillMachineSettings.MachineMinXStroke)
          return;
        lastX2 = num4;
        lastX1 = num4 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
        double APos4 = Job.Moves[Job.Moves.Count - 1].X1Clamper - lastX1;
        double BPos = Job.Moves[Job.Moves.Count - 1].X2Clamper - lastX2;
        this.MoveClampers(lastX1, this.NoMove, drillPlaneNames.Top, ref Job, true);
        this.MoveClampers(this.NoMove, lastX2, drillPlaneNames.Top, ref Job, true);
        this.AddClamperMoveForCnc(ref Job, APos4, BPos, true);
      }
    }
    else
    {
      List<MinMidMaxRange> minMidMaxRangeList1 = new List<MinMidMaxRange>();
      List<MinMidMaxRange> minMidMaxRangeList2 = new List<MinMidMaxRange>();
      List<double> RefList = new List<double>();
      for (int index = 0; index <= entInClamperArea.Count - 1; ++index)
      {
        RefList.Add(entInClamperArea[index].BoxMinOfDrawing.X);
        RefList.Add(entInClamperArea[index].BoxMaxOfDrawing.X);
        if (entInClamperArea[index].planeName == planeBoxNames.Bottom)
          ;
        MinMidMaxRange minMidMaxRange = new MinMidMaxRange()
        {
          Min = entInClamperArea[index].BoxMinOfDrawing.X,
          Max = entInClamperArea[index].BoxMaxOfDrawing.X
        };
        minMidMaxRange.Mid = (minMidMaxRange.Min + minMidMaxRange.Max) / 2.0;
        minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
        minMidMaxRangeList2.Add(minMidMaxRange);
      }
      clsInit.cVector5.SortList(SortDirectionType.Bigger, ref RefList);
      bool flag1 = false;
      if (entInClamperArea.Count > 0 && entInClamperArea[0].planeName == planeBoxNames.Bottom)
        flag1 = true;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        double num5 = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
        if (flag1)
          num5 = clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance;
        if (index == 0)
        {
          MinMidMaxRange minMidMaxRange = new MinMidMaxRange()
          {
            Max = 0.0,
            Min = RefList[index] + num5
          };
          minMidMaxRange.Mid = (minMidMaxRange.Min + minMidMaxRange.Max) / 2.0;
          minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
          if (minMidMaxRange.Max > minMidMaxRange.Min & minMidMaxRange.Range > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
            minMidMaxRangeList1.Add(minMidMaxRange);
        }
        if (index > 0)
        {
          MinMidMaxRange minMidMaxRange = new MinMidMaxRange()
          {
            Max = RefList[index - 1] - num5,
            Min = RefList[index] + num5
          };
          minMidMaxRange.Mid = (minMidMaxRange.Min + minMidMaxRange.Max) / 2.0;
          minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
          if (minMidMaxRange.Max > minMidMaxRange.Min & minMidMaxRange.Range > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
            minMidMaxRangeList1.Add(minMidMaxRange);
        }
        if (index == RefList.Count - 1)
        {
          MinMidMaxRange minMidMaxRange = new MinMidMaxRange()
          {
            Max = RefList[index] - num5,
            Min = -clsDrill.activeJob.Material.Size.Width
          };
          minMidMaxRange.Mid = (minMidMaxRange.Min + minMidMaxRange.Max) / 2.0;
          minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
          if (minMidMaxRange.Max > minMidMaxRange.Min & minMidMaxRange.Range > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
            minMidMaxRangeList1.Add(minMidMaxRange);
        }
      }
      num1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = true;
      bool flag5 = true;
      for (int index = 0; index <= minMidMaxRangeList2.Count - 1; ++index)
      {
        double num6 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
        double num7 = Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
        double num8 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
        double num9 = Job.Moves[Job.Moves.Count - 1].X2Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
        if (num8 > minMidMaxRangeList2[index].Min & num8 < minMidMaxRangeList2[index].Max)
          flag5 = false;
        if (num9 > minMidMaxRangeList2[index].Min & num9 < minMidMaxRangeList2[index].Max)
          flag5 = false;
        if (minMidMaxRangeList2[index].Min > num8 & minMidMaxRangeList2[index].Min < num9)
          flag5 = false;
        if (minMidMaxRangeList2[index].Max > num8 & minMidMaxRangeList2[index].Max < num9)
          flag5 = false;
        if (num6 > minMidMaxRangeList2[index].Min & num6 < minMidMaxRangeList2[index].Max)
          flag4 = false;
        if (num7 > minMidMaxRangeList2[index].Min & num7 < minMidMaxRangeList2[index].Max)
          flag4 = false;
        if (minMidMaxRangeList2[index].Min > num6 & minMidMaxRangeList2[index].Min < num7)
          flag4 = false;
        if (minMidMaxRangeList2[index].Max > num6 & minMidMaxRangeList2[index].Max < num7)
          flag4 = false;
      }
      if (minMidMaxRangeList1.Count > 0)
      {
        double newX2 = 0.0;
        double newX1_1 = 0.0;
        if (flag4)
          newX1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
        if (flag5)
          newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
        if (!flag5)
        {
          for (int index = 0; index <= minMidMaxRangeList1.Count - 1; ++index)
          {
            if (index == 0)
            {
              if (minMidMaxRangeList1[index].Max > -0.1)
              {
                if (Math.Abs(minMidMaxRangeList1[index].Min) < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
                {
                  if (minMidMaxRangeList1.Count >= 2)
                  {
                    if (minMidMaxRangeList1[1].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
                    {
                      if (Math.Abs(minMidMaxRangeList1[1].Max) < Job.Material.Size.Width / 3.0)
                      {
                        newX2 = minMidMaxRangeList1[1].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                        if (newX2 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0)
                          flag3 = true;
                      }
                      else if (Math.Abs(minMidMaxRangeList1[index].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                      {
                        newX2 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                        if (newX2 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0)
                          flag3 = true;
                      }
                    }
                    else if (Math.Abs(minMidMaxRangeList1[index].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                    {
                      newX2 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                      if (newX2 < 0.0 & 2.0 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0)
                        flag3 = true;
                    }
                  }
                  else if (Math.Abs(minMidMaxRangeList1[index].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                  {
                    newX2 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                    if (newX2 < 0.0 & newX2 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0)
                      flag3 = true;
                  }
                }
                else
                {
                  newX2 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                  if (newX2 < 0.0 & newX2 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0)
                    flag3 = true;
                }
              }
              else if (minMidMaxRangeList1[index].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
              {
                newX2 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                flag3 = true;
              }
            }
            else if (!flag3 && minMidMaxRangeList1[index].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
            {
              newX2 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
              flag3 = true;
            }
          }
        }
        if (!flag4)
        {
          for (int index = minMidMaxRangeList1.Count - 1; index >= 0; --index)
          {
            if (index == minMidMaxRangeList1.Count - 1)
            {
              if (minMidMaxRangeList1[index].Min <= -clsDrill.activeJob.Material.Size.Width)
              {
                if (minMidMaxRangeList1[index].Range < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
                {
                  if (minMidMaxRangeList1.Count >= 2)
                  {
                    if (minMidMaxRangeList1[minMidMaxRangeList1.Count - 2].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
                    {
                      if (minMidMaxRangeList1[minMidMaxRangeList1.Count - 2].Min < -Job.Material.Size.Width * 0.66)
                      {
                        double num10 = minMidMaxRangeList1[minMidMaxRangeList1.Count - 2].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                        if (newX2 - num10 > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
                        {
                          newX1_1 = minMidMaxRangeList1[minMidMaxRangeList1.Count - 2].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                          if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                            flag2 = true;
                        }
                        else if (Math.Abs(minMidMaxRangeList1[index].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                        {
                          newX1_1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                          if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                            flag2 = true;
                        }
                      }
                      else if (Math.Abs(minMidMaxRangeList1[index].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                      {
                        newX1_1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                        if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                          flag2 = true;
                      }
                    }
                    else if (Math.Abs(minMidMaxRangeList1[index].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                    {
                      newX1_1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                      if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                        flag2 = true;
                    }
                  }
                  else if (Math.Abs(minMidMaxRangeList1[index].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                  {
                    newX1_1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                    if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                      flag2 = true;
                  }
                }
                else if (minMidMaxRangeList1[index].Range < clsDrill.varDrillCNCSettings.ClamperLength * 2.0)
                {
                  newX1_1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                  if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                    flag2 = true;
                }
                else
                {
                  newX1_1 = minMidMaxRangeList1[index].Min + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0);
                  if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                    flag2 = true;
                }
              }
              else if (minMidMaxRangeList1[index].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
              {
                newX1_1 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
                if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                  flag2 = true;
              }
            }
            else if (!flag2 && minMidMaxRangeList1[index].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
            {
              newX1_1 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
              if (newX1_1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
              {
                flag2 = true;
              }
              else
              {
                double num11 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
                double num12 = minMidMaxRangeList1[index].Max - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance);
                if (clsDrill.varDrillMachineSettings.MachineMinXStroke > num11 & clsDrill.varDrillMachineSettings.MachineMinXStroke < num12)
                {
                  newX1_1 = clsDrill.varDrillMachineSettings.MachineMinXStroke;
                  flag2 = true;
                }
              }
              if (!flag2)
                ;
            }
          }
        }
        double num13 = clsDrill.activeJob.Material.Size.Width - Math.Abs(newX1_1);
        if (num13 < 0.0 & clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - Math.Abs(num13) < 50.0)
          newX1_1 = -clsDrill.activeJob.Material.Size.Width;
        List<string> stringList = new List<string>();
        if (!flag5)
        {
          if (flag3)
          {
            if (!buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X2Clamper, newX2))
            {
              if (newX2 < -Job.Material.Size.Width / 2.0)
              {
                for (int index = 0; index <= minMidMaxRangeList2.Count - 1; ++index)
                {
                  if (-Job.Material.Size.Width / 2.0 < minMidMaxRangeList2[index].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
                    newX2 = -Job.Material.Size.Width / 2.0;
                }
              }
              APos1 = 0.0;
              if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
              {
                newX1_1 = newX2 - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
                APos1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1_1;
                this.MoveClampers(newX1_1, this.NoMove, drillPlaneNames.Top, ref Job, true);
              }
              double BPos = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
              this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job, true);
              this.AddClamperMoveForCnc(ref Job, APos1, BPos, true);
            }
          }
          else
            stringList.Add(buDrillCalc.LangDrillMessage[25] + " [X2]");
        }
        if (!flag4)
        {
          if (flag2)
          {
            if (!buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X1Clamper, newX1_1) && newX1_1 < -Job.Material.Size.Width / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
            {
              double num14 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1_1;
              APos1 = 0.0;
              if (num14 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
              {
                newX1_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
                APos1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1_1;
              }
              double BPos = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
              this.MoveClampers(newX1_1, this.NoMove, drillPlaneNames.Top, ref Job, true);
              this.AddClamperMoveForCnc(ref Job, APos1, BPos, true);
            }
          }
          else
            stringList.Add(buDrillCalc.LangDrillMessage[25] + " [X1]");
        }
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double newX1_2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          double BPos = 0.0;
          APos1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1_2;
          this.MoveClampers(newX1_2, this.NoMove, drillPlaneNames.Top, ref Job, true);
          this.AddClamperMoveForCnc(ref Job, APos1, BPos, true);
        }
      }
      if (!(entInClamperArea.Count > 0 & minMidMaxRangeList2.Count > 0 & (minMidMaxRangeList1.Count == 0 | !flag3 & !flag5)))
        return;
      double xposition = Job.Moves[Job.Moves.Count - 1].XPosition;
      if (Job.Material.Size.Width < 300.0)
      {
        double newX2 = minMidMaxRangeList2[0].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - 20.0;
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double newX1 = newX2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
          APos1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job, true);
        }
        double BPos = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
        this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job, true);
        this.AddClamperMoveForCnc(ref Job, APos1, BPos, true);
      }
      else if (Job.Material.Size.Width >= 300.0 & Job.Material.Size.Width <= 500.0)
      {
        double newX2 = -Job.Material.Size.Width / 2.0;
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double newX1 = newX2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
          APos1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job, true);
        }
        double BPos = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
        this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job, true);
        this.AddClamperMoveForCnc(ref Job, APos1, BPos, true);
      }
      else
      {
        double newX2 = minMidMaxRangeList2[0].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - 150.0;
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double newX1 = newX2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
          APos1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job, true);
        }
        double BPos = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
        this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job, true);
        this.AddClamperMoveForCnc(ref Job, APos1, BPos, true);
      }
    }
  }

  public void CreatCodeFromJobShapeContourAndSlotItem(ref DrillJob Job)
  {
    bool flag = false;
    List<DrillItem> drillItemList1 = new List<DrillItem>();
    DrillItem drillItem1 = new DrillItem();
    for (int index = 0; index <= Job.Items.Count - 1; ++index)
    {
      if (Job.Items[index].ShapeGroup == ShapeGroup.Contour)
      {
        flag = true;
        DrillItem drillItem2 = new DrillItem(Job.Items[index], true);
        drillItem2.shapeEntitites.Clear();
        if (Job.Items[index].Tool != null)
          drillItem2.ToolMilling = new ToolBase5(Job.Items[index].Tool);
        drillItemList1.Add(drillItem2);
      }
    }
    if (!flag)
      return;
    if (clsInit.appDrill.MachType == DrillMachineType.GoWithNoAtc)
    {
      for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
      {
        if (clsDrill.ToolList[index].Data.No == 31 /*0x1F*/)
          clsDrill.toolTop = new ToolBase5(clsDrill.ToolList[index]);
      }
    }
    if (clsInit.appDrill.MachType == DrillMachineType.GoWithAtc)
      clsDrill.toolTop = new ToolBase5(ccVars.toolActive);
    double X = Job.Moves[Job.Moves.Count - 1].XPosition;
    double X1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
    double X2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
    this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - X, Job.Moves[Job.Moves.Count - 1].X2Clamper - X, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.Fast, 0.0, 0, 0, 0, 0, 0, 0, ref Job);
    List<DrillItem> drillItemList2 = new List<DrillItem>();
    List<DrillItem> drillItemList3 = new List<DrillItem>();
    List<DrillItem> drillItemList4 = new List<DrillItem>();
    if (!flag)
      return;
    for (int index1 = 0; index1 <= drillItemList1.Count - 1; ++index1)
    {
      bool isTop = true;
      ToolBase5 Tool = new ToolBase5(clsDrill.toolTop);
      if (drillItemList1[index1].ToolMilling != null)
        Tool = new ToolBase5(drillItemList1[index1].ToolMilling);
      double num1 = clsDrill.varDrillCNCSettings.ContourLimitLenForTopSpindleOneMove;
      if (drillItemList1[index1].planeName == planeBoxNames.Bottom)
      {
        num1 = clsDrill.varDrillCNCSettings.ContourLimitLenForBottomSpindleOneMove;
        Tool = new ToolBase5(clsDrill.toolBottom);
        isTop = false;
      }
      List<DrillItem> ItemShape1 = new List<DrillItem>();
      List<DrillItem> ItemShape2 = new List<DrillItem>();
      DrillItem drillItem3 = new DrillItem(drillItemList1[index1]);
      this.MillingContourClamperPositions(Job, isTop, ref X1, ref X2);
      if (Job.Material.Size.Width >= num1)
      {
        if (X2 - Job.Moves[Job.Moves.Count - 1].X1Clamper > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength)
        {
          if (Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper - X2) > 0.2)
            this.MoveClampers(this.NoMove, X2, drillPlaneNames.Top, ref Job);
          if (Math.Abs(Job.Moves[Job.Moves.Count - 1].X1Clamper - X1) > 0.2)
            this.MoveClampers(X1, this.NoMove, drillPlaneNames.Top, ref Job);
        }
        else
        {
          if (Math.Abs(Job.Moves[Job.Moves.Count - 1].X1Clamper - X1) > 0.2)
            this.MoveClampers(X1, this.NoMove, drillPlaneNames.Top, ref Job);
          if (Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper - X2) > 0.2)
            this.MoveClampers(this.NoMove, X2, drillPlaneNames.Top, ref Job);
        }
      }
      else if (Job.Moves[Job.Moves.Count - 1].X2Clamper - X1 > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength)
      {
        if (Math.Abs(Job.Moves[Job.Moves.Count - 1].X1Clamper - X1) > 0.2)
          this.MoveClampers(X1, this.NoMove, drillPlaneNames.Top, ref Job);
        if (Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper - X2) > 0.2)
          this.MoveClampers(this.NoMove, X2, drillPlaneNames.Top, ref Job);
      }
      else
      {
        if (Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper - X2) > 0.2)
          this.MoveClampers(this.NoMove, X2, drillPlaneNames.Top, ref Job);
        if (Math.Abs(Job.Moves[Job.Moves.Count - 1].X1Clamper - X1) > 0.2)
          this.MoveClampers(X1, this.NoMove, drillPlaneNames.Top, ref Job);
      }
      drillItem3.Command = drillCommands.DrawingContour;
      if (drillItem3.planeName == planeBoxNames.Top)
      {
        this.CreateContourEntities(Job, drillItem3, Tool, isTop, ref drillItem3.X1Move, ref drillItem3.X2Move, ref drillItem3.X1First, ref drillItem3.ClockDir, ref drillItem3.shapeEntitites);
        drillItem3.isMillingAtClamperSide = true;
        ItemShape1.Add(drillItem3);
        drillItemList2.Add(new DrillItem(drillItem3));
      }
      if (drillItem3.planeName == planeBoxNames.Bottom)
      {
        this.CreateContourEntities(Job, drillItem3, Tool, isTop, ref drillItem3.X1Move, ref drillItem3.X2Move, ref drillItem3.X1First, ref drillItem3.ClockDir, ref drillItem3.shapeEntitites);
        drillItem3.isMillingAtClamperSide = true;
        ItemShape2.Add(drillItem3);
        drillItemList2.Add(new DrillItem(drillItem3));
      }
      if (ItemShape1.Count > 0)
      {
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, this.NoMove, ref Job);
        this.CreateCodeForShapeTopAndBottomSide(ref ItemShape1, false, true, clsDrill.toolTop, ref Job);
        double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
        double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
        for (int index2 = 0; index2 <= ItemShape1.Count - 1; ++index2)
        {
          x1Clamper += ItemShape1[index2].X1Move;
          x2Clamper += ItemShape1[index2].X2Move;
        }
        TpPnt9D LastP9 = new TpPnt9D();
        clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP9);
        X = LastP9.P9.X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
        X1 = x1Clamper + X;
        X2 = x2Clamper + X;
        this.AddDrillMove(X1, X2, LastP9.P9.Y, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.GCode, drillPlaneNames.Top, X, ref Job);
        camTpPoint camPoint = Job.Cams[Job.Cams.Count - 1].CamPoints[Job.Cams[Job.Cams.Count - 1].CamPoints.Count - 1];
        double num2 = camPoint.Points[camPoint.Points.Count - 1].P9.Y + 100.0;
        camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add((object) "M26");
      }
      if (ItemShape2.Count > 0)
      {
        this.CreateCodeForShapeTopAndBottomSide(ref ItemShape2, false, false, clsDrill.toolBottom, ref Job);
        double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
        double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
        for (int index3 = 0; index3 <= ItemShape2.Count - 1; ++index3)
        {
          x1Clamper += ItemShape2[index3].X1Move;
          x2Clamper += ItemShape2[index3].X2Move;
        }
        TpPnt9D LastP9 = new TpPnt9D();
        clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP9);
        X = LastP9.P9.X + clsDrill.varDrillCNCSettings.Tool270XZeroOffset;
        X1 = x1Clamper + X;
        X2 = x2Clamper + X;
        double Y1 = Job.Cams[Job.Cams.Count - 1].CamPoints[0].Points[0].P9.Y + 0.0;
        double y = Job.Cams[Job.Cams.Count - 1].CamPoints[0].Points[0].P9.Y;
        double parkY2 = clsDrill.varDrillCNCSettings.ParkY2;
        DrillMoveOptions Options = new DrillMoveOptions(drillPlaneNames.Bottom, DrillCNCMode.Z1_Z2NoOffset, DrillMoveAddType.OnlyMove);
        this.AddDrillMove(this.NoMove, this.NoMove, Y1, parkY2, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        this.AddDrillMove(X1, X2, this.NoMove, this.NoMove, LastP9.P9.Y, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z3SafeDistance, DrillMoveCommand.GCode, drillPlaneNames.Bottom, X, ref Job);
        camTpPoint camPoint = Job.Cams[Job.Cams.Count - 1].CamPoints[Job.Cams[Job.Cams.Count - 1].CamPoints.Count - 1];
        camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add((object) "M28");
      }
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - X, Job.Moves[Job.Moves.Count - 1].X2Clamper - X, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.Fast, 0.0, 0, 0, 0, 0, 0, 0, ref Job);
    }
  }

  public void CreateContourEntities(
    DrillJob Job,
    DrillItem ContourOP,
    ToolBase5 Tool,
    bool isTop,
    ref double X1Move,
    ref double X2Move,
    ref bool isX1First,
    ref ClockDirectionType ClockDir,
    ref List<List<buEntity>> ELL)
  {
    double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
    double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
    double num1 = Tool.Geometry.Diameter / 2.0 + ContourOP.Offset;
    double num2 = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + 10.0;
    double num3 = clsDrill.varDrillCNCSettings.ContourLimitLenForTopSpindleOneMove;
    if (!isTop)
    {
      num2 = Math.Abs(clsDrill.varDrillCNCSettings.BottomKorukXMinusDistance) + clsDrill.varDrillCNCSettings.ClamperSafeXDistance;
      num3 = clsDrill.varDrillCNCSettings.ContourLimitLenForBottomSpindleOneMove;
    }
    if (isTop & clsDrill.varDrillCNCSettings.ContourTopDirection == ClockDirectionType.CW | !isTop & clsDrill.varDrillCNCSettings.ContourBottomDirection == ClockDirectionType.CW)
    {
      isX1First = false;
      ClockDir = ClockDirectionType.CW;
      if (Job.Material.Size.Width >= num3)
      {
        double x1 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
        double x2 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
        Point3D start = new Point3D(x2, num1);
        Point3D point3D1 = new Point3D(num1, num1);
        Point3D point3D2 = new Point3D(num1, -Job.Material.Size.Height - num1);
        Point3D point3D3 = new Point3D(-Job.Material.Size.Width - num1, -Job.Material.Size.Height - num1);
        Point3D point3D4 = new Point3D(-Job.Material.Size.Width - num1, num1);
        Point3D point3D5 = new Point3D(x1, num1);
        Point3D end = new Point3D(x2, num1);
        ELL.Add(new List<buEntity>()
        {
          (buEntity) new buLine(start, point3D1),
          (buEntity) new buLine(point3D1, point3D2),
          (buEntity) new buLine(point3D2, point3D3),
          (buEntity) new buLine(point3D3, point3D4),
          (buEntity) new buLine(point3D4, point3D5)
        });
        ELL.Add(new List<buEntity>()
        {
          (buEntity) new buLine(point3D5, end)
        });
        X1Move = -(clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2);
        X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2;
      }
      else
      {
        double x3;
        double x4;
        if (isTop)
        {
          if (Job.Material.Size.Width >= 500.0 & Job.Material.Size.Width < num3)
          {
            x3 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
            x4 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
          }
          else if (Job.Material.Size.Width >= 400.0 & Job.Material.Size.Width < 500.0)
          {
            x3 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
            x4 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
          }
          else
          {
            x3 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.5);
            x4 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.5);
          }
        }
        else if (Job.Material.Size.Width >= 700.0 & Job.Material.Size.Width < num3)
        {
          x3 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
          x4 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
        }
        else
        {
          x3 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
          x4 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
        }
        Point3D start = new Point3D(x4, num1);
        Point3D point3D6 = new Point3D(num1, num1);
        Point3D point3D7 = new Point3D(num1, -Job.Material.Size.Height - num1);
        Point3D point3D8 = new Point3D(-Job.Material.Size.Width - num1, -Job.Material.Size.Height - num1);
        Point3D point3D9 = new Point3D(-Job.Material.Size.Width - num1, num1);
        Point3D point3D10 = new Point3D(x3, num1);
        Point3D end = new Point3D(x4, num1);
        ELL.Add(new List<buEntity>()
        {
          (buEntity) new buLine(start, point3D6),
          (buEntity) new buLine(point3D6, point3D7),
          (buEntity) new buLine(point3D7, point3D8)
        });
        ELL.Add(new List<buEntity>()
        {
          (buEntity) new buLine(point3D8, point3D9),
          (buEntity) new buLine(point3D9, point3D10)
        });
        ELL.Add(new List<buEntity>()
        {
          (buEntity) new buLine(point3D10, end)
        });
        if (isTop)
        {
          if (Job.Material.Size.Width >= 500.0 & Job.Material.Size.Width < num3)
          {
            X1Move = x2Clamper;
            X2Move = -x2Clamper;
          }
          else if (Job.Material.Size.Width >= 400.0 & Job.Material.Size.Width < 500.0)
          {
            X1Move = x2Clamper - 20.0;
            X2Move = -x2Clamper + 20.0;
          }
          else
          {
            X1Move = x2Clamper - 75.0;
            X2Move = -x2Clamper + 65.0;
          }
        }
        else if (Job.Material.Size.Width >= 700.0 & Job.Material.Size.Width < num3)
        {
          X1Move = x2Clamper;
          X2Move = -x2Clamper;
        }
        else
        {
          X1Move = x2Clamper - 75.0;
          X2Move = -x2Clamper + 65.0;
        }
      }
    }
    if (!(isTop & clsDrill.varDrillCNCSettings.ContourTopDirection == ClockDirectionType.CCW | !isTop & clsDrill.varDrillCNCSettings.ContourBottomDirection == ClockDirectionType.CCW))
      return;
    isX1First = true;
    ClockDir = ClockDirectionType.CCW;
    if (Job.Material.Size.Width >= num3)
    {
      double x5 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
      double x6 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
      Point3D start = new Point3D(x5, num1);
      Point3D point3D11 = new Point3D(-Job.Material.Size.Width - num1, num1);
      Point3D point3D12 = new Point3D(-Job.Material.Size.Width - num1, -Job.Material.Size.Height - num1);
      Point3D point3D13 = new Point3D(num1, -Job.Material.Size.Height - num1);
      Point3D point3D14 = new Point3D(num1, num1);
      Point3D point3D15 = new Point3D(x6, num1);
      Point3D end = new Point3D(x5, num1);
      ELL.Add(new List<buEntity>()
      {
        (buEntity) new buLine(start, point3D11),
        (buEntity) new buLine(point3D11, point3D12),
        (buEntity) new buLine(point3D12, point3D13),
        (buEntity) new buLine(point3D13, point3D14),
        (buEntity) new buLine(point3D14, point3D15)
      });
      ELL.Add(new List<buEntity>()
      {
        (buEntity) new buLine(point3D15, end)
      });
      X1Move = -(clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2);
      X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2;
    }
    else if (500.0 <= Job.Material.Size.Width & Job.Material.Size.Width < num3)
    {
      double x7;
      double x8;
      if (Job.Material.Size.Width >= 500.0)
      {
        x7 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
        x8 = x2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
      }
      else
      {
        x7 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.9);
        x8 = x2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
      }
      Point3D start = new Point3D(x7, num1);
      Point3D point3D16 = new Point3D(-Job.Material.Size.Width - num1, num1);
      Point3D point3D17 = new Point3D(-Job.Material.Size.Width - num1, -Job.Material.Size.Height - num1);
      Point3D point3D18 = new Point3D(num1, -Job.Material.Size.Height - num1);
      Point3D point3D19 = new Point3D(num1, num1);
      Point3D point3D20 = new Point3D(x8, num1);
      Point3D end = new Point3D(x7, num1);
      ELL.Add(new List<buEntity>()
      {
        (buEntity) new buLine(start, point3D16),
        (buEntity) new buLine(point3D16, point3D17),
        (buEntity) new buLine(point3D17, point3D18)
      });
      ELL.Add(new List<buEntity>()
      {
        (buEntity) new buLine(point3D18, point3D19),
        (buEntity) new buLine(point3D19, point3D20)
      });
      ELL.Add(new List<buEntity>()
      {
        (buEntity) new buLine(point3D20, end)
      });
      if (Job.Material.Size.Width >= 500.0)
      {
        X1Move = -(clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2);
        X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2;
      }
      else
      {
        X1Move = -(clsDrill.varDrillCNCSettings.ClamperLength + 1.2 * num2);
        X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 1.0 * num2;
      }
    }
    else
    {
      double x9;
      double x10;
      if (Job.Material.Size.Width >= 500.0)
      {
        x9 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
        x10 = x2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
      }
      else
      {
        x9 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
        x10 = x2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
      }
      Point3D start = new Point3D(x9, num1);
      Point3D point3D21 = new Point3D(-Job.Material.Size.Width - num1, num1);
      Point3D point3D22 = new Point3D(-Job.Material.Size.Width - num1, -Job.Material.Size.Height - num1);
      Point3D point3D23 = new Point3D(num1, -Job.Material.Size.Height - num1);
      Point3D point3D24 = new Point3D(num1, num1);
      Point3D point3D25 = new Point3D(x10, num1);
      Point3D end = new Point3D(x9, num1);
      ELL.Add(new List<buEntity>()
      {
        (buEntity) new buLine(start, point3D21),
        (buEntity) new buLine(point3D21, point3D22),
        (buEntity) new buLine(point3D22, point3D23)
      });
      ELL.Add(new List<buEntity>()
      {
        (buEntity) new buLine(point3D23, point3D24),
        (buEntity) new buLine(point3D24, point3D25)
      });
      ELL.Add(new List<buEntity>()
      {
        (buEntity) new buLine(point3D25, end)
      });
      if (Job.Material.Size.Width >= 500.0)
      {
        X1Move = -(clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2);
        X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2;
      }
      else
      {
        X1Move = -(clsDrill.varDrillCNCSettings.ClamperLength + 1.8 * num2);
        X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 1.6 * num2;
      }
    }
  }

  public void MoveSimPart(DrillMove pntMove)
  {
    clsDrill.SimToCollsionCheck1.Clear();
    clsDrill.SimToCollsionCheck2.Clear();
    if (pntMove.Command == DrillMoveCommand.Wait)
    {
      double num = 0.0;
      if (clsDrill.activeJob != null)
        num = clsDrill.activeJob.Material.Size.Depth;
      this.X1ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX1ClampZDistance + num;
      this.X2ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX2ClampZDistance + num;
    }
    if (pntMove.Command == DrillMoveCommand.AllClamperDown)
    {
      double num = 0.0;
      if (clsDrill.activeJob != null)
        num = clsDrill.activeJob.Material.Size.Depth;
      this.X1ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX1ClampZDistance + num;
      this.X2ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX2ClampZDistance + num;
    }
    if (pntMove.Command == DrillMoveCommand.AllClamperUp)
    {
      this.X1ClamperZOffset = 0.0;
      this.X2ClamperZOffset = 0.0;
    }
    if (pntMove.Command == DrillMoveCommand.Clamper1Up)
      this.X1ClamperZOffset = 0.0;
    if (pntMove.Command == DrillMoveCommand.Clamper1Down)
    {
      double num = 0.0;
      if (clsDrill.activeJob != null)
        num = clsDrill.activeJob.Material.Size.Depth;
      this.X1ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX1ClampZDistance + num;
    }
    if (pntMove.Command == DrillMoveCommand.Clamper2Up)
      this.X2ClamperZOffset = 0.0;
    if (pntMove.Command == DrillMoveCommand.Clamper2Down)
    {
      double num = 0.0;
      if (clsDrill.activeJob != null)
        num = clsDrill.activeJob.Material.Size.Depth;
      this.X2ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX2ClampZDistance + num;
    }
    if (pntMove.Command == DrillMoveCommand.ResetAll | pntMove.Command2 == DrillMoveCommand.ResetAll | pntMove.Command3 == DrillMoveCommand.ResetAll)
    {
      for (int index = 0; index < 300; ++index)
        clsDrill.ToolPistonDownPos[index] = 0.0;
    }
    if (pntMove.Command == DrillMoveCommand.ResetPiston | pntMove.Command2 == DrillMoveCommand.ResetPiston | pntMove.Command3 == DrillMoveCommand.ResetPiston)
    {
      this.ResetTools(pntMove.Tool1);
      this.ResetTools(pntMove.Tool2);
      this.ResetTools(pntMove.Tool3);
      this.ResetTools(pntMove.Tool4);
      this.ResetTools(pntMove.Tool5);
      this.ResetTools(pntMove.Tool6);
      this.ResetTools(pntMove.Tool7);
      this.ResetTools(pntMove.Tool8);
      this.ResetTools(pntMove.Tool9);
      this.ResetTools(pntMove.Tool10);
      this.ResetTools(pntMove.Tool11);
      this.ResetTools(pntMove.Tool12);
    }
    if (pntMove.Command == DrillMoveCommand.SetPiston | pntMove.Command2 == DrillMoveCommand.SetPiston | pntMove.Command3 == DrillMoveCommand.SetPiston)
    {
      this.SetTools(pntMove.Tool1);
      this.SetTools(pntMove.Tool2);
      this.SetTools(pntMove.Tool3);
      this.SetTools(pntMove.Tool4);
      this.SetTools(pntMove.Tool5);
      this.SetTools(pntMove.Tool6);
      this.SetTools(pntMove.Tool7);
      this.SetTools(pntMove.Tool8);
      this.SetTools(pntMove.Tool9);
      this.SetTools(pntMove.Tool10);
      this.SetTools(pntMove.Tool11);
      this.SetTools(pntMove.Tool12);
    }
    for (int index = 0; index <= clsDrill.SimMovePartIndex.Count - 1; ++index)
    {
      if (clsDrill.viewportAuto.Entities.Count > 0 & clsDrill.SimMovePartIndex[index] <= clsDrill.viewportAuto.Entities.Count - 1)
      {
        CustomData entityData = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]].EntityData as CustomData;
        Pnt6D pnt6D = new Pnt6D();
        Point3D point3D = new Point3D();
        int num1 = clsDrill.SimMovePartIndex[index];
        if (clsDrill.SimMovePartIndex[index] >= 0 & clsDrill.SimMovePartIndex[index] <= clsDrill.viewportAuto.Entities.Count - 1)
        {
          if (clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]].GetType() == typeof (buTool))
          {
            buTool entity1 = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]] as buTool;
            string blockName = ((BlockReference) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).BlockName;
            double num2 = 0.0;
            if (entity1.No >= 0 & entity1.No <= 299)
              num2 = clsDrill.ToolPistonDownPos[entity1.No];
            if (entity1.Tag != null && entity1.Tag == "Z1")
            {
              ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y1Position;
              if (entity1.No != 31 /*0x1F*/)
                ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z1Position + num2;
              else
                ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z1Position + num2;
              Entity entity2 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
              entity2.Translate(0.0, -pntMove.Y1Position, pntMove.Z1Position + num2);
              entity2.Regen(new RegenParams(0.01, (IWorkspace) clsDrill.viewportAuto));
              clsDrill.SimToCollsionCheck1.Add(entity2);
            }
          }
          if (clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]].GetType() == typeof (buMaterialMoveable))
            ((buMaterialMoveable) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).xPos = pntMove.XPosition;
          if (clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]].GetType() == typeof (buMachinePart))
          {
            buMachinePart entity3 = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]] as buMachinePart;
            if (entityData.typeDefination == entityTypeDefination.MachineBody | entityData.typeDefination == entityTypeDefination.MachineParts)
            {
              string blockName = ((BlockReference) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).BlockName;
              double num3 = 0.0;
              if (entity3.No >= 0 & entity3.No <= 299)
                num3 = clsDrill.ToolPistonDownPos[entity3.No];
              if (blockName == "X1_Body" | blockName == "X1_Clamper")
              {
                if (blockName == "X1_Clamper")
                  ;
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).xPos = pntMove.X1Clamper;
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = this.X1ClamperZOffset;
                Entity entity4 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
                entity4.Translate(pntMove.X1Clamper, 0.0, this.X1ClamperZOffset);
                entity4.Regen(new RegenParams(0.01, (IWorkspace) clsDrill.viewportAuto));
                if (blockName == "X1_Clamper")
                  clsDrill.SimToCollsionCheck2.Add(entity4);
              }
              if (blockName == "X2_Body" | blockName == "X2_Clamper")
              {
                if (blockName == "X2_Clamper")
                  ;
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).xPos = pntMove.X2Clamper;
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = this.X2ClamperZOffset;
                Entity entity5 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
                entity5.Translate(pntMove.X2Clamper, 0.0, this.X2ClamperZOffset);
                entity5.Regen(new RegenParams(0.01, (IWorkspace) clsDrill.viewportAuto));
                if (blockName == "X2_Clamper")
                  clsDrill.SimToCollsionCheck2.Add(entity5);
              }
              if (blockName == "Y1_Body")
              {
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y1Position;
                buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).Translate(0.0, -pntMove.Y1Position);
              }
              if (entity3.Tag != null && entity3.Tag == "Z1")
              {
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y1Position;
                if (blockName != "Z_Milling")
                  ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z1Position + num3;
                else
                  ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z1Position + num3;
                Entity entity6 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
                entity6.Translate(0.0, -pntMove.Y1Position, pntMove.Z1Position + num3);
                clsDrill.SimToCollsionCheck1.Add(entity6);
              }
            }
          }
        }
      }
    }
    clsDrill.viewportAuto.Entities.Regen();
    if (!clsDrill.viewportAuto.IsAnimationRunning)
      ;
  }

  public void DrawTool(int ToolNo)
  {
    for (int index = clsDrill.viewportAuto.Blocks.Count - 1; index >= 0; --index)
    {
      if (clsDrill.viewportAuto.Blocks[index].Name.IndexOf("ToolMilling") >= 0)
      {
        clsDrill.viewportAuto.Blocks.RemoveAt(index);
        if (clsDrill.SimMovePartIndex.Count > 0)
          clsDrill.SimMovePartIndex.RemoveAt(clsDrill.SimMovePartIndex.Count - 1);
      }
    }
    List<Mesh> refMeshes = new List<Mesh>();
    Block block = (Block) null;
    buTool buTool = (buTool) null;
    for (int index1 = 0; index1 <= ccVars.Tools.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.Tools[index1].Tools.Count - 1; ++index2)
      {
        if (ccVars.Tools[index1].Tools[index2].Data.No == ToolNo)
        {
          clsInit.appMW.CreateToolWithToolDirection(new ToolBase5(ccVars.Tools[index1].Tools[index2])
          {
            Geometry = {
              Length = 41.2
            }
          }, true, true, false, false, true, ref refMeshes);
          block = new Block("ToolMilling" + ccVars.Tools[index1].Tools[index2].Data.No.ToString());
          buTool = new buTool(block.Name);
        }
      }
    }
    for (int index3 = 0; index3 <= clsDrill.ToolList.Count - 1; ++index3)
    {
      clsDrill.ToolList[index3].Geometry.LowerRadius = 0.0;
      clsDrill.ToolList[index3].Geometry.UpperRadius = 0.0;
      clsDrill.ToolList[index3].Geometry.CornerRadiusType = ToolCornerRadiusType.None;
      for (int index4 = 0; index4 <= refMeshes.Count - 1; ++index4)
      {
        refMeshes[index4].Color = Color.FromArgb((int) byte.MaxValue, refMeshes[index4].Color);
        if (clsDrill.ToolList[index3].Data.No == 31 /*0x1F*/)
        {
          double x = clsDrill.ToolList[index3].Positions.CommonOffset.X;
          double y = clsDrill.ToolList[index3].Positions.CommonOffset.Y;
          double dz = clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
          refMeshes[index4].Translate(x, y, dz);
          buTool.Tag = "Z1";
          refMeshes[index4].EntityData = (object) clsDrill.ToolList[index3].Data.No;
          block.Entities.Add((Entity) refMeshes[index4]);
          buTool.No = clsDrill.ToolList[index3].Data.No;
          buTool.EntityData = (object) new CustomData()
          {
            typeDefination = entityTypeDefination.Tool,
            OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count
          };
        }
      }
    }
    if ((block == null ? 0 : (block.Entities.Count > 0 ? 1 : 0)) == 0)
      return;
    clsDrill.viewportAuto.Blocks.Add(block);
    clsDrill.viewportAuto.Entities.Add((Entity) buTool);
    clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
  }

  public void DrawEntities(bool ZoomFit)
  {
    clsDrill.viewportAuto.Entities.Clear();
    clsDrill.SimMovePartIndex.Clear();
    for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
      {
        buMachinePart buMachinePart = new buMachinePart(ccVars.SimMachine.MachineParts[index1].PartName);
        buMachinePart.ARotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.A;
        buMachinePart.BRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.B;
        buMachinePart.CRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.C;
        buMachinePart.XMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.X;
        buMachinePart.YMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Y;
        buMachinePart.ZMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Z;
        buMachinePart.xRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.X;
        buMachinePart.yRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.Y;
        buMachinePart.zRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.Z;
        buMachinePart.Color = ccVars.SimMachine.MachineParts[index1].Color;
        buMachinePart.ColorMethod = colorMethodType.byEntity;
        double num = 0.0;
        if (ccVars.SimMachine.MachineParts[index1].Tag != null && ccVars.SimMachine.MachineParts[index1].Tag == "Z1")
          num = clsDrill.varDrillCNCSettings.Y1GroupZOffset;
        double dx = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.X;
        double dy = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Y;
        double dz = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Z + num;
        buMachinePart.Translate(dx, dy, dz);
        buMachinePart.Tag = ccVars.SimMachine.MachineParts[index1].Tag;
        buMachinePart.No = ccVars.SimMachine.MachineParts[index1].No;
        buMachinePart.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.MachineBody,
          OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count
        };
        clsDrill.viewportAuto.Entities.Add((Entity) buMachinePart);
        clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
      }
    }
    for (int index = clsDrill.viewportAuto.Blocks.Count - 1; index >= 0; --index)
    {
      bool flag = false;
      if (clsDrill.viewportAuto.Blocks[index].Name.IndexOf("Tool") >= 0)
      {
        clsDrill.viewportAuto.Blocks.RemoveAt(index);
        flag = true;
      }
      if (!flag && clsDrill.viewportAuto.Blocks[index].Name.IndexOf("SolidMat") >= 0)
      {
        clsDrill.viewportAuto.Blocks.RemoveAt(index);
        flag = true;
      }
      if (!flag && clsDrill.viewportAuto.Blocks[index].Name.IndexOf("MaterialWood") >= 0)
        clsDrill.viewportAuto.Blocks.RemoveAt(index);
    }
    for (int index3 = 0; index3 <= clsDrill.ToolList.Count - 1; ++index3)
    {
      List<Mesh> refMeshes = new List<Mesh>();
      clsDrill.ToolList[index3].Geometry.LowerRadius = 0.0;
      clsDrill.ToolList[index3].Geometry.UpperRadius = 0.0;
      clsDrill.ToolList[index3].Geometry.CornerRadiusType = ToolCornerRadiusType.None;
      clsInit.appMW.CreateToolWithToolDirection(clsDrill.ToolList[index3], true, true, false, false, true, ref refMeshes);
      Block block = new Block("Tool" + clsDrill.ToolList[index3].Data.No.ToString());
      buTool buTool = new buTool(block.Name);
      for (int index4 = 0; index4 <= refMeshes.Count - 1; ++index4)
      {
        refMeshes[index4].Color = Color.FromArgb((int) byte.MaxValue, refMeshes[index4].Color);
        if (clsDrill.ToolList[index3].Data.No >= 61 & clsDrill.ToolList[index3].Data.No <= 79)
        {
          if (Math.Abs(clsDrill.ToolList[index3].Geometry.ToolDirection.Z) != 0.0)
          {
            double x = clsDrill.ToolList[index3].Positions.CommonOffset.X;
            double y = clsDrill.ToolList[index3].Positions.CommonOffset.Y;
            double dz = clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
            refMeshes[index4].Translate(x, y, dz);
          }
          else
          {
            double x = clsDrill.ToolList[index3].Positions.CommonOffset.X;
            double y = clsDrill.ToolList[index3].Positions.CommonOffset.Y;
            double dz = clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
            refMeshes[index4].Translate(x, y, dz);
          }
          buTool.Tag = "Z1";
        }
        if (clsDrill.ToolList[index3].Data.No == 95)
        {
          double x = clsDrill.ToolList[index3].Positions.CommonOffset.X;
          double y = clsDrill.ToolList[index3].Positions.CommonOffset.Y;
          double dz = clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
          refMeshes[index4].Translate(x, y + clsDrill.ToolList[index3].Geometry.Thickness / 2.0, dz);
          buTool.Tag = "Z1";
        }
        refMeshes[index4].EntityData = (object) clsDrill.ToolList[index3].Data.No;
        block.Entities.Add((Entity) refMeshes[index4]);
      }
      if (block.Entities.Count > 0)
        clsDrill.viewportAuto.Blocks.Add(block);
      buTool.No = clsDrill.ToolList[index3].Data.No;
      buTool.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.Tool,
        OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count
      };
      clsDrill.viewportAuto.Entities.Add((Entity) buTool);
      clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
    }
    if (clsDrill.activeJob == null)
      return;
    if (clsDrill.activeJob.Material.Entities != null)
    {
      Entity copiedEnt = (Entity) null;
      clsDrill.activeJob.panelEntity.Color = Color.FromArgb(150, clsDrill.varDrillSettings.colorPanel);
      buVector5.CopyEntities(clsDrill.activeJob.Material.Entities[0], ref copiedEnt);
      copiedEnt.Color = Color.FromArgb(150, clsDrill.varDrillSettings.colorPanel);
      copiedEnt.Regen(0.005);
      buMaterialMoveable materialMoveable = new buMaterialMoveable("MaterialWood");
      materialMoveable.XMove = true;
      Block block = new Block("MaterialWood");
      block.Entities.Add(copiedEnt);
      for (int index = 0; index <= clsDrill.viewportAuto.Blocks.Count - 1; ++index)
      {
        if (clsDrill.viewportAuto.Blocks[index].Name == "MaterialWood")
          ;
      }
      clsDrill.viewportAuto.Blocks.Add(block);
      materialMoveable.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.Material,
        OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count
      };
      clsDrill.viewportAuto.Entities.Add((Entity) materialMoveable);
      clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
    }
    for (int index5 = 0; index5 <= clsDrill.activeJob.Items.Count - 1; ++index5)
    {
      for (int index6 = 0; index6 <= clsDrill.activeJob.Items[index5].entitySolid.Count - 1; ++index6)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(clsDrill.activeJob.Items[index5].entitySolid[index6], ref copiedEntity);
        copiedEntity.Color = clsDrill.activeJob.Items[index5].Enable ? Color.Lime : Color.Gray;
        buMaterialMoveable materialMoveable = new buMaterialMoveable($"SolidMat{index5.ToString("D3")}{index6.ToString("D3")}");
        materialMoveable.XMove = true;
        Block block = new Block($"SolidMat{index5.ToString("D3")}{index6.ToString("D3")}");
        block.Entities.Add(copiedEntity);
        for (int index7 = 0; index7 <= clsDrill.viewportAuto.Blocks.Count - 1; ++index7)
        {
          if (clsDrill.viewportAuto.Blocks[index7].Name == $"SolidMat{index5.ToString("D3")}{index6.ToString("D3")}")
            ;
        }
        clsDrill.viewportAuto.Blocks.Add(block);
        materialMoveable.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.Material,
          OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count
        };
        clsDrill.viewportAuto.Entities.Add((Entity) materialMoveable);
        clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
      }
    }
  }

  public void SetTools(int ToolNo)
  {
    if (ToolNo >= 61 & ToolNo <= 70)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonVerticalDistance;
    if (ToolNo >= 31 /*0x1F*/ & ToolNo <= 39)
    {
      this.DrawTool(ToolNo);
      clsDrill.ToolPistonDownPos[31 /*0x1F*/] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
      clsDrill.ToolPistonDownPos[32 /*0x20*/] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
      clsDrill.ToolPistonDownPos[33] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
      clsDrill.ToolPistonDownPos[34] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
      clsDrill.ToolPistonDownPos[35] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
      clsDrill.ToolPistonDownPos[36] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
      clsDrill.ToolPistonDownPos[37] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
      clsDrill.ToolPistonDownPos[38] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
      clsDrill.ToolPistonDownPos[39] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
    }
    if (ToolNo == 95)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonSawDistance;
    if (ToolNo == 72 | ToolNo == 74 | ToolNo == 76)
    {
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
      clsDrill.ToolPistonDownPos[ToolNo - 1] = -clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
    }
    if (!(ToolNo == 71 | ToolNo == 73 | ToolNo == 75))
      return;
    clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
    clsDrill.ToolPistonDownPos[ToolNo + 1] = -clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
  }

  public void ResetTools(int ToolNo)
  {
    if (!(ToolNo >= 0 & ToolNo <= 299))
      return;
    clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
    if (ToolNo == 72 | ToolNo == 74 | ToolNo == 76)
    {
      clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
      clsDrill.ToolPistonDownPos[ToolNo - 1] = 0.0;
    }
    if (!(ToolNo == 71 | ToolNo == 73 | ToolNo == 75))
      return;
    clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
    clsDrill.ToolPistonDownPos[ToolNo + 1] = 0.0;
  }

  public void FindHolesForFrontSide()
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstFront.Count - 1; ++index1)
    {
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstFront[index1];
      List<DrillCalcItem> drillCalcItemList2 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
          drillCalcItemList2.Add(new DrillCalcItem(drillCalcItemList1[index2]));
      }
      if (drillCalcItemList2.Count > 0)
        drillCalcItemList2 = this.SortByYDistance(drillCalcItemList2, new DrillCalcItem(), SortDirection.LowerToBigger);
      int count = drillCalcItemList2.Count;
      if (drillCalcItemList2.Count >= 2 && clsInit.cDrill.isMultiZAvailable(drillCalcItemList2))
      {
        List<List<DrillCalcItem>> SplitedItems = new List<List<DrillCalcItem>>();
        clsInit.cDrill.SplitDrillsByYDistanceThenSortZDir(drillCalcItemList2, SortDirection.LowerToBigger, ref SplitedItems);
        if (SplitedItems.Count > 0)
        {
          drillCalcItemList2 = new List<DrillCalcItem>();
          for (int index3 = 0; index3 <= SplitedItems.Count - 1; ++index3)
          {
            for (int index4 = 0; index4 <= SplitedItems[index3].Count - 1; ++index4)
              drillCalcItemList2.Add(new DrillCalcItem(SplitedItems[index3][index4]));
          }
        }
      }
      for (int index5 = 0; index5 <= count - 1; ++index5)
      {
        DrillFound Found = new DrillFound();
        for (int index6 = 0; index6 <= clsDrill.ToolList.Count - 1; ++index6)
          clsDrill.ToolList[index6].Data.Used = false;
        List<int> Y1GroupTool = new List<int>();
        List<int> Y2GroupTool = new List<int>();
        int T1 = 0;
        int T2 = 0;
        int T3 = 0;
        int T4 = 0;
        int T5 = 0;
        int T6 = 0;
        int T7 = 0;
        int T8 = 0;
        int T9 = 0;
        int T10 = 0;
        int T11 = 0;
        int T12 = 0;
        int Count = 0;
        FindToolSettings Settings = new FindToolSettings();
        Settings.Plane = planeBoxNames.Front;
        Settings.SetAsUsed = true;
        ToolBase5 foundTool = (ToolBase5) null;
        if (index5 <= drillCalcItemList2.Count - 1 & drillCalcItemList2.Count > 0 && !drillCalcItemList2[index5].Calculated)
        {
          Count = 0;
          clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList2, drillCalcItemList2[index5], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index5, ref Count);
          if (!clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
            this.FindToolFromBlock(drillCalcItemList2[index5], 0, Settings, ref foundTool);
          else
            this.FindToolFromBlock(drillCalcItemList2[index5], 0, Settings, SortDirection.BiggerToLower, ref foundTool);
          if (foundTool != null)
          {
            if (this.SetValueToAvailableTool(foundTool.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList2[index5].Calculated = true;
              drillCalcItemList2[index5].OffsetedPoint.Y = drillCalcItemList2[index5].Center.Y + foundTool.Positions.CommonOffset.Y;
              drillCalcItemList2[index5].HeadNo = 1;
              DrillFound.Add(drillCalcItemList2[index5], foundTool.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList2[index5].ID);
            }
            else
              this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {foundTool.Data.No.ToString()} - Position : {drillCalcItemList2[index5].Center.ToString()}");
          }
          if (foundTool != null)
          {
            for (int index7 = index5 + 1; index7 <= drillCalcItemList2.Count - 1; ++index7)
            {
              double num1 = drillCalcItemList2[index7].Center.Y - drillCalcItemList2[index5].Center.Y;
              if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
                num1 = drillCalcItemList2[index5].Center.Y - drillCalcItemList2[index7].Center.Y;
              double num2 = Math.Round(num1, 5) % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
              if (num1 > 0.0 & !drillCalcItemList2[index7].Calculated & buCompare5.EQ(num2, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList2[index5], drillCalcItemList2[index7]))
              {
                for (int index8 = 0; index8 <= clsDrill.ToolList.Count - 1; ++index8)
                {
                  if (foundTool.Data.GroupIndex == clsDrill.ToolList[index8].Data.GroupIndex & !clsDrill.ToolList[index8].Data.Used & clsDrill.ToolList[index8].Geometry.Diameter == drillCalcItemList2[index7].Diameter & clsDrill.ToolList[index8].Geometry.ToolDirection.X == -1.0)
                  {
                    double num3 = foundTool.Positions.CommonOffset.Y - clsDrill.ToolList[index8].Positions.CommonOffset.Y;
                    if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
                      ;
                    if (buCompare5.EQ(num3, num1, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index8].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
                      if (availableTool > 0)
                      {
                        drillCalcItemList2[index7].Calculated = true;
                        drillCalcItemList2[index7].OffsetedPoint.Y = drillCalcItemList2[index7].Center.Y + clsDrill.ToolList[index8].Positions.CommonOffset.Y;
                        drillCalcItemList2[index7].HeadNo = 1;
                        clsDrill.ToolList[index8].Data.Used = true;
                        DrillFound.Add(drillCalcItemList2[index7], clsDrill.ToolList[index8].Data.No, ref Found);
                        this.SetAsCalculatedDrillItemByID(drillCalcItemList2[index7].ID);
                      }
                      if (availableTool < 1)
                        this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index8].Data.No.ToString()} - Position : {drillCalcItemList2[index7].Center.ToString()}");
                      index8 = clsDrill.ToolList.Count;
                    }
                  }
                }
              }
            }
          }
        }
        if (Found.Items.Count > 0)
          this.FoundDrills.Add(Found);
      }
    }
  }

  public void FindHolesForBackSide()
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstBack.Count - 1; ++index1)
    {
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstBack[index1];
      List<DrillCalcItem> drillCalcItemList2 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
          drillCalcItemList2.Add(new DrillCalcItem(drillCalcItemList1[index2]));
      }
      if (drillCalcItemList2.Count > 0)
        drillCalcItemList2 = this.SortByYDistance(drillCalcItemList2, new DrillCalcItem(), SortDirection.LowerToBigger);
      int count = drillCalcItemList2.Count;
      if (drillCalcItemList2.Count >= 2 && clsInit.cDrill.isMultiZAvailable(drillCalcItemList2))
      {
        List<List<DrillCalcItem>> SplitedItems = new List<List<DrillCalcItem>>();
        clsInit.cDrill.SplitDrillsByYDistanceThenSortZDir(drillCalcItemList2, SortDirection.LowerToBigger, ref SplitedItems);
        if (SplitedItems.Count > 0)
        {
          drillCalcItemList2 = new List<DrillCalcItem>();
          for (int index3 = 0; index3 <= SplitedItems.Count - 1; ++index3)
          {
            for (int index4 = 0; index4 <= SplitedItems[index3].Count - 1; ++index4)
              drillCalcItemList2.Add(new DrillCalcItem(SplitedItems[index3][index4]));
          }
        }
      }
      for (int index5 = 0; index5 <= count - 1; ++index5)
      {
        DrillFound Found = new DrillFound();
        for (int index6 = 0; index6 <= clsDrill.ToolList.Count - 1; ++index6)
          clsDrill.ToolList[index6].Data.Used = false;
        List<int> Y1GroupTool = new List<int>();
        int T1 = 0;
        int T2 = 0;
        int T3 = 0;
        int T4 = 0;
        int T5 = 0;
        int T6 = 0;
        int T7 = 0;
        int T8 = 0;
        int T9 = 0;
        int T10 = 0;
        int T11 = 0;
        int T12 = 0;
        int Count = 0;
        FindToolSettings Settings = new FindToolSettings();
        Settings.Plane = planeBoxNames.Back;
        Settings.SetAsUsed = true;
        ToolBase5 foundTool = (ToolBase5) null;
        if (index5 <= drillCalcItemList2.Count - 1 & drillCalcItemList2.Count > 0 && !drillCalcItemList2[index5].Calculated)
        {
          Count = 0;
          clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList2, drillCalcItemList2[index5], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index5, ref Count);
          this.FindToolFromBlock(drillCalcItemList2[index5], 0, Settings, ref foundTool);
          if (foundTool != null)
          {
            if (this.SetValueToAvailableTool(foundTool.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList2[index5].Calculated = true;
              drillCalcItemList2[index5].OffsetedPoint.Y = drillCalcItemList2[index5].Center.Y + foundTool.Positions.CommonOffset.Y;
              drillCalcItemList2[index5].HeadNo = 1;
              DrillFound.Add(drillCalcItemList2[index5], foundTool.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList2[index5].ID);
            }
            else
              this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {foundTool.Data.No.ToString()} - Position : {drillCalcItemList2[index5].Center.ToString()}");
          }
          if (foundTool != null)
          {
            for (int index7 = index5 + 1; index7 <= drillCalcItemList2.Count - 1; ++index7)
            {
              double num1 = drillCalcItemList2[index7].Center.Y - drillCalcItemList2[index5].Center.Y;
              double num2 = Math.Round(num1, 5) % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
              if (num1 > 0.0 & !drillCalcItemList2[index7].Calculated & buCompare5.EQ(num2, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList2[index5], drillCalcItemList2[index7]))
              {
                for (int index8 = 0; index8 <= clsDrill.ToolList.Count - 1; ++index8)
                {
                  if (foundTool.Data.GroupIndex == clsDrill.ToolList[index8].Data.GroupIndex & !clsDrill.ToolList[index8].Data.Used & clsDrill.ToolList[index8].Geometry.Diameter == drillCalcItemList2[index7].Diameter & clsDrill.ToolList[index8].Geometry.ToolDirection.X == 1.0 && buCompare5.EQ(foundTool.Positions.CommonOffset.Y - clsDrill.ToolList[index8].Positions.CommonOffset.Y, num1, 0.05))
                  {
                    int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index8].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool);
                    if (availableTool > 0)
                    {
                      drillCalcItemList2[index7].Calculated = true;
                      drillCalcItemList2[index7].OffsetedPoint.Y = drillCalcItemList2[index7].Center.Y - clsDrill.ToolList[index8].Positions.CommonOffset.Y;
                      drillCalcItemList2[index7].HeadNo = 1;
                      clsDrill.ToolList[index8].Data.Used = true;
                      DrillFound.Add(drillCalcItemList2[index7], clsDrill.ToolList[index8].Data.No, ref Found);
                      this.SetAsCalculatedDrillItemByID(drillCalcItemList2[index7].ID);
                    }
                    if (availableTool < 1)
                      this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index8].Data.No.ToString()} - Position : {drillCalcItemList2[index7].Center.ToString()}");
                    index8 = clsDrill.ToolList.Count;
                  }
                }
              }
            }
          }
        }
        if (Found.Items.Count > 0)
          this.FoundDrills.Add(Found);
      }
    }
  }

  public void FindHolesForTopSide()
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstTop.Count - 1; ++index1)
    {
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstTop[index1];
      List<DrillCalcItem> drillCalcItemList2 = (List<DrillCalcItem>) null;
      if (index1 < this.SplitedItems.lstTop.Count - 1)
        drillCalcItemList2 = this.SplitedItems.lstTop[index1 + 1];
      List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList4 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
          drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
      }
      if (drillCalcItemList2 != null)
      {
        for (int index3 = 0; index3 <= drillCalcItemList2.Count - 1; ++index3)
        {
          if (!drillCalcItemList2[index3].Calculated)
            drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList2[index3]));
        }
      }
      if (drillCalcItemList3.Count > 0)
        drillCalcItemList3 = this.SortByYDistance(drillCalcItemList3, new DrillCalcItem(), SortDirection.BiggerToLower);
      bool flag1 = false;
      int count = drillCalcItemList3.Count;
      for (int index4 = 0; index4 <= count - 1; ++index4)
      {
        DrillFound Found = new DrillFound();
        for (int index5 = 0; index5 <= clsDrill.ToolList.Count - 1; ++index5)
          clsDrill.ToolList[index5].Data.Used = false;
        List<int> Y1GroupTool = new List<int>();
        int T1 = 0;
        int T2 = 0;
        int T3 = 0;
        int T4 = 0;
        int T5 = 0;
        int T6 = 0;
        int T7 = 0;
        int T8 = 0;
        int T9 = 0;
        int T10 = 0;
        int T11 = 0;
        int T12 = 0;
        int Count1 = 0;
        int Count2 = 0;
        FindToolSettings Settings = new FindToolSettings();
        Settings.Plane = planeBoxNames.Top;
        Settings.SetAsUsed = true;
        ToolBase5 foundTool = (ToolBase5) null;
        if (index4 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0)
        {
          bool flag2 = true;
          if (!drillCalcItemList3[index4].Calculated)
          {
            if (drillCalcItemList3[index4].NumberNextVerticalItem > 0)
              Settings.SelectVerticalTools = true;
            double MaxYDistance = 0.0;
            clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList3, drillCalcItemList3[index4], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index4, ref Count1, ref MaxYDistance);
            clsInit.cDrill.isVerticalDrillAvailable(drillCalcItemList3[index4], this.SplitedItems.lstTop, clsDrill.varDrillCNCSettings.ToolRepeatDistance, index1, ref Count2);
            bool flag3 = false;
            if (Count1 == 0 && Count2 == 0 & index1 > 0 & this.FoundDrills.Count > 0 && this.FoundDrills[this.FoundDrills.Count - 1].Items[0].Diameter == drillCalcItemList3[index4].Diameter & this.FoundDrills[this.FoundDrills.Count - 1].Items[0].planeName == drillCalcItemList3[index4].planeName && this.FoundDrills[this.FoundDrills.Count - 1].Items[0].Center.Y == drillCalcItemList3[index4].Center.Y & this.FoundDrills[this.FoundDrills.Count - 1].Items[0].Tool == 70)
              flag3 = true;
            if (Count1 > 0)
            {
              Convert.ToInt32(MaxYDistance / clsDrill.varDrillCNCSettings.ToolRepeatDistance);
              Settings.StartToolIndex = !clsDrill.varDrillCNCSettings.MirrorCalculationForTop ? 65 : 61;
              if (clsDrill.varDrillCNCSettings.MirrorCalculationForTop)
                this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.LowerToBigger, ref foundTool);
              else
                this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.BiggerToLower, ref foundTool);
            }
            else if (Count2 > 0)
            {
              Settings.StartToolIndex = 70;
              this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.BiggerToLower, ref foundTool);
            }
            else if (Count2 == 0 & flag3)
            {
              Settings.StartToolIndex = 70;
              this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.BiggerToLower, ref foundTool);
            }
            else
            {
              Settings.StartToolIndex = 65;
              this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.LowerToBigger, ref foundTool);
              if (foundTool == null)
                this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.BiggerToLower, ref foundTool);
            }
            if (foundTool == null)
            {
              Settings.StartToolIndex = 60;
              this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, ref foundTool);
            }
            if (foundTool != null)
            {
              if (this.SetValueToAvailableTool(foundTool.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
              {
                drillCalcItemList3[index4].Calculated = true;
                drillCalcItemList3[index4].HeadNo = 1;
                drillCalcItemList3[index4].OffsetedPoint.Y = drillCalcItemList3[index4].Center.Y + foundTool.Positions.CommonOffset.Y;
                DrillFound.Add(drillCalcItemList3[index4], foundTool.Data.No, ref Found);
                this.SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
                this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index4].ID);
              }
              else
                this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {foundTool.Data.No.ToString()} - Position : {drillCalcItemList3[index4].Center.ToString()}");
            }
            if (foundTool != null)
            {
              for (int index6 = index4 + 1; index6 <= drillCalcItemList3.Count - 1; ++index6)
              {
                double num = drillCalcItemList3[index6].Center.Y - drillCalcItemList3[index4].Center.Y;
                if (!flag1)
                  num = drillCalcItemList3[index4].Center.Y - drillCalcItemList3[index6].Center.Y;
                if (buCompare5.EQ(Math.Round(num, 5) % clsDrill.varDrillCNCSettings.ToolRepeatDistance, 0.0, 0.05) & !drillCalcItemList3[index6].Calculated & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList3[index4], drillCalcItemList3[index6]))
                {
                  for (int index7 = 0; index7 <= clsDrill.ToolList.Count - 1; ++index7)
                  {
                    if (foundTool.Data.GroupIndex == clsDrill.ToolList[index7].Data.GroupIndex & !clsDrill.ToolList[index7].Data.Used & clsDrill.ToolList[index7].Geometry.Diameter == drillCalcItemList3[index6].Diameter & clsDrill.ToolList[index7].Geometry.ToolDirection.Z == -1.0 && buCompare5.EQ(clsDrill.ToolList[index7].Positions.CommonOffset.Y - foundTool.Positions.CommonOffset.Y, num, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index7].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool);
                      if (availableTool > 0)
                      {
                        drillCalcItemList3[index6].Calculated = true;
                        drillCalcItemList3[index6].HeadNo = 1;
                        drillCalcItemList3[index6].OffsetedPoint.Y = drillCalcItemList3[index6].Center.Y + clsDrill.ToolList[index7].Positions.CommonOffset.Y;
                        clsDrill.ToolList[index7].Data.Used = true;
                        DrillFound.Add(drillCalcItemList3[index6], clsDrill.ToolList[index7].Data.No, ref Found);
                        this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index6].ID);
                      }
                      if (availableTool < 1)
                        this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index7].Data.No.ToString()} - Position : {drillCalcItemList3[index6].Center.ToString()}");
                      index7 = clsDrill.ToolList.Count;
                    }
                  }
                }
              }
            }
            if (Count1 > 0 & !clsDrill.varDrillCNCSettings.SearchVerToolEvenMultiHorDrillAvailableForTop)
              flag2 = false;
            if (foundTool != null & Count2 > 0 & flag2 && drillCalcItemList3.Count > 0)
            {
              List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
              int MaxToolCount = -1;
              if (drillCalcItemList3[index4].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItemList3[index4].Diameter / 2.0)
              {
                int lower = (int) buNumeric5.RoundToLower((clsDrill.activeJob.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 1.5) / clsDrill.varDrillCNCSettings.ToolRepeatDistance);
                if (lower <= 0)
                  MaxToolCount = 1;
                else if (lower <= 4)
                  MaxToolCount = lower;
              }
              clsInit.cDrill.FindNextVerticalDrill(this.SplitedItems.lstTop, drillCalcItemList3[index4], index1 + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems, MaxToolCount);
              for (int index8 = 0; index8 <= foundItems.Count - 1; ++index8)
              {
                double num1 = foundItems[index8].Center.X - drillCalcItemList3[index4].Center.X;
                for (int index9 = 0; index9 <= clsDrill.ToolList.Count - 1; ++index9)
                {
                  if (!foundItems[index8].Calculated & foundTool.Data.GroupIndex == clsDrill.ToolList[index9].Data.GroupIndex & !clsDrill.ToolList[index9].Data.Used & clsDrill.ToolList[index9].Geometry.Diameter == foundItems[index8].Diameter & clsDrill.ToolList[index9].Geometry.ToolDirection.Z == -1.0)
                  {
                    double num2 = foundTool.Positions.CommonOffset.X - clsDrill.ToolList[index9].Positions.CommonOffset.X;
                    double num3 = foundTool.Positions.CommonOffset.Y - clsDrill.ToolList[index9].Positions.CommonOffset.Y;
                    if (buCompare5.EQ(num1, num2, 0.05) & buCompare5.EQ(num3, 0.0, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index9].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool);
                      if (availableTool > 0)
                      {
                        foundItems[index8].HeadNo = 1;
                        foundItems[index8].OffsetedPoint.Y = foundItems[index8].Center.Y + clsDrill.ToolList[index9].Positions.CommonOffset.Y;
                        DrillFound.Add(foundItems[index8], clsDrill.ToolList[index9].Data.No, ref Found);
                        this.SetAsCalculatedDrillItemByID(foundItems[index8].ID);
                        clsDrill.ToolList[index9].Data.Used = true;
                      }
                      if (availableTool < 1)
                        this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index9].Data.No.ToString()} - Position : {foundItems[index8].Center.ToString()}");
                      index9 = clsDrill.ToolList.Count;
                    }
                  }
                }
              }
            }
          }
        }
        if (Found.Items.Count > 0)
          this.FoundDrills.Add(Found);
      }
    }
  }

  public void FindHolesForBottomSide()
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstBottom.Count - 1; ++index1)
    {
      bool flag1 = true;
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstBottom[index1];
      List<DrillCalcItem> drillCalcItemList2 = (List<DrillCalcItem>) null;
      if (index1 < this.SplitedItems.lstBottom.Count - 1)
        drillCalcItemList2 = this.SplitedItems.lstBottom[index1 + 1];
      List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
      List<DrillCalcItem> lst1 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
          drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
      }
      if (drillCalcItemList2 != null)
      {
        for (int index3 = 0; index3 <= drillCalcItemList2.Count - 1; ++index3)
        {
          if (!drillCalcItemList2[index3].Calculated)
            lst1.Add(new DrillCalcItem(drillCalcItemList2[index3]));
        }
      }
      if (drillCalcItemList3.Count > 0)
      {
        List<DrillCalcItem> lst2 = this.SortByYDistance(drillCalcItemList3, new DrillCalcItem(), SortDirection.LowerToBigger);
        if (lst1.Count > 0)
          this.SortByYDistance(lst1, new DrillCalcItem(), SortDirection.LowerToBigger);
        drillCalcItemList3 = !flag1 ? this.SortByYDistance(lst2, new DrillCalcItem(), SortDirection.BiggerToLower) : this.SortByYDistance(lst2, new DrillCalcItem(), SortDirection.LowerToBigger);
      }
      double count = (double) drillCalcItemList3.Count;
      for (int index4 = 0; (double) index4 <= count - 1.0; ++index4)
      {
        DrillFound Found = new DrillFound();
        for (int index5 = 0; index5 <= clsDrill.ToolList.Count - 1; ++index5)
          clsDrill.ToolList[index5].Data.Used = false;
        List<int> Y1GroupTool = new List<int>();
        List<int> Y2GroupTool = new List<int>();
        int T1 = 0;
        int T2 = 0;
        int T3 = 0;
        int T4 = 0;
        int T5 = 0;
        int T6 = 0;
        int T7 = 0;
        int T8 = 0;
        int T9 = 0;
        int T10 = 0;
        int T11 = 0;
        int T12 = 0;
        int Count1 = 0;
        int Count2 = 0;
        FindToolSettings Settings = new FindToolSettings();
        Settings.Plane = planeBoxNames.Bottom;
        Settings.SetAsUsed = true;
        ToolBase5 foundTool = (ToolBase5) null;
        if (index4 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0)
        {
          bool flag2 = true;
          if (!drillCalcItemList3[index4].Calculated)
          {
            if (drillCalcItemList3[index4].NumberNextVerticalItem > 0)
              Settings.SelectVerticalTools = true;
            double MaxYDistance = 0.0;
            clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList3, drillCalcItemList3[index4], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index4, ref Count1, ref MaxYDistance);
            clsInit.cDrill.isVerticalDrillAvailable(drillCalcItemList3[index4], this.SplitedItems.lstBottom, clsDrill.varDrillCNCSettings.ToolRepeatDistance, index1, ref Count2);
            if (Count2 > 0)
              clsInit.cDrill.FindVerticalSameDiameterTools(clsDrill.ToolList, drillCalcItemList3[index4].Diameter, planeBoxNames.Bottom, ref Settings.StartToolIndex);
            this.FindToolFromBlock(drillCalcItemList3[index4], 2, Settings, ref foundTool);
            if (foundTool == null)
            {
              Settings.StartToolIndex = 0;
              this.FindToolFromBlock(drillCalcItemList3[index4], 2, Settings, ref foundTool);
            }
            if (foundTool != null)
            {
              if (this.SetValueToAvailableTool(foundTool.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
              {
                drillCalcItemList3[index4].Calculated = true;
                drillCalcItemList3[index4].HeadNo = 3;
                drillCalcItemList3[index4].OffsetedPoint.Y = drillCalcItemList3[index4].Center.Y - foundTool.Positions.Offset.Y;
                DrillFound.Add(drillCalcItemList3[index4], foundTool.Data.No, ref Found);
                this.SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
                this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index4].ID);
              }
              else
                this.calcErrorList.Add($"Bottom Surface Y1 Group Tool Set Limit Full - Tool No : {foundTool.Data.No.ToString()} - Position : {drillCalcItemList3[index4].Center.ToString()}");
            }
            if (foundTool != null)
            {
              for (int index6 = index4 + 1; index6 <= drillCalcItemList3.Count - 1; ++index6)
              {
                double num = drillCalcItemList3[index6].Center.Y - drillCalcItemList3[index4].Center.Y;
                if (!flag1)
                  num = drillCalcItemList3[index4].Center.Y - drillCalcItemList3[index6].Center.Y;
                if (buCompare5.EQ(Math.Round(num, 5) % clsDrill.varDrillCNCSettings.ToolRepeatDistance, 0.0, 0.05) & !drillCalcItemList3[index6].Calculated & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList3[index4], drillCalcItemList3[index6]))
                {
                  for (int index7 = 0; index7 <= clsDrill.ToolList.Count - 1; ++index7)
                  {
                    if (foundTool.Data.GroupIndex == clsDrill.ToolList[index7].Data.GroupIndex & !clsDrill.ToolList[index7].Data.Used & clsDrill.ToolList[index7].Geometry.Diameter == drillCalcItemList3[index6].Diameter & clsDrill.ToolList[index7].Geometry.ToolDirection.Z == 1.0 && buCompare5.EQ(clsDrill.ToolList[index7].Positions.Offset.Y - foundTool.Positions.Offset.Y, num, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index7].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
                      if (availableTool > 0)
                      {
                        drillCalcItemList3[index6].Calculated = true;
                        drillCalcItemList3[index6].HeadNo = 3;
                        drillCalcItemList3[index6].OffsetedPoint.Y = drillCalcItemList3[index6].Center.Y - clsDrill.ToolList[index7].Positions.Offset.Y;
                        clsDrill.ToolList[index7].Data.Used = true;
                        DrillFound.Add(drillCalcItemList3[index6], clsDrill.ToolList[index7].Data.No, ref Found);
                        this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index6].ID);
                      }
                      if (availableTool < 1)
                        this.calcErrorList.Add($"Bottom Surface Y3 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index7].Data.No.ToString()} - Position : {drillCalcItemList3[index6].Center.ToString()}");
                      index7 = clsDrill.ToolList.Count;
                    }
                  }
                }
              }
            }
            if (Count1 > 0 & !clsDrill.varDrillCNCSettings.SearchVerToolEvenMultiHorDrillAvailableForTop)
              flag2 = false;
            if (foundTool != null & Count2 > 0 & flag2 && drillCalcItemList3.Count > 0)
            {
              List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
              clsInit.cDrill.FindNextVerticalDrill(this.SplitedItems.lstBottom, drillCalcItemList3[index4], index1 + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems);
              for (int index8 = 0; index8 <= foundItems.Count - 1; ++index8)
              {
                double num1 = foundItems[index8].Center.X - drillCalcItemList3[index4].Center.X;
                for (int index9 = 0; index9 <= clsDrill.ToolList.Count - 1; ++index9)
                {
                  if (!foundItems[index8].Calculated & foundTool.Data.GroupIndex == clsDrill.ToolList[index9].Data.GroupIndex & !clsDrill.ToolList[index9].Data.Used & clsDrill.ToolList[index9].Geometry.Diameter == foundItems[index8].Diameter & clsDrill.ToolList[index9].Geometry.ToolDirection.Z == 1.0)
                  {
                    double num2 = foundTool.Positions.Offset.X - clsDrill.ToolList[index9].Positions.Offset.X;
                    double num3 = foundTool.Positions.Offset.Y - clsDrill.ToolList[index9].Positions.Offset.Y;
                    if (buCompare5.EQ(num1, num2, 0.05) & buCompare5.EQ(num3, 0.0, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index9].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
                      if (availableTool > 0)
                      {
                        foundItems[index8].HeadNo = 3;
                        foundItems[index8].OffsetedPoint.Y = foundItems[index8].Center.Y - clsDrill.ToolList[index9].Positions.Offset.Y;
                        DrillFound.Add(foundItems[index8], clsDrill.ToolList[index9].Data.No, ref Found);
                        this.SetAsCalculatedDrillItemByID(foundItems[index8].ID);
                        clsDrill.ToolList[index9].Data.Used = true;
                      }
                      if (availableTool < 1)
                        this.calcErrorList.Add($"Bottom Surface Y3 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index9].Data.No.ToString()} - Position : {foundItems[index8].Center.ToString()}");
                      index9 = clsDrill.ToolList.Count;
                    }
                  }
                }
              }
            }
          }
        }
        if (Found.Items.Count > 0)
          this.FoundDrills.Add(Found);
      }
    }
  }

  public void FindHolesForLefttSide()
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstLeft.Count - 1; ++index1)
    {
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstLeft[index1];
      List<DrillCalcItem> drillCalcItemList2 = (List<DrillCalcItem>) null;
      if (index1 < this.SplitedItems.lstLeft.Count - 1)
        drillCalcItemList2 = this.SplitedItems.lstLeft[index1 + 1];
      List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList4 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
          drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
      }
      if (drillCalcItemList2 != null)
      {
        for (int index3 = 0; index3 <= drillCalcItemList2.Count - 1; ++index3)
        {
          if (!drillCalcItemList2[index3].Calculated)
            drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList2[index3]));
        }
      }
      int count = drillCalcItemList3.Count;
      for (int index4 = 0; index4 <= count - 1; ++index4)
      {
        DrillFound Found = new DrillFound();
        for (int index5 = 0; index5 <= clsDrill.ToolList.Count - 1; ++index5)
          clsDrill.ToolList[index5].Data.Used = false;
        List<int> intList = new List<int>();
        int T1 = 0;
        int T2 = 0;
        int T3 = 0;
        int T4 = 0;
        int T5 = 0;
        int T6 = 0;
        int T7 = 0;
        int T8 = 0;
        int T9 = 0;
        int T10 = 0;
        int T11 = 0;
        int T12 = 0;
        int Count = 0;
        FindToolSettings Settings = new FindToolSettings();
        Settings.SetAsUsed = true;
        ToolBase5 foundTool = (ToolBase5) null;
        Settings.Plane = planeBoxNames.Left;
        if (index4 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0 && !drillCalcItemList3[index4].Calculated)
        {
          Count = 0;
          clsInit.cDrill.isVerticalDrillAvailable(drillCalcItemList3[index4], this.SplitedItems.lstLeft, clsDrill.varDrillCNCSettings.ToolRepeatDistance, index1, ref Count);
          this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, ref foundTool);
          if (foundTool != null)
          {
            if (this.SetValueToAvailableTool(foundTool.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList3[index4].Calculated = true;
              drillCalcItemList3[index4].OffsetedPoint.Y = drillCalcItemList3[index4].Center.Y + foundTool.Positions.CommonOffset.Y;
              drillCalcItemList3[index4].HeadNo = 1;
              DrillFound.Add(drillCalcItemList3[index4], foundTool.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index4].ID);
            }
            else
              this.calcErrorList.Add($"Left Surface Y2 Group Tool Set Limit Full - Tool No : {foundTool.Data.No.ToString()} - Position : {drillCalcItemList3[index4].Center.ToString()}");
          }
        }
        if (Found.Items.Count > 0)
          this.FoundDrills.Add(Found);
      }
    }
  }

  public void FindHolesForRightSide()
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstRight.Count - 1; ++index1)
    {
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstRight[index1];
      List<DrillCalcItem> drillCalcItemList2 = (List<DrillCalcItem>) null;
      if (index1 < this.SplitedItems.lstRight.Count - 1)
        drillCalcItemList2 = this.SplitedItems.lstRight[index1 + 1];
      List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList4 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
          drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
      }
      if (drillCalcItemList2 != null)
      {
        for (int index3 = 0; index3 <= drillCalcItemList2.Count - 1; ++index3)
        {
          if (!drillCalcItemList2[index3].Calculated)
            drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList2[index3]));
        }
      }
      int count = drillCalcItemList3.Count;
      for (int index4 = 0; index4 <= count - 1; ++index4)
      {
        DrillFound Found = new DrillFound();
        for (int index5 = 0; index5 <= clsDrill.ToolList.Count - 1; ++index5)
          clsDrill.ToolList[index5].Data.Used = false;
        List<int> intList = new List<int>();
        int T1 = 0;
        int T2 = 0;
        int T3 = 0;
        int T4 = 0;
        int T5 = 0;
        int T6 = 0;
        int T7 = 0;
        int T8 = 0;
        int T9 = 0;
        int T10 = 0;
        int T11 = 0;
        int T12 = 0;
        int Count = 0;
        FindToolSettings Settings = new FindToolSettings();
        Settings.SetAsUsed = true;
        ToolBase5 foundTool = (ToolBase5) null;
        Settings.Plane = planeBoxNames.Right;
        if (index4 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0 && !drillCalcItemList3[index4].Calculated)
        {
          Count = 0;
          clsInit.cDrill.isVerticalDrillAvailable(drillCalcItemList3[index4], this.SplitedItems.lstRight, clsDrill.varDrillCNCSettings.ToolRepeatDistance, index1, ref Count);
          this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, ref foundTool);
          if (foundTool != null)
          {
            if (this.SetValueToAvailableTool(foundTool.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList3[index4].Calculated = true;
              drillCalcItemList3[index4].OffsetedPoint.Y = drillCalcItemList3[index4].Center.Y + foundTool.Positions.CommonOffset.Y;
              drillCalcItemList3[index4].HeadNo = 1;
              DrillFound.Add(drillCalcItemList3[index4], foundTool.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index4].ID);
            }
            else
              this.calcErrorList.Add($"Rigth Surface Y2 Group Tool Set Limit Full - Tool No : {foundTool.Data.No.ToString()} - Position : {drillCalcItemList3[index4].Center.ToString()}");
          }
        }
        if (Found.Items.Count > 0)
          this.FoundDrills.Add(Found);
      }
    }
  }

  public void AssingToolOffset()
  {
    for (int index1 = 0; index1 <= this.FoundDrills.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
      {
        double XOffset = 0.0;
        this.GetXToolOffsetFromNo(this.FoundDrills[index1].Items[index2].Tool, ref XOffset);
        double num = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.0 + this.FoundDrills[index1].Items[index2].Center.X;
        this.FoundDrills[index1].Items[index2].OffsetedPoint.X = num;
      }
    }
  }

  public void MoveBackOperationToLast()
  {
    List<DrillFound> drillFoundList = new List<DrillFound>();
    for (int index = this.FoundDrills.Count - 1; index >= 0; --index)
    {
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Back)
      {
        DrillFound drillFound = new DrillFound(this.FoundDrills[index]);
        drillFoundList.Add(drillFound);
        this.FoundDrills.RemoveAt(index);
      }
    }
    if (drillFoundList.Count <= 0)
      return;
    drillFoundList.Reverse();
    for (int index = 0; index <= drillFoundList.Count - 1; ++index)
      this.FoundDrills.Add(drillFoundList[index]);
  }

  public void CreateCodes(ref DrillJob Job)
  {
    this.LastPlane = drillPlaneNames.Top;
    if (this.FoundDrills.Count > 0)
    {
      if (this.FoundDrills[0].Items.Count > 0)
      {
        double num1 = this.FoundDrills[0].Items[0].OffsetedPoint.X + clsDrill.varDrillCNCSettings.X1SafeDistance;
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper + num1 > clsDrill.varDrillMachineSettings.MachineMaxXStroke)
        {
          double num2 = this.FoundDrills.Count < 2 ? this.FoundDrills[0].Items[0].OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition : this.FoundDrills[1].Items[0].OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
          double num3 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num2 - clsDrill.varDrillMachineSettings.MachineMaxXStroke + 100.0;
          double num4 = 500.0;
          if (num3 > 0.0 & num3 < 500.0)
            num4 = num3;
          if (num3 >= 500.0 & num3 < 1000.0)
            num4 = num3;
          if (num3 > 1000.0)
            num4 = 1000.0;
          if (num4 > 1000.0)
            num4 = 1000.0;
          buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2, S2: "M87");
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(), this.list_2, this.list_3, ref Job);
          double newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num4;
          double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num4;
          List<string> collection = new List<string>();
          if (newX1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
          {
            if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
            {
              double num5 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R901=" + num5.ToString("f1"));
              this.list_2.Add("L CARPA.ISC");
              this.MoveClampers(newX1, this.NoMoveX2, drillPlaneNames.Top, this.list_2, this.list_3, ref Job);
            }
            double num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R900=" + num6.ToString("f1"));
            this.list_2.Add("L CARPB.ISC");
            this.MoveClampers(this.NoMoveX1, newX2, drillPlaneNames.Top, this.list_2, this.list_3, ref Job);
          }
          DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
          drillMove.Command = DrillMoveCommand.GCodeList;
          drillMove.pntCenter = new Point3D();
          drillMove.CodeLines = new List<string>();
          if (collection.Count > 0)
            drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
          Job.Moves.Add(drillMove);
        }
        else
        {
          buString5.AddStringsToList("M87", ref this.list_2);
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions()
          {
            OnlyCode = true
          }, this.list_2, this.list_3, ref Job);
        }
      }
      else
      {
        buString5.AddStringsToList("M87", ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions()
        {
          OnlyCode = true
        }, this.list_2, this.list_3, ref Job);
      }
    }
    for (int index = 0; index <= this.FoundDrills.Count - 1; ++index)
    {
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Top)
        this.CreateCodeForTop(ref Job, this.FoundDrills[index].Items, index);
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Front)
        this.CreateCodeForFront(ref Job, this.FoundDrills[index].Items, index);
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Back)
        this.CreateCodeForBack(ref Job, this.FoundDrills[index].Items, index);
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Left)
        this.CreateCodeForLeft(ref Job, this.FoundDrills[index].Items, index);
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Right)
        this.CreateCodeForRight(ref Job, this.FoundDrills[index].Items, index);
      if (index < this.FoundDrills.Count - 1 && this.FoundDrills[index + 1].Items.Count > 0)
      {
        double num7 = this.FoundDrills[index + 1].Items[0].OffsetedPoint.X - this.FoundDrills[index].Items[0].OffsetedPoint.X;
        double num8 = this.FoundDrills[this.FoundDrills.Count - 1].Items[0].OffsetedPoint.X - this.FoundDrills[index].Items[0].OffsetedPoint.X;
        double num9 = num7 + 100.0;
        if (num8 > num7)
          num9 = num8 + 100.0;
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper + num7 > clsDrill.varDrillMachineSettings.MachineMaxXStroke)
        {
          double num10 = Math.Round(Job.Moves[Job.Moves.Count - 1].X2Clamper + num9 - clsDrill.varDrillMachineSettings.MachineMaxXStroke, 5);
          double num11 = this.FoundDrills[this.FoundDrills.Count - 1].Items[0].OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
          double num12 = this.FoundDrills[this.FoundDrills.Count - 1].Items[0].OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
          double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num10;
          double newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num10;
          double num13 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 50.0;
          double num14 = 0.0;
          List<string> collection = new List<string>();
          if (newX1 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
            newX1 = clsDrill.varDrillMachineSettings.MachineMinXStroke + 20.0;
          if (newX1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
          {
            if (newX1 < num13)
              num11 -= num13 - newX1;
            buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(), this.list_2, this.list_3, ref Job);
            double num15 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num11;
            double num16 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num12;
            num14 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R901=" + num14.ToString("f1"));
            this.list_2.Add("L CARPA.ISC");
            this.MoveClampers(newX1, this.NoMoveX2, drillPlaneNames.Top, this.list_2, this.list_3, ref Job);
            num14 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R900=" + num14.ToString("f1"));
            this.list_2.Add("L CARPB.ISC");
            this.MoveClampers(this.NoMoveX1, newX2, drillPlaneNames.Top, this.list_2, this.list_3, ref Job);
            DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
            drillMove.Command = DrillMoveCommand.GCodeList;
            drillMove.pntCenter = new Point3D();
            drillMove.CodeLines = new List<string>();
            if (collection.Count > 0)
              drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
            Job.Moves.Add(drillMove);
          }
        }
      }
    }
  }

  public void CreateCodeForTop(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    List<string> CodesSL = new List<string>();
    this.list_2.Clear();
    this.list_3.Clear();
    drillPlaneNames refPlane = drillPlaneNames.Top;
    Point3D point3D = new Point3D();
    DrillCalcItem drillCalcItem = (DrillCalcItem) null;
    DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    double CenterX = 0.0;
    double dX = 0.0;
    double X = 0.0;
    double Y1 = this.NoMoveY1;
    double noMoveZ1 = this.NoMoveZ1;
    double Z1_1 = this.NoMoveZ1;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double Z1_2 = this.NoMoveZ1;
    bool flag1 = false;
    List<ToolBase5> FoundTools = new List<ToolBase5>();
    double num1 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
    double num2 = 0.0;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem == null & Items[index].HeadNo == 1)
      {
        drillCalcItem = Items[index];
        Y1 = drillCalcItem.OffsetedPoint.Y;
        double z = drillCalcItem.Center.Z;
        Z1_2 = z - drillCalcItem.Depth;
        Z1_1 = z + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
        CenterX = drillCalcItem.Center.X;
        point3D.X = drillCalcItem.Center.X;
        point3D.Y = drillCalcItem.Center.Y;
        point3D.Z = drillCalcItem.Depth;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option);
      if (Items[index] != null && Items[index].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + Items[index].Diameter / 2.0)
        flag1 = true;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
        {
          if (foundTool.CamData.PlungeSpeed > 0.0)
          {
            num1 = foundTool.CamData.PlungeSpeed;
            num2 = foundTool.CamData.WaitTime;
          }
          FoundTools.Add(foundTool);
        }
      }
      else
        this.calcErrorList.Add($"{buDrillCalc.LangDrillMessage[40]} - {clsInit.cDrill.DrillCalcItemToString(Items[index])}");
    }
    if (drillCalcItem != null)
    {
      dX = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      X = drillCalcItem.OffsetedPoint.X;
    }
    if (Index == 0)
    {
      buString5.AddStringsToList("M85", ref this.list_2, S2: "M6T" + Option.Tool1.ToString(), S3: "M16", S4: "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
      Option.isG0 = true;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      this.LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    }
    else
    {
      if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Top)
      {
        if (this.FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
          buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
      }
      else
        buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
      Option.OnlyCode = true;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveX2, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      Option.OnlyCode = false;
    }
    if (flag1 & !Job.isSingleClamper)
      this.CheckClampers(Index, dX, CenterX, Items[0], refPlane, FoundTools, ref Job, ref CodesSL);
    if (Job.Moves[Job.Moves.Count - 1].X2Clamper + dX > clsDrill.varDrillMachineSettings.MachineMaxXStroke)
    {
      double num3 = Job.Moves[Job.Moves.Count - 1].X2Clamper + dX - clsDrill.varDrillMachineSettings.MachineMaxXStroke;
      buString5.AddStringsToList($"G0 X{(point3D.X - num3).ToString("f2")} Y{point3D.Y.ToString("f2")}", ref this.list_2);
      Option.Mode = DrillCNCMode.Fast;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX - num3, Job.Moves[Job.Moves.Count - 1].X2Clamper + dX - num3, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X - num3, Option, this.list_2, this.list_3, ref Job);
      this.list_2.Clear();
      this.list_2.Add("R910=0");
      this.list_2.Add("R901=" + num3.ToString("f1"));
      this.list_2.Add("L CARPA.ISC");
      this.MoveClampers(Job.Moves[Job.Moves.Count - 1].X1Clamper - num3, this.NoMoveX2, drillPlaneNames.Top, this.list_2, this.list_3, ref Job);
      this.list_2.Clear();
      this.list_2.Add("R910=0");
      this.list_2.Add("R900=" + num3.ToString("f1"));
      this.list_2.Add("L CARPB.ISC");
      this.MoveClampers(this.NoMoveX1, Job.Moves[Job.Moves.Count - 1].X2Clamper - num3, drillPlaneNames.Top, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList($"G0 X{point3D.X.ToString("f2")} Y{point3D.Y.ToString("f2")}", ref this.list_2);
      Option.Mode = DrillCNCMode.Fast;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num3, Job.Moves[Job.Moves.Count - 1].X2Clamper + num3, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X, Option, this.list_2, this.list_3, ref Job);
    }
    else
    {
      buString5.AddStringsToList($"G0 X{point3D.X.ToString("f2")} Y{point3D.Y.ToString("f2")}", ref this.list_2);
      Option.Mode = DrillCNCMode.Fast;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X, Option, this.list_2, this.list_3, ref Job);
    }
    Option.Mode = DrillCNCMode.ToolSet;
    buString5.AddStringsToList("G0 Z" + Z1_1.ToString("f2"), ref this.list_2);
    this.ToolSetAddList(Option, ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1_1, DrillMoveCommand.SetPiston, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    Option.Mode = DrillCNCMode.Plunge;
    buString5.AddStringsToList($"G1 Z{Z1_2.ToString("f2")} F{num1.ToString()}", ref this.list_2);
    if (num2 > 0.0)
      buString5.AddStringsToList("G4 F" + num2.ToString("f1"), ref this.list_2, false);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1_2, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    if (Index < this.FoundDrills.Count - 1)
    {
      bool flag2 = false;
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Top)
      {
        if (clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
          flag2 = true;
        if (flag1)
          flag2 = false;
        if (flag2)
        {
          if (!Job.isSingleClamper)
          {
            buString5.AddStringsToList("G0 Z" + Z1_1.ToString("f2"), ref this.list_2, S2: "M144");
            Option.Mode = DrillCNCMode.SafeRapid;
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1_1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
          }
          else if (flag1)
          {
            buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2, S2: "M144");
            Option.Mode = DrillCNCMode.SafeRapid;
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
          }
          else
          {
            buString5.AddStringsToList("G0 Z" + Z1_1.ToString("f2"), ref this.list_2, S2: "M144");
            Option.Mode = DrillCNCMode.SafeRapid;
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1_1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
          }
        }
        else
        {
          buString5.AddStringsToList("G0 Z" + Z1_1.ToString("f2"), ref this.list_2);
          Option.Mode = DrillCNCMode.SafeRapid;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1_1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
          buString5.AddStringsToList("M85", ref this.list_2);
          Option.Mode = DrillCNCMode.ToolReset;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        }
      }
      else
      {
        buString5.AddStringsToList("G0 Z" + z1SafeDistance.ToString("f2"), ref this.list_2);
        Option.Mode = DrillCNCMode.Safe;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        Option.Mode = DrillCNCMode.ToolReset;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      }
    }
    else
    {
      buString5.AddStringsToList("G0 Z" + z1SafeDistance.ToString("f2"), ref this.list_2);
      Option.Mode = DrillCNCMode.Safe;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      this.list_2.Clear();
      Option.Mode = DrillCNCMode.ToolReset;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    }
    this.LastPlane = drillPlaneNames.Top;
    DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
    drillMove.Command = DrillMoveCommand.GCodeList;
    drillMove.pntCenter = new Point3D();
    drillMove.CodeLines = new List<string>();
    drillMove.CodeLines.AddRange((IEnumerable<string>) CodesSL);
    if (CodesSL.Count <= 0)
      return;
    Job.Moves.Add(drillMove);
  }

  public void CreateCodeForFront(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    this.list_2.Clear();
    this.list_3.Clear();
    List<string> collection = new List<string>();
    DrillCalcItem drillCalcItem = (DrillCalcItem) null;
    drillPlaneNames Plane = drillPlaneNames.Front;
    Point3D point3D = new Point3D();
    DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    double num1 = 0.0;
    double X1 = 0.0;
    double X2 = 0.0;
    double X3 = 0.0;
    double Y1 = this.NoMoveY1;
    double Z1 = this.NoMoveZ1;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double num2 = double.MaxValue;
    double num3 = 0.0;
    List<ToolBase5> toolBase5List = new List<ToolBase5>();
    double num4 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
    double num5 = 0.0;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem == null & Items[index].HeadNo == 1)
      {
        drillCalcItem = Items[index];
        Y1 = drillCalcItem.OffsetedPoint.Y;
        Z1 = drillCalcItem.Center.Z;
        num3 = drillCalcItem.Center.X;
        point3D.X = drillCalcItem.Depth;
        point3D.Y = drillCalcItem.Center.Y;
        point3D.Z = drillCalcItem.Center.Z;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option);
      if (Items[index].Center.Y < num2)
        num2 = Items[index].Center.Y;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
        {
          if (foundTool.CamData.PlungeSpeed > 0.0)
          {
            num4 = foundTool.CamData.PlungeSpeed;
            num5 = foundTool.CamData.WaitTime;
          }
          toolBase5List.Add(foundTool);
        }
      }
      else
        this.calcErrorList.Add("No Defined Tool For This OP");
    }
    if (drillCalcItem != null)
    {
      ToolBase5 foundTool = new ToolBase5();
      this.FindToolWithToolNo(drillCalcItem.Tool, ref foundTool);
      num1 = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      double x = drillCalcItem.OffsetedPoint.X;
      X1 = x - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.X1SafeDistance;
      X2 = x - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.X1SmallSafeDistance;
      X3 = x - foundTool.Geometry.Length + drillCalcItem.Depth;
    }
    if (!Job.isSingleClamper && num2 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0 & (Job.Moves[Job.Moves.Count - 1].X2Clamper > 0.0 | Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper) < clsDrill.varDrillCNCSettings.ClamperLength / 2.0))
    {
      double num6 = 0.0;
      if (Index < this.FoundDrills.Count - 1)
      {
        for (int index1 = Index + 1; index1 <= this.FoundDrills.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
          {
            if (this.FoundDrills[index1].Items[index2].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + this.FoundDrills[index1].Items[index2].Diameter / 2.0)
            {
              double num7 = this.FoundDrills[index1].Items[index2].Center.X - num3;
              if (num7 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Top | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Left && num7 > num6)
                num6 = num7;
            }
          }
        }
      }
      if (num6 > 0.0)
        num6 += clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
      double num8 = toolBase5List[0].Positions.CommonOffset.X - toolBase5List[0].Geometry.Length - 40.0;
      double num9 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num1;
      if (num9 > num8)
      {
        double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (num9 - num8) - num6;
        double num10;
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num11 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          num10 = Job.Moves[Job.Moves.Count - 1].X1Clamper - (newX2 - num11);
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R901=" + num10.ToString("f1"));
          this.list_2.Add("L CARPA.ISC");
          this.MoveClampers(newX2 - num11, this.NoMove, Plane, this.list_2, this.list_3, ref Job);
        }
        num10 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
        this.list_2.Clear();
        this.list_2.Add("R910=0");
        this.list_2.Add("R900=" + num10.ToString("f1"));
        this.list_2.Add("L CARPB.ISC");
        this.MoveClampers(this.NoMove, newX2, Plane, this.list_2, this.list_3, ref Job);
      }
    }
    if (Index == 0)
    {
      buString5.AddStringsToList("M85", ref this.list_2, S2: "M6T" + Option.Tool1.ToString(), S3: "M16", S4: "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      this.LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
      buString5.AddStringsToList($"G0 X{(-clsDrill.varDrillCNCSettings.XSafeDistance).ToString("f2")} Y{point3D.Y.ToString("f2")}", ref this.list_2);
      double num12 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num12, Job.Moves[Job.Moves.Count - 1].X2Clamper + num12, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X1, Option, this.list_2, this.list_3, ref Job);
    }
    else if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Front)
    {
      if (this.FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
        buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
    }
    else
      buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
    double num13;
    if (Index > 0)
    {
      if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Front)
      {
        List<string> list2 = this.list_2;
        num13 = -clsDrill.varDrillCNCSettings.X1SmallSafeDistance;
        string str = $"G0 X{num13.ToString("f2")} Y{point3D.Y.ToString("f2")}";
        list2.Add(str);
      }
      else
      {
        List<string> list2 = this.list_2;
        num13 = -clsDrill.varDrillCNCSettings.X1SafeDistance;
        string str = $"G0 X{num13.ToString("f2")} Y{point3D.Y.ToString("f2")}";
        list2.Add(str);
      }
    }
    else
    {
      List<string> list2 = this.list_2;
      num13 = -clsDrill.varDrillCNCSettings.X1SafeDistance;
      string str = $"G0 X{num13.ToString("f2")} Y{point3D.Y.ToString("f2")}";
      list2.Add(str);
    }
    double num14 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
    this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num14, Job.Moves[Job.Moves.Count - 1].X2Clamper + num14, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X2, Option, this.list_2, this.list_3, ref Job);
    this.list_2.Clear();
    this.ToolSetAddList(Option, ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1, DrillMoveCommand.SetPiston, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    buString5.AddStringsToList("G0 Z" + point3D.Z.ToString("f2"), ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    double num15 = X3 - Job.Moves[Job.Moves.Count - 1].XPosition;
    buString5.AddStringsToList($"G1 X{point3D.X.ToString("f2")} F{num4.ToString()}", ref this.list_2);
    this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num15, Job.Moves[Job.Moves.Count - 1].X2Clamper + num15, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X3, Option, this.list_2, this.list_3, ref Job);
    if (num5 > 0.0)
      buString5.AddStringsToList("G4 F" + num5.ToString("f1"), ref this.list_2, false);
    if (Index < this.FoundDrills.Count - 1)
    {
      bool flag = false;
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Front)
      {
        num13 = -clsDrill.varDrillCNCSettings.X1SmallSafeDistance;
        buString5.AddStringsToList("G0 X" + num13.ToString("f2"), ref this.list_2);
        double num16 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num16, Job.Moves[Job.Moves.Count - 1].X2Clamper + num16, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X2, Option, this.list_2, this.list_3, ref Job);
        if (clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
          flag = true;
        if (!flag)
        {
          buString5.AddStringsToList("M85", ref this.list_2);
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        }
        else
        {
          buString5.AddStringsToList("M144", ref this.list_2);
          Option.OnlyCode = true;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
          Option.OnlyCode = false;
        }
      }
      else
      {
        double num17 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
        num13 = -clsDrill.varDrillCNCSettings.XSafeDistance;
        buString5.AddStringsToList("G0 X" + num13.ToString("f2"), ref this.list_2);
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num17, Job.Moves[Job.Moves.Count - 1].X2Clamper + num17, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X1, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("M85", ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      }
    }
    else
    {
      double num18 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      num13 = -clsDrill.varDrillCNCSettings.XSafeDistance;
      buString5.AddStringsToList("G0 X" + num13.ToString("f2"), ref this.list_2);
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num18, Job.Moves[Job.Moves.Count - 1].X2Clamper + num18, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X1, Option, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList("M85", ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    }
    DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
    drillMove.Command = DrillMoveCommand.GCodeList;
    drillMove.pntCenter = new Point3D();
    drillMove.CodeLines = new List<string>();
    drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
    if (collection.Count > 0)
      Job.Moves.Add(drillMove);
    this.LastPlane = drillPlaneNames.Front;
  }

  public void CreateCodeForBack(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    this.list_2.Clear();
    this.list_3.Clear();
    List<string> collection = new List<string>();
    DrillCalcItem drillCalcItem = (DrillCalcItem) null;
    Point3D point3D = new Point3D();
    DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    double num1 = 0.0;
    double X1 = 0.0;
    double X2 = 0.0;
    double X3 = 0.0;
    double Y1 = this.NoMoveY1;
    double Z1 = this.NoMoveZ1;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double num2 = double.MaxValue;
    double num3 = 0.0;
    List<ToolBase5> toolBase5List = new List<ToolBase5>();
    double num4 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
    double num5 = 0.0;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem == null & Items[index].HeadNo == 1)
      {
        drillCalcItem = Items[index];
        Y1 = drillCalcItem.OffsetedPoint.Y;
        Z1 = drillCalcItem.Center.Z;
        num3 = drillCalcItem.Center.X;
        point3D.X = Job.Material.Size.Width - drillCalcItem.Depth;
        point3D.Y = drillCalcItem.Center.Y;
        point3D.Z = drillCalcItem.Center.Z;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option);
      if (Items[index].Center.Y < num2)
        num2 = Items[index].Center.Y;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
        {
          if (foundTool.CamData.PlungeSpeed > 0.0)
          {
            num4 = foundTool.CamData.PlungeSpeed;
            num5 = foundTool.CamData.WaitTime;
          }
          toolBase5List.Add(foundTool);
        }
      }
      else
        this.calcErrorList.Add("No Defined Tool For This OP");
    }
    if (drillCalcItem != null)
    {
      ToolBase5 foundTool = new ToolBase5();
      this.FindToolWithToolNo(drillCalcItem.Tool, ref foundTool);
      num1 = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      double x = drillCalcItem.OffsetedPoint.X;
      X1 = x + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.X1SafeDistance;
      X2 = x + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.X1SmallSafeDistance;
      X3 = x + foundTool.Geometry.Length - drillCalcItem.Depth;
    }
    if (!Job.isSingleClamper)
    {
      double num6 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
      if (num2 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0 & Job.Moves[Job.Moves.Count - 1].X1Clamper < num6 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0)
      {
        double num7 = 0.0;
        if (Index < this.FoundDrills.Count - 1)
        {
          for (int index1 = Index + 1; index1 <= this.FoundDrills.Count - 1; ++index1)
          {
            for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
            {
              if (this.FoundDrills[index1].Items[index2].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + this.FoundDrills[index1].Items[index2].Diameter / 2.0)
              {
                double num8 = Math.Abs(this.FoundDrills[index1].Items[index2].Center.X - num3);
                if (num8 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Top | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Left && num8 > num7)
                  num7 = num8;
              }
            }
          }
        }
        if (num7 > 0.0)
          num7 += clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
        double num9 = X3 - Job.Moves[Job.Moves.Count - 1].XPosition;
        double num10 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num9;
        double num11 = toolBase5List[0].Positions.CommonOffset.X + toolBase5List[0].Geometry.Length + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
        if (num2 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0 & num10 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 < num11)
        {
          double num12 = num11 - (num10 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
          if (num12 > 0.0)
          {
            double newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num12 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + num7;
            double num13;
            if (Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
            {
              double num14 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
              double newX2 = newX1 + num14;
              num13 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R900=" + num13.ToString("f1"));
              this.list_2.Add("L CARPB.ISC");
              this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Back, this.list_2, this.list_3, ref Job);
            }
            num13 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R901=" + num13.ToString("f1"));
            this.list_2.Add("L CARPA.ISC");
            this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Back, this.list_2, this.list_3, ref Job);
          }
        }
      }
    }
    if (Index == 0)
    {
      buString5.AddStringsToList("M85", ref this.list_2, S2: "M6T" + Option.Tool1.ToString(), S3: "M16", S4: "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      this.LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
      buString5.AddStringsToList($"G0 X{(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.XSafeDistance).ToString("f2")} Y{point3D.Y.ToString("f2")}", ref this.list_2);
      double num15 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num15, Job.Moves[Job.Moves.Count - 1].X2Clamper + num15, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X1, Option, this.list_2, this.list_3, ref Job);
    }
    else if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Back)
    {
      if (this.FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
        buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
    }
    else
      buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
    double num16;
    if (Index > 0)
    {
      if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Back)
      {
        List<string> list2 = this.list_2;
        num16 = Job.Material.Size.Width + clsDrill.varDrillCNCSettings.X1SmallSafeDistance;
        string str = $"G0 X{num16.ToString("f2")} Y{point3D.Y.ToString("f2")}";
        list2.Add(str);
      }
      else
      {
        List<string> list2 = this.list_2;
        num16 = Job.Material.Size.Width + clsDrill.varDrillCNCSettings.X1SafeDistance;
        string str = $"G0 X{num16.ToString("f2")} Y{point3D.Y.ToString("f2")}";
        list2.Add(str);
      }
    }
    else
    {
      List<string> list2 = this.list_2;
      num16 = Job.Material.Size.Width + clsDrill.varDrillCNCSettings.X1SafeDistance;
      string str = $"G0 X{num16.ToString("f2")} Y{point3D.Y.ToString("f2")}";
      list2.Add(str);
    }
    double num17 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
    this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num17, Job.Moves[Job.Moves.Count - 1].X2Clamper + num17, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X2, Option, this.list_2, this.list_3, ref Job);
    this.list_2.Clear();
    this.ToolSetAddList(Option, ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1, DrillMoveCommand.SetPiston, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    buString5.AddStringsToList("G0 Z" + point3D.Z.ToString("f2"), ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    double num18 = X3 - Job.Moves[Job.Moves.Count - 1].XPosition;
    buString5.AddStringsToList($"G1 X{point3D.X.ToString("f2")} F{num4.ToString()}", ref this.list_2);
    this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num18, Job.Moves[Job.Moves.Count - 1].X2Clamper + num18, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X3, Option, this.list_2, this.list_3, ref Job);
    if (num5 > 0.0)
      buString5.AddStringsToList("G4 F" + num5.ToString("f1"), ref this.list_2, false);
    if (Index < this.FoundDrills.Count - 1)
    {
      bool flag = false;
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Back)
      {
        num16 = Job.Material.Size.Width + clsDrill.varDrillCNCSettings.X1SmallSafeDistance;
        buString5.AddStringsToList("G0 X" + num16.ToString("f2"), ref this.list_2);
        double num19 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num19, Job.Moves[Job.Moves.Count - 1].X2Clamper + num19, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X2, Option, this.list_2, this.list_3, ref Job);
        if (clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
          flag = true;
        if (!flag)
        {
          buString5.AddStringsToList("M85", ref this.list_2);
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        }
        else
        {
          buString5.AddStringsToList("M144", ref this.list_2);
          Option.OnlyCode = true;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
          Option.OnlyCode = false;
        }
      }
      else
      {
        double num20 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
        num16 = Job.Material.Size.Width + clsDrill.varDrillCNCSettings.XSafeDistance;
        buString5.AddStringsToList("G0 X" + num16.ToString("f2"), ref this.list_2);
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num20, Job.Moves[Job.Moves.Count - 1].X2Clamper + num20, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X1, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("M85", ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetPiston, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      }
    }
    else
    {
      double num21 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      num16 = Job.Material.Size.Width + clsDrill.varDrillCNCSettings.XSafeDistance;
      buString5.AddStringsToList("G0 X" + num16.ToString("f2"), ref this.list_2);
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num21, Job.Moves[Job.Moves.Count - 1].X2Clamper + num21, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X1, Option, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList("M85", ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    }
    DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
    drillMove.Command = DrillMoveCommand.GCodeList;
    drillMove.pntCenter = new Point3D();
    drillMove.CodeLines = new List<string>();
    drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
    if (collection.Count > 0)
      Job.Moves.Add(drillMove);
    this.LastPlane = drillPlaneNames.Back;
  }

  public void CreateCodeForLeft(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    this.list_2.Clear();
    this.list_3.Clear();
    List<string> CodesSL = new List<string>();
    drillPlaneNames refPlane = drillPlaneNames.Left;
    DrillCalcItem drillCalcItem = (DrillCalcItem) null;
    Point3D point3D = new Point3D();
    DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Left, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    double dX = 0.0;
    double X = 0.0;
    double Z1 = this.NoMoveZ1;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double num1 = double.MaxValue;
    double CenterX = 0.0;
    double Y1_1 = this.NoMoveY1;
    double Y1_2 = this.NoMoveY1;
    double Y1_3 = this.NoMoveY1;
    List<ToolBase5> FoundTools = new List<ToolBase5>();
    double num2 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
    double num3 = 0.0;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem == null & Items[index].HeadNo == 1)
      {
        drillCalcItem = Items[index];
        Z1 = drillCalcItem.Center.Z;
        CenterX = drillCalcItem.Center.X;
        ToolBase5 foundTool = new ToolBase5();
        this.FindToolWithToolNo(drillCalcItem.Tool, ref foundTool);
        Y1_1 = drillCalcItem.OffsetedPoint.Y - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.Y1SafeDistance;
        Y1_3 = drillCalcItem.OffsetedPoint.Y - foundTool.Geometry.Length + drillCalcItem.Depth;
        Y1_2 = drillCalcItem.OffsetedPoint.Y - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.Y1SmallSafeDistance;
        point3D.X = drillCalcItem.Center.X;
        point3D.Y = drillCalcItem.Depth;
        point3D.Z = drillCalcItem.Center.Z;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option);
      if (Items[index].Center.Y < num1)
        num1 = Items[index].Center.Y;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
        {
          if (foundTool.CamData.PlungeSpeed > 0.0)
          {
            num2 = foundTool.CamData.PlungeSpeed;
            num3 = foundTool.CamData.WaitTime;
          }
          FoundTools.Add(foundTool);
        }
      }
      else
        this.calcErrorList.Add("No Defined Tool For This OP");
    }
    if (drillCalcItem != null)
    {
      dX = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      X = drillCalcItem.OffsetedPoint.X;
    }
    if (num1 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + Items[0].Diameter / 2.0 & !Job.isSingleClamper)
      this.CheckClampers(Index, dX, CenterX, Items[0], refPlane, FoundTools, ref Job, ref CodesSL);
    if (Index == 0)
    {
      buString5.AddStringsToList("M85", ref this.list_2, S2: "M6T" + Option.Tool1.ToString(), S3: "M16", S4: "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      this.LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    }
    else if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Left)
    {
      if (this.FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
        buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
    }
    else
      buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
    if (Index > 0)
    {
      if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Left)
        this.list_2.Add($"G0 X{point3D.X.ToString("f2")} Y{(-clsDrill.varDrillCNCSettings.Y1SmallSafeDistance).ToString("f2")}");
      else
        this.list_2.Add($"G0 X{point3D.X.ToString("f2")} Y{(-clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2")}");
    }
    else
      this.list_2.Add($"G0 X{point3D.X.ToString("f2")} Y{(-clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2")}");
    this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, Y1_2, this.NoMoveZ1, DrillMoveCommand.AxisMove, X, Option, this.list_2, this.list_3, ref Job);
    this.list_2.Clear();
    this.ToolSetAddList(Option, ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1, DrillMoveCommand.SetPiston, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    buString5.AddStringsToList("G0 Z" + point3D.Z.ToString("f2"), ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    buString5.AddStringsToList($"G1 Y{point3D.Y.ToString("f2")} F{num2.ToString()}", ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_3, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    if (num3 > 0.0)
      buString5.AddStringsToList("G4 F" + num3.ToString("f1"), ref this.list_2, false);
    if (Index < this.FoundDrills.Count - 1)
    {
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Left)
      {
        buString5.AddStringsToList("G0 Y" + (-clsDrill.varDrillCNCSettings.Y1SmallSafeDistance).ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("M85", ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      }
      else
      {
        buString5.AddStringsToList("G0 Y" + (-clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("M85", ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      }
    }
    else
    {
      buString5.AddStringsToList("G0 Y" + (-clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"), ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList("M85", ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    }
    this.LastPlane = drillPlaneNames.Left;
    DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
    drillMove.Command = DrillMoveCommand.GCodeList;
    drillMove.pntCenter = new Point3D();
    drillMove.CodeLines = new List<string>();
    drillMove.CodeLines.AddRange((IEnumerable<string>) CodesSL);
    if (CodesSL.Count <= 0)
      return;
    Job.Moves.Add(drillMove);
  }

  public void CreateCodeForRight(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    this.list_2.Clear();
    this.list_3.Clear();
    List<string> collection = new List<string>();
    DrillCalcItem drillCalcItem = (DrillCalcItem) null;
    Point3D point3D = new Point3D();
    DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Right, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    double num1 = 0.0;
    double X = 0.0;
    double Z1 = this.NoMoveZ1;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double num2 = double.MaxValue;
    double Y1_1 = this.NoMoveY1;
    double Y1_2 = this.NoMoveY1;
    double Y1_3 = this.NoMoveY1;
    List<ToolBase5> toolBase5List = new List<ToolBase5>();
    double num3 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
    double num4 = 0.0;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem == null & Items[index].HeadNo == 1)
      {
        drillCalcItem = Items[index];
        Z1 = drillCalcItem.Center.Z;
        ToolBase5 foundTool = new ToolBase5();
        this.FindToolWithToolNo(drillCalcItem.Tool, ref foundTool);
        Y1_1 = drillCalcItem.OffsetedPoint.Y + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.Y1SafeDistance;
        Y1_2 = drillCalcItem.OffsetedPoint.Y + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.Y1SmallSafeDistance;
        Y1_3 = drillCalcItem.OffsetedPoint.Y + foundTool.Geometry.Length - drillCalcItem.Depth;
        point3D.X = drillCalcItem.Center.X;
        point3D.Y = Job.Material.Size.Height - drillCalcItem.Depth;
        point3D.Z = drillCalcItem.Center.Z;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option);
      if (Items[index].Center.Y < num2)
        num2 = Items[index].Center.Y;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
        {
          if (foundTool.CamData.PlungeSpeed > 0.0)
          {
            num3 = foundTool.CamData.PlungeSpeed;
            num4 = foundTool.CamData.WaitTime;
          }
          toolBase5List.Add(foundTool);
        }
      }
      else
        this.calcErrorList.Add("No Defined Tool For This OP");
    }
    if (drillCalcItem != null)
    {
      num1 = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      X = drillCalcItem.OffsetedPoint.X;
    }
    if (Index == 0)
    {
      buString5.AddStringsToList("M85", ref this.list_2, S2: "M6T" + Option.Tool1.ToString(), S3: "M16", S4: "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      this.LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    }
    else if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Right)
    {
      if (this.FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
        buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
    }
    else
      buString5.AddStringsToList("M6T" + Option.Tool1.ToString(), ref this.list_2, S2: "M16");
    double num5;
    if (Index > 0)
    {
      if (this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Right)
      {
        List<string> list2 = this.list_2;
        string str1 = point3D.X.ToString("f2");
        num5 = Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SmallSafeDistance;
        string str2 = num5.ToString("f2");
        string str3 = $"G0 X{str1} Y{str2}";
        list2.Add(str3);
      }
      else
      {
        List<string> list2 = this.list_2;
        string str4 = point3D.X.ToString("f2");
        num5 = Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SafeDistance;
        string str5 = num5.ToString("f2");
        string str6 = $"G0 X{str4} Y{str5}";
        list2.Add(str6);
      }
    }
    else
    {
      List<string> list2 = this.list_2;
      string str7 = point3D.X.ToString("f2");
      num5 = Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SafeDistance;
      string str8 = num5.ToString("f2");
      string str9 = $"G0 X{str7} Y{str8}";
      list2.Add(str9);
    }
    this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, Y1_2, this.NoMoveZ1, DrillMoveCommand.AxisMove, X, Option, this.list_2, this.list_3, ref Job);
    this.list_2.Clear();
    this.ToolSetAddList(Option, ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1, DrillMoveCommand.SetPiston, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    buString5.AddStringsToList("G0 Z" + point3D.Z.ToString("f2"), ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, Z1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    buString5.AddStringsToList($"G1 Y{point3D.Y.ToString("f2")} F{num3.ToString()}", ref this.list_2);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_3, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    if (num4 > 0.0)
      buString5.AddStringsToList("G4 F" + num4.ToString("f1"), ref this.list_2, false);
    if (Index < this.FoundDrills.Count - 1)
    {
      bool flag = false;
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Right)
      {
        num5 = Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SmallSafeDistance;
        buString5.AddStringsToList("G0 Y" + num5.ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_2, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        if (clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
          flag = true;
        if (!flag)
        {
          buString5.AddStringsToList("M85", ref this.list_2);
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        }
        else
        {
          buString5.AddStringsToList("M144", ref this.list_2);
          Option.OnlyCode = true;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
          Option.OnlyCode = false;
        }
      }
      else
      {
        num5 = Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SafeDistance;
        buString5.AddStringsToList("G0 Y" + num5.ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("M85", ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
        buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      }
    }
    else
    {
      num5 = Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SafeDistance;
      buString5.AddStringsToList("G0 Y" + num5.ToString("f2"), ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList("M85", ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Option, this.list_2, this.list_3, ref Job);
      buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref this.list_2);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Option, this.list_2, this.list_3, ref Job);
    }
    DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
    drillMove.Command = DrillMoveCommand.GCodeList;
    drillMove.pntCenter = new Point3D();
    drillMove.CodeLines = new List<string>();
    drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
    if (collection.Count > 0)
      Job.Moves.Add(drillMove);
    this.LastPlane = drillPlaneNames.Right;
  }

  public void CheckClampers(
    int Index,
    double dX,
    double CenterX,
    DrillCalcItem Item,
    drillPlaneNames refPlane,
    List<ToolBase5> FoundTools,
    ref DrillJob Job,
    ref List<string> CodesSL)
  {
    this.list_2.Clear();
    this.list_3.Clear();
    ClamperInsideCalc clamperInsideCalc1 = new ClamperInsideCalc();
    ClamperInsideCalc clamperInsideCalc2 = new ClamperInsideCalc();
    DrillMoveOptions Options = new DrillMoveOptions(refPlane, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    string str = $"{Item.planeName.ToString()} - {Item.Diameter.ToString("f1")} - {Item.Center.ToString()}";
    double num1 = 0.0;
    bool flag1 = false;
    bool flag2 = false;
    double num2 = Job.Material.Size.Width > clsDrill.varDrillCNCSettings.MaterialSmallLimit ? (!(clsDrill.varDrillCNCSettings.MaterialSmallLimit < Job.Material.Size.Width & Job.Material.Size.Width <= clsDrill.varDrillCNCSettings.MaterialMediumLimit) ? Math.Round(clsDrill.varDrillCNCSettings.ClamperLength * clsDrill.varDrillCNCSettings.ClamperBigMaterialCLampMinLengthPersc / 100.0, 3) : Math.Round(clsDrill.varDrillCNCSettings.ClamperLength * clsDrill.varDrillCNCSettings.ClamperMediumMaterialCLampMinLengthPersc / 100.0, 3)) : Math.Round(clsDrill.varDrillCNCSettings.ClamperLength * clsDrill.varDrillCNCSettings.ClamperSmallMaterialCLampMinLengthPersc / 100.0, 3);
    if (Index < this.FoundDrills.Count - 1)
    {
      for (int index1 = Index + 1; index1 <= this.FoundDrills.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
        {
          if (this.FoundDrills[index1].Items[index2].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + this.FoundDrills[index1].Items[index2].Diameter / 2.0)
          {
            double num3 = this.FoundDrills[index1].Items[index2].Center.X - CenterX;
            if (num3 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Top | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Left && num3 > num1)
              num1 = num3 + 10.0;
          }
        }
      }
    }
    clamperInsideCalc2.DrillInClamper = this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance, ref clamperInsideCalc2.minXClamper, ref clamperInsideCalc2.maxXClamper);
    clamperInsideCalc1.DrillInClamper = this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance, ref clamperInsideCalc1.minXClamper, ref clamperInsideCalc1.maxXClamper);
    clamperInsideCalc1.XMovePlus = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc1.minXClamper + num1;
    clamperInsideCalc1.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.maxXClamper - num1;
    clamperInsideCalc2.XMovePlus = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamper + num1;
    clamperInsideCalc2.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamper - num1;
    clamperInsideCalc2.DrillInClamperLassSafe = this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance / 2.0, ref clamperInsideCalc2.minXClamperLessSafe, ref clamperInsideCalc2.maxXClamperLessSafe);
    clamperInsideCalc1.DrillInClamperLassSafe = this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance / 2.0, ref clamperInsideCalc1.minXClamperLessSafe, ref clamperInsideCalc1.maxXClamperLessSafe);
    clamperInsideCalc1.XMovePlusLessSafe = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc1.minXClamperLessSafe;
    clamperInsideCalc1.XMoveMinusLessSafe = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.maxXClamperLessSafe;
    clamperInsideCalc2.XMovePlusLessSafe = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamperLessSafe;
    clamperInsideCalc2.XMoveMinusLessSafe = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamperLessSafe;
    double num4 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
    if (clamperInsideCalc1.XMoveMinus + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num4 < num2)
      flag1 = true;
    if (num1 != 0.0 & flag1)
    {
      flag1 = false;
      clamperInsideCalc1.XMovePlus = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc1.minXClamper;
      clamperInsideCalc1.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.maxXClamper;
      double num5 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
      if (clamperInsideCalc1.XMoveMinus + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num5 < num2)
        flag1 = true;
    }
    if (Job.Moves[Job.Moves.Count - 1].XPosition - (clamperInsideCalc2.XMovePlus - clsDrill.varDrillCNCSettings.ClamperLength / 2.0) < num2)
      flag2 = true;
    if (num1 != 0.0 & flag2)
    {
      flag2 = false;
      clamperInsideCalc2.XMovePlus = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamper;
      clamperInsideCalc2.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamper;
      if (Job.Moves[Job.Moves.Count - 1].XPosition - (clamperInsideCalc2.XMovePlus - clsDrill.varDrillCNCSettings.ClamperLength / 2.0) < num2)
        flag2 = true;
    }
    if (clamperInsideCalc2.DrillInClamper)
    {
      this.list_2.Clear();
      this.list_2.Add("M85");
      if (!this.isLastPositionLastZ(Job))
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, this.list_2, this.list_3, ref Job);
        this.list_2.Clear();
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Options, this.list_2, this.list_3, ref Job);
      }
      if (flag2)
      {
        if (clamperInsideCalc2.XMoveMinus - Job.Moves[Job.Moves.Count - 1].X1Clamper <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double newX1_1 = clamperInsideCalc2.XMoveMinus - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          double num6 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
          if (newX1_1 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num6 > num2)
          {
            double num7 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1_1;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R901=" + num7.ToString("f1"));
            this.list_2.Add("L CARPA.ISC");
            this.MoveClampers(newX1_1, this.NoMove, refPlane, this.list_2, this.list_3, ref Job);
            double num8 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinus;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R900=" + num8.ToString("f1"));
            this.list_2.Add("L CARPB.ISC");
            this.MoveClampers(this.NoMove, clamperInsideCalc2.XMoveMinus, refPlane, this.list_2, this.list_3, ref Job);
          }
          else
          {
            double newX1_2 = clamperInsideCalc2.XMoveMinusLessSafe - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
            double num9 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
            if (newX1_2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num9 > num2)
            {
              double num10 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1_2;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R901=" + num10.ToString("f1"));
              this.list_2.Add("L CARPA.ISC");
              this.MoveClampers(newX1_2, this.NoMove, refPlane, this.list_2, this.list_3, ref Job);
              double num11 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinusLessSafe;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R900=" + num11.ToString("f1"));
              this.list_2.Add("L CARPB.ISC");
              this.MoveClampers(this.NoMove, clamperInsideCalc2.XMoveMinusLessSafe, refPlane, this.list_2, this.list_3, ref Job);
              Job.isLesSafe = true;
            }
            else
              this.calcErrorList.Add($"{buDrillCalc.LangDrillMessage[25]} - {str}");
          }
        }
        else
        {
          double num12 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinus;
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R900=" + num12.ToString("f1"));
          this.list_2.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, clamperInsideCalc2.XMoveMinus, refPlane, this.list_2, this.list_3, ref Job);
        }
      }
      else
      {
        bool flag3 = false;
        if (clamperInsideCalc2.XMovePlus - Job.Moves[Job.Moves.Count - 1].X1Clamper <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double newX1_3 = clamperInsideCalc2.XMoveMinus - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          double num13 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
          if (newX1_3 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num13 > num2)
          {
            double num14 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1_3;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R901=" + num14.ToString("f1"));
            this.list_2.Add("L CARPA.ISC");
            this.MoveClampers(newX1_3, this.NoMove, refPlane, ref Job);
            double num15 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinus;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R900=" + num15.ToString("f1"));
            this.list_2.Add("L CARPB.ISC");
            this.MoveClampers(this.NoMove, clamperInsideCalc2.XMoveMinus, refPlane, this.list_2, this.list_3, ref Job);
            flag3 = true;
          }
          else
          {
            double newX1_4 = clamperInsideCalc2.XMoveMinusLessSafe - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
            double num16 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
            if (newX1_4 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num16 > num2)
            {
              double num17 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1_4;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R901=" + num17.ToString("f1"));
              this.list_2.Add("L CARPA.ISC");
              this.MoveClampers(newX1_4, this.NoMove, refPlane, this.list_2, this.list_3, ref Job);
              double num18 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinusLessSafe;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R900=" + num18.ToString("f1"));
              this.list_2.Add("L CARPB.ISC");
              this.MoveClampers(this.NoMove, clamperInsideCalc2.XMoveMinusLessSafe, refPlane, this.list_2, this.list_3, ref Job);
              flag3 = true;
              Job.isLesSafe = true;
            }
          }
        }
        else
        {
          double num19 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMovePlus;
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R900=" + num19.ToString("f1"));
          this.list_2.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, clamperInsideCalc2.XMovePlus, refPlane, this.list_2, this.list_3, ref Job);
          flag3 = true;
        }
        if (!flag3)
        {
          double num20 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinus;
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R900=" + num20.ToString("f1"));
          this.list_2.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, clamperInsideCalc2.XMoveMinus, refPlane, this.list_2, this.list_3, ref Job);
        }
      }
    }
    if (clamperInsideCalc1.DrillInClamper & clamperInsideCalc2.DrillInClamper)
    {
      clamperInsideCalc2.DrillInClamper = this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance, ref clamperInsideCalc2.minXClamper, ref clamperInsideCalc2.maxXClamper);
      clamperInsideCalc1.DrillInClamper = this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance, ref clamperInsideCalc1.minXClamper, ref clamperInsideCalc1.maxXClamper);
      clamperInsideCalc1.XMovePlus = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc1.minXClamper + num1;
      clamperInsideCalc1.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.maxXClamper - num1;
      clamperInsideCalc2.XMovePlus = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamper + num1;
      clamperInsideCalc2.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamper - num1;
      clamperInsideCalc2.DrillInClamperLassSafe = this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance / 2.0, ref clamperInsideCalc2.minXClamperLessSafe, ref clamperInsideCalc2.maxXClamperLessSafe);
      clamperInsideCalc1.DrillInClamperLassSafe = this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance / 2.0, ref clamperInsideCalc1.minXClamperLessSafe, ref clamperInsideCalc1.maxXClamperLessSafe);
      clamperInsideCalc1.XMovePlusLessSafe = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc1.minXClamperLessSafe;
      clamperInsideCalc1.XMoveMinusLessSafe = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.maxXClamperLessSafe;
      clamperInsideCalc2.XMovePlusLessSafe = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamperLessSafe;
      clamperInsideCalc2.XMoveMinusLessSafe = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamperLessSafe;
    }
    if (clamperInsideCalc1.DrillInClamper)
    {
      this.list_2.Clear();
      this.list_2.Add("M85");
      if (!this.isLastPositionLastZ(Job))
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, this.list_2, this.list_3, ref Job);
        this.list_2.Clear();
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Options, this.list_2, this.list_3, ref Job);
      }
      if (flag1)
      {
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc1.XMovePlus <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num21 = clamperInsideCalc1.XMovePlus + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          if (Job.Moves[Job.Moves.Count - 1].XPosition - (num21 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0) >= num2)
          {
            double newX2 = clamperInsideCalc1.XMovePlus + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
            double num22 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R900=" + num22.ToString("f1"));
            this.list_2.Add("L CARPB.ISC");
            this.MoveClampers(this.NoMoveX1, newX2, refPlane, this.list_2, this.list_3, ref Job);
            double num23 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.XMovePlus;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R901=" + num23.ToString("f1"));
            this.list_2.Add("L CARPA.ISC");
            this.MoveClampers(clamperInsideCalc1.XMovePlus, this.NoMoveX2, refPlane, this.list_2, this.list_3, ref Job);
          }
          else
          {
            double num24 = clamperInsideCalc1.XMovePlusLessSafe + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
            if (Job.Moves[Job.Moves.Count - 1].XPosition - (num24 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0) >= num2 * 0.5)
            {
              double newX2 = clamperInsideCalc1.XMovePlusLessSafe + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
              double num25 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R900=" + num25.ToString("f1"));
              this.list_2.Add("L CARPB.ISC");
              this.MoveClampers(this.NoMoveX1, newX2, refPlane, this.list_2, this.list_3, ref Job);
              double num26 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.XMovePlusLessSafe;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R901=" + num26.ToString("f1"));
              this.list_2.Add("L CARPA.ISC");
              this.MoveClampers(clamperInsideCalc1.XMovePlusLessSafe, this.NoMoveX2, refPlane, this.list_2, this.list_3, ref Job);
              Job.isLesSafe = true;
            }
            else
              this.calcErrorList.Add($"{buDrillCalc.LangDrillMessage[25]} - {str}");
          }
        }
        else
        {
          double num27 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.XMovePlus;
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R901=" + num27.ToString("f1"));
          this.list_2.Add("L CARPA.ISC");
          this.MoveClampers(clamperInsideCalc1.XMovePlus, this.NoMoveX2, refPlane, this.list_2, this.list_3, ref Job);
        }
      }
      else
      {
        bool flag4 = false;
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc1.XMovePlus <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num28 = 0.0;
          double num29 = clamperInsideCalc1.XMovePlus + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          if (Job.Moves[Job.Moves.Count - 1].XPosition - (num29 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0) >= num2)
          {
            double newX2 = clamperInsideCalc1.XMovePlus + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
            double num30 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R900=" + num30.ToString("f1"));
            this.list_2.Add("L CARPB.ISC");
            this.MoveClampers(this.NoMoveX1, newX2, refPlane, this.list_2, this.list_3, ref Job);
            double num31 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.XMovePlus;
            this.list_2.Clear();
            this.list_2.Add("R910=0");
            this.list_2.Add("R901=" + num31.ToString("f1"));
            this.list_2.Add("L CARPA.ISC");
            this.MoveClampers(clamperInsideCalc1.XMovePlus, this.NoMoveX2, refPlane, this.list_2, this.list_3, ref Job);
            flag4 = true;
          }
          else
          {
            num28 = 0.0;
            double num32 = clamperInsideCalc1.XMovePlusLessSafe + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
            if (Job.Moves[Job.Moves.Count - 1].XPosition - (num32 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0) >= num2)
            {
              double newX2 = clamperInsideCalc1.XMovePlusLessSafe + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
              double num33 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R900=" + num33.ToString("f1"));
              this.list_2.Add("L CARPB.ISC");
              this.MoveClampers(this.NoMoveX1, newX2, refPlane, this.list_2, this.list_3, ref Job);
              double num34 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.XMovePlusLessSafe;
              this.list_2.Clear();
              this.list_2.Add("R910=0");
              this.list_2.Add("R901=" + num34.ToString("f1"));
              this.list_2.Add("L CARPA.ISC");
              this.MoveClampers(clamperInsideCalc1.XMovePlusLessSafe, this.NoMoveX2, refPlane, this.list_2, this.list_3, ref Job);
              flag4 = true;
              Job.isLesSafe = true;
            }
          }
        }
        else
        {
          double num35 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.XMovePlus;
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R901=" + num35.ToString("f1"));
          this.list_2.Add("L CARPA.ISC");
          this.MoveClampers(clamperInsideCalc1.XMovePlus, this.NoMoveX2, refPlane, this.list_2, this.list_3, ref Job);
          flag4 = true;
        }
        if (!flag4)
        {
          double num36 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc1.XMoveMinus;
          this.list_2.Clear();
          this.list_2.Add("R910=0");
          this.list_2.Add("R901=" + num36.ToString("f1"));
          this.list_2.Add("L CARPA.ISC");
          this.MoveClampers(clamperInsideCalc1.XMoveMinus, this.NoMoveX2, refPlane, this.list_2, this.list_3, ref Job);
        }
      }
    }
    if (Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].X1Clamper >= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0)
      return;
    this.calcErrorList.Add($"{buDrillCalc.LangDrillMessage[63 /*0x3F*/]} - {str}");
  }

  public bool isLastPositionLastZ(DrillJob Job)
  {
    return Job.Moves.Count > 0 && Job.Moves[Job.Moves.Count - 1].Z1Position == clsDrill.varDrillCNCSettings.Z1SafeDistance;
  }

  public void CreateCodeForSlotTopSide(ref DrillJob Job, ref List<DrillCalcItem> ItemSlot)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    this.list_2.Clear();
    this.list_3.Clear();
    Point3D point3D = new Point3D();
    DrillMoveOptions Options = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
    List<DrillCalcItem> drillCalcItemList1 = new List<DrillCalcItem>();
    for (int index = 0; index <= ItemSlot.Count - 1; ++index)
    {
      if (ItemSlot[index].Center.X + ItemSlot[index].Length > Job.Material.Size.Width * 1.2)
      {
        DrillCalcItem drillCalcItem = new DrillCalcItem(ItemSlot[index]);
        drillCalcItem.Center.X -= drillCalcItem.Length;
        drillCalcItemList1.Add(drillCalcItem);
      }
      else if (ItemSlot[index].Corner == CornerLocation.RightBottom | ItemSlot[index].Corner == CornerLocation.RightCenter | ItemSlot[index].Corner == CornerLocation.RightTop)
      {
        DrillCalcItem drillCalcItem = new DrillCalcItem(ItemSlot[index]);
        drillCalcItemList1.Add(drillCalcItem);
      }
      else
        drillCalcItemList1.Add(new DrillCalcItem(ItemSlot[index]));
    }
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
      clsDrill.ToolList[index].Data.Used = false;
    if (drillCalcItemList1.Count == 0)
      return;
    if (drillCalcItemList1[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth & Job.Material.Size.Width < 400.0)
    {
      buString5.MessageBoxError(buDrillCalc.LangDrillMessage[41]);
    }
    else
    {
      List<string> collection = new List<string>();
      if (drillCalcItemList1[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperSlotCatchWidth)
      {
        collection.Add("M85");
        collection.Add("M40");
        collection.Add("M6 T" + drillCalcItemList1[0].Tool.ToString());
        if (!drillCalcItemList1[0].UseMilling)
          collection.Add("M16");
        collection.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
        FindToolSettings Settings = new FindToolSettings();
        Settings.SetAsUsed = true;
        if (Settings.Y1Y2ZoneSelectionLimit < clsDrill.varDrillCNCSettings.Y1MinLimit)
          Settings.Y1Y2ZoneSelectionLimit = clsDrill.varDrillCNCSettings.Y1MinLimit;
        ToolBase5 foundTool = new ToolBase5();
        this.FindToolFromBlock(drillCalcItemList1[0], 0, Settings, ref foundTool);
        if (foundTool == null)
          return;
        double XOffset = 0.0;
        double YOffset = 0.0;
        this.GetXYToolOffsetFromNo(foundTool.Data.No, ref XOffset, ref YOffset);
        double Y1 = drillCalcItemList1[0].Center.Y + foundTool.Positions.CommonOffset.Y;
        num1 = drillCalcItemList1[0].Center.Z + clsDrill.varDrillCNCSettings.SlotSawSafeDistance;
        Options.Tool1 = foundTool.Data.No;
        double X1;
        double X1_1;
        double X2_1;
        if (Job.Material.Size.Width <= 550.0)
        {
          X1 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X - 50.0;
          double num3 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num3;
          X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num3;
        }
        else if (Job.Material.Size.Width > 550.0 & Job.Material.Size.Width <= 750.0)
        {
          X1 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X - 50.0;
          double num4 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num4;
          X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num4;
        }
        else if (Job.Material.Size.Width > 750.0 & Job.Material.Size.Width <= 1200.0)
        {
          X1 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X - 50.0;
          double num5 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num5;
          X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num5;
        }
        else
        {
          X1 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X - 50.0;
          double num6 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num6;
          X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num6;
        }
        this.AddDrillMove(this.NoMove, this.NoMove, Y1, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        int Index = -1;
        this.GetIndexFromItemID(drillCalcItemList1[0].ID, drillCalcItemList1, ref Index);
        if (Index >= 0)
          drillCalcItemList1[Index].OffsetedPoint.X = X1;
        this.AddDrillMove(X1_1, X2_1, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X1, Options, ref Job);
        double num7;
        if (Job.Material.Size.Width <= 550.0)
        {
          double newX1 = -(Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
          double num8 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          collection.Add("R910=0");
          collection.Add("R901=" + num8.ToString("f2"));
          collection.Add("L CARPA.ISC");
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          double num9 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
          collection.Add("R910=0");
          collection.Add("R900=" + num9.ToString("f2"));
          collection.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num7 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 70.0);
        }
        else if (Job.Material.Size.Width > 550.0 & clsDrill.activeJob.Material.Size.Width <= 750.0)
        {
          double newX1 = -(Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 4.0;
          double num10 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          collection.Add("R910=0");
          collection.Add("R901=" + num10.ToString("f2"));
          collection.Add("L CARPA.ISC");
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 60.0;
          double num11 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
          collection.Add("R910=0");
          collection.Add("R900=" + num11.ToString("f2"));
          collection.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num7 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 70.0);
        }
        else if (Job.Material.Size.Width > 750.0 & clsDrill.activeJob.Material.Size.Width <= 1200.0)
        {
          double newX1 = -(Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 4.0;
          double num12 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          collection.Add("R910=0");
          collection.Add("R901=" + num12.ToString("f2"));
          collection.Add("L CARPA.ISC");
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 150.0;
          double num13 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
          collection.Add("R910=0");
          collection.Add("R900=" + num13.ToString("f2"));
          collection.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num7 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
        }
        else if (Job.Material.Size.Width > 1200.0 & clsDrill.activeJob.Material.Size.Width <= 1500.0)
        {
          double newX1 = -(Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
          double num14 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          collection.Add("R910=0");
          collection.Add("R901=" + num14.ToString("f2"));
          collection.Add("L CARPA.ISC");
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 400.0;
          num14 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
          collection.Add("R910=0");
          collection.Add("R900=" + num14.ToString("f2"));
          collection.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num7 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
        }
        else if (Job.Material.Size.Width > 1500.0 & clsDrill.activeJob.Material.Size.Width <= 2000.0)
        {
          double newX1 = -(Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
          double num15 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          collection.Add("R910=0");
          collection.Add("R901=" + num15.ToString("f2"));
          collection.Add("L CARPA.ISC");
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 600.0;
          num15 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
          collection.Add("R910=0");
          collection.Add("R900=" + num15.ToString("f2"));
          collection.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num7 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
        }
        else
        {
          double newX1 = -(2000.0 - Job.Moves[Job.Moves.Count - 1].XPosition);
          double num16 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
          collection.Add("R910=0");
          collection.Add("R901=" + num16.ToString("f2"));
          collection.Add("L CARPA.ISC");
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 800.0;
          double num17 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
          collection.Add("R910=0");
          collection.Add("R900=" + num17.ToString("f2"));
          collection.Add("L CARPB.ISC");
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num7 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
        }
        collection.Add($"G0 X{drillCalcItemList1[0].Center.X.ToString("f2")} Y{drillCalcItemList1[0].Center.Y.ToString("f2")}");
        collection.Add("M" + drillCalcItemList1[0].Tool.ToString());
        collection.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
        collection.Add($"G1 Z{(Job.Material.Size.Depth - drillCalcItemList1[0].Depth).ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}");
        num1 = drillCalcItemList1.Count < 2 ? this.NoMove : drillCalcItemList1[1].Center.Z + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, clsDrill.activeJob.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance, DrillMoveCommand.AxisMove, X1, Options, ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, Options, ref Job);
        num1 = drillCalcItemList1.Count < 2 ? this.NoMove : drillCalcItemList1[1].Center.Z - drillCalcItemList1[1].Depth;
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, drillCalcItemList1[0].Center.Z - drillCalcItemList1[0].Depth, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
        double X2 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + num7;
        if (Job.Material.Size.Width <= 550.0)
          X2 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + num7 - 5.0;
        else if (Job.Material.Size.Width > 550.0 & clsDrill.activeJob.Material.Size.Width <= 750.0)
          X2 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + num7 - 20.0;
        double num18 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num18, Job.Moves[Job.Moves.Count - 1].X2Clamper + num18, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
        collection.Add($"G1 X{X2.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}");
        collection.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
        collection.Add("M85");
        double num19 = num7 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.3 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
        num19 = XOffset + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
        double newX2_1 = Job.Material.Size.Width > 550.0 ? (!(Job.Material.Size.Width > 550.0 & clsDrill.activeJob.Material.Size.Width <= 750.0) ? (!(Job.Material.Size.Width > 750.0 & clsDrill.activeJob.Material.Size.Width <= 1200.0) ? X2 - clsDrill.varDrillCNCSettings.ClamperLength : X2 - clsDrill.varDrillCNCSettings.ClamperLength / 4.0) : X2 + clsDrill.varDrillCNCSettings.ClamperLength * 0.15) : X2 + clsDrill.varDrillCNCSettings.ClamperLength * 0.2;
        double num20 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2_1;
        collection.Add("R910=0");
        collection.Add("R900=" + num20.ToString("f2"));
        collection.Add("L CARPB.ISC");
        collection.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
        collection.Add($"G1 Z{(Job.Material.Size.Depth - drillCalcItemList1[0].Depth).ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}");
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetAll, this.NoMove, Options, ref Job);
        this.MoveClampers(this.NoMove, newX2_1, drillPlaneNames.Top, ref Job);
        double num21 = num7 + (foundTool.Positions.CommonOffset.X - (Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0)) - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance * 2.0;
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool.Data.No), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, drillCalcItemList1[0].Center.Z - drillCalcItemList1[0].Depth, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool.Data.No), ref Job);
        X2 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + num21;
        if (Job.Material.Size.Width <= 550.0)
          X2 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + num21 + 30.0;
        else if (Job.Material.Size.Width > 550.0 & clsDrill.activeJob.Material.Size.Width <= 750.0)
          X2 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + num21 + 5.0;
        double num22 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
        double X1_2 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num22;
        double X2_2 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num22;
        collection.Add($"G1 X{X2.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
        collection.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
        collection.Add("M85");
        this.AddDrillMove(X1_2, X2_2, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool.Data.No), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool.Data.No), ref Job);
        double num23 = Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength * 2.0;
        num23 = XOffset + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
        double newX1_1 = Job.Material.Size.Width > 550.0 ? (!(Job.Material.Size.Width > 550.0 & Job.Material.Size.Width <= 750.0) ? (!(Job.Material.Size.Width > 750.0 & Job.Material.Size.Width <= 1200.0) ? (!(Job.Material.Size.Width > 1200.0 & Job.Material.Size.Width <= 1500.0) ? (!(Job.Material.Size.Width > 1500.0 & Job.Material.Size.Width <= 2000.0) ? Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 1000.0 : Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 800.0) : Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 500.0) : Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 140.0) : Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 70.0) : Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength;
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1_1 < clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength)
          newX1_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
        num20 = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1_1;
        collection.Add("R910=0");
        collection.Add("R901=" + num20.ToString("f2"));
        collection.Add("L CARPA.ISC");
        collection.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
        collection.Add($"G1 Z{(Job.Material.Size.Depth - drillCalcItemList1[0].Depth).ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}");
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetAll, this.NoMove, Options, ref Job);
        this.MoveClampers(newX1_1, this.NoMove, drillPlaneNames.Top, ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool.Data.No), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, drillCalcItemList1[0].Center.Z - drillCalcItemList1[0].Depth, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool.Data.No), ref Job);
        X2 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + drillCalcItemList1[0].Length + foundTool.Geometry.Diameter / 4.0;
        double num24 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
        double X1_3 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num24;
        double X2_3 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num24;
        if (X2_3 > clsDrill.varDrillMachineSettings.MachineMaxXStroke)
        {
          double num25 = X2_3 - clsDrill.varDrillMachineSettings.MachineMaxXStroke;
          double X1_4 = X1_3 - num25;
          double X2_4 = X2_3 - num25;
          double X3 = X2 - num25;
          collection.Add($"G1 X{X3.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
          this.AddDrillMove(X1_4, X2_4, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X3, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool.Data.No), ref Job);
          this.AddDrillMove(X1_4 - num25, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, X2_4 - num25, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool.Data.No), ref Job);
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num25, Job.Moves[Job.Moves.Count - 1].X2Clamper + num25, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool.Data.No), ref Job);
          num20 = Job.Moves[Job.Moves.Count - 1].X1Clamper - (X1_4 - num25);
          collection.Add("R910=0");
          collection.Add("R901=" + num20.ToString("f2"));
          collection.Add("L CARPA.ISC");
          collection.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
          num20 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (X2_4 - num25);
          collection.Add("R910=0");
          collection.Add("R900=" + num20.ToString("f2"));
          collection.Add("L CARPB.ISC");
          List<string> stringList1 = collection;
          double num26 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
          string str1 = "G0 Z" + num26.ToString("f2");
          stringList1.Add(str1);
          List<string> stringList2 = collection;
          num26 = Job.Material.Size.Depth - drillCalcItemList1[0].Depth;
          string str2 = $"G1 Z{num26.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}";
          stringList2.Add(str2);
          collection.Add($"G1 X{X2.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
        }
        else
        {
          this.AddDrillMove(X1_3, X2_3, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool.Data.No), ref Job);
          collection.Add($"G1 X{X2.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
        }
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.SlotSawSafeDistance, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool.Data.No), ref Job);
        collection.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
        collection.Add("M85");
        DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCodeList, Job.Moves[Job.Moves.Count - 1].XPosition);
        drillMove.pntCenter = new Point3D();
        drillMove.CodeLines = new List<string>();
        drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
        Job.Moves.Add(drillMove);
      }
      else
      {
        List<DrillCalcItem> Items = this.SortByYDistance(drillCalcItemList1, new DrillCalcItem(), SortDirection.LowerToBigger);
        List<DrillCalcItem> drillCalcItemList2 = new List<DrillCalcItem>();
        for (int index = 0; index <= Items.Count - 1; ++index)
          drillCalcItemList2.Add(new DrillCalcItem(Items[index]));
        int count = drillCalcItemList2.Count;
        for (int index1 = 0; index1 <= count - 1; ++index1)
        {
          bool flag = true;
          double num27 = 0.0;
          FindToolSettings Settings = new FindToolSettings();
          Settings.Plane = planeBoxNames.Top;
          Settings.SetAsUsed = true;
          for (int index2 = 0; index2 <= clsDrill.ToolList.Count - 1; ++index2)
            clsDrill.ToolList[index2].Data.Used = false;
          int t1 = 0;
          int t2 = 0;
          ToolBase5 foundTool = (ToolBase5) null;
          double Y1 = this.NoMove;
          double num28 = this.NoMove;
          if (index1 <= drillCalcItemList2.Count - 1 & drillCalcItemList2.Count > 0)
          {
            if (!drillCalcItemList2[index1].Calculated & !drillCalcItemList2[index1].UseMilling)
            {
              this.FindToolFromBlock(drillCalcItemList2[index1], 0, Settings, ref foundTool);
              if (foundTool != null)
              {
                Y1 = drillCalcItemList2[index1].Center.Y + foundTool.Positions.CommonOffset.Y;
                num28 = drillCalcItemList2[index1].Center.Z;
                double x1 = drillCalcItemList2[index1].Center.X;
                double x2 = drillCalcItemList2[index1].Center.X;
                num27 = drillCalcItemList2[index1].Depth;
                drillCalcItemList2[index1].Calculated = true;
                t1 = foundTool.Data.No;
              }
            }
            else if (drillCalcItemList2[index1].UseMilling)
            {
              Y1 = drillCalcItemList2[index1].Center.Y;
              num28 = drillCalcItemList2[index1].Center.Z;
              double x3 = drillCalcItemList2[index1].Center.X;
              double x4 = drillCalcItemList2[index1].Center.X;
              num27 = drillCalcItemList2[index1].Depth;
              drillCalcItemList2[index1].Calculated = true;
              for (int index3 = 0; index3 <= ccVars.Tools[0].Tools.Count - 1; ++index3)
              {
                if (ccVars.Tools[0].Tools[index3].Data.No == drillCalcItemList2[index1].Tool)
                  foundTool = new ToolBase5(ccVars.Tools[0].Tools[index3]);
              }
              t1 = drillCalcItemList2[index1].Tool;
            }
            else
              flag = false;
          }
          else
            flag = false;
          if (num28 == this.NoMove & num28 != num2)
            num28 = clsDrill.varDrillCNCSettings.SlotSawSafeDistance;
          if (num28 == num2)
            num28 = this.NoMove;
          if (foundTool == null)
            return;
          if (flag)
          {
            double XOffset = 0.0;
            double YOffset = 0.0;
            if (foundTool != null)
            {
              ToolBase5 toolBase5 = new ToolBase5(foundTool);
              if (!Items[0].UseMilling)
              {
                this.GetXYToolOffsetFromNo(foundTool.Data.No, ref XOffset, ref YOffset);
              }
              else
              {
                XOffset = foundTool.Positions.CommonOffset.X;
                YOffset = foundTool.Positions.CommonOffset.Y;
              }
            }
            point3D.X = Items[0].Center.X;
            point3D.Y = Items[0].Center.Y;
            point3D.Z = Job.Material.Size.Depth - Items[0].Depth;
            Options.Tool1 = foundTool.Data.No;
            Options.Mode = DrillCNCMode.ToolOffset;
            if (!Items[0].UseMilling)
              buString5.AddStringsToList("M85", ref this.list_2, S2: "M40", S3: "M6 T" + foundTool.Data.No.ToString(), S4: "M16", S5: "G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
            else
              buString5.AddStringsToList("M85", ref this.list_2, S2: "M40", S3: "M6 T" + foundTool.Data.No.ToString(), S4: "$M39", S5: "M3 S" + foundTool.CamData.SpindleSpeed.ToString(), S6: "M149", S7: "G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
            Options.Mode = DrillCNCMode.Safe;
            Options.EnableAxes = new AxesEnable(false, false, true);
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawSafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, this.list_2, this.list_3, ref Job);
            double num29 = 0.0;
            double X4 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + Items[0].Center.X;
            if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
              X4 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + Items[0].Center.X + Items[0].Length;
            double num30 = X4 - Job.Moves[Job.Moves.Count - 1].XPosition;
            double num31 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num30;
            double num32 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num30;
            double num33;
            if (num31 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
            {
              this.list_2.Clear();
              this.list_2.Add("G0 Y" + Items[0].Center.Y.ToString("f2"));
              this.AddDrillMove(this.NoMove, this.NoMove, Y1, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, t1, t2), this.list_2, this.list_3, ref Job);
              double num34 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillMachineSettings.MachineMinXStroke;
              double X5 = X4 + Math.Abs(num30) - num34;
              double num35 = num30 + num34;
              this.list_2.Clear();
              List<string> list2 = this.list_2;
              num33 = Math.Abs(num35);
              string str = "G0 X" + num33.ToString("f2");
              list2.Add(str);
              if (Items[0].UseMilling)
                this.list_2.Add("M1091");
              this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num34, Job.Moves[Job.Moves.Count - 1].X2Clamper - num34, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X5, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), this.list_2, this.list_3, ref Job);
              double num36 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num35;
              double num37 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num35;
              double num38 = num36 - clsDrill.varDrillMachineSettings.MachineMinXStroke;
              double num39 = num36 - num38;
              double num40 = num37 - num38;
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              num29 = -(num40 - num38 - Job.Moves[Job.Moves.Count - 1].X2Clamper);
              buString5.AddStringsToList("R910=0", ref this.list_2, S2: "R900=" + num29.ToString("f2"), S3: "L CARPB.ISC");
              this.AddDrillMove(this.NoMove, num40 - num38, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), this.list_2, this.list_3, ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              num29 = -(num39 - num38 - Job.Moves[Job.Moves.Count - 1].X1Clamper);
              ref List<string> local = ref this.list_2;
              string S2 = "R901=" + num29.ToString("f2");
              num33 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
              string S4 = "G0 Z" + num33.ToString("f2");
              buString5.AddStringsToList("R910=0", ref local, S2: S2, S3: "L CARPA.ISC", S4: S4);
              this.AddDrillMove(num39 - num38, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), this.list_2, this.list_3, ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.list_2.Clear();
              this.list_2.Add($"G0 X{Items[0].Center.X.ToString("f2")} Y{Items[0].Center.Y.ToString("f2")}");
              this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num35, Job.Moves[Job.Moves.Count - 1].X2Clamper + num35, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X4, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), this.list_2, this.list_3, ref Job);
            }
            else
            {
              this.list_2.Clear();
              if (!clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
              {
                this.list_2.Add($"G0 X{Items[0].Center.X.ToString("f2")} Y{Items[0].Center.Y.ToString("f2")}");
                if (Items[0].UseMilling)
                  this.list_2.Add("M1091");
              }
              else
              {
                List<string> list2 = this.list_2;
                num33 = Items[0].Center.X + Items[0].Length;
                string str = $"G0 X{num33.ToString("f2")} Y{Items[0].Center.Y.ToString("f2")}";
                list2.Add(str);
                if (Items[0].UseMilling)
                  this.list_2.Add("M1091");
              }
              Options.Mode = DrillCNCMode.Safe;
              Options.EnableAxes = new AxesEnable(true, true, false);
              this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num30, Job.Moves[Job.Moves.Count - 1].X2Clamper + num30, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X4, Options, this.list_2, this.list_3, ref Job);
            }
            double num41 = this.NoMove;
            if (flag & num28 != this.NoMove)
              num41 = num28 + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
            Options.Mode = DrillCNCMode.ToolSet;
            if (!Items[0].UseMilling)
            {
              buString5.AddStringsToList("M" + foundTool.Data.No.ToString(), ref this.list_2);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, Options, this.list_2, this.list_3, ref Job);
            }
            num33 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
            buString5.AddStringsToList("G0 Z" + num33.ToString("f2"), ref this.list_2);
            Options.Mode = DrillCNCMode.Safe;
            Options.EnableAxes = new AxesEnable(false, false, true);
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawRapidDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, this.list_2, this.list_3, ref Job);
            num33 = Job.Material.Size.Depth - Items[0].Depth;
            buString5.AddStringsToList($"G1 Z{num33.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}", ref this.list_2);
            Options.Mode = DrillCNCMode.Safe;
            Options.EnableAxes = new AxesEnable(false, false, true);
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, point3D.Z, DrillMoveCommand.AxisMove, this.NoMove, Options, this.list_2, this.list_3, ref Job);
            if (flag)
            {
              int Index = -1;
              this.GetIndexFromItemID(drillCalcItemList2[index1].ID, Items, ref Index);
              if (Index >= 0)
                Items[Index].OffsetedPoint.X = X4;
            }
            num41 = this.NoMove;
            if (flag & num28 != this.NoMove)
              num41 = num28 - num27;
            double X6 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + Items[0].Center.X + Items[0].Length;
            if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
              X6 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + Items[0].Center.X;
            double num42 = X6 - Job.Moves[Job.Moves.Count - 1].XPosition;
            double X1_5 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num42;
            double X2_5 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num42;
            double num43 = clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + XOffset;
            if (X2_5 > clsDrill.varDrillMachineSettings.MachineMaxXStroke - clsDrill.varDrillMachineSettings.MillingHolderOffset)
            {
              double num44 = X2_5 - clsDrill.varDrillMachineSettings.MachineMaxXStroke + clsDrill.varDrillMachineSettings.MillingHolderOffset;
              double X1_6 = X1_5 - num44;
              double X2_6 = X2_5 - num44;
              double X7 = X6 - num44;
              num33 = X7 - num43;
              buString5.AddStringsToList($"G1 X{num33.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}", ref this.list_2);
              this.AddDrillMove(X1_6, X2_6, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X7, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), this.list_2, this.list_3, ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              num29 = Job.Moves[Job.Moves.Count - 1].X1Clamper - (X1_6 - num44);
              buString5.AddStringsToList("R910=0", ref this.list_2, S2: "R901=" + num29.ToString("f2"), S3: "L CARPA.ISC");
              this.AddDrillMove(X1_6 - num44, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), this.list_2, this.list_3, ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              num29 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (X2_6 - num44);
              buString5.AddStringsToList("R910=0", ref this.list_2, S2: "R900=" + num29.ToString("f2"), S3: "L CARPB.ISC");
              this.AddDrillMove(this.NoMove, X2_6 - num44, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), this.list_2, this.list_3, ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.list_2.Clear();
              List<string> list2_1 = this.list_2;
              num33 = Job.Material.Size.Depth - Items[0].Depth;
              string str3 = $"G1 Z{num33.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}";
              list2_1.Add(str3);
              List<string> list2_2 = this.list_2;
              num33 = X6 - num43;
              string str4 = $"G1 X{num33.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}";
              list2_2.Add(str4);
              this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num44, Job.Moves[Job.Moves.Count - 1].X2Clamper + num44, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X6, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), this.list_2, this.list_3, ref Job);
            }
            else
            {
              Options.Mode = DrillCNCMode.Plunge;
              Options.EnableAxes = new AxesEnable(true, false, false);
              Options.isG0 = false;
              Options.Feed = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
              this.list_2.Clear();
              if (!clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
              {
                List<string> list2 = this.list_2;
                string[] strArray = new string[6];
                strArray[0] = "G1 X";
                num33 = Items[0].Center.X + Items[0].Length;
                strArray[1] = num33.ToString("f2");
                strArray[2] = " Y";
                strArray[3] = Items[0].Center.Y.ToString("f2");
                strArray[4] = " F";
                strArray[5] = clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString();
                string str = string.Concat(strArray);
                list2.Add(str);
              }
              else
                this.list_2.Add($"G1 X{Items[0].Center.X.ToString("f2")} Y{Items[0].Center.Y.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
              this.AddDrillMove(X1_5, X2_5, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X6, Options, this.list_2, this.list_3, ref Job);
            }
            double num45 = this.NoMove;
            if (flag & num28 != this.NoMove)
              num45 = num28 + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
            Options.Mode = DrillCNCMode.Safe;
            Options.isG0 = true;
            Options.EnableAxes = new AxesEnable(false, false, true);
            buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"), ref this.list_2);
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawSafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, this.list_2, this.list_3, ref Job);
            num28 = num45;
            buString5.AddStringsToList("M1090", ref this.list_2);
            Options.Mode = DrillCNCMode.ToolReset;
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Options, this.list_2, this.list_3, ref Job);
          }
          num2 = num28;
        }
        DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCodeList, Job.Moves[Job.Moves.Count - 1].XPosition);
        drillMove.pntCenter = new Point3D();
        drillMove.CodeLines = new List<string>();
        drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
        if (collection.Count <= 0)
          return;
        Job.Moves.Add(drillMove);
      }
    }
  }

  public void CreateCodeForSlotTopSideByMilling(ref DrillJob Job, ref List<DrillItem> ItemSlot)
  {
    double Y1 = 0.0;
    Point3D point3D = new Point3D();
    DrillMoveOptions Options = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    for (int index = 0; index <= ItemSlot.Count - 1; ++index)
    {
      DrillCalcItem drillCalcItem = new DrillCalcItem(ItemSlot[index]);
      drillCalcItemList.Add(drillCalcItem);
    }
    if (drillCalcItemList.Count == 0)
      return;
    if (drillCalcItemList[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth & Job.Material.Size.Width < 400.0)
    {
      buString5.MessageBoxError(buDrillCalc.LangDrillMessage[41]);
    }
    else
    {
      List<string> collection = new List<string>();
      if (drillCalcItemList[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperSlotCatchWidth)
        return;
      for (int index = 0; index <= ItemSlot.Count - 1; ++index)
      {
        collection.Add("M85");
        collection.Add("M40");
        collection.Add("M6 T" + ItemSlot[index].ToolMilling.Data.No.ToString());
        collection.Add("$M39");
        collection.Add($"S{ItemSlot[index].ToolMilling.CamData.SpindleSpeed.ToString()} M3");
        collection.Add("M149");
        collection.Add($"G0 X{ItemSlot[index].Center.X.ToString("f2")} Y{ItemSlot[index].Center.Y.ToString("f2")} Z{clsDrill.varDrillCNCSettings.distanceSafe.ToString("f2")}");
        collection.Add("M1091");
        if (!clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
          collection.Add($"G0 X{drillCalcItemList[0].Center.X.ToString("f2")} Y{drillCalcItemList[0].Center.Y.ToString("f2")}");
        else
          collection.Add($"G0 X{(drillCalcItemList[0].Center.X + drillCalcItemList[0].Length).ToString("f2")} Y{drillCalcItemList[0].Center.Y.ToString("f2")}");
        double num1 = 0.0;
        point3D.X = drillCalcItemList[0].Center.X;
        point3D.Y = drillCalcItemList[0].Center.Y;
        point3D.Z = Job.Material.Size.Depth - drillCalcItemList[0].Depth;
        Options.Tool1 = ItemSlot[index].ToolMilling.Data.No;
        Options.Mode = DrillCNCMode.Safe;
        Options.EnableAxes = new AxesEnable(false, false, true);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.distanceSafe, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        double X1 = num1 + drillCalcItemList[0].Center.X;
        double num2 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
        double num3 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num2;
        double num4 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num2;
        if (num3 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
        {
          this.AddDrillMove(this.NoMove, this.NoMove, Y1, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, 0, 0), ref Job);
          double num5 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillMachineSettings.MachineMinXStroke;
          double X2 = X1 + Math.Abs(num2) - num5;
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num5, Job.Moves[Job.Moves.Count - 1].X2Clamper - num5, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
          double num6 = num2 + num5;
          double num7 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num6;
          double num8 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num6;
          double num9 = num7 - clsDrill.varDrillMachineSettings.MachineMinXStroke;
          double num10 = num7 - num9;
          double num11 = num8 - num9;
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(this.NoMove, num11 - num9, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(num10 - num9, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num6, Job.Moves[Job.Moves.Count - 1].X2Clamper + num6, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
        }
        else
        {
          Options.Mode = DrillCNCMode.Safe;
          Options.EnableAxes = new AxesEnable(true, true, false);
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, Y1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X1, Options, ref Job);
        }
        collection.Add("M95");
        collection.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
        collection.Add($"G1 Z{(Job.Material.Size.Depth - drillCalcItemList[0].Depth).ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}");
        Options.Mode = DrillCNCMode.ToolSet;
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, Options, ref Job);
        Options.Mode = DrillCNCMode.Safe;
        Options.EnableAxes = new AxesEnable(false, false, true);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawRapidDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        Options.Mode = DrillCNCMode.Safe;
        Options.EnableAxes = new AxesEnable(false, false, true);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, point3D.Z, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        double X3 = num1 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList[0].Center.X + drillCalcItemList[0].Length;
        if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
          X3 = num1 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList[0].Center.X;
        double num12 = X3 - Job.Moves[Job.Moves.Count - 1].XPosition;
        double X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num12;
        double X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num12;
        double num13 = clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + num1;
        if (X2_1 > clsDrill.varDrillMachineSettings.MachineMaxXStroke - clsDrill.varDrillMachineSettings.MillingHolderOffset)
        {
          double num14 = X2_1 - clsDrill.varDrillMachineSettings.MachineMaxXStroke + clsDrill.varDrillMachineSettings.MillingHolderOffset;
          double X1_2 = X1_1 - num14;
          double X2_2 = X2_1 - num14;
          double X4 = X3 - num14;
          collection.Add($"G1 X{(X4 - num13).ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
          this.AddDrillMove(X1_2, X2_2, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X4, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(X1_2 - num14, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(this.NoMove, X2_2 - num14, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num14, Job.Moves[Job.Moves.Count - 1].X2Clamper + num14, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X3, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
          double num15 = Job.Moves[Job.Moves.Count - 1].X1Clamper - (X1_2 - num14);
          collection.Add("R910=0");
          collection.Add("R901=" + num15.ToString("f2"));
          collection.Add("L CARPA.ISC");
          collection.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
          double num16 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (X2_2 - num14);
          collection.Add("R910=0");
          collection.Add("R900=" + num16.ToString("f2"));
          collection.Add("L CARPB.ISC");
          collection.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
          collection.Add($"G1 Z{(Job.Material.Size.Depth - drillCalcItemList[0].Depth).ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed.ToString()}");
          collection.Add($"G1 X{(X3 - num13).ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
        }
        else
        {
          Options.Mode = DrillCNCMode.Plunge;
          Options.EnableAxes = new AxesEnable(true, false, false);
          Options.isG0 = false;
          Options.Feed = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
          this.AddDrillMove(X1_1, X2_1, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, X3, Options, ref Job);
          if (!clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
            collection.Add($"G1 X{(drillCalcItemList[0].Center.X + drillCalcItemList[0].Length).ToString("f2")} Y{drillCalcItemList[0].Center.Y.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
          else
            collection.Add($"G1 X{drillCalcItemList[0].Center.X.ToString("f2")} Y{drillCalcItemList[0].Center.Y.ToString("f2")} F{clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed.ToString()}");
        }
        collection.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
        collection.Add("M1090");
        collection.Add("M85");
        Options.Mode = DrillCNCMode.Safe;
        Options.isG0 = true;
        Options.EnableAxes = new AxesEnable(false, false, true);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawSafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        Options.Mode = DrillCNCMode.ToolReset;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.ResetAll, this.NoMove, Options, ref Job);
        DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCodeList, Job.Moves[Job.Moves.Count - 1].XPosition);
        drillMove.pntCenter = new Point3D();
        drillMove.CodeLines = new List<string>();
        drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
        Job.Moves.Add(drillMove);
      }
    }
  }

  public void CreateCodeForSlotTopSide(
    ref List<DrillItem> ItemShape,
    bool isTop,
    ToolBase5 toolFound,
    ref DrillJob Job)
  {
    double Y1 = 0.0;
    double Y2 = 0.0;
    double Y3 = 0.0;
    double Z1 = 0.0;
    double Z2 = 0.0;
    double Z3 = 0.0;
    double X1_1 = 0.0;
    double X2_1 = 0.0;
    double XPos1 = 0.0;
    ToolBase5 toolBase5_1 = new ToolBase5();
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<Entity> entityList3 = new List<Entity>();
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    clsMW.CamEntities.Clear();
    MWCalculationOptions MWCalcoptions = new MWCalculationOptions();
    MWCalcoptions.NumberofAxis = 3;
    MWCalcoptions.Mode = CamMode.WireFrame;
    MWCalcoptions.DontApplyReset = true;
    MWCalcoptions.isBuWireframeCalculation = false;
    MWCalcoptions.AddToCamListInMWCalculation = false;
    MWCalcoptions.DontShowDialogBox = true;
    MWCalcoptions.isBuSort = false;
    MWCalcoptions.UseStartPoint = false;
    MWCalcoptions.UseConstantStartPoint = false;
    MWCalcoptions.StartPointX = 0.0;
    MWCalcoptions.StartPointY = 0.0;
    MWCalcoptions.ShowProgressForm = false;
    camTp camTp1 = new camTp();
    camTp camTp2 = new camTp();
    camTp camTp3 = new camTp();
    camTp camTp4 = new camTp();
    camTp camTp5 = new camTp();
    camTp camTp6 = new camTp();
    this.ShapeCamParameterSet(Job, toolFound);
    for (int index1 = 0; index1 <= ItemShape.Count - 1; ++index1)
    {
      double depth = ItemShape[index1].ShapeData.Depth;
      buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
      buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
      buMWDrillVars.varCamContour.buPar.Distances.RapidRetract = true;
      List<List<buEntity>> copiedEntities = new List<List<buEntity>>();
      if (ItemShape[index1].camEntities.Count > 0)
        buEntity.Copy(ItemShape[index1].camEntities, ref copiedEntities);
      else
        buEntity.Copy(ItemShape[index1].shapeEntitites, ref copiedEntities);
      if (!ItemShape[index1].isDrill)
      {
        for (int index2 = 0; index2 <= copiedEntities.Count - 1; ++index2)
        {
          List<Entity> entityList4 = new List<Entity>();
          for (int index3 = 0; index3 <= copiedEntities[index2].Count - 1; ++index3)
          {
            buEntity refEntity = buEntity.Copy(copiedEntities[index2][index3]);
            Mirror T1 = new Mirror(new Plane(new Point3D(), Vector3D.AxisX, Vector3D.AxisZ));
            refEntity.TransformBy((Transformation) T1);
            Mirror T2 = new Mirror(new Plane(new Point3D(), Vector3D.AxisY, Vector3D.AxisZ));
            refEntity.TransformBy((Transformation) T2);
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(refEntity, ref copiedEntity);
            entityList4.Add(copiedEntity);
          }
          buMWDrillVars.varCamContour.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
          buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
          ccVars.toolActive.CamData.SpindleSpeed = clsDrill.varDrillCNCSettings.TopSpindleSpeed;
          buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
          buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - depth;
          buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
          buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - depth;
          if (ItemShape[index1].FeedCut > 0.0)
            buMWDrillVars.varCamContour.buPar.Speeds.Feed = ItemShape[index1].FeedCut;
          if (ItemShape[index1].FeedPlunge > 0.0)
            buMWDrillVars.varCamContour.buPar.Speeds.Plunge = ItemShape[index1].FeedPlunge;
          if (ItemShape[index1].SpindleSpeed > 0.0)
            ccVars.toolActive.CamData.SpindleSpeed = ItemShape[index1].SpindleSpeed;
          if (ItemShape[index1].StepEnable)
          {
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
            buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
            buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth;
            buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
            buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
            buMWDrillVars.varCamRough.buPar.Steps.StartValue = Job.Material.Size.Depth;
            buMWDrillVars.varCamRough.buPar.Steps.EndValue = Job.Material.Size.Depth - depth;
          }
          else
          {
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
            buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
            buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
            buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
            buMWDrillVars.varCamRough.buPar.Steps.StartValue = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.buPar.Steps.EndValue = Job.Material.Size.Depth - depth;
          }
          if (entityList4.Count > 0)
          {
            clsMW.CamEntities.Clear();
            for (int index4 = 0; index4 <= entityList4.Count - 1; ++index4)
            {
              Entity copiedEnt = (Entity) null;
              buVector5.CopyEntities(entityList4[index4], ref copiedEnt);
              clsMW.CamEntities.Add(copiedEnt);
            }
            MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
            camTp Cam = new camTp();
            ToolBase5 toolBase5_2 = new ToolBase5(toolFound);
            if (ItemShape[index1].ToolMilling != null)
              toolBase5_2 = new ToolBase5(ItemShape[index1].ToolMilling);
            this.doWireframeContour(MWCalcoptions, toolBase5_2, ref Cam);
            camTp6.EntitiesG1.AddRange((IEnumerable<Entity>) Cam.EntitiesG1);
            Cam.Tool = new ToolBase5(toolBase5_2);
            bool flag = false;
            if (ItemShape[index1].X1First)
            {
              Cam.Aux1First = ItemShape[index1].X1First;
              if (ItemShape[index1].X1Move != 0.0 & Cam.CamPoints.Count > 0)
              {
                Cam.Aux1 = ItemShape[index1].X1Move;
                Cam.CamPoints[0].PreCodes.Add((object) "M85");
                Cam.CamPoints[0].PreCodes.Add((object) "R910=0");
                Cam.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                Cam.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                flag = true;
              }
              if (ItemShape[index1].X2Move != 0.0 & Cam.CamPoints.Count > 0)
              {
                Cam.Aux2 = ItemShape[index1].X2Move;
                Cam.CamPoints[0].PreCodes.Add((object) "M85");
                Cam.CamPoints[0].PreCodes.Add((object) "R910=0");
                Cam.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                Cam.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                flag = true;
              }
            }
            else
            {
              Cam.Aux1First = ItemShape[index1].X1First;
              if (ItemShape[index1].X2Move != 0.0)
              {
                Cam.Aux2 = ItemShape[index1].X2Move;
                Cam.CamPoints[0].PreCodes.Add((object) "M85");
                Cam.CamPoints[0].PreCodes.Add((object) "R910=0");
                Cam.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                Cam.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                flag = true;
              }
              if (ItemShape[index1].X1Move != 0.0)
              {
                Cam.Aux1 = ItemShape[index1].X1Move;
                Cam.CamPoints[0].PreCodes.Add((object) "M85");
                Cam.CamPoints[0].PreCodes.Add((object) "R910=0");
                Cam.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                Cam.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                flag = true;
              }
            }
            if (!flag || ItemShape[index1].planeName == planeBoxNames.Top)
              ;
            if (Cam.CamPoints.Count > 0)
            {
              camTp6.Tool = new ToolBase5(Cam.Tool);
              for (int index5 = 0; index5 <= Cam.CamPoints.Count - 1; ++index5)
                camTp6.CamPoints.Add(new camTpPoint(Cam.CamPoints[index5])
                {
                  ToolCam = new ToolBase5(Cam.Tool)
                });
              camTp6.PlaneName = !isTop ? planeNames.Bottom : planeNames.Top;
            }
            if (Cam.SimilationPoint.SimMove.Count > 0)
            {
              if (camTp6.SimilationPoint.SimMove.Count > 0)
              {
                List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
                clsInit.cVector5.LineerInterpolation(camTp6.SimilationPoint.SimMove[camTp6.SimilationPoint.SimMove.Count - 1], Cam.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints);
                if (CalculatedPoints.Count >= 3)
                {
                  CalculatedPoints.RemoveAt(0);
                  CalculatedPoints.RemoveAt(CalculatedPoints.Count - 1);
                  for (int index6 = 0; index6 <= CalculatedPoints.Count - 1; ++index6)
                  {
                    CalculatedPoints[index6].ToolNo = (double) ItemShape[index1].ToolMilling.Data.No;
                    camTp6.SimilationPoint.SimMove.Add(CalculatedPoints[index6]);
                  }
                }
              }
              if (Cam.Aux1 != 0.0 & Cam.Aux2 != 0.0)
              {
                if (Cam.Aux1First)
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
                  camTp6.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam.Aux1
                  });
                  camTp6.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam.Aux2
                  });
                }
                else
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
                  camTp6.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam.Aux2
                  });
                  camTp6.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam.Aux1
                  });
                }
              }
              else if (Cam.Aux1 != 0.0 & Cam.Aux2 == 0.0)
                camTp6.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1])
                {
                  Aux1 = Cam.Aux1
                });
              else if (Cam.Aux1 == 0.0 & Cam.Aux2 != 0.0)
                camTp6.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1])
                {
                  Aux2 = Cam.Aux2
                });
              for (int index7 = 0; index7 <= Cam.SimilationPoint.SimMove.Count - 1; ++index7)
                camTp6.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam.SimilationPoint.SimMove[index7])
                {
                  ToolNo = (double) ItemShape[index1].ToolMilling.Data.No
                });
            }
          }
        }
      }
    }
    if (clsItem.FrmProgress != null)
      clsItem.FrmProgress.Visible = false;
    List<DrillMove> drillMoveList = new List<DrillMove>();
    if (!isTop)
      return;
    double XPos2 = 0.0;
    double X1_2 = 0.0;
    double X2_2 = 0.0;
    DrillMove drillMove1 = new DrillMove();
    if (Job.SimulationMoves.Count > 0 & camTp6.SimilationPoint.SimMove.Count > 0)
    {
      XPos2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].XPosition;
      X1_2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
      X2_2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
      X1_1 = X1_2;
      X2_1 = X2_2;
      Y1 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y1Position;
      Y2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y2Position;
      Y3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y3Position;
      Z1 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z1Position;
      Z2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z2Position;
      Z3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z3Position;
      DrillMove drillMove2 = new DrillMove(X1_2, X2_2, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.SetPiston, XPos2, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[0].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
      Job.SimulationMoves.Add(drillMove2);
    }
    double num1 = 0.0;
    double num2 = 0.0;
    for (int index8 = 0; index8 <= camTp6.SimilationPoint.SimMove.Count - 1; ++index8)
    {
      if (Job.SimulationMoves[Job.SimulationMoves.Count - 1].Tool1 != (int) camTp6.SimilationPoint.SimMove[index8].ToolNo)
      {
        X1_2 = X1_2 + camTp6.SimilationPoint.SimMove[index8].X - XPos2;
        X2_2 = X2_2 + camTp6.SimilationPoint.SimMove[index8].X - XPos2;
        XPos1 = camTp6.SimilationPoint.SimMove[index8].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
        X1_1 = X1_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num1;
        X2_1 = X2_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num2;
        Y1 = camTp6.SimilationPoint.SimMove[index8].Y;
        Z1 = camTp6.SimilationPoint.SimMove[index8].Z;
        DrillMove drillMove3 = new DrillMove(X1_2, X2_2, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.SetPiston, XPos2, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        Job.SimulationMoves.Add(drillMove3);
      }
      if (camTp6.SimilationPoint.SimMove[index8].Aux1 != 0.0 | camTp6.SimilationPoint.SimMove[index8].Aux2 != 0.0)
      {
        if (camTp6.SimilationPoint.SimMove[index8].Aux1 != 0.0)
        {
          num1 += camTp6.SimilationPoint.SimMove[index8].Aux1;
          DrillMove drillMove4 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.Clamper1Up, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove4);
          List<double> Values = new List<double>();
          buNumeric5.DevideMinMaxValueByNumber(0.0, camTp6.SimilationPoint.SimMove[index8].Aux1, 5, ref Values);
          double x1Clamper = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
          for (int index9 = 1; index9 <= Values.Count - 1; ++index9)
          {
            DrillMove drillMove5 = new DrillMove(X1_1 + Values[index9], X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove5);
          }
          X1_1 += camTp6.SimilationPoint.SimMove[index8].Aux1;
          DrillMove drillMove6 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.Clamper1Down, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove6);
        }
        if (camTp6.SimilationPoint.SimMove[index8].Aux2 != 0.0)
        {
          num2 += camTp6.SimilationPoint.SimMove[index8].Aux2;
          DrillMove drillMove7 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.Clamper2Up, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove7);
          List<double> Values = new List<double>();
          buNumeric5.DevideMinMaxValueByNumber(0.0, camTp6.SimilationPoint.SimMove[index8].Aux2, 5, ref Values);
          double x2Clamper = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
          for (int index10 = 1; index10 <= Values.Count - 1; ++index10)
          {
            DrillMove drillMove8 = new DrillMove(X1_1, X2_1 + Values[index10], Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove8);
          }
          X2_1 += camTp6.SimilationPoint.SimMove[index8].Aux2;
          DrillMove drillMove9 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.Clamper2Down, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove9);
        }
      }
      else
      {
        X1_2 = X1_2 + camTp6.SimilationPoint.SimMove[index8].X - XPos2;
        X2_2 = X2_2 + camTp6.SimilationPoint.SimMove[index8].X - XPos2;
        XPos1 = camTp6.SimilationPoint.SimMove[index8].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
        X1_1 = X1_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num1;
        X2_1 = X2_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num2;
        Y1 = camTp6.SimilationPoint.SimMove[index8].Y;
        Z1 = camTp6.SimilationPoint.SimMove[index8].Z;
        if (index8 == camTp6.SimilationPoint.SimMove.Count - 1)
        {
          DrillMove drillMove10 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.ResetPiston, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove10);
        }
        DrillMove CurrentMove = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp6.SimilationPoint.SimMove[index8].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        if (index8 == 0 && Job.SimulationMoves.Count > 0)
        {
          List<DrillMove> calcSimMoves = new List<DrillMove>();
          clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], CurrentMove, 20.0, ref calcSimMoves);
          if (calcSimMoves.Count > 2)
          {
            calcSimMoves.RemoveAt(calcSimMoves.Count - 1);
            for (int index11 = 0; index11 <= calcSimMoves.Count - 1; ++index11)
              Job.SimulationMoves.Add(calcSimMoves[index11]);
          }
        }
        Job.SimulationMoves.Add(CurrentMove);
        XPos2 = camTp6.SimilationPoint.SimMove[index8].X;
      }
    }
    if (!(camTp6.CamPoints.Count > 0 & isTop))
      return;
    Job.Cams.Add(camTp6);
  }

  public void ShapeCamParameterSet(DrillJob Job, ToolBase5 toolFound)
  {
    buMWDrillVars.varCamContour.buPar.Speeds.Feed = clsDrill.varDrillCNCSettings.MillingFeed;
    buMWDrillVars.varCamContour.buPar.Speeds.Plunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
    buMWDrillVars.varCamContour.buPar.Distances.SafeSmall = clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamContour.buPar.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
    buMWDrillVars.varCamContour.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamContour.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamContour.mwPar.MachParam.LinkParams.FeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamContour.mwPar.MachParam.LinkParams.RetractPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamContour.mwPar.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
    buMWDrillVars.varCamContour.mwPar.MachParam.RapidRetractFlg = true;
    buMWDrillVars.varCamContour.mwPar.MachParam.RapidFeedFlg = true;
    buMWDrillVars.varCamRough.buPar.Speeds.Feed = clsDrill.varDrillCNCSettings.MillingFeed;
    buMWDrillVars.varCamRough.buPar.Speeds.Plunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
    buMWDrillVars.varCamRough.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
    buMWDrillVars.varCamRough.buPar.Distances.SafeSmall = clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamRough.buPar.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
    buMWDrillVars.varCamRough.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamRough.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = toolFound.Geometry.Diameter * 0.9;
    buMWDrillVars.varCamRough.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamRough.mwPar.MachParam.LinkParams.FeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamRough.mwPar.MachParam.LinkParams.RetractPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamRough.mwPar.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
    buMWDrillVars.varCamRough.mwPar.MachParam.RapidRetractFlg = true;
    buMWDrillVars.varCamRough.mwPar.MachParam.RapidFeedFlg = true;
    buMWDrillVars.varCamMeshRough.mwPar.MachParam.MaxStepoverDistance = toolFound.Geometry.Diameter * 0.9;
    buMWDrillVars.varCamMeshRough.buPar.Speeds.Feed = clsDrill.varDrillCNCSettings.MillingFeed;
    buMWDrillVars.varCamMeshRough.buPar.Speeds.Plunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
    buMWDrillVars.varCamMeshRough.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
    buMWDrillVars.varCamMeshRough.buPar.Distances.SafeSmall = clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshRough.buPar.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
    buMWDrillVars.varCamMeshRough.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshRough.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshRough.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshRough.mwPar.MachParam.LinkParams.FeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshRough.mwPar.MachParam.LinkParams.RetractPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshRough.mwPar.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
    buMWDrillVars.varCamMeshParalelCut.buPar.Speeds.Feed = clsDrill.varDrillCNCSettings.MillingFeed;
    buMWDrillVars.varCamMeshParalelCut.buPar.Speeds.Plunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
    buMWDrillVars.varCamMeshParalelCut.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
    buMWDrillVars.varCamMeshParalelCut.buPar.Distances.SafeSmall = clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshParalelCut.buPar.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
    buMWDrillVars.varCamMeshParalelCut.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshParalelCut.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshParalelCut.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshParalelCut.mwPar.MachParam.LinkParams.FeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshParalelCut.mwPar.MachParam.LinkParams.RetractPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    buMWDrillVars.varCamMeshParalelCut.mwPar.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
  }

  public void CreateCodeForShapeTopAndBottomSide(
    ref List<DrillItem> ItemShape,
    bool preCalculation,
    bool isTop,
    ToolBase5 toolFound,
    ref DrillJob Job)
  {
    double Y1 = 0.0;
    double Y2 = 0.0;
    double Y3 = 0.0;
    double Z1 = 0.0;
    double Z2 = 0.0;
    double Z3 = 0.0;
    double X1_1 = 0.0;
    double X2_1 = 0.0;
    double XPos1 = 0.0;
    ToolBase5 toolBase5_1 = new ToolBase5();
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<Entity> entityList3 = new List<Entity>();
    List<Entity> entityList4 = new List<Entity>();
    List<Entity> entityList5 = new List<Entity>();
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    clsMW.CamEntities.Clear();
    MWCalculationOptions MWCalcoptions = new MWCalculationOptions();
    MWCalcoptions.NumberofAxis = 3;
    MWCalcoptions.Mode = CamMode.WireFrame;
    MWCalcoptions.DontApplyReset = true;
    MWCalcoptions.isBuWireframeCalculation = false;
    MWCalcoptions.AddToCamListInMWCalculation = false;
    MWCalcoptions.DontShowDialogBox = true;
    MWCalcoptions.isBuSort = false;
    MWCalcoptions.UseStartPoint = false;
    MWCalcoptions.UseConstantStartPoint = false;
    MWCalcoptions.StartPointX = 0.0;
    MWCalcoptions.StartPointY = 0.0;
    MWCalcoptions.ShowProgressForm = false;
    camTp camTp1 = new camTp();
    camTp Cam1 = new camTp();
    camTp Cam2 = new camTp();
    camTp camTp2 = new camTp();
    camTp camTp3 = new camTp();
    camTp camTp4 = new camTp();
    this.ShapeCamParameterSet(Job, toolFound);
    for (int index1 = 0; index1 <= ItemShape.Count - 1; ++index1)
    {
      double depth = ItemShape[index1].ShapeData.Depth;
      buMWDrillVars.varCamContour.buPar.Operations.Direction = ClockDirectionType.CW;
      if (ItemShape[index1].Type == DrillItemType.Contouring)
        buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
      else if (ItemShape[index1].Type == DrillItemType.Contour)
      {
        buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
        buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
      }
      else if (ItemShape[index1].Type == DrillItemType.SlotByMilling)
      {
        buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
        buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
      }
      else if (ItemShape[index1].Type == DrillItemType.Profiling)
      {
        buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Right;
        buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
      }
      else
      {
        buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = ItemShape[index1].CamPars.Offsets.ClosedContour;
        MWCalcoptions.isBuWireframeCalculation = false;
        if (ItemShape[index1].ShapeType == ShapeTypes.FreeLines)
        {
          MWCalcoptions.isBuWireframeCalculation = true;
          buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
          buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
        }
      }
      buMWDrillVars.varCamContour.buPar.Distances.RapidRetract = true;
      List<List<buEntity>> copiedEntities = new List<List<buEntity>>();
      if (ItemShape[index1].camEntities.Count > 0)
        buEntity.Copy(ItemShape[index1].camEntities, ref copiedEntities);
      else
        buEntity.Copy(ItemShape[index1].shapeEntitites, ref copiedEntities);
      if (!ItemShape[index1].isDrill)
      {
        for (int index2 = 0; index2 <= copiedEntities.Count - 1; ++index2)
        {
          List<Entity> entityList6 = new List<Entity>();
          List<Entity> entityList7 = new List<Entity>();
          for (int index3 = 0; index3 <= copiedEntities[index2].Count - 1; ++index3)
          {
            buEntity refEntity = buEntity.Copy(copiedEntities[index2][index3]);
            Mirror T1 = new Mirror(new Plane(new Point3D(), Vector3D.AxisX, Vector3D.AxisZ));
            refEntity.TransformBy((Transformation) T1);
            Mirror T2 = new Mirror(new Plane(new Point3D(), Vector3D.AxisY, Vector3D.AxisZ));
            refEntity.TransformBy((Transformation) T2);
            if (ItemShape[index1].isPocket & !ItemShape[index1].isDrill)
            {
              Entity copiedEntity = (Entity) null;
              buEntity.Copy(refEntity, ref copiedEntity);
              entityList7.Add(copiedEntity);
            }
            else
            {
              Entity copiedEntity = (Entity) null;
              buEntity.Copy(refEntity, ref copiedEntity);
              entityList6.Add(copiedEntity);
            }
          }
          buMWDrillVars.varCamContour.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
          buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
          ccVars.toolActive.CamData.SpindleSpeed = clsDrill.varDrillCNCSettings.TopSpindleSpeed;
          buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
          buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - depth;
          buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
          buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - depth;
          if (ItemShape[index1].FeedCut > 0.0)
            buMWDrillVars.varCamContour.buPar.Speeds.Feed = ItemShape[index1].FeedCut;
          if (ItemShape[index1].FeedPlunge > 0.0)
            buMWDrillVars.varCamContour.buPar.Speeds.Plunge = ItemShape[index1].FeedPlunge;
          if (ItemShape[index1].SpindleSpeed > 0.0)
            ccVars.toolActive.CamData.SpindleSpeed = ItemShape[index1].SpindleSpeed;
          if (ItemShape[index1].StepEnable)
          {
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
            buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
            buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth;
            buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
            buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
            buMWDrillVars.varCamRough.buPar.Steps.StartValue = Job.Material.Size.Depth;
            buMWDrillVars.varCamRough.buPar.Steps.EndValue = Job.Material.Size.Depth - depth;
          }
          else
          {
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
            buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
            buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
            buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
            buMWDrillVars.varCamRough.buPar.Steps.StartValue = Job.Material.Size.Depth - depth;
            buMWDrillVars.varCamRough.buPar.Steps.EndValue = Job.Material.Size.Depth - depth;
          }
          if (entityList6.Count > 0)
          {
            clsMW.CamEntities.Clear();
            for (int index4 = 0; index4 <= entityList6.Count - 1; ++index4)
            {
              Entity copiedEnt = (Entity) null;
              buVector5.CopyEntities(entityList6[index4], ref copiedEnt);
              clsMW.CamEntities.Add(copiedEnt);
            }
            MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
            camTp Cam3 = new camTp();
            ToolBase5 toolBase5_2 = new ToolBase5(toolFound);
            if (ItemShape[index1].ToolMilling != null)
              toolBase5_2 = new ToolBase5(ItemShape[index1].ToolMilling);
            this.doWireframeContour(MWCalcoptions, toolBase5_2, ref Cam3);
            camTp4.EntitiesG1.AddRange((IEnumerable<Entity>) Cam3.EntitiesG1);
            Cam3.Tool = new ToolBase5(toolBase5_2);
            if (ItemShape[index1].Command == drillCommands.DrawingContour | ItemShape[index1].isMillingAtClamperSide)
            {
              if (copiedEntities.Count == 2 && index2 == 1)
              {
                bool flag = false;
                if (ItemShape[index1].X1First)
                {
                  Cam3.Aux1First = ItemShape[index1].X1First;
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam3.Aux1 = ItemShape[index1].X1Move;
                    Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam3.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                    Cam3.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                    flag = true;
                  }
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam3.Aux2 = ItemShape[index1].X2Move;
                    Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam3.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                    Cam3.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                    flag = true;
                  }
                }
                else
                {
                  Cam3.Aux1First = ItemShape[index1].X1First;
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam3.Aux2 = ItemShape[index1].X2Move;
                    Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam3.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                    Cam3.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                    flag = true;
                  }
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam3.Aux1 = ItemShape[index1].X1Move;
                    Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam3.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                    Cam3.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                    flag = true;
                  }
                }
                if (!flag || ItemShape[index1].planeName == planeBoxNames.Top)
                  ;
              }
              if (copiedEntities.Count == 3)
              {
                if (ItemShape[index1].Command == drillCommands.DrawingContour)
                {
                  if (index2 == 1)
                  {
                    bool flag = false;
                    if (ItemShape[index1].X2Move != 0.0 && ItemShape[index1].ClockDir == ClockDirectionType.CW)
                    {
                      Cam3.Aux1First = false;
                      Cam3.Aux2 = ItemShape[index1].X2Move;
                      Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                      Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                      Cam3.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                      Cam3.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                      Cam3.Aux1 = ItemShape[index1].X2Move;
                      Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                      Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                      Cam3.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                      Cam3.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                      flag = true;
                    }
                    if (ItemShape[index1].X1Move != 0.0 && ItemShape[index1].ClockDir == ClockDirectionType.CCW)
                    {
                      Cam3.Aux1First = true;
                      Cam3.Aux1 = ItemShape[index1].X1Move;
                      Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                      Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                      Cam3.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                      Cam3.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                      Cam3.Aux2 = ItemShape[index1].X1Move;
                      Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                      Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                      Cam3.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                      Cam3.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                      flag = true;
                    }
                    if (!flag || ItemShape[index1].planeName == planeBoxNames.Top)
                      ;
                  }
                  if (index2 == 2)
                  {
                    bool flag = false;
                    if (ItemShape[index1].X1Move != 0.0)
                    {
                      if (ItemShape[index1].ClockDir == ClockDirectionType.CW)
                      {
                        Cam3.Aux1 = ItemShape[index1].X1Move;
                        Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                        Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                        Cam3.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                        Cam3.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                        ItemShape[index1].X1Move += ItemShape[index1].X2Move;
                      }
                      flag = true;
                    }
                    if (ItemShape[index1].X2Move != 0.0 && ItemShape[index1].ClockDir == ClockDirectionType.CCW)
                    {
                      Cam3.Aux2 = ItemShape[index1].X2Move;
                      Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                      Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                      Cam3.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                      Cam3.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                      ItemShape[index1].X2Move = ItemShape[index1].X1Move + ItemShape[index1].X2Move;
                      flag = true;
                    }
                    if (!flag || ItemShape[index1].planeName != planeBoxNames.Top)
                      ;
                  }
                }
                else
                {
                  if (index2 == 1)
                  {
                    bool flag = false;
                    if (ItemShape[index1].X2Move != 0.0)
                    {
                      Cam3.Aux2 = ItemShape[index1].X2Move;
                      Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                      Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                      Cam3.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                      Cam3.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                      flag = true;
                    }
                    if (!flag || ItemShape[index1].planeName == planeBoxNames.Top)
                      ;
                  }
                  if (index2 == 2)
                  {
                    bool flag = false;
                    if (ItemShape[index1].X1Move != 0.0)
                    {
                      Cam3.Aux1 = ItemShape[index1].X1Move;
                      Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                      Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                      Cam3.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                      Cam3.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                      flag = true;
                    }
                    if (!flag || ItemShape[index1].planeName != planeBoxNames.Top)
                      ;
                  }
                }
              }
            }
            else
            {
              bool flag = false;
              if (ItemShape[index1].X1First)
              {
                Cam3.Aux1First = ItemShape[index1].X1First;
                if (ItemShape[index1].X1Move != 0.0 & Cam3.CamPoints.Count > 0)
                {
                  Cam3.Aux1 = ItemShape[index1].X1Move;
                  Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                  Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                  Cam3.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                  Cam3.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                  flag = true;
                }
                if (ItemShape[index1].X2Move != 0.0 & Cam3.CamPoints.Count > 0)
                {
                  Cam3.Aux2 = ItemShape[index1].X2Move;
                  Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                  Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                  Cam3.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                  Cam3.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                  flag = true;
                }
              }
              else
              {
                Cam3.Aux1First = ItemShape[index1].X1First;
                if (ItemShape[index1].X2Move != 0.0)
                {
                  Cam3.Aux2 = ItemShape[index1].X2Move;
                  Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                  Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                  Cam3.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                  Cam3.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                  flag = true;
                }
                if (ItemShape[index1].X1Move != 0.0)
                {
                  Cam3.Aux1 = ItemShape[index1].X1Move;
                  Cam3.CamPoints[0].PreCodes.Add((object) "M85");
                  Cam3.CamPoints[0].PreCodes.Add((object) "R910=0");
                  Cam3.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                  Cam3.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                  flag = true;
                }
              }
              if (!flag || ItemShape[index1].planeName == planeBoxNames.Top)
                ;
            }
            if (Cam3.CamPoints.Count > 0)
            {
              camTp4.Tool = new ToolBase5(Cam3.Tool);
              for (int index5 = 0; index5 <= Cam3.CamPoints.Count - 1; ++index5)
                camTp4.CamPoints.Add(new camTpPoint(Cam3.CamPoints[index5])
                {
                  ToolCam = new ToolBase5(Cam3.Tool)
                });
              camTp4.PlaneName = !isTop ? planeNames.Bottom : planeNames.Top;
            }
            if (Cam3.SimilationPoint.SimMove.Count > 0)
            {
              if (camTp4.SimilationPoint.SimMove.Count > 0)
              {
                List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
                clsInit.cVector5.LineerInterpolation(camTp4.SimilationPoint.SimMove[camTp4.SimilationPoint.SimMove.Count - 1], Cam3.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints);
                if (CalculatedPoints.Count >= 3)
                {
                  CalculatedPoints.RemoveAt(0);
                  CalculatedPoints.RemoveAt(CalculatedPoints.Count - 1);
                  for (int index6 = 0; index6 <= CalculatedPoints.Count - 1; ++index6)
                  {
                    CalculatedPoints[index6].ToolNo = (double) ItemShape[index1].ToolMilling.Data.No;
                    camTp4.SimilationPoint.SimMove.Add(CalculatedPoints[index6]);
                  }
                }
              }
              if (Cam3.Aux1 != 0.0 & Cam3.Aux2 != 0.0)
              {
                if (Cam3.Aux1First)
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(camTp4.SimilationPoint.SimMove[camTp4.SimilationPoint.SimMove.Count - 1]);
                  camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam3.Aux1
                  });
                  camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam3.Aux2
                  });
                }
                else
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove();
                  if (camTp4.SimilationPoint.SimMove.Count > 0)
                    Pnt = new Pnt6DSimMove(camTp4.SimilationPoint.SimMove[camTp4.SimilationPoint.SimMove.Count - 1]);
                  camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam3.Aux2
                  });
                  camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam3.Aux1
                  });
                }
              }
              else if (Cam3.Aux1 != 0.0 & Cam3.Aux2 == 0.0)
                camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(camTp4.SimilationPoint.SimMove[camTp4.SimilationPoint.SimMove.Count - 1])
                {
                  Aux1 = Cam3.Aux1
                });
              else if (Cam3.Aux1 == 0.0 & Cam3.Aux2 != 0.0)
                camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(camTp4.SimilationPoint.SimMove[camTp4.SimilationPoint.SimMove.Count - 1])
                {
                  Aux2 = Cam3.Aux2
                });
              for (int index7 = 0; index7 <= Cam3.SimilationPoint.SimMove.Count - 1; ++index7)
                camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam3.SimilationPoint.SimMove[index7])
                {
                  ToolNo = (double) ItemShape[index1].ToolMilling.Data.No
                });
            }
          }
          if (entityList7.Count > 0)
          {
            clsMW.CamEntities.Clear();
            for (int index8 = 0; index8 <= entityList7.Count - 1; ++index8)
            {
              Entity copiedEnt = (Entity) null;
              buVector5.CopyEntities(entityList7[index8], ref copiedEnt);
              clsMW.CamEntities.Add(copiedEnt);
            }
            MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
            ToolBase5 toolBase5_3 = new ToolBase5(toolFound);
            if (ItemShape[index1].ToolMilling != null)
              toolBase5_3 = new ToolBase5(ItemShape[index1].ToolMilling);
            buMWDrillVars.varCamRough.buPar.Pockets.StepOverPersentage = ItemShape[index1].CamPars.Pockets.StepOverPersentage;
            this.doWireframePocket(MWCalcoptions, toolBase5_3, ref Cam1);
            camTp4.EntitiesG1.AddRange((IEnumerable<Entity>) Cam1.EntitiesG1);
            Cam1.Tool = new ToolBase5(toolBase5_3);
            if (ItemShape[index1].isMillingAtClamperSide)
            {
              if (copiedEntities.Count == 2 && index2 == 1)
              {
                bool flag = false;
                if (ItemShape[index1].X1First)
                {
                  Cam1.Aux1First = ItemShape[index1].X1First;
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam1.Aux1 = ItemShape[index1].X1Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam1.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                    Cam1.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                    flag = true;
                  }
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam1.Aux2 = ItemShape[index1].X2Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam1.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                    Cam1.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                    flag = true;
                  }
                }
                else
                {
                  Cam1.Aux1First = ItemShape[index1].X1First;
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam1.Aux2 = ItemShape[index1].X2Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam1.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                    Cam1.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                    flag = true;
                  }
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam1.Aux1 = ItemShape[index1].X1Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam1.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                    Cam1.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                    flag = true;
                  }
                }
                if (!flag || ItemShape[index1].planeName == planeBoxNames.Top)
                  ;
              }
              if (copiedEntities.Count == 3)
              {
                if (index2 == 1)
                {
                  bool flag = false;
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam1.Aux2 = ItemShape[index1].X2Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam1.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                    Cam1.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                    flag = true;
                  }
                  if (!flag || ItemShape[index1].planeName == planeBoxNames.Top)
                    ;
                }
                if (index2 == 2)
                {
                  bool flag = false;
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam1.Aux1 = ItemShape[index1].X1Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                    Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                    Cam1.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                    Cam1.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                    flag = true;
                  }
                  if (!flag || ItemShape[index1].planeName != planeBoxNames.Top)
                    ;
                }
              }
            }
            else
            {
              bool flag = false;
              if (ItemShape[index1].X1First)
              {
                Cam1.Aux1First = ItemShape[index1].X1First;
                if (ItemShape[index1].X1Move != 0.0 & Cam1.CamPoints.Count > 0)
                {
                  Cam1.Aux1 = ItemShape[index1].X1Move;
                  Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                  Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                  Cam1.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                  Cam1.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                  flag = true;
                }
                if (ItemShape[index1].X2Move != 0.0 & Cam1.CamPoints.Count > 0)
                {
                  Cam1.Aux2 = ItemShape[index1].X2Move;
                  Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                  Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                  Cam1.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                  Cam1.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                  flag = true;
                }
              }
              else
              {
                Cam1.Aux1First = ItemShape[index1].X1First;
                if (ItemShape[index1].X2Move != 0.0)
                {
                  Cam1.Aux2 = ItemShape[index1].X2Move;
                  Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                  Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                  Cam1.CamPoints[0].PreCodes.Add((object) ("R900=" + (-ItemShape[index1].X2Move).ToString("f1")));
                  Cam1.CamPoints[0].PreCodes.Add((object) "L CARPB.ISC");
                  flag = true;
                }
                if (ItemShape[index1].X1Move != 0.0)
                {
                  Cam1.Aux1 = ItemShape[index1].X1Move;
                  Cam1.CamPoints[0].PreCodes.Add((object) "M85");
                  Cam1.CamPoints[0].PreCodes.Add((object) "R910=0");
                  Cam1.CamPoints[0].PreCodes.Add((object) ("R901=" + (-ItemShape[index1].X1Move).ToString("f1")));
                  Cam1.CamPoints[0].PreCodes.Add((object) "L CARPA.ISC");
                  flag = true;
                }
              }
              if (!flag || ItemShape[index1].planeName == planeBoxNames.Top)
                ;
            }
            if (Cam1.CamPoints.Count > 0)
            {
              camTp4.Tool = new ToolBase5(Cam1.Tool);
              for (int index9 = 0; index9 <= Cam1.CamPoints.Count - 1; ++index9)
              {
                camTp4.CamPoints.Add(new camTpPoint(Cam1.CamPoints[index9])
                {
                  ToolCam = new ToolBase5(Cam1.Tool)
                });
                if (isTop)
                {
                  if (index9 == 0)
                    ;
                  if (index9 == Cam1.CamPoints.Count - 1)
                    ;
                  if (camTp4.CamPoints.Count <= 0 || clsDrill.activeJob.Material.Size.Depth - ItemShape[index1].ShapeData.Depth <= 2.0)
                    ;
                  camTp4.PlaneName = planeNames.Top;
                }
                else
                  camTp4.PlaneName = planeNames.Bottom;
              }
            }
            if (Cam1.SimilationPoint.SimMove.Count > 0)
            {
              if (camTp4.SimilationPoint.SimMove.Count > 0)
              {
                List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
                clsInit.cVector5.LineerInterpolation(camTp4.SimilationPoint.SimMove[camTp4.SimilationPoint.SimMove.Count - 1], Cam1.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints);
                if (CalculatedPoints.Count >= 3)
                {
                  CalculatedPoints.RemoveAt(0);
                  CalculatedPoints.RemoveAt(CalculatedPoints.Count - 1);
                  for (int index10 = 0; index10 <= CalculatedPoints.Count - 1; ++index10)
                  {
                    CalculatedPoints[index10].ToolNo = (double) ItemShape[index1].ToolMilling.Data.No;
                    camTp4.SimilationPoint.SimMove.Add(CalculatedPoints[index10]);
                  }
                }
              }
              if (Cam1.Aux1 != 0.0 & Cam1.Aux2 != 0.0)
              {
                if (Cam1.Aux1First)
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[Cam1.SimilationPoint.SimMove.Count - 1]);
                  camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam1.Aux1
                  });
                  camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam1.Aux2
                  });
                }
                else
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[Cam1.SimilationPoint.SimMove.Count - 1]);
                  camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam1.Aux2
                  });
                  camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam1.Aux1
                  });
                }
              }
              else if (Cam1.Aux1 != 0.0 & Cam1.Aux2 == 0.0)
                camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[Cam1.SimilationPoint.SimMove.Count - 1])
                {
                  Aux1 = Cam1.Aux1
                });
              else if (Cam1.Aux1 == 0.0 & Cam1.Aux2 != 0.0)
                camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[Cam1.SimilationPoint.SimMove.Count - 1])
                {
                  Aux2 = Cam1.Aux2
                });
              for (int index11 = 0; index11 <= Cam1.SimilationPoint.SimMove.Count - 1; ++index11)
                camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[index11])
                {
                  ToolNo = (double) ItemShape[index1].ToolMilling.Data.No
                });
            }
          }
        }
      }
      if (ItemShape[index1].Command == drillCommands.Engraving)
      {
        for (int index12 = 0; index12 <= ItemShape[index1].solidEntities.Count - 1; ++index12)
        {
          if (ItemShape[index1].isRough)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(ItemShape[index1].solidEntities[index12], ref copiedEntity);
            entityList4.Add(copiedEntity);
          }
          if (ItemShape[index1].isFinish)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(ItemShape[index1].solidEntities[index12], ref copiedEntity);
            entityList5.Add(copiedEntity);
          }
        }
      }
      if (ItemShape[index1].isDrill)
      {
        Entity entity = (Entity) new Circle(Plane.XY, ItemShape[index1].Center, ItemShape[index1].ShapeData.Diameter / 2.0);
        entity.EntityData = (object) new CustomData()
        {
          infoDepth = ItemShape[index1].ShapeData.Depth
        };
        entityList3.Add(entity);
      }
    }
    if (entityList3.Count > 0)
    {
      double Depth = 0.0;
      clsMW.CamEntities.Clear();
      for (int index = 0; index <= entityList3.Count - 1; ++index)
      {
        Entity copiedEnt = (Entity) null;
        Depth = !isTop ? -((CustomData) entityList3[index].EntityData).infoDepth : clsDrill.activeJob.Material.Size.Depth - ((CustomData) entityList3[index].EntityData).infoDepth;
        buVector5.CopyEntities(entityList3[index], ref copiedEnt);
        clsMW.CamEntities.Add(copiedEnt);
      }
      ToolBase5 Tool = new ToolBase5();
      this.doDrill(MWCalcoptions, Depth, Tool, ref Cam2);
      if (Cam2.CamPoints.Count > 0)
      {
        for (int index13 = 0; index13 <= Cam2.CamPoints.Count - 1; ++index13)
        {
          if (index13 <= entityList3.Count - 1)
          {
            for (int index14 = 0; index14 <= ccVars.Tools[0].Tools.Count - 1; ++index14)
            {
              if (buCompare5.EQ(ccVars.Tools[0].Tools[index14].Geometry.Diameter, ((Circle) entityList3[index13]).Diameter, 0.1))
                Cam2.CamPoints[index13].ToolCam = new ToolBase5(ccVars.Tools[0].Tools[index14]);
            }
          }
          if (Cam2.CamPoints[index13].ToolCam == null)
            this.calcErrorList.Add($"Top Surface Milling Tool Not Available : {buLangTranslate.preDef.Diameter} =  {((Circle) entityList3[index13]).Diameter.ToString("f1")}");
          camTp4.CamPoints.Add(new camTpPoint(Cam2.CamPoints[index13]));
        }
      }
      if (Cam2.SimilationPoint.SimMove.Count > 0)
      {
        for (int index = 0; index <= Cam2.SimilationPoint.SimMove.Count - 1; ++index)
          camTp4.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[index]));
      }
    }
    if (clsItem.FrmProgress != null)
      clsItem.FrmProgress.Visible = false;
    List<DrillMove> drillMoveList = new List<DrillMove>();
    if (!isTop)
      return;
    double XPos2 = 0.0;
    double X1_2 = 0.0;
    double X2_2 = 0.0;
    DrillMove drillMove1 = new DrillMove();
    if (Job.SimulationMoves.Count > 0 & camTp4.SimilationPoint.SimMove.Count > 0)
    {
      XPos2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].XPosition;
      X1_2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
      X2_2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
      X1_1 = X1_2;
      X2_1 = X2_2;
      Y1 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y1Position;
      Y2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y2Position;
      Y3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y3Position;
      Z1 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z1Position;
      Z2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z2Position;
      Z3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z3Position;
      DrillMove drillMove2 = new DrillMove(X1_2, X2_2, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.SetPiston, XPos2, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[0].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
      Job.SimulationMoves.Add(drillMove2);
    }
    double num1 = 0.0;
    double num2 = 0.0;
    for (int index15 = 0; index15 <= camTp4.SimilationPoint.SimMove.Count - 1; ++index15)
    {
      if (Job.SimulationMoves[Job.SimulationMoves.Count - 1].Tool1 != (int) camTp4.SimilationPoint.SimMove[index15].ToolNo)
      {
        X1_2 = X1_2 + camTp4.SimilationPoint.SimMove[index15].X - XPos2;
        X2_2 = X2_2 + camTp4.SimilationPoint.SimMove[index15].X - XPos2;
        XPos1 = camTp4.SimilationPoint.SimMove[index15].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
        X1_1 = X1_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num1;
        X2_1 = X2_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num2;
        Y1 = camTp4.SimilationPoint.SimMove[index15].Y;
        Z1 = camTp4.SimilationPoint.SimMove[index15].Z;
        DrillMove drillMove3 = new DrillMove(X1_2, X2_2, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.SetPiston, XPos2, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        Job.SimulationMoves.Add(drillMove3);
      }
      if (camTp4.SimilationPoint.SimMove[index15].Aux1 != 0.0 | camTp4.SimilationPoint.SimMove[index15].Aux2 != 0.0)
      {
        if (camTp4.SimilationPoint.SimMove[index15].Aux1 != 0.0)
        {
          num1 += camTp4.SimilationPoint.SimMove[index15].Aux1;
          DrillMove drillMove4 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.Clamper1Up, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove4);
          List<double> Values = new List<double>();
          buNumeric5.DevideMinMaxValueByNumber(0.0, camTp4.SimilationPoint.SimMove[index15].Aux1, 5, ref Values);
          double x1Clamper = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
          for (int index16 = 1; index16 <= Values.Count - 1; ++index16)
          {
            DrillMove drillMove5 = new DrillMove(X1_1 + Values[index16], X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove5);
          }
          X1_1 += camTp4.SimilationPoint.SimMove[index15].Aux1;
          DrillMove drillMove6 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.Clamper1Down, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove6);
        }
        if (camTp4.SimilationPoint.SimMove[index15].Aux2 != 0.0)
        {
          num2 += camTp4.SimilationPoint.SimMove[index15].Aux2;
          DrillMove drillMove7 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.Clamper2Up, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove7);
          List<double> Values = new List<double>();
          buNumeric5.DevideMinMaxValueByNumber(0.0, camTp4.SimilationPoint.SimMove[index15].Aux2, 5, ref Values);
          double x2Clamper = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
          for (int index17 = 1; index17 <= Values.Count - 1; ++index17)
          {
            DrillMove drillMove8 = new DrillMove(X1_1, X2_1 + Values[index17], Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove8);
          }
          X2_1 += camTp4.SimilationPoint.SimMove[index15].Aux2;
          DrillMove drillMove9 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.Clamper2Down, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove9);
        }
      }
      else
      {
        X1_2 = X1_2 + camTp4.SimilationPoint.SimMove[index15].X - XPos2;
        X2_2 = X2_2 + camTp4.SimilationPoint.SimMove[index15].X - XPos2;
        XPos1 = camTp4.SimilationPoint.SimMove[index15].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
        X1_1 = X1_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num1;
        X2_1 = X2_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num2;
        Y1 = camTp4.SimilationPoint.SimMove[index15].Y;
        Z1 = camTp4.SimilationPoint.SimMove[index15].Z;
        if (index15 == camTp4.SimilationPoint.SimMove.Count - 1)
        {
          DrillMove drillMove10 = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.ResetPiston, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
          Job.SimulationMoves.Add(drillMove10);
        }
        DrillMove CurrentMove = new DrillMove(X1_1, X2_1, Y1, Y2, Y3, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1, DrillCNCMode.None, drillPlaneNames.Top, (int) camTp4.SimilationPoint.SimMove[index15].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        if (index15 == 0 && Job.SimulationMoves.Count > 0)
        {
          List<DrillMove> calcSimMoves = new List<DrillMove>();
          clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], CurrentMove, 20.0, ref calcSimMoves);
          if (calcSimMoves.Count > 2)
          {
            calcSimMoves.RemoveAt(calcSimMoves.Count - 1);
            for (int index18 = 0; index18 <= calcSimMoves.Count - 1; ++index18)
              Job.SimulationMoves.Add(calcSimMoves[index18]);
          }
        }
        Job.SimulationMoves.Add(CurrentMove);
        XPos2 = camTp4.SimilationPoint.SimMove[index15].X;
      }
    }
    if (!(camTp4.CamPoints.Count > 0 & isTop))
      return;
    Job.Cams.Add(camTp4);
  }

  public void doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWDrillVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWDrillVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
    buMWDrillVars.varCamContour.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDrillVars.varCamContour.mwPar, buMWDrillVars.varCamContour.buPar);
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamContour.mwPar, buMWDrillVars.varCamContour.buPar, out clsMW.varbuCamWFContourPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWDrillVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWDrillVars.varCamContour.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void doWireframePocket(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
    buMWDrillVars.varCamRough.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWDrillVars.varCamRough.buPar.Runtime.SimG1DevideLength = 40.0;
    buMWDrillVars.varCamRough.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDrillVars.varCamRough.mwPar, buMWDrillVars.varCamRough.buPar);
    clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamRough.mwPar, buMWDrillVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
    clsMW.varMWCamWFPocketPars.MachParam.MaxStepoverDistance = Tool.Geometry.Diameter * clsMW.varbuCamWFPocketPars.Pockets.StepOverPersentage / 100.0;
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWDrillVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWDrillVars.varCamRough.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void doTriangleMeshRough(
    MWCalculationOptions MWCalcoptions,
    ToolBase5 Tool,
    ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWDrillVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWDrillVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
    MWCalcoptions.CamTriMeshType = CamTriangularMeshType.Rough;
    buMWDrillVars.varCamMeshRough.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDrillVars.varCamMeshRough.mwPar, buMWDrillVars.varCamMeshRough.buPar);
    clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamMeshRough.mwPar, buMWDrillVars.varCamMeshRough.buPar, out clsMW.varbuCamMeshRoughPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWDrillVars.varCamMeshRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWDrillVars.varCamMeshRough.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void doTriangleMeshParalelCut(
    MWCalculationOptions MWCalcoptions,
    ToolBase5 Tool,
    ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWDrillVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWDrillVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
    MWCalcoptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
    buMWDrillVars.varCamMeshParalelCut.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDrillVars.varCamMeshParalelCut.mwPar, buMWDrillVars.varCamMeshParalelCut.buPar);
    clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamMeshParalelCut.mwPar, buMWDrillVars.varCamMeshParalelCut.buPar, out clsMW.varbuCamMeshParallelPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWDrillVars.varCamMeshParalelCut.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWDrillVars.varCamMeshParalelCut.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void doDrill(
    MWCalculationOptions MWCalcoptions,
    double Depth,
    ToolBase5 Tool,
    ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWDrillVars.varCamContour.buPar.Runtime.SimG0DevideLength = 20.0;
    buMWDrillVars.varCamContour.buPar.Runtime.SimG1DevideLength = 10.0;
    clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamContour.mwPar, buMWDrillVars.varCamContour.buPar, out clsMW.varbuCamDrillPars);
    camResult Result = (camResult) null;
    clsMW.varbuCamDrillPars.Drill.EndHeight = Depth;
    clsMW.varbuCamDrillPars.Distances.Rapid = clsDrill.activeJob.Material.Size.Depth - Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    clsMW.varbuCamDrillPars.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
    clsMW.varMWCamDrillPars.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
    clsMW.varMWCamDrillPars.MachParam.LinkParams.RetractPlaneIncremental = clsDrill.activeJob.Material.Size.Depth - Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
    int num = clsInit.appMW.doDrill(MWCalcoptions, new ToolBase5(Tool)
    {
      Purpose = ToolPurpose.Drilling
    }, ref Cam, ref Result);
    buMWDrillVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWDrillVars.varCamContour.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void ToolSetAddList(DrillMoveOptions Option, ref List<string> CodeSL)
  {
    if (Option.Tool1 != 0)
      CodeSL.Add("M" + Option.Tool1.ToString());
    if (Option.Tool2 != 0)
      CodeSL.Add("M" + Option.Tool2.ToString());
    if (Option.Tool3 != 0)
      CodeSL.Add("M" + Option.Tool3.ToString());
    if (Option.Tool4 != 0)
      CodeSL.Add("M" + Option.Tool4.ToString());
    if (Option.Tool5 != 0)
      CodeSL.Add("M" + Option.Tool5.ToString());
    if (Option.Tool6 != 0)
      CodeSL.Add("M" + Option.Tool6.ToString());
    if (Option.Tool7 != 0)
      CodeSL.Add("M" + Option.Tool7.ToString());
    if (Option.Tool8 != 0)
      CodeSL.Add("M" + Option.Tool8.ToString());
    if (Option.Tool9 != 0)
      CodeSL.Add("M" + Option.Tool9.ToString());
    if (Option.Tool10 != 0)
      CodeSL.Add("M" + Option.Tool10.ToString());
    if (Option.Tool11 != 0)
      CodeSL.Add("M" + Option.Tool11.ToString());
    if (Option.Tool12 == 0)
      return;
    CodeSL.Add("M" + Option.Tool12.ToString());
  }

  public void RecommentedTools()
  {
    List<DrillCalcItem> Items = new List<DrillCalcItem>();
    DrillJob Job = new DrillJob(clsDrill.activeJob);
    this.FindDrillsAtPlane(Job, planeBoxNames.Top, ref Items);
    Job.ItemCalc.Clear();
    Job.ItemCalc.AddRange((IEnumerable<DrillCalcItem>) Items);
  }

  public bool FindToolWithToolNo(int ToolNo, ref ToolBase5 foundTool)
  {
    bool toolWithToolNo;
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == ToolNo)
      {
        foundTool = new ToolBase5(clsDrill.ToolList[index]);
        toolWithToolNo = true;
        goto label_6;
      }
    }
    toolWithToolNo = false;
label_6:
    return toolWithToolNo;
  }

  public bool FindTool(DrillCalcItem Item, FindToolSettings Settings, ref ToolBase5 foundTool)
  {
    bool tool;
    if (Item.Type == DrillItemType.Drill)
    {
      if (Item.planeName == planeBoxNames.Front)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (clsDrill.ToolList[index].Geometry.ToolDirection.X == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter)
          {
            int num = Item.Center.Y >= Settings.Y1Y2ZoneSelectionLimit ? 0 : 1;
            if (clsDrill.ToolList[index].Data.GroupIndex == num)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              tool = true;
              goto label_42;
            }
          }
        }
      }
      else if (Item.planeName == planeBoxNames.Left)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (clsDrill.ToolList[index].Geometry.ToolDirection.Y == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && clsDrill.ToolList[index].Data.GroupIndex == 1)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            tool = true;
            goto label_42;
          }
        }
      }
      else if (Item.planeName == planeBoxNames.Right)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (clsDrill.ToolList[index].Geometry.ToolDirection.Y == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && clsDrill.ToolList[index].Data.GroupIndex == 0)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            tool = true;
            goto label_42;
          }
        }
      }
      else if (Item.planeName == planeBoxNames.Top)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (clsDrill.ToolList[index].Geometry.ToolDirection.Z == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter)
          {
            int num = Item.Center.Y >= Settings.Y1Y2ZoneSelectionLimit ? 0 : 1;
            if (clsDrill.ToolList[index].Data.GroupIndex == num)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              tool = true;
              goto label_42;
            }
          }
        }
      }
      else if (Item.planeName == planeBoxNames.Back)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (clsDrill.ToolList[index].Geometry.ToolDirection.X == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter)
          {
            int num = Item.Center.Y >= Settings.Y1Y2ZoneSelectionLimit ? 0 : 1;
            if (clsDrill.ToolList[index].Data.GroupIndex == num)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              tool = true;
              goto label_42;
            }
          }
        }
      }
    }
    if (Item.Type == DrillItemType.Slot && Item.planeName == planeBoxNames.Top)
    {
      for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
      {
        if (clsDrill.ToolList[index].Geometry.GeometryType == ToolType.Slot)
        {
          int num = Item.Center.Y >= Settings.Y1Y2ZoneSelectionLimit ? 0 : 1;
          if (clsDrill.ToolList[index].Data.GroupIndex == num)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            tool = true;
            goto label_42;
          }
        }
      }
    }
    tool = false;
label_42:
    return tool;
  }

  public bool FindToolFromBlock(
    DrillCalcItem Item,
    int BlockIndex,
    FindToolSettings Settings,
    ref ToolBase5 foundTool)
  {
    foundTool = (ToolBase5) null;
    bool toolFromBlock;
    if (Item.Type == DrillItemType.Slot)
    {
      for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
      {
        if (!clsDrill.ToolList[index].Data.Used | Settings.IgnoreUsedInfo)
        {
          if (Settings.Plane == planeBoxNames.Top && clsDrill.ToolList[index].Geometry.GeometryType == ToolType.Slot & clsDrill.ToolList[index].Geometry.Thickness == Item.Width && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No > Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Bottom && clsDrill.ToolList[index].Geometry.ToolDirection.Z == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No > Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Front && clsDrill.ToolList[index].Geometry.ToolDirection.X == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No > Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Back && clsDrill.ToolList[index].Geometry.ToolDirection.X == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No > Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Left && clsDrill.ToolList[index].Geometry.ToolDirection.Y == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No > Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Right && clsDrill.ToolList[index].Geometry.ToolDirection.Y == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No > Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
        }
      }
      if (foundTool == null)
      {
        toolFromBlock = false;
        goto label_46;
      }
    }
    if (foundTool != null)
    {
      toolFromBlock = true;
    }
    else
    {
      for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
      {
        if (!clsDrill.ToolList[index].Data.Used | Settings.IgnoreUsedInfo)
        {
          if (Settings.Plane == planeBoxNames.Top && clsDrill.ToolList[index].Geometry.ToolDirection.Z == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No >= Settings.StartToolIndex)
          {
            bool flag = true;
            if (Settings.SelectVerticalTools)
            {
              flag = false;
              if (clsDrill.ToolList[index].Positions.Location == ToolLocationType.Vertical | clsDrill.ToolList[index].Positions.Location == ToolLocationType.HorizontalAndVertical)
                flag = true;
            }
            double num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
            if (BlockIndex == 0)
              num = Item.Center.Y + clsDrill.ToolList[index].Positions.CommonOffset.Y;
            if (BlockIndex == 1)
              num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
            if (num > clsDrill.ToolList[index].Limits.AxesMinLimits.Y && flag)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
          }
          if (Settings.Plane == planeBoxNames.Bottom && clsDrill.ToolList[index].Geometry.ToolDirection.Z == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No >= Settings.StartToolIndex && Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Front && clsDrill.ToolList[index].Geometry.ToolDirection.X == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No >= Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Back && clsDrill.ToolList[index].Geometry.ToolDirection.X == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No >= Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Left && clsDrill.ToolList[index].Geometry.ToolDirection.Y == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No >= Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Right && clsDrill.ToolList[index].Geometry.ToolDirection.Y == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex & clsDrill.ToolList[index].Data.No >= Settings.StartToolIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
        }
      }
      toolFromBlock = foundTool != null;
    }
label_46:
    return toolFromBlock;
  }

  public bool FindToolFromBlock(
    DrillCalcItem Item,
    int BlockIndex,
    FindToolSettings Settings,
    SortDirection SortDir,
    ref ToolBase5 foundTool)
  {
    foundTool = (ToolBase5) null;
    if (SortDir == SortDirection.LowerToBigger)
    {
      if (Item.Type == DrillItemType.Slot)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (!clsDrill.ToolList[index].Data.Used | Settings.IgnoreUsedInfo)
          {
            if (Settings.Plane == planeBoxNames.Top && clsDrill.ToolList[index].Geometry.GeometryType == ToolType.Slot & clsDrill.ToolList[index].Geometry.Thickness == Item.Width && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              double num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (BlockIndex == 0)
                num = Item.Center.Y + clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (BlockIndex == 1)
                num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (num > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
              {
                foundTool = new ToolBase5(clsDrill.ToolList[index]);
                clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
                index = clsDrill.ToolList.Count;
              }
            }
            if (Settings.Plane == planeBoxNames.Bottom && clsDrill.ToolList[index].Geometry.ToolDirection.Z == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex && Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
            if (Settings.Plane == planeBoxNames.Front && clsDrill.ToolList[index].Geometry.ToolDirection.X == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
            if (Settings.Plane == planeBoxNames.Back && clsDrill.ToolList[index].Geometry.ToolDirection.X == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
            if (Settings.Plane == planeBoxNames.Left && clsDrill.ToolList[index].Geometry.ToolDirection.Y == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
            if (Settings.Plane == planeBoxNames.Right && clsDrill.ToolList[index].Geometry.ToolDirection.Y == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
          }
        }
      }
    }
    else if (Item.Type == DrillItemType.Slot)
    {
      for (int index = clsDrill.ToolList.Count - 1; index >= 0; --index)
      {
        if (!clsDrill.ToolList[index].Data.Used | Settings.IgnoreUsedInfo)
        {
          if (Settings.Plane == planeBoxNames.Top && clsDrill.ToolList[index].Geometry.GeometryType == ToolType.Slot & clsDrill.ToolList[index].Geometry.Thickness == Item.Width && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
          {
            double num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
            if (BlockIndex == 0)
              num = Item.Center.Y + clsDrill.ToolList[index].Positions.CommonOffset.Y;
            if (BlockIndex == 1)
              num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
            if (num > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
          }
          if (Settings.Plane == planeBoxNames.Bottom && clsDrill.ToolList[index].Geometry.ToolDirection.Z == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex && Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Front && clsDrill.ToolList[index].Geometry.ToolDirection.X == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Back && clsDrill.ToolList[index].Geometry.ToolDirection.X == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Left && clsDrill.ToolList[index].Geometry.ToolDirection.Y == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
          if (Settings.Plane == planeBoxNames.Right && clsDrill.ToolList[index].Geometry.ToolDirection.Y == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
          {
            foundTool = new ToolBase5(clsDrill.ToolList[index]);
            clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
            index = clsDrill.ToolList.Count;
          }
        }
      }
    }
    bool toolFromBlock;
    if (foundTool != null)
    {
      toolFromBlock = true;
    }
    else
    {
      if (SortDir == SortDirection.LowerToBigger)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (!clsDrill.ToolList[index].Data.Used | Settings.IgnoreUsedInfo)
          {
            if (Settings.Plane == planeBoxNames.Top && clsDrill.ToolList[index].Geometry.ToolDirection.Z == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              double num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (BlockIndex == 0)
                num = Item.Center.Y + clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (BlockIndex == 1)
                num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (num > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
              {
                foundTool = new ToolBase5(clsDrill.ToolList[index]);
                clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
                index = clsDrill.ToolList.Count;
              }
            }
            if (Settings.Plane == planeBoxNames.Bottom && clsDrill.ToolList[index].Geometry.ToolDirection.Z == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex && Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
            if (Settings.Plane == planeBoxNames.Front && clsDrill.ToolList[index].Geometry.ToolDirection.X == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
            if (Settings.Plane == planeBoxNames.Back && clsDrill.ToolList[index].Geometry.ToolDirection.X == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
            if (Settings.Plane == planeBoxNames.Left && clsDrill.ToolList[index].Geometry.ToolDirection.Y == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
            if (Settings.Plane == planeBoxNames.Right && clsDrill.ToolList[index].Geometry.ToolDirection.Y == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = clsDrill.ToolList.Count;
            }
          }
        }
      }
      else
      {
        for (int index = clsDrill.ToolList.Count - 1; index >= 0; --index)
        {
          if (!clsDrill.ToolList[index].Data.Used | Settings.IgnoreUsedInfo)
          {
            if (Settings.Plane == planeBoxNames.Top && clsDrill.ToolList[index].Geometry.ToolDirection.Z == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              double num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (BlockIndex == 0)
                num = Item.Center.Y + clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (BlockIndex == 1)
                num = Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y;
              if (num > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
              {
                foundTool = new ToolBase5(clsDrill.ToolList[index]);
                clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
                index = 0;
              }
            }
            if (Settings.Plane == planeBoxNames.Bottom && clsDrill.ToolList[index].Geometry.ToolDirection.Z == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex && Item.Center.Y - clsDrill.ToolList[index].Positions.CommonOffset.Y > clsDrill.ToolList[index].Limits.AxesMinLimits.Y)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = 0;
            }
            if (Settings.Plane == planeBoxNames.Front && clsDrill.ToolList[index].Geometry.ToolDirection.X == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = 0;
            }
            if (Settings.Plane == planeBoxNames.Back && clsDrill.ToolList[index].Geometry.ToolDirection.X == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = 0;
            }
            if (Settings.Plane == planeBoxNames.Left && clsDrill.ToolList[index].Geometry.ToolDirection.Y == 1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = 0;
            }
            if (Settings.Plane == planeBoxNames.Right && clsDrill.ToolList[index].Geometry.ToolDirection.Y == -1.0 & clsDrill.ToolList[index].Geometry.Diameter == Item.Diameter && BlockIndex == clsDrill.ToolList[index].Data.GroupIndex)
            {
              foundTool = new ToolBase5(clsDrill.ToolList[index]);
              clsDrill.ToolList[index].Data.Used = Settings.SetAsUsed;
              index = 0;
            }
          }
        }
      }
      toolFromBlock = foundTool != null;
    }
    return toolFromBlock;
  }

  public bool GetXYToolOffsetFromNo(int ToolNo, ref double XOffset, ref double YOffset)
  {
    XOffset = 0.0;
    YOffset = 0.0;
    bool toolOffsetFromNo = false;
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == ToolNo)
      {
        XOffset = clsDrill.ToolList[index].Positions.CommonOffset.X;
        YOffset = clsDrill.ToolList[index].Positions.CommonOffset.Y;
        toolOffsetFromNo = true;
      }
    }
    return toolOffsetFromNo;
  }

  public bool GetXToolOffsetFromNo(int ToolNo, ref double XOffset)
  {
    double YOffset = 0.0;
    XOffset = 0.0;
    return this.GetXYToolOffsetFromNo(ToolNo, ref XOffset, ref YOffset);
  }

  public int SetValueToAvailableTool(
    int ToolValue,
    ref int T1,
    ref int T2,
    ref int T3,
    ref int T4,
    ref int T5,
    ref int T6,
    ref int T7,
    ref int T8,
    ref int T9,
    ref int T10,
    ref int T11,
    ref int T12)
  {
    int availableTool;
    if (ToolValue > 0)
    {
      if (T1 <= 0)
      {
        T1 = ToolValue;
        availableTool = 1;
        goto label_26;
      }
      if (T2 <= 0)
      {
        T2 = ToolValue;
        availableTool = 2;
        goto label_26;
      }
      if (T3 <= 0)
      {
        T3 = ToolValue;
        availableTool = 3;
        goto label_26;
      }
      if (T4 <= 0)
      {
        T4 = ToolValue;
        availableTool = 4;
        goto label_26;
      }
      if (T5 <= 0)
      {
        T5 = ToolValue;
        availableTool = 5;
        goto label_26;
      }
      if (T6 <= 0)
      {
        T6 = ToolValue;
        availableTool = 6;
        goto label_26;
      }
      if (T7 <= 0)
      {
        T7 = ToolValue;
        availableTool = 7;
        goto label_26;
      }
      if (T8 <= 0)
      {
        T8 = ToolValue;
        availableTool = 8;
        goto label_26;
      }
      if (T9 <= 0)
      {
        T9 = ToolValue;
        availableTool = 9;
        goto label_26;
      }
      if (T10 <= 0)
      {
        T10 = ToolValue;
        availableTool = 10;
        goto label_26;
      }
      if (T11 <= 0)
      {
        T11 = ToolValue;
        availableTool = 11;
        goto label_26;
      }
      if (T12 <= 0)
      {
        T12 = ToolValue;
        availableTool = 12;
        goto label_26;
      }
    }
    availableTool = 0;
label_26:
    return availableTool;
  }

  public int SetValueToAvailableTool(
    int ToolValue,
    ref int T1,
    ref int T2,
    ref int T3,
    ref int T4,
    ref int T5,
    ref int T6,
    ref int T7,
    ref int T8,
    ref int T9,
    ref int T10,
    ref int T11,
    ref int T12,
    ref List<int> Y1GroupTool,
    ref List<int> Y2GroupTool)
  {
    int availableTool;
    if (ToolValue > 0)
    {
      if (T1 <= 0)
      {
        T1 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 1;
        goto label_74;
      }
      if (T2 <= 0)
      {
        T2 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 2;
        goto label_74;
      }
      if (T3 <= 0)
      {
        T3 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 3;
        goto label_74;
      }
      if (T4 <= 0)
      {
        T4 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 4;
        goto label_74;
      }
      if (T5 <= 0)
      {
        T5 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 5;
        goto label_74;
      }
      if (T6 <= 0)
      {
        T6 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 6;
        goto label_74;
      }
      if (T7 <= 0)
      {
        T7 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 7;
        goto label_74;
      }
      if (T8 <= 0)
      {
        T8 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 8;
        goto label_74;
      }
      if (T9 <= 0)
      {
        T9 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 9;
        goto label_74;
      }
      if (T10 <= 0)
      {
        T10 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 10;
        goto label_74;
      }
      if (T11 <= 0)
      {
        T11 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 11;
        goto label_74;
      }
      if (T12 <= 0)
      {
        T12 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        if (ToolValue >= 161 & ToolValue <= 179)
          Y2GroupTool.Add(ToolValue);
        availableTool = 12;
        goto label_74;
      }
    }
    availableTool = 0;
label_74:
    return availableTool;
  }

  public int SetValueToAvailableTool(
    int ToolValue,
    ref int T1,
    ref int T2,
    ref int T3,
    ref int T4,
    ref int T5,
    ref int T6,
    ref int T7,
    ref int T8,
    ref int T9,
    ref int T10,
    ref int T11,
    ref int T12,
    ref List<int> Y1GroupTool)
  {
    int availableTool;
    if (ToolValue > 0)
    {
      if (T1 <= 0)
      {
        T1 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 1;
        goto label_50;
      }
      if (T2 <= 0)
      {
        T2 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 2;
        goto label_50;
      }
      if (T3 <= 0)
      {
        T3 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 3;
        goto label_50;
      }
      if (T4 <= 0)
      {
        T4 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 4;
        goto label_50;
      }
      if (T5 <= 0)
      {
        T5 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 5;
        goto label_50;
      }
      if (T6 <= 0)
      {
        T6 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 6;
        goto label_50;
      }
      if (T7 <= 0)
      {
        T7 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 7;
        goto label_50;
      }
      if (T8 <= 0)
      {
        T8 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 8;
        goto label_50;
      }
      if (T9 <= 0)
      {
        T9 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 9;
        goto label_50;
      }
      if (T10 <= 0)
      {
        T10 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 10;
        goto label_50;
      }
      if (T11 <= 0)
      {
        T11 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 11;
        goto label_50;
      }
      if (T12 <= 0)
      {
        T12 = ToolValue;
        if (ToolValue >= 61 & ToolValue <= 79)
          Y1GroupTool.Add(ToolValue);
        availableTool = 12;
        goto label_50;
      }
    }
    availableTool = 0;
label_50:
    return availableTool;
  }

  public int SetValueToAvailableTool(int ToolValue, ref DrillMoveOptions Option)
  {
    int availableTool;
    if (ToolValue > 0)
    {
      if (Option.Tool1 <= 0)
      {
        Option.Tool1 = ToolValue;
        availableTool = 1;
        goto label_26;
      }
      if (Option.Tool2 <= 0)
      {
        Option.Tool2 = ToolValue;
        availableTool = 2;
        goto label_26;
      }
      if (Option.Tool3 <= 0)
      {
        Option.Tool3 = ToolValue;
        availableTool = 3;
        goto label_26;
      }
      if (Option.Tool4 <= 0)
      {
        Option.Tool4 = ToolValue;
        availableTool = 4;
        goto label_26;
      }
      if (Option.Tool5 <= 0)
      {
        Option.Tool5 = ToolValue;
        availableTool = 5;
        goto label_26;
      }
      if (Option.Tool6 <= 0)
      {
        Option.Tool6 = ToolValue;
        availableTool = 6;
        goto label_26;
      }
      if (Option.Tool7 <= 0)
      {
        Option.Tool7 = ToolValue;
        availableTool = 7;
        goto label_26;
      }
      if (Option.Tool8 <= 0)
      {
        Option.Tool8 = ToolValue;
        availableTool = 8;
        goto label_26;
      }
      if (Option.Tool9 <= 0)
      {
        Option.Tool9 = ToolValue;
        availableTool = 9;
        goto label_26;
      }
      if (Option.Tool10 <= 0)
      {
        Option.Tool10 = ToolValue;
        availableTool = 10;
        goto label_26;
      }
      if (Option.Tool11 <= 0)
      {
        Option.Tool11 = ToolValue;
        availableTool = 11;
        goto label_26;
      }
      if (Option.Tool12 <= 0)
      {
        Option.Tool12 = ToolValue;
        availableTool = 12;
        goto label_26;
      }
    }
    availableTool = 0;
label_26:
    return availableTool;
  }

  public bool FindFirstClamperPositions(
    DrillJob Job,
    ref double MaterialZeroYPos,
    ref double X1,
    ref double X2)
  {
    MaterialZeroYPos = Job.Material.Size.Height / 2.0;
    if (MaterialZeroYPos < clsDrill.varDrillCNCSettings.MaterialZeroYMinPosition)
      MaterialZeroYPos = clsDrill.varDrillCNCSettings.MaterialZeroYMinPosition;
    if (MaterialZeroYPos > clsDrill.varDrillCNCSettings.MaterialZeroYMaxPosition)
      MaterialZeroYPos = clsDrill.varDrillCNCSettings.MaterialZeroYMaxPosition;
    X2 = -clsDrill.varDrillCNCSettings.ClamperFirstPositionOffset - clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
    X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperFirstPositionOffset + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
    if (clsDrill.activeJob.FirstClamperX != clsDrill.activeJob.SecondClamperX)
    {
      X2 = clsDrill.activeJob.SecondClamperX;
      X1 = clsDrill.activeJob.FirstClamperX;
    }
    if (X2 - X1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
    {
      double num = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (X2 - X1);
      if (num > 0.0)
      {
        X2 += num / 2.0;
        X1 -= num / 2.0;
      }
    }
    if (Job.Material.Size.Width > clsDrill.varDrillCNCSettings.MaterialFeedMaxDistance)
      ;
    if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
      X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke;
    return true;
  }

  public bool isSingleClamperAvailable(DrillJob Job, ref double X1Pos, ref double X2Pos)
  {
    List<double> doubleList1 = new List<double>();
    List<double> doubleList2 = new List<double>();
    for (int index = 0; index <= Job.ItemCalc.Count - 1; ++index)
    {
      if (Job.ItemCalc[index].planeName == planeBoxNames.Front | Job.ItemCalc[index].planeName == planeBoxNames.Back)
      {
        if (Math.Abs(Job.ItemCalc[index].Center.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0)
          doubleList1.Add(Job.ItemCalc[index].Center.X);
        else
          doubleList2.Add(Job.ItemCalc[index].Center.X);
      }
      else if (Math.Abs(Job.ItemCalc[index].Center.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth)
        doubleList1.Add(Job.ItemCalc[index].Center.X);
      else
        doubleList2.Add(Job.ItemCalc[index].Center.X);
    }
    bool flag;
    if (doubleList1.Count >= 2)
    {
      for (int index = 1; index <= doubleList1.Count - 1; ++index)
      {
        if (doubleList1[index] - doubleList1[index - 1] > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          X2Pos = -Math.Abs(doubleList1[index - 1] + (doubleList1[index] - doubleList1[index - 1]) / 2.0);
          X1Pos = -(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
          flag = true;
          goto label_25;
        }
      }
      double num1 = Math.Abs(doubleList1[0]);
      if (num1 > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
      {
        X2Pos = -num1 / 2.0;
        X1Pos = -(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
        flag = true;
        goto label_25;
      }
      double num2 = Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength * 0.3;
      if (num2 - Math.Abs(doubleList1[doubleList1.Count - 1]) > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
      {
        X2Pos = -Math.Abs(doubleList1[doubleList1.Count - 1] + (num2 - doubleList1[doubleList1.Count - 1]) / 2.0);
        X1Pos = -(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
        flag = true;
        goto label_25;
      }
    }
    if (doubleList1.Count == 1 && Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperLength && doubleList1[0] == 0.0)
    {
      X2Pos = -clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
      X1Pos = -(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
      flag = true;
    }
    else if (doubleList1.Count == 0 & doubleList2.Count > 0)
    {
      X2Pos = -Job.Material.Size.Width / 2.0;
      X1Pos = -(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
      flag = true;
    }
    else
      flag = false;
label_25:
    return flag;
  }

  public bool SingleMustClamper(DrillJob Job, ref double X1Pos, ref double X2Pos)
  {
    double num = -Job.Material.Size.Width / 2.0;
    bool flag1 = false;
    bool flag2 = false;
    for (int index = 0; index <= Job.Items.Count - 1; ++index)
    {
      if (Job.Items[index].planeName == planeBoxNames.Right)
        flag1 = true;
      if (Job.Items[index].planeName == planeBoxNames.Left)
        flag2 = true;
    }
    if (!flag2)
      num = -clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
    else if (!flag1)
      num = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
    X2Pos = num;
    X1Pos = -(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
    return true;
  }

  public bool MillingContourClamperPositions(
    DrillJob Job,
    bool isTop,
    ref double X1,
    ref double X2)
  {
    double num = clsDrill.varDrillCNCSettings.ContourLimitLenForTopSpindleOneMove;
    if (!isTop)
      num = clsDrill.varDrillCNCSettings.ContourLimitLenForBottomSpindleOneMove;
    bool flag;
    if (isTop & clsDrill.varDrillCNCSettings.ContourTopDirection == ClockDirectionType.CW | !isTop & clsDrill.varDrillCNCSettings.ContourBottomDirection == ClockDirectionType.CW)
    {
      if (Job.Material.Size.Width >= num)
      {
        if (!isTop)
        {
          X2 = -clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
          X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
        }
        else
        {
          X2 = -clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
          X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
        }
        if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength)
          X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength;
        flag = true;
      }
      else if (Job.Material.Size.Width >= 700.0 & Job.Material.Size.Width < num)
      {
        X2 = -Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength;
        X1 = -Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.0;
        if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength)
          X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength;
        flag = true;
      }
      else if (Job.Material.Size.Width >= 500.0 & Job.Material.Size.Width < 700.0)
      {
        X2 = -Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.1 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength;
        X1 = -Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.1;
        flag = true;
      }
      else
      {
        X2 = -Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.3 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength;
        X1 = -Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.3;
        flag = true;
      }
    }
    else if (isTop & clsDrill.varDrillCNCSettings.ContourTopDirection == ClockDirectionType.CCW | !isTop & clsDrill.varDrillCNCSettings.ContourBottomDirection == ClockDirectionType.CCW)
    {
      if (Job.Material.Size.Width >= num)
      {
        if (!isTop)
        {
          X2 = -clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperLength * 1.2;
          X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 1.2;
        }
        else
        {
          X2 = -(clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.5);
          X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
        }
        if (X2 - X1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
        if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength)
        {
          X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength;
          if (X2 - X1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
            X2 = X1 + (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
        }
        flag = true;
      }
      else if (Job.Material.Size.Width >= 700.0 & Job.Material.Size.Width < num)
      {
        if (!isTop)
        {
          X2 = 0.0;
          X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
        }
        else
        {
          X2 = 0.0;
          X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 200.0);
        }
        flag = true;
      }
      else if (Job.Material.Size.Width >= 500.0 & Job.Material.Size.Width < 700.0)
      {
        if (!isTop)
        {
          X2 = 70.0;
          X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
        }
        else
        {
          X2 = clsDrill.varDrillCNCSettings.ClamperLength * 0.1;
          X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength + 100.0);
        }
        flag = true;
      }
      else
      {
        if (isTop)
        {
          X2 = clsDrill.varDrillCNCSettings.ClamperLength * 0.2;
          X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength);
        }
        flag = true;
      }
    }
    else
      flag = false;
    return flag;
  }

  public bool isDrillInsideClamper(
    double XPosition,
    List<ToolBase5> activeTools,
    double ClamperOperationMinDistance,
    ref double ClamperMinXToToolX,
    ref double ClamperMaxXToToolX,
    double ExtraOffset = 0.0)
  {
    bool flag = false;
    double num1 = XPosition - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - ClamperOperationMinDistance - ExtraOffset;
    double num2 = XPosition + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + ClamperOperationMinDistance + ExtraOffset;
    List<double> RefList = new List<double>();
    for (int index = 0; index <= activeTools.Count - 1; ++index)
    {
      double x = activeTools[index].Positions.CommonOffset.X;
      if (num1 <= activeTools[index].Positions.CommonOffset.X & activeTools[index].Positions.CommonOffset.X <= num2 && x >= num1 & x <= num2 & Math.Abs(x - num2) > 1.0 & Math.Abs(x - num1) > 1.0)
        flag = true;
      RefList.Add(x);
    }
    clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
    if (RefList.Count > 0)
    {
      ClamperMinXToToolX = Math.Round(RefList[RefList.Count - 1] - num1, 3);
      ClamperMaxXToToolX = Math.Round(num2 - RefList[0], 3);
    }
    return flag;
  }

  public bool isItemInsideClamper(
    double XPosition,
    ToolBase5 ToolMilling,
    double ClamperOperationMinDistance,
    ref double ClamperMinXToToolX,
    ref double ClamperMaxXToToolX,
    double ExtraOffset = 0.0)
  {
    bool flag = false;
    double num1 = XPosition - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - ClamperOperationMinDistance - ExtraOffset;
    double num2 = XPosition + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + ClamperOperationMinDistance + ExtraOffset;
    List<double> RefList = new List<double>();
    double x = ToolMilling.Positions.CommonOffset.X;
    if (num1 <= ToolMilling.Positions.CommonOffset.X & ToolMilling.Positions.CommonOffset.X <= num2 && x >= num1 & x <= num2 & Math.Abs(x - num2) > 1.0 & Math.Abs(x - num1) > 1.0)
      flag = true;
    RefList.Add(x);
    clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
    if (RefList.Count > 0)
    {
      ClamperMinXToToolX = Math.Round(RefList[RefList.Count - 1] - num1, 3);
      ClamperMaxXToToolX = Math.Round(num2 - RefList[0], 3);
    }
    return flag;
  }

  public bool isItemInsideClamper(
    DrillItem Item,
    double dX,
    ToolBase5 ToolMilling,
    ref double ClamperMinXToToolX,
    ref double ClamperMaxXToToolX,
    double ExtraOffset = 0.0)
  {
    bool flag1 = false;
    ClamperMaxXToToolX = 0.0;
    ClamperMinXToToolX = 0.0;
    double num1 = Item.BoxMinItem.X + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
    double num2 = Item.BoxMinItem.X + dX + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
    double num3 = double.MaxValue;
    double num4 = double.MinValue;
    List<double> RefList1 = new List<double>();
    if (num1 <= ToolMilling.Positions.CommonOffset.X & ToolMilling.Positions.CommonOffset.X <= num2)
    {
      double num5 = ToolMilling.Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
      num3 = num1;
      num4 = num2;
      if (num5 >= num1 & num5 <= num2)
        flag1 = true;
      RefList1.Add(num5);
    }
    double num6 = Item.BoxMaxItem.X + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
    double num7 = Item.BoxMaxItem.X + dX + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
    if (num6 <= ToolMilling.Positions.CommonOffset.X & ToolMilling.Positions.CommonOffset.X <= num7)
    {
      double num8 = ToolMilling.Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
      if (num6 < num3)
        num3 = num6;
      if (num7 > num4)
        num4 = num7;
      if (num8 >= num6 & num8 <= num7)
        flag1 = true;
      RefList1.Add(num8);
    }
    clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList1);
    if (RefList1.Count > 0)
    {
      ClamperMinXToToolX = RefList1[RefList1.Count - 1] - num3;
      ClamperMaxXToToolX = num4 - RefList1[0];
    }
    bool flag2;
    if (flag1)
    {
      flag2 = flag1;
    }
    else
    {
      if (!flag1)
      {
        List<double> Values = new List<double>();
        buNumeric5.DevideMinMaxValueByNumber(Item.BoxMinItem.X, Item.BoxMaxItem.X, 5, ref Values);
        double num9 = Values[0] + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
        double num10 = Values[Values.Count - 1] + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
        for (int index = 0; index <= Values.Count - 1; ++index)
        {
          ClamperMaxXToToolX = 0.0;
          ClamperMinXToToolX = 0.0;
          double num11 = Values[index] + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
          double num12 = Values[index] + dX + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
          double num13 = double.MaxValue;
          double num14 = double.MinValue;
          List<double> RefList2 = new List<double>();
          if (num11 <= ToolMilling.Positions.CommonOffset.X & ToolMilling.Positions.CommonOffset.X <= num12)
          {
            double num15 = ToolMilling.Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
            num13 = num9;
            num14 = num10;
            if (num15 >= num11 & num15 <= num12)
              flag1 = true;
            RefList2.Add(num15);
          }
          clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList2);
          if (RefList2.Count > 0)
          {
            ClamperMinXToToolX = RefList2[RefList2.Count - 1] - num13;
            ClamperMaxXToToolX = num14 - RefList2[0];
            if (flag1)
            {
              flag2 = flag1;
              goto label_28;
            }
          }
        }
      }
      flag2 = flag1;
    }
label_28:
    return flag2;
  }

  public void MoveClampers(
    double newX1,
    double newX2,
    drillPlaneNames Plane,
    ref DrillJob Job,
    bool AddListCmd = false)
  {
    if (Job.Moves.Count > 0)
    {
      if (buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X2Clamper, newX2, 0.1))
        newX2 = this.NoMove;
      if (buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X1Clamper, newX1, 0.1))
        newX1 = this.NoMove;
    }
    if (!(newX1 != this.NoMove | newX2 != this.NoMove))
      return;
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOff, Plane, this.NoMove, ref Job);
    if (newX1 != this.NoMove)
    {
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, Plane, this.NoMove, ref Job);
      DrillMoveOptions Options = new DrillMoveOptions(Plane, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
      if (AddListCmd)
      {
        Options.Mode = DrillCNCMode.X1ClamperMove;
        Options.ClamperMove = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
        Options.pntCenter = new Point3D();
      }
      this.AddDrillMove(newX1, this.NoMove, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, Plane, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOn, Plane, this.NoMove, ref Job);
    }
    else
    {
      if (newX2 == this.NoMove)
        return;
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, Plane, this.NoMove, ref Job);
      DrillMoveOptions Options = new DrillMoveOptions(Plane, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
      if (AddListCmd)
      {
        Options.Mode = DrillCNCMode.X2ClamperMove;
        Options.ClamperMove = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
        Options.pntCenter = new Point3D();
      }
      this.AddDrillMove(this.NoMove, newX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, Plane, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOn, Plane, this.NoMove, ref Job);
    }
  }

  public void MoveClampers(
    double newX1,
    double newX2,
    drillPlaneNames Plane,
    List<string> PreCodes,
    List<string> AfterCodes,
    ref DrillJob Job,
    bool AddListCmd = false)
  {
    if (Job.Moves.Count > 0)
    {
      if (buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X2Clamper, newX2, 0.1))
        newX2 = this.NoMove;
      if (buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X1Clamper, newX1, 0.1))
        newX1 = this.NoMove;
    }
    DrillMoveOptions Options1 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
    if (!(newX1 != this.NoMove | newX2 != this.NoMove))
      return;
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOff, this.NoMove, Options1, PreCodes, AfterCodes, ref Job);
    if (newX1 != this.NoMove)
    {
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, ref Job);
      DrillMoveOptions Options2 = new DrillMoveOptions(Plane, DrillCNCMode.Fast);
      if (AddListCmd)
      {
        Options2.Mode = DrillCNCMode.X1ClamperMove;
        Options2.ClamperMove = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
        Options2.pntCenter = new Point3D();
      }
      this.AddDrillMove(newX1, this.NoMove, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Options2, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOn, this.NoMove, ref Job);
    }
    else
    {
      if (newX2 == this.NoMove)
        return;
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, ref Job);
      DrillMoveOptions Options3 = new DrillMoveOptions(Plane, DrillCNCMode.Fast);
      if (AddListCmd)
      {
        Options3.Mode = DrillCNCMode.X2ClamperMove;
        Options3.ClamperMove = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
        Options3.pntCenter = new Point3D();
      }
      this.AddDrillMove(this.NoMove, newX2, this.NoMoveY1, this.NoMoveZ1, DrillMoveCommand.AxisMove, this.NoMove, Options3, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOn, this.NoMove, ref Job);
    }
  }

  public void AddDrillMove(
    double X1,
    double X2,
    double Y1,
    double Z1,
    DrillMoveCommand Cmd,
    double X,
    DrillMoveOptions Options,
    ref DrillJob Job)
  {
    this.AddDrillMove(X1, X2, Y1, Z1, Cmd, X, Options, new List<string>(), new List<string>(), ref Job);
  }

  public void AddDrillMove(
    double X1,
    double X2,
    double Y1,
    double Z1,
    DrillMoveCommand Cmd,
    double X,
    ref DrillJob Job)
  {
    this.AddDrillMove(X1, X2, Y1, Z1, Cmd, X, new DrillMoveOptions()
    {
      Mode = DrillCNCMode.Fast
    }, new List<string>(), new List<string>(), ref Job);
  }

  public void AddDrillMove(
    double X1,
    double X2,
    double Y1,
    double Z1,
    DrillMoveCommand Cmd,
    double X,
    DrillMoveOptions Options,
    List<string> PreCodes,
    List<string> AfterCodes,
    ref DrillJob Job)
  {
    double X1_1 = X1;
    double X2_1 = X2;
    double Y1_1 = Y1;
    double Z1_1 = Z1;
    double XPos = X;
    if (Job.Moves.Count > 0)
    {
      if (Options.OnlyCode)
      {
        DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
        drillMove.CodeLines = new List<string>();
        if (PreCodes.Count > 0)
          drillMove.CodeLines.AddRange((IEnumerable<string>) PreCodes);
        if (AfterCodes.Count > 0)
          drillMove.CodeLines.AddRange((IEnumerable<string>) AfterCodes);
        if (drillMove.CodeLines.Count <= 0)
          return;
        Job.Moves.Add(drillMove);
        return;
      }
      if (Cmd == DrillMoveCommand.AxisMove)
      {
        double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
        double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
        double xposition = Job.Moves[Job.Moves.Count - 1].XPosition;
        double y1Position = Job.Moves[Job.Moves.Count - 1].Y1Position;
        double y2Position = Job.Moves[Job.Moves.Count - 1].Y2Position;
        double y3Position = Job.Moves[Job.Moves.Count - 1].Y3Position;
        double z1Position = Job.Moves[Job.Moves.Count - 1].Z1Position;
        double z2Position = Job.Moves[Job.Moves.Count - 1].Z2Position;
        double z3Position = Job.Moves[Job.Moves.Count - 1].Z3Position;
        if ((buCompare5.EQ(X1, x1Clamper, 0.01) | X1 == this.NoMove) & (buCompare5.EQ(X2, x2Clamper, 0.01) | X2 == this.NoMove) & (buCompare5.EQ(X, xposition, 0.01) | X == this.NoMove) && buCompare5.EQ(Y1, y1Position, 0.01) | Y1 == this.NoMove && buCompare5.EQ(Z1, z1Position, 0.01) | Z1 == this.NoMove)
        {
          if (Options.Cmd1 == DrillMoveCommand.None & Options.Cmd2 == DrillMoveCommand.None & Options.Cmd3 == DrillMoveCommand.None && PreCodes.Count == 0 & AfterCodes.Count == 0)
            return;
          if (Options.Cmd1 == DrillMoveCommand.ResetAll)
            Cmd = Options.Cmd1;
          if (Options.Cmd2 == DrillMoveCommand.ResetAll)
            Cmd = Options.Cmd2;
          if (Options.Cmd3 == DrillMoveCommand.ResetAll)
            Cmd = Options.Cmd3;
          if (Options.Cmd1 == DrillMoveCommand.SetPiston)
            Cmd = Options.Cmd1;
          if (Options.Cmd2 == DrillMoveCommand.SetPiston)
            Cmd = Options.Cmd2;
          if (Options.Cmd3 == DrillMoveCommand.SetPiston)
            Cmd = Options.Cmd3;
        }
      }
    }
    if (Cmd == DrillMoveCommand.AxisMove && X1 == this.NoMove & X2 == this.NoMove & Y1 == this.NoMove & Z1 == this.NoMove & X == this.NoMove && Options.Cmd1 == DrillMoveCommand.None & Options.Cmd2 == DrillMoveCommand.None & Options.Cmd3 == DrillMoveCommand.None)
      return;
    string str1 = $"X{X.ToString("f2")} ";
    string str2 = $"Y{Y1.ToString("f2")} ";
    string str3 = $"Z{Z1.ToString("f2")} ";
    if (Job.Moves.Count > 0 & X1 == this.NoMove)
      X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
    if (Job.Moves.Count > 0 & X2 == this.NoMove)
      X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
    if (Job.Moves.Count > 0 & Y1 == this.NoMove)
    {
      Y1_1 = Job.Moves[Job.Moves.Count - 1].Y1Position;
      str2 = "";
    }
    if (Job.Moves.Count > 0 & Z1 == this.NoMove)
    {
      Z1_1 = Job.Moves[Job.Moves.Count - 1].Z1Position;
      str3 = "";
    }
    if (Job.Moves.Count > 0 & X == this.NoMove)
    {
      XPos = Job.Moves[Job.Moves.Count - 1].XPosition;
      str1 = "";
    }
    DrillMove drillMove1 = new DrillMove(X1_1, X2_1, Y1_1, 0.0, 0.0, Z1_1, 0.0, 0.0, Cmd, XPos);
    drillMove1.Tool1 = Options.Tool1;
    drillMove1.Tool2 = Options.Tool2;
    drillMove1.Tool3 = Options.Tool3;
    drillMove1.Tool4 = Options.Tool4;
    drillMove1.Tool5 = Options.Tool5;
    drillMove1.Tool6 = Options.Tool6;
    drillMove1.Tool7 = Options.Tool7;
    drillMove1.Tool8 = Options.Tool8;
    drillMove1.Tool9 = Options.Tool9;
    drillMove1.Tool10 = Options.Tool10;
    drillMove1.Tool11 = Options.Tool11;
    drillMove1.Tool12 = Options.Tool12;
    drillMove1.Mode = Options.Mode;
    drillMove1.Plane = Options.Plane;
    drillMove1.Command2 = Options.Cmd2;
    drillMove1.Command3 = Options.Cmd3;
    drillMove1.CodeLines = new List<string>();
    if (Options.pntCenter != (Point3D) null)
      drillMove1.pntCenter = new Point3D(Options.pntCenter.X, Options.pntCenter.Y, Options.pntCenter.Z);
    drillMove1.EnableAxes = new AxesEnable(Options.EnableAxes);
    drillMove1.isG0 = Options.isG0;
    drillMove1.Feed = Options.Feed;
    drillMove1.ClamperMove = Options.ClamperMove;
    string str4 = Options.Feed <= 0.0 ? "F" + clsDrill.varDrillCNCSettings.DrillPlungeFeed.ToString("f1") : "F" + Options.Feed.ToString("f1");
    if (PreCodes.Count > 0)
      drillMove1.CodeLines.AddRange((IEnumerable<string>) PreCodes);
    if (Options.AddAxesCode)
    {
      if (!drillMove1.isG0)
        drillMove1.CodeLines.Add($"G1 {str1}{str2}{str3}{str4}");
      else
        drillMove1.CodeLines.Add($"G0 {str1}{str2}{str3}");
    }
    if (AfterCodes.Count > 0)
      drillMove1.CodeLines.AddRange((IEnumerable<string>) AfterCodes);
    if (Options.AddType == DrillMoveAddType.OnlyMove)
      Job.Moves.Add(drillMove1);
    else if (Options.AddType == DrillMoveAddType.OnlySimulation)
    {
      if (Job.SimulationMoves.Count == 0)
      {
        Job.SimulationMoves.Add(drillMove1);
      }
      else
      {
        List<DrillMove> calcSimMoves = new List<DrillMove>();
        clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove1, Options.DevideLen, ref calcSimMoves);
        if (calcSimMoves.Count <= 0)
          return;
        for (int index = 0; index <= calcSimMoves.Count - 1; ++index)
          Job.SimulationMoves.Add(calcSimMoves[index]);
      }
    }
    else
    {
      Job.Moves.Add(drillMove1);
      if (Job.SimulationMoves.Count == 0 | Cmd != 0)
      {
        Job.SimulationMoves.Add(new DrillMove(drillMove1)
        {
          LineIndex = Job.Moves.Count - 1
        });
      }
      else
      {
        double devideLen = clsDrill.varDrillCNCSettings.SimulationDevideG0Length;
        if (drillMove1.Mode == DrillCNCMode.Plunge | drillMove1.Mode == DrillCNCMode.Cut)
          devideLen = clsDrill.varDrillCNCSettings.SimulationDevideG1Length;
        List<DrillMove> calcSimMoves = new List<DrillMove>();
        clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove1, devideLen, ref calcSimMoves);
        if (calcSimMoves.Count <= 0)
          return;
        for (int index = 0; index <= calcSimMoves.Count - 1; ++index)
        {
          calcSimMoves[index].LineIndex = Job.Moves.Count - 1;
          Job.SimulationMoves.Add(calcSimMoves[index]);
        }
      }
    }
  }

  public void AddClamperMoveForCnc(ref DrillJob Job, double APos, double BPos, bool isAFirst)
  {
    List<string> collection = new List<string>();
    if (isAFirst)
    {
      if (APos != 0.0)
      {
        double num = APos;
        collection.Add("R910=0");
        collection.Add("R901=" + num.ToString("f1"));
        collection.Add("L CARPA.ISC");
      }
      if (BPos != 0.0)
      {
        double num = BPos;
        collection.Add("R910=0");
        collection.Add("R900=" + num.ToString("f1"));
        collection.Add("L CARPB.ISC");
      }
    }
    else
    {
      if (BPos != 0.0)
      {
        double num = BPos;
        collection.Add("R910=0");
        collection.Add("R900=" + num.ToString("f1"));
        collection.Add("L CARPB.ISC");
      }
      if (APos != 0.0)
      {
        double num = APos;
        collection.Add("R910=0");
        collection.Add("R901=" + num.ToString("f1"));
        collection.Add("L CARPA.ISC");
      }
    }
    if (collection.Count <= 0)
      return;
    DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
    drillMove.Command = DrillMoveCommand.GCodeList;
    drillMove.pntCenter = new Point3D();
    drillMove.CodeLines = new List<string>();
    drillMove.CodeLines.AddRange((IEnumerable<string>) collection);
    Job.Moves.Add(drillMove);
  }
}
