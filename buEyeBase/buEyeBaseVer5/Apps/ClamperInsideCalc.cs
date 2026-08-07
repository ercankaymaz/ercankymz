// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ClamperInsideCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ClamperInsideCalc : buSerilization5
{
  public double Z1Position;
  public double Z2Position;
  public double Z3Position;
  public double SPosition;
  public bool X1ClamperDown;
  public bool X2ClamperDown;
  public bool MaterialZeroDown;
  public int LineIndex;
  public int Tool1;
  public Point3D Tool1OriginalPos;

  public static void Decode(List<string> AL, ref FoamBlock Item)
  {
    Item = (FoamBlock) new DrillUpdateArg();
    buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) Item);
    List<List<string>> stringListList = new List<List<string>>();
    List<string> CalcList1 = new List<string>();
    List<List<string>> CalcList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<Patterns>", "</Patterns>", false, AL, ref CalcList1);
    buStatics.ListToSpecificList("<FoamPattern>", "</FoamPattern>", true, CalcList1, ref CalcList2);
    for (int index = 0; index <= CalcList2.Count - 1; ++index)
    {
      FoamPattern foamPattern = (FoamPattern) new DrillJobCreateEventHandler();
      DrillJobEventArg.Decode(CalcList2[index], ref foamPattern);
      ((DrillItemBase) Item).Pattern.Add(foamPattern);
    }
    CalcList1.Clear();
    CalcList2.Clear();
    AL.Clear();
    stringListList.Clear();
  }

  public static ArrayList ToDef(FoamBlock refItem, int Space)
  {
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) refItem.ToDefAll("", Space, (SerilizationMode5) 1));
    if (def.Count > 0)
    {
      string str = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<Patterns>"));
      for (int index = 0; index <= ((DrillItemBase) refItem).Pattern.Count - 1; ++index)
        def.AddRange((ICollection) DrillJobCreateEventHandler.ToDef(((DrillItemBase) refItem).Pattern[index], Space + 4));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</Patterns>"));
      def.Add((object) str);
    }
    return def;
  }

  public override string ToString()
  {
    return $"{((DrillCalcItem) this).BlockName.ToString()} - TopZ: {((DrillItemBase) this).TopZ.ToString()} - BottomZ: {((DrillItemBase) this).BottomZ.ToString()}";
  }
}
