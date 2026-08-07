// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopPocketData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopPocketData : buSerilization5
{
  public double FinishCutForwardFeed;
  public double FinishCutBackwardFeed;
  public double FinishSafeDis;
  public double FinishRapid;

  public static void Decode(ArrayList AL, ref MarbleJob refJob)
  {
    try
    {
      refJob = (MarbleJob) new marbleChamferBothSideData();
      List<string> CalcList = new List<string>();
      buStatics.ListToSpecificList("<MarbleJobBase>", "</MarbleJobBase>", false, AL, ref CalcList);
      buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) refJob);
      List<List<string>> stringListList = new List<List<string>>();
      CalcList.Clear();
      buStatics.ListToSpecificList("<MarbleOperations>", "</MarbleOperations>", false, AL, ref CalcList);
      if (CalcList.Count > 0)
      {
        ((MarbleProgramSettings) refJob).Items = new List<MarbleItem>();
        marbleMaterialType.Decode(CalcList, ref ((MarbleProgramSettings) refJob).Items);
      }
      CalcList.Clear();
    }
    catch (Exception ex)
    {
    }
  }

  public abstract void m001FA9();

  public marbleCountertopPocketData()
  {
    // ISSUE: unable to decompile the method.
  }
}
