// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Nesting.clsPowerNest
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.DialogBox;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using ns8;
using Opaline2Cs;
using PowerNest2Cs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Nesting;

public class clsPowerNest
{
  public static List<string> ErrorList = new List<string>();
  public PowerNest2 tempPowerNest = (PowerNest2) null;
  public Opaline OPL = new Opaline();
  public string Login = "fatih@115";
  public static bool bExecute = false;
  public static bool bExecuteDone = false;
  public static bool bStop = false;
  public static Thread threadExecute = (Thread) null;
  public static int ExecutionCounter = 0;
  public List<buNestedResult> tempBetterNestedResult = new List<buNestedResult>();
  public static List<MultiResult> storedNestedResult = new List<MultiResult>();
  private MultiResult multiResult_0 = (MultiResult) null;
  private IList<Sheet> ilist_0 = (IList<Sheet>) new List<Sheet>();
  private IList<buNestingSheet> ilist_1 = (IList<buNestingSheet>) new List<buNestingSheet>();
  private IList<PowerNest2Cs.Part> ilist_2 = (IList<PowerNest2Cs.Part>) new List<PowerNest2Cs.Part>();
  private IList<buNestingPart> ilist_3 = (IList<buNestingPart>) new List<buNestingPart>();
  private IList<int> ilist_4 = (IList<int>) new List<int>();
  private IUserData iuserData_0 = (IUserData) null;
  private IUserData iuserData_1 = (IUserData) null;
  private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();
  private double double_0 = 30.0;
  private int int_0 = 1;
  private bool bool_0 = false;
  private DateTime dateTime_0 = new DateTime();

  public bool isDongleAvailable()
  {
    try
    {
      if (this.tempPowerNest == null)
        this.tempPowerNest = new PowerNest2();
      bool flag = this.tempPowerNest.CheckDetectedExe();
      this.DisposeNesting();
      return flag;
    }
    catch (Exception ex)
    {
      buString5.MessageBoxError("NO Nesting Dongle");
      Environment.Exit(0);
      return false;
    }
  }

  public void DisposeNesting()
  {
    try
    {
      if (this.tempPowerNest == null)
        return;
      this.tempPowerNest.Dispose();
    }
    catch (Exception ex)
    {
    }
  }

  public string PowerNestLogin => this.Login.Trim();

