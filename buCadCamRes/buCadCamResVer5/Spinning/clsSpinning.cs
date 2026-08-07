// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Spinning.clsSpinning
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Spining;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Spinning;

public class clsSpinning
{
  public static SpinPattern varMetalSpinning = new SpinPattern();
  public static SpinPipePattern varMetalPipeSpinning = new SpinPipePattern();
  public SpinPatternRuntime varSpinningRuntime = (SpinPatternRuntime) null;
  public static F_MetalSpinning frmSpin = (F_MetalSpinning) null;
  public static F_MetalPipeSpinning frmSpinPipe = (F_MetalPipeSpinning) null;
  public List<Entity> BaseFinishOffsetedEntities = (List<Entity>) null;
  public List<Entity> BaseRoughtOffsetedEntities = (List<Entity>) null;
  public List<Entity> calcEnt = (List<Entity>) null;
  public List<Entity> calcEntReturn = (List<Entity>) null;
  public List<List<Entity>> tempCalcEntitities = (List<List<Entity>>) null;
  public List<SpinCalculatedData> CalculatedEntitiesList = (List<SpinCalculatedData>) null;
  public Point3D pntStart = new Point3D();
  public Point3D pntLastCalc = new Point3D();
  public double TotalLength = 0.0;

  public void Init()
  {
    this.varSpinningRuntime = new SpinPatternRuntime();
    clsSpinning.frmSpin = new F_MetalSpinning();
    clsSpinning.frmSpin.ShowPath += new ClickSenderDataEventHandler(this.ShowPath);
    clsSpinning.frmSpin.SpinValueChanged += new ApplyCommandWithDataEventHandler(this.ValueChanged);
    clsSpinning.frmSpinPipe = new F_MetalPipeSpinning();
    clsSpinning.frmSpinPipe.ShowPath += new ClickSenderDataEventHandler(this.ShowPipePath);
    clsSpinning.frmSpinPipe.SpinValueChanged += new ApplyCommandWithDataEventHandler(this.ValuePipeChanged);
  }

