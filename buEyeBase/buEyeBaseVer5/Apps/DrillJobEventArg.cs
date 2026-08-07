// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillJobEventArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class DrillJobEventArg
{
  public drillPlaneNames Plane;

  public static void Decode(List<string> AL, ref FoamPattern Item)
  {
    Item = (FoamPattern) new DrillJobCreateEventHandler();
    buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) Item);
    List<List<string>> CalcList1 = new List<List<string>>();
    List<string> CalcList2 = new List<string>();
    buStatics.ListToSpecificList("<sortEntities>", "</sortEntities>", false, AL, ref CalcList2);
    buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList2, ref CalcList1);
    for (int index = 0; index <= CalcList1.Count - 1; ++index)
    {
      buEntity buEntity = buText.Decode(CalcList1[index]);
      if (buEntity != null)
        ((DrillItem) Item).sortEntities.Add(buEntity);
    }
    List<string> CalcList3 = new List<string>();
    List<List<string>> CalcList4 = new List<List<string>>();
    buStatics.ListToSpecificList("<foamEntitiesAll>", "</foamEntitiesAll>", false, AL, ref CalcList3);
    buStatics.ListToSpecificList("<foamEntities>", "</foamEntities>", false, CalcList3, ref CalcList4);
    for (int index1 = 0; index1 <= CalcList4.Count - 1; ++index1)
    {
      FoamEntities foamEntities = (FoamEntities) new buTuftingCalc();
      List<List<string>> stringListList = new List<List<string>>();
      CalcList3.Clear();
      CalcList1.Clear();
      buStatics.ListToSpecificList("<foamEntitiesOutsideEntities>", "</foamEntitiesOutsideEntities>", false, CalcList4[index1], ref CalcList3);
      buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList3, ref CalcList1);
      for (int index2 = 0; index2 <= CalcList1.Count - 1; ++index2)
      {
        buEntity buEntity = buText.Decode(CalcList1[index2]);
        if (buEntity != null)
          ((\u0084.\u0001) ((DrillItem) foamEntities).GroupEntity.Outside).Entities.Add(buEntity);
      }
      CalcList3.Clear();
      buStatics.ListToSpecificList("<foamEntitiesInsideEntitiesItem>", "</foamEntitiesInsideEntitiesItem>", false, CalcList4[index1], ref CalcList3);
      for (int index3 = 0; index3 <= stringListList.Count - 1; ++index3)
      {
        CalcList1.Clear();
        CalcList1 = new List<List<string>>();
        buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, stringListList[index3], ref CalcList1);
        List<buEntity> buEntityList = new List<buEntity>();
        for (int index4 = 0; index4 <= CalcList1.Count - 1; ++index4)
        {
          buEntity buEntity = buText.Decode(CalcList1[index4]);
          if (buEntity != null)
            buEntityList.Add(buEntity);
        }
        if (buEntityList.Count > 0)
          ;
      }
      ((DrillItem) Item).foamEntities.Add(foamEntities);
    }
  }

  public abstract void m001B91();

  public DrillJobEventArg()
  {
    ((DrillItem) this).DrawAll = false;
    ((DrillItem) this).DeleteSort = false;
    ((DrillItem) this).DeleteTool = false;
    ((DrillItem) this).DrawPreview = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