  public bool AddPart(List<buNestingPart> Parts)
  {
    try
    {
      this.ilist_2.Clear();
      this.ilist_2 = (IList<PowerNest2Cs.Part>) new List<PowerNest2Cs.Part>();
      this.ilist_3.Clear();
      this.ilist_3 = (IList<buNestingPart>) new List<buNestingPart>();
      clsPowerNest.ErrorList.Clear();
      for (int index1 = 0; index1 <= Parts.Count - 1; ++index1)
      {
        Shape shape = (Shape) null;
        bool flag1 = false;
        string str = "";
        if (Parts[index1].Enable & Parts[index1].Remain > 0)
        {
          IList<PowerNest2Cs.Orientation> orientationList = (IList<PowerNest2Cs.Orientation>) new List<PowerNest2Cs.Orientation>();
          if (Parts[index1].PartData.Rotation == nestPartRotateType.FreeRotate)
            orientationList.Add(this.tempPowerNest.CreateFreeOrientation(Parts[index1].PartData.Mirror));
          else if (Parts[index1].PartData.Rotation == nestPartRotateType.Increment180)
          {
            if (!Parts[index1].PartData.Mirror)
            {
              orientationList.Add(PowerNest2.CreateOrientation(0.0));
              orientationList.Add(PowerNest2.CreateOrientation(180.0));
            }
            else
            {
              orientationList.Add(PowerNest2.CreateXFlippedOrientation(0.0));
              orientationList.Add(PowerNest2.CreateXFlippedOrientation(180.0));
            }
            if (Parts[index1].PartData.AdditionalRotation > 0.0)
            {
              double tolerance = Parts[index1].PartData.AdditionalRotation / 2.0;
              if (!Parts[index1].PartData.Mirror)
              {
                orientationList.Add(PowerNest2.CreateRangeOrientation(0.0 + tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateRangeOrientation(180.0 - tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateRangeOrientation(180.0 + tolerance, tolerance));
              }
              else
              {
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(0.0 + tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(180.0 - tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(180.0 + tolerance, tolerance));
              }
            }
          }
          else if (Parts[index1].PartData.Rotation == nestPartRotateType.Fixed0)
          {
            orientationList.Add(PowerNest2.CreateOrientation(0.0));
          }
          else
          {
            if (!Parts[index1].PartData.Mirror)
            {
              orientationList.Add(PowerNest2.CreateOrientation(0.0));
              orientationList.Add(PowerNest2.CreateOrientation(90.0));
              orientationList.Add(PowerNest2.CreateOrientation(180.0));
              orientationList.Add(PowerNest2.CreateOrientation(270.0));
            }
            else
            {
              orientationList.Add(PowerNest2.CreateXFlippedOrientation(0.0));
              orientationList.Add(PowerNest2.CreateXFlippedOrientation(90.0));
              orientationList.Add(PowerNest2.CreateXFlippedOrientation(180.0));
              orientationList.Add(PowerNest2.CreateXFlippedOrientation(270.0));
            }
            if (Parts[index1].PartData.AdditionalRotation > 0.0)
            {
              double tolerance = Parts[index1].PartData.AdditionalRotation / 2.0;
              if (!Parts[index1].PartData.Mirror)
              {
                orientationList.Add(PowerNest2.CreateRangeOrientation(0.0 + tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateRangeOrientation(90.0 - tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateRangeOrientation(90.0 + tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateRangeOrientation(180.0 - tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateRangeOrientation(180.0 + tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateRangeOrientation(270.0 - tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateRangeOrientation(270.0 + tolerance, tolerance));
              }
              else
              {
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(0.0 + tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(90.0 - tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(90.0 + tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(180.0 - tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(180.0 + tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(270.0 - tolerance, tolerance));
                orientationList.Add(PowerNest2.CreateXFlippedRangeOrientation(270.0 + tolerance, tolerance));
              }
            }
          }
          if (Parts[index1].Type == nestMaterialType.Rectangle)
          {
            IList<PowerNest2Cs.Point> pointList = (IList<PowerNest2Cs.Point>) new List<PowerNest2Cs.Point>();
            for (int index2 = 0; index2 <= Parts[index1].EntitiesGroup.Outside.Points.Count - 1; ++index2)
              pointList.Add(new PowerNest2Cs.Point(Parts[index1].EntitiesGroup.Outside.Points[index2].X, Parts[index1].EntitiesGroup.Outside.Points[index2].Y));
            if (pointList.Count >= 4)
            {
              shape = this.tempPowerNest.AddShape((IEnumerable<PowerNest2Cs.Point>) pointList);
              flag1 = true;
            }
          }
          else
          {
            List<PowerNest2Cs.Point> pointList1 = new List<PowerNest2Cs.Point>();
            List<double> doubleList = new List<double>();
            if (Parts[index1].EntitiesGroup.Outside.Points == null)
            {
              Parts[index1].EntitiesGroup.Outside.Points = new List<Point3D>();
              clsInit.cVector5.EntitiesToPointsWithCamDirection(Parts[index1].EntitiesGroup.Outside.Entities, ref Parts[index1].EntitiesGroup.Outside.Points);
            }
            if ((Parts[index1].EntitiesGroup.Outside.Entities == null ? 0 : (Parts[index1].EntitiesGroup.Outside.Entities.Count > 0 ? 1 : 0)) != 0)
              str = Parts[index1].EntitiesGroup.Outside.Entities[0].LayerName;
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Parts[index1].EntitiesGroup.Outside.Points);
            if (!clsInit.cVector5.IsClosed(Parts[index1].EntitiesGroup.Outside.Points))
              ;
            for (int index3 = 0; index3 <= Parts[index1].EntitiesGroup.Outside.Points.Count - 1; ++index3)
              pointList1.Add(new PowerNest2Cs.Point(Parts[index1].EntitiesGroup.Outside.Points[index3].X, Parts[index1].EntitiesGroup.Outside.Points[index3].Y));
            Contour contourFromPoints1 = this.tempPowerNest.CreateContourFromPoints((IEnumerable<PowerNest2Cs.Point>) pointList1);
            ErrorCode errorCode1 = this.tempPowerNest.GetErrorCode((PowerNest2Cs.Wrappable) contourFromPoints1);
            bool flag2 = false;
            if (errorCode1 == ErrorCode.OK)
            {
              shape = this.tempPowerNest.AddShapeFromContour(contourFromPoints1, new PowerNest2Cs.Point());
            }
            else
            {
              clsPowerNest.ErrorList.Add($"{index1.ToString()}. Part Contour Hole Add Part : {Parts[index1].PartData.Name} -  {errorCode1.ToString()}");
              flag2 = true;
            }
            if (!flag2)
            {
              if (Parts[index1].UseInnersAsHolePartInPart && Parts[index1].EntitiesGroup.Inside != null)
              {
                for (int index4 = 0; index4 <= Parts[index1].EntitiesGroup.Inside.Count - 1; ++index4)
                {
                  if ((Parts[index1].EntitiesGroup.Inside[index4].Entities == null ? 0 : (Parts[index1].EntitiesGroup.Inside[index4].Entities.Count > 0 ? 1 : 0)) != 0 && Parts[index1].EntitiesGroup.Inside[index4].Entities[0].LayerName == str)
                  {
                    if (Parts[index1].EntitiesGroup.Inside[index4].Points == null)
                      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoInternalEntitiesPoints);
                    else if (Parts[index1].EntitiesGroup.Inside[index4].Points.Count >= 4 && clsInit.cVector5.IsClosed(Parts[index1].EntitiesGroup.Inside[index4].Points))
                    {
                      List<PowerNest2Cs.Point> pointList2 = new List<PowerNest2Cs.Point>();
                      for (int index5 = 0; index5 <= Parts[index1].EntitiesGroup.Inside[index4].Points.Count - 1; ++index5)
                        pointList2.Add(new PowerNest2Cs.Point(Parts[index1].EntitiesGroup.Inside[index4].Points[index5].X, Parts[index1].EntitiesGroup.Inside[index4].Points[index5].Y));
                      Contour contourFromPoints2 = this.tempPowerNest.CreateContourFromPoints((IEnumerable<PowerNest2Cs.Point>) pointList2);
                      ErrorCode errorCode2 = this.tempPowerNest.GetErrorCode((PowerNest2Cs.Wrappable) contourFromPoints2);
                      if (errorCode2 == ErrorCode.OK)
                      {
                        int num = (int) this.tempPowerNest.ShapeAddHoleFromContour(shape, contourFromPoints2);
                      }
                      else
                        clsPowerNest.ErrorList.Add($"{index1.ToString()}. Part Error Hole Add Part : {Parts[index1].PartData.Name} -  {errorCode2.ToString()}");
                    }
                  }
                }
              }
              flag1 = true;
            }
          }
          if (flag1)
          {
            int num1 = 0;
            if (Parts[index1].PartDistance > 0.0)
            {
              int num2 = (int) this.tempPowerNest.ShapeSetProtectionOffset(shape, Parts[index1].PartDistance);
            }
            else
            {
              int num3 = (int) this.tempPowerNest.ShapeSetProtectionOffset(shape, clsNesting.ParNest.PartSettings.PartsSpace);
            }
            IEnumerable<PowerNest2Cs.Part> partList = (IEnumerable<PowerNest2Cs.Part>) new List<PowerNest2Cs.Part>();
            int num4 = (int) this.tempPowerNest.AddSeveralParts(shape, (IEnumerable<PowerNest2Cs.Orientation>) orientationList, Parts[index1].Remain * clsNesting.ParNest.PartSettings.Multiply, out partList);
            for (int index6 = 0; index6 < partList.Count<PowerNest2Cs.Part>(); ++index6)
            {
              PowerNest2Cs.Part part = partList.ElementAt<PowerNest2Cs.Part>(index6);
              ErrorCode errorCode = this.tempPowerNest.GetErrorCode((PowerNest2Cs.Wrappable) part);
              if (errorCode == ErrorCode.OK)
              {
                this.ilist_2.Add(part);
              }
              else
              {
                clsPowerNest.ErrorList.Add($"{index1.ToString()}. Part Error Add Part : {Parts[index1].PartData.Name} -  {errorCode.ToString()}");
                ++num1;
              }
            }
            if (num1 == 0)
            {
              for (int index7 = 0; index7 <= Parts[index1].Remain * clsNesting.ParNest.PartSettings.Multiply - 1; ++index7)
                this.ilist_3.Add(new buNestingPart(Parts[index1]));
            }
          }
        }
      }
      if (clsPowerNest.ErrorList.Count <= 0)
        return true;
      DialogBoxList dialogBoxList = new DialogBoxList();
      dialogBoxList.Caption = buLangTranslate.preDef.Error;
      dialogBoxList.Width = 500;
      for (int index = 0; index <= clsPowerNest.ErrorList.Count - 1; ++index)
        dialogBoxList.Items.Add(clsPowerNest.ErrorList[index]);
      dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
      dialogBoxList.Init();
      int num5 = (int) dialogBoxList.ShowDialog();
      return dialogBoxList.Result == DialogResult.OK;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public void AddSheet(List<buNestingSheet> Sheets)
  {
    this.ilist_0.Clear();
    this.ilist_0 = (IList<Sheet>) new List<Sheet>();
    this.ilist_4.Clear();
    this.ilist_1.Clear();
    this.ilist_1 = (IList<buNestingSheet>) new List<buNestingSheet>();
    for (int index1 = 0; index1 <= Sheets.Count - 1; ++index1)
    {
      if (Sheets[index1].Enable & Sheets[index1].Remain > 0)
      {
        Sheet sheet;
        if (Sheets[index1].Type == nestMaterialType.Rectangle)
        {
          sheet = this.tempPowerNest.AddSheet(Sheets[index1].MaterialData.Height, Sheets[index1].MaterialData.Width);
          int num = (int) this.tempPowerNest.SheetAddBorderGaps(sheet, clsNesting.ParNest.MaterailSettings.RectangleMarginLeft, clsNesting.ParNest.MaterailSettings.RectangleMarginRight, clsNesting.ParNest.MaterailSettings.RectangleMarginBottom, clsNesting.ParNest.MaterailSettings.RectangleMarginTop);
        }
        else
        {
          List<PowerNest2Cs.Point> pointList = new List<PowerNest2Cs.Point>();
          for (int index2 = 0; index2 <= Sheets[index1].EntitiesGroup.Outside.Points.Count - 1; ++index2)
            pointList.Add(new PowerNest2Cs.Point(Sheets[index1].EntitiesGroup.Outside.Points[index2].X, Sheets[index1].EntitiesGroup.Outside.Points[index2].Y));
          sheet = this.tempPowerNest.AddSheetFromContourWithBorderGap(this.tempPowerNest.CreateContourFromPoints((IEnumerable<PowerNest2Cs.Point>) pointList), clsNesting.ParNest.MaterailSettings.IrregularMargin);
        }
        if (Sheets[index1].EntitiesGroup.Inside != null)
        {
          for (int index3 = 0; index3 <= Sheets[index1].EntitiesGroup.Inside.Count - 1; ++index3)
          {
            if (clsInit.cVector5.IsClosed(Sheets[index1].EntitiesGroup.Inside[index3].Points))
            {
              List<PowerNest2Cs.Point> pointList = new List<PowerNest2Cs.Point>();
              for (int index4 = 0; index4 <= Sheets[index1].EntitiesGroup.Inside[index3].Points.Count - 1; ++index4)
                pointList.Add(new PowerNest2Cs.Point(Sheets[index1].EntitiesGroup.Inside[index3].Points[index4].X, Sheets[index1].EntitiesGroup.Inside[index3].Points[index4].Y));
              Contour contourFromPoints = this.tempPowerNest.CreateContourFromPoints((IEnumerable<PowerNest2Cs.Point>) pointList);
              int num = (int) this.tempPowerNest.SheetAddDefectFromContour(sheet, contourFromPoints);
            }
          }
        }
        ErrorCode errorCode = this.tempPowerNest.GetErrorCode((PowerNest2Cs.Wrappable) sheet);
        if (errorCode == ErrorCode.OK)
        {
          this.ilist_0.Add(sheet);
          this.ilist_4.Add(Sheets[index1].Remain);
        }
        else
          clsPowerNest.ErrorList.Add($"Error Add Sheet : {Sheets[index1].MaterialData.Name} - {errorCode.ToString()}");
        this.ilist_1.Add(new buNestingSheet(Sheets[index1]));
      }
    }
  }

  public void DrawToMultiSvg(PowerNest2 PowerNest, MultiResult Result, string FileName)
  {
    int num = (int) PowerNest.DrawMultiSvg(Result, FileName);
  }

  public void MultiResultToNestedResult(MultiResult nestMultiResult, ref buNestedResult Result)
  {
    if (this.tempPowerNest.GetErrorCode((PowerNest2Cs.Wrappable) nestMultiResult) == ErrorCode.OK)
    {
      Result = new buNestedResult();
      int nbSheets = 0;
      ErrorCode multiResultInfos = this.tempPowerNest.GetMultiResultInfos(nestMultiResult, out nbSheets);
      if (multiResultInfos == ErrorCode.OK)
      {
        Result.NestedSheetCount = nbSheets;
        int count = this.ilist_3.Count;
        int num1 = 0;
        for (int multiIndex = 0; multiIndex < nbSheets; ++multiIndex)
        {
          int index1 = -1;
          Sheet sheet_result;
          Result result1;
          if (clsNesting.ParNest.Settings.UseCompactMethod)
          {
            Result result2 = this.tempPowerNest.GetResult(nestMultiResult, multiIndex, out sheet_result);
            int num2 = (int) this.tempPowerNest.SetSessionOffcutSides(Side.Top, Side.Right);
            result1 = this.tempPowerNest.Compact(result2, DirectionType.BottomLeft, clsNesting.ParNest.Settings.CompactTime);
          }
          else
            result1 = this.tempPowerNest.GetResult(nestMultiResult, multiIndex, out sheet_result);
          ErrorCode errorCode = this.tempPowerNest.GetErrorCode((PowerNest2Cs.Wrappable) result1);
          if (errorCode == ErrorCode.OK)
          {
            for (int index2 = 0; index2 <= this.ilist_0.Count - 1; ++index2)
            {
              if ((PowerNest2Cs.Wrappable) sheet_result == (PowerNest2Cs.Wrappable) this.ilist_0[index2])
                index1 = index2;
            }
            if (index1 >= 0)
            {
              buNestedSheet sheetNested = new buNestedSheet(this.ilist_1[index1]);
              for (int index3 = 0; index3 < this.ilist_2.Count; ++index3)
              {
                PowerNest2Cs.Point position;
                PowerNest2Cs.Orientation orientation;
                if (this.tempPowerNest.GetNestedPart(result1, this.ilist_2.ElementAt<PowerNest2Cs.Part>(index3), out position, out orientation))
                {
                  buNestingPart buNestingPart = this.ilist_3[index3];
                  buNestedPart Part = buNestedPart.FromNestingPart(this.ilist_3[index3]);
                  clsInit.cVector5.EntitiesLength(buNestingPart.EntitiesGroup.Outside.Entities, ref Part.TotalOutSideLength);
                  this.GetApproxLEngthBLayerName(ref sheetNested, buNestingPart.EntitiesGroup.Outside.Entities);
                  ++sheetNested.TotalUpMove;
                  ++sheetNested.TotalDownMove;
                  if (buNestingPart.EntitiesGroup.Inside != null)
                  {
                    for (int index4 = 0; index4 <= buNestingPart.EntitiesGroup.Inside.Count - 1; ++index4)
                    {
                      double Length = 0.0;
                      clsInit.cVector5.EntitiesLength(buNestingPart.EntitiesGroup.Inside[index4].Entities, ref Length);
                      Part.TotalInsideLength += Length;
                      ++sheetNested.TotalUpMove;
                      ++sheetNested.TotalDownMove;
                      this.GetApproxLEngthBLayerName(ref sheetNested, buNestingPart.EntitiesGroup.Inside[index4].Entities);
                    }
                  }
                  if (buNestingPart.EntitiesGroup.OpenEntities != null)
                  {
                    for (int index5 = 0; index5 <= buNestingPart.EntitiesGroup.OpenEntities.Count - 1; ++index5)
                    {
                      double Length = 0.0;
                      clsInit.cVector5.EntitiesLength(buNestingPart.EntitiesGroup.OpenEntities[index5].Entities, ref Length);
                      Part.TotalInsideLength += Length;
                      ++sheetNested.TotalUpMove;
                      ++sheetNested.TotalDownMove;
                      this.GetApproxLEngthBLayerName(ref sheetNested, buNestingPart.EntitiesGroup.OpenEntities[index5].Entities);
                    }
                  }
                  if (buNestingPart.EntitiesGroup.Text != null)
                  {
                    for (int index6 = 0; index6 <= buNestingPart.EntitiesGroup.Text.Entities.Count - 1; ++index6)
                      ++sheetNested.TotalTextCount;
                  }
                  clsInit.cNesting.PartArea(Part, clsNesting.ParNest.ProgramSettings.UnitArea, clsNesting.ParNest.ResultSettings.PartAreaOnlyFromOutter, ref Part.PartArea);
                  sheetNested.NestedArea += Part.PartArea;
                  Part.TotalLength = Part.TotalInsideLength + Part.TotalOutSideLength;
                  Part.MovedDistance = new Vec3D(position.x, position.y);
                  Part.RotateValue = orientation.MinAngle;
                  if (orientation.HorizontalFlip == 1)
                  {
                    clsInit.cVector5.Mirror(new Point3D(), new Point3D(1.0, 0.0, 0.0), Plane.XY, ref Part.EntitiesGroup);
                    Part.RotateValue = -orientation.MinAngle;
                  }
                  clsInit.cVector5.Rotate(new Point3D(), Part.RotateValue, Vector3D.AxisZ, ref Part.EntitiesGroup);
                  clsInit.cVector5.Move(Part.MovedDistance.X, Part.MovedDistance.Y, 0.0, ref Part.EntitiesGroup);
                  if (orientation.HorizontalFlip == 1)
                    Part.isMirror = true;
                  int index7 = buNestingPart.ID % clsVar.ColorList.Count;
                  Part.Color = clsVar.ColorList[index7];
                  Part.Thickness = this.ilist_1[index1].MaterialData.Thickness + 1.0;
                  sheetNested.Parts.Add(Part);
                  sheetNested.TotalLength += Part.TotalLength;
                  sheetNested.TotalInsideLength = Math.Round(sheetNested.TotalInsideLength + Part.TotalInsideLength, 5);
                  sheetNested.TotalOutsideLength = Math.Round(sheetNested.TotalOutsideLength + Part.TotalOutSideLength, 5);
                  if (clsNesting.ParNest.ProgramSettings.UseNoneCutting && index3 > 0 & sheetNested.Parts.Count > 0)
                  {
                    Point3D vertex1 = sheetNested.Parts[sheetNested.Parts.Count - 1].EntitiesGroup.Outside.Entities[0].Vertices[0];
                    Point3D vertex2 = Part.EntitiesGroup.Outside.Entities[0].Vertices[0];
                    sheetNested.TotalNoneCuttingLength += Point3D.Distance(vertex1, vertex2);
                  }
                  ++num1;
                }
              }
              if (clsNesting.ParNest.ProgramSettings.CuttingSpeed > 0.0)
                sheetNested.ApproxExecutionTimeSec = sheetNested.TotalLength / clsNesting.ParNest.ProgramSettings.CuttingSpeed + (double) sheetNested.TotalUpMove * clsNesting.ParNest.ProgramSettings.PenUpTime + (double) sheetNested.TotalDownMove * clsNesting.ParNest.ProgramSettings.PenDownTime + (double) sheetNested.TotalTextCount * clsNesting.ParNest.ProgramSettings.TextTime;
              if (clsNesting.ParNest.ProgramSettings.NoneCuttingSpeed > 0.0 & clsNesting.ParNest.ProgramSettings.UseNoneCutting & sheetNested.TotalNoneCuttingLength > 0.0)
                sheetNested.ApproxExecutionTimeSec += sheetNested.TotalNoneCuttingLength / clsNesting.ParNest.ProgramSettings.NoneCuttingSpeed;
              if (sheetNested.ApproxExecution0Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer0Speed > 0.0)
                sheetNested.ApproxExecution0TimeSec = sheetNested.ApproxExecution0Len / clsNesting.ParNest.ProgramSettings.Layer0Speed + (double) sheetNested.ApproxExecution0UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution1Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer1Speed > 0.0)
                sheetNested.ApproxExecution1TimeSec = sheetNested.ApproxExecution1Len / clsNesting.ParNest.ProgramSettings.Layer1Speed + (double) sheetNested.ApproxExecution1UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution2Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer2Speed > 0.0)
                sheetNested.ApproxExecution2TimeSec = sheetNested.ApproxExecution2Len / clsNesting.ParNest.ProgramSettings.Layer2Speed + (double) sheetNested.ApproxExecution2UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution3Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer3Speed > 0.0)
                sheetNested.ApproxExecution3TimeSec = sheetNested.ApproxExecution3Len / clsNesting.ParNest.ProgramSettings.Layer3Speed + (double) sheetNested.ApproxExecution3UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution4Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer4Speed > 0.0)
                sheetNested.ApproxExecution4TimeSec = sheetNested.ApproxExecution4Len / clsNesting.ParNest.ProgramSettings.Layer4Speed + (double) sheetNested.ApproxExecution4UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution5Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer5Speed > 0.0)
                sheetNested.ApproxExecution5TimeSec = sheetNested.ApproxExecution5Len / clsNesting.ParNest.ProgramSettings.Layer5Speed + (double) sheetNested.ApproxExecution5UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution6Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer6Speed > 0.0)
                sheetNested.ApproxExecution6TimeSec = sheetNested.ApproxExecution6Len / clsNesting.ParNest.ProgramSettings.Layer6Speed + (double) sheetNested.ApproxExecution6UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution7Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer7Speed > 0.0)
                sheetNested.ApproxExecution7TimeSec = sheetNested.ApproxExecution7Len / clsNesting.ParNest.ProgramSettings.Layer7Speed + (double) sheetNested.ApproxExecution7UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution8Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer8Speed > 0.0)
                sheetNested.ApproxExecution8TimeSec = sheetNested.ApproxExecution8Len / clsNesting.ParNest.ProgramSettings.Layer8Speed + (double) sheetNested.ApproxExecution8UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution9Len > 0.0 & clsNesting.ParNest.ProgramSettings.Layer9Speed > 0.0)
                sheetNested.ApproxExecution9TimeSec = sheetNested.ApproxExecution9Len / clsNesting.ParNest.ProgramSettings.Layer9Speed + (double) sheetNested.ApproxExecution9UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
              if (sheetNested.ApproxExecution0TimeSec > 0.0 | sheetNested.ApproxExecution1TimeSec > 0.0 | sheetNested.ApproxExecution2TimeSec > 0.0 | sheetNested.ApproxExecution3TimeSec > 0.0 | sheetNested.ApproxExecution4TimeSec > 0.0 | sheetNested.ApproxExecution5TimeSec > 0.0 | sheetNested.ApproxExecution6TimeSec > 0.0 | sheetNested.ApproxExecution7TimeSec > 0.0 | sheetNested.ApproxExecution8TimeSec > 0.0 | sheetNested.ApproxExecution9TimeSec > 0.0)
                sheetNested.ApproxExecutionTimeSec = sheetNested.ApproxExecution0TimeSec + sheetNested.ApproxExecution1TimeSec + sheetNested.ApproxExecution2TimeSec + sheetNested.ApproxExecution3TimeSec + sheetNested.ApproxExecution4TimeSec + sheetNested.ApproxExecution5TimeSec + sheetNested.ApproxExecution6TimeSec + sheetNested.ApproxExecution7TimeSec + sheetNested.ApproxExecution8TimeSec + sheetNested.ApproxExecution9TimeSec;
              Point3D pntMin = new Point3D();
              Point3D pntMax = new Point3D();
              clsInit.cNesting.NestedPartsBoxAreaFromNestedSheet(sheetNested, ref pntMin, ref pntMax);
              sheetNested.SheetMaxXPosition = pntMax.X;
              sheetNested.SheetMaxYPosition = pntMax.Y;
              if (clsNesting.ParNest.ResultSettings.RemnantCalculate)
              {
                double num3 = sheetNested.MaterialWidth - pntMax.X - clsNesting.ParNest.ResultSettings.RemnantSizeOffset;
                double num4 = sheetNested.MaterialHeight - pntMax.Y - clsNesting.ParNest.ResultSettings.RemnantSizeOffset;
                if (num3 > num4)
                {
                  if (num3 > clsNesting.ParNest.ResultSettings.RemnantMinLength)
                  {
                    Rectangle2D rectangle2D1 = new Rectangle2D(new Point3D(Math.Round(pntMax.X + clsNesting.ParNest.ResultSettings.RemnantSizeOffset, 5), 0.0), Math.Round(num3, 5), sheetNested.MaterialHeight);
                    sheetNested.RemnantSheets.Add(rectangle2D1);
                    if (num4 > clsNesting.ParNest.ResultSettings.RemnantMinLength)
                    {
                      Rectangle2D rectangle2D2 = new Rectangle2D(new Point3D(0.0, Math.Round(pntMax.Y + clsNesting.ParNest.ResultSettings.RemnantSizeOffset, 5)), Math.Round(pntMax.X, 5), Math.Round(num4, 5));
                      sheetNested.RemnantSheets.Add(rectangle2D2);
                    }
                  }
                }
                else if (num4 > clsNesting.ParNest.ResultSettings.RemnantMinLength)
                {
                  Rectangle2D rectangle2D3 = new Rectangle2D(new Point3D(0.0, Math.Round(pntMax.Y + clsNesting.ParNest.ResultSettings.RemnantSizeOffset, 5)), Math.Round(pntMax.X, 5), Math.Round(num4, 5));
                  sheetNested.RemnantSheets.Add(rectangle2D3);
                  if (num3 > clsNesting.ParNest.ResultSettings.RemnantMinLength)
                  {
                    Rectangle2D rectangle2D4 = new Rectangle2D(new Point3D(Math.Round(pntMax.X + clsNesting.ParNest.ResultSettings.RemnantSizeOffset, 5), 0.0), Math.Round(num3, 5), pntMax.Y);
                    sheetNested.RemnantSheets.Add(rectangle2D4);
                  }
                }
              }
              clsInit.cNesting.SheeatArea(sheetNested, clsNesting.ParNest.ProgramSettings.UnitArea, ref sheetNested.MaterialArea);
              if (sheetNested.Type == nestMaterialType.Rectangle)
              {
                sheetNested.MaterialArea = sheetNested.MaterialHeight * sheetNested.MaterialWidth;
                sheetNested.MaterialAreaFromMaxX = sheetNested.MaterialHeight * sheetNested.SheetMaxXPosition;
                double UnitRatio = 1.0;
                clsInit.cVector5.AreaUnitRatioFromMM(clsNesting.ParNest.ProgramSettings.UnitArea, ref UnitRatio);
                sheetNested.MaterialArea /= UnitRatio;
                sheetNested.MaterialAreaFromMaxX /= UnitRatio;
              }
              sheetNested.UsingPersentage = sheetNested.NestedArea / sheetNested.MaterialArea * 100.0;
              sheetNested.UsingPersentageFromMaxX = sheetNested.NestedArea / sheetNested.MaterialAreaFromMaxX * 100.0;
              Result.NestedResultSheets.Add(sheetNested);
            }
          }
          else
            clsPowerNest.ErrorList.Add("Error Sheet Result  - " + errorCode.ToString());
        }
        Result.Parameters = new buNestingVar(clsNesting.ParNest);
        Result.OrderedTotalPartCount = count;
        Result.NestedTotalPartCount = num1;
        Result.PartGap = clsNesting.ParNest.PartSettings.PartsSpace;
        Result.ExecutionDate = DateTime.Now;
        Result.ExecutionTime = (double) clsNesting.ParNest.Runtime.MaxNestingTimeSec;
        if (Result.NestedResultSheets.Count == 1)
        {
          Result.MaxXPosition = Result.NestedResultSheets[0].SheetMaxXPosition;
          Result.MaxYPosition = Result.NestedResultSheets[0].SheetMaxYPosition;
        }
        if (num1 < count)
          Result.NotNestedAll = true;
      }
      else
        clsPowerNest.ErrorList.Add("GetMultiResultInfos  - " + multiResultInfos.ToString());
    }
    Result.JobExplanation = clsNesting.ParNest.Runtime.NestingJobExplanation;
    Result.JobName = clsNesting.ParNest.Runtime.NestingJobName;
  }

  public void GetApproxLEngthBLayerName(ref buNestedSheet sheetNested, List<buEntity> refEntities)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    int num6 = 0;
    int num7 = 0;
    int num8 = 0;
    int num9 = 0;
    int num10 = 0;
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      if (refEntities[index].LayerName.Trim() == "0")
      {
        sheetNested.ApproxExecution0Len += refEntities[index].Length();
        ++num1;
      }
      if (refEntities[index].LayerName.Trim() == "1")
      {
        sheetNested.ApproxExecution1Len += refEntities[index].Length();
        ++num2;
      }
      if (refEntities[index].LayerName.Trim() == "2")
      {
        sheetNested.ApproxExecution2Len += refEntities[index].Length();
        ++num3;
      }
      if (refEntities[index].LayerName.Trim() == "3")
      {
        sheetNested.ApproxExecution3Len += refEntities[index].Length();
        ++num4;
      }
      if (refEntities[index].LayerName.Trim() == "4")
      {
        sheetNested.ApproxExecution4Len += refEntities[index].Length();
        ++num5;
      }
      if (refEntities[index].LayerName.Trim() == "5")
      {
        sheetNested.ApproxExecution5Len += refEntities[index].Length();
        ++num6;
      }
      if (refEntities[index].LayerName.Trim() == "6")
      {
        sheetNested.ApproxExecution6Len += refEntities[index].Length();
        ++num7;
      }
      if (refEntities[index].LayerName.Trim() == "7")
      {
        sheetNested.ApproxExecution7Len += refEntities[index].Length();
        ++num8;
      }
      if (refEntities[index].LayerName.Trim() == "8")
      {
        sheetNested.ApproxExecution8Len += refEntities[index].Length();
        ++num9;
      }
      if (refEntities[index].LayerName.Trim() == "9")
      {
        sheetNested.ApproxExecution9Len += refEntities[index].Length();
        ++num10;
      }
    }
    if (num1 > 0)
    {
      ++sheetNested.ApproxExecution0UpDownCnt;
      ++sheetNested.ApproxExecution0UpDownCnt;
    }
    if (num2 > 0)
    {
      ++sheetNested.ApproxExecution1UpDownCnt;
      ++sheetNested.ApproxExecution1UpDownCnt;
    }
    if (num3 > 0)
    {
      ++sheetNested.ApproxExecution2UpDownCnt;
      ++sheetNested.ApproxExecution2UpDownCnt;
    }
    if (num4 > 0)
    {
      ++sheetNested.ApproxExecution3UpDownCnt;
      ++sheetNested.ApproxExecution3UpDownCnt;
    }
    if (num5 > 0)
    {
      ++sheetNested.ApproxExecution4UpDownCnt;
      ++sheetNested.ApproxExecution4UpDownCnt;
    }
    if (num6 > 0)
    {
      ++sheetNested.ApproxExecution5UpDownCnt;
      ++sheetNested.ApproxExecution5UpDownCnt;
    }
    if (num7 > 0)
    {
      ++sheetNested.ApproxExecution6UpDownCnt;
      ++sheetNested.ApproxExecution6UpDownCnt;
    }
    if (num8 > 0)
    {
      ++sheetNested.ApproxExecution7UpDownCnt;
      ++sheetNested.ApproxExecution7UpDownCnt;
    }
    if (num9 > 0)
    {
      ++sheetNested.ApproxExecution8UpDownCnt;
      ++sheetNested.ApproxExecution8UpDownCnt;
    }
    if (num10 <= 0)
      return;
    ++sheetNested.ApproxExecution9UpDownCnt;
    ++sheetNested.ApproxExecution9UpDownCnt;
  }

  public bool Execute(double Time)
  {
    bool flag;
    if (this.ilist_2.Count == 0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoPartWillWeNested);
      flag = false;
    }
    else if (this.ilist_0.Count == 0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoMaterialWillBeUsedForNesting);
      flag = false;
    }
    else
    {
      if (clsNesting.ParNest.Settings.NestingThreadCalculationCount <= 0)
        clsNesting.ParNest.Settings.NestingThreadCalculationCount = 2;
      if (clsNesting.ParNest.Settings.NestingThreadCalculationCount > 4)
        clsNesting.ParNest.Settings.NestingThreadCalculationCount = 4;
      clsPowerNest.ExecutionCounter = 0;
      clsPowerNest.bStop = false;
      this.iuserData_0 = (IUserData) new MyUserData();
      this.iuserData_1 = (IUserData) new MyUserData();
      int num1 = (int) this.tempPowerNest.SetSessionOffcutSides(Side.Right, Side.Top);
      if (clsNesting.ParNest.Settings.UseCallBacks)
      {
        int num2 = (int) this.tempPowerNest.SetSessionMultiCallbacks(new StopNesting(Class5.smethod_113), this.iuserData_0, new MultiUpdateBest(Class5.smethod_84), this.iuserData_1);
      }
      int num3 = (int) this.tempPowerNest.SetSessionNbThreads(clsNesting.ParNest.Settings.NestingThreadCalculationCount);
      clsPowerNest.bExecuteDone = false;
      clsNesting.BestNestCount = 1;
      this.tempBetterNestedResult.Clear();
      clsPowerNest.storedNestedResult.Clear();
      this.double_0 = Time;
      this.dateTime_0 = DateTime.Now;
      if (clsNesting.ParNest.Settings.NestExecutionByThread)
      {
        this.timer_0.Interval = 100;
        this.timer_0.Tick += new EventHandler(this.Tick_Execute);
        this.timer_0.Start();
        clsPowerNest.threadExecute = new Thread(new ThreadStart(clsInit.appNestingPower.ThreadCalculationLoop));
        clsPowerNest.threadExecute.Start();
        clsPowerNest.bExecute = true;
      }
      else
      {
        this.multiResult_0 = this.tempPowerNest.MultiNest((IEnumerable<Sheet>) this.ilist_0, (IEnumerable<int>) this.ilist_4, (IEnumerable<PowerNest2Cs.Part>) this.ilist_2, Time);
        clsPowerNest.bStop = false;
        this.ExecuteEnd(this.multiResult_0);
      }
      flag = true;
    }
    return flag;
  }