  public void cmdSpinning()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.drawObjectSpinPattern;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doSpinPattern();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSpinningEdit()
  {
    try
    {
      if (this.CalculatedEntitiesList.Count == 0)
        return;
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      clsInit.appCommand.cmdCamRemoveAll(true);
      if (this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].isMoveSafe)
        this.CalculatedEntitiesList.RemoveAt(this.CalculatedEntitiesList.Count - 1);
      if (this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].isFinished)
      {
        if (this.CalculatedEntitiesList.Count >= 3)
        {
          this.CalculatedEntitiesList.RemoveAt(this.CalculatedEntitiesList.Count - 1);
          this.pntStart = buVector5.ToPoint3D(this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].StartPoint);
          this.CalculatedEntitiesList.RemoveAt(this.CalculatedEntitiesList.Count - 1);
        }
        else
          this.pntStart = buVector5.ToPoint3D(this.CalculatedEntitiesList[0].StartPoint);
      }
      clsSpinning.frmSpin.PropertiesForm.TopMost = true;
      clsSpinning.frmSpin.varSpinPattern = new SpinPattern(clsSpinning.varMetalSpinning);
      clsSpinning.frmSpin.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsSpinning.frmSpin.Init();
      clsSpinning.frmSpin.Show();
      this.ShowPath((object) null, (object) new SpinPatternCommand()
      {
        ShowPattern = true
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSpinningSettings()
  {
    try
    {
      F_MetalSpinningSettings spinningSettings = new F_MetalSpinningSettings();
      spinningSettings.varSpinPattern = new SpinPattern(clsSpinning.varMetalSpinning);
      spinningSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      spinningSettings.Init();
      int num = (int) spinningSettings.ShowDialog();
      if (spinningSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      clsSpinning.varMetalSpinning = new SpinPattern(spinningSettings.varSpinPattern);
      clsSpinning.frmSpin.varSpinPattern = new SpinPattern(spinningSettings.varSpinPattern);
      clsFiles.SaveParameter();
      this.ShowPath((object) null, (object) new SpinPatternCommand()
      {
        ShowPattern = true
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdShowCode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        string Lines = "";
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
        F_Notepad fNotepad = new F_Notepad();
        fNotepad.Init(Lines);
        fNotepad.Show();
        if (clsItem.FrmProgress == null)
          return;
        clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCreateCode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
        saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
          return;
        clsVar.varInterface.pathGCode = buFile.GetPath(saveFileDialog.FileName);
        string Lines = "";
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
        buFile.SaveToFile(Lines, saveFileDialog.FileName);
        clsFiles.SaveParameter();
        if (clsItem.FrmProgress == null)
          return;
        clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmd3DMaterial()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.surfaceRevolveByCurve;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doMaterialSurface();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdPipeSpinning()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      this.doSpinPipePattern();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doSpinPipePattern()
  {
    clsSpinning.frmSpinPipe.PropertiesForm.TopMost = true;
    clsSpinning.frmSpinPipe.varSpinPattern = new SpinPipePattern(clsSpinning.varMetalPipeSpinning);
    clsSpinning.frmSpinPipe.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsSpinning.frmSpinPipe.Init();
    clsSpinning.frmSpinPipe.Show();
    this.ShowPipePath((object) null, (object) new SpinPatternCommand()
    {
      ShowPattern = true
    });
  }

  public void doSpinPattern()
  {
    SortSettings Settings = new SortSettings();
    SortResult Result = new SortResult();
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> SortedEntities = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    Point3D point3D1 = new Point3D();
    Point3D point3D2 = new Point3D();
    this.CalculatedEntitiesList = new List<SpinCalculatedData>();
    this.varSpinningRuntime.isFinish = false;
    clsInit.appCommand.SelectionToEntities(ref entityList1, new SelectionOption()
    {
      SplitArcIfGreatThen180 = true,
      CircleToArc = true
    });
    for (int index = 0; index <= entityList1.Count - 1; ++index)
    {
      if (entityList1[index] is Curve)
      {
        Entity LinearPathEntity = (Entity) null;
        clsInit.cVector5.EntitiesToLinearPath(entityList1[index], 0.001, ref LinearPathEntity);
        entityList1[index] = LinearPathEntity;
      }
    }
    Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
    if (ccVars.SelectionOP.ClickList.Count > 0)
    {
      Settings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
      clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref entityList1, Settings, ref SortedEntities, ref Result);
    }
    else
      clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.Selections[0].pntClick, ref entityList1, Settings, ref SortedEntities, ref Result);
    buVector5.CopyEntities(SortedEntities, ref entityList2);
    if (clsSpinning.varMetalSpinning.CurveOffset != 0.0)
    {
      CompositeCurve Curve1 = (CompositeCurve) null;
      clsInit.appCommand.EntitiesToCompositeCurve(SortedEntities, 0.001, ref Curve1);
      CompositeCurve Curve2 = Curve1.Offset(clsSpinning.varMetalSpinning.CurveOffset, Vector3D.AxisZ, false)[0] as CompositeCurve;
      Curve2.Regen(0.1);
      if (Curve2.BoxMin.Y < Curve1.BoxMin.Y)
      {
        Curve2 = Curve1.Offset(-clsSpinning.varMetalSpinning.CurveOffset, Vector3D.AxisZ, false)[0] as CompositeCurve;
        Curve2.Regen(0.1);
      }
      if (Curve2 != null)
      {
        List<Entity> entityList3 = new List<Entity>();
        clsInit.appCommand.CompositeCurveToEntities(Curve2, 0.001, ref entityList3);
        SortedEntities.Clear();
        SortedEntities = new List<Entity>();
        if (ccVars.SelectionOP.ClickList.Count > 0)
        {
          Settings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
          clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref entityList3, Settings, ref SortedEntities, ref Result);
        }
        else
          clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.Selections[0].pntClick, ref entityList3, Settings, ref SortedEntities, ref Result);
      }
    }
    if (clsSpinning.varMetalSpinning.CurveFinishOffset != 0.0)
    {
      CompositeCurve Curve3 = (CompositeCurve) null;
      clsInit.appCommand.EntitiesToCompositeCurve(entityList2, 0.001, ref Curve3);
      CompositeCurve Curve4 = (CompositeCurve) Curve3.Offset(clsSpinning.varMetalSpinning.CurveFinishOffset, Vector3D.AxisZ, false)[0];
      Curve4.Regen(0.1);
      if (Curve4.BoxMin.Y < Curve3.BoxMin.Y)
      {
        Curve4 = (CompositeCurve) Curve3.Offset(-clsSpinning.varMetalSpinning.CurveFinishOffset, Vector3D.AxisZ, false)[0];
        Curve4.Regen(0.1);
      }
      if (Curve4 != null)
      {
        List<Entity> entityList4 = new List<Entity>();
        clsInit.appCommand.CompositeCurveToEntities(Curve4, 0.001, ref entityList4);
        entityList2.Clear();
        entityList2 = new List<Entity>();
        if (ccVars.SelectionOP.ClickList.Count > 0)
        {
          Settings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
          clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref entityList4, Settings, ref entityList2, ref Result);
        }
        else
          clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.Selections[0].pntClick, ref entityList4, Settings, ref entityList2, ref Result);
      }
    }
    else
      buVector5.CopyEntities(SortedEntities, ref entityList2);
    if (clsSpinning.varMetalSpinning.CurveStartExtend > 0.001)
    {
      Point3D point3D3;
      Point3D point3D4;
      if (((CustomData) SortedEntities[0].EntityData).sortDirection == entitySortDirection.Normal)
      {
        point3D3 = buVector5.ToPoint3D(SortedEntities[0].Vertices[0]);
        point3D4 = buVector5.ToPoint3D(SortedEntities[0].Vertices[1]);
      }
      else
      {
        point3D3 = buVector5.ToPoint3D(SortedEntities[0].Vertices[SortedEntities[0].Vertices.Length - 1]);
        point3D4 = buVector5.ToPoint3D(SortedEntities[0].Vertices[SortedEntities[0].Vertices.Length - 2]);
      }
      double Angle = clsInit.cVector5.PointAngle(point3D3, point3D4, Plane.XY);
      Point3D EndPnt = new Point3D();
      clsInit.cVector5.LineWithLengthAndAngle(point3D3, clsSpinning.varMetalSpinning.CurveStartExtend, Angle, ref EndPnt);
      SortedEntities.Insert(0, (Entity) new Line(EndPnt, point3D3));
    }
    if (clsSpinning.varMetalSpinning.CurveEndExtend > 0.001)
    {
      Point3D point3D5;
      Point3D point3D6;
      if (((CustomData) SortedEntities[SortedEntities.Count - 1].EntityData).sortDirection == entitySortDirection.Normal)
      {
        point3D5 = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[SortedEntities[SortedEntities.Count - 1].Vertices.Length - 2]);
        point3D6 = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[SortedEntities[SortedEntities.Count - 1].Vertices.Length - 1]);
      }
      else
      {
        point3D5 = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[1]);
        point3D6 = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[0]);
      }
      double Angle = clsInit.cVector5.PointAngle(point3D6, point3D5, Plane.XY);
      Point3D EndPnt = new Point3D();
      clsInit.cVector5.LineWithLengthAndAngle(point3D6, clsSpinning.varMetalSpinning.CurveEndExtend, Angle, ref EndPnt);
      SortedEntities.Add((Entity) new Line(point3D6, EndPnt));
    }
    this.TotalLength = 0.0;
    if (SortedEntities.Count > 0)
    {
      this.varSpinningRuntime.pntLeaveArcEnd = new Point3D();
      this.varSpinningRuntime.pntLeaveArcMid = new Point3D();
      this.pntStart = ((CustomData) SortedEntities[0].EntityData).sortDirection != entitySortDirection.Normal ? buVector5.ToPoint3D(SortedEntities[0].Vertices[SortedEntities[0].Vertices.Length - 1]) : buVector5.ToPoint3D(SortedEntities[0].Vertices[0]);
      this.varSpinningRuntime.pntCurveEnd = ((CustomData) SortedEntities[SortedEntities.Count - 1].EntityData).sortDirection != entitySortDirection.Normal ? buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[0]) : buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[SortedEntities[SortedEntities.Count - 1].Vertices.Length - 1]);
      this.varSpinningRuntime.pntCurveStart = buVector5.ToPoint3D(this.pntStart);
    }
    if (entityList2.Count > 0)
    {
      this.varSpinningRuntime.pntLeaveArcEnd = new Point3D();
      this.varSpinningRuntime.pntLeaveArcMid = new Point3D();
      this.varSpinningRuntime.pntCurveFinishStart = ((CustomData) entityList2[0].EntityData).sortDirection != entitySortDirection.Normal ? buVector5.ToPoint3D(entityList2[0].Vertices[entityList2[0].Vertices.Length - 1]) : buVector5.ToPoint3D(entityList2[0].Vertices[0]);
      this.varSpinningRuntime.pntCurveFinishEnd = ((CustomData) entityList2[entityList2.Count - 1].EntityData).sortDirection != entitySortDirection.Normal ? buVector5.ToPoint3D(entityList2[entityList2.Count - 1].Vertices[0]) : buVector5.ToPoint3D(entityList2[entityList2.Count - 1].Vertices[entityList2[SortedEntities.Count - 1].Vertices.Length - 1]);
    }
    if (SortedEntities.Count <= 0)
      return;
    this.BaseFinishOffsetedEntities = new List<Entity>();
    this.BaseRoughtOffsetedEntities = new List<Entity>();
    if (entityList2.Count > 0)
      buVector5.CopyEntities(entityList2, ref this.BaseFinishOffsetedEntities);
    else
      buVector5.CopyEntities(SortedEntities, ref this.BaseFinishOffsetedEntities);
    buVector5.CopyEntities(SortedEntities, ref this.BaseRoughtOffsetedEntities);
    for (int index = 0; index <= this.BaseRoughtOffsetedEntities.Count - 1; ++index)
      this.BaseRoughtOffsetedEntities[index].Regen(clsVar.varEntities.RegenDeviation);
    for (int index = 0; index <= this.BaseFinishOffsetedEntities.Count - 1; ++index)
      this.BaseFinishOffsetedEntities[index].Regen(clsVar.varEntities.RegenDeviation);
    clsSpinning.frmSpin.PropertiesForm.TopMost = true;
    clsSpinning.frmSpin.varSpinPattern = new SpinPattern(clsSpinning.varMetalSpinning);
    clsSpinning.frmSpin.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsSpinning.frmSpin.Init();
    clsSpinning.frmSpin.Show();
    this.ShowPath((object) null, (object) new SpinPatternCommand()
    {
      ShowPattern = true
    });
  }

  public void doMaterialSurface()
  {
    Entity surfEntity = (Entity) null;
    clsInit.appCommand.surfaceRevolveByPath(ref surfEntity);
    surfEntity.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].LayerPurposes == LayerPurpose.Model)
        surfEntity.LayerName = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
    }
    clsInit.appCommand.AddEntity(surfEntity);
  }

  public void getEntitiesBetweenStartPointAndLength(
    Point3D pntStart,
    SpinPattern varPattern,
    List<Entity> baseEntities,
    bool CalcReturn,
    ref List<Entity> calcEntities,
    ref Point3D pntNewStart,
    ref Point3D pntReturn,
    ref double DirectionAngle)
  {
    pntNewStart = buVector5.ToPoint3D(pntStart);
    this.TotalLength = 0.0;
    bool flag = false;
    for (int index = 0; index <= baseEntities.Count - 1; ++index)
    {
      ICurve baseEntity = (ICurve) baseEntities[index];
      double t1;
      baseEntity.ClosestPointTo(pntNewStart, out t1);
      if (clsInit.cVector5.isPointInsideEntity(baseEntity, pntNewStart, 0.01) & t1 >= baseEntity.Domain.t0 & t1 <= baseEntity.Domain.t1)
      {
        flag = true;
        double num1 = (baseEntity.Domain.t1 - baseEntity.Domain.t0) / baseEntity.Length();
        double num2 = varPattern.StepCatchLength - this.TotalLength;
        Point3D point3D1 = new Point3D();
        ICurve sub = (ICurve) null;
        if (((CustomData) baseEntities[index].EntityData).sortDirection == entitySortDirection.Normal)
        {
          double num3 = t1 + num2 * num1;
          double t2 = t1 + (num2 - varPattern.StepReturnLength) * num1;
          if (num3 > baseEntity.Domain.t1)
            num3 = baseEntity.Domain.t1;
          if (t2 > baseEntity.Domain.t1)
            t2 = baseEntity.Domain.t1;
          if (t2 < baseEntity.Domain.t0)
            t2 = baseEntity.Domain.t0;
          if (num3 - t1 > 0.001)
          {
            Point3D point3D2 = new Point3D();
            baseEntity.SubCurve(t1, num3, out sub);
            double num4 = sub.Length();
            Point3D point3D3 = buVector5.ToPoint3D(baseEntity.PointAt(num3));
            Point3D point3D4 = buVector5.ToPoint3D(baseEntity.PointAt(num3 - 0.1));
            DirectionAngle = clsInit.cVector5.PointAngle(point3D3, point3D4, Plane.XY);
            Entity entity = (Entity) sub;
            entity.Regen(0.001);
            calcEntities.Add(entity);
            pntNewStart = buVector5.ToPoint3D(point3D3);
            pntReturn = buVector5.ToPoint3D(baseEntity.PointAt(t2));
            if (buCompare5.EQ(pntNewStart, pntReturn))
              pntReturn = buVector5.ToPoint3D(pntNewStart);
            double num5 = (num3 - t1) / num1;
            if (!(buCompare5.EQ(num5 + this.TotalLength, varPattern.StepCatchLength, 0.01) | num5 + this.TotalLength > varPattern.StepCatchLength))
            {
              this.TotalLength += num4;
            }
            else
            {
              if (CalcReturn)
                break;
              SpinPattern varPattern1 = new SpinPattern(varPattern);
              varPattern1.StepCatchLength = varPattern.StepCatchLength - varPattern.StepReturnLength;
              List<Entity> calcEntities1 = new List<Entity>();
              Point3D pntNewStart1 = new Point3D();
              Point3D pntReturn1 = new Point3D();
              double DirectionAngle1 = 0.0;
              this.getEntitiesBetweenStartPointAndLength(pntStart, varPattern1, baseEntities, true, ref calcEntities1, ref pntNewStart1, ref pntReturn1, ref DirectionAngle1);
              pntReturn = buVector5.ToPoint3D(pntNewStart1);
              break;
            }
          }
        }
        else
        {
          double num6 = t1 - num2 * num1;
          double t3 = t1 - (num2 - varPattern.StepReturnLength) * num1;
          if (num6 < baseEntity.Domain.t0)
            num6 = baseEntity.Domain.t0;
          if (t3 < baseEntity.Domain.t0)
            t3 = baseEntity.Domain.t0;
          if (t3 > baseEntity.Domain.t1)
            t3 = baseEntity.Domain.t1;
          if (t1 - num6 > 0.001)
          {
            Point3D point3D5 = new Point3D();
            baseEntity.SubCurve(num6, t1, out sub);
            double num7 = sub.Length();
            Point3D point3D6 = buVector5.ToPoint3D(baseEntity.PointAt(num6));
            Point3D point3D7 = buVector5.ToPoint3D(baseEntity.PointAt(num6 + 0.1));
            DirectionAngle = clsInit.cVector5.PointAngle(point3D6, point3D7, Plane.XY);
            Entity entity = (Entity) sub;
            entity.Regen(new RegenParams(0.0001));
            calcEntities.Add(entity);
            pntNewStart = buVector5.ToPoint3D(point3D6);
            pntReturn = buVector5.ToPoint3D(baseEntity.PointAt(t3));
            if (buCompare5.EQ(pntNewStart, pntReturn))
              pntReturn = buVector5.ToPoint3D(pntNewStart);
            double num8 = (t1 - num6) / num1;
            if (!(buCompare5.EQ(num8 + this.TotalLength, varPattern.StepCatchLength, 0.01) | num8 + this.TotalLength > varPattern.StepCatchLength))
            {
              this.TotalLength += num7;
            }
            else
            {
              if (CalcReturn)
                break;
              SpinPattern varPattern2 = new SpinPattern(varPattern);
              varPattern2.StepCatchLength = varPattern.StepCatchLength - varPattern.StepReturnLength;
              List<Entity> calcEntities2 = new List<Entity>();
              Point3D pntNewStart2 = new Point3D();
              Point3D pntReturn2 = new Point3D();
              double DirectionAngle2 = 0.0;
              this.getEntitiesBetweenStartPointAndLength(pntStart, varPattern2, baseEntities, true, ref calcEntities2, ref pntNewStart2, ref pntReturn2, ref DirectionAngle2);
              pntReturn = buVector5.ToPoint3D(pntNewStart2);
              break;
            }
          }
        }
      }
      else if (flag)
        this.TotalLength += baseEntity.Length();
    }
  }

  public void getEntitiesBetweenStartPointAndEndPoint(
    Point3D pntStart,
    Point3D pntEnd,
    SpinPattern varPattern,
    List<Entity> baseEntities,
    ref List<Entity> calcEntities)
  {
    Point3D point3D = buVector5.ToPoint3D(pntStart);
    this.TotalLength = 0.0;
    bool flag = false;
    for (int index = 0; index <= baseEntities.Count - 1; ++index)
    {
      ICurve baseEntity = (ICurve) baseEntities[index];
      baseEntity.ClosestPointTo(point3D, out double _);
      if (!(clsInit.cVector5.isPointInsideEntity(baseEntity, pntStart, 0.01) & clsInit.cVector5.isPointInsideEntity(baseEntity, pntEnd, 0.01)))
      {
        if (flag)
        {
          Entity copiedEnt = (Entity) null;
          buVector5.CopyEntities(baseEntities[index], ref copiedEnt);
          calcEntities.Add(copiedEnt);
        }
      }
      else
      {
        if (((CustomData) baseEntities[index].EntityData).sortDirection == entitySortDirection.Normal)
        {
          ICurve sub = (ICurve) null;
          baseEntity.SubCurve(pntStart, pntEnd, out sub);
          Entity entity = (Entity) sub;
          entity.Regen(new RegenParams(0.0001));
          calcEntities.Add(entity);
          break;
        }
        ICurve sub1 = (ICurve) null;
        baseEntity.SubCurve(pntEnd, pntStart, out sub1);
        Entity entity1 = (Entity) sub1;
        entity1.EntityData = (object) new CustomData();
        entity1.Regen(new RegenParams(0.0001));
        calcEntities.Add(entity1);
        break;
      }
    }
  }

  public void CreateLeave(
    Entity LastEntity,
    Point3D pntStart,
    Point3D pntEnd,
    SpinPattern varPattern,
    ref List<Entity> calcEnt)
  {
    try
    {
      calcEnt.Clear();
      double num1 = pntEnd.X - this.varSpinningRuntime.pntLeaveArcEnd.X + varPattern.LeaveOffsetX;
      double num2 = pntEnd.X - this.varSpinningRuntime.pntLeaveArcMid.X + varPattern.LeaveOffsetX;
      double num3 = 0.0;
      double num4 = 0.0;
      if (!this.varSpinningRuntime.isLastSpin)
      {
        if (!clsSpinning.varMetalSpinning.ReturnSameWay)
        {
          if (varPattern.isLeaveArc)
          {
            Point3D third = new Point3D(this.varSpinningRuntime.pntLeaveArcEnd.X + num3 / 2.0, this.varSpinningRuntime.pntLeaveArcEnd.Y, this.varSpinningRuntime.pntLeaveArcEnd.Z);
            Point3D second = new Point3D(this.varSpinningRuntime.pntLeaveArcMid.X + num4 / 2.0, this.varSpinningRuntime.pntLeaveArcMid.Y, this.varSpinningRuntime.pntLeaveArcMid.Z);
            Arc arc = new Arc(Plane.XY, (Point2D) pntStart, (Point2D) second, (Point2D) third, true);
            arc.Regen(new RegenParams(0.001));
            arc.EntityData = (object) new CustomData()
            {
              CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
            };
            calcEnt.Add((Entity) arc);
          }
          else
          {
            Line line = new Line(pntStart, this.varSpinningRuntime.pntLeaveArcEnd);
            line.Regen(new RegenParams(0.001));
            line.EntityData = (object) new CustomData()
            {
              CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
            };
            calcEnt.Add((Entity) line);
          }
          Point3D point3D = new Point3D(pntEnd.X, this.varSpinningRuntime.pntLeaveArcEnd.Y, 0.0);
          Line line1 = new Line(this.varSpinningRuntime.pntLeaveArcEnd, point3D);
          line1.Regen(new RegenParams(0.001));
          line1.EntityData = (object) new CustomData()
          {
            CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
          };
          calcEnt.Add((Entity) line1);
          if (varPattern.isArcCorner)
          {
            ICurve curve1 = (ICurve) calcEnt[0].Clone();
            ICurve curve2 = (ICurve) calcEnt[1].Clone();
            CustomData customData1 = new CustomData((CustomData) calcEnt[0].EntityData);
            CustomData customData2 = new CustomData((CustomData) calcEnt[1].EntityData);
            Arc fillet = (Arc) null;
            if (Curve.Fillet(curve1, curve2, varPattern.LeaveArcCornerRadius, false, false, true, true, out fillet))
            {
              calcEnt[0] = buVector5.CopyEntities((Entity) curve1);
              calcEnt[1] = buVector5.CopyEntities((Entity) curve2);
              calcEnt[0].EntityData = (object) customData1;
              calcEnt[1].EntityData = (object) customData2;
              fillet.Regen(0.001);
              if (fillet != null)
              {
                fillet.EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
                };
                calcEnt.Insert(1, (Entity) fillet);
              }
            }
            if (Curve.Fillet(curve1, curve2, varPattern.LeaveArcCornerRadius, true, false, true, true, out fillet))
            {
              calcEnt[0] = buVector5.CopyEntities((Entity) curve1);
              calcEnt[1] = buVector5.CopyEntities((Entity) curve2);
              calcEnt[0].EntityData = (object) customData1;
              calcEnt[1].EntityData = (object) customData2;
              fillet.Regen(0.001);
              if (fillet != null)
              {
                fillet.EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
                };
                calcEnt.Insert(1, (Entity) fillet);
              }
            }
            if (Curve.Fillet(curve1, curve2, varPattern.LeaveArcCornerRadius, false, true, true, true, out fillet))
            {
              calcEnt[0] = buVector5.CopyEntities((Entity) curve1);
              calcEnt[1] = buVector5.CopyEntities((Entity) curve2);
              calcEnt[0].EntityData = (object) customData1;
              calcEnt[1].EntityData = (object) customData2;
              fillet.Regen(0.001);
              if (fillet != null)
              {
                fillet.EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
                };
                calcEnt.Insert(1, (Entity) fillet);
              }
            }
            if (Curve.Fillet(curve1, curve2, varPattern.LeaveArcCornerRadius, true, true, true, true, out fillet))
            {
              calcEnt[0] = buVector5.CopyEntities((Entity) curve1);
              calcEnt[1] = buVector5.CopyEntities((Entity) curve2);
              calcEnt[0].EntityData = (object) customData1;
              calcEnt[1].EntityData = (object) customData2;
              fillet.Regen(0.001);
              if (fillet != null)
              {
                fillet.EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
                };
                calcEnt.Insert(1, (Entity) fillet);
              }
            }
          }
          Line line2 = new Line(point3D, new Point3D(pntEnd.X, pntEnd.Y + clsSpinning.varMetalSpinning.SafeDistance));
          line2.Regen(new RegenParams(0.001));
          line2.EntityData = (object) new CustomData()
          {
            CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
          };
          calcEnt.Add((Entity) line2);
          if (varPattern.isArcCorner)
          {
            ICurve curve3 = (ICurve) calcEnt[calcEnt.Count - 2].Clone();
            ICurve curve4 = (ICurve) calcEnt[calcEnt.Count - 1].Clone();
            CustomData customData3 = new CustomData((CustomData) calcEnt[calcEnt.Count - 2].EntityData);
            CustomData customData4 = new CustomData((CustomData) calcEnt[calcEnt.Count - 1].EntityData);
            Arc fillet = (Arc) null;
            if (Curve.Fillet(curve3, curve4, 5.0, false, false, true, true, out fillet))
            {
              calcEnt[calcEnt.Count - 2] = buVector5.CopyEntities((Entity) curve3);
              calcEnt[calcEnt.Count - 1] = buVector5.CopyEntities((Entity) curve4);
              calcEnt[calcEnt.Count - 2].EntityData = (object) customData3;
              calcEnt[calcEnt.Count - 1].EntityData = (object) customData4;
              fillet.Regen(0.001);
              if (fillet != null)
              {
                fillet.EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
                };
                calcEnt.Insert(calcEnt.Count - 1, (Entity) fillet);
              }
            }
            if (Curve.Fillet(curve3, curve4, 5.0, true, false, true, true, out fillet))
            {
              calcEnt[calcEnt.Count - 2] = buVector5.CopyEntities((Entity) curve3);
              calcEnt[calcEnt.Count - 1] = buVector5.CopyEntities((Entity) curve4);
              fillet.Regen(0.001);
              calcEnt[calcEnt.Count - 2].EntityData = (object) customData3;
              calcEnt[calcEnt.Count - 1].EntityData = (object) customData4;
              if (fillet != null)
              {
                fillet.EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
                };
                calcEnt.Insert(calcEnt.Count - 1, (Entity) fillet);
              }
            }
            if (Curve.Fillet(curve3, curve4, 5.0, false, true, true, true, out fillet))
            {
              calcEnt[calcEnt.Count - 2] = buVector5.CopyEntities((Entity) curve3);
              calcEnt[calcEnt.Count - 1] = buVector5.CopyEntities((Entity) curve4);
              calcEnt[calcEnt.Count - 2].EntityData = (object) customData3;
              calcEnt[calcEnt.Count - 1].EntityData = (object) customData4;
              fillet.Regen(0.001);
              if (fillet != null)
              {
                fillet.EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
                };
                calcEnt.Insert(calcEnt.Count - 1, (Entity) fillet);
              }
            }
            if (Curve.Fillet(curve3, curve4, 5.0, true, true, true, true, out fillet))
            {
              calcEnt[calcEnt.Count - 2] = buVector5.CopyEntities((Entity) curve3);
              calcEnt[calcEnt.Count - 1] = buVector5.CopyEntities((Entity) curve4);
              fillet.Regen(0.001);
              calcEnt[calcEnt.Count - 2].EntityData = (object) customData3;
              calcEnt[calcEnt.Count - 1].EntityData = (object) customData4;
              if (fillet != null)
              {
                fillet.EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
                };
                calcEnt.Insert(calcEnt.Count - 1, (Entity) fillet);
              }
            }
          }
          Line line3 = new Line(new Point3D(pntEnd.X, pntEnd.Y + clsSpinning.varMetalSpinning.SafeDistance), pntEnd);
          line3.Regen(new RegenParams(0.001));
          line3.EntityData = (object) new CustomData()
          {
            CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
          };
          calcEnt.Add((Entity) line3);
          this.varSpinningRuntime.pntLastCalc = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
        }
        else if (varPattern.isLeaveArc)
        {
          Point3D third = new Point3D(this.varSpinningRuntime.pntLeaveArcEnd.X + num3 / 2.0, this.varSpinningRuntime.pntLeaveArcEnd.Y, this.varSpinningRuntime.pntLeaveArcEnd.Z);
          Point3D second = new Point3D(this.varSpinningRuntime.pntLeaveArcMid.X + num4 / 2.0, this.varSpinningRuntime.pntLeaveArcMid.Y, this.varSpinningRuntime.pntLeaveArcMid.Z);
          Arc arc1 = new Arc(Plane.XY, (Point2D) pntStart, (Point2D) second, (Point2D) third, true);
          arc1.Regen(new RegenParams(0.001));
          arc1.EntityData = (object) new CustomData()
          {
            CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
          };
          calcEnt.Add((Entity) arc1);
          double num5 = clsSpinning.varMetalSpinning.ReturnSameWayOffset / 2.0;
          if (!clsSpinning.varMetalSpinning.ReturnSameWayExtraMoveForArc)
            num5 = 0.0;
          Arc arc2 = new Arc(Plane.XY, (Point2D) this.varSpinningRuntime.pntSameWayReturn, (Point2D) new Point3D(this.varSpinningRuntime.pntLeaveArcMid.X + num4 / 2.0 - num5, this.varSpinningRuntime.pntLeaveArcMid.Y, this.varSpinningRuntime.pntLeaveArcMid.Z), (Point2D) third, true);
          arc2.Regen(new RegenParams(0.001));
          arc2.EntityData = (object) new CustomData()
          {
            CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
          };
          calcEnt.Add((Entity) arc2);
          for (int index = 0; index <= this.calcEntReturn.Count - 1; ++index)
          {
            Entity entity = buVector5.CopyEntities(this.calcEntReturn[index]);
            entity.EntityData = (object) new CustomData()
            {
              CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
            };
            calcEnt.Add(entity);
          }
          this.varSpinningRuntime.pntLastCalc = new Point3D(this.varSpinningRuntime.pntSameWayReturn.X, this.varSpinningRuntime.pntSameWayReturn.Y, this.varSpinningRuntime.pntSameWayReturn.Z);
        }
        else
        {
          Line line4 = new Line(this.varSpinningRuntime.pntLeaveArcEnd, pntStart);
          line4.Regen(new RegenParams(0.001));
          line4.EntityData = (object) new CustomData()
          {
            CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
          };
          calcEnt.Add((Entity) line4);
          Line line5 = new Line(this.varSpinningRuntime.pntSameWayReturn, this.varSpinningRuntime.pntLeaveArcEnd);
          line5.Regen(new RegenParams(0.001));
          line5.EntityData = (object) new CustomData()
          {
            CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
          };
          calcEnt.Add((Entity) line5);
          for (int index = 0; index <= this.calcEntReturn.Count - 1; ++index)
          {
            Entity entity = buVector5.CopyEntities(this.calcEntReturn[index]);
            entity.EntityData = (object) new CustomData()
            {
              CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
            };
            calcEnt.Add(entity);
          }
          this.varSpinningRuntime.pntLastCalc = new Point3D(this.varSpinningRuntime.pntSameWayReturn.X, this.varSpinningRuntime.pntSameWayReturn.Y, this.varSpinningRuntime.pntSameWayReturn.Z);
        }
      }
      else
      {
        Line line = new Line(pntEnd, new Point3D(pntEnd.X, pntEnd.Y + varPattern.LeaveHeight));
        calcEnt.Add((Entity) line);
        this.varSpinningRuntime.pntLastCalc = new Point3D(pntEnd.X, pntEnd.Y + varPattern.LeaveHeight);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void CalculateLeaveAngle(
    Point3D lastPoint,
    SpinPattern varPattern,
    List<Entity> baseEntities,
    ref Point3D midPoint,
    ref Point3D endPoint)
  {
    double num1 = this.varSpinningRuntime.DirectionAngle - (this.varSpinningRuntime.DirectionAngle - 90.0) * varPattern.LeaveDeltaAngleRatio + varPattern.LeaveOffsetAngle;
    if (num1 > varPattern.LeaveMaxAngle)
      num1 = varPattern.LeaveMaxAngle;
    if (num1 < varPattern.LeaveMinAngle)
      num1 = varPattern.LeaveMinAngle;
    double num2 = Math.Tan(buConversion5.DegreeToRadian(num1 - 90.0)) * varPattern.LeaveHeight;
    double num3 = Math.Tan(buConversion5.DegreeToRadian(num1 - 90.0)) * (varPattern.LeaveHeight / 2.0);
    double y1 = lastPoint.Y + varPattern.LeaveHeight;
    double y2 = lastPoint.Y + varPattern.LeaveHeight / 2.0;
    bool flag = false;
    midPoint = new Point3D();
    endPoint = new Point3D();
    for (int index = 0; index <= baseEntities.Count - 1; ++index)
    {
      ICurve baseEntity = (ICurve) baseEntities[index];
      if (baseEntities[index].BoxMax == (Point3D) null)
        baseEntities[index].Regen(0.0001);
      if (y2 >= baseEntities[index].BoxMin.Y & y2 <= baseEntities[index].BoxMax.Y)
      {
        Line C2 = new Line(new Point3D(-100000.0, y2), new Point3D(100000.0, y2));
        Point3D[] point3DArray = baseEntity.IntersectWith((ICurve) C2);
        if (point3DArray != null && point3DArray.Length != 0)
        {
          midPoint = buVector5.ToPoint3D(point3DArray[0]);
          flag = true;
        }
      }
    }
    endPoint = new Point3D(lastPoint.X - num2 + varPattern.LeaveOffsetX, y1);
    midPoint = new Point3D(lastPoint.X - varPattern.LeaveArcRadiusRatioFromHeight * varPattern.LeaveHeight - num3 + varPattern.LeaveOffsetX * 0.5, y2);
    if (flag)
      ;
    this.varSpinningRuntime.isLastSpin = false;
    if (!this.varSpinningRuntime.isFinish)
    {
      if (!(lastPoint == this.varSpinningRuntime.pntCurveEnd))
        return;
      this.varSpinningRuntime.isLastSpin = true;
    }
    else
    {
      if (!(lastPoint == this.varSpinningRuntime.pntCurveFinishEnd))
        return;
      this.varSpinningRuntime.isLastSpin = true;
    }
  }

  public void ShowPath(object sender, object Data)
  {
    try
    {
      SpinPatternCommand spinPatternCommand = (SpinPatternCommand) Data;
      Point3D pntNewStart = new Point3D();
      Point3D pntReturn = new Point3D();
      List<Entity> calcEnt = new List<Entity>();
      if (spinPatternCommand.OK & this.CalculatedEntitiesList != null)
      {
        if (this.CalculatedEntitiesList.Count == 0)
          return;
        clsInit.appCommand.undoBuffer();
        clsInit.appCommand.cmdCamRemoveAll(true);
        if (!this.varSpinningRuntime.isFinish)
        {
          Line line = new Line(this.pntLastCalc, new Point3D(this.pntLastCalc.X, this.pntLastCalc.Y + clsSpinning.varMetalSpinning.LeaveHeight, this.pntLastCalc.Z));
          line.EntityData = (object) new CustomData()
          {
            CamFeedrate = clsSpinning.varMetalSpinning.CamLeaveFeed
          };
          this.CalculatedEntitiesList.Add(new SpinCalculatedData()
          {
            StartPoint = buVector5.ToPoint3D(this.pntLastCalc),
            isFinished = this.varSpinningRuntime.isFinish,
            CalculatedEntities = {
              (Entity) line
            },
            isMoveSafe = true
          });
        }
        ccVars.Pages[ccVars.PageIndex].Cams.Clear();
        List<Entity> BaseRefEntities = new List<Entity>();
        this.tempCalcEntitities.Clear();
        for (int index1 = 0; index1 <= this.CalculatedEntitiesList.Count - 1; ++index1)
        {
          List<Entity> copiedEnt = new List<Entity>();
          buVector5.CopyEntities(this.CalculatedEntitiesList[index1].CalculatedEntities, ref copiedEnt);
          for (int index2 = 0; index2 <= copiedEnt.Count - 1; ++index2)
          {
            copiedEnt[index2].Translate(0.0, this.CalculatedEntitiesList[index1].YOffset);
            copiedEnt[index2].Regen(new RegenParams(clsVar.varEntities.RegenDeviation));
          }
          this.tempCalcEntitities.Add(copiedEnt);
        }
        for (int index3 = 0; index3 <= this.tempCalcEntitities.Count - 1; ++index3)
        {
          for (int index4 = 0; index4 <= this.tempCalcEntitities[index3].Count - 1; ++index4)
          {
            Entity copiedEnt = (Entity) null;
            buVector5.CopyEntities(this.tempCalcEntitities[index3][index4], ref copiedEnt);
            BaseRefEntities.Add(copiedEnt);
          }
        }
        if (!this.varSpinningRuntime.isFinish)
          ;
        camTp CamCalculated = new camTp();
        SortSettings Settings = new SortSettings();
        Settings.Option.IntersectionRules = SortingIntersectionRulesType.FromDrawing;
        Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.DrawingSequence;
        List<Entity> SortedEntities = new List<Entity>();
        SortResult Result = new SortResult();
        clsInit.cVector5.SortEntitiesByRefPoint(this.varSpinningRuntime.pntCurveStart, ref BaseRefEntities, Settings, ref SortedEntities, ref Result);
        clsInit.cCam5.camContourCenter(SortedEntities, false, ccVars.toolActive, new camParameters5()
        {
          Distances = {
            Safe = 0.0,
            Rapid = 0.0
          },
          Options = {
            FeedFromEntityFeedrate = true
          }
        }, ref CamCalculated);
        clsInit.appCommand.CamAvailableIDGet(ref CamCalculated.CamID);
        ccVars.UndoDont = true;
        clsInit.appCommand.CamAdd(CamCalculated);
        clsSpinning.frmSpin.Visible = false;
        clsInit.appCommand.Reset();
        ccVars.UndoDont = false;
        clsFiles.SaveParameter();
      }
      else if (spinPatternCommand.Cancel)
        clsInit.appCommand.Reset();
      else if (spinPatternCommand.Finish & this.CalculatedEntitiesList != null)
      {
        this.varSpinningRuntime.isFinish = true;
        if (this.CalculatedEntitiesList.Count > 0)
        {
          if (!this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].ReturnSameWay)
          {
            this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.RemoveAt(this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1);
            this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.RemoveAt(this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1);
            if (this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities[this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1] is Arc)
              this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.RemoveAt(this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1);
          }
          Point3D point3D = new Point3D();
          Entity calculatedEntity = this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities[this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1];
          Point3D start = ((CustomData) calculatedEntity.EntityData).sortDirection != entitySortDirection.Normal ? buVector5.ToPoint3D(calculatedEntity.Vertices[0]) : buVector5.ToPoint3D(calculatedEntity.Vertices[calculatedEntity.Vertices.Length - 1]);
          Line line1 = new Line(start, new Point3D(this.varSpinningRuntime.pntCurveFinishStart.X, start.Y, start.Z));
          line1.EntityData = (object) new CustomData();
          this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.Add((Entity) line1);
          Line line2 = new Line(new Point3D(this.varSpinningRuntime.pntCurveFinishStart.X, start.Y, start.Z), new Point3D(this.varSpinningRuntime.pntCurveFinishStart.X, this.varSpinningRuntime.pntCurveFinishStart.Y - 0.0, this.varSpinningRuntime.pntCurveFinishStart.Z));
          line2.EntityData = (object) new CustomData()
          {
            Tags = "finishconnect"
          };
          this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].CalculatedEntities.Add((Entity) line2);
          SpinPatternCommand Data1 = new SpinPatternCommand();
          Data1.NextPattern = true;
          this.pntStart = buVector5.ToPoint3D(this.varSpinningRuntime.pntCurveFinishStart);
          double stepCatchLength = clsSpinning.frmSpin.varSpinPattern.StepCatchLength;
          clsSpinning.frmSpin.varSpinPattern.StepCatchLength = 10000.0;
          clsSpinning.varMetalSpinning.StepCatchLength = 100000.0;
          this.ShowPath((object) null, (object) Data1);
          clsSpinning.frmSpin.varSpinPattern.StepCatchLength = stepCatchLength;
          clsSpinning.varMetalSpinning.StepCatchLength = stepCatchLength;
          this.ShowPath((object) null, (object) new SpinPatternCommand()
          {
            OK = true
          });
        }
        this.varSpinningRuntime.isFinish = false;
      }
      else if (spinPatternCommand.SimStart & this.tempCalcEntitities != null & this.BaseRoughtOffsetedEntities != null)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.Top);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(new Vector3D(0.0, -0.1, 0.999), false);
        ccVars.Pages[ccVars.PageIndex].Cams.Clear();
        List<Entity> BaseRefEntities = new List<Entity>();
        if (!clsSpinning.varMetalSpinning.HidePrevious)
        {
          for (int index5 = 0; index5 <= this.CalculatedEntitiesList.Count - 1; ++index5)
          {
            for (int index6 = 0; index6 <= this.CalculatedEntitiesList[index5].CalculatedEntities.Count - 1; ++index6)
            {
              Entity copiedEnt = (Entity) null;
              buVector5.CopyEntities(this.CalculatedEntitiesList[index5].CalculatedEntities[index6], ref copiedEnt);
              BaseRefEntities.Add(copiedEnt);
            }
          }
        }
        for (int index7 = 0; index7 <= this.tempCalcEntitities.Count - 1; ++index7)
        {
          for (int index8 = 0; index8 <= this.tempCalcEntitities[index7].Count - 1; ++index8)
          {
            Entity copiedEnt = (Entity) null;
            buVector5.CopyEntities(this.tempCalcEntitities[index7][index8], ref copiedEnt);
            BaseRefEntities.Add(copiedEnt);
          }
        }
        camTp CamCalculated = new camTp();
        SortSettings Settings = new SortSettings();
        List<Entity> SortedEntities = new List<Entity>();
        SortResult Result = new SortResult();
        clsInit.cVector5.SortEntitiesByRefPoint(this.varSpinningRuntime.pntCurveStart, ref BaseRefEntities, Settings, ref SortedEntities, ref Result);
        clsInit.cCam5.camContourCenter(SortedEntities, false, ccVars.toolActive, new camParameters5()
        {
          Distances = {
            Safe = 0.0,
            Rapid = 0.0
          },
          Options = {
            FeedFromEntityFeedrate = true
          }
        }, ref CamCalculated);
        ccVars.Pages[ccVars.PageIndex].Cams.Add(CamCalculated);
        clsInit.appCommand.simStart();
      }
      else if (spinPatternCommand.SimStop & this.BaseRoughtOffsetedEntities != null)
      {
        ccVars.Pages[ccVars.PageIndex].Cams.Clear();
        clsInit.appCommand.simStop();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.Top);
      }
      else if (spinPatternCommand.Undo & this.BaseRoughtOffsetedEntities != null)
      {
        if (this.CalculatedEntitiesList == null || this.CalculatedEntitiesList.Count <= 0)
          return;
        this.pntStart = buVector5.ToPoint3D(this.CalculatedEntitiesList[this.CalculatedEntitiesList.Count - 1].StartPoint);
        this.CalculatedEntitiesList.RemoveAt(this.CalculatedEntitiesList.Count - 1);
        this.ShowPath((object) null, (object) new SpinPatternCommand()
        {
          ShowPattern = true
        });
      }
      else
      {
        ccVars.pntDrawDynamicLinesArrColored.Clear();
        clsSpinning.varMetalSpinning = new SpinPattern(clsSpinning.frmSpin.varSpinPattern);
        if (!((spinPatternCommand.ShowPattern | spinPatternCommand.NextPattern) & this.BaseRoughtOffsetedEntities != null))
          return;
        double num1 = clsSpinning.varMetalSpinning.CurveOffset;
        Point3D point3D1 = new Point3D();
        Point3D point3D2 = buVector5.ToPoint3D(this.pntStart);
        this.tempCalcEntitities = new List<List<Entity>>();
        if (this.varSpinningRuntime.isFinish)
          num1 = 0.0;
        double y = 0.0;
        for (int index9 = 0; index9 <= clsSpinning.varMetalSpinning.RepeatCount - 1; ++index9)
        {
          this.calcEnt = new List<Entity>();
          this.calcEntReturn = new List<Entity>();
          if (!this.varSpinningRuntime.isFinish)
          {
            clsInit.cVector5.getPointAtEntitiesBetweenStartPointAndLength(point3D2, clsSpinning.varMetalSpinning.StepCatchLength + clsSpinning.varMetalSpinning.ReturnSameWayOffset, 0.01, this.BaseRoughtOffsetedEntities, ref this.varSpinningRuntime.pntSameWayReturn);
            this.getEntitiesBetweenStartPointAndLength(point3D2, clsSpinning.varMetalSpinning, this.BaseRoughtOffsetedEntities, false, ref this.calcEnt, ref pntNewStart, ref pntReturn, ref this.varSpinningRuntime.DirectionAngle);
            this.getEntitiesBetweenStartPointAndEndPoint(pntReturn, this.varSpinningRuntime.pntSameWayReturn, clsSpinning.varMetalSpinning, this.BaseRoughtOffsetedEntities, ref this.calcEntReturn);
          }
          else
            this.getEntitiesBetweenStartPointAndLength(point3D2, clsSpinning.varMetalSpinning, this.BaseFinishOffsetedEntities, false, ref this.calcEnt, ref pntNewStart, ref pntReturn, ref this.varSpinningRuntime.DirectionAngle);
          Point3D point3D3 = new Point3D();
          Point3D point3D4 = new Point3D();
          SpinPattern varPattern = new SpinPattern(clsSpinning.varMetalSpinning);
          if (this.varSpinningRuntime.DirectionAngle >= 90.0 & this.varSpinningRuntime.DirectionAngle < 100.0)
            varPattern.LeaveArcRadiusRatioFromHeight = clsSpinning.varMetalSpinning.LeaveArcRadiusRatioFromHeight90To100;
          else if (this.varSpinningRuntime.DirectionAngle >= 100.0 & this.varSpinningRuntime.DirectionAngle < 110.0)
            varPattern.LeaveArcRadiusRatioFromHeight = clsSpinning.varMetalSpinning.LeaveArcRadiusRatioFromHeight100To110;
          else if (this.varSpinningRuntime.DirectionAngle >= 110.0 & this.varSpinningRuntime.DirectionAngle < 120.0)
            varPattern.LeaveArcRadiusRatioFromHeight = clsSpinning.varMetalSpinning.LeaveArcRadiusRatioFromHeight110To120;
          else if (this.varSpinningRuntime.DirectionAngle >= 120.0 & this.varSpinningRuntime.DirectionAngle < 130.0)
            varPattern.LeaveArcRadiusRatioFromHeight = clsSpinning.varMetalSpinning.LeaveArcRadiusRatioFromHeight120To130;
          else if (this.varSpinningRuntime.DirectionAngle >= 130.0 & this.varSpinningRuntime.DirectionAngle < 150.0)
            varPattern.LeaveArcRadiusRatioFromHeight = clsSpinning.varMetalSpinning.LeaveArcRadiusRatioFromHeight130To150;
          else if (this.varSpinningRuntime.DirectionAngle >= 150.0 & this.varSpinningRuntime.DirectionAngle < 180.0)
            varPattern.LeaveArcRadiusRatioFromHeight = clsSpinning.varMetalSpinning.LeaveArcRadiusRatioFromHeight150To180;
          varPattern.LeaveArcRadiusRatioFromHeight *= clsSpinning.varMetalSpinning.LeaveArcRadiusRatioFromHeight;
          this.CalculateLeaveAngle(pntNewStart, varPattern, this.BaseRoughtOffsetedEntities, ref this.varSpinningRuntime.pntLeaveArcMid, ref this.varSpinningRuntime.pntLeaveArcEnd);
          if (this.calcEnt.Count > 0)
          {
            for (int index10 = 0; index10 <= this.calcEnt.Count - 1; ++index10)
            {
              if (this.calcEnt[index10].EntityData == null)
                this.calcEnt[index10].EntityData = (object) new CustomData()
                {
                  CamFeedrate = clsSpinning.varMetalSpinning.CamFeed
                };
              else
                ((CustomData) this.calcEnt[index10].EntityData).CamFeedrate = clsSpinning.varMetalSpinning.CamFeed;
            }
            this.CreateLeave(this.calcEnt[this.calcEnt.Count - 1], pntNewStart, pntReturn, varPattern, ref calcEnt);
            for (int index11 = 0; index11 <= calcEnt.Count - 1; ++index11)
              this.calcEnt.Add(calcEnt[index11]);
            if (!clsSpinning.varMetalSpinning.HidePrevious)
            {
              for (int index12 = 0; index12 <= this.CalculatedEntitiesList.Count - 1; ++index12)
              {
                for (int index13 = 0; index13 <= this.CalculatedEntitiesList[index12].CalculatedEntities.Count - 1; ++index13)
                {
                  List<PointRGB> pointRgbList = new List<PointRGB>();
                  buVector5.VerticeToPointsList(this.CalculatedEntitiesList[index12].CalculatedEntities[index13].Vertices, ref pointRgbList, Color.Blue);
                  clsInit.cVector5.AddValueToPointList(0.0, y, 0.0, ref pointRgbList);
                  ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList);
                }
              }
            }
            if (this.calcEnt.Count > 0)
            {
              for (int index14 = 0; index14 <= this.calcEnt.Count - 1; ++index14)
              {
                List<PointRGB> pointRgbList = new List<PointRGB>();
                buVector5.VerticeToPointsList(this.calcEnt[index14].Vertices, ref pointRgbList, Color.Red);
                clsInit.cVector5.AddValueToPointList(0.0, y, 0.0, ref pointRgbList);
                ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList);
              }
            }
            this.tempCalcEntitities.Add(this.calcEnt);
          }
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
          point3D2 = buVector5.ToPoint3D(pntReturn);
          if (spinPatternCommand.NextPattern)
          {
            this.pntLastCalc = buVector5.ToPoint3D(this.varSpinningRuntime.pntLastCalc);
            SpinCalculatedData spinCalculatedData = new SpinCalculatedData();
            spinCalculatedData.StartPoint = buVector5.ToPoint3D(this.pntStart);
            spinCalculatedData.YOffset = y;
            spinCalculatedData.ReturnSameWay = clsSpinning.varMetalSpinning.ReturnSameWay;
            spinCalculatedData.isFinished = this.varSpinningRuntime.isFinish;
            buVector5.CopyEntities(this.calcEnt, ref spinCalculatedData.CalculatedEntities);
            this.CalculatedEntitiesList.Add(spinCalculatedData);
            this.pntStart = buVector5.ToPoint3D(pntReturn);
            if (!this.varSpinningRuntime.isLastSpin)
              this.ShowPath((object) null, (object) new SpinPatternCommand()
              {
                ShowPattern = true
              });
            else if (!this.varSpinningRuntime.isFinish)
              this.ShowPath((object) null, (object) new SpinPatternCommand()
              {
                OK = true
              });
          }
        }
        Point3D MaxPoint = new Point3D();
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArrColored, ref MinPoint, ref MidPoint, ref MaxPoint);
        ccVars.pntDrawDynamicMeasure.Clear();
        MeasureData measureData1 = new MeasureData();
        measureData1.Color = Color.Red;
        measureData1.Points.Add(new Point3D(MinPoint.X, MaxPoint.Y + 10.0, 0.0));
        measureData1.Points.Add(new Point3D(MaxPoint.X, MaxPoint.Y + 10.0, 0.0));
        measureData1.PntText = new Point3D(MidPoint.X, MaxPoint.Y + 20.0, 0.0);
        MeasureData measureData2 = measureData1;
        double num2 = MaxPoint.X - MinPoint.X;
        string str1 = num2.ToString("f1") + " mm";
        measureData2.Text = str1;
        ccVars.pntDrawDynamicMeasure.Add(measureData1);
        MeasureData measureData3 = new MeasureData();
        measureData3.Color = Color.Green;
        measureData3.Points.Add(new Point3D(MinPoint.X - 10.0, MaxPoint.Y, 0.0));
        measureData3.Points.Add(new Point3D(MinPoint.X - 10.0, 0.0, 0.0));
        measureData3.PntText = new Point3D(MinPoint.X - 20.0, MaxPoint.Y / 2.0, 0.0);
        MeasureData measureData4 = measureData3;
        num2 = MaxPoint.Y - 0.0;
        string str2 = num2.ToString("f1") + " mm";
        measureData4.Text = str2;
        ccVars.pntDrawDynamicMeasure.Add(measureData3);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void ValueChanged(object Data)
  {
    clsSpinning.varMetalSpinning = new SpinPattern((SpinPattern) Data);
    this.ShowPath((object) null, (object) new SpinPatternCommand()
    {
      ShowPattern = true
    });
  }

  public void ShowPipePath(object sender, object Data)
  {
    try
    {
      SpinPatternCommand spinPatternCommand = (SpinPatternCommand) Data;
      Point3D point3D1 = new Point3D();
      Point3D point3D2 = new Point3D();
      List<Entity> entityList = new List<Entity>();
      ccVars.pntDrawDynamicLinesArrColored.Clear();
      clsSpinning.varMetalPipeSpinning = new SpinPipePattern(clsSpinning.frmSpinPipe.varSpinPattern);
      if (!(spinPatternCommand.ShowPattern | spinPatternCommand.NextPattern))
        return;
      Point3D MinPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      camStep Steps = new camStep();
      List<double> CalcValues = new List<double>();
      Steps.StartValue = MaxPoint.Y - clsSpinning.varMetalPipeSpinning.TubeTopOffset;
      Steps.EndValue = MidPoint.Y + clsSpinning.varMetalPipeSpinning.CenterLineOffset;
      Steps.StepType = CamStepType.StartToEndByStep;
      Steps.Step = clsSpinning.varMetalPipeSpinning.StepDepth;
      Steps.Enable = true;
      clsInit.cVector.CamStepCalculation(Steps, ref CalcValues);
      if (CalcValues.Count <= 0)
        return;
      double num1 = 0.0;
      double num2 = 0.0;
      for (int index1 = 0; index1 <= CalcValues.Count - 1; ++index1)
      {
        double num3 = (double) index1 * clsSpinning.varMetalPipeSpinning.SetTubeLeftOffsetEachStep;
        double num4 = (double) index1 * clsSpinning.varMetalPipeSpinning.SetTubeRightOffsetEachStep;
        List<Point3D> SortingPoints = new List<Point3D>();
        Line line = new Line(new Point3D(MinPoint.X - 10.0, CalcValues[index1]), new Point3D(MaxPoint.X + 10.0, CalcValues[index1]));
        for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
        {
          Point3D[] collection = line.IntersectWith((ICurve) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2], 0.0, true);
          if (collection != null && collection.Length != 0)
            SortingPoints.AddRange((IEnumerable<Point3D>) collection);
        }
        clsInit.cVector5.SortDeltaX(MaxPoint, SortDirectionType.Bigger, ref SortingPoints);
        if (SortingPoints.Count >= 2)
        {
          List<PointRGB> pointRgbList1 = new List<PointRGB>();
          double x1 = SortingPoints[0].X - clsSpinning.varMetalPipeSpinning.TubeRigthOffset - num4;
          double y1 = SortingPoints[0].Y;
          double num5 = SortingPoints[1].X + clsSpinning.varMetalPipeSpinning.PipeLeftOffset + num3;
          double y2 = SortingPoints[1].Y;
          Point3D first = new Point3D(x1 + clsSpinning.varMetalPipeSpinning.FirstCurveLength, y1 - clsSpinning.varMetalPipeSpinning.FirstCurveLength);
          Point3D second = new Point3D(x1 + clsSpinning.varMetalPipeSpinning.LeadinCurveLength * 0.8, y1);
          Point3D third = new Point3D(x1, y1 + clsSpinning.varMetalPipeSpinning.LeadinCurveLength);
          Arc arc1 = new Arc(first, second, third, false);
          arc1.Regen(0.001);
          Color color;
          if (index1 > 0)
          {
            List<PointRGB> pointRgbList2 = pointRgbList1;
            double x2 = num1;
            double y3 = num2;
            color = Color.DarkOrange;
            int r1 = (int) color.R;
            color = Color.DarkOrange;
            int g1 = (int) color.G;
            color = Color.DarkOrange;
            int b1 = (int) color.B;
            PointRGB pointRgb1 = new PointRGB(x2, y3, 0.0, (byte) r1, (byte) g1, (byte) b1);
            pointRgbList2.Add(pointRgb1);
            List<PointRGB> pointRgbList3 = pointRgbList1;
            double x3 = third.X;
            double y4 = num2;
            color = Color.LimeGreen;
            int r2 = (int) color.R;
            color = Color.LimeGreen;
            int g2 = (int) color.G;
            color = Color.LimeGreen;
            int b2 = (int) color.B;
            PointRGB pointRgb2 = new PointRGB(x3, y4, 0.0, (byte) r2, (byte) g2, (byte) b2);
            pointRgbList3.Add(pointRgb2);
          }
          for (int index3 = arc1.Vertices.Length - 1; index3 >= 0; --index3)
          {
            List<PointRGB> pointRgbList4 = pointRgbList1;
            double x4 = arc1.Vertices[index3].X;
            double y5 = arc1.Vertices[index3].Y;
            double z = arc1.Vertices[index3].Z;
            color = Color.Blue;
            int r = (int) color.R;
            color = Color.Blue;
            int b3 = (int) color.B;
            color = Color.Blue;
            int b4 = (int) color.B;
            PointRGB pointRgb = new PointRGB(x4, y5, z, (byte) r, (byte) b3, (byte) b4);
            pointRgbList4.Add(pointRgb);
          }
          Arc arc2 = new Arc(new Point3D(x1 + clsSpinning.varMetalPipeSpinning.FirstCurveLength, y1 - clsSpinning.varMetalPipeSpinning.FirstCurveLength), new Point3D(x1 + clsSpinning.varMetalPipeSpinning.FirstCurveLength * 0.8, y1 - clsSpinning.varMetalPipeSpinning.FirstCurveLength * 0.5), new Point3D(x1, y1), false);
          arc2.Regen(0.001);
          for (int index4 = 0; index4 <= arc2.Vertices.Length - 1; ++index4)
          {
            List<PointRGB> pointRgbList5 = pointRgbList1;
            double x5 = arc2.Vertices[index4].X;
            double y6 = arc2.Vertices[index4].Y;
            double z = arc2.Vertices[index4].Z;
            color = Color.Blue;
            int r = (int) color.R;
            color = Color.Blue;
            int g = (int) color.G;
            color = Color.Blue;
            int b = (int) color.B;
            PointRGB pointRgb = new PointRGB(x5, y6, z, (byte) r, (byte) g, (byte) b);
            pointRgbList5.Add(pointRgb);
          }
          List<PointRGB> pointRgbList6 = pointRgbList1;
          double x6 = x1;
          double y7 = y1;
          double z1 = SortingPoints[0].Z;
          color = Color.Blue;
          int r3 = (int) color.R;
          color = Color.Blue;
          int g3 = (int) color.G;
          color = Color.Blue;
          int b5 = (int) color.B;
          PointRGB pointRgb3 = new PointRGB(x6, y7, z1, (byte) r3, (byte) g3, (byte) b5);
          pointRgbList6.Add(pointRgb3);
          List<PointRGB> pointRgbList7 = pointRgbList1;
          double x7 = num5;
          double y8 = y2;
          double z2 = SortingPoints[1].Z;
          color = Color.Blue;
          int r4 = (int) color.R;
          color = Color.Blue;
          int g4 = (int) color.G;
          color = Color.Blue;
          int b6 = (int) color.B;
          PointRGB pointRgb4 = new PointRGB(x7, y8, z2, (byte) r4, (byte) g4, (byte) b6);
          pointRgbList7.Add(pointRgb4);
          if (pointRgbList1.Count > 0)
          {
            List<PointRGB> pointRgbList8 = pointRgbList1;
            int index5 = pointRgbList1.Count - 1;
            double x8 = pointRgbList1[pointRgbList1.Count - 1].X;
            double y9 = pointRgbList1[pointRgbList1.Count - 1].Y;
            double z3 = pointRgbList1[pointRgbList1.Count - 1].Z;
            color = Color.Gold;
            int r5 = (int) color.R;
            color = Color.Gold;
            int g5 = (int) color.G;
            color = Color.Gold;
            int b7 = (int) color.B;
            PointRGB pointRgb5 = new PointRGB(x8, y9, z3, (byte) r5, (byte) g5, (byte) b7);
            pointRgbList8[index5] = pointRgb5;
          }
          List<PointRGB> pointRgbList9 = pointRgbList1;
          double x9 = num5;
          double y10 = y2 + clsSpinning.varMetalPipeSpinning.LeaveHeight;
          double z4 = SortingPoints[0].Z;
          color = Color.Gold;
          int r6 = (int) color.R;
          color = Color.Gold;
          int g6 = (int) color.G;
          color = Color.Gold;
          int b8 = (int) color.B;
          PointRGB pointRgb6 = new PointRGB(x9, y10, z4, (byte) r6, (byte) g6, (byte) b8);
          pointRgbList9.Add(pointRgb6);
          num1 = num5;
          num2 = y2 + clsSpinning.varMetalPipeSpinning.LeaveHeight;
          ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList1);
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void ValuePipeChanged(object Data)
  {
    clsSpinning.varMetalPipeSpinning = new SpinPipePattern((SpinPipePattern) Data);
    SpinPatternCommand Data1 = new SpinPatternCommand();
    Data1.ShowPattern = true;
    clsFiles.SaveParameter();
    this.ShowPipePath((object) null, (object) Data1);
  }
}
