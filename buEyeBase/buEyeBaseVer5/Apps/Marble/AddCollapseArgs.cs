// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.AddCollapseArgs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class AddCollapseArgs
{
  public double RoughLeadOut;
  public double RoughStep;

  public static void Decode(List<string> SL, ref List<MarbleItemExtend> refItes)
  {
    try
    {
      refItes = new List<MarbleItemExtend>();
      if (SL.Count <= 0)
        return;
      List<List<string>> CalcList = new List<List<string>>();
      buStatics.ListToSpecificList("<MarbleVacuumCut>", "</MarbleVacuumCut>", true, SL, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        MarbleItemExtend refItem = (MarbleItemExtend) new CounterTopCreateEventArg();
        AddSlatArgs.Decode(CalcList[index], ref refItem);
        refItes.Add(refItem);
        CalcList[index].Clear();
      }
      CalcList.Clear();
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    return $"Point: {((MarbleMachineSimultionSettings) this).ExtendPoint.ToString()} , Len: {((MarbleMachineSimultionSettings) this).ExtendLength.ToString()}";
  }
}