  public void ExecuteEnd(MultiResult nestMultiResult)
  {
    if (clsPowerNest.threadExecute != null)
      clsPowerNest.threadExecute.Abort();
    this.DrawToMultiSvg(this.tempPowerNest, nestMultiResult, Path.Combine(AppPath.Base, "buNesting.svg"));
    clsPowerNest.storedNestedResult.Add(nestMultiResult);
    this.MultiResultToNestedResult(nestMultiResult, ref clsInit.appNesting.NestedResult);
    clsInit.appNesting.doAddToTempCalculatedNesting(clsInit.appNesting.NestedResult, true);
    clsItem.FrmNestOnlineCalc.btn_send.Enabled = true;
    clsItem.FrmNestOnlineCalc.btn_preview.Enabled = true;
    if (!clsVar.appModes_0.CutterMode.Enable)
      return;
    clsInit.appCutter.AddCutterThingsToNestingResult(ref clsInit.appNesting.NestedResult);
  }

  public void AddBetterResult()
  {
    for (int index1 = 0; index1 <= clsPowerNest.storedNestedResult.Count - 1; ++index1)
    {
      int nbSheets = 0;
      MultiResult multiResult = clsPowerNest.storedNestedResult[index1].DeepClone<MultiResult>();
      if (this.tempPowerNest.GetMultiResultInfos(multiResult, out nbSheets) == ErrorCode.OK)
      {
        clsInit.appNesting.NestedResult.NestedSheetCount = nbSheets;
        int num = 0;
        int count = this.ilist_3.Count;
        for (int multiIndex = 0; multiIndex < nbSheets; ++multiIndex)
        {
          int index2 = -1;
          Sheet sheet_result;
          Result result = this.tempPowerNest.GetResult(multiResult, multiIndex, out sheet_result);
          ErrorCode errorCode = this.tempPowerNest.GetErrorCode((PowerNest2Cs.Wrappable) result);
          if (errorCode == ErrorCode.OK)
          {
            for (int index3 = 0; index3 <= this.ilist_0.Count - 1; ++index3)
            {
              if ((PowerNest2Cs.Wrappable) sheet_result == (PowerNest2Cs.Wrappable) this.ilist_0[index3])
                index2 = index3;
            }
            if (index2 >= 0)
            {
              buNestedSheet Sheet = new buNestedSheet(this.ilist_1[index2]);
              for (int index4 = 0; index4 < this.ilist_2.Count; ++index4)
              {
                PowerNest2Cs.Point position;
                PowerNest2Cs.Orientation orientation;
                if (this.tempPowerNest.GetNestedPart(result, this.ilist_2.ElementAt<PowerNest2Cs.Part>(index4), out position, out orientation))
                {
                  buNestingPart buNestingPart = new buNestingPart(this.ilist_3[index4]);
                  buNestedPart Part = new buNestedPart();
                  try
                  {
                    Part.EntitiesGroup = new buEntitiesGroup(this.ilist_3[index4].EntitiesGroup);
                  }
                  catch (Exception ex)
                  {
                  }
                  Part.MovedDistance = new Vec3D(position.x, position.y);
                  Part.RotateValue = orientation.MinAngle;
                  if (orientation.HorizontalFlip == 1)
                  {
                    clsInit.cVector5.Mirror(new Point3D(), new Point3D(1.0, 0.0, 0.0), Plane.XY, ref Part.EntitiesGroup);
                    Part.RotateValue = -orientation.MinAngle;
                  }
                  clsInit.cVector5.Rotate(new Point3D(), Part.RotateValue, Vector3D.AxisZ, ref Part.EntitiesGroup);
                  clsInit.cVector5.Move(Part.MovedDistance.X, Part.MovedDistance.Y, 0.0, ref Part.EntitiesGroup);
                  int index5 = buNestingPart.ID % clsVar.ColorList.Count;
                  Part.Color = clsVar.ColorList[index5];
                  Part.Thickness = this.ilist_1[index2].MaterialData.Thickness + 1.0;
                  clsInit.cNesting.PartArea(Part, clsNesting.ParNest.ProgramSettings.UnitArea, clsNesting.ParNest.ResultSettings.PartAreaOnlyFromOutter, ref Part.PartArea);
                  Sheet.NestedArea += Part.PartArea;
                  Sheet.Parts.Add(Part);
                  ++num;
                }
              }
              Point3D pntMin = new Point3D();
              Point3D pntMax = new Point3D();
              clsInit.cNesting.NestedPartsBoxAreaFromNestedSheet(Sheet, ref pntMin, ref pntMax);
              Sheet.SheetMaxXPosition = pntMax.X;
              Sheet.SheetMaxYPosition = pntMax.Y;
              clsInit.cNesting.SheeatArea(Sheet, clsNesting.ParNest.ProgramSettings.UnitArea, ref Sheet.MaterialArea);
              if (Sheet.Type == nestMaterialType.Rectangle && multiIndex == nbSheets - 1)
              {
                Sheet.MaterialArea = Sheet.MaterialHeight * Sheet.MaterialWidth;
                Sheet.MaterialAreaFromMaxX = Sheet.MaterialHeight * Sheet.SheetMaxXPosition;
                double UnitRatio = 1.0;
                clsInit.cVector5.AreaUnitRatioFromMM(clsNesting.ParNest.ProgramSettings.UnitArea, ref UnitRatio);
                Sheet.MaterialArea /= UnitRatio;
                Sheet.MaterialAreaFromMaxX /= UnitRatio;
              }
              Sheet.UsingPersentage = Sheet.NestedArea / Sheet.MaterialArea * 100.0;
              Sheet.UsingPersentageFromMaxX = Sheet.NestedArea / Sheet.MaterialAreaFromMaxX * 100.0;
              clsInit.appNesting.NestedResult.NestedResultSheets.Add(Sheet);
            }
          }
          else
            clsPowerNest.ErrorList.Add("Error Sheet Result  - " + errorCode.ToString());
        }
        clsInit.appNesting.NestedResult.OrderedTotalPartCount = count;
        clsInit.appNesting.NestedResult.NestedTotalPartCount = num;
        clsInit.appNesting.NestedResult.PartGap = clsNesting.ParNest.PartSettings.PartsSpace;
        clsInit.appNesting.NestedResult.ExecutionDate = DateTime.Now;
        clsInit.appNesting.NestedResult.ExecutionTime = (double) clsNesting.ParNest.Runtime.MaxNestingTimeSec;
        if (clsInit.appNesting.NestedResult.NestedResultSheets.Count == 1)
        {
          clsInit.appNesting.NestedResult.MaxXPosition = clsInit.appNesting.NestedResult.NestedResultSheets[0].SheetMaxXPosition;
          clsInit.appNesting.NestedResult.MaxYPosition = clsInit.appNesting.NestedResult.NestedResultSheets[0].SheetMaxYPosition;
        }
        if (clsVar.appModes_0.CutterMode.Enable)
          clsInit.appCutter.AddCutterThingsToNestingResult(ref clsInit.appNesting.NestedResult);
        if (num < count)
          clsInit.appNesting.NestedResult.NotNestedAll = true;
      }
      clsInit.appNesting.NestedResult.JobExplanation = clsNesting.ParNest.Runtime.NestingJobExplanation;
      clsInit.appNesting.NestedResult.JobName = clsNesting.ParNest.Runtime.NestingJobName;
      this.tempBetterNestedResult.Add(clsInit.appNesting.NestedResult);
    }
  }

