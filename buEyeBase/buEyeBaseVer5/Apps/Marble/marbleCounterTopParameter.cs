// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCounterTopParameter
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.Marble;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCounterTopParameter : buSerilization5
{
  public Color colorSinkAngle;
  public Color colorSinkDimension;
  public Color colorSinkLoction;
  public Color colorBuiltInngle;
  public Color colorBuiltInDimension;
  public Color colorBuiltInLocation;

  public void FindItemsInsideMaterials(
    MaterialBase5 Mat,
    List<MarbleItem> Items,
    ref List<MarbleItem> FoundItems)
  {
    if (Mat == null)
      return;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      Point3D MinPoint = new Point3D(((SortOptions) Mat).BoxMinPoint.X - 0.5, ((SortOptions) Mat).BoxMinPoint.Y - 0.5, ((SortOptions) Mat).BoxMinPoint.Z);
      Point3D MaxPoint = new Point3D(((SortCamData) Mat).BoxMaxPoint.X + 0.5, ((SortCamData) Mat).BoxMaxPoint.Y + 0.5, ((SortCamData) Mat).BoxMaxPoint.Z);
      if (buCall.\u0001.IsPointInsideBoxsize(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Items[index]).SizeItem).MinPoint, MinPoint, MaxPoint, Plane.XY) & buCall.\u0001.IsPointInsideBoxsize(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Items[index]).SizeItem).MaxPoint, MinPoint, MaxPoint, Plane.XY))
        FoundItems.Add(Items[index]);
    }
  }

  public void GetMaterialListFromFiles(string Path, ref List<marbleMaterialType> MatList)
  {
    if (MatList == null)
      MatList = new List<marbleMaterialType>();
    MatList.Clear();
    List<string> stringList = new List<string>();
    List<string> Files = new List<string>();
    buFile.GetFilesInDirectory(AppPath.Materials, ".bumarblemats", ref Files);
    for (int index = 0; index <= Files.Count - 1; ++index)
    {
      marbleMaterialType marbleMaterialType = (marbleMaterialType) new \u0007.\u0001();
      ((MarbleMotionCommands) marbleMaterialType).Parameters = (marbleCamPars) new \u0007.\u0001();
      List<string> StringList = new List<string>();
      buVector5.OpenFromFile(Files[index], ref StringList);
      buSerilization5.Decode(StringList, "", (SerilizationMode5) 1, (object) ((MarbleMotionCommands) marbleMaterialType).Parameters);
      ((MarbleMotionCommands) marbleMaterialType).MaterialNames = buFile.getFileNameWithoutExtension(Files[index]);
      FileInfo fileInfo1 = new FileInfo($"{AppPath.Materials}\\{((MarbleMotionCommands) marbleMaterialType).MaterialNames}.jpg");
      if (fileInfo1.Exists)
      {
        ((MarbleMotionCommands) marbleMaterialType).Photo = Image.FromFile(fileInfo1.FullName);
      }
      else
      {
        FileInfo fileInfo2 = new FileInfo($"{AppPath.Materials}\\{((MarbleMotionCommands) marbleMaterialType).MaterialNames}.png");
        if (fileInfo2.Exists)
        {
          ((MarbleMotionCommands) marbleMaterialType).Photo = Image.FromFile(fileInfo2.FullName);
        }
        else
        {
          FileInfo fileInfo3 = new FileInfo($"{AppPath.Materials}\\{((MarbleMotionCommands) marbleMaterialType).MaterialNames}.bmp");
          if (fileInfo3.Exists)
            ((MarbleMotionCommands) marbleMaterialType).Photo = Image.FromFile(fileInfo3.FullName);
        }
      }
      MatList.Add(marbleMaterialType);
    }
  }

  public void ShowMaterialPage()
  {
    if (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList == null)
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList = (F_MarbleMaterialList) new F_MarbleSawCornerClean();
    ((F_MarbleSawMillingCam) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList).Settings = (marbleCamPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam);
    ((F_MarbleSawMillingCam) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    ((F_MarbleSawMillingCam) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList).PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
    ((F_MarbleSawMillingRough) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList).Init();
    int num = (int) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList.ShowDialog();
    if (((F_MarbleSawMillingCam) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList).PropertiesForm.Result != DialogResult.OK)
      return;
    ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam = (marbleCamPars) new \u0007.\u0001(((F_MarbleSawMillingCam) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.frmMaterialList).Settings);
  }

  public void GetMaterialBorderLimits(MarbleJob Job, ToolBase5 ToolSaw)
  {
    double x1 = 0.0;
    double y1 = 0.0;
    double num1 = 0.0;
    double baseWoodHeight = ((marbleProfileCutPars) MarbleRuntimeSettings.varMarbleMachineSettings).BaseWoodHeight;
    double y2 = ((marbleProfileCutPars) MarbleRuntimeSettings.varMarbleMachineSettings).BaseWoodHeight;
    if (((SortAskMe) ((MarbleProgramSettings) Job).Material).Enable)
    {
      Math.Round(((SortResult) ((MarbleProgramSettings) Job).Material).Size.Width, 3);
      double num2 = Math.Round(((SortResult) ((MarbleProgramSettings) Job).Material).Size.Height, 3);
      x1 = Math.Round(((SortOptions) ((MarbleProgramSettings) Job).Material).BoxMinPoint.X, 3);
      y1 = Math.Round(((SortOptions) ((MarbleProgramSettings) Job).Material).BoxMinPoint.Y, 3);
      y2 = y1 + num2;
    }
    List<Point3D> point3DList = new List<Point3D>();
    MarbleDrawingSetting.MaterialLimits.Clear();
    if (((MarbleProgramSettings) Job).Items.Count == 0)
    {
      MarbleDrawingSetting.MaterialLimits.Add(new Point3D());
      MarbleDrawingSetting.MaterialLimits.Add(new Point3D(0.0, y2, 0.0));
    }
    else
    {
      List<Pnt6D> pnt6DList = new List<Pnt6D>();
      for (int index1 = 0; index1 <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index1)
      {
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        double x2 = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MinPoint.X + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index1]).OffsetX;
        double y3 = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MinPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index1]).OffsetY;
        double x3 = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MaxPoint.X + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index1]).OffsetX;
        double y4 = ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MaxPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index1]).OffsetY;
        for (int index2 = 0; index2 <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index2)
        {
          if (index1 != index2)
          {
            flag1 |= buFile5.IsValueInsideMinMaxValues(y3, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index2]).SizeItem).MinPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index2]).OffsetY, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index2]).SizeItem).MaxPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index2]).OffsetY);
            flag2 |= buFile5.IsValueInsideMinMaxValues(y4, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index2]).SizeItem).MinPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index2]).OffsetY, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index2]).SizeItem).MaxPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index2]).OffsetY);
            if (flag1 | flag2 && x2 > ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index2]).SizeItem).MaxPoint.X + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index2]).OffsetX)
              flag3 = true;
          }
        }
        if (flag1)
        {
          if (flag3)
            pnt6DList.Add(new Pnt6D(x2, y3, (double) index1, -1.0, 0.0, 0.0));
        }
        else
          pnt6DList.Add(new Pnt6D(x2, y3, (double) index1, -1.0, 0.0, 0.0));
        if (flag2)
        {
          if (flag3)
            pnt6DList.Add(new Pnt6D(x3, y4, (double) index1, 1.0, 0.0, 0.0));
        }
        else
          pnt6DList.Add(new Pnt6D(x3, y4, (double) index1, 1.0, 0.0, 0.0));
      }
      buCall.\u0001.SortDeltaY(new Point3D(-100.0, 100.0, 0.0), SortDirectionType.Lower, ref pnt6DList);
      ((F_CutterOffsetEntities) buCall.\u0001).CheckDuplicatedPointAxesWithPrevious(ref pnt6DList, AxesXYZ.Y);
      if (pnt6DList.Count == 0)
        return;
      for (int index3 = 0; index3 <= pnt6DList.Count - 1; ++index3)
      {
        double num3 = -10000000.0;
        num1 = 0.0;
        for (int index4 = 0; index4 <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index4)
        {
          Point3D FirstPoint = new Point3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index4]).SizeItem).MinPoint.X + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index4]).OffsetX, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index4]).SizeItem).MinPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index4]).OffsetY, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index4]).SizeItem).MinPoint.Z);
          Point3D SecondPoint = new Point3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index4]).SizeItem).MaxPoint.X + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index4]).OffsetX, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index4]).SizeItem).MaxPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index4]).OffsetY, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index4]).SizeItem).MaxPoint.Z);
          Entity entRectangle = (Entity) null;
          Entity entity = (Entity) new Line(new Point3D(0.0, pnt6DList[index3].Y), new Point3D(100000.0, pnt6DList[index3].Y));
          buCall.\u0001.Rectangle2Point(FirstPoint, SecondPoint, Plane.XY, ref entRectangle);
          Point3D[] point3DArray = ((ICurve) entity).IntersectWith((ICurve) entRectangle);
          if ((point3DArray == null ? 0 : (point3DArray.Length != 0 ? 1 : 0)) != 0)
          {
            for (int index5 = 0; index5 <= point3DArray.Length - 1; ++index5)
            {
              if (point3DArray[index5].X > num3)
                num3 = point3DArray[index5].X;
            }
          }
        }
        double num4 = pnt6DList[index3].A * ((ToolDisplay5) ((ToolGeometry5) ToolSaw).Geometry).Thickness;
        point3DList.Add(new Point3D(num3 + ((ToolDisplay5) ((ToolGeometry5) ToolSaw).Geometry).Thickness, pnt6DList[index3].Y + num4, pnt6DList[index3].Z));
      }
      if (point3DList.Count <= 0)
        return;
      if (point3DList[0].Y < ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).EdgeBorderGap)
      {
        Point3D point3D = F_NotchEdit.ToPoint3D(point3DList[0]);
        point3D.Y = y1;
        MarbleDrawingSetting.MaterialLimits.Add(point3D);
      }
      else
      {
        MarbleDrawingSetting.MaterialLimits.Add(new Point3D(x1, y1));
        point3DList[0].Y -= ((ToolDisplay5) ((ToolGeometry5) ToolSaw).Geometry).Thickness;
        Point3D point3D = F_NotchEdit.ToPoint3D(point3DList[0]);
        point3D.X = x1;
        MarbleDrawingSetting.MaterialLimits.Add(point3D);
      }
      for (int index = 0; index <= point3DList.Count - 1; ++index)
      {
        double num5 = 0.0;
        double num6 = 0.0;
        if (index > 0)
        {
          double num7 = point3DList[index].Y - point3DList[index - 1].Y;
          double num8 = point3DList[index].X - point3DList[index - 1].X;
          if (Math.Abs(point3DList[index].Z - point3DList[index - 1].Z) > 0.0)
          {
            if (num7 > ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).PartAndPartBorderDistance)
            {
              Point3D pntMin = new Point3D(-100.0, (point3DList[index].Y + point3DList[index - 1].Y) / 2.0, 0.0);
              Point3D pntMax = new Point3D(100000.0, (point3DList[index].Y + point3DList[index - 1].Y) / 2.0, 0.0);
              double MinX = 0.0;
              double MaxX = 0.0;
              if (!((marbleCounterTopPars) this).MarbleItemIntersectionWithLine(Job, pntMin, pntMax, ref MinX, ref MaxX))
                MaxX = x1;
              else
                MaxX += ((ToolDisplay5) ((ToolGeometry5) ToolSaw).Geometry).Thickness;
              Point3D point3D1 = F_NotchEdit.ToPoint3D(MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1]);
              point3D1.X = MaxX;
              MarbleDrawingSetting.MaterialLimits.Add(point3D1);
              Point3D point3D2 = F_NotchEdit.ToPoint3D(point3DList[index]);
              point3D2.X = MaxX;
              point3D2.Y -= ((ToolDisplay5) ((ToolGeometry5) ToolSaw).Geometry).Thickness;
              MarbleDrawingSetting.MaterialLimits.Add(point3D2);
            }
            else if (MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1].X < point3DList[index].X)
            {
              MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1].Y = point3DList[index].Y;
              Point3D point3D = F_NotchEdit.ToPoint3D(MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1]);
              point3D.X = point3DList[index].X;
              MarbleDrawingSetting.MaterialLimits.Add(point3D);
            }
            else
            {
              MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1].Y += ((ToolDisplay5) ((ToolGeometry5) ToolSaw).Geometry).Thickness;
              Point3D point3D = F_NotchEdit.ToPoint3D(MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1]);
              point3D.X = point3DList[index].X;
              MarbleDrawingSetting.MaterialLimits.Add(point3D);
            }
          }
        }
        MarbleDrawingSetting.MaterialLimits.Add(new Point3D(point3DList[index].X + num5, point3DList[index].Y + num6, 0.0));
      }
      if (y2 - MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1].Y < ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).EdgeBorderGap)
      {
        Point3D point3D = F_NotchEdit.ToPoint3D(MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1]);
        point3D.Y = y2;
        MarbleDrawingSetting.MaterialLimits.Add(point3D);
      }
      else
      {
        Point3D point3D3 = F_NotchEdit.ToPoint3D(MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1]);
        point3D3.X = x1;
        MarbleDrawingSetting.MaterialLimits.Add(point3D3);
        Point3D point3D4 = F_NotchEdit.ToPoint3D(MarbleDrawingSetting.MaterialLimits[MarbleDrawingSetting.MaterialLimits.Count - 1]);
        point3D4.Y = y2;
        MarbleDrawingSetting.MaterialLimits.Add(point3D4);
      }
    }
  }
}
