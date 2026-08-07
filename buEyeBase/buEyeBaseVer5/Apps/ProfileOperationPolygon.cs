// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationPolygon
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationPolygon : ProfileOperation
{
  public static byte f0042AD;
  public new double Thickness;
  public double Cost;

  public static void Decode(ArrayList AL, ref List<buNestingMaterials> Mats)
  {
    List<List<string>> stringListList = new List<List<string>>();
    Mats.Clear();
    Mats = new List<buNestingMaterials>();
    List<List<string>> CalcList = new List<List<string>>();
    buStatics.ListToSpecificList("<nestingMaterials>", "</nestingMaterials>", true, AL, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      ArrayList AL1 = new ArrayList();
      AL1.AddRange((ICollection) CalcList[index].ToArray());
      buNestingMaterials nestingMaterials = (buNestingMaterials) new ProfileOperationNotchOld();
      buSerilization5.Decode(AL1, "", (SerilizationMode5) 1, (object) nestingMaterials);
      Mats.Add(nestingMaterials);
    }
  }

  static ProfileOperationPolygon() => ProfileOperationData.Captions = new List<string>();

  public ProfileOperationPolygon()
  {
    ((ProfileOperationData) this).JobName = "";
    ((ProfileOperationData) this).JobColor = "";
    ((ProfileOperationData) this).JobExplanation = "";
    ((ProfileOperationData) this).ExecutionTime = 0.0;
    ((ProfileOperationData) this).PastalWidth = 0.0;
    ((ProfileOperationData) this).MaxXPosition = 0.0;
    ((ProfileOperationData) this).MaxYPosition = 0.0;
    ((ProfileOperationData) this).PartGap = 0.0;
    ((ProfileOperationData) this).ExecutionDate = new DateTime();
    ((ProfileOperationData) this).Licanse = 1;
    ((ProfileOperationData) this).NestedSheetCount = 0;
    ((ProfileOperationData) this).OrderedTotalPartCount = 0;
    ((ProfileOperationData) this).NestedTotalPartCount = 0;
    ((ProfileOperationData) this).TotalUsingPersentage = 0.0;
    ((ProfileOperationData) this).NotNestedAll = false;
    ((ProfileOperationData) this).ItemNo = "";
    ((ProfileOperationData) this).SalesNo = "";
    ((ProfileOperationData) this).Other = "";
    ((ProfileOperationData) this).Aux = "";
    ((ProfileOperationData) this).UserData = 0.0;
    ((ProfileOperationData) this).Parameters = (buNestingVar) new ProfileOperationDataBarel();
    ((ProfileOperationData) this).NestedResultSheets = new List<buNestedSheet>();
    ((ProfileOperationData) this).NestingPartsList = new List<buNestingPart>();
    ((ProfileOperationData) this).NestingSheetList = new List<buNestingSheet>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