  public void Tick_Execute(object sender, EventArgs e)
  {
    TimeSpan timeSpan = DateTime.Now - this.dateTime_0;
    GC.KeepAlive((object) this.tempPowerNest);
    if (clsItem.FrmNestOnlineCalc != null && clsItem.FrmNestOnlineCalc.Visible)
    {
      if (!clsPowerNest.bExecuteDone)
      {
        clsItem.FrmNestOnlineCalc.lbl_status.Text = "Running";
        clsItem.FrmNestOnlineCalc.lbl_status.BackColor = Color.Lime;
      }
      else
      {
        clsItem.FrmNestOnlineCalc.lbl_status.Text = "Done";
        clsItem.FrmNestOnlineCalc.lbl_status.BackColor = Color.LightCoral;
      }
      if (this.tempBetterNestedResult.Count > 0)
        this.tempBetterNestedResult.RemoveAt(0);
      clsItem.FrmNestOnlineCalc.txt_bestcount.Text = this.int_0.ToString();
      clsItem.FrmNestOnlineCalc.txt_time.Text = $"{Convert.ToInt32(timeSpan.TotalSeconds).ToString()} / {clsNesting.ParNest.Runtime.MaxNestingTimeSec.ToString("f0")}";
      double totalSeconds = timeSpan.TotalSeconds;
      double num = 0.0;
      if (totalSeconds < 0.0)
        clsItem.FrmNestOnlineCalc.progress_execution.Value = 0;
      else if (totalSeconds >= 0.0 & totalSeconds <= (double) clsNesting.ParNest.Runtime.MaxNestingTimeSec)
      {
        num = totalSeconds / (double) clsNesting.ParNest.Runtime.MaxNestingTimeSec * 100.0;
        clsItem.FrmNestOnlineCalc.progress_execution.Value = (int) num;
      }
      else
      {
        num = 100.0;
        clsItem.FrmNestOnlineCalc.progress_execution.Value = 100;
      }
      clsItem.FrmNestOnlineCalc.lbl_persentage.Text = "%" + num.ToString("f1");
    }
    if (!clsPowerNest.bExecuteDone)
      return;
    clsItem.FrmNestOnlineCalc.progress_execution.Value = 100;
    clsItem.FrmNestOnlineCalc.lbl_persentage.Text = "%100.0";
    this.ExecuteEnd(this.multiResult_0.DeepClone<MultiResult>());
    clsPowerNest.bExecuteDone = false;
    this.timer_0.Tick -= new EventHandler(this.Tick_Execute);
    this.timer_0.Stop();
  }

  public void ThreadCalculationLoop()
  {
    try
    {
      while (true)
      {
        do
          ;
        while (!clsPowerNest.bExecute);
        GC.TryStartNoGCRegion((long) clsNesting.ParNest.Settings.GarbageCollectionDisableSize, true);
        this.multiResult_0 = this.tempPowerNest.MultiNest((IEnumerable<Sheet>) this.ilist_0, (IEnumerable<int>) this.ilist_4, (IEnumerable<PowerNest2Cs.Part>) this.ilist_2, this.double_0);
        GC.KeepAlive((object) this.iuserData_0);
        GC.KeepAlive((object) this.iuserData_1);
        clsPowerNest.bStop = false;
        clsPowerNest.bExecute = false;
        clsPowerNest.bExecuteDone = true;
        GC.EndNoGCRegion();
      }
    }
    catch (Exception ex)
    {
    }
  }
}
