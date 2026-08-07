// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FindToolSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class FindToolSettings
{
  public int NumberNextVerticalItem;
  public ClockDirectionType ClockDir;
  public ToolBase5 ToolMilling;
  public static byte f003F90;
  public Point3D DrillPosition;
  public double XPosition;
  public double X1Clamper;
  public double X2Clamper;

  public static void Decode(ArrayList AL, ref FoamItem Item)
  {
    Item = (FoamItem) new DrillRuntimeSettings();
    buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) Item);
    List<List<string>> CalcList1 = new List<List<string>>();
    List<string> CalcList2 = new List<string>();
    List<string> CalcList3 = new List<string>();
    List<string> CalcList4 = new List<string>();
    List<List<string>> CalcList5 = new List<List<string>>();
    List<List<string>> CalcList6 = new List<List<string>>();
    buStatics.ListToSpecificList("<BlocksXZ>", "</BlocksXZ>", false, AL, ref CalcList3);
    buStatics.ListToSpecificList("<BlocksYZ>", "</BlocksYZ>", false, AL, ref CalcList4);
    buStatics.ListToSpecificList("<FoamBlock>", "</FoamBlock>", true, CalcList3, ref CalcList5);
    buStatics.ListToSpecificList("<FoamBlock>", "</FoamBlock>", true, CalcList4, ref CalcList6);
    for (int index = 0; index <= CalcList5.Count - 1; ++index)
    {
      FoamBlock foamBlock = (FoamBlock) new DrillUpdateArg();
      ClamperInsideCalc.Decode(CalcList5[index], ref foamBlock);
      ((DrillCalcItem) Item).BlockXZ.Add(foamBlock);
    }
    for (int index = 0; index <= CalcList6.Count - 1; ++index)
    {
      FoamBlock foamBlock = (FoamBlock) new DrillUpdateArg();
      ClamperInsideCalc.Decode(CalcList6[index], ref foamBlock);
      ((DrillCalcItem) Item).BlockYZ.Add(foamBlock);
    }
    CalcList2.Clear();
    CalcList1.Clear();
    buStatics.ListToSpecificList("<sortedEntitiesXZ>", "</sortedEntitiesXZ>", false, AL, ref CalcList2);
    buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList2, ref CalcList1);
    for (int index = 0; index <= CalcList1.Count - 1; ++index)
    {
      buEntity buEntity = buText.Decode(CalcList1[index]);
      if (buEntity != null)
        ((DrillCalcItem) Item).sortedEntitiesXZ.Add(buEntity);
    }
    CalcList2.Clear();
    CalcList1.Clear();
    buStatics.ListToSpecificList("<sortedEntitiesYZ>", "</sortedEntitiesYZ>", false, AL, ref CalcList2);
    buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList2, ref CalcList1);
    for (int index = 0; index <= CalcList1.Count - 1; ++index)
    {
      buEntity buEntity = buText.Decode(CalcList1[index]);
      if (buEntity != null)
        ((DrillCalcItem) Item).sortedEntitiesYZ.Add(buEntity);
    }
    CalcList2.Clear();
    CalcList3.Clear();
    CalcList4.Clear();
    CalcList5.Clear();
    CalcList6.Clear();
    AL.Clear();
    CalcList1.Clear();
  }

  public override string ToString() => ((DrillCalcItem) this).ItemName.ToString();
}
