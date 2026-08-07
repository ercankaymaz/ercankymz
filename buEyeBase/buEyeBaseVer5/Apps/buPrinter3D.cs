// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buPrinter3D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buPrinter3D
{
  public List<Entity> OutsideCenterEntities;
  public bool DrillDiameterError;
  public double XScaleFactor;
  public double YScaleFactor;
  public bool NotchOnContour;
  public List<List<Entity>> Entities;
  public int SimStep;

  public bool WriteIsoFile(
    string FileName,
    int Index,
    CutterIsoFileSettings Settings,
    buNestedResult NestResult,
    CutterProgramSettings ProgramSettings,
    ref List<List<Entity>> DrawEntities)
  {
    bool flag1 = false;
    List<string> stringList = new List<string>();
    DrawEntities.Clear();
    DrawEntities = new List<List<Entity>>();
    string str1 = "H1*" + "ZX984251*D2*M15*";
    bool flag2;
    if (Index >= 0 & Index <= ((ProfileOperationData) NestResult).NestedResultSheets.Count - 1)
    {
      int num;
      for (int index1 = 0; index1 <= ((ProfileOperationDataNotch) ((ProfileOperationData) NestResult).NestedResultSheets[Index]).Parts.Count - 1; ++index1)
      {
        string str2 = str1;
        num = index1 + 1;
        string str3 = num.ToString();
        str1 = $"{str2}N{str3}*";
        List<Entity> entityList = new List<Entity>();
        List<List<Entity>> entityListList1 = new List<List<Entity>>();
        List<List<Entity>> entityListList2 = new List<List<Entity>>();
        CutterIsoEntities Entities = (CutterIsoEntities) new buPrinter3D();
        List<List<Entity>> calcEntities = new List<List<Entity>>();
        CutterIsoError Error = (CutterIsoError) new Printer3DJob();
        ((ProfileBase) buCall.\u0001).NestedPartToCutterEntity(((ProfileOperationDataNotch) ((ProfileOperationData) NestResult).NestedResultSheets[Index]).Parts[index1], ((Printer3DSettings) ProgramSettings).DrillMainDaimeterValue, ((Printer3DSettings) ProgramSettings).DrillAuxDaimeterValue, ref Entities, ref Error);
        if (!((buPrinter3D) Error).DrillDiameterError)
        {
          if (((buPrinter3D) Settings).NotchOnContour)
            ((WoodRuntimeSettings) this).SetNotchOnContour(((WoodItemType) Entities).NotchCenterEntities, ((buPrinter3D) Entities).OutsideCenterEntities, true, true, ref calcEntities);
          else
            calcEntities.Add(((buPrinter3D) Entities).OutsideCenterEntities);
          buVector5.AddEntities(calcEntities, ref DrawEntities);
          if (((WoodItemType) Entities).InnerCenterEntities.Count > 0)
          {
            for (int index2 = 0; index2 <= ((WoodItemType) Entities).InnerCenterEntities.Count - 1; ++index2)
            {
              List<Point3D> Points = new List<Point3D>();
              buCall.\u0001.EntitiesToPointsWithCamDirection(((WoodItemType) Entities).InnerCenterEntities[index2], buSystem.RegenDeviation, ref Points);
              if (Points.Count > 1)
              {
                string[] strArray1 = new string[6]
                {
                  str1 + "D2*M15*",
                  "X",
                  null,
                  null,
                  null,
                  null
                };
                num = Convert.ToInt32(Points[0].X / ((buPrinter3D) Settings).XScaleFactor);
                strArray1[2] = num.ToString();
                strArray1[3] = "Y";
                num = Convert.ToInt32(Points[0].Y / ((buPrinter3D) Settings).YScaleFactor);
                strArray1[4] = num.ToString();
                strArray1[5] = "*";
                string str4 = string.Concat(strArray1) + "M14*";
                for (int index3 = 1; index3 <= Points.Count - 1; ++index3)
                {
                  string[] strArray2 = new string[6]
                  {
                    str4,
                    "X",
                    null,
                    null,
                    null,
                    null
                  };
                  num = Convert.ToInt32(Points[index3].X / ((buPrinter3D) Settings).XScaleFactor);
                  strArray2[2] = num.ToString();
                  strArray2[3] = "Y";
                  num = Convert.ToInt32(Points[index3].Y / ((buPrinter3D) Settings).YScaleFactor);
                  strArray2[4] = num.ToString();
                  strArray2[5] = "*";
                  str4 = string.Concat(strArray2);
                }
                str1 = str4 + "D2*M15*";
                flag1 = true;
              }
            }
          }
          if (((WoodItemType) Entities).DrillMainEntities.Count > 0)
          {
            if (!flag1)
              str1 += "D2*M15*";
            for (int index4 = 0; index4 <= ((WoodItemType) Entities).DrillMainEntities.Count - 1; ++index4)
            {
              if (((WoodItemType) Entities).DrillMainEntities[index4] is Circle)
              {
                Circle drillMainEntity = ((WoodItemType) Entities).DrillMainEntities[index4] as Circle;
                string[] strArray = new string[6]
                {
                  str1,
                  "X",
                  null,
                  null,
                  null,
                  null
                };
                num = Convert.ToInt32(drillMainEntity.Center.X / ((buPrinter3D) Settings).XScaleFactor);
                strArray[2] = num.ToString();
                strArray[3] = "Y";
                num = Convert.ToInt32(drillMainEntity.Center.Y / ((buPrinter3D) Settings).YScaleFactor);
                strArray[4] = num.ToString();
                strArray[5] = "M43*";
                str1 = string.Concat(strArray) + "D2*M15*";
                flag1 = true;
              }
            }
          }
          if (((WoodItemType) Entities).DrillAuxEntities.Count > 0)
          {
            if (!flag1)
              str1 += "D2*M15*";
            for (int index5 = 0; index5 <= ((WoodItemType) Entities).DrillAuxEntities.Count - 1; ++index5)
            {
              if (((WoodItemType) Entities).DrillMainEntities[index5] is Circle)
              {
                Circle drillAuxEntity = ((WoodItemType) Entities).DrillAuxEntities[index5] as Circle;
                string[] strArray = new string[6]
                {
                  str1,
                  "X",
                  null,
                  null,
                  null,
                  null
                };
                num = Convert.ToInt32(drillAuxEntity.Center.X / ((buPrinter3D) Settings).XScaleFactor);
                strArray[2] = num.ToString();
                strArray[3] = "Y";
                num = Convert.ToInt32(drillAuxEntity.Center.Y / ((buPrinter3D) Settings).YScaleFactor);
                strArray[4] = num.ToString();
                strArray[5] = "M44*";
                str1 = string.Concat(strArray);
              }
            }
            str1 += "D2*M15*";
            flag1 = true;
          }
          if (calcEntities.Count > 0)
          {
            if (!flag1)
              str1 += "D2*M15*";
            for (int index6 = 0; index6 <= calcEntities.Count - 1; ++index6)
            {
              List<Point3D> Points = new List<Point3D>();
              buCall.\u0001.EntitiesToPointsWithCamDirection(calcEntities[index6], buSystem.RegenDeviation, ref Points);
              if (Points.Count > 1)
              {
                string[] strArray3 = new string[6]
                {
                  str1,
                  "X",
                  null,
                  null,
                  null,
                  null
                };
                num = Convert.ToInt32(Points[0].X / ((buPrinter3D) Settings).XScaleFactor);
                strArray3[2] = num.ToString();
                strArray3[3] = "Y";
                num = Convert.ToInt32(Points[0].Y / ((buPrinter3D) Settings).YScaleFactor);
                strArray3[4] = num.ToString();
                strArray3[5] = "*";
                string str5 = string.Concat(strArray3) + "M14*";
                for (int index7 = 1; index7 <= Points.Count - 1; ++index7)
                {
                  if (index7 == Points.Count - 1 & index6 < calcEntities.Count - 1)
                    str5 += "M14*";
                  string[] strArray4 = new string[6]
                  {
                    str5,
                    "X",
                    null,
                    null,
                    null,
                    null
                  };
                  num = Convert.ToInt32(Points[index7].X / ((buPrinter3D) Settings).XScaleFactor);
                  strArray4[2] = num.ToString();
                  strArray4[3] = "Y";
                  num = Convert.ToInt32(Points[index7].Y / ((buPrinter3D) Settings).YScaleFactor);
                  strArray4[4] = num.ToString();
                  strArray4[5] = "*";
                  str5 = string.Concat(strArray4);
                }
                str1 = str5 + "D2*M15*";
                flag1 = true;
              }
            }
          }
        }
        else
        {
          buNumeric5.MessageBoxError(WoodItemType.LangCutterMessage[0]);
          flag2 = false;
          goto label_54;
        }
      }
      if (!flag1)
        str1 += "D2*M15*";
      string str6 = str1;
      num = Convert.ToInt32(((ProfileOperationDataNotch) ((ProfileOperationData) NestResult).NestedResultSheets[Index]).SheetMaxXPosition / ((buPrinter3D) Settings).XScaleFactor);
      string str7 = num.ToString();
      str1 = $"{str6}QX{str7}Y0*";
    }
    string String = str1 + "M0**";
    if (String.Length > 0)
      buVector5.SaveToFile(String, FileName);
    flag2 = true;
label_54:
    return flag2;
  }

  public abstract void m001A7E();

  public buPrinter3D()
  {
    ((WoodItemType) this).InnerCenterEntities = new List<List<Entity>>();
    ((WoodItemType) this).DirectionCenterEntities = new List<List<Entity>>();
    ((WoodItemType) this).InnerPlotterCenterEntities = new List<List<Entity>>();
    ((WoodItemType) this).InnerPlotterAuxCenterEntities = new List<List<Entity>>();
    ((WoodItemType) this).TextCenterEntities = new List<Entity>();
    ((WoodItemType) this).NotchCenterEntities = new List<Entity>();
    ((WoodItemType) this).DrillMainEntities = new List<Entity>();
    ((WoodItemType) this).DrillAuxEntities = new List<Entity>();
    this.OutsideCenterEntities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }
}
