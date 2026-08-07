// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Drill.clsDrillGoUltra2Up1Down
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

public class clsDrillGoUltra2Up1Down : clsDrill
{
  public void cmdShowTools()
  {
    if (this.FrmTools == null)
      this.FrmTools = new F_Tools();
    this.FrmTools.fileNameLeftTools = AppPath.MachineSimConfig + "\\Tools\\GoUltraLeftToolGroups.step";
    this.FrmTools.fileNameRightTools = AppPath.MachineSimConfig + "\\Tools\\GoUltraRightToolGroups.step";
    this.FrmTools.fileNameBottomTools = AppPath.MachineSimConfig + "\\Tools\\GoUltraBottomToolGroups.step";
    CreateModelProperties createModelProperties = new CreateModelProperties();
    if (this.FrmTools.viewportLeft == null)
    {
      this.FrmTools.viewportLeft = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, new CreateModelProperties()
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
      this.FrmTools.viewportLeft.Name = "viewportLeft";
      this.FrmTools.pnl_viewportleft.Controls.Add((System.Windows.Forms.Control) this.FrmTools.viewportLeft);
    }
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
    if (this.FrmTools.viewportBottom == null)
    {
      this.FrmTools.viewportBottom = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, new CreateModelProperties()
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
      this.FrmTools.viewportBottom.Name = "viewportBottom";
      this.FrmTools.pnl_viewportbottom.Controls.Add((System.Windows.Forms.Control) this.FrmTools.viewportBottom);
    }
    this.FrmTools.StartPosition = FormStartPosition.CenterParent;
    this.FrmTools.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    this.FrmTools.settingRuntime = new DrillRuntimeSettings(clsDrill.varDrillRunSettings);
    this.FrmTools.Init();
    int num = (int) this.FrmTools.ShowDialog();
    if (this.FrmTools.PropertiesForm.Result != DialogResult.OK)
      return;
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == 41)
        clsDrill.toolBottom = new ToolBase5(clsDrill.ToolList[index]);
    }
    clsDrill.varDrillRunSettings = new DrillRuntimeSettings(this.FrmTools.settingRuntime);
    this.SaveDrillFile();
    this.SaveToolConfigFile(clsDrill.fileNameToolSetting);
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
        if (buShapeCut.BasePoint.X + buShapeCut.Length > clsDrill.activeJob.Material.Size.Width + 100.0)
          Messages.Add(buDrillCalc.LangDrillMessage[44]);
        if (Shape.BasePoint.Y < 0.0)
          Messages.Add(buDrillCalc.LangDrillMessage[45]);
        if (Shape.BasePoint.Y > clsDrill.activeJob.Material.Size.Height)
          Messages.Add(buDrillCalc.LangDrillMessage[46]);
        if (buShapeCut.planeName == planeBoxNames.Back | buShapeCut.planeName == planeBoxNames.Front | buShapeCut.planeName == planeBoxNames.Left | buShapeCut.planeName == planeBoxNames.Right)
          Messages.Add(buDrillCalc.LangDrillMessage[51]);
        if (buShapeCut.planeName == planeBoxNames.Bottom && !buShapeCut.isMilling)
          Messages.Add(buDrillCalc.LangDrillMessage[52]);
        if (buShapeCut.planeName == planeBoxNames.Top)
        {
          if (buShapeCut.isMilling & buShapeCut.Diameter != clsDrill.toolTop.Geometry.Diameter)
            Messages.Add(buDrillCalc.LangDrillMessage[54]);
          if (!buShapeCut.isMilling & buShapeCut.Diameter != clsDrill.toolSlotY1.Geometry.CutLength & buShapeCut.Diameter != clsDrill.toolSlotY2.Geometry.CutLength)
            Messages.Add(buDrillCalc.LangDrillMessage[55]);
        }
        if (buShapeCut.planeName == planeBoxNames.Bottom && buShapeCut.isMilling & buShapeCut.Diameter != clsDrill.toolBottom.Geometry.Diameter)
          Messages.Add(buDrillCalc.LangDrillMessage[54]);
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
    List<DrillCalcItem> lst1 = new List<DrillCalcItem>();
    List<DrillCalcItem> lst2 = new List<DrillCalcItem>();
    List<DrillCalcItem> lst3 = new List<DrillCalcItem>();
    List<DrillCalcItem> lst4 = new List<DrillCalcItem>();
    List<DrillItem> drillItemList = new List<DrillItem>();
    List<DrillItem> ItemDrillShape = new List<DrillItem>();
    List<DrillItem> ItemSlotShape = new List<DrillItem>();
    this.ItemSplited = new List<List<DrillCalcItem>>();
    List<DrillCalcItem> drillCalcItemList1 = new List<DrillCalcItem>();
    List<List<DrillCalcItem>> drillCalcItemListList = new List<List<DrillCalcItem>>();
    clsInit.appDrill.GetItemsFromDrillTypes(ref Job);
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == 85)
        clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[index]);
      if (clsDrill.ToolList[index].Data.No == 185)
        clsDrill.toolSlotY2 = new ToolBase5(clsDrill.ToolList[index]);
    }
    this.FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref X1_1, ref X2_1);
    bool flag1 = false;
    if (Job.FirstClamperX < -Job.Material.Size.Width && -Job.Material.Size.Width < Job.SecondClamperX & Job.SecondClamperX < 0.0)
      flag1 = true;
    if (!flag1)
    {
      if (Job.isClamperSideDrillOpAvailable & Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperSingleLimit | flag1)
      {
        double X1Pos = 0.0;
        double X2Pos = 0.0;
        Job.isSingleClamper = clsInit.cDrill.isSingleClamperAvailable(Job, clsDrill.varDrillCNCSettings, ref X1Pos, ref X2Pos);
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
      Job.isSingleClamper = clsInit.cDrill.SingleMustClamper(Job, clsDrill.varDrillCNCSettings, ref X1Pos, ref X2Pos);
      if (Job.isSingleClamper)
      {
        X1_1 = X1Pos;
        X2_1 = X2Pos;
      }
      if (Job.isClamperSideDrillOpAvailable)
        this.calcErrorList.Add(buDrillCalc.LangDrillMessage[66]);
    }
    for (int index = 0; index <= Job.ItemShape.Count - 1; ++index)
      drillItemList.Add(new DrillItem(Job.ItemShape[index]));
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
    List<DrillCalcItem> drillCalcItemList2 = this.SortByXDistance(lst3, new DrillCalcItem(), SortDirection.LowerToBigger);
    this.ItemSplited = new List<List<DrillCalcItem>>();
    List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList4 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList5 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList6 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList7 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList8 = new List<DrillCalcItem>();
    for (int index1 = 0; index1 <= drillCalcItemList2.Count - 1; ++index1)
    {
      if (drillCalcItemList3.Count == 0)
      {
        drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList2[index1]));
      }
      else
      {
        bool flag2 = false;
        if (buCompare5.EQ(drillCalcItemList3[drillCalcItemList3.Count - 1].Center.X, drillCalcItemList2[index1].Center.X, 0.01))
          flag2 = true;
        if (flag2)
        {
          drillCalcItemList3.Add(drillCalcItemList2[index1]);
        }
        else
        {
          List<DrillCalcItem> drillCalcItemList9 = new List<DrillCalcItem>();
          for (int index2 = 0; index2 <= drillCalcItemList5.Count - 1; ++index2)
            drillCalcItemList9.Add(drillCalcItemList5[index2]);
          for (int index3 = 0; index3 <= drillCalcItemList6.Count - 1; ++index3)
            drillCalcItemList9.Add(drillCalcItemList6[index3]);
          for (int index4 = 0; index4 <= drillCalcItemList4.Count - 1; ++index4)
            drillCalcItemList9.Add(drillCalcItemList4[index4]);
          for (int index5 = 0; index5 <= drillCalcItemList7.Count - 1; ++index5)
            drillCalcItemList9.Add(drillCalcItemList7[index5]);
          for (int index6 = 0; index6 <= drillCalcItemList8.Count - 1; ++index6)
            drillCalcItemList9.Add(drillCalcItemList8[index6]);
          this.ItemSplited.Add(drillCalcItemList9);
          drillCalcItemList3 = new List<DrillCalcItem>();
          drillCalcItemList3.Add(drillCalcItemList2[index1]);
          drillCalcItemList4 = new List<DrillCalcItem>();
          drillCalcItemList5 = new List<DrillCalcItem>();
          drillCalcItemList6 = new List<DrillCalcItem>();
          drillCalcItemList7 = new List<DrillCalcItem>();
          drillCalcItemList8 = new List<DrillCalcItem>();
        }
      }
      if (drillCalcItemList2[index1].planeName == planeBoxNames.Back)
        drillCalcItemList8.Add(new DrillCalcItem(drillCalcItemList2[index1]));
      if (drillCalcItemList2[index1].planeName == planeBoxNames.Front)
        drillCalcItemList7.Add(new DrillCalcItem(drillCalcItemList2[index1]));
      if (drillCalcItemList2[index1].planeName == planeBoxNames.Top)
        drillCalcItemList5.Add(new DrillCalcItem(drillCalcItemList2[index1]));
      if (drillCalcItemList2[index1].planeName == planeBoxNames.Bottom)
        drillCalcItemList6.Add(new DrillCalcItem(drillCalcItemList2[index1]));
      if (drillCalcItemList2[index1].planeName == planeBoxNames.Left | drillCalcItemList2[index1].planeName == planeBoxNames.Right)
        drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList2[index1]));
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
    DrillMove drillMove = new DrillMove(clsDrill.varDrillCNCSettings.ParkX1, clsDrill.varDrillCNCSettings.ParkX2, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.ParkY2, clsDrill.varDrillCNCSettings.ParkY3, clsDrill.varDrillCNCSettings.ParkZ1, clsDrill.varDrillCNCSettings.ParkZ2, clsDrill.varDrillCNCSettings.ParkZ3, DrillMoveCommand.AxisMove, 0.0);
    Job.Moves.Add(drillMove);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AllClamperUp, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, clsDrill.varDrillCNCSettings.Z3SafeDistance, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetAll, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(X1_1, X2_1, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, MaterialZeroYPos, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z2SupportDistance, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Wait, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AllClamperDown, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOn, drillPlaneNames.Top, this.NoMove, ref Job);
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
    for (int index7 = 0; index7 <= this.ItemSplited.Count - 1; ++index7)
    {
      List<DrillCalcItem> drillCalcItemList11 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList12 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList13 = new List<DrillCalcItem>();
      this.ItemSplited[index7] = this.SortByYDistance(this.ItemSplited[index7], new DrillCalcItem(), SortDirection.LowerToBigger);
      for (int index8 = 0; index8 <= this.ItemSplited[index7].Count - 1; ++index8)
      {
        if (this.ItemSplited[index7][index8].planeName == planeBoxNames.Top)
          drillCalcItemList11.Add(new DrillCalcItem(this.ItemSplited[index7][index8]));
        if (this.ItemSplited[index7][index8].planeName == planeBoxNames.Bottom)
          drillCalcItemList12.Add(new DrillCalcItem(this.ItemSplited[index7][index8]));
        if (this.ItemSplited[index7][index8].planeName == planeBoxNames.Right | this.ItemSplited[index7][index8].planeName == planeBoxNames.Left)
          drillCalcItemList13.Add(new DrillCalcItem(this.ItemSplited[index7][index8]));
      }
      if (drillCalcItemList11.Count > 0)
        this.SplitedItems.lstTop.Add(drillCalcItemList11);
      if (drillCalcItemList12.Count > 0)
        this.SplitedItems.lstBottom.Add(drillCalcItemList12);
      if (drillCalcItemList13.Count > 0)
        this.SplitedItems.lstLeftRight.Add(drillCalcItemList13);
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
    this.calcErrorList.Clear();
    this.FoundDrills.Clear();
    this.ClearCalculatedThings();
    this.FindHolesForFrontSide();
    this.FindHolesForTopSide();
    this.FindHolesForBottomSide();
    this.FindHolesForLeftRightSide();
    this.FindHolesForBackSide();
    this.AssingToolOffset();
    for (int index = 0; index <= this.FoundDrills.Count - 2; ++index)
    {
      if (buCompare5.EQ(this.FoundDrills[index].Items[0].OffsetedPoint.X, this.FoundDrills[index + 1].Items[0].OffsetedPoint.X, 0.01))
        this.FoundDrills[index + 1].Items[0].OffsetedPoint.X = this.FoundDrills[index].Items[0].OffsetedPoint.X + 1E-05;
    }
    this.FoundDrills = this.SortByXOffsetedDistanceDrillFound(this.FoundDrills, new DrillCalcItem(), SortDirection.LowerToBigger);
    if (clsDrill.varDrillCNCSettings.BackOperationsAlwaysWillLastOperation)
      this.MoveBackOperationToLast();
    this.CreateCodes(ref Job);
    for (int index9 = 0; index9 <= this.FoundDrills.Count - 1; ++index9)
    {
      for (int index10 = 0; index10 <= this.FoundDrills[index9].Items.Count - 1; ++index10)
        this.SetAsCalculatedDrillItemByID(this.FoundDrills[index9].Items[index10].ID, ref Job.ItemCalc);
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
      List<DrillCalcItem> ItemSlot1 = this.SortByYDistance(lst4, new DrillCalcItem(), SortDirection.LowerToBigger);
      List<DrillCalcItem> ItemSlot2 = new List<DrillCalcItem>();
      if (ItemSlot1.Count == 1)
      {
        this.CreateCodeForSlotTopSide(ref Job, ref ItemSlot1);
      }
      else
      {
        for (int index11 = 0; index11 <= ItemSlot1.Count - 1; ++index11)
        {
          if (!ItemSlot1[index11].Calculated)
          {
            DrillCalcItem drillCalcItem1 = ItemSlot1[index11];
            ItemSlot2.Add(drillCalcItem1);
            for (int index12 = index11 + 1; index12 <= ItemSlot1.Count - 1; ++index12)
            {
              if (!ItemSlot1[index12].Calculated)
              {
                DrillCalcItem drillCalcItem2 = ItemSlot1[index12];
                double num = drillCalcItem1.Center.Y - clsDrill.toolSlotY2.Positions.CommonOffset.Y;
                if (drillCalcItem2.Center.Y - clsDrill.toolSlotY1.Positions.CommonOffset.Y - num > clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
                  ItemSlot2.Add(drillCalcItem2);
              }
              if (ItemSlot2.Count >= 2)
                index12 = ItemSlot1.Count;
            }
          }
          if (ItemSlot2.Count > 0)
          {
            this.CreateCodeForSlotTopSide(ref Job, ref ItemSlot2);
            for (int index13 = 0; index13 <= ItemSlot2.Count - 1; ++index13)
              ItemSlot2[index13].Calculated = true;
          }
          ItemSlot2.Clear();
        }
      }
      double X1_2 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      double X2_2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      double X = 0.0;
      if (X1_2 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
      {
        double num = clsDrill.varDrillMachineSettings.MachineMinXStroke - X1_2;
        X1_2 += num;
        X2_2 += num;
        X += num;
      }
      this.AddDrillMove(X1_2, X2_2, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, X, ref Job);
    }
    this.CreatCodeFromJobShapeContour(ref Job);
    this.CreatCodeFromJobShapeItem(ref Job, Job.ItemShape, ItemDrillShape, ItemSlotShape);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.Finished, drillPlaneNames.Top, this.NoMove, ref Job);
    this.CreatCodeFromMove(Job.Moves, ref Job.Codes);
    Job.TotalSec = 0.0;
    this.doCalculateTime(ref Job.TotalSec);
    if (!(this.calcErrorList.Count > 0 & !IgnoreErrors))
      return;
    DialogBoxList dialogBoxList = new DialogBoxList();
    dialogBoxList.Caption = "No Tool Available for These Holes";
    dialogBoxList.Width = 500;
    for (int index = 0; index <= this.calcErrorList.Count - 1; ++index)
      dialogBoxList.Items.Add(this.calcErrorList[index]);
    dialogBoxList.Init();
    int num1 = (int) dialogBoxList.ShowDialog();
  }

  public void CreatCodeFromJobItem1(ref DrillJob Job, bool IgnoreErrors = false)
  {
    double X1_1 = 0.0;
    double X2_1 = 0.0;
    double MaterialZeroYPos = 0.0;
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
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == 85)
        clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[index]);
      if (clsDrill.ToolList[index].Data.No == 185)
        clsDrill.toolSlotY2 = new ToolBase5(clsDrill.ToolList[index]);
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
              ItemDrillShape.Add(new DrillItem((buShapeHole) Job.Items[index1]));
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
        buShapeCut buShapeCut = Job.Items[index1] as buShapeCut;
        if ((buShapeCut.CutType == CutTypes.CutHorizontal | buShapeCut.CutType == CutTypes.CutHorizontalLine) & !buShapeCut.isMilling)
          Job.ItemCalc.Add(new DrillCalcItem(buShapeCut));
        else if (buShapeCut.CutType == CutTypes.CutVertical | buShapeCut.CutType == CutTypes.CutVerticalLine | buShapeCut.CutType == CutTypes.CutFree)
        {
          ItemSlotShape.Add(new DrillItem((buShapeCut) Job.Items[index1]));
        }
        else
        {
          DrillItem data = new DrillItem((buShapeCut) Job.Items[index1]);
          if (-buShapeCut.CalculatedPoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + buShapeCut.Diameter / 2.0)
          {
            if (buShapeCut.Length < Job.Material.Size.Width * 0.25)
            {
              ItemSlotShape.Add(new DrillItem((buShapeCut) Job.Items[index1]));
            }
            else
            {
              List<Point3D> Points = new List<Point3D>();
              List<Point3D> PointsDevided = new List<Point3D>();
              Points.Add(buVector5.ToPoint3D(data.camEntities[0][0].StartPoint));
              Points.Add(buVector5.ToPoint3D(data.camEntities[0][0].EndPoint));
              double num = 6.0;
              if (clsDrill.activeJob.Material.Size.Width > 1000.0)
                num = 8.0;
              if (clsDrill.activeJob.Material.Size.Width > 2000.0)
                num = 12.0;
              clsInit.cVector5.DevidePointsByLength(Points, buShapeCut.Length / num, ref PointsDevided);
              if (PointsDevided.Count > 0)
              {
                data.camEntities[0].Clear();
                DrillItem drillItem1 = new DrillItem(data);
                drillItem1.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities1 = new List<buEntity>();
                refEntities1.Add((buEntity) new buLine(PointsDevided[0], PointsDevided[1]));
                clsInit.cVector5.BoxSizeCalculate(refEntities1, ref drillItem1.BoxMinOfDrawing, ref drillItem1.BoxMaxOfDrawing);
                drillItem1.BoxMinItem = new Point3D(-drillItem1.BoxMaxOfDrawing.X, -drillItem1.BoxMaxOfDrawing.Y, drillItem1.BoxMinOfDrawing.Z);
                drillItem1.BoxMaxItem = new Point3D(-drillItem1.BoxMinOfDrawing.X, -drillItem1.BoxMinOfDrawing.Y, drillItem1.BoxMaxOfDrawing.Z);
                drillItem1.camEntities.Add(refEntities1);
                ItemSlotShape.Add(drillItem1);
                DrillItem drillItem2 = new DrillItem(data);
                drillItem2.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities2 = new List<buEntity>();
                refEntities2.Add((buEntity) new buLine(PointsDevided[1], PointsDevided[2]));
                clsInit.cVector5.BoxSizeCalculate(refEntities2, ref drillItem2.BoxMinOfDrawing, ref drillItem2.BoxMaxOfDrawing);
                drillItem2.BoxMinItem = new Point3D(-drillItem2.BoxMaxOfDrawing.X, -drillItem2.BoxMaxOfDrawing.Y, drillItem2.BoxMinOfDrawing.Z);
                drillItem2.BoxMaxItem = new Point3D(-drillItem2.BoxMinOfDrawing.X, -drillItem2.BoxMinOfDrawing.Y, drillItem2.BoxMaxOfDrawing.Z);
                drillItem2.camEntities.Add(refEntities2);
                ItemSlotShape.Add(drillItem2);
                DrillItem drillItem3 = new DrillItem(data);
                drillItem3.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities3 = new List<buEntity>();
                refEntities3.Add((buEntity) new buLine(PointsDevided[2], PointsDevided[PointsDevided.Count - 3]));
                clsInit.cVector5.BoxSizeCalculate(refEntities3, ref drillItem3.BoxMinOfDrawing, ref drillItem3.BoxMaxOfDrawing);
                drillItem3.BoxMinItem = new Point3D(-drillItem3.BoxMaxOfDrawing.X, -drillItem3.BoxMaxOfDrawing.Y, drillItem3.BoxMinOfDrawing.Z);
                drillItem3.BoxMaxItem = new Point3D(-drillItem3.BoxMinOfDrawing.X, -drillItem3.BoxMinOfDrawing.Y, drillItem3.BoxMaxOfDrawing.Z);
                drillItem3.camEntities.Add(refEntities3);
                ItemSlotShape.Add(drillItem3);
                DrillItem drillItem4 = new DrillItem(data);
                drillItem4.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities4 = new List<buEntity>();
                refEntities4.Add((buEntity) new buLine(PointsDevided[PointsDevided.Count - 3], PointsDevided[PointsDevided.Count - 2]));
                clsInit.cVector5.BoxSizeCalculate(refEntities4, ref drillItem4.BoxMinOfDrawing, ref drillItem4.BoxMaxOfDrawing);
                drillItem4.BoxMinItem = new Point3D(-drillItem4.BoxMaxOfDrawing.X, -drillItem4.BoxMaxOfDrawing.Y, drillItem4.BoxMinOfDrawing.Z);
                drillItem4.BoxMaxItem = new Point3D(-drillItem4.BoxMinOfDrawing.X, -drillItem4.BoxMinOfDrawing.Y, drillItem4.BoxMaxOfDrawing.Z);
                drillItem4.camEntities.Add(refEntities4);
                ItemSlotShape.Add(drillItem4);
                DrillItem drillItem5 = new DrillItem(data);
                drillItem5.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities5 = new List<buEntity>();
                refEntities5.Add((buEntity) new buLine(PointsDevided[PointsDevided.Count - 2], PointsDevided[PointsDevided.Count - 1]));
                clsInit.cVector5.BoxSizeCalculate(refEntities5, ref drillItem5.BoxMinOfDrawing, ref drillItem5.BoxMaxOfDrawing);
                drillItem5.BoxMinItem = new Point3D(-drillItem5.BoxMaxOfDrawing.X, -drillItem5.BoxMaxOfDrawing.Y, drillItem5.BoxMinOfDrawing.Z);
                drillItem5.BoxMaxItem = new Point3D(-drillItem5.BoxMinOfDrawing.X, -drillItem5.BoxMinOfDrawing.Y, drillItem5.BoxMaxOfDrawing.Z);
                drillItem5.camEntities.Add(refEntities5);
                ItemSlotShape.Add(drillItem5);
              }
            }
          }
          else
            ItemSlotShape.Add(new DrillItem((buShapeCut) Job.Items[index1]));
        }
      }
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Shape & Job.Items[index1].Enable)
        ItemShape.Add(new DrillItem(Job.Items[index1]));
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Profiling & Job.Items[index1].Enable)
        ItemShape.Add(new DrillItem((buShapeProfiling) Job.Items[index1]));
      if (Job.Items[index1] is buShapeJunction & Job.Items[index1].Enable)
      {
        buShapeJunction buShapeJunction = Job.Items[index1] as buShapeJunction;
        if (buShapeJunction.Enable)
        {
          for (int index4 = 0; index4 <= buShapeJunction.multiCenter.Count - 1; ++index4)
          {
            buShapeHole buShapeHole = new buShapeHole(buShapeJunction.multiCenter[index4].Diameter, buShapeJunction.Depth);
            buShapeHole.CalculatedPoint = new Point3D(buShapeJunction.multiCenter[index4].Center.X, buShapeJunction.multiCenter[index4].Center.Y, buShapeJunction.multiCenter[index4].Center.Z);
            buShapeHole.planeName = buShapeJunction.planeName;
            buShapeHole.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole));
            ++this.IDCounter;
          }
        }
      }
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Engraving & Job.Items[index1].Enable)
        ItemShape.Add(new DrillItem((buShapeEngrave) Job.Items[index1]));
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
    if (Job.isClamperSideDrillOpAvailable & Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperSingleLimit)
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
    this.ItemSplited = new List<List<DrillCalcItem>>();
    List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList4 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList5 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList6 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList7 = new List<DrillCalcItem>();
    List<DrillCalcItem> drillCalcItemList8 = new List<DrillCalcItem>();
    for (int index5 = 0; index5 <= drillCalcItemList2.Count - 1; ++index5)
    {
      if (drillCalcItemList3.Count == 0)
      {
        drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList2[index5]));
      }
      else
      {
        bool flag = false;
        if (buCompare5.EQ(drillCalcItemList3[drillCalcItemList3.Count - 1].Center.X, drillCalcItemList2[index5].Center.X, 0.01))
          flag = true;
        if (flag)
        {
          drillCalcItemList3.Add(drillCalcItemList2[index5]);
        }
        else
        {
          List<DrillCalcItem> drillCalcItemList9 = new List<DrillCalcItem>();
          for (int index6 = 0; index6 <= drillCalcItemList5.Count - 1; ++index6)
            drillCalcItemList9.Add(drillCalcItemList5[index6]);
          for (int index7 = 0; index7 <= drillCalcItemList6.Count - 1; ++index7)
            drillCalcItemList9.Add(drillCalcItemList6[index7]);
          for (int index8 = 0; index8 <= drillCalcItemList4.Count - 1; ++index8)
            drillCalcItemList9.Add(drillCalcItemList4[index8]);
          for (int index9 = 0; index9 <= drillCalcItemList7.Count - 1; ++index9)
            drillCalcItemList9.Add(drillCalcItemList7[index9]);
          for (int index10 = 0; index10 <= drillCalcItemList8.Count - 1; ++index10)
            drillCalcItemList9.Add(drillCalcItemList8[index10]);
          this.ItemSplited.Add(drillCalcItemList9);
          drillCalcItemList3 = new List<DrillCalcItem>();
          drillCalcItemList3.Add(drillCalcItemList2[index5]);
          drillCalcItemList4 = new List<DrillCalcItem>();
          drillCalcItemList5 = new List<DrillCalcItem>();
          drillCalcItemList6 = new List<DrillCalcItem>();
          drillCalcItemList7 = new List<DrillCalcItem>();
          drillCalcItemList8 = new List<DrillCalcItem>();
        }
      }
      if (drillCalcItemList2[index5].planeName == planeBoxNames.Back)
        drillCalcItemList8.Add(new DrillCalcItem(drillCalcItemList2[index5]));
      if (drillCalcItemList2[index5].planeName == planeBoxNames.Front)
        drillCalcItemList7.Add(new DrillCalcItem(drillCalcItemList2[index5]));
      if (drillCalcItemList2[index5].planeName == planeBoxNames.Top)
        drillCalcItemList5.Add(new DrillCalcItem(drillCalcItemList2[index5]));
      if (drillCalcItemList2[index5].planeName == planeBoxNames.Bottom)
        drillCalcItemList6.Add(new DrillCalcItem(drillCalcItemList2[index5]));
      if (drillCalcItemList2[index5].planeName == planeBoxNames.Left | drillCalcItemList2[index5].planeName == planeBoxNames.Right)
        drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList2[index5]));
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
    DrillMove drillMove = new DrillMove(clsDrill.varDrillCNCSettings.ParkX1, clsDrill.varDrillCNCSettings.ParkX2, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.ParkY2, clsDrill.varDrillCNCSettings.ParkY3, clsDrill.varDrillCNCSettings.ParkZ1, clsDrill.varDrillCNCSettings.ParkZ2, clsDrill.varDrillCNCSettings.ParkZ3, DrillMoveCommand.AxisMove, 0.0);
    Job.Moves.Add(drillMove);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AllClamperUp, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, clsDrill.varDrillCNCSettings.Z3SafeDistance, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetAll, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(X1_1, X2_1, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, MaterialZeroYPos, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z2SupportDistance, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Wait, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AllClamperDown, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, this.NoMove, ref Job);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOn, drillPlaneNames.Top, this.NoMove, ref Job);
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
    for (int index11 = 0; index11 <= this.ItemSplited.Count - 1; ++index11)
    {
      List<DrillCalcItem> drillCalcItemList11 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList12 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList13 = new List<DrillCalcItem>();
      this.ItemSplited[index11] = this.SortByYDistance(this.ItemSplited[index11], new DrillCalcItem(), SortDirection.LowerToBigger);
      for (int index12 = 0; index12 <= this.ItemSplited[index11].Count - 1; ++index12)
      {
        if (this.ItemSplited[index11][index12].planeName == planeBoxNames.Top)
          drillCalcItemList11.Add(new DrillCalcItem(this.ItemSplited[index11][index12]));
        if (this.ItemSplited[index11][index12].planeName == planeBoxNames.Bottom)
          drillCalcItemList12.Add(new DrillCalcItem(this.ItemSplited[index11][index12]));
        if (this.ItemSplited[index11][index12].planeName == planeBoxNames.Right | this.ItemSplited[index11][index12].planeName == planeBoxNames.Left)
          drillCalcItemList13.Add(new DrillCalcItem(this.ItemSplited[index11][index12]));
      }
      if (drillCalcItemList11.Count > 0)
        this.SplitedItems.lstTop.Add(drillCalcItemList11);
      if (drillCalcItemList12.Count > 0)
        this.SplitedItems.lstBottom.Add(drillCalcItemList12);
      if (drillCalcItemList13.Count > 0)
        this.SplitedItems.lstLeftRight.Add(drillCalcItemList13);
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
    this.calcErrorList.Clear();
    this.FoundDrills.Clear();
    this.ClearCalculatedThings();
    this.FindHolesForFrontSide();
    this.FindHolesForTopSide();
    this.FindHolesForBottomSide();
    this.FindHolesForLeftRightSide();
    this.FindHolesForBackSide();
    this.AssingToolOffset();
    for (int index = 0; index <= this.FoundDrills.Count - 2; ++index)
    {
      if (buCompare5.EQ(this.FoundDrills[index].Items[0].OffsetedPoint.X, this.FoundDrills[index + 1].Items[0].OffsetedPoint.X, 0.01))
        this.FoundDrills[index + 1].Items[0].OffsetedPoint.X = this.FoundDrills[index].Items[0].OffsetedPoint.X + 1E-05;
    }
    this.FoundDrills = this.SortByXOffsetedDistanceDrillFound(this.FoundDrills, new DrillCalcItem(), SortDirection.LowerToBigger);
    if (clsDrill.varDrillCNCSettings.BackOperationsAlwaysWillLastOperation)
      this.MoveBackOperationToLast();
    this.CreateCodes(ref Job);
    for (int index13 = 0; index13 <= this.FoundDrills.Count - 1; ++index13)
    {
      for (int index14 = 0; index14 <= this.FoundDrills[index13].Items.Count - 1; ++index14)
        this.SetAsCalculatedDrillItemByID(this.FoundDrills[index13].Items[index14].ID, ref Job.ItemCalc);
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
      List<DrillCalcItem> ItemSlot1 = this.SortByYDistance(lst4, new DrillCalcItem(), SortDirection.LowerToBigger);
      List<DrillCalcItem> ItemSlot2 = new List<DrillCalcItem>();
      if (ItemSlot1.Count == 1)
      {
        this.CreateCodeForSlotTopSide(ref Job, ref ItemSlot1);
      }
      else
      {
        for (int index15 = 0; index15 <= ItemSlot1.Count - 1; ++index15)
        {
          if (!ItemSlot1[index15].Calculated)
          {
            DrillCalcItem drillCalcItem1 = ItemSlot1[index15];
            ItemSlot2.Add(drillCalcItem1);
            for (int index16 = index15 + 1; index16 <= ItemSlot1.Count - 1; ++index16)
            {
              if (!ItemSlot1[index16].Calculated)
              {
                DrillCalcItem drillCalcItem2 = ItemSlot1[index16];
                double num = drillCalcItem1.Center.Y - clsDrill.toolSlotY2.Positions.CommonOffset.Y;
                if (drillCalcItem2.Center.Y - clsDrill.toolSlotY1.Positions.CommonOffset.Y - num > clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
                  ItemSlot2.Add(drillCalcItem2);
              }
              if (ItemSlot2.Count >= 2)
                index16 = ItemSlot1.Count;
            }
          }
          if (ItemSlot2.Count > 0)
          {
            this.CreateCodeForSlotTopSide(ref Job, ref ItemSlot2);
            for (int index17 = 0; index17 <= ItemSlot2.Count - 1; ++index17)
              ItemSlot2[index17].Calculated = true;
          }
          ItemSlot2.Clear();
        }
      }
      double X1_2 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      double X2_2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      double X = 0.0;
      if (X1_2 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
      {
        double num = clsDrill.varDrillMachineSettings.MachineMinXStroke - X1_2;
        X1_2 += num;
        X2_2 += num;
        X += num;
      }
      this.AddDrillMove(X1_2, X2_2, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, X, ref Job);
    }
    this.CreatCodeFromJobShapeContour(ref Job);
    this.CreatCodeFromJobShapeItem(ref Job, ItemShape, ItemDrillShape, ItemSlotShape);
    this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.Finished, drillPlaneNames.Top, this.NoMove, ref Job);
    this.CreatCodeFromMove(Job.Moves, ref Job.Codes);
    Job.TotalSec = 0.0;
    this.doCalculateTime(ref Job.TotalSec);
    if (!(this.calcErrorList.Count > 0 & !IgnoreErrors))
      return;
    DialogBoxList dialogBoxList = new DialogBoxList();
    dialogBoxList.Caption = "No Tool Available for These Holes";
    dialogBoxList.Width = 500;
    for (int index = 0; index <= this.calcErrorList.Count - 1; ++index)
      dialogBoxList.Items.Add(this.calcErrorList[index]);
    dialogBoxList.Init();
    int num1 = (int) dialogBoxList.ShowDialog();
  }

  public void CreatCodeFromJobShapeItem(
    ref DrillJob Job,
    List<DrillItem> ItemShape,
    List<DrillItem> ItemDrillShape,
    List<DrillItem> ItemSlotShape)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    if (!(ItemShape.Count > 0 | ItemDrillShape.Count > 0 | ItemSlotShape.Count > 0 | Job.MakeContour))
      return;
    if (Job.Moves[Job.Moves.Count - 1].XPosition != 0.0)
    {
      num1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition, Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.Fast, 0.0, 0, 0, 0, 0, 0, 0, ref Job);
    }
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == 41)
        clsDrill.toolBottom = new ToolBase5(clsDrill.ToolList[index]);
    }
    double lastX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
    double lastX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
    List<DrillItem> lst = new List<DrillItem>();
    List<DrillItem> drillItemList1 = new List<DrillItem>();
    List<DrillItem> drillItemList2 = new List<DrillItem>();
    for (int index = 0; index <= ItemShape.Count - 1; ++index)
    {
      if (ItemShape[index].planeName == planeBoxNames.Top)
        drillItemList1.Add(ItemShape[index]);
      if (ItemShape[index].planeName == planeBoxNames.Bottom)
        drillItemList2.Add(ItemShape[index]);
      lst.Add(ItemShape[index]);
    }
    for (int index = 0; index <= ItemDrillShape.Count - 1; ++index)
    {
      if (ItemDrillShape[index].planeName == planeBoxNames.Top)
      {
        drillItemList1.Add(ItemDrillShape[index]);
        drillItemList1[drillItemList1.Count - 1].isDrill = true;
      }
      if (ItemDrillShape[index].planeName == planeBoxNames.Bottom)
      {
        drillItemList2.Add(ItemDrillShape[index]);
        drillItemList2[drillItemList2.Count - 1].isDrill = true;
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
          drillItemList1.Add(ItemSlotShape[index]);
      }
      if (ItemSlotShape[index].planeName == planeBoxNames.Bottom)
        drillItemList2.Add(ItemSlotShape[index]);
      if (!flag)
        lst.Add(ItemSlotShape[index]);
    }
    List<DrillItem> drillItemList3 = this.SortShapeByXDistance(lst, new DrillItem(), SortDirection.LowerToBigger);
    List<DrillItem> ItemShape1 = new List<DrillItem>();
    List<DrillItem> ItemShape2 = new List<DrillItem>();
    for (int index = 0; index <= drillItemList3.Count - 1; ++index)
    {
      if (drillItemList3[index].planeName == planeBoxNames.Top)
        ItemShape1.Add(drillItemList3[index]);
      if (drillItemList3[index].planeName == planeBoxNames.Bottom)
        ItemShape2.Add(drillItemList3[index]);
    }
    List<DrillItem> entInClamperArea1 = new List<DrillItem>();
    for (int index = 0; index <= drillItemList3.Count - 1; ++index)
    {
      if (drillItemList3[index].planeName == planeBoxNames.Top && Math.Abs(drillItemList3[index].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
        entInClamperArea1.Add(new DrillItem(drillItemList3[index]));
    }
    this.AdjustClamperForShape(ref Job, entInClamperArea1, lastX1, lastX2);
    if (ItemShape1.Count > 0)
    {
      double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
      double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
      double num3 = 0.0;
      double num4 = 0.0;
      double x = clsDrill.toolTop.Positions.CommonOffset.X;
      for (int index = 0; index <= ItemShape1.Count - 1; ++index)
      {
        if (ItemShape1[index].ToolMilling != null)
          clsDrill.toolTop = new ToolBase5(ItemShape1[index].ToolMilling);
        double ClamperMinXToToolX = 0.0;
        double ClamperMaxXToToolX = 0.0;
        if (Math.Abs(ItemShape1[index].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
        {
          if (this.isItemInsideClamper(ItemShape1[index], x2Clamper + clsDrill.toolTop.Positions.CommonOffset.X + num4, clsDrill.toolTop, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0) | Math.Abs(ClamperMaxXToToolX) < 5.0 & Math.Abs(ClamperMaxXToToolX) > 0.0 | Math.Abs(ClamperMinXToToolX) < 20.0 & Math.Abs(ClamperMinXToToolX) > 0.0)
          {
            num4 += ClamperMinXToToolX;
            double num5 = x2Clamper + x + num4 + ItemShape1[index].BoxMinItem.X - clsDrill.toolTop.Positions.CommonOffset.X;
            if (num5 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
            {
              double num6 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0 - num5;
              num4 += num6;
              ClamperMinXToToolX += num6;
            }
            ItemShape1[index].X2Move = ClamperMinXToToolX;
          }
          if (this.isItemInsideClamper(ItemShape1[index], x1Clamper + clsDrill.toolTop.Positions.CommonOffset.X + num3, clsDrill.toolTop, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0) | Math.Abs(ClamperMaxXToToolX) < 20.0 & Math.Abs(ClamperMaxXToToolX) > 0.0 | Math.Abs(ClamperMinXToToolX) < 20.0 & Math.Abs(ClamperMinXToToolX) > 0.0)
          {
            num3 += ClamperMinXToToolX;
            double num7 = x1Clamper + x + num3 + ItemShape1[index].BoxMinItem.X - clsDrill.toolTop.Positions.CommonOffset.X;
            if (num7 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
            {
              double num8 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0 - num7;
              num3 += num8;
              ClamperMinXToToolX += num8;
            }
            double num9 = x2Clamper + num4;
            if (num9 - (x1Clamper + num3) < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
            {
              double num10 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (num9 - (x1Clamper + num3));
              num4 += num10;
              ItemShape1[index].X2Move = num10;
              ItemShape1[index].X1First = false;
            }
            ItemShape1[index].X1Move = ClamperMinXToToolX;
          }
        }
      }
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.ParkY2, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, this.NoMove, ref Job);
      this.CreateCodeForShapeTopAndBottomSide(ref ItemShape1, false, true, clsDrill.toolTop, ref Job);
      TpPnt9D LastP9 = new TpPnt9D();
      if (Job.Cams.Count > 0)
        clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP9);
      double X = LastP9.P9.X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
      this.AddDrillMove(x1Clamper + num3 + X, x2Clamper + num4 + X, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.GCode, drillPlaneNames.Top, X, ref Job);
      if (ItemShape2.Count > 0)
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - X, Job.Moves[Job.Moves.Count - 1].X2Clamper - X, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.Fast, 0.0, 0, 0, 0, 0, 0, 0, ref Job);
    }
    List<DrillItem> entInClamperArea2 = new List<DrillItem>();
    for (int index = 0; index <= drillItemList3.Count - 1; ++index)
    {
      if (drillItemList3[index].planeName == planeBoxNames.Bottom && Math.Abs(drillItemList3[index].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.BottomKorukYMinusDistance)
        entInClamperArea2.Add(new DrillItem(drillItemList3[index]));
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
    this.AdjustClamperForShape(ref Job, entInClamperArea2, Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper);
    if (ItemShape2.Count <= 0)
      return;
    double x1Clamper1 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
    double x2Clamper1 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
    double num11 = 0.0;
    double num12 = 0.0;
    for (int index = 0; index <= ItemShape2.Count - 1; ++index)
    {
      if (ItemShape2[index].ToolMilling != null)
        clsDrill.toolBottom = new ToolBase5(ItemShape2[index].ToolMilling);
      double ClamperMinXToToolX = 0.0;
      double ClamperMaxXToToolX = 0.0;
      if (Math.Abs(ItemShape2[index].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
      {
        if (this.isItemInsideClamper(ItemShape2[index], x2Clamper1 + clsDrill.toolBottom.Positions.CommonOffset.X + num12, clsDrill.toolBottom, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance) | Math.Abs(ClamperMaxXToToolX) < 20.0 & Math.Abs(ClamperMaxXToToolX) > 0.0 | Math.Abs(ClamperMinXToToolX) < 20.0 & Math.Abs(ClamperMinXToToolX) > 0.0)
        {
          num12 += ClamperMinXToToolX;
          double num13 = x2Clamper1 + clsDrill.toolBottom.Positions.CommonOffset.X + num12 + ItemShape2[index].BoxMinItem.X - clsDrill.toolTop.Positions.CommonOffset.X;
          if (num13 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance)
          {
            double num14 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance - num13;
            num12 += num14;
            ClamperMinXToToolX += num14;
          }
          ItemShape2[index].X2Move = ClamperMinXToToolX;
        }
        if (this.isItemInsideClamper(ItemShape2[index], x1Clamper1 + clsDrill.toolBottom.Positions.CommonOffset.X + num11, clsDrill.toolBottom, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance) | Math.Abs(ClamperMaxXToToolX) < 20.0 & Math.Abs(ClamperMaxXToToolX) > 0.0 | Math.Abs(ClamperMinXToToolX) < 20.0 & Math.Abs(ClamperMinXToToolX) > 0.0)
        {
          num11 += ClamperMinXToToolX;
          double num15 = x1Clamper1 + clsDrill.toolBottom.Positions.CommonOffset.X + num11 + ItemShape2[index].BoxMinItem.X - clsDrill.toolTop.Positions.CommonOffset.X;
          if (num15 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance)
          {
            double num16 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance - num15;
            num11 += num16;
            ClamperMinXToToolX += num16;
          }
          double num17 = x2Clamper1 + num12;
          if (num17 - (x1Clamper1 + num11) < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          {
            double num18 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (num17 - (x1Clamper1 + num11));
            num12 += num18;
            ItemShape2[index].X2Move = num18;
            ItemShape2[index].X1First = false;
          }
          ItemShape2[index].X1Move = ClamperMinXToToolX;
        }
      }
    }
    this.CreateCodeForShapeTopAndBottomSide(ref ItemShape2, false, false, clsDrill.toolBottom, ref Job);
    if (Job.Cams.Count <= 0 || Job.Cams[0].CamPoints.Count <= 0)
      return;
    double Y1 = Job.Cams[Job.Cams.Count - 1].CamPoints[0].Points[0].P9.Y + clsDrill.varDrillCNCSettings.TopSpindleYOffsetForBottomOperation;
    double parkY2 = clsDrill.varDrillCNCSettings.ParkY2;
    TpPnt9D LastP9_1 = new TpPnt9D();
    clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP9_1);
    double X1 = LastP9_1.P9.X + clsDrill.varDrillCNCSettings.Tool270XZeroOffset;
    this.AddDrillMove(this.NoMove, this.NoMove, Y1, parkY2, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Bottom, DrillCNCMode.Z1_Z2NoOffset, this.NoMove, ref Job);
    this.AddDrillMove(x1Clamper1 + num11 + X1, x2Clamper1 + num12 + X1, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.GCode, drillPlaneNames.Bottom, DrillCNCMode.Z1_Z2NoOffset, X1, ref Job);
  }

  public void AdjustClamperForShape(
    ref DrillJob Job,
    List<DrillItem> entInClamperArea,
    double lastX1,
    double lastX2)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    if (Job.Material.Size.Width > clsDrill.varDrillMachineSettings.MachineMillingStandartXStroke)
    {
      double num3 = Job.Material.Size.Width - clsDrill.varDrillMachineSettings.MachineMillingStandartXStroke;
      double num4 = lastX2 - num3;
      if (num4 - lastX1 > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
      {
        lastX2 = num4;
        this.MoveClampers(this.NoMove, lastX2, drillPlaneNames.Top, ref Job);
      }
      else
      {
        if (num4 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance) <= clsDrill.varDrillMachineSettings.MachineMinXStroke)
          return;
        lastX2 = num4;
        lastX1 = num4 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
        this.MoveClampers(lastX1, this.NoMove, drillPlaneNames.Top, ref Job);
        this.MoveClampers(this.NoMove, lastX2, drillPlaneNames.Top, ref Job);
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
        double newX1 = 0.0;
        if (flag4)
          newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
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
                        flag3 = true;
                      }
                      else if (Math.Abs(minMidMaxRangeList1[index].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                      {
                        newX2 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                        flag3 = true;
                      }
                    }
                    else if (Math.Abs(minMidMaxRangeList1[index].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                    {
                      newX2 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                      flag3 = true;
                    }
                  }
                  else if (Math.Abs(minMidMaxRangeList1[index].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                  {
                    newX2 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                    flag3 = true;
                  }
                }
                else
                {
                  newX2 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                  flag3 = true;
                }
              }
              else if (minMidMaxRangeList1[index].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
              {
                newX2 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                flag3 = true;
              }
            }
            else if (!flag3 && minMidMaxRangeList1[index].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance)
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
                          newX1 = minMidMaxRangeList1[minMidMaxRangeList1.Count - 2].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                          flag2 = true;
                        }
                        else if (Math.Abs(minMidMaxRangeList1[index].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                        {
                          newX1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                          flag2 = true;
                        }
                      }
                      else if (Math.Abs(minMidMaxRangeList1[index].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                      {
                        newX1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                        flag2 = true;
                      }
                    }
                    else if (Math.Abs(minMidMaxRangeList1[index].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                    {
                      newX1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                      flag2 = true;
                    }
                  }
                  else if (Math.Abs(minMidMaxRangeList1[index].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
                  {
                    newX1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                    flag2 = true;
                  }
                }
                else if (minMidMaxRangeList1[index].Range < clsDrill.varDrillCNCSettings.ClamperLength * 2.0)
                {
                  newX1 = minMidMaxRangeList1[index].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
                  if (newX1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                    flag2 = true;
                }
                else
                {
                  newX1 = minMidMaxRangeList1[index].Min + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0);
                  if (newX1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
                    flag2 = true;
                }
              }
              else if (minMidMaxRangeList1[index].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
              {
                newX1 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
                flag2 = true;
              }
            }
            else if (!flag2 && minMidMaxRangeList1[index].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
            {
              newX1 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
              if (newX1 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
              {
                flag2 = true;
              }
              else
              {
                double num11 = minMidMaxRangeList1[index].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
                double num12 = minMidMaxRangeList1[index].Max - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
                if (clsDrill.varDrillMachineSettings.MachineMinXStroke > num11 & clsDrill.varDrillMachineSettings.MachineMinXStroke < num12)
                {
                  newX1 = clsDrill.varDrillMachineSettings.MachineMinXStroke;
                  flag2 = true;
                }
              }
              if (!flag2)
                ;
            }
          }
        }
        double num13 = clsDrill.activeJob.Material.Size.Width - Math.Abs(newX1);
        if (num13 < 0.0 & clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - Math.Abs(num13) < 50.0)
          newX1 = -clsDrill.activeJob.Material.Size.Width;
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
              if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
              {
                newX1 = newX2 - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
                this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
              }
              this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
            }
          }
          else
            stringList.Add(buDrillCalc.LangDrillMessage[25] + " [X2]");
        }
        if (!flag4)
        {
          if (flag2)
          {
            if (!buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X1Clamper, newX1) && newX1 < -Job.Material.Size.Width / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
            {
              if (Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
                newX1 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
              this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
            }
          }
          else
            stringList.Add(buDrillCalc.LangDrillMessage[25] + " [X1]");
        }
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          this.MoveClampers(Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance, this.NoMove, drillPlaneNames.Top, ref Job);
      }
      if (!(entInClamperArea.Count > 0 & minMidMaxRangeList2.Count > 0 & (minMidMaxRangeList1.Count == 0 | !flag3 & !flag5)))
        return;
      double xposition = Job.Moves[Job.Moves.Count - 1].XPosition;
      if (Job.Material.Size.Width <= 500.0)
      {
        double newX2 = minMidMaxRangeList2[0].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - 20.0;
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          this.MoveClampers(newX2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance), this.NoMove, drillPlaneNames.Top, ref Job);
        this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
      }
      else
      {
        double newX2 = minMidMaxRangeList2[0].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - 150.0;
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          this.MoveClampers(newX2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance), this.NoMove, drillPlaneNames.Top, ref Job);
        this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
      }
    }
  }

  public void CreatCodeFromJobShapeContour(ref DrillJob Job)
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
        drillItemList1.Add(drillItem2);
      }
    }
    if (!flag)
      return;
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == 41)
        clsDrill.toolBottom = new ToolBase5(clsDrill.ToolList[index]);
    }
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
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.ParkY2, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, this.NoMove, ref Job);
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
        if (ccVars.SimMachine.MachineParts[index1].Tag != null)
        {
          if (ccVars.SimMachine.MachineParts[index1].Tag == "Z1")
            num = clsDrill.varDrillCNCSettings.Y1GroupZOffset;
          if (ccVars.SimMachine.MachineParts[index1].Tag == "Z2")
            num = clsDrill.varDrillCNCSettings.Y2GroupZOffset;
          if (ccVars.SimMachine.MachineParts[index1].Tag == "Z3")
            num = clsDrill.varDrillCNCSettings.Y3GroupZOffset;
        }
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
            double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalXOffset;
            double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalYOffset;
            double dz = clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
            refMeshes[index4].Translate(dx, dy, dz);
          }
          else
          {
            double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalXOffset;
            double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalYOffset;
            double dz = clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
            refMeshes[index4].Translate(dx, dy, dz);
          }
          buTool.Tag = "Z1";
        }
        if (clsDrill.ToolList[index3].Data.No == 80 /*0x50*/)
        {
          double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalXOffset;
          double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalYOffset;
          double dz = clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
          refMeshes[index4].Translate(dx, dy, dz);
          buTool.Tag = "Z1";
        }
        if (clsDrill.ToolList[index3].Data.No == 85)
        {
          double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalXOffset;
          double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalYOffset;
          double dz = clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
          refMeshes[index4].Translate(dx, dy, dz);
          buTool.Tag = "Z1";
        }
        if (clsDrill.ToolList[index3].Data.No >= 161 & clsDrill.ToolList[index3].Data.No <= 179)
        {
          if (Math.Abs(clsDrill.ToolList[index3].Geometry.ToolDirection.Z) != 0.0)
          {
            double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y2GroupToolVerticalXOffset;
            double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y2GroupToolVerticalYOffset;
            double dz = clsDrill.varDrillCNCSettings.Y2GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y2GroupZOffset;
            refMeshes[index4].Translate(dx, dy, dz);
          }
          else
          {
            double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalXOffset;
            double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalYOffset;
            double dz = clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalZOffset + clsDrill.varDrillCNCSettings.Y2GroupZOffset;
            refMeshes[index4].Translate(dx, dy, dz);
          }
          buTool.Tag = "Z2";
        }
        if (clsDrill.ToolList[index3].Data.No == 185)
        {
          double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y2GroupToolVerticalXOffset;
          double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y2GroupToolVerticalYOffset;
          double dz = clsDrill.varDrillCNCSettings.Y2GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y2GroupZOffset;
          refMeshes[index4].Translate(dx, dy, dz);
          buTool.Tag = "Z2";
        }
        if (clsDrill.ToolList[index3].Data.No >= 261 & clsDrill.ToolList[index3].Data.No <= 269)
        {
          double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y3GroupToolVerticalXOffset;
          double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y3GroupToolVerticalYOffset;
          double dz = clsDrill.varDrillCNCSettings.Y3GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y3GroupZOffset;
          refMeshes[index4].Translate(dx, dy, dz);
          buTool.Tag = "Z3";
        }
        if (clsDrill.ToolList[index3].Data.No == 270)
        {
          double dx = clsDrill.ToolList[index3].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y3GroupToolVerticalXOffset;
          double dy = -clsDrill.ToolList[index3].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y3GroupToolVerticalYOffset;
          double dz = clsDrill.varDrillCNCSettings.Y3GroupToolMillingZOffset + clsDrill.varDrillCNCSettings.Y3GroupZOffset;
          refMeshes[index4].Translate(dx, dy, dz);
          buTool.Tag = "Z3";
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
        buMaterialMoveable materialMoveable = new buMaterialMoveable($"SolidMat{index5.ToString()}{index6.ToString()}");
        materialMoveable.XMove = true;
        Block block = new Block($"SolidMat{index5.ToString()}{index6.ToString()}");
        block.Entities.Add(copiedEntity);
        for (int index7 = 0; index7 <= clsDrill.viewportAuto.Blocks.Count - 1; ++index7)
        {
          if (clsDrill.viewportAuto.Blocks[index7].Name == $"SolidMat{index5.ToString()}{index6.ToString()}")
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

  public void MoveSimPart(DrillMove pntMove)
  {
    clsDrill.SimToCollsionCheck1.Clear();
    clsDrill.SimToCollsionCheck2.Clear();
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
      CustomData entityData = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]].EntityData as CustomData;
      KinematicBase5 kinematicBase5 = new KinematicBase5()
      {
        RotateCenterOffsetOfA = {
          Z = 171.0
        },
        Type = KinemeticType.CartezianXYZ_WristA_4Axis
      };
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
          if (entity1.Tag != null)
          {
            if (entity1.Tag == "Z1")
            {
              ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y1Position;
              if (entity1.No != 80 /*0x50*/)
                ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z1Position + num2;
              else
                ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z1Position + num2;
              Entity entity2 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
              entity2.Translate(0.0, -pntMove.Y1Position, pntMove.Z1Position + num2);
              entity2.Regen(new RegenParams(0.01, (IWorkspace) clsDrill.viewportAuto));
              clsDrill.SimToCollsionCheck1.Add(entity2);
            }
            if (entity1.Tag == "Z2")
            {
              ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y2Position;
              ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z2Position + num2;
              Entity entity3 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
              entity3.Translate(0.0, -pntMove.Y2Position, pntMove.Z2Position + num2);
              entity3.Regen(new RegenParams(0.01, (IWorkspace) clsDrill.viewportAuto));
              clsDrill.SimToCollsionCheck1.Add(entity3);
            }
            if (entity1.Tag == "Z3")
            {
              ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y3Position;
              if (entity1.No != 270)
                ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = -(pntMove.Z3Position + num2);
              else
                ((buTool) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = -(pntMove.Z3Position + num2 + clsDrill.varDrillSettings.SimBottomMillinOffset);
              Entity entity4 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
              entity4.Translate(0.0, -pntMove.Y3Position, -(pntMove.Z3Position + num2));
              entity4.Regen(new RegenParams(0.01, (IWorkspace) clsDrill.viewportAuto));
              clsDrill.SimToCollsionCheck1.Add(entity4);
            }
          }
        }
        if (clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]].GetType() == typeof (buMaterialMoveable))
          ((buMaterialMoveable) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).xPos = pntMove.XPosition;
        if (clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]].GetType() == typeof (buMachinePart))
        {
          buMachinePart entity5 = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]] as buMachinePart;
          if (entityData.typeDefination == entityTypeDefination.MachineBody | entityData.typeDefination == entityTypeDefination.MachineParts)
          {
            string blockName = ((BlockReference) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).BlockName;
            double num3 = 0.0;
            if (entity5.No >= 0 & entity5.No <= 299)
              num3 = clsDrill.ToolPistonDownPos[entity5.No];
            if (blockName == "X1_Body" | blockName == "X1_Clamper")
            {
              if (blockName == "X1_Clamper")
                ;
              ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).xPos = pntMove.X1Clamper;
              ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = this.X1ClamperZOffset;
              Entity entity6 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
              entity6.Translate(pntMove.X1Clamper, 0.0, this.X1ClamperZOffset);
              entity6.Regen(new RegenParams(0.01, (IWorkspace) clsDrill.viewportAuto));
              if (blockName == "X1_Clamper")
                clsDrill.SimToCollsionCheck2.Add(entity6);
            }
            if (blockName == "X2_Body" | blockName == "X2_Clamper")
            {
              if (blockName == "X2_Clamper")
                ;
              ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).xPos = pntMove.X2Clamper;
              ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = this.X2ClamperZOffset;
              Entity entity7 = buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]);
              entity7.Translate(pntMove.X2Clamper, 0.0, this.X2ClamperZOffset);
              entity7.Regen(new RegenParams(0.01, (IWorkspace) clsDrill.viewportAuto));
              if (blockName == "X2_Clamper")
                clsDrill.SimToCollsionCheck2.Add(entity7);
            }
            if (blockName == "Y1_Body")
            {
              ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y1Position;
              buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).Translate(0.0, -pntMove.Y1Position);
            }
            if (blockName == "Y2_Body")
            {
              ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y2Position;
              buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).Translate(0.0, -pntMove.Y2Position);
            }
            if (blockName == "Y3_Body")
            {
              ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y3Position;
              buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).Translate(0.0, -pntMove.Y3Position);
            }
            if (entity5.Tag != null)
            {
              if (entity5.Tag == "Z1")
              {
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y1Position;
                if (blockName != "Z1_Milling")
                  ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z1Position + num3;
                else
                  ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z1Position + clsDrill.ToolPistonDownPos[80 /*0x50*/] + clsDrill.varDrillSettings.SimTopMillingOffset;
                buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).Translate(0.0, -pntMove.Y1Position, pntMove.Z1Position + num3);
              }
              if (entity5.Tag == "Z2")
              {
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y2Position;
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = pntMove.Z2Position + num3;
                buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).Translate(0.0, -pntMove.Y2Position, pntMove.Z2Position + num3);
              }
              if (entity5.Tag == "Z3")
              {
                ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).yPos = -pntMove.Y3Position;
                if (blockName != "Z3_Milling")
                  ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = -(pntMove.Z3Position + num3);
                else
                  ((buMachinePart) clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).zPos = -(pntMove.Z3Position + num3 + clsDrill.ToolPistonDownPos[270] + clsDrill.varDrillSettings.SimBottomMillinOffset);
                buVector5.CopyEntities(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[index]]).Translate(0.0, -pntMove.Y3Position, -(pntMove.Z3Position + num3));
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

  public void SetTools(int ToolNo)
  {
    if (ToolNo >= 61 & ToolNo <= 71)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonVerticalDistance;
    if (ToolNo >= 31 /*0x1F*/ & ToolNo <= 36)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
    if (ToolNo == 85)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonSawDistance;
    if (ToolNo >= 161 & ToolNo <= 171)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonVerticalDistance;
    if (ToolNo == 185)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonSawDistance;
    if (ToolNo == 41)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolBottomSpindlePistonDistance;
    if (ToolNo >= 261 & ToolNo <= 269)
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonVerticalDistance;
    if (ToolNo == 72 | ToolNo == 74 | ToolNo == 76 | ToolNo == 78 | ToolNo == 172 | ToolNo == 174 | ToolNo == 176 /*0xB0*/ | ToolNo == 178)
    {
      clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
      clsDrill.ToolPistonDownPos[ToolNo + 1] = -clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
    }
    if (!(ToolNo == 73 | ToolNo == 75 | ToolNo == 77 | ToolNo == 79 | ToolNo == 173 | ToolNo == 175 | ToolNo == 177 | ToolNo == 179))
      return;
    clsDrill.ToolPistonDownPos[ToolNo] = -clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
    clsDrill.ToolPistonDownPos[ToolNo - 1] = -clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
  }

  public void ResetTools(int ToolNo)
  {
    if (!(ToolNo >= 0 & ToolNo <= 299))
      return;
    clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
    if (ToolNo == 72 | ToolNo == 74 | ToolNo == 76 | ToolNo == 78 | ToolNo == 172 | ToolNo == 174 | ToolNo == 176 /*0xB0*/ | ToolNo == 178)
    {
      clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
      clsDrill.ToolPistonDownPos[ToolNo + 1] = 0.0;
    }
    if (!(ToolNo == 73 | ToolNo == 75 | ToolNo == 77 | ToolNo == 79 | ToolNo == 173 | ToolNo == 175 | ToolNo == 177 | ToolNo == 179))
      return;
    clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
    clsDrill.ToolPistonDownPos[ToolNo - 1] = 0.0;
  }

  public void FindHolesForFrontSide()
  {
    double num1 = clsDrill.varDrillCNCSettings.Y1MinLimit;
    if (clsDrill.activeJob.Material.Size.Height > clsDrill.varDrillCNCSettings.DoubleHeadWorkTogetherLimit)
      num1 = clsDrill.activeJob.Material.Size.Height / 2.0;
    for (int index1 = 0; index1 <= this.SplitedItems.lstFront.Count - 1; ++index1)
    {
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstFront[index1];
      List<DrillCalcItem> drillCalcItemList2 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
        {
          if (drillCalcItemList1[index2].Center.Y < clsDrill.activeJob.Material.Size.Height)
          {
            if (drillCalcItemList1[index2].Center.Y >= num1)
              drillCalcItemList2.Add(new DrillCalcItem(drillCalcItemList1[index2]));
            else
              drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
          }
          else
            drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
        }
      }
      if (drillCalcItemList2.Count > 0)
        drillCalcItemList2 = clsDrill.varDrillCNCSettings.MirrorCalculationForFront ? this.SortByYDistance(drillCalcItemList2, new DrillCalcItem(), SortDirection.BiggerToLower) : this.SortByYDistance(drillCalcItemList2, new DrillCalcItem(), SortDirection.LowerToBigger);
      if (drillCalcItemList3.Count > 0)
        drillCalcItemList3 = this.SortByYDistance(drillCalcItemList3, new DrillCalcItem(), SortDirection.LowerToBigger);
      int count = drillCalcItemList2.Count;
      if (drillCalcItemList3.Count > count)
        count = drillCalcItemList3.Count;
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
      if (drillCalcItemList3.Count >= 2 && clsInit.cDrill.isMultiZAvailable(drillCalcItemList3))
      {
        List<List<DrillCalcItem>> SplitedItems = new List<List<DrillCalcItem>>();
        clsInit.cDrill.SplitDrillsByYDistanceThenSortZDir(drillCalcItemList3, SortDirection.LowerToBigger, ref SplitedItems);
        if (SplitedItems.Count > 0)
        {
          drillCalcItemList3 = new List<DrillCalcItem>();
          for (int index5 = 0; index5 <= SplitedItems.Count - 1; ++index5)
          {
            for (int index6 = 0; index6 <= SplitedItems[index5].Count - 1; ++index6)
              drillCalcItemList3.Add(new DrillCalcItem(SplitedItems[index5][index6]));
          }
        }
      }
      for (int index7 = 0; index7 <= count - 1; ++index7)
      {
        DrillFound Found = new DrillFound();
        for (int index8 = 0; index8 <= clsDrill.ToolList.Count - 1; ++index8)
          clsDrill.ToolList[index8].Data.Used = false;
        List<int> Y1GroupTool = new List<int>();
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
        FindToolSettings Settings = new FindToolSettings();
        Settings.Plane = planeBoxNames.Front;
        Settings.SetAsUsed = true;
        ToolBase5 foundTool1 = (ToolBase5) null;
        ToolBase5 foundTool2 = (ToolBase5) null;
        if (index7 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0 && !drillCalcItemList3[index7].Calculated)
        {
          if (drillCalcItemList3[index7].NumberNextVerticalItem > 0)
            Settings.SelectVerticalTools = true;
          int Count = 0;
          clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList3, drillCalcItemList3[index7], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index7, ref Count);
          this.FindToolFromBlock(drillCalcItemList3[index7], 1, Settings, SortDirection.BiggerToLower, ref foundTool2);
          if (foundTool2 != null)
          {
            if (this.SetValueToAvailableTool(foundTool2.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList3[index7].Calculated = true;
              drillCalcItemList3[index7].OffsetedPoint.Y = drillCalcItemList3[index7].Center.Y - foundTool2.Positions.Offset.Y;
              drillCalcItemList3[index7].HeadNo = 2;
              DrillFound.Add(drillCalcItemList3[index7], foundTool2.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool2.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index7].ID);
            }
            else
              this.calcErrorList.Add($"Top Surface Y2 Group Tool Set Limit Full - Tool No : {foundTool2.Data.No.ToString()} - Position : {drillCalcItemList3[index7].Center.ToString()}");
          }
          if (foundTool2 != null)
          {
            for (int index9 = index7 + 1; index9 <= drillCalcItemList3.Count - 1; ++index9)
            {
              double num2 = drillCalcItemList3[index9].Center.Y - drillCalcItemList3[index7].Center.Y;
              double num3 = num2 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
              if (num2 > 0.0 & !drillCalcItemList3[index9].Calculated & buCompare5.EQ(num3, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList3[index7], drillCalcItemList3[index9]))
              {
                for (int index10 = 0; index10 <= clsDrill.ToolList.Count - 1; ++index10)
                {
                  if (foundTool2.Data.GroupIndex == clsDrill.ToolList[index10].Data.GroupIndex & !clsDrill.ToolList[index10].Data.Used & clsDrill.ToolList[index10].Geometry.Diameter == drillCalcItemList3[index9].Diameter & clsDrill.ToolList[index10].Geometry.ToolDirection.X == -1.0 && buCompare5.EQ(clsDrill.ToolList[index10].Positions.Offset.Y - foundTool2.Positions.Offset.Y, num2, 0.05))
                  {
                    int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index10].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref intList, ref intList);
                    if (availableTool > 0)
                    {
                      drillCalcItemList3[index9].HeadNo = 2;
                      drillCalcItemList3[index9].OffsetedPoint.Y = drillCalcItemList3[index9].Center.Y - clsDrill.ToolList[index10].Positions.Offset.Y;
                      drillCalcItemList3[index9].Calculated = true;
                      clsDrill.ToolList[index10].Data.Used = true;
                      DrillFound.Add(drillCalcItemList3[index9], clsDrill.ToolList[index10].Data.No, ref Found);
                      this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index9].ID);
                    }
                    if (availableTool < 1)
                      this.calcErrorList.Add($"Top Surface Y2 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index10].Data.No.ToString()} - Position : {drillCalcItemList3[index9].Center.ToString()}");
                    index10 = clsDrill.ToolList.Count;
                  }
                }
              }
            }
          }
        }
        if (index7 <= drillCalcItemList2.Count - 1 & drillCalcItemList2.Count > 0 && !drillCalcItemList2[index7].Calculated)
        {
          int Count = 0;
          clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList2, drillCalcItemList2[index7], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index7, ref Count);
          if (!clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
            this.FindToolFromBlock(drillCalcItemList2[index7], 0, Settings, ref foundTool1);
          else
            this.FindToolFromBlock(drillCalcItemList2[index7], 0, Settings, SortDirection.BiggerToLower, ref foundTool1);
          if (foundTool1 != null)
          {
            if (this.SetValueToAvailableTool(foundTool1.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList2[index7].Calculated = true;
              drillCalcItemList2[index7].OffsetedPoint.Y = drillCalcItemList2[index7].Center.Y - foundTool1.Positions.Offset.Y;
              drillCalcItemList2[index7].HeadNo = 1;
              DrillFound.Add(drillCalcItemList2[index7], foundTool1.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool1.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList2[index7].ID);
            }
            else
              this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {foundTool1.Data.No.ToString()} - Position : {drillCalcItemList2[index7].Center.ToString()}");
          }
          if (foundTool1 != null)
          {
            for (int index11 = index7 + 1; index11 <= drillCalcItemList2.Count - 1; ++index11)
            {
              double num4 = drillCalcItemList2[index11].Center.Y - drillCalcItemList2[index7].Center.Y;
              if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
                num4 = drillCalcItemList2[index7].Center.Y - drillCalcItemList2[index11].Center.Y;
              double num5 = num4 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
              if (num4 > 0.0 & !drillCalcItemList2[index11].Calculated & buCompare5.EQ(num5, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList2[index7], drillCalcItemList2[index11]))
              {
                for (int index12 = 0; index12 <= clsDrill.ToolList.Count - 1; ++index12)
                {
                  if (foundTool1.Data.GroupIndex == clsDrill.ToolList[index12].Data.GroupIndex & !clsDrill.ToolList[index12].Data.Used & clsDrill.ToolList[index12].Geometry.Diameter == drillCalcItemList2[index11].Diameter & clsDrill.ToolList[index12].Geometry.ToolDirection.X == -1.0)
                  {
                    double num6 = clsDrill.ToolList[index12].Positions.Offset.Y - foundTool1.Positions.Offset.Y;
                    if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
                      num6 = foundTool1.Positions.Offset.Y - clsDrill.ToolList[index12].Positions.Offset.Y;
                    if (buCompare5.EQ(num6, num4, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index12].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref intList);
                      if (availableTool > 0)
                      {
                        drillCalcItemList2[index11].Calculated = true;
                        drillCalcItemList2[index11].OffsetedPoint.Y = drillCalcItemList2[index11].Center.Y - clsDrill.ToolList[index12].Positions.Offset.Y;
                        drillCalcItemList2[index11].HeadNo = 1;
                        clsDrill.ToolList[index12].Data.Used = true;
                        DrillFound.Add(drillCalcItemList2[index11], clsDrill.ToolList[index12].Data.No, ref Found);
                        this.SetAsCalculatedDrillItemByID(drillCalcItemList2[index11].ID);
                      }
                      if (availableTool < 1)
                        this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index12].Data.No.ToString()} - Position : {drillCalcItemList2[index11].Center.ToString()}");
                      index12 = clsDrill.ToolList.Count;
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
    double num1 = clsDrill.varDrillCNCSettings.Y1MinLimit;
    if (clsDrill.activeJob.Material.Size.Height > clsDrill.varDrillCNCSettings.DoubleHeadWorkTogetherLimit)
      num1 = clsDrill.activeJob.Material.Size.Height / 2.0;
    for (int index1 = 0; index1 <= this.SplitedItems.lstBack.Count - 1; ++index1)
    {
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstBack[index1];
      List<DrillCalcItem> drillCalcItemList2 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
        {
          if (drillCalcItemList1[index2].Center.Y < clsDrill.activeJob.Material.Size.Height)
          {
            if (drillCalcItemList1[index2].Center.Y >= num1)
              drillCalcItemList2.Add(new DrillCalcItem(drillCalcItemList1[index2]));
            else
              drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
          }
          else
            drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
        }
      }
      if (drillCalcItemList2.Count > 0)
        drillCalcItemList2 = clsDrill.varDrillCNCSettings.MirrorCalculationForBack ? this.SortByYDistance(drillCalcItemList2, new DrillCalcItem(), SortDirection.BiggerToLower) : this.SortByYDistance(drillCalcItemList2, new DrillCalcItem(), SortDirection.LowerToBigger);
      if (drillCalcItemList3.Count > 0)
        drillCalcItemList3 = this.SortByYDistance(drillCalcItemList3, new DrillCalcItem(), SortDirection.LowerToBigger);
      int count = drillCalcItemList2.Count;
      if (drillCalcItemList3.Count > count)
        count = drillCalcItemList3.Count;
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
      if (drillCalcItemList3.Count >= 2 && clsInit.cDrill.isMultiZAvailable(drillCalcItemList3))
      {
        List<List<DrillCalcItem>> SplitedItems = new List<List<DrillCalcItem>>();
        clsInit.cDrill.SplitDrillsByYDistanceThenSortZDir(drillCalcItemList3, SortDirection.LowerToBigger, ref SplitedItems);
        if (SplitedItems.Count > 0)
        {
          drillCalcItemList3 = new List<DrillCalcItem>();
          for (int index5 = 0; index5 <= SplitedItems.Count - 1; ++index5)
          {
            for (int index6 = 0; index6 <= SplitedItems[index5].Count - 1; ++index6)
              drillCalcItemList3.Add(new DrillCalcItem(SplitedItems[index5][index6]));
          }
        }
      }
      for (int index7 = 0; index7 <= count - 1; ++index7)
      {
        DrillFound Found = new DrillFound();
        for (int index8 = 0; index8 <= clsDrill.ToolList.Count - 1; ++index8)
          clsDrill.ToolList[index8].Data.Used = false;
        List<int> Y1GroupTool = new List<int>();
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
        FindToolSettings Settings = new FindToolSettings();
        Settings.Plane = planeBoxNames.Back;
        Settings.SetAsUsed = true;
        ToolBase5 foundTool1 = (ToolBase5) null;
        ToolBase5 foundTool2 = (ToolBase5) null;
        if (index7 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0 && !drillCalcItemList3[index7].Calculated)
        {
          int Count = 0;
          clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList3, drillCalcItemList3[index7], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index7, ref Count);
          this.FindToolFromBlock(drillCalcItemList3[index7], 1, Settings, SortDirection.BiggerToLower, ref foundTool2);
          if (foundTool2 != null)
          {
            if (this.SetValueToAvailableTool(foundTool2.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList3[index7].Calculated = true;
              drillCalcItemList3[index7].OffsetedPoint.Y = drillCalcItemList3[index7].Center.Y - foundTool2.Positions.Offset.Y;
              drillCalcItemList3[index7].HeadNo = 2;
              DrillFound.Add(drillCalcItemList3[index7], foundTool2.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool2.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index7].ID);
            }
            else
              this.calcErrorList.Add($"Top Surface Y2 Group Tool Set Limit Full - Tool No : {foundTool2.Data.No.ToString()} - Position : {drillCalcItemList3[index7].Center.ToString()}");
          }
          if (foundTool2 != null)
          {
            for (int index9 = index7 + 1; index9 <= drillCalcItemList3.Count - 1; ++index9)
            {
              double num2 = drillCalcItemList3[index9].Center.Y - drillCalcItemList3[index7].Center.Y;
              double num3 = num2 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
              if (num2 > 0.0 & !drillCalcItemList3[index9].Calculated & buCompare5.EQ(num3, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList3[index7], drillCalcItemList3[index9]))
              {
                for (int index10 = 0; index10 <= clsDrill.ToolList.Count - 1; ++index10)
                {
                  if (foundTool2.Data.GroupIndex == clsDrill.ToolList[index10].Data.GroupIndex & !clsDrill.ToolList[index10].Data.Used & clsDrill.ToolList[index10].Geometry.Diameter == drillCalcItemList3[index9].Diameter & clsDrill.ToolList[index10].Geometry.ToolDirection.X == 1.0 && buCompare5.EQ(clsDrill.ToolList[index10].Positions.Offset.Y - foundTool2.Positions.Offset.Y, num2, 0.05))
                  {
                    int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index10].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref intList, ref intList);
                    if (availableTool > 0)
                    {
                      drillCalcItemList3[index9].OffsetedPoint.Y = drillCalcItemList3[index9].Center.Y - clsDrill.ToolList[index10].Positions.Offset.Y;
                      drillCalcItemList3[index9].HeadNo = 2;
                      drillCalcItemList3[index9].Calculated = true;
                      clsDrill.ToolList[index10].Data.Used = true;
                      DrillFound.Add(drillCalcItemList3[index9], clsDrill.ToolList[index10].Data.No, ref Found);
                      this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index9].ID);
                    }
                    if (availableTool < 1)
                      this.calcErrorList.Add($"Top Surface Y2 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index10].Data.No.ToString()} - Position : {drillCalcItemList3[index9].Center.ToString()}");
                    index10 = clsDrill.ToolList.Count;
                  }
                }
              }
            }
          }
        }
        if (index7 <= drillCalcItemList2.Count - 1 & drillCalcItemList2.Count > 0 && !drillCalcItemList2[index7].Calculated)
        {
          int Count = 0;
          clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList2, drillCalcItemList2[index7], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index7, ref Count);
          if (!clsDrill.varDrillCNCSettings.MirrorCalculationForBack)
            this.FindToolFromBlock(drillCalcItemList2[index7], 0, Settings, ref foundTool1);
          else
            this.FindToolFromBlock(drillCalcItemList2[index7], 0, Settings, SortDirection.BiggerToLower, ref foundTool1);
          if (foundTool1 != null)
          {
            if (this.SetValueToAvailableTool(foundTool1.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList2[index7].Calculated = true;
              drillCalcItemList2[index7].OffsetedPoint.Y = drillCalcItemList2[index7].Center.Y - foundTool1.Positions.Offset.Y;
              drillCalcItemList2[index7].HeadNo = 1;
              DrillFound.Add(drillCalcItemList2[index7], foundTool1.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool1.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList2[index7].ID);
            }
            else
              this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {foundTool1.Data.No.ToString()} - Position : {drillCalcItemList2[index7].Center.ToString()}");
          }
          if (foundTool1 != null)
          {
            for (int index11 = index7 + 1; index11 <= drillCalcItemList2.Count - 1; ++index11)
            {
              double num4 = drillCalcItemList2[index11].Center.Y - drillCalcItemList2[index7].Center.Y;
              if (clsDrill.varDrillCNCSettings.MirrorCalculationForBack)
                num4 = drillCalcItemList2[index7].Center.Y - drillCalcItemList2[index11].Center.Y;
              double num5 = num4 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
              if (num4 > 0.0 & !drillCalcItemList2[index11].Calculated & buCompare5.EQ(num5, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList2[index7], drillCalcItemList2[index11]))
              {
                for (int index12 = 0; index12 <= clsDrill.ToolList.Count - 1; ++index12)
                {
                  if (foundTool1.Data.GroupIndex == clsDrill.ToolList[index12].Data.GroupIndex & !clsDrill.ToolList[index12].Data.Used & clsDrill.ToolList[index12].Geometry.Diameter == drillCalcItemList2[index11].Diameter & clsDrill.ToolList[index12].Geometry.ToolDirection.X == 1.0)
                  {
                    double num6 = clsDrill.ToolList[index12].Positions.Offset.Y - foundTool1.Positions.Offset.Y;
                    if (clsDrill.varDrillCNCSettings.MirrorCalculationForBack)
                      num6 = foundTool1.Positions.Offset.Y - clsDrill.ToolList[index12].Positions.Offset.Y;
                    if (buCompare5.EQ(num6, num4, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index12].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref intList);
                      if (availableTool > 0)
                      {
                        drillCalcItemList2[index11].Calculated = true;
                        drillCalcItemList2[index11].OffsetedPoint.Y = drillCalcItemList2[index11].Center.Y - clsDrill.ToolList[index12].Positions.Offset.Y;
                        drillCalcItemList2[index11].HeadNo = 1;
                        clsDrill.ToolList[index12].Data.Used = true;
                        DrillFound.Add(drillCalcItemList2[index11], clsDrill.ToolList[index12].Data.No, ref Found);
                        this.SetAsCalculatedDrillItemByID(drillCalcItemList2[index11].ID);
                      }
                      if (availableTool < 1)
                        this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index12].Data.No.ToString()} - Position : {drillCalcItemList2[index11].Center.ToString()}");
                      index12 = clsDrill.ToolList.Count;
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

  public void FindHolesForTopSide()
  {
    double num1 = clsDrill.varDrillCNCSettings.Y1MinLimit;
    if (clsDrill.activeJob.Material.Size.Height > clsDrill.varDrillCNCSettings.DoubleHeadWorkTogetherLimit)
      num1 = clsDrill.activeJob.Material.Size.Height / 2.0;
    for (int index1 = 0; index1 <= this.SplitedItems.lstTop.Count - 1; ++index1)
    {
      bool flag1 = true;
      bool flag2 = true;
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstTop[index1];
      List<DrillCalcItem> drillCalcItemList2 = (List<DrillCalcItem>) null;
      if (index1 < this.SplitedItems.lstTop.Count - 1)
        drillCalcItemList2 = this.SplitedItems.lstTop[index1 + 1];
      List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList4 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList5 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList6 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
        {
          if (drillCalcItemList1[index2].Center.Y < clsDrill.activeJob.Material.Size.Height)
          {
            if (drillCalcItemList1[index2].Center.Y >= num1)
              drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
            else
              drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList1[index2]));
          }
          else
            drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList1[index2]));
        }
      }
      if (drillCalcItemList2 != null)
      {
        for (int index3 = 0; index3 <= drillCalcItemList2.Count - 1; ++index3)
        {
          if (!drillCalcItemList2[index3].Calculated)
          {
            if (drillCalcItemList2[index3].Center.Y < clsDrill.activeJob.Material.Size.Height)
            {
              if (drillCalcItemList2[index3].Center.Y >= num1)
                drillCalcItemList5.Add(new DrillCalcItem(drillCalcItemList2[index3]));
              else
                drillCalcItemList6.Add(new DrillCalcItem(drillCalcItemList2[index3]));
            }
            else
              drillCalcItemList6.Add(new DrillCalcItem(drillCalcItemList2[index3]));
          }
        }
      }
      if (drillCalcItemList3.Count > 0)
        drillCalcItemList3 = clsDrill.varDrillCNCSettings.MirrorCalculationForTop ? this.SortByYDistance(drillCalcItemList3, new DrillCalcItem(), SortDirection.BiggerToLower) : this.SortByYDistance(drillCalcItemList3, new DrillCalcItem(), SortDirection.LowerToBigger);
      if (drillCalcItemList4.Count > 0)
        drillCalcItemList4 = this.SortByYDistance(drillCalcItemList4, new DrillCalcItem(), SortDirection.LowerToBigger);
      int count = drillCalcItemList3.Count;
      if (drillCalcItemList4.Count > count)
        count = drillCalcItemList4.Count;
      for (int index4 = 0; index4 <= count - 1; ++index4)
      {
        DrillFound Found = new DrillFound();
        for (int index5 = 0; index5 <= clsDrill.ToolList.Count - 1; ++index5)
          clsDrill.ToolList[index5].Data.Used = false;
        List<int> Y1GroupTool = new List<int>();
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
        int Count1 = 0;
        int Count2 = 0;
        bool flag3 = true;
        FindToolSettings Settings = new FindToolSettings();
        Settings.Plane = planeBoxNames.Top;
        Settings.SetAsUsed = true;
        ToolBase5 foundTool1 = (ToolBase5) null;
        ToolBase5 foundTool2 = (ToolBase5) null;
        if (index4 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0)
        {
          bool flag4 = true;
          if (!drillCalcItemList3[index4].Calculated)
          {
            if (drillCalcItemList3[index4].NumberNextVerticalItem > 0)
              Settings.SelectVerticalTools = true;
            double MaxYDistance = 0.0;
            clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList3, drillCalcItemList3[index4], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index4, ref Count1, ref MaxYDistance);
            clsInit.cDrill.isVerticalDrillAvailable(drillCalcItemList3[index4], this.SplitedItems.lstTop, clsDrill.varDrillCNCSettings.ToolRepeatDistance, index1, ref Count2);
            if (Count1 > 0)
            {
              Convert.ToInt32(MaxYDistance / clsDrill.varDrillCNCSettings.ToolRepeatDistance);
              Settings.StartToolIndex = !clsDrill.varDrillCNCSettings.MirrorCalculationForTop ? 66 : 61;
              if (clsDrill.varDrillCNCSettings.MirrorCalculationForTop)
                this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.LowerToBigger, ref foundTool1);
              else
                this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.BiggerToLower, ref foundTool1);
            }
            else if (Count2 > 0)
            {
              Settings.StartToolIndex = 66;
              this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.LowerToBigger, ref foundTool1);
            }
            else
            {
              Settings.StartToolIndex = 66;
              this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.LowerToBigger, ref foundTool1);
              if (foundTool1 == null)
                this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, SortDirection.BiggerToLower, ref foundTool1);
            }
            if (foundTool1 == null)
            {
              Settings.StartToolIndex = 60;
              this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, ref foundTool1);
            }
            if (foundTool1 != null)
            {
              if (this.SetValueToAvailableTool(foundTool1.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
              {
                drillCalcItemList3[index4].Calculated = true;
                drillCalcItemList3[index4].HeadNo = 1;
                drillCalcItemList3[index4].OffsetedPoint.Y = drillCalcItemList3[index4].Center.Y - foundTool1.Positions.Offset.Y;
                DrillFound.Add(drillCalcItemList3[index4], foundTool1.Data.No, ref Found);
                this.SetAsUsedToolByNo(foundTool1.Data.No, ref clsDrill.ToolList);
                this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index4].ID);
              }
              else
                this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {foundTool1.Data.No.ToString()} - Position : {drillCalcItemList3[index4].Center.ToString()}");
            }
            if (foundTool1 != null)
            {
              for (int index6 = index4 + 1; index6 <= drillCalcItemList3.Count - 1; ++index6)
              {
                double num2 = drillCalcItemList3[index6].Center.Y - drillCalcItemList3[index4].Center.Y;
                if (!flag1)
                  num2 = drillCalcItemList3[index4].Center.Y - drillCalcItemList3[index6].Center.Y;
                if (buCompare5.EQ(num2 % clsDrill.varDrillCNCSettings.ToolRepeatDistance, 0.0, 0.05) & !drillCalcItemList3[index6].Calculated & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList3[index4], drillCalcItemList3[index6]))
                {
                  for (int index7 = 0; index7 <= clsDrill.ToolList.Count - 1; ++index7)
                  {
                    if (foundTool1.Data.GroupIndex == clsDrill.ToolList[index7].Data.GroupIndex & !clsDrill.ToolList[index7].Data.Used & clsDrill.ToolList[index7].Geometry.Diameter == drillCalcItemList3[index6].Diameter & clsDrill.ToolList[index7].Geometry.ToolDirection.Z == -1.0)
                    {
                      double num3 = clsDrill.ToolList[index7].Positions.Offset.Y - foundTool1.Positions.Offset.Y;
                      if (clsDrill.varDrillCNCSettings.MirrorCalculationForTop)
                        num3 = clsDrill.ToolList[index7].Positions.Offset.Y - foundTool1.Positions.Offset.Y;
                      if (buCompare5.EQ(num3, num2, 0.05))
                      {
                        int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index7].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref intList);
                        if (availableTool > 0)
                        {
                          drillCalcItemList3[index6].Calculated = true;
                          drillCalcItemList3[index6].HeadNo = 1;
                          drillCalcItemList3[index6].OffsetedPoint.Y = drillCalcItemList3[index6].Center.Y - clsDrill.ToolList[index7].Positions.Offset.Y;
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
            }
            if (Count1 > 0 & !clsDrill.varDrillCNCSettings.SearchVerToolEvenMultiHorDrillAvailableForTop)
              flag4 = false;
            if (foundTool1 != null & Count2 > 0 & flag4 && drillCalcItemList3.Count > 0)
            {
              List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
              clsInit.cDrill.FindNextVerticalDrill(this.SplitedItems.lstTop, drillCalcItemList3[index4], index1 + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems);
              for (int index8 = 0; index8 <= foundItems.Count - 1; ++index8)
              {
                double num4 = foundItems[index8].Center.X - drillCalcItemList3[index4].Center.X;
                for (int index9 = 0; index9 <= clsDrill.ToolList.Count - 1; ++index9)
                {
                  if (!foundItems[index8].Calculated & foundTool1.Data.GroupIndex == clsDrill.ToolList[index9].Data.GroupIndex & !clsDrill.ToolList[index9].Data.Used & clsDrill.ToolList[index9].Geometry.Diameter == foundItems[index8].Diameter & clsDrill.ToolList[index9].Geometry.ToolDirection.Z == -1.0)
                  {
                    double num5 = foundTool1.Positions.Offset.X - clsDrill.ToolList[index9].Positions.Offset.X;
                    double num6 = foundTool1.Positions.Offset.Y - clsDrill.ToolList[index9].Positions.Offset.Y;
                    if (buCompare5.EQ(num4, num5, 0.05) & buCompare5.EQ(num6, 0.0, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index9].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref intList);
                      if (availableTool > 0)
                      {
                        foundItems[index8].HeadNo = 1;
                        foundItems[index8].OffsetedPoint.Y = foundItems[index8].Center.Y - clsDrill.ToolList[index9].Positions.Offset.Y;
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
        if (index4 <= drillCalcItemList4.Count - 1 & drillCalcItemList4.Count > 0)
        {
          flag3 = true;
          if (!drillCalcItemList4[index4].Calculated)
          {
            if (drillCalcItemList4[index4].NumberNextVerticalItem > 0)
              Settings.SelectVerticalTools = true;
            int Count3 = 0;
            int Count4 = 0;
            double MaxYDistance = 0.0;
            clsInit.cDrill.isHorizontalDrillAvailabe(drillCalcItemList4, drillCalcItemList4[index4], clsDrill.varDrillCNCSettings.ToolRepeatDistance, index4, ref Count3, ref MaxYDistance);
            clsInit.cDrill.isVerticalDrillAvailable(drillCalcItemList4[index4], this.SplitedItems.lstTop, clsDrill.varDrillCNCSettings.ToolRepeatDistance, index1, ref Count4);
            if (Count4 > 0 & Count3 == 0)
              Settings.StartToolIndex = 166;
            if (Count3 > 0)
            {
              Convert.ToInt32(MaxYDistance / clsDrill.varDrillCNCSettings.ToolRepeatDistance);
              Settings.StartToolIndex = 161;
            }
            this.FindToolFromBlock(drillCalcItemList4[index4], 1, Settings, ref foundTool2);
            if (foundTool2 == null)
            {
              Settings.StartToolIndex = 160 /*0xA0*/;
              this.FindToolFromBlock(drillCalcItemList4[index4], 1, Settings, ref foundTool2);
            }
            if (foundTool2 != null)
            {
              if (this.SetValueToAvailableTool(foundTool2.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
              {
                drillCalcItemList4[index4].Calculated = true;
                drillCalcItemList4[index4].HeadNo = 2;
                drillCalcItemList4[index4].OffsetedPoint.Y = drillCalcItemList4[index4].Center.Y - foundTool2.Positions.Offset.Y;
                DrillFound.Add(drillCalcItemList4[index4], foundTool2.Data.No, ref Found);
                this.SetAsUsedToolByNo(foundTool2.Data.No, ref clsDrill.ToolList);
                this.SetAsCalculatedDrillItemByID(drillCalcItemList4[index4].ID);
              }
              else
                this.calcErrorList.Add($"Top Surface Y2 Group Tool Set Limit Full - Tool No : {foundTool2.Data.No.ToString()} - Position : {drillCalcItemList4[index4].Center.ToString()}");
            }
            if (foundTool2 != null)
            {
              for (int index10 = index4 + 1; index10 <= drillCalcItemList4.Count - 1; ++index10)
              {
                double num7 = drillCalcItemList4[index10].Center.Y - drillCalcItemList4[index4].Center.Y;
                if (!flag2)
                  num7 = drillCalcItemList4[index4].Center.Y - drillCalcItemList4[index10].Center.Y;
                if (buCompare5.EQ(num7 % clsDrill.varDrillCNCSettings.ToolRepeatDistance, 0.0, 0.05) & !drillCalcItemList4[index10].Calculated & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList4[index4], drillCalcItemList4[index10]))
                {
                  for (int index11 = 0; index11 <= clsDrill.ToolList.Count - 1; ++index11)
                  {
                    if (foundTool2.Data.GroupIndex == clsDrill.ToolList[index11].Data.GroupIndex & !clsDrill.ToolList[index11].Data.Used & clsDrill.ToolList[index11].Geometry.Diameter == drillCalcItemList4[index10].Diameter & clsDrill.ToolList[index11].Geometry.ToolDirection.Z == -1.0)
                    {
                      double num8 = clsDrill.ToolList[index11].Positions.Offset.Y - foundTool2.Positions.Offset.Y;
                      if (foundTool2.Data.No < clsDrill.ToolList[index11].Data.No)
                        ;
                      if (buCompare5.EQ(num8, num7, 0.05))
                      {
                        int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index11].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref intList, ref intList);
                        if (availableTool > 0)
                        {
                          drillCalcItemList4[index10].Calculated = true;
                          drillCalcItemList4[index10].HeadNo = 2;
                          drillCalcItemList4[index10].OffsetedPoint.Y = drillCalcItemList4[index10].Center.Y - clsDrill.ToolList[index11].Positions.Offset.Y;
                          clsDrill.ToolList[index11].Data.Used = true;
                          DrillFound.Add(drillCalcItemList4[index10], clsDrill.ToolList[index11].Data.No, ref Found);
                          this.SetAsCalculatedDrillItemByID(drillCalcItemList4[index10].ID);
                        }
                        if (availableTool < 1)
                          this.calcErrorList.Add($"Top Surface Y2 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index11].Data.No.ToString()} - Position : {drillCalcItemList4[index10].Center.ToString()}");
                        index11 = clsDrill.ToolList.Count;
                      }
                    }
                  }
                }
              }
            }
            if (Count3 > 0 & !clsDrill.varDrillCNCSettings.SearchVerToolEvenMultiHorDrillAvailableForTop)
              flag3 = false;
            if (foundTool2 != null & Count4 > 0 & Count3 == 0 && drillCalcItemList4.Count > 0)
            {
              List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
              clsInit.cDrill.FindNextVerticalDrill(this.SplitedItems.lstTop, drillCalcItemList4[index4], index1 + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems);
              for (int index12 = 0; index12 <= foundItems.Count - 1; ++index12)
              {
                double num9 = foundItems[index12].Center.X - drillCalcItemList4[index4].Center.X;
                double num10 = foundItems[index12].Center.Y - drillCalcItemList4[index4].Center.Y;
                for (int index13 = 0; index13 <= clsDrill.ToolList.Count - 1; ++index13)
                {
                  if (!foundItems[index12].Calculated & foundTool2.Data.GroupIndex == clsDrill.ToolList[index13].Data.GroupIndex & !clsDrill.ToolList[index13].Data.Used & clsDrill.ToolList[index13].Geometry.Diameter == foundItems[index12].Diameter & clsDrill.ToolList[index13].Geometry.ToolDirection.Z == -1.0)
                  {
                    double num11 = foundTool2.Positions.Offset.X - clsDrill.ToolList[index13].Positions.Offset.X;
                    double num12 = foundTool2.Positions.Offset.Y - clsDrill.ToolList[index13].Positions.Offset.Y;
                    if (buCompare5.EQ(num9, num11, 0.05) & buCompare5.EQ(num10, num12, 0.05))
                    {
                      int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index13].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref intList, ref intList);
                      if (availableTool > 0)
                      {
                        foundItems[index12].HeadNo = 2;
                        foundItems[index12].OffsetedPoint.Y = foundItems[index12].Center.Y - clsDrill.ToolList[index13].Positions.Offset.Y;
                        DrillFound.Add(foundItems[index12], clsDrill.ToolList[index13].Data.No, ref Found);
                        this.SetAsCalculatedDrillItemByID(foundItems[index12].ID);
                        clsDrill.ToolList[index13].Data.Used = true;
                      }
                      if (availableTool < 1)
                        this.calcErrorList.Add($"Top Surface Y2 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index13].Data.No.ToString()} - Position : {foundItems[index12].Center.ToString()}");
                      index13 = clsDrill.ToolList.Count;
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
                if (buCompare5.EQ(num % clsDrill.varDrillCNCSettings.ToolRepeatDistance, 0.0, 0.05) & !drillCalcItemList3[index6].Calculated & clsInit.cDrill.isDrillSameForSameLine(drillCalcItemList3[index4], drillCalcItemList3[index6]))
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

  public void FindHolesForLeftRightSide()
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstLeftRight.Count - 1; ++index1)
    {
      List<DrillCalcItem> drillCalcItemList1 = this.SplitedItems.lstLeftRight[index1];
      List<DrillCalcItem> drillCalcItemList2 = (List<DrillCalcItem>) null;
      if (index1 < this.SplitedItems.lstLeftRight.Count - 1)
        drillCalcItemList2 = this.SplitedItems.lstLeftRight[index1 + 1];
      List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList4 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList5 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList6 = new List<DrillCalcItem>();
      for (int index2 = 0; index2 <= drillCalcItemList1.Count - 1; ++index2)
      {
        if (!drillCalcItemList1[index2].Calculated)
        {
          if (drillCalcItemList1[index2].planeName == planeBoxNames.Left)
            drillCalcItemList4.Add(new DrillCalcItem(drillCalcItemList1[index2]));
          else
            drillCalcItemList3.Add(new DrillCalcItem(drillCalcItemList1[index2]));
        }
      }
      if (drillCalcItemList2 != null)
      {
        for (int index3 = 0; index3 <= drillCalcItemList2.Count - 1; ++index3)
        {
          if (!drillCalcItemList2[index3].Calculated)
          {
            if (drillCalcItemList2[index3].planeName == planeBoxNames.Left)
              drillCalcItemList6.Add(new DrillCalcItem(drillCalcItemList2[index3]));
            else
              drillCalcItemList5.Add(new DrillCalcItem(drillCalcItemList2[index3]));
          }
        }
      }
      int count = drillCalcItemList3.Count;
      if (drillCalcItemList4.Count > count)
        count = drillCalcItemList4.Count;
      for (int index4 = 0; index4 <= count - 1; ++index4)
      {
        DrillFound Found = new DrillFound();
        for (int index5 = 0; index5 <= clsDrill.ToolList.Count - 1; ++index5)
          clsDrill.ToolList[index5].Data.Used = false;
        List<int> Y1GroupTool = new List<int>();
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
        ToolBase5 foundTool1 = (ToolBase5) null;
        ToolBase5 foundTool2 = (ToolBase5) null;
        Settings.Plane = planeBoxNames.Right;
        if (index4 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0 && !drillCalcItemList3[index4].Calculated)
        {
          if (drillCalcItemList3[index4].NumberNextVerticalItem > 0)
            Settings.SelectVerticalTools = true;
          clsInit.cDrill.isVerticalDrillAvailable(drillCalcItemList3[index4], this.SplitedItems.lstLeftRight, clsDrill.varDrillCNCSettings.ToolRepeatDistance, index1, ref Count);
          this.FindToolFromBlock(drillCalcItemList3[index4], 0, Settings, ref foundTool1);
          if (foundTool1 != null)
          {
            if (this.SetValueToAvailableTool(foundTool1.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList3[index4].Calculated = true;
              drillCalcItemList3[index4].OffsetedPoint.Y = drillCalcItemList3[index4].Center.Y - foundTool1.Positions.Offset.Y;
              drillCalcItemList3[index4].HeadNo = 1;
              DrillFound.Add(drillCalcItemList3[index4], foundTool1.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool1.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList3[index4].ID);
            }
            else
              this.calcErrorList.Add($"Right Surface Y1 Group Tool Set Limit Full - Tool No : {foundTool1.Data.No.ToString()} - Position : {drillCalcItemList3[index4].Center.ToString()}");
          }
          if (foundTool1 != null & Count > 0 && drillCalcItemList3.Count > 0)
          {
            List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
            clsInit.cDrill.FindNextVerticalDrill(this.SplitedItems.lstLeftRight, drillCalcItemList3[index4], index1 + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems);
            for (int index6 = 0; index6 <= foundItems.Count - 1; ++index6)
            {
              double num1 = foundItems[index6].Center.X - drillCalcItemList3[index4].Center.X;
              for (int index7 = 0; index7 <= clsDrill.ToolList.Count - 1; ++index7)
              {
                if (foundTool1.Data.GroupIndex == clsDrill.ToolList[index7].Data.GroupIndex & !clsDrill.ToolList[index7].Data.Used & clsDrill.ToolList[index7].Geometry.Diameter == foundItems[index6].Diameter & clsDrill.ToolList[index7].Geometry.ToolDirection.Y == -1.0)
                {
                  double num2 = foundTool1.Positions.Offset.X - clsDrill.ToolList[index7].Positions.Offset.X;
                  if (buCompare5.EQ(num1, num2, 0.05))
                  {
                    int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index7].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref intList);
                    if (availableTool > 0)
                    {
                      foundItems[index6].OffsetedPoint.Y = foundItems[index6].Center.Y - clsDrill.ToolList[index7].Positions.Offset.Y;
                      foundItems[index6].HeadNo = 1;
                      DrillFound.Add(foundItems[index6], clsDrill.ToolList[index7].Data.No, ref Found);
                      this.SetAsCalculatedDrillItemByID(foundItems[index6].ID);
                      clsDrill.ToolList[index7].Data.Used = true;
                    }
                    if (availableTool < 1)
                      this.calcErrorList.Add($"Top Surface Y1 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index7].Data.No.ToString()} - Position : {foundItems[index6].Center.ToString()}");
                    index7 = clsDrill.ToolList.Count;
                  }
                }
              }
            }
          }
        }
        Settings.Plane = planeBoxNames.Left;
        if (index4 <= drillCalcItemList4.Count - 1 & drillCalcItemList4.Count > 0 && !drillCalcItemList4[index4].Calculated)
        {
          Count = 0;
          clsInit.cDrill.isVerticalDrillAvailable(drillCalcItemList4[index4], this.SplitedItems.lstLeftRight, clsDrill.varDrillCNCSettings.ToolRepeatDistance, index1, ref Count);
          this.FindToolFromBlock(drillCalcItemList4[index4], 1, Settings, ref foundTool2);
          if (foundTool2 != null)
          {
            if (this.SetValueToAvailableTool(foundTool2.Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12) > 0)
            {
              drillCalcItemList4[index4].Calculated = true;
              drillCalcItemList4[index4].OffsetedPoint.Y = drillCalcItemList4[index4].Center.Y - foundTool2.Positions.Offset.Y;
              drillCalcItemList4[index4].HeadNo = 2;
              DrillFound.Add(drillCalcItemList4[index4], foundTool2.Data.No, ref Found);
              this.SetAsUsedToolByNo(foundTool2.Data.No, ref clsDrill.ToolList);
              this.SetAsCalculatedDrillItemByID(drillCalcItemList4[index4].ID);
            }
            else
              this.calcErrorList.Add($"Left Surface Y2 Group Tool Set Limit Full - Tool No : {foundTool2.Data.No.ToString()} - Position : {drillCalcItemList4[index4].Center.ToString()}");
          }
          if (foundTool2 != null & Count > 0 && drillCalcItemList4.Count > 0)
          {
            List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
            clsInit.cDrill.FindNextVerticalDrill(this.SplitedItems.lstLeftRight, drillCalcItemList4[index4], index1 + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems);
            for (int index8 = 0; index8 <= foundItems.Count - 1; ++index8)
            {
              double num3 = foundItems[index8].Center.X - drillCalcItemList4[index4].Center.X;
              for (int index9 = 0; index9 <= clsDrill.ToolList.Count - 1; ++index9)
              {
                if (foundTool2.Data.GroupIndex == clsDrill.ToolList[index9].Data.GroupIndex & !clsDrill.ToolList[index9].Data.Used & clsDrill.ToolList[index9].Geometry.Diameter == foundItems[index8].Diameter & clsDrill.ToolList[index9].Geometry.ToolDirection.Y == 1.0)
                {
                  double num4 = foundTool2.Positions.Offset.X - clsDrill.ToolList[index9].Positions.Offset.X;
                  if (buCompare5.EQ(num3, num4, 0.05))
                  {
                    int availableTool = this.SetValueToAvailableTool(clsDrill.ToolList[index9].Data.No, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref intList, ref intList);
                    if (availableTool > 0)
                    {
                      foundItems[index8].HeadNo = 2;
                      foundItems[index8].OffsetedPoint.Y = foundItems[index8].Center.Y - clsDrill.ToolList[index9].Positions.Offset.Y;
                      DrillFound.Add(foundItems[index8], clsDrill.ToolList[index9].Data.No, ref Found);
                      this.SetAsCalculatedDrillItemByID(foundItems[index8].ID);
                      clsDrill.ToolList[index9].Data.Used = true;
                    }
                    if (availableTool < 1)
                      this.calcErrorList.Add($"Top Surface Y2 Group Tool Set Limit Full - Tool No : {clsDrill.ToolList[index9].Data.No.ToString()} - Position : {foundItems[index8].Center.ToString()}");
                    index9 = clsDrill.ToolList.Count;
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

  public void AssingToolOffset()
  {
    for (int index1 = 0; index1 <= this.FoundDrills.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
      {
        double XOffset = 0.0;
        this.GetXToolOffsetFromNo(this.FoundDrills[index1].Items[index2].Tool, ref XOffset);
        double num = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + this.FoundDrills[index1].Items[index2].Center.X;
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
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX1, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
    for (int index = 0; index <= this.FoundDrills.Count - 1; ++index)
    {
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Top)
        this.CreateCodeForTop(ref Job, this.FoundDrills[index].Items, index);
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Bottom)
        this.CreateCodeForBottom(ref Job, this.FoundDrills[index].Items, index);
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Front)
        this.CreateCodeForFront(ref Job, this.FoundDrills[index].Items, index);
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Back)
        this.CreateCodeForBack(ref Job, this.FoundDrills[index].Items, index);
      if (this.FoundDrills[index].Items[0].planeName == planeBoxNames.Left | this.FoundDrills[index].Items[0].planeName == planeBoxNames.Right)
        this.CreateCodeForLeftRight(ref Job, this.FoundDrills[index].Items, index);
      if (index < this.FoundDrills.Count - 1 && this.FoundDrills[index + 1].Items.Count > 0)
      {
        double num1 = this.FoundDrills[index + 1].Items[0].Center.X - this.FoundDrills[index].Items[0].Center.X;
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper + num1 > clsDrill.varDrillMachineSettings.MachineMaxXStroke - 100.0)
        {
          double num2 = this.FoundDrills[this.FoundDrills.Count - 1].Items[0].Center.X - Job.Moves[Job.Moves.Count - 1].XPosition + 500.0;
          if (num2 > 1000.0)
            num2 = 1000.0;
          double newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num2;
          double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num2;
          if (newX1 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
          {
            double num3 = num1 * 0.4;
            double X = Job.Moves[Job.Moves.Count - 1].XPosition + num3;
            this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num3, Job.Moves[Job.Moves.Count - 1].X2Clamper + num3, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
            double num4 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillMachineSettings.MachineMinXStroke;
            newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num4;
            newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num4;
          }
          this.MoveClampers(newX1, this.NoMoveX2, drillPlaneNames.Top, ref Job);
          this.MoveClampers(this.NoMoveX1, newX2, drillPlaneNames.Top, ref Job);
        }
      }
    }
  }

  public void CreateCodeForTop(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    drillPlaneNames drillPlaneNames = drillPlaneNames.Top;
    DrillCalcItem drillCalcItem1 = (DrillCalcItem) null;
    DrillCalcItem drillCalcItem2 = (DrillCalcItem) null;
    DrillMoveOptions Option1 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    DrillMoveOptions drillMoveOptions1 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    DrillMoveOptions Options = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.ResetAll, DrillMoveCommand.None);
    DrillMoveOptions Option2 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions drillMoveOptions2 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    DrillMoveOptions Option3 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions drillMoveOptions3 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
    double num1 = 0.0;
    double X = 0.0;
    double Y1 = this.NoMoveY1;
    double Y2_1 = this.NoMoveY2;
    double noMoveZ1 = this.NoMoveZ1;
    double noMoveZ2 = this.NoMoveZ2;
    double Z1_1 = this.NoMoveZ1;
    double Z2_1 = this.NoMoveZ2;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
    double Z1_2 = this.NoMoveZ1;
    double Z2_2 = this.NoMoveZ2;
    double ClamperMinXToToolX = 0.0;
    double ClamperMaxXToToolX = 0.0;
    double num2 = 0.0;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    List<ToolBase5> activeTools = new List<ToolBase5>();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem1 == null & Items[index].HeadNo == 1)
      {
        drillCalcItem1 = Items[index];
        Y1 = drillCalcItem1.OffsetedPoint.Y;
        double z = drillCalcItem1.Center.Z;
        Z1_2 = z - drillCalcItem1.Depth;
        Z1_1 = z + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
        num2 = drillCalcItem1.Center.X;
      }
      if (drillCalcItem2 == null & Items[index].HeadNo == 2)
      {
        drillCalcItem2 = Items[index];
        Y2_1 = drillCalcItem2.OffsetedPoint.Y;
        double z = drillCalcItem2.Center.Z;
        Z2_2 = z - drillCalcItem2.Depth;
        Z2_1 = z + clsDrill.varDrillCNCSettings.Z2SmallSafeDistance;
        num2 = drillCalcItem2.Center.X;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option2);
      if (Items[index].HeadNo == 2)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option3);
      if (drillCalcItem1 != null && drillCalcItem1.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem1.Diameter / 2.0)
        flag2 = true;
      if (drillCalcItem2 != null && drillCalcItem2.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem2.Diameter / 2.0)
        flag3 = true;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
          activeTools.Add(foundTool);
      }
      else
        this.calcErrorList.Add($"{buDrillCalc.LangDrillMessage[40]} - {clsInit.cDrill.DrillCalcItemToString(Items[index])}");
      this.SetValueToAvailableTool(Items[index].Tool, ref Option1);
    }
    if (drillCalcItem1 != null)
    {
      num1 = drillCalcItem1.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      X = drillCalcItem1.OffsetedPoint.X;
    }
    else if (drillCalcItem2 != null)
    {
      num1 = drillCalcItem2.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      X = drillCalcItem2.OffsetedPoint.X;
    }
    if (flag2 | flag3 && clsDrill.varDrillCNCSettings.MoveSafeDistanceAtClamperSideForTop)
    {
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
      flag1 = true;
    }
    if ((flag2 | flag3) & !Job.isSingleClamper)
    {
      double num3 = 0.0;
      if (Index < this.FoundDrills.Count - 1)
      {
        for (int index1 = Index + 1; index1 <= this.FoundDrills.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
          {
            if (this.FoundDrills[index1].Items[index2].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + this.FoundDrills[index1].Items[index2].Diameter / 2.0)
            {
              double num4 = this.FoundDrills[index1].Items[index2].Center.X - num2;
              if (num4 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Top | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Left && num4 > num3)
                num3 = num4;
            }
          }
        }
      }
      if (this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, activeTools, ref ClamperMinXToToolX, ref ClamperMaxXToToolX))
      {
        if (!flag1)
        {
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
          flag1 = true;
        }
        double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper + ClamperMinXToToolX;
        if (newX2 > Job.Moves[Job.Moves.Count - 1].XPosition && clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - (newX2 - Job.Moves[Job.Moves.Count - 1].XPosition) < 40.0)
          newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num3;
        if (newX2 > Job.Moves[Job.Moves.Count - 1].XPosition && newX2 - Job.Moves[Job.Moves.Count - 1].XPosition > clsDrill.varDrillCNCSettings.ClamperLength / 2.0 * 0.75)
          newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num3;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num5 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          this.MoveClampers(newX2 - num5, this.NoMove, drillPlaneNames, ref Job);
        }
        this.MoveClampers(this.NoMove, newX2, drillPlaneNames, ref Job);
      }
      if (this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, activeTools, ref ClamperMinXToToolX, ref ClamperMaxXToToolX))
      {
        if (!flag1)
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        double newX1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + ClamperMinXToToolX;
        double newX1_2 = Job.Moves[Job.Moves.Count - 1].X1Clamper - ClamperMaxXToToolX;
        bool flag5 = false;
        if (newX1_2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 < Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width)
          flag5 = true;
        double num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1_1;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
        if (num6 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num7 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          double newX2 = newX1_1 + num7;
          bool flag6 = false;
          if (newX2 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 > Job.Moves[Job.Moves.Count - 1].XPosition)
            flag6 = true;
          if (flag5)
          {
            if (newX2 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial < Job.Moves[Job.Moves.Count - 1].XPosition)
            {
              this.MoveClampers(this.NoMoveX1, newX2, drillPlaneNames, ref Job);
              this.MoveClampers(newX1_1, this.NoMoveX2, drillPlaneNames, ref Job);
            }
            else if (!flag6)
            {
              if (newX2 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial / 2.0 < Job.Moves[Job.Moves.Count - 1].XPosition)
              {
                this.MoveClampers(this.NoMoveX1, newX2, drillPlaneNames, ref Job);
                this.MoveClampers(newX1_1, this.NoMoveX2, drillPlaneNames, ref Job);
              }
              else if (newX2 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial / 4.0 < Job.Moves[Job.Moves.Count - 1].XPosition)
              {
                this.MoveClampers(this.NoMoveX1, newX2, drillPlaneNames, ref Job);
                this.MoveClampers(newX1_1, this.NoMoveX2, drillPlaneNames, ref Job);
              }
              else
                this.calcErrorList.Add(buDrillCalc.LangDrillMessage[40] + " - ");
            }
            else
              this.calcErrorList.Add(buDrillCalc.LangDrillMessage[40] + " - ");
          }
          else
            this.MoveClampers(newX1_2, this.NoMoveX2, drillPlaneNames, ref Job);
        }
        else
          this.MoveClampers(newX1_1, this.NoMoveX2, drillPlaneNames, ref Job);
      }
    }
    if (drillCalcItem1 != null & drillCalcItem2 != null)
    {
      if (Y1 - Y2_1 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
        flag4 = true;
    }
    else if (drillCalcItem1 != null & drillCalcItem2 == null)
    {
      if (Y1 - Job.Moves[Job.Moves.Count - 1].Y2Position < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
        Y2_1 = Y1 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
    }
    else if (drillCalcItem1 == null & drillCalcItem2 != null && Job.Moves[Job.Moves.Count - 1].Y1Position - Y2_1 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
      Y1 = Y2_1 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
    if (!flag4)
    {
      Option1.Cmd2 = DrillMoveCommand.None;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, Y1, Y2_1, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, Option1, ref Job);
      Option1.Cmd2 = DrillMoveCommand.SetPiston;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_1, Z2_1, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      DrillMoveOptions drillMoveOptions4 = new DrillMoveOptions(Option1)
      {
        Mode = DrillCNCMode.Plunge,
        Cmd2 = DrillMoveCommand.None
      };
      Option1.Mode = DrillCNCMode.Plunge;
      Option1.Cmd2 = DrillMoveCommand.None;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_2, Z2_2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
    }
    else
    {
      double num8 = Y2_1;
      double Y2_2 = Y1 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, Y1, Y2_2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option2, ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_2, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(Option1)
      {
        Mode = DrillCNCMode.Plunge,
        Cmd2 = DrillMoveCommand.None
      }, ref Job);
      Option2.Cmd2 = DrillMoveCommand.ResetAll;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option2, ref Job);
      double Y2_3 = num8;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y2_3 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance, Y2_3, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, Z2_1, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option3, ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, Z2_2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(Option1)
      {
        Mode = DrillCNCMode.Plunge,
        Cmd2 = DrillMoveCommand.None
      }, ref Job);
      Option3.Cmd2 = DrillMoveCommand.ResetAll;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, Z2_1, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option3, ref Job);
    }
    Option1.Mode = DrillCNCMode.Fast;
    if (Index < this.FoundDrills.Count - 1)
    {
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Top)
      {
        if (clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
        {
          Option1.Cmd2 = DrillMoveCommand.None;
          for (int index = 0; index <= Items.Count - 1; ++index)
          {
            if (Items[index].Center.Y < clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
              Option1.Cmd2 = DrillMoveCommand.ResetAll;
          }
        }
        else
          Option1.Cmd2 = DrillMoveCommand.ResetAll;
        if (!clsDrill.varDrillCNCSettings.ResetDrillPistonWhileMoveSafeAfterDrill)
        {
          if (Option1.Cmd2 != DrillMoveCommand.ResetAll)
            Option1.Cmd2 = DrillMoveCommand.ResetPress;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_1, Z2_1, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
        }
        else
        {
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_1, Z2_1, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
        }
      }
      else
      {
        Option1.Cmd2 = DrillMoveCommand.ResetAll;
        if (clsDrill.varDrillCNCSettings.ResetDrillPistonWhileMoveSafeAfterDrill)
        {
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
        }
        else
        {
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
        }
      }
    }
    else
    {
      Option1.Cmd2 = DrillMoveCommand.ResetAll;
      if (clsDrill.varDrillCNCSettings.ResetDrillPistonWhileMoveSafeAfterDrill)
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      }
      else
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
      }
    }
  }

  public void CreateCodeForBottom(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    DrillCalcItem drillCalcItem = (DrillCalcItem) null;
    drillPlaneNames drillPlaneNames = drillPlaneNames.Bottom;
    DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Bottom, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions Options = new DrillMoveOptions(drillPlaneNames.Bottom, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.ResetAll, DrillMoveCommand.None);
    double num1 = 0.0;
    double X = 0.0;
    double Y3 = this.NoMoveY3;
    double noMoveZ3 = this.NoMoveZ3;
    double Z3_1 = this.NoMoveZ3;
    double z3SafeDistance = clsDrill.varDrillCNCSettings.Z3SafeDistance;
    double Z3_2 = this.NoMoveZ3;
    double num2 = double.MaxValue;
    double ClamperMinXToToolX = 0.0;
    double ClamperMaxXToToolX = 0.0;
    double num3 = 0.0;
    double noMoveZ1 = this.NoMoveZ1;
    double noMoveZ2 = this.NoMoveZ2;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
    bool flag1 = false;
    bool flag2 = false;
    List<ToolBase5> activeTools = new List<ToolBase5>();
    List<DrillCalcItem> CopiedItem = new List<DrillCalcItem>();
    DrillCalcItem.Copy(Items, ref CopiedItem);
    for (int index = 0; index <= CopiedItem.Count - 1; ++index)
    {
      if (drillCalcItem == null & CopiedItem[index].HeadNo == 3)
      {
        drillCalcItem = CopiedItem[index];
        Y3 = drillCalcItem.OffsetedPoint.Y;
        double z = drillCalcItem.Center.Z;
        Z3_2 = z - drillCalcItem.Depth;
        Z3_1 = z + clsDrill.varDrillCNCSettings.Z3SmallSafeDistance;
        num3 = drillCalcItem.Center.X;
      }
      if (CopiedItem[index].HeadNo == 3)
        this.SetValueToAvailableTool(CopiedItem[index].Tool, ref Option);
      if (drillCalcItem != null)
      {
        if (drillCalcItem.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem.Diameter / 2.0)
          flag1 = true;
        if (index == CopiedItem.Count - 1)
          DrillCalcItem.Copy(CopiedItem[index], ref this.LastCalcItem);
      }
      if (CopiedItem[index].Center.Y < num2)
        num2 = CopiedItem[index].Center.Y;
      if (CopiedItem[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(CopiedItem[index].Tool, ref foundTool))
          activeTools.Add(foundTool);
      }
      else
        this.calcErrorList.Add("No Defined Tool For This OP");
    }
    if (drillCalcItem != null)
    {
      num1 = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      X = drillCalcItem.OffsetedPoint.X;
    }
    if (flag1 & Index == 0)
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY3, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, z3SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    if (num2 < clsDrill.varDrillCNCSettings.ClamperCatchWidthForBottom + Items[0].Diameter / 2.0 & !Job.isSingleClamper)
    {
      double num4 = 0.0;
      if (Index < this.FoundDrills.Count - 1)
      {
        for (int index1 = Index + 1; index1 <= this.FoundDrills.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
          {
            if (this.FoundDrills[index1].Items[index2].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + this.FoundDrills[index1].Items[index2].Diameter / 2.0)
            {
              double num5 = this.FoundDrills[index1].Items[index2].Center.X - num3;
              if (num5 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Top | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Bottom | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Left && num5 > num4)
                num4 = num5;
            }
          }
        }
      }
      if (this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, activeTools, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, 50.0))
      {
        double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper + ClamperMinXToToolX;
        if (newX2 > Job.Moves[Job.Moves.Count - 1].XPosition && clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - (newX2 - Job.Moves[Job.Moves.Count - 1].XPosition) < 40.0)
          newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num4;
        if (newX2 > Job.Moves[Job.Moves.Count - 1].XPosition && newX2 - Job.Moves[Job.Moves.Count - 1].XPosition > clsDrill.varDrillCNCSettings.ClamperLength / 2.0 * 0.75)
          newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num4;
        if (Math.Abs(newX2 - Job.Moves[Job.Moves.Count - 1].X2Clamper) > 0.1)
        {
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY3, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
          if (!flag2 & clsDrill.varDrillCNCSettings.LeaveClamperSideWhileClamperChangeForBottom)
          {
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, Y3 + clsDrill.varDrillCNCSettings.LeaveYDistanceWhileClamperChangeForBottom, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
            flag2 = true;
          }
          if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          {
            double num6 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
            this.MoveClampers(newX2 - num6, this.NoMove, drillPlaneNames, ref Job);
          }
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames, ref Job);
        }
      }
      if (this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, activeTools, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, 50.0))
      {
        double newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + ClamperMinXToToolX;
        double num7 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY3, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        if (!flag2 & clsDrill.varDrillCNCSettings.LeaveClamperSideWhileClamperChangeForBottom)
        {
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, Y3 + clsDrill.varDrillCNCSettings.LeaveYDistanceWhileClamperChangeForBottom, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
          flag2 = true;
        }
        if (num7 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num8 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          if (newX1 + num8 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial < Job.Moves[Job.Moves.Count - 1].XPosition)
            this.MoveClampers(this.NoMoveX1, newX1 + num8, drillPlaneNames, ref Job);
          else
            newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - ClamperMaxXToToolX;
        }
        this.MoveClampers(newX1, this.NoMoveX2, drillPlaneNames, ref Job);
      }
    }
    double z1Position = Job.Moves[Job.Moves.Count - 1].Z1Position;
    double z2Position = Job.Moves[Job.Moves.Count - 1].Z2Position;
    double y1Position = Job.Moves[Job.Moves.Count - 1].Y1Position;
    double y2Position = Job.Moves[Job.Moves.Count - 1].Y2Position;
    double Z1_1 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
    double Z2_1 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.Z2SmallSafeDistance;
    double Y2;
    double Z2_2;
    double Y1;
    double Z1_2;
    if (Job.Material.Size.Height <= clsDrill.varDrillCNCSettings.BottomDrillBothY1AndY2PressLimit)
    {
      if (drillCalcItem.Center.Y < clsDrill.varDrillCNCSettings.BottomDrillPressMinLimit)
      {
        Y2 = clsDrill.varDrillCNCSettings.BottomDrillPressMinLimit - 100.0;
        Z2_2 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
        Y1 = Y2 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
        Z1_2 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
      }
      else
      {
        Y2 = drillCalcItem.Center.Y - 165.0;
        Z2_2 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
        Y1 = Y2 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
        Z1_2 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
      }
    }
    else
    {
      Z2_2 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
      Z1_2 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
      if (drillCalcItem.Center.Y < Job.Material.Size.Height / 2.0)
      {
        Y2 = drillCalcItem.Center.Y - 165.0;
        if (drillCalcItem.Depth > Job.Material.Size.Depth - 1.0)
          Y2 = drillCalcItem.Center.Y - 165.0 + 100.0;
        Y1 = Y2 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
      }
      else
      {
        Y1 = drillCalcItem.Center.Y + 215.0;
        if (drillCalcItem.Depth > Job.Material.Size.Depth - 1.0)
          Y1 = drillCalcItem.Center.Y + 215.0 + 100.0;
        Y2 = Y1 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
      }
    }
    if (flag2)
    {
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1, Y2, Y3, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    }
    else if (flag1)
    {
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1, Y2, Y3, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    }
    else if (clsDrill.varDrillCNCSettings.MoveXYSameTimeForBottom)
    {
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, Y1, Y2, Y3, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    }
    else
    {
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1, Y2, Y3, this.NoMoveZ3, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    }
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_2, Z2_2, Z3_1, DrillMoveCommand.AxisMove, this.NoMove, Option, ref Job);
    this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, Z3_2, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Plunge), ref Job);
    if (Index < this.FoundDrills.Count - 1)
    {
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Bottom)
      {
        if (clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_1, Z2_1, Z3_1, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        else
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
      }
      else
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, clsDrill.varDrillCNCSettings.ParkY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
      }
    }
    else
    {
      Option.Cmd2 = DrillMoveCommand.ResetAll;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, clsDrill.varDrillCNCSettings.ParkY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    }
  }

  public void CreateCodeForFront(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    DrillCalcItem drillCalcItem1 = (DrillCalcItem) null;
    DrillCalcItem drillCalcItem2 = (DrillCalcItem) null;
    drillPlaneNames drillPlaneNames = drillPlaneNames.Front;
    DrillMoveOptions Option1 = new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions Option2 = new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions Option3 = new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    double num1 = 0.0;
    double X1 = 0.0;
    double X2 = 0.0;
    double Y1_1 = this.NoMoveY1;
    double Y2_1 = this.NoMoveY2;
    double Z1 = this.NoMoveZ1;
    double Z2 = this.NoMoveZ2;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
    double num2 = double.MaxValue;
    double num3 = 0.0;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    List<ToolBase5> toolBase5List = new List<ToolBase5>();
    if (Index > 0 & Index <= this.FoundDrills.Count - 1 && this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Front)
      flag4 = true;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem1 == null & Items[index].HeadNo == 1)
      {
        drillCalcItem1 = Items[index];
        Y1_1 = drillCalcItem1.OffsetedPoint.Y;
        Z1 = drillCalcItem1.Center.Z;
        num3 = drillCalcItem1.Center.X;
      }
      if (drillCalcItem2 == null & Items[index].HeadNo == 2)
      {
        drillCalcItem2 = Items[index];
        Y2_1 = drillCalcItem2.OffsetedPoint.Y;
        Z2 = drillCalcItem2.Center.Z;
        num3 = drillCalcItem2.Center.X;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option2);
      if (Items[index].HeadNo == 2)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option3);
      if (drillCalcItem1 != null && drillCalcItem1.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem1.Diameter / 2.0)
        flag1 = true;
      if (drillCalcItem2 != null && drillCalcItem2.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem2.Diameter / 2.0)
        flag2 = true;
      if (Items[index].Center.Y < num2)
        num2 = Items[index].Center.Y;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
          toolBase5List.Add(foundTool);
      }
      else
        this.calcErrorList.Add("No Defined Tool For This OP");
      this.SetValueToAvailableTool(Items[index].Tool, ref Option1);
    }
    if (drillCalcItem1 != null)
    {
      ToolBase5 foundTool = new ToolBase5();
      this.FindToolWithToolNo(drillCalcItem1.Tool, ref foundTool);
      num1 = drillCalcItem1.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      double x = drillCalcItem1.OffsetedPoint.X;
      X1 = x - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.X1SafeDistance;
      X2 = x - foundTool.Geometry.Length + drillCalcItem1.Depth;
    }
    else if (drillCalcItem2 != null)
    {
      ToolBase5 foundTool = new ToolBase5();
      this.FindToolWithToolNo(drillCalcItem2.Tool, ref foundTool);
      num1 = drillCalcItem2.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      double x = drillCalcItem2.OffsetedPoint.X;
      X1 = x - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.X1SafeDistance;
      X2 = x - foundTool.Geometry.Length + drillCalcItem2.Depth;
    }
    if (!Job.isSingleClamper && num2 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0 & (Job.Moves[Job.Moves.Count - 1].X2Clamper > 0.0 | Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper) < clsDrill.varDrillCNCSettings.ClamperLength / 2.0))
    {
      double num4 = 0.0;
      if (Index < this.FoundDrills.Count - 1)
      {
        for (int index1 = Index + 1; index1 <= this.FoundDrills.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
          {
            if (this.FoundDrills[index1].Items[index2].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + this.FoundDrills[index1].Items[index2].Diameter / 2.0)
            {
              double num5 = this.FoundDrills[index1].Items[index2].Center.X - num3;
              if (num5 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Top | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Left && num5 > num4)
                num4 = num5;
            }
          }
        }
      }
      if (num4 > 0.0)
        num4 += clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
      double num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num1;
      if (num6 > 0.0)
      {
        double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num6 - num4;
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num7 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          this.MoveClampers(newX2 - num7, this.NoMove, drillPlaneNames, ref Job);
        }
        this.MoveClampers(this.NoMove, newX2, drillPlaneNames, ref Job);
      }
    }
    if (Index == 0)
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
    else if ((flag1 | flag2) & clsDrill.varDrillCNCSettings.MoveSafeDistanceAtClamperSideForFront)
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
    if (drillCalcItem1 != null & drillCalcItem2 != null)
    {
      if (Y1_1 - Y2_1 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
        flag3 = true;
    }
    else if (drillCalcItem1 != null & drillCalcItem2 == null)
    {
      if (Y1_1 - Job.Moves[Job.Moves.Count - 1].Y2Position < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
        Y2_1 = Y1_1 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
    }
    else if (drillCalcItem1 == null & drillCalcItem2 != null && Job.Moves[Job.Moves.Count - 1].Y1Position - Y2_1 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
      Y1_1 = Y2_1 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
    if (!flag3)
    {
      if (!flag4)
      {
        if (!buCompare5.EQ(X1, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(Y1_1, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(Y2_1, Job.Moves[Job.Moves.Count - 1].Y2Position))
        {
          double num8 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num8, Job.Moves[Job.Moves.Count - 1].X2Clamper + num8, Y1_1, Y2_1, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
        }
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      }
      else if (!buCompare5.EQ(X1, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(Y1_1, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(Y2_1, Job.Moves[Job.Moves.Count - 1].Y2Position))
      {
        double num9 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num9, Job.Moves[Job.Moves.Count - 1].X2Clamper + num9, Y1_1, Y2_1, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, Option1, ref Job);
      }
      else
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      double num10 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num10, Job.Moves[Job.Moves.Count - 1].X2Clamper + num10, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Plunge), ref Job);
      double num11 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num11, Job.Moves[Job.Moves.Count - 1].X2Clamper + num11, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
    }
    else
    {
      double num12 = Y2_1;
      if (!buCompare5.EQ(X1, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(Y1_1, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(Y2_1, Job.Moves[Job.Moves.Count - 1].Y2Position))
      {
        double num13 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num13, Job.Moves[Job.Moves.Count - 1].X2Clamper + num13, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
      }
      double Y2_2 = Y1_1 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
      if (Job.Moves[Job.Moves.Count - 1].Y1Position < Job.Material.Size.Height)
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, Y2_2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option2, ref Job);
      }
      else
      {
        Option2.Cmd2 = DrillMoveCommand.None;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, Y2_2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option2, ref Job);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.SetPiston, this.NoMove, Option2, ref Job);
      }
      double num14 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num14, Job.Moves[Job.Moves.Count - 1].X2Clamper + num14, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Plunge), ref Job);
      double num15 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num15, Job.Moves[Job.Moves.Count - 1].X2Clamper + num15, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
      double Y2_3 = num12;
      double Y1_2 = Y2_3 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
      if (Y2_3 > 50.0)
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_2, Y2_3, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option3, ref Job);
      }
      else
      {
        Option3.Cmd2 = DrillMoveCommand.None;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_2, Y2_3, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option3, ref Job);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_2, Y2_3, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.SetPiston, this.NoMove, Option3, ref Job);
      }
      double num16 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num16, Job.Moves[Job.Moves.Count - 1].X2Clamper + num16, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Plunge), ref Job);
      double num17 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num17, Job.Moves[Job.Moves.Count - 1].X2Clamper + num17, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
    }
    if (Index < this.FoundDrills.Count - 1)
    {
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Front)
      {
        if (clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
        {
          Option1.Cmd2 = DrillMoveCommand.ResetAll;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAllPress, this.NoMove, Option1, ref Job);
        }
        else
        {
          Option1.Cmd2 = DrillMoveCommand.ResetAll;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
        }
      }
      else
      {
        Option1.Cmd2 = DrillMoveCommand.ResetAll;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      }
    }
    else
    {
      Option1.Cmd2 = DrillMoveCommand.ResetAll;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
    }
  }

  public void CreateCodeForBack(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    DrillCalcItem drillCalcItem1 = (DrillCalcItem) null;
    DrillCalcItem drillCalcItem2 = (DrillCalcItem) null;
    drillPlaneNames plane = drillPlaneNames.Back;
    DrillMoveOptions Option1 = new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions Option2 = new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions Option3 = new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    double num1 = 0.0;
    double X1 = 0.0;
    double X2 = 0.0;
    double Y1_1 = this.NoMoveY1;
    double Y2_1 = this.NoMoveY2;
    double Z1 = this.NoMoveZ1;
    double Z2 = this.NoMoveZ2;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
    double num2 = double.MaxValue;
    double num3 = 0.0;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    List<ToolBase5> toolBase5List = new List<ToolBase5>();
    if (Index > 0 & Index <= this.FoundDrills.Count - 1 && this.FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Back)
      flag4 = true;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem1 == null & Items[index].HeadNo == 1)
      {
        drillCalcItem1 = Items[index];
        Y1_1 = drillCalcItem1.OffsetedPoint.Y;
        Z1 = drillCalcItem1.Center.Z;
        num3 = drillCalcItem1.Center.X;
      }
      if (drillCalcItem2 == null & Items[index].HeadNo == 2)
      {
        drillCalcItem2 = Items[index];
        Y2_1 = drillCalcItem2.OffsetedPoint.Y;
        Z2 = drillCalcItem2.Center.Z;
        num3 = drillCalcItem2.Center.X;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option2);
      if (Items[index].HeadNo == 2)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option3);
      if (drillCalcItem1 != null && drillCalcItem1.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem1.Diameter / 2.0)
        flag1 = true;
      if (drillCalcItem2 != null && drillCalcItem2.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem2.Diameter / 2.0)
        flag2 = true;
      if (Items[index].Center.Y < num2)
        num2 = Items[index].Center.Y;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
          toolBase5List.Add(foundTool);
      }
      else
        this.calcErrorList.Add("No Defined Tool For This OP");
      this.SetValueToAvailableTool(Items[index].Tool, ref Option1);
    }
    if (drillCalcItem1 != null)
    {
      ToolBase5 foundTool = new ToolBase5();
      this.FindToolWithToolNo(drillCalcItem1.Tool, ref foundTool);
      num1 = drillCalcItem1.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      double x = drillCalcItem1.OffsetedPoint.X;
      X1 = x + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.X1SafeDistance;
      X2 = x + foundTool.Geometry.Length - drillCalcItem1.Depth;
    }
    else if (drillCalcItem2 != null)
    {
      ToolBase5 foundTool = new ToolBase5();
      this.FindToolWithToolNo(drillCalcItem2.Tool, ref foundTool);
      num1 = drillCalcItem2.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      double x = drillCalcItem2.OffsetedPoint.X;
      X1 = x + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.X1SafeDistance;
      X2 = x + foundTool.Geometry.Length - drillCalcItem2.Depth;
    }
    if (!Job.isSingleClamper)
    {
      double num4 = 0.0;
      if (Index < this.FoundDrills.Count - 1)
      {
        for (int index1 = Index + 1; index1 <= this.FoundDrills.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= this.FoundDrills[index1].Items.Count - 1; ++index2)
          {
            if (this.FoundDrills[index1].Items[index2].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + this.FoundDrills[index1].Items[index2].Diameter / 2.0)
            {
              double num5 = Math.Abs(this.FoundDrills[index1].Items[index2].Center.X - num3);
              if (num5 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Top | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Left && num5 > num4)
                num4 = num5;
            }
          }
        }
      }
      if (num4 > 0.0)
        num4 += clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
      double num6 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
      double num7 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num6;
      double num8 = toolBase5List[0].Positions.CommonOffset.X + toolBase5List[0].Geometry.Length + 40.0;
      if (num2 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0 & num7 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 < num8)
      {
        double num9 = num8 - (num7 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
        if (num9 > 0.0)
        {
          double newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num9 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + num4;
          if (Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          {
            double num10 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
            this.MoveClampers(this.NoMove, newX1 + num10, drillPlaneNames.Back, ref Job);
          }
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Back, ref Job);
        }
      }
    }
    if (Index == 0)
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
    else if ((flag1 | flag2) & clsDrill.varDrillCNCSettings.MoveSafeDistanceAtClamperSideForBack)
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
    if (drillCalcItem1 != null & drillCalcItem2 != null)
    {
      if (Y1_1 - Y2_1 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
        flag3 = true;
    }
    else if (drillCalcItem1 != null & drillCalcItem2 == null)
    {
      if (Y1_1 - Job.Moves[Job.Moves.Count - 1].Y2Position < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
        Y2_1 = Y1_1 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
    }
    else if (drillCalcItem1 == null & drillCalcItem2 != null && Job.Moves[Job.Moves.Count - 1].Y1Position - Y2_1 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
      Y1_1 = Y2_1 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
    if (!flag3)
    {
      if (!flag4)
      {
        if (!buCompare5.EQ(X1, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(Y1_1, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(Y2_1, Job.Moves[Job.Moves.Count - 1].Y2Position))
        {
          double num11 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num11, Job.Moves[Job.Moves.Count - 1].X2Clamper + num11, Y1_1, Y2_1, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
        }
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      }
      else if (!buCompare5.EQ(X1, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(Y1_1, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(Y2_1, Job.Moves[Job.Moves.Count - 1].Y2Position))
      {
        double num12 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
        Option1.Cmd2 = DrillMoveCommand.None;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num12, Job.Moves[Job.Moves.Count - 1].X2Clamper + num12, Y1_1, Y2_1, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, Option1, ref Job);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.SetPiston, this.NoMove, Option1, ref Job);
      }
      else
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      double num13 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num13, Job.Moves[Job.Moves.Count - 1].X2Clamper + num13, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Plunge), ref Job);
      double num14 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num14, Job.Moves[Job.Moves.Count - 1].X2Clamper + num14, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
    }
    else
    {
      double num15 = Y2_1;
      if (!buCompare5.EQ(X1, Job.Moves[Job.Moves.Count - 1].XPosition))
      {
        double num16 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num16, Job.Moves[Job.Moves.Count - 1].X2Clamper + num16, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
      }
      double Y2_2 = Y1_1 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
      if (Job.Moves[Job.Moves.Count - 1].Y1Position < Job.Material.Size.Height)
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, Y2_2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option2, ref Job);
      }
      else
      {
        Option2.Cmd2 = DrillMoveCommand.None;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, Y2_2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option2, ref Job);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, Y2_2, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.SetPiston, this.NoMove, Option2, ref Job);
      }
      double num17 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num17, Job.Moves[Job.Moves.Count - 1].X2Clamper + num17, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Plunge), ref Job);
      double num18 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num18, Job.Moves[Job.Moves.Count - 1].X2Clamper + num18, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
      double Y2_3 = num15;
      double Y1_2 = Y2_3 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
      if (Y2_3 > 50.0)
      {
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_2, Y2_3, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option3, ref Job);
      }
      else
      {
        Option3.Cmd2 = DrillMoveCommand.None;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_2, Y2_3, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option3, ref Job);
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_2, Y2_3, this.NoMoveY3, Z1, Z2, this.NoMoveZ3, DrillMoveCommand.SetPiston, this.NoMove, Option3, ref Job);
      }
      double num19 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num19, Job.Moves[Job.Moves.Count - 1].X2Clamper + num19, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Plunge), ref Job);
      double num20 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num20, Job.Moves[Job.Moves.Count - 1].X2Clamper + num20, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
    }
    if (Index < this.FoundDrills.Count - 1)
    {
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Back)
      {
        if (clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
        {
          Option1.Cmd2 = DrillMoveCommand.ResetAll;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.ResetAllPress, this.NoMove, Option1, ref Job);
        }
        else
        {
          Option1.Cmd2 = DrillMoveCommand.ResetAll;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
        }
      }
      else
      {
        Option1.Cmd2 = DrillMoveCommand.ResetAll;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      }
    }
    else
    {
      Option1.Cmd2 = DrillMoveCommand.ResetAll;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
    }
  }

  public void CreateCodeForLeftRight(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
  {
    drillPlaneNames drillPlaneNames = drillPlaneNames.LeftRight;
    DrillCalcItem drillCalcItem1 = (DrillCalcItem) null;
    DrillCalcItem drillCalcItem2 = (DrillCalcItem) null;
    DrillMoveOptions Option1 = new DrillMoveOptions(drillPlaneNames.LeftRight, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions Options = new DrillMoveOptions(drillPlaneNames.LeftRight, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.ResetAll, DrillMoveCommand.None);
    DrillMoveOptions Option2 = new DrillMoveOptions(drillPlaneNames.LeftRight, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    DrillMoveOptions Option3 = new DrillMoveOptions(drillPlaneNames.LeftRight, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
    double num1 = 0.0;
    double X = 0.0;
    double num2 = this.NoMoveY1;
    double num3 = this.NoMoveY2;
    double Z1_1 = this.NoMoveZ1;
    double Z2_1 = this.NoMoveZ2;
    double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
    double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
    double num4 = double.MaxValue;
    double ClamperMinXToToolX = 0.0;
    double ClamperMaxXToToolX = 0.0;
    double num5 = 0.0;
    double Y1_1 = this.NoMoveY1;
    double Y2_1 = this.NoMoveY2;
    double Y1_2 = this.NoMoveY1;
    double Y2_2 = this.NoMoveY2;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    List<ToolBase5> activeTools = new List<ToolBase5>();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (drillCalcItem1 == null & Items[index].HeadNo == 1)
      {
        drillCalcItem1 = Items[index];
        num2 = drillCalcItem1.OffsetedPoint.Y;
        Z1_1 = drillCalcItem1.Center.Z;
        num5 = drillCalcItem1.Center.X;
        ToolBase5 foundTool = new ToolBase5();
        this.FindToolWithToolNo(drillCalcItem1.Tool, ref foundTool);
        Y1_1 = drillCalcItem1.OffsetedPoint.Y + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.Y1SafeDistance;
        Y1_2 = drillCalcItem1.OffsetedPoint.Y + foundTool.Geometry.Length - drillCalcItem1.Depth;
      }
      if (drillCalcItem2 == null & Items[index].HeadNo == 2)
      {
        drillCalcItem2 = Items[index];
        num3 = drillCalcItem2.OffsetedPoint.Y;
        Z2_1 = drillCalcItem2.Center.Z;
        num5 = drillCalcItem2.Center.X;
        ToolBase5 foundTool = new ToolBase5();
        this.FindToolWithToolNo(drillCalcItem2.Tool, ref foundTool);
        Y2_1 = drillCalcItem2.OffsetedPoint.Y - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.Y2SafeDistance;
        Y2_2 = drillCalcItem2.OffsetedPoint.Y - foundTool.Geometry.Length + drillCalcItem2.Depth;
      }
      if (Items[index].HeadNo == 1)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option2);
      if (Items[index].HeadNo == 2)
        this.SetValueToAvailableTool(Items[index].Tool, ref Option3);
      if (drillCalcItem1 != null && drillCalcItem1.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem1.Diameter / 2.0)
        flag2 = true;
      if (drillCalcItem2 != null && drillCalcItem2.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem2.Diameter / 2.0)
        flag3 = true;
      if (Items[index].Center.Y < num4)
        num4 = Items[index].Center.Y;
      if (Items[index].Tool > 0)
      {
        ToolBase5 foundTool = new ToolBase5();
        if (this.FindToolWithToolNo(Items[index].Tool, ref foundTool))
          activeTools.Add(foundTool);
      }
      else
        this.calcErrorList.Add("No Defined Tool For This OP");
      this.SetValueToAvailableTool(Items[index].Tool, ref Option1);
    }
    if (drillCalcItem1 != null)
    {
      num1 = drillCalcItem1.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      X = drillCalcItem1.OffsetedPoint.X;
    }
    else if (drillCalcItem2 != null)
    {
      num1 = drillCalcItem2.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
      X = drillCalcItem2.OffsetedPoint.X;
    }
    if (Index == 0)
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    else if ((flag2 | flag3) & clsDrill.varDrillCNCSettings.MoveSafeDistanceAtClamperSideForLeftRight)
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    if (num4 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + Items[0].Diameter / 2.0 & !Job.isSingleClamper)
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
              double num7 = this.FoundDrills[index1].Items[index2].Center.X - num5;
              if (num7 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Top | this.FoundDrills[index1].Items[index2].planeName == planeBoxNames.Left && num7 > num6)
                num6 = num7 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance;
            }
          }
        }
      }
      if (this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, activeTools, ref ClamperMinXToToolX, ref ClamperMaxXToToolX))
      {
        double newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper + ClamperMinXToToolX;
        if (newX2 > Job.Moves[Job.Moves.Count - 1].XPosition && clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - (newX2 - Job.Moves[Job.Moves.Count - 1].XPosition) < 40.0)
          newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num6;
        if (newX2 > Job.Moves[Job.Moves.Count - 1].XPosition && newX2 - Job.Moves[Job.Moves.Count - 1].XPosition > clsDrill.varDrillCNCSettings.ClamperLength / 2.0 * 0.75)
          newX2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num6;
        if (!flag1)
        {
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
          flag1 = true;
        }
        if (newX2 - Job.Moves[Job.Moves.Count - 1].X1Clamper <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num8 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          this.MoveClampers(newX2 - num8, this.NoMove, drillPlaneNames, ref Job);
        }
        this.MoveClampers(this.NoMove, newX2, drillPlaneNames, ref Job);
      }
      if (this.isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, activeTools, ref ClamperMinXToToolX, ref ClamperMaxXToToolX))
      {
        double newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + ClamperMinXToToolX;
        double num9 = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1;
        if (!flag1)
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        if (num9 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num10 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          if (newX1 + num10 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial < Job.Moves[Job.Moves.Count - 1].XPosition)
            this.MoveClampers(this.NoMoveX1, newX1 + num10, drillPlaneNames, ref Job);
          else
            newX1 = Job.Moves[Job.Moves.Count - 1].X1Clamper - ClamperMaxXToToolX;
        }
        this.MoveClampers(newX1, this.NoMoveX2, drillPlaneNames, ref Job);
      }
    }
    double andY2MinDistance = clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
    if (drillCalcItem1 != null & drillCalcItem2 != null)
    {
      if (num2 - num3 < andY2MinDistance - 80.0)
        flag4 = true;
    }
    else if (drillCalcItem1 != null & drillCalcItem2 == null)
    {
      drillPlaneNames = drillPlaneNames.Left;
      if (num2 - Job.Moves[Job.Moves.Count - 1].Y2Position < andY2MinDistance - 80.0)
      {
        double num11 = num2 - andY2MinDistance - 0.0;
        if (Y2_1 == this.NoMove)
          Y2_1 = num11;
      }
    }
    else if (drillCalcItem1 == null & drillCalcItem2 != null)
    {
      drillPlaneNames = drillPlaneNames.Right;
      if (Job.Moves[Job.Moves.Count - 1].Y1Position - num3 < andY2MinDistance - 80.0)
      {
        double num12 = num3 + andY2MinDistance + 0.0;
        if (Y1_1 == this.NoMove)
          Y1_1 = num12;
      }
    }
    if (!flag4)
    {
      this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num1, Job.Moves[Job.Moves.Count - 1].X2Clamper + num1, Y1_1, Y2_1, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, X, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_1, Z2_1, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_2, Y2_2, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Plunge), ref Job);
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, Y1_1, Y2_1, this.NoMoveY3, this.NoMoveZ1, this.NoMoveZ2, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
    }
    else
    {
      int num13 = (int) MessageBox.Show("Not Ready");
    }
    if (Index < this.FoundDrills.Count - 1)
    {
      double Z1_2 = this.NoMoveZ1;
      double Z2_2 = this.NoMoveZ2;
      if (Job.Material.Size.Depth > 20.0)
      {
        Z1_2 = z1SafeDistance;
        Z2_2 = z2SafeDistance;
      }
      if (this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Left | this.FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Right)
      {
        if (!clsInit.cDrill.isToolsSameForNextOperation(Items, this.FoundDrills[Index + 1].Items))
        {
          Option1.Cmd2 = DrillMoveCommand.ResetAll;
          this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, this.NoMoveZ1, Z2_2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
        }
        else
        {
          double num14 = 0.0;
          double num15 = 0.0;
          double num16 = 0.0;
          double num17 = 0.0;
          for (int index3 = 0; index3 <= Items.Count - 1; ++index3)
          {
            double XOffset1 = 0.0;
            double x = this.FoundDrills[Index].Items[index3].Center.X;
            this.GetXToolOffsetFromNo(Items[index3].Tool, ref XOffset1);
            for (int index4 = 0; index4 <= this.FoundDrills[Index + 1].Items.Count - 1; ++index4)
            {
              double XOffset2 = 0.0;
              double num18 = this.FoundDrills[Index + 1].Items[index4].Center.X - x;
              this.GetXToolOffsetFromNo(this.FoundDrills[Index + 1].Items[index4].Tool, ref XOffset2);
              num14 = Job.Moves[Job.Moves.Count - 1].X2Clamper >= XOffset1 ? 1.0 : -1.0;
              num15 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num18 >= XOffset2 ? 1.0 : -1.0;
              num16 = Job.Moves[Job.Moves.Count - 1].X1Clamper >= XOffset1 ? 1.0 : -1.0;
              num17 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num18 >= XOffset2 ? 1.0 : -1.0;
            }
          }
          if (num14 != num15)
          {
            Option1.Cmd2 = DrillMoveCommand.ResetAll;
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_2, Z2_2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
          }
          else if (num16 != num17)
          {
            Option1.Cmd2 = DrillMoveCommand.ResetAll;
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_2, Z2_2, this.NoMoveZ3, DrillMoveCommand.ResetAll, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
          }
          else
            this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, Z1_2, Z2_2, this.NoMoveZ3, DrillMoveCommand.ResetAllPress, this.NoMove, new DrillMoveOptions(drillPlaneNames, DrillCNCMode.Fast), ref Job);
        }
      }
      else
      {
        Option1.Cmd2 = DrillMoveCommand.ResetAll;
        this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
      }
    }
    else
    {
      Option1.Cmd2 = DrillMoveCommand.ResetAll;
      this.AddDrillMove(this.NoMoveX1, this.NoMoveX2, this.NoMoveY1, this.NoMoveY2, this.NoMoveY3, z1SafeDistance, z2SafeDistance, this.NoMoveZ3, DrillMoveCommand.AxisMove, this.NoMove, Option1, ref Job);
    }
  }

  public void CreateCodeForSlotTopSide(ref DrillJob Job, ref List<DrillCalcItem> ItemSlot)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    double num4 = 0.0;
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
      else
        drillCalcItemList1.Add(new DrillCalcItem(ItemSlot[index]));
    }
    if (drillCalcItemList1.Count == 0)
      return;
    if (drillCalcItemList1[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth & Job.Material.Size.Width < 400.0)
    {
      buString5.MessageBoxError(buDrillCalc.LangDrillMessage[41]);
    }
    else
    {
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
      if (drillCalcItemList1[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth)
      {
        FindToolSettings Settings = new FindToolSettings();
        Settings.Y1Y2ZoneSelectionLimit = Job.Material.Size.Height / 2.0;
        if (Settings.Y1Y2ZoneSelectionLimit < clsDrill.varDrillCNCSettings.Y1MinLimit)
          Settings.Y1Y2ZoneSelectionLimit = clsDrill.varDrillCNCSettings.Y1MinLimit;
        ToolBase5 foundTool1 = new ToolBase5();
        ToolBase5 foundTool2 = new ToolBase5();
        this.FindTool(drillCalcItemList1[0], Settings, ref foundTool2);
        double XOffset = 0.0;
        double YOffset = 0.0;
        this.GetXYToolOffsetFromNo(foundTool2.Data.No, ref XOffset, ref YOffset);
        double Y2 = drillCalcItemList1[0].Center.Y - foundTool2.Positions.Offset.Y;
        num2 = drillCalcItemList1[0].Center.Z + clsDrill.varDrillCNCSettings.Z2SafeDistance;
        double Y1;
        if (drillCalcItemList1.Count >= 2)
        {
          this.FindTool(drillCalcItemList1[1], Settings, ref foundTool1);
          this.GetXYToolOffsetFromNo(foundTool1.Data.No, ref XOffset, ref YOffset);
          Y1 = drillCalcItemList1[1].Center.Y - foundTool1.Positions.Offset.Y;
          num1 = drillCalcItemList1[1].Center.Z + clsDrill.varDrillCNCSettings.Z1SafeDistance;
        }
        else
        {
          Y1 = Job.Moves[Job.Moves.Count - 1].Y1Position;
          if (Job.Moves[Job.Moves.Count - 1].Y1Position - Y2 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
            Y1 = Y2 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance + 20.0;
        }
        if (foundTool1.Data.No > 0 & foundTool2.Data.No > 0)
        {
          Options.Tool1 = foundTool2.Data.No;
          Options.Tool2 = foundTool1.Data.No;
        }
        else if (foundTool1.Data.No > 0 & foundTool2.Data.No == 0)
          Options.Tool1 = foundTool1.Data.No;
        else if (foundTool1.Data.No == 0 & foundTool2.Data.No > 0)
          Options.Tool1 = foundTool2.Data.No;
        double X1;
        double num5;
        double X1_1;
        double X2_1;
        if (Job.Material.Size.Width <= 500.0)
        {
          X1 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X - 50.0;
          num5 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num5;
          X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num5;
        }
        else if (Job.Material.Size.Width > 500.0 & Job.Material.Size.Width <= 750.0)
        {
          X1 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X - 50.0;
          num5 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num5;
          X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num5;
        }
        else if (Job.Material.Size.Width > 750.0 & Job.Material.Size.Width <= 1200.0)
        {
          X1 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X - 50.0;
          num5 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num5;
          X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num5;
        }
        else
        {
          X1 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X - 50.0;
          num5 = X1 - Job.Moves[Job.Moves.Count - 1].XPosition;
          X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num5;
          X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num5;
        }
        this.AddDrillMove(this.NoMove, this.NoMove, Y1, Y2, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, Options, ref Job);
        int Index = -1;
        this.GetIndexFromItemID(drillCalcItemList1[0].ID, drillCalcItemList1, ref Index);
        if (Index >= 0)
          drillCalcItemList1[Index].OffsetedPoint.X = X1;
        this.AddDrillMove(X1_1, X2_1, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X1, Options, ref Job);
        double num6;
        if (Job.Material.Size.Width <= 550.0)
        {
          double newX1 = -Job.Material.Size.Width + num5;
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num6 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 70.0);
        }
        else if (Job.Material.Size.Width > 550.0 & clsDrill.activeJob.Material.Size.Width <= 750.0)
        {
          double newX1 = -Job.Material.Size.Width + num5;
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 100.0;
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num6 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 70.0);
        }
        else if (Job.Material.Size.Width > 750.0 & clsDrill.activeJob.Material.Size.Width <= 1200.0)
        {
          double newX1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num5;
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 200.0;
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num6 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
        }
        else if (Job.Material.Size.Width > 1200.0 & clsDrill.activeJob.Material.Size.Width <= 1500.0)
        {
          double newX1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num5;
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 200.0;
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num6 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
        }
        else
        {
          double newX1 = -1200.0;
          this.MoveClampers(newX1, this.NoMove, drillPlaneNames.Top, ref Job);
          double newX2 = newX1 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 400.0;
          this.MoveClampers(this.NoMove, newX2, drillPlaneNames.Top, ref Job);
          num6 = X1 - (newX2 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 60.0);
        }
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, drillCalcItemList1.Count < 2 ? this.NoMove : drillCalcItemList1[1].Center.Z + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance, drillCalcItemList1[0].Center.Z + clsDrill.varDrillCNCSettings.Z2SmallSafeDistance, this.NoMove, DrillMoveCommand.AxisMove, X1, Options, ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, Options, ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, drillCalcItemList1.Count < 2 ? this.NoMove : drillCalcItemList1[1].Center.Z - drillCalcItemList1[1].Depth, drillCalcItemList1[0].Center.Z - drillCalcItemList1[0].Depth, this.NoMove, DrillMoveCommand.AxisMove, X1, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
        double X2 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + num6;
        double num7 = X2 - Job.Moves[Job.Moves.Count - 1].XPosition;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num7, Job.Moves[Job.Moves.Count - 1].X2Clamper + num7, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X2, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool2.Data.No), ref Job);
        double num8 = num6 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.3 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
        num8 = XOffset + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
        this.MoveClampers(this.NoMove, Job.Material.Size.Width > 550.0 ? (!(Job.Material.Size.Width > 550.0 & clsDrill.activeJob.Material.Size.Width <= 750.0) ? (!(Job.Material.Size.Width > 750.0 & clsDrill.activeJob.Material.Size.Width <= 1200.0) ? X2 - clsDrill.varDrillCNCSettings.ClamperLength : X2 - clsDrill.varDrillCNCSettings.ClamperLength / 4.0) : X2 + clsDrill.varDrillCNCSettings.ClamperLength / 8.0) : X2 + clsDrill.varDrillCNCSettings.ClamperLength / 4.0, drillPlaneNames.Top, ref Job);
        double num9 = num6 + (foundTool2.Positions.Offset.X - (Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0)) - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance * 2.0;
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool2.Data.No), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, drillCalcItemList1[0].Center.Z - drillCalcItemList1[0].Depth, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
        double X3 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + num9;
        double num10 = X3 - Job.Moves[Job.Moves.Count - 1].XPosition;
        this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num10, Job.Moves[Job.Moves.Count - 1].X2Clamper + num10, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X3, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool2.Data.No), ref Job);
        double num11 = Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength * 2.0;
        num11 = XOffset + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
        double newX1_1 = Job.Material.Size.Width > 550.0 ? (!(Job.Material.Size.Width > 550.0 & Job.Material.Size.Width <= 750.0) ? (!(Job.Material.Size.Width > 750.0 & Job.Material.Size.Width <= 1200.0) ? Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 500.0 : Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 200.0) : Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 100.0) : Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength;
        if (Job.Moves[Job.Moves.Count - 1].X2Clamper - newX1_1 < clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength)
          newX1_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
        this.MoveClampers(newX1_1, this.NoMove, drillPlaneNames.Top, ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool2.Data.No), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, drillCalcItemList1[0].Center.Z - drillCalcItemList1[0].Depth, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
        double X4 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + drillCalcItemList1[0].Center.X + drillCalcItemList1[0].Length + foundTool2.Geometry.Diameter / 4.0;
        double num12 = X4 - Job.Moves[Job.Moves.Count - 1].XPosition;
        double X1_2 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num12;
        double X2_2 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num12;
        if (X2_2 > clsDrill.varDrillMachineSettings.MachineMaxXStroke)
        {
          double num13 = X2_2 - clsDrill.varDrillMachineSettings.MachineMaxXStroke;
          double X1_3 = X1_2 - num13;
          double X2_3 = X2_2 - num13;
          double X5 = X4 - num13;
          this.AddDrillMove(X1_3, X2_3, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X5, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
          this.AddDrillMove(X1_3 - num13, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, X2_3 - num13, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
          this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
          this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num13, Job.Moves[Job.Moves.Count - 1].X2Clamper + num13, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X4, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
        }
        else
          this.AddDrillMove(X1_2, X2_2, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X4, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, drillCalcItemList1.Count < 2 ? this.NoMove : drillCalcItemList1[1].Center.Z + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance, drillCalcItemList1[0].Center.Z + clsDrill.varDrillCNCSettings.Z2SmallSafeDistance, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
        this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool1.Data.No, foundTool2.Data.No), ref Job);
      }
      else
      {
        List<DrillCalcItem> Items = this.SortByYDistance(drillCalcItemList1, new DrillCalcItem(), SortDirection.LowerToBigger);
        List<DrillCalcItem> drillCalcItemList2 = new List<DrillCalcItem>();
        List<DrillCalcItem> drillCalcItemList3 = new List<DrillCalcItem>();
        for (int index = 0; index <= Items.Count - 1; ++index)
        {
          if (Items[index].Center.Y < Job.Material.Size.Height)
          {
            if (Items[index].Center.Y >= Job.Material.Size.Height / 2.0)
              drillCalcItemList2.Add(new DrillCalcItem(Items[index]));
            else
              drillCalcItemList3.Add(new DrillCalcItem(Items[index]));
          }
          else
            drillCalcItemList3.Add(new DrillCalcItem(Items[index]));
        }
        int count = drillCalcItemList2.Count;
        if (drillCalcItemList3.Count > count)
          count = drillCalcItemList3.Count;
        for (int index1 = 0; index1 <= count - 1; ++index1)
        {
          bool flag1 = true;
          bool flag2 = true;
          double num14 = 0.0;
          FindToolSettings Settings = new FindToolSettings();
          Settings.Plane = planeBoxNames.Top;
          Settings.SetAsUsed = true;
          for (int index2 = 0; index2 <= clsDrill.ToolList.Count - 1; ++index2)
            clsDrill.ToolList[index2].Data.Used = false;
          int t1 = 0;
          int t2 = 0;
          ToolBase5 foundTool3 = (ToolBase5) null;
          ToolBase5 foundTool4 = (ToolBase5) null;
          double Y1 = this.NoMove;
          double Y2 = this.NoMove;
          double num15 = this.NoMove;
          double num16 = this.NoMove;
          if (index1 <= drillCalcItemList2.Count - 1 & drillCalcItemList2.Count > 0)
          {
            if (!drillCalcItemList2[index1].Calculated)
            {
              this.FindToolFromBlock(drillCalcItemList2[index1], 0, Settings, ref foundTool3);
              if (foundTool3 != null)
              {
                Y1 = drillCalcItemList2[index1].Center.Y - foundTool3.Positions.Offset.Y;
                num15 = drillCalcItemList2[index1].Center.Z;
                double x1 = drillCalcItemList2[index1].Center.X;
                double x2 = drillCalcItemList2[index1].Center.X;
                num14 = drillCalcItemList2[index1].Depth;
                drillCalcItemList2[index1].Calculated = true;
                t1 = foundTool3.Data.No;
              }
            }
            else
              flag1 = false;
          }
          else
            flag1 = false;
          if (index1 <= drillCalcItemList3.Count - 1 & drillCalcItemList3.Count > 0)
          {
            if (!drillCalcItemList3[index1].Calculated)
            {
              this.FindToolFromBlock(drillCalcItemList3[index1], 1, Settings, ref foundTool4);
              if (foundTool4 != null)
              {
                Y2 = drillCalcItemList3[index1].Center.Y - foundTool4.Positions.Offset.Y;
                num16 = drillCalcItemList3[index1].Center.Z;
                double x3 = drillCalcItemList3[index1].Center.X;
                double x4 = drillCalcItemList3[index1].Center.X;
                num14 = drillCalcItemList3[index1].Depth;
                drillCalcItemList3[index1].Calculated = true;
                t2 = foundTool4.Data.No;
              }
            }
            else
              flag2 = false;
          }
          else
            flag2 = false;
          if (num15 == this.NoMove & num15 != num3)
            num15 = clsDrill.varDrillCNCSettings.Z1SafeDistance;
          if (num16 == this.NoMove & num16 != num4)
            num16 = clsDrill.varDrillCNCSettings.Z2SafeDistance;
          if (num15 == num3)
            num15 = this.NoMove;
          if (num16 == num4)
            num16 = this.NoMove;
          if (flag1 & !flag2 && Y1 - Job.Moves[Job.Moves.Count - 1].Y2Position < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
            Y2 = Y1 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
          if (!flag1 & flag2 && Job.Moves[Job.Moves.Count - 1].Y1Position - Y2 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
            Y1 = Y2 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
          if (flag1 | flag2)
          {
            double XOffset = 0.0;
            double YOffset = 0.0;
            if (foundTool3 != null)
            {
              ToolBase5 toolBase5 = new ToolBase5(foundTool3);
              this.GetXYToolOffsetFromNo(foundTool3.Data.No, ref XOffset, ref YOffset);
            }
            else
            {
              ToolBase5 toolBase5 = new ToolBase5(foundTool4);
              this.GetXYToolOffsetFromNo(foundTool4.Data.No, ref XOffset, ref YOffset);
            }
            this.AddDrillMove(this.NoMove, this.NoMove, Y1, Y2, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, t1, t2), ref Job);
            double X6 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + Items[0].Center.X;
            double num17 = X6 - Job.Moves[Job.Moves.Count - 1].XPosition;
            double num18 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num17;
            double num19 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num17;
            if (num18 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
            {
              double num20 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillMachineSettings.MachineMinXStroke;
              double X7 = X6 + Math.Abs(num17) - num20;
              this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num20, Job.Moves[Job.Moves.Count - 1].X2Clamper - num20, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X7, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
              double num21 = num17 + num20;
              double num22 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num21;
              double num23 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num21;
              double num24 = num22 - clsDrill.varDrillMachineSettings.MachineMinXStroke;
              double num25 = num22 - num24;
              double num26 = num23 - num24;
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, num26 - num24, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(num25 - num24, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num21, Job.Moves[Job.Moves.Count - 1].X2Clamper + num21, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X6, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
            }
            else
              this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num17, Job.Moves[Job.Moves.Count - 1].X2Clamper + num17, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X6, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
            double Z1_1 = this.NoMove;
            double Z2_1 = this.NoMove;
            if (flag1 & num15 != this.NoMove)
              Z1_1 = num15 + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
            if (flag2 & num16 != this.NoMove)
              Z2_1 = num16 + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
            this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, Z1_1, Z2_1, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
            this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.SetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, t1, t2), ref Job);
            if (flag1)
            {
              int Index = -1;
              this.GetIndexFromItemID(drillCalcItemList2[index1].ID, Items, ref Index);
              if (Index >= 0)
                Items[Index].OffsetedPoint.X = X6;
            }
            if (flag2)
            {
              int Index = -1;
              this.GetIndexFromItemID(drillCalcItemList3[index1].ID, Items, ref Index);
              if (Index >= 0)
                Items[Index].OffsetedPoint.X = X6;
            }
            double Z1_2 = this.NoMove;
            double Z2_2 = this.NoMove;
            if (flag1 & num15 != this.NoMove)
              Z1_2 = num15 - num14;
            if (flag2 & num16 != this.NoMove)
              Z2_2 = num16 - num14;
            this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, Z1_2, Z2_2, this.NoMove, DrillMoveCommand.AxisMove, X6, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
            double X8 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + Items[0].Center.X + Items[0].Length;
            double num27 = X8 - Job.Moves[Job.Moves.Count - 1].XPosition;
            double X1_4 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num27;
            double X2_4 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num27;
            if (X2_4 > clsDrill.varDrillMachineSettings.MachineMaxXStroke)
            {
              double num28 = X2_4 - clsDrill.varDrillMachineSettings.MachineMaxXStroke;
              double X1_5 = X1_4 - num28;
              double X2_5 = X2_4 - num28;
              double X9 = X8 - num28;
              this.AddDrillMove(X1_5, X2_5, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X9, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(X1_5 - num28, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, X2_5 - num28, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Up, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
              this.AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num28, Job.Moves[Job.Moves.Count - 1].X2Clamper + num28, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X8, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
            }
            else
              this.AddDrillMove(X1_4, X2_4, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, X8, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
            double Z1_3 = this.NoMove;
            double Z2_3 = this.NoMove;
            if (flag1 & num15 != this.NoMove)
              Z1_3 = num15 + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
            if (flag2 & num16 != this.NoMove)
              Z2_3 = num16 + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
            this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, Z1_3, Z2_3, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
            num15 = Z1_3;
            num16 = Z2_3;
            if (t1 != 0 | t2 != 0)
              this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetPiston, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, t1, t2), ref Job);
          }
          num3 = num15;
          num4 = num16;
        }
      }
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.ResetAllPress, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, this.NoMove, DrillMoveCommand.AxisMove, this.NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
    }
  }

  public void CreateCodeForShapeTopAndBottomSide(
    ref List<DrillItem> ItemShape,
    bool preCalculation,
    bool isTop,
    ToolBase5 toolFound,
    ref DrillJob Job)
  {
    double Y1_1 = 0.0;
    double Y2 = 0.0;
    double Y3_1 = 0.0;
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
    double num1 = 1000.0;
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
    camTp Cam1 = new camTp();
    camTp Cam2 = new camTp();
    camTp camTp1 = new camTp();
    camTp Cam3 = new camTp();
    camTp Cam4 = new camTp();
    camTp camTp2 = new camTp();
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
    for (int index1 = 0; index1 <= ItemShape.Count - 1; ++index1)
    {
      if (ItemShape[index1].ToolMilling != null)
        toolFound = new ToolBase5(ItemShape[index1].ToolMilling);
      num1 = ItemShape[index1].ShapeData.Depth;
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
        buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = ItemShape[index1].CamPars.Offsets.ClosedContour;
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
          if (isTop)
          {
            buMWDrillVars.varCamContour.buPar.Distances.Rapid = num1 + clsDrill.varDrillCNCSettings.distanceSmallSafe;
            buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = num1 + clsDrill.varDrillCNCSettings.distanceSmallSafe;
            ccVars.toolActive.CamData.SpindleSpeed = clsDrill.varDrillCNCSettings.TopSpindleSpeed;
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num1;
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - num1;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num1;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - num1;
            buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth - num1;
            buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - num1;
            if (ItemShape[index1].StepEnable)
            {
              buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num1;
              buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
              buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
              buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num1;
              buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
              buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
              buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth - num1;
              buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth;
            }
          }
          else
          {
            buMWDrillVars.varCamContour.buPar.Distances.Rapid = num1 + clsDrill.varDrillCNCSettings.distanceSmallSafe;
            buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = num1 + clsDrill.varDrillCNCSettings.distanceSmallSafe;
            buMWDrillVars.varCamContour.buPar.Steps.Enable = ItemShape[index1].StepEnable;
            buMWDrillVars.varCamContour.buPar.Steps.StartValue = -num1;
            buMWDrillVars.varCamContour.buPar.Steps.EndValue = -num1;
            ccVars.toolActive.CamData.SpindleSpeed = clsDrill.varDrillCNCSettings.BottomSpindleSpeed;
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = -num1;
            buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = -num1;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = -num1;
            buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = -num1;
            if (ItemShape[index1].StepEnable)
            {
              buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = -num1;
              buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = 0.0;
              buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
              buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = -num1;
              buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = 0.0;
              buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[index1].StepValue;
              buMWDrillVars.varCamContour.buPar.Steps.StartValue = 0.0;
              buMWDrillVars.varCamContour.buPar.Steps.EndValue = -num1;
            }
          }
          if (entityList6.Count > 0)
          {
            bool flag1 = false;
            clsMW.CamEntities.Clear();
            for (int index4 = 0; index4 <= entityList6.Count - 1; ++index4)
            {
              Entity copiedEnt = (Entity) null;
              buVector5.CopyEntities(entityList6[index4], ref copiedEnt);
              clsMW.CamEntities.Add(copiedEnt);
            }
            MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
            Cam1 = new camTp();
            this.doWireframeContour(MWCalcoptions, toolFound, ref Cam1);
            for (int index5 = 0; index5 <= Cam1.CamPoints.Count - 1; ++index5)
              Cam1.CamPoints[index5].ToolCam = new ToolBase5(toolFound);
            Cam1.Tool = new ToolBase5(toolFound);
            if (ItemShape[index1].Command == drillCommands.DrawingContour | ItemShape[index1].isMillingAtClamperSide)
            {
              if (copiedEntities.Count == 2 && index2 == 1)
              {
                bool flag2 = false;
                if (ItemShape[index1].X1First)
                {
                  Cam1.Aux1First = ItemShape[index1].X1First;
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam1.Aux1 = ItemShape[index1].X1Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                    flag2 = true;
                  }
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam1.Aux2 = ItemShape[index1].X2Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                    flag2 = true;
                  }
                }
                else
                {
                  Cam1.Aux1First = ItemShape[index1].X1First;
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam1.Aux2 = ItemShape[index1].X2Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                    flag2 = true;
                  }
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam1.Aux1 = ItemShape[index1].X1Move;
                    Cam1.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                    flag2 = true;
                  }
                }
                if (flag2)
                {
                  if (ItemShape[index1].planeName == planeBoxNames.Top)
                  {
                    Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                    Cam1.CamPoints[0].PreCodes.Add((object) "M27");
                  }
                  if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                  {
                    Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                    Cam1.CamPoints[0].PreCodes.Add((object) "M29");
                  }
                  Cam1.CamPoints[0].PreCodes.Add((object) "M46");
                }
              }
              if (copiedEntities.Count == 3)
              {
                if (ItemShape[index1].Command == drillCommands.DrawingContour)
                {
                  if (index2 == 1)
                  {
                    bool flag3 = false;
                    if (ItemShape[index1].X2Move != 0.0 && ItemShape[index1].ClockDir == ClockDirectionType.CW)
                    {
                      Cam1.Aux1First = false;
                      Cam1.Aux2 = ItemShape[index1].X2Move;
                      Cam1.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                      Cam1.Aux1 = ItemShape[index1].X2Move;
                      Cam1.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X2Move.ToString("f1")));
                      flag3 = true;
                    }
                    if (ItemShape[index1].X1Move != 0.0 && ItemShape[index1].ClockDir == ClockDirectionType.CCW)
                    {
                      Cam1.Aux1First = true;
                      Cam1.Aux1 = ItemShape[index1].X1Move;
                      Cam1.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                      Cam1.Aux2 = ItemShape[index1].X1Move;
                      Cam1.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X1Move.ToString("f1")));
                      flag3 = true;
                    }
                    if (flag3)
                    {
                      if (ItemShape[index1].planeName == planeBoxNames.Top)
                      {
                        Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                        Cam1.CamPoints[0].PreCodes.Add((object) "M27");
                      }
                      if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                      {
                        Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                        Cam1.CamPoints[0].PreCodes.Add((object) "M29");
                      }
                      Cam1.CamPoints[0].PreCodes.Add((object) "M46");
                    }
                  }
                  if (index2 == 2)
                  {
                    bool flag4 = false;
                    if (ItemShape[index1].X1Move != 0.0)
                    {
                      if (ItemShape[index1].ClockDir == ClockDirectionType.CW)
                      {
                        Cam1.Aux1 = ItemShape[index1].X1Move;
                        Cam1.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                        ItemShape[index1].X1Move += ItemShape[index1].X2Move;
                      }
                      flag4 = true;
                    }
                    if (ItemShape[index1].X2Move != 0.0 && ItemShape[index1].ClockDir == ClockDirectionType.CCW)
                    {
                      Cam1.Aux2 = ItemShape[index1].X2Move;
                      Cam1.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                      ItemShape[index1].X2Move = ItemShape[index1].X1Move + ItemShape[index1].X2Move;
                      flag4 = true;
                    }
                    if (flag4)
                    {
                      if (ItemShape[index1].planeName == planeBoxNames.Top)
                      {
                        Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                        Cam1.CamPoints[0].PreCodes.Add((object) "M27");
                      }
                      if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                      {
                        Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                        Cam1.CamPoints[0].PreCodes.Add((object) "M29");
                      }
                      Cam1.CamPoints[0].PreCodes.Add((object) "M46");
                    }
                  }
                }
                else
                {
                  if (index2 == 1)
                  {
                    bool flag5 = false;
                    if (ItemShape[index1].X2Move != 0.0)
                    {
                      Cam1.Aux2 = ItemShape[index1].X2Move;
                      Cam1.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                      flag5 = true;
                    }
                    if (flag5)
                    {
                      if (ItemShape[index1].planeName == planeBoxNames.Top)
                      {
                        Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                        Cam1.CamPoints[0].PreCodes.Add((object) "M27");
                      }
                      if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                      {
                        Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                        Cam1.CamPoints[0].PreCodes.Add((object) "M29");
                      }
                      Cam1.CamPoints[0].PreCodes.Add((object) "M46");
                    }
                  }
                  if (index2 == 2)
                  {
                    bool flag6 = false;
                    if (ItemShape[index1].X1Move != 0.0)
                    {
                      Cam1.Aux1 = ItemShape[index1].X1Move;
                      Cam1.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                      flag6 = true;
                    }
                    if (flag6)
                    {
                      if (ItemShape[index1].planeName == planeBoxNames.Top)
                        Cam1.CamPoints[0].PreCodes.Add((object) "M27");
                      if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                        Cam1.CamPoints[0].PreCodes.Add((object) "M29");
                      Cam1.CamPoints[0].PreCodes.Add((object) "M46");
                    }
                  }
                }
              }
            }
            else
            {
              bool flag7 = false;
              if (ItemShape[index1].X1First)
              {
                Cam1.Aux1First = ItemShape[index1].X1First;
                if (ItemShape[index1].X1Move != 0.0 & Cam1.CamPoints.Count > 0)
                {
                  Cam1.Aux1 = ItemShape[index1].X1Move;
                  Cam1.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                  flag7 = true;
                }
                if (ItemShape[index1].X2Move != 0.0 & Cam1.CamPoints.Count > 0)
                {
                  Cam1.Aux2 = ItemShape[index1].X2Move;
                  Cam1.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                  flag7 = true;
                }
              }
              else
              {
                Cam1.Aux1First = ItemShape[index1].X1First;
                if (ItemShape[index1].X2Move != 0.0)
                {
                  Cam1.Aux2 = ItemShape[index1].X2Move;
                  Cam1.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                  flag7 = true;
                }
                if (ItemShape[index1].X1Move != 0.0)
                {
                  Cam1.Aux1 = ItemShape[index1].X1Move;
                  Cam1.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                  flag7 = true;
                }
              }
              if (flag7)
              {
                flag1 = true;
                if (ItemShape[index1].planeName == planeBoxNames.Top)
                {
                  Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                  Cam1.CamPoints[0].PreCodes.Add((object) "M27");
                }
                if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                {
                  Cam1.CamPoints[0].PreCodes.Add((object) "G75");
                  Cam1.CamPoints[0].PreCodes.Add((object) "M29");
                }
                Cam1.CamPoints[0].PreCodes.Add((object) "M46");
              }
            }
            if (ItemShape[index1].BoxMinItem.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth & !isTop & (clsDrill.varDrillCNCSettings.MoveY3AxisToSafeIfOperationAtClamperSideFroBottom | flag1))
            {
              if (Cam1.CamPoints.Count > 0 && Cam1.CamPoints[0].Points.Count > 0)
              {
                Cam1.CamPoints[0].Points.Insert(0, new TpPnt9D(Cam1.CamPoints[0].Points[0])
                {
                  EnableAxes = new AxesEnableWithUVW(true, false, false, false, false, false)
                });
                TpPnt9D tpPnt9D = new TpPnt9D(Cam1.CamPoints[0].Points[Cam1.CamPoints[0].Points.Count - 1]);
                tpPnt9D.P9.Y = 300.0;
                tpPnt9D.EnableAxes = new AxesEnableWithUVW(false, true, false, false, false, false);
                Cam1.CamPoints[0].Points.Add(tpPnt9D);
              }
              Cam1.SimilationPoint.SimMove.Clear();
              List<Pnt6DSimMove> simPoints = new List<Pnt6DSimMove>();
              if (index1 == 0 && Cam1.CamPoints.Count > 0)
              {
                TpPnt9D pntFirst = new TpPnt9D(0.0, Job.Moves[Job.Moves.Count - 1].Y3Position, Job.Moves[Job.Moves.Count - 1].Z3Position);
                clsInit.cCam5.SimilationPointBetweenTwoPoints(pntFirst, Cam1.CamPoints[0].Points[0], ref simPoints, 20.0);
                if (simPoints.Count >= 2)
                  simPoints.RemoveAt(simPoints.Count - 1);
              }
              if (Cam1.CamPoints.Count > 0)
                clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam1, Cam1.CamPoints[0], 20.0, 5.0);
              if (simPoints.Count > 0)
                Cam1.SimilationPoint.SimMove.InsertRange(0, (IEnumerable<Pnt6DSimMove>) simPoints);
            }
            if (isTop && Cam1.CamPoints.Count > 0)
            {
              if (clsDrill.activeJob.Material.Size.Depth - ItemShape[index1].ShapeData.Depth <= 2.0)
                Cam1.CamPoints[0].Points[0].PreCodes.Add((object) "M32");
              else
                Cam1.CamPoints[0].Points[0].PreCodes.Add((object) "M33");
            }
            if (Cam1.CamPoints.Count > 0)
            {
              for (int index6 = 0; index6 <= Cam1.CamPoints.Count - 1; ++index6)
                camTp2.CamPoints.Add(new camTpPoint(Cam1.CamPoints[index6]));
              camTp2.PlaneName = !isTop ? planeNames.Bottom : planeNames.Top;
            }
            if (Cam1.SimilationPoint.SimMove.Count > 0)
            {
              if (camTp2.SimilationPoint.SimMove.Count > 0)
              {
                List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
                clsInit.cVector5.LineerInterpolation(camTp2.SimilationPoint.SimMove[camTp2.SimilationPoint.SimMove.Count - 1], Cam1.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints);
                if (CalculatedPoints.Count >= 3)
                {
                  CalculatedPoints.RemoveAt(0);
                  CalculatedPoints.RemoveAt(CalculatedPoints.Count - 1);
                  for (int index7 = 0; index7 <= CalculatedPoints.Count - 1; ++index7)
                    camTp2.SimilationPoint.SimMove.Add(CalculatedPoints[index7]);
                }
              }
              if (Cam1.Aux1 != 0.0 & Cam1.Aux2 != 0.0)
              {
                if (Cam1.Aux1First)
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[Cam1.SimilationPoint.SimMove.Count - 1]);
                  camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam1.Aux1
                  });
                  camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam1.Aux2
                  });
                }
                else
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[Cam1.SimilationPoint.SimMove.Count - 1]);
                  camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam1.Aux2
                  });
                  camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam1.Aux1
                  });
                }
              }
              else if (Cam1.Aux1 != 0.0 & Cam1.Aux2 == 0.0)
                camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[Cam1.SimilationPoint.SimMove.Count - 1])
                {
                  Aux1 = Cam1.Aux1
                });
              else if (Cam1.Aux1 == 0.0 & Cam1.Aux2 != 0.0)
                camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[Cam1.SimilationPoint.SimMove.Count - 1])
                {
                  Aux2 = Cam1.Aux2
                });
              for (int index8 = 0; index8 <= Cam1.SimilationPoint.SimMove.Count - 1; ++index8)
                camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam1.SimilationPoint.SimMove[index8]));
            }
          }
          if (entityList7.Count > 0)
          {
            clsMW.CamEntities.Clear();
            for (int index9 = 0; index9 <= entityList7.Count - 1; ++index9)
            {
              Entity copiedEnt = (Entity) null;
              buVector5.CopyEntities(entityList7[index9], ref copiedEnt);
              clsMW.CamEntities.Add(copiedEnt);
            }
            MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
            this.doWireframePocket(MWCalcoptions, toolFound, ref Cam2);
            if (ItemShape[index1].isMillingAtClamperSide)
            {
              if (copiedEntities.Count == 2 && index2 == 1)
              {
                bool flag = false;
                if (ItemShape[index1].X1First)
                {
                  Cam2.Aux1First = ItemShape[index1].X1First;
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam2.Aux1 = ItemShape[index1].X1Move;
                    Cam2.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                    flag = true;
                  }
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam2.Aux2 = ItemShape[index1].X2Move;
                    Cam2.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                    flag = true;
                  }
                }
                else
                {
                  Cam2.Aux1First = ItemShape[index1].X1First;
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam2.Aux2 = ItemShape[index1].X2Move;
                    Cam2.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                    flag = true;
                  }
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam2.Aux1 = ItemShape[index1].X1Move;
                    Cam2.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                    flag = true;
                  }
                }
                if (flag)
                {
                  if (ItemShape[index1].planeName == planeBoxNames.Top)
                  {
                    Cam2.CamPoints[0].PreCodes.Add((object) "G75");
                    Cam2.CamPoints[0].PreCodes.Add((object) "M27");
                  }
                  if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                  {
                    Cam2.CamPoints[0].PreCodes.Add((object) "G75");
                    Cam2.CamPoints[0].PreCodes.Add((object) "M29");
                  }
                  Cam2.CamPoints[0].PreCodes.Add((object) "M46");
                }
              }
              if (copiedEntities.Count == 3)
              {
                if (index2 == 1)
                {
                  bool flag = false;
                  if (ItemShape[index1].X2Move != 0.0)
                  {
                    Cam2.Aux2 = ItemShape[index1].X2Move;
                    Cam2.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                    flag = true;
                  }
                  if (flag)
                  {
                    if (ItemShape[index1].planeName == planeBoxNames.Top)
                    {
                      Cam2.CamPoints[0].PreCodes.Add((object) "G75");
                      Cam2.CamPoints[0].PreCodes.Add((object) "M27");
                    }
                    if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                    {
                      Cam2.CamPoints[0].PreCodes.Add((object) "G75");
                      Cam2.CamPoints[0].PreCodes.Add((object) "M29");
                    }
                    Cam2.CamPoints[0].PreCodes.Add((object) "M46");
                  }
                }
                if (index2 == 2)
                {
                  bool flag = false;
                  if (ItemShape[index1].X1Move != 0.0)
                  {
                    Cam2.Aux1 = ItemShape[index1].X1Move;
                    Cam2.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                    flag = true;
                  }
                  if (flag)
                  {
                    if (ItemShape[index1].planeName == planeBoxNames.Top)
                      Cam2.CamPoints[0].PreCodes.Add((object) "M27");
                    if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                      Cam2.CamPoints[0].PreCodes.Add((object) "M29");
                    Cam2.CamPoints[0].PreCodes.Add((object) "M46");
                  }
                }
              }
            }
            else
            {
              bool flag = false;
              if (ItemShape[index1].X1First)
              {
                Cam2.Aux1First = ItemShape[index1].X1First;
                if (ItemShape[index1].X1Move != 0.0 & Cam2.CamPoints.Count > 0)
                {
                  Cam2.Aux1 = ItemShape[index1].X1Move;
                  Cam2.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                  flag = true;
                }
                if (ItemShape[index1].X2Move != 0.0 & Cam2.CamPoints.Count > 0)
                {
                  Cam2.Aux2 = ItemShape[index1].X2Move;
                  Cam2.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                  flag = true;
                }
              }
              else
              {
                Cam2.Aux1First = ItemShape[index1].X1First;
                if (ItemShape[index1].X2Move != 0.0)
                {
                  Cam2.Aux2 = ItemShape[index1].X2Move;
                  Cam2.CamPoints[0].PreCodes.Add((object) ("M45 K" + ItemShape[index1].X2Move.ToString("f1")));
                  flag = true;
                }
                if (ItemShape[index1].X1Move != 0.0)
                {
                  Cam2.Aux1 = ItemShape[index1].X1Move;
                  Cam2.CamPoints[0].PreCodes.Add((object) ("M44 K" + ItemShape[index1].X1Move.ToString("f1")));
                  flag = true;
                }
              }
              if (flag)
              {
                if (ItemShape[index1].planeName == planeBoxNames.Top)
                {
                  Cam2.CamPoints[0].PreCodes.Add((object) "G75");
                  Cam2.CamPoints[0].PreCodes.Add((object) "M27");
                }
                if (ItemShape[index1].planeName == planeBoxNames.Bottom)
                {
                  Cam2.CamPoints[0].PreCodes.Add((object) "G75");
                  Cam2.CamPoints[0].PreCodes.Add((object) "M29");
                }
                Cam2.CamPoints[0].PreCodes.Add((object) "M46");
              }
            }
            if (ItemShape[index1].BoxMinItem.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth & !isTop)
            {
              if (Cam1.CamPoints.Count > 0 && Cam1.CamPoints[0].Points.Count > 0)
              {
                Cam1.CamPoints[0].Points.Insert(0, new TpPnt9D(Cam1.CamPoints[0].Points[0])
                {
                  EnableAxes = new AxesEnableWithUVW(true, false, false, false, false, false)
                });
                TpPnt9D tpPnt9D = new TpPnt9D(Cam1.CamPoints[0].Points[Cam1.CamPoints[0].Points.Count - 1]);
                tpPnt9D.P9.Y = 300.0;
                tpPnt9D.EnableAxes = new AxesEnableWithUVW(false, true, false, false, false, false);
                Cam1.CamPoints[0].Points.Add(tpPnt9D);
              }
              Cam1.SimilationPoint.SimMove.Clear();
              List<Pnt6DSimMove> simPoints = new List<Pnt6DSimMove>();
              if (index1 == 0)
              {
                TpPnt9D pntFirst = new TpPnt9D(0.0, Job.Moves[Job.Moves.Count - 1].Y3Position, Job.Moves[Job.Moves.Count - 1].Z3Position);
                clsInit.cCam5.SimilationPointBetweenTwoPoints(pntFirst, Cam1.CamPoints[0].Points[0], ref simPoints, 20.0);
                if (simPoints.Count >= 2)
                  simPoints.RemoveAt(simPoints.Count - 1);
              }
              clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam1, Cam1.CamPoints[0]);
              if (simPoints.Count > 0)
                Cam1.SimilationPoint.SimMove.InsertRange(0, (IEnumerable<Pnt6DSimMove>) simPoints);
            }
            if (Cam2.CamPoints.Count > 0)
            {
              for (int index10 = 0; index10 <= Cam2.CamPoints.Count - 1; ++index10)
              {
                camTp2.CamPoints.Add(new camTpPoint(Cam2.CamPoints[index10]));
                if (isTop)
                {
                  if (index10 == 0)
                    camTp2.CamPoints[index10].PreCodes.Add((object) "M34");
                  if (index10 == Cam2.CamPoints.Count - 1)
                    camTp2.CamPoints[index10].AfterCodes.Add((object) "M35");
                  if (camTp2.CamPoints.Count > 0)
                  {
                    if (clsDrill.activeJob.Material.Size.Depth - ItemShape[index1].ShapeData.Depth <= 2.0)
                      camTp2.CamPoints[0].Points[0].PreCodes.Add((object) "M32");
                    else
                      camTp2.CamPoints[0].Points[0].PreCodes.Add((object) "M33");
                  }
                  camTp2.PlaneName = planeNames.Top;
                }
                else
                  camTp2.PlaneName = planeNames.Bottom;
              }
            }
            if (Cam2.SimilationPoint.SimMove.Count > 0)
            {
              if (camTp2.SimilationPoint.SimMove.Count > 0)
              {
                List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
                clsInit.cVector5.LineerInterpolation(camTp2.SimilationPoint.SimMove[camTp2.SimilationPoint.SimMove.Count - 1], Cam2.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints);
                if (CalculatedPoints.Count >= 3)
                {
                  CalculatedPoints.RemoveAt(0);
                  CalculatedPoints.RemoveAt(CalculatedPoints.Count - 1);
                  for (int index11 = 0; index11 <= CalculatedPoints.Count - 1; ++index11)
                    camTp2.SimilationPoint.SimMove.Add(CalculatedPoints[index11]);
                }
              }
              if (Cam2.Aux1 != 0.0 & Cam2.Aux2 != 0.0)
              {
                if (Cam2.Aux1First)
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[Cam2.SimilationPoint.SimMove.Count - 1]);
                  camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam2.Aux1
                  });
                  camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam2.Aux2
                  });
                }
                else
                {
                  Pnt6DSimMove Pnt = new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[Cam2.SimilationPoint.SimMove.Count - 1]);
                  camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux2 = Cam2.Aux2
                  });
                  camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Pnt)
                  {
                    Aux1 = Cam2.Aux1
                  });
                }
              }
              else if (Cam2.Aux1 != 0.0 & Cam2.Aux2 == 0.0)
                camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[Cam2.SimilationPoint.SimMove.Count - 1])
                {
                  Aux1 = Cam2.Aux1
                });
              else if (Cam2.Aux1 == 0.0 & Cam2.Aux2 != 0.0)
                camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[Cam2.SimilationPoint.SimMove.Count - 1])
                {
                  Aux2 = Cam2.Aux2
                });
              for (int index12 = 0; index12 <= Cam2.SimilationPoint.SimMove.Count - 1; ++index12)
                camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[index12]));
            }
          }
        }
      }
      if (ItemShape[index1].Command == drillCommands.Engraving)
      {
        for (int index13 = 0; index13 <= ItemShape[index1].solidEntities.Count - 1; ++index13)
        {
          if (ItemShape[index1].isRough)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(ItemShape[index1].solidEntities[index13], ref copiedEntity);
            entityList4.Add(copiedEntity);
          }
          if (ItemShape[index1].isFinish)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(ItemShape[index1].solidEntities[index13], ref copiedEntity);
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
    if (entityList4.Count > 0)
    {
      clsMW.CamEntities.Clear();
      for (int index = 0; index <= entityList4.Count - 1; ++index)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(entityList4[index], ref copiedEnt);
        Mirror xform1 = new Mirror(new Plane(new Point3D(), Vector3D.AxisX, Vector3D.AxisZ));
        copiedEnt.TransformBy((Transformation) xform1);
        Mirror xform2 = new Mirror(new Plane(new Point3D(), Vector3D.AxisY, Vector3D.AxisZ));
        copiedEnt.TransformBy((Transformation) xform2);
        clsMW.CamEntities.Add(copiedEnt);
      }
      if (clsMW.CamEntities.Count > 0)
      {
        MWCalcoptions = new MWCalculationOptions();
        MWCalcoptions.NumberofAxis = 3;
        MWCalcoptions.Mode = CamMode.TriangularMesh;
        MWCalcoptions.CamTriMeshType = CamTriangularMeshType.Rough;
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
        this.doTriangleMeshRough(MWCalcoptions, toolFound, ref Cam3);
        if (Cam3.CamPoints.Count > 0)
        {
          Cam3.CamPoints[0].PreCodes.Add((object) "M34");
          for (int index = 0; index <= Cam3.CamPoints.Count - 1; ++index)
            camTp2.CamPoints.Add(new camTpPoint(Cam3.CamPoints[index]));
          for (int index = 0; index <= Cam3.SimilationPoint.SimMove.Count - 1; ++index)
            camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam3.SimilationPoint.SimMove[index]));
        }
      }
    }
    if (entityList5.Count > 0)
    {
      clsMW.CamEntities.Clear();
      for (int index = 0; index <= entityList5.Count - 1; ++index)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(entityList5[index], ref copiedEnt);
        Mirror xform3 = new Mirror(new Plane(new Point3D(), Vector3D.AxisX, Vector3D.AxisZ));
        copiedEnt.TransformBy((Transformation) xform3);
        Mirror xform4 = new Mirror(new Plane(new Point3D(), Vector3D.AxisY, Vector3D.AxisZ));
        copiedEnt.TransformBy((Transformation) xform4);
        clsMW.CamEntities.Add(copiedEnt);
      }
      if (clsMW.CamEntities.Count > 0)
      {
        MWCalcoptions = new MWCalculationOptions();
        MWCalcoptions.NumberofAxis = 3;
        MWCalcoptions.Mode = CamMode.TriangularMesh;
        MWCalcoptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
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
        this.doTriangleMeshParalelCut(MWCalcoptions, toolFound, ref Cam4);
        if (Cam4.CamPoints.Count > 0)
        {
          Cam4.CamPoints[0].PreCodes.Add((object) "M34");
          for (int index = 0; index <= Cam4.CamPoints.Count - 1; ++index)
            camTp2.CamPoints.Add(new camTpPoint(Cam4.CamPoints[index]));
          for (int index = 0; index <= Cam4.SimilationPoint.SimMove.Count - 1; ++index)
            camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam4.SimilationPoint.SimMove[index]));
        }
      }
    }
    if (entityList3.Count > 0)
    {
      clsMW.CamEntities.Clear();
      for (int index14 = 0; index14 <= entityList3.Count - 1; ++index14)
      {
        camTp Cam5 = new camTp();
        clsMW.CamEntities.Clear();
        Entity copiedEnt = (Entity) null;
        double Depth = !isTop ? -((CustomData) entityList3[index14].EntityData).infoDepth : clsDrill.activeJob.Material.Size.Depth - ((CustomData) entityList3[index14].EntityData).infoDepth;
        buVector5.CopyEntities(entityList3[index14], ref copiedEnt);
        clsMW.CamEntities.Add(copiedEnt);
        ToolBase5 toolBase5_2 = new ToolBase5();
        for (int index15 = 0; index15 <= ccVars.Tools[0].Tools.Count - 1; ++index15)
        {
          Circle circle = entityList3[index14] as Circle;
          if (isTop)
          {
            if (ccVars.Tools[0].Tools[index15].Data.No >= 31 /*0x1F*/ & ccVars.Tools[0].Tools[index15].Data.No <= 35 && ccVars.Tools[0].Tools[index15].Geometry.Diameter == circle.Diameter)
              toolBase5_2 = new ToolBase5(ccVars.Tools[0].Tools[index15]);
          }
          else if (ccVars.Tools[0].Tools[index15].Data.No == 41 && ccVars.Tools[0].Tools[index15].Geometry.Diameter == circle.Diameter)
            toolBase5_2 = new ToolBase5(ccVars.Tools[0].Tools[index15]);
        }
        this.doDrill(MWCalcoptions, Depth, toolBase5_2, ref Cam5);
        if (isTop && Cam5.CamPoints.Count > 0)
        {
          if (Depth <= 2.0)
            Cam5.CamPoints[0].Points[0].PreCodes.Add((object) "M32");
          else
            Cam5.CamPoints[0].Points[0].PreCodes.Add((object) "M33");
        }
        if (Cam5.CamPoints.Count > 0)
        {
          for (int index16 = 0; index16 <= Cam5.CamPoints.Count - 1; ++index16)
            camTp2.CamPoints.Add(new camTpPoint(Cam5.CamPoints[index16])
            {
              ToolCam = new ToolBase5(toolBase5_2)
            });
        }
        if (Cam5.SimilationPoint.SimMove.Count > 0)
        {
          for (int index17 = 0; index17 <= Cam5.SimilationPoint.SimMove.Count - 1; ++index17)
            camTp2.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam5.SimilationPoint.SimMove[index17]));
        }
      }
    }
    if (clsItem.FrmProgress != null)
      clsItem.FrmProgress.Visible = false;
    List<DrillMove> drillMoveList = new List<DrillMove>();
    if (isTop)
    {
      double XPos2 = 0.0;
      double X1_2 = 0.0;
      double X2_2 = 0.0;
      DrillMove drillMove1 = new DrillMove();
      if (Job.SimulationMoves.Count > 0)
      {
        XPos2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].XPosition;
        X1_2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
        X2_2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
        X1_1 = X1_2;
        X2_1 = X2_2;
        Y1_1 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y1Position;
        Y2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y2Position;
        Y3_1 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y3Position;
        Z1 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z1Position;
        Z2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z2Position;
        Z3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z3Position;
        DrillMove drillMove2 = new DrillMove(X1_2, X2_2, Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.SetPiston, XPos2, DrillCNCMode.None, drillPlaneNames.Top, 80 /*0x50*/, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        Job.SimulationMoves.Add(drillMove2);
      }
      double num2 = 0.0;
      double num3 = 0.0;
      for (int index18 = 0; index18 <= camTp2.SimilationPoint.SimMove.Count - 1; ++index18)
      {
        if (camTp2.SimilationPoint.SimMove[index18].Aux1 != 0.0 | camTp2.SimilationPoint.SimMove[index18].Aux2 != 0.0)
        {
          if (camTp2.SimilationPoint.SimMove[index18].Aux1 != 0.0)
          {
            num2 += camTp2.SimilationPoint.SimMove[index18].Aux1;
            DrillMove drillMove3 = new DrillMove(X1_1, X2_1, Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.Clamper1Up, XPos1, DrillCNCMode.None, drillPlaneNames.Top, 80 /*0x50*/, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove3);
            List<double> Values = new List<double>();
            buNumeric5.DevideMinMaxValueByNumber(0.0, camTp2.SimilationPoint.SimMove[index18].Aux1, 5, ref Values);
            double x1Clamper = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
            for (int index19 = 1; index19 <= Values.Count - 1; ++index19)
            {
              DrillMove drillMove4 = new DrillMove(X1_1 + Values[index19], X2_1, Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1, DrillCNCMode.None, drillPlaneNames.Top, 80 /*0x50*/, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
              Job.SimulationMoves.Add(drillMove4);
            }
            X1_1 += camTp2.SimilationPoint.SimMove[index18].Aux1;
            DrillMove drillMove5 = new DrillMove(X1_1, X2_1, Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.Clamper1Down, XPos1, DrillCNCMode.None, drillPlaneNames.Top, 80 /*0x50*/, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove5);
          }
          if (camTp2.SimilationPoint.SimMove[index18].Aux2 != 0.0)
          {
            num3 += camTp2.SimilationPoint.SimMove[index18].Aux2;
            DrillMove drillMove6 = new DrillMove(X1_1, X2_1, Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.Clamper2Up, XPos1, DrillCNCMode.None, drillPlaneNames.Top, 80 /*0x50*/, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove6);
            List<double> Values = new List<double>();
            buNumeric5.DevideMinMaxValueByNumber(0.0, camTp2.SimilationPoint.SimMove[index18].Aux2, 5, ref Values);
            double x2Clamper = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
            for (int index20 = 1; index20 <= Values.Count - 1; ++index20)
            {
              DrillMove drillMove7 = new DrillMove(X1_1, X2_1 + Values[index20], Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1, DrillCNCMode.None, drillPlaneNames.Top, 80 /*0x50*/, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
              Job.SimulationMoves.Add(drillMove7);
            }
            X2_1 += camTp2.SimilationPoint.SimMove[index18].Aux2;
            DrillMove drillMove8 = new DrillMove(X1_1, X2_1, Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.Clamper2Down, XPos1, DrillCNCMode.None, drillPlaneNames.Top, 80 /*0x50*/, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove8);
          }
        }
        else
        {
          X1_2 = X1_2 + camTp2.SimilationPoint.SimMove[index18].X - XPos2;
          X2_2 = X2_2 + camTp2.SimilationPoint.SimMove[index18].X - XPos2;
          XPos1 = camTp2.SimilationPoint.SimMove[index18].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
          X1_1 = X1_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num2;
          X2_1 = X2_2 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num3;
          Y1_1 = camTp2.SimilationPoint.SimMove[index18].Y;
          Z1 = camTp2.SimilationPoint.SimMove[index18].Z;
          if (index18 == camTp2.SimilationPoint.SimMove.Count - 1)
          {
            DrillMove drillMove9 = new DrillMove(X1_1, X2_1, Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.ResetPiston, XPos1, DrillCNCMode.None, drillPlaneNames.Top, 80 /*0x50*/, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove9);
          }
          DrillMove CurrentMove = new DrillMove(X1_1, X2_1, Y1_1, Y2, Y3_1, Z1, Z2, Z3, DrillMoveCommand.AxisMove, XPos1);
          if (index18 == 0)
          {
            List<DrillMove> calcSimMoves = new List<DrillMove>();
            clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], CurrentMove, 20.0, ref calcSimMoves);
            if (calcSimMoves.Count > 2)
            {
              calcSimMoves.RemoveAt(calcSimMoves.Count - 1);
              for (int index21 = 0; index21 <= calcSimMoves.Count - 1; ++index21)
                Job.SimulationMoves.Add(calcSimMoves[index21]);
            }
          }
          Job.SimulationMoves.Add(CurrentMove);
          XPos2 = camTp2.SimilationPoint.SimMove[index18].X;
        }
      }
    }
    else
    {
      double XPos3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].XPosition;
      double X1_3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
      double X2_3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
      double y1Position = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y1Position;
      double y2Position = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y2Position;
      double Y3_2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y3Position;
      double z1Position = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z1Position;
      double z2Position = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z2Position;
      double z3Position = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z3Position;
      DrillMove drillMove10 = new DrillMove(X1_3, X2_3, y1Position, y2Position, Y3_2, z1Position, z2Position, z3Position, DrillMoveCommand.SetPiston, XPos3, DrillCNCMode.None, drillPlaneNames.Bottom, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
      Job.SimulationMoves.Add(drillMove10);
      double num4 = 0.0;
      double num5 = 0.0;
      for (int index22 = 0; index22 <= camTp2.SimilationPoint.SimMove.Count - 1; ++index22)
      {
        if (camTp2.SimilationPoint.SimMove[index22].Aux1 != 0.0 | camTp2.SimilationPoint.SimMove[index22].Aux2 != 0.0)
        {
          if (camTp2.SimilationPoint.SimMove[index22].Aux1 != 0.0)
            num4 += camTp2.SimilationPoint.SimMove[index22].Aux1;
          if (camTp2.SimilationPoint.SimMove[index22].Aux2 != 0.0)
            num5 += camTp2.SimilationPoint.SimMove[index22].Aux2;
        }
        else
        {
          X1_3 = X1_3 + camTp2.SimilationPoint.SimMove[index22].X - XPos3;
          X2_3 = X2_3 + camTp2.SimilationPoint.SimMove[index22].X - XPos3;
          double XPos4 = camTp2.SimilationPoint.SimMove[index22].X + clsDrill.varDrillCNCSettings.Tool270XZeroOffset;
          double X1_4 = X1_3 + clsDrill.varDrillCNCSettings.Tool270XZeroOffset + num4;
          double X2_4 = X2_3 + clsDrill.varDrillCNCSettings.Tool270XZeroOffset + num5;
          double Y1_2 = Y3_2;
          double parkY2 = clsDrill.varDrillCNCSettings.ParkY2;
          Y3_2 = camTp2.SimilationPoint.SimMove[index22].Y;
          double z = camTp2.SimilationPoint.SimMove[index22].Z;
          if (index22 == camTp2.SimilationPoint.SimMove.Count - 1)
          {
            DrillMove drillMove11 = new DrillMove(X1_4, X2_4, Y1_2, parkY2, Y3_2, z1Position, z2Position, z, DrillMoveCommand.ResetPiston, XPos4, DrillCNCMode.None, drillPlaneNames.Bottom, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Job.SimulationMoves.Add(drillMove11);
          }
          DrillMove CurrentMove = new DrillMove(X1_4, X2_4, Y1_2, parkY2, Y3_2, z1Position, z2Position, z, DrillMoveCommand.AxisMove, XPos4);
          if (index22 == 0)
          {
            List<DrillMove> calcSimMoves = new List<DrillMove>();
            clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], CurrentMove, 20.0, ref calcSimMoves);
            if (calcSimMoves.Count > 2)
            {
              calcSimMoves.RemoveAt(calcSimMoves.Count - 1);
              for (int index23 = 0; index23 <= calcSimMoves.Count - 1; ++index23)
                Job.SimulationMoves.Add(calcSimMoves[index23]);
            }
          }
          Job.SimulationMoves.Add(CurrentMove);
          XPos3 = camTp2.SimilationPoint.SimMove[index22].X;
        }
      }
    }
    if (camTp2.CamPoints.Count > 0 & isTop)
    {
      camTp2.PreCodes.Add((object) "G75");
      camTp2.PreCodes.Add((object) "M154");
      camTp2.PreCodes.Add((object) "G75");
      camTp2.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      camTp2.PreCodes.Add((object) "G75");
      camTp2.PreCodes.Add((object) "M154");
      camTp2.AfterCodes.Add((object) "G53");
      camTp2.AfterCodes.Add((object) "G0 X0");
      camTp2.AfterCodes.Add((object) "G75");
      camTp2.AfterCodes.Add((object) "M154");
      camTp2.AfterCodes.Add((object) "G75");
      camTp2.AfterCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      camTp2.AfterCodes.Add((object) "G75");
      for (int index24 = 0; index24 <= camTp2.CamPoints.Count - 1; ++index24)
      {
        camTp2.CamPoints[index24].PreCodes.Add((object) ("M6 K" + camTp2.CamPoints[index24].ToolCam.Data.No.ToString()));
        camTp2.CamPoints[index24].PreCodes.Add((object) ("M3 K" + camTp2.CamPoints[index24].ToolCam.CamData.SpindleSpeed.ToString()));
        for (int index25 = 0; index25 <= camTp2.CamPoints[index24].Points.Count - 1; ++index25)
        {
          if (!camTp2.CamPoints[index24].Points[index25].PlungeAxisMovement)
          {
            camTp2.CamPoints[index24].Points[index25].AfterCodes.Add((object) "M27");
            index25 = camTp2.CamPoints[index24].Points.Count;
          }
        }
        bool flag8 = false;
        bool flag9 = false;
        if (num1 < clsDrill.varDrillCNCSettings.HorizontalTableTopSurfaceZLimit)
          camTp2.CamPoints[index24].Points[0].AfterCodes.Add((object) "M22");
        for (int index26 = 0; index26 <= camTp2.CamPoints[index24].Points.Count - 1; ++index26)
        {
          if (index26 > 0)
          {
            if (camTp2.CamPoints[index24].Points[index26].PlungeAxisMovement && camTp2.CamPoints[index24].Points[index26].P9.Z < camTp2.CamPoints[index24].Points[index26 - 1].P9.Z & !flag8)
            {
              camTp2.CamPoints[index24].Points[index26].PreCodes.Add((object) "M20");
              flag8 = true;
              flag9 = false;
            }
            if (camTp2.CamPoints[index24].Points[index26].P9.Z > camTp2.CamPoints[index24].Points[index26 - 1].P9.Z & !flag9)
            {
              camTp2.CamPoints[index24].Points[index26].PreCodes.Add((object) "M21");
              flag8 = false;
              flag9 = true;
            }
          }
        }
        if (camTp2.CamPoints[index24].Points.Count > 0)
        {
          Point3D MinPoint1 = new Point3D();
          Point3D MaxPoint = new Point3D();
          clsInit.cVector5.BoxSizeCalculate(camTp2.CamPoints[index24].Points, ref MinPoint1, ref MaxPoint);
          if (MinPoint1.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
            camTp2.CamPoints[index24].Points[camTp2.CamPoints[index24].Points.Count - 1].AfterCodes.Add((object) "M26");
          else if (index24 < camTp2.CamPoints.Count - 1)
          {
            Point3D MinPoint2 = new Point3D();
            MaxPoint = new Point3D();
            clsInit.cVector5.BoxSizeCalculate(camTp2.CamPoints[index24 + 1].Points, ref MinPoint2, ref MaxPoint);
            if (MinPoint2.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
              camTp2.CamPoints[index24].Points[camTp2.CamPoints[index24].Points.Count - 1].AfterCodes.Add((object) "M26");
          }
        }
      }
      Job.Cams.Add(camTp2);
    }
    if (!(camTp2.CamPoints.Count > 0 & !isTop))
      return;
    camTp2.PreCodes.Add((object) "G75");
    camTp2.PreCodes.Add((object) "M154");
    camTp2.PreCodes.Add((object) "G75");
    camTp2.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
    camTp2.PreCodes.Add((object) "G75");
    camTp2.PreCodes.Add((object) "M154");
    camTp2.PreCodes.Add((object) "M6 K41");
    camTp2.PreCodes.Add((object) "M32");
    camTp2.AfterCodes.Add((object) "G53");
    camTp2.AfterCodes.Add((object) "G0 X0");
    camTp2.AfterCodes.Add((object) "G75");
    camTp2.AfterCodes.Add((object) "M154");
    camTp2.AfterCodes.Add((object) "G75");
    camTp2.AfterCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
    camTp2.AfterCodes.Add((object) "G75");
    for (int index27 = 0; index27 <= camTp2.CamPoints.Count - 1; ++index27)
    {
      bool flag10 = false;
      bool flag11 = false;
      for (int index28 = 0; index28 <= camTp2.CamPoints[index27].Points.Count - 1; ++index28)
      {
        if (index28 > 0 && camTp2.CamPoints[index27].Points[index28].PlungeAxisMovement)
        {
          if (camTp2.CamPoints[index27].Points[index28].P9.Z < camTp2.CamPoints[index27].Points[index28 - 1].P9.Z & !flag10)
          {
            camTp2.CamPoints[index27].Points[index28].PreCodes.Add((object) "M50");
            camTp2.CamPoints[index27].Points[index28].PreCodes.Add((object) "M20");
            camTp2.CamPoints[index27].Points[index28].PreCodes.Add((object) "G75");
            flag10 = true;
            flag11 = false;
          }
          if (camTp2.CamPoints[index27].Points[index28].P9.Z > camTp2.CamPoints[index27].Points[index28 - 1].P9.Z & !flag11)
          {
            camTp2.CamPoints[index27].Points[index28].PreCodes.Add((object) "M21");
            flag11 = true;
            flag10 = false;
          }
        }
      }
    }
    Job.Cams.Add(camTp2);
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
          goto label_21;
        }
      }
    }
    if (doubleList1.Count == 1 && Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperLength && doubleList1[0] == 0.0)
    {
      X2Pos = -clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
      X1Pos = -(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
      flag = true;
    }
    else if (doubleList2.Count > 0)
    {
      X2Pos = -Job.Material.Size.Width / 2.0;
      X1Pos = -(Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
      flag = true;
    }
    else
      flag = false;
label_21:
    return flag;
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
    ref double ClamperMinXToToolX,
    ref double ClamperMaxXToToolX,
    double ExtraOffset = 0.0)
  {
    bool flag = false;
    double num1 = XPosition - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
    double num2 = XPosition + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
    List<double> RefList = new List<double>();
    for (int index = 0; index <= activeTools.Count - 1; ++index)
    {
      double num3 = activeTools[index].Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
      if (num1 <= activeTools[index].Positions.CommonOffset.X & activeTools[index].Positions.CommonOffset.X <= num2 && num3 >= num1 & num3 <= num2)
        flag = true;
      RefList.Add(num3);
    }
    clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
    if (RefList.Count > 0)
    {
      ClamperMinXToToolX = RefList[RefList.Count - 1] - num1;
      ClamperMaxXToToolX = num2 - RefList[0];
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
    bool flag = false;
    ClamperMaxXToToolX = 0.0;
    ClamperMinXToToolX = 0.0;
    double num1 = Item.BoxMinItem.X + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
    double num2 = Item.BoxMinItem.X + dX + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
    double num3 = double.MaxValue;
    double num4 = double.MinValue;
    List<double> RefList = new List<double>();
    if (num1 <= ToolMilling.Positions.CommonOffset.X & ToolMilling.Positions.CommonOffset.X <= num2)
    {
      double num5 = ToolMilling.Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
      num3 = num1;
      num4 = num2;
      if (num5 >= num1 & num5 <= num2)
        flag = true;
      RefList.Add(num5);
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
        flag = true;
      RefList.Add(num8);
    }
    clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
    if (RefList.Count > 0)
    {
      ClamperMinXToToolX = RefList[RefList.Count - 1] - num3;
      ClamperMaxXToToolX = num4 - RefList[0];
    }
    return flag;
  }

  public void MoveClampers(double newX1, double newX2, drillPlaneNames Plane, ref DrillJob Job)
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
      this.AddDrillMove(newX1, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, Plane, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper1Down, Plane, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOn, Plane, this.NoMove, ref Job);
    }
    else
    {
      if (newX2 == this.NoMove)
        return;
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Up, Plane, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, newX2, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.AxisMove, Plane, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.Clamper2Down, Plane, this.NoMove, ref Job);
      this.AddDrillMove(this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, this.NoMove, DrillMoveCommand.XAxesGantyOn, Plane, this.NoMove, ref Job);
    }
  }
}
