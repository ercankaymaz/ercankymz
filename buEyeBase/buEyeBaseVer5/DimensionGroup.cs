// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.DimensionGroup
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class DimensionGroup : buSerilization5
{
  public List<buEntityList> TempEntities;
  public buEntityList Text;
  public buEntityList Solid;
  public static byte f000121;

  public static ArrayList ToDefGroup(buEntitiesGroup Group, int Space, string refChar = "")
  {
    ArrayList AL = new ArrayList();
    buEntitiesGroup.ToDefGroup(Group, Space, ref AL, refChar);
    return AL;
  }

  public static void Decode(List<string> SL, ref buEntitiesGroup refEntityGroup, string refChar = "")
  {
    try
    {
      List<string> CalcList1 = new List<string>();
      buStatics.ListToSpecificList($"<buEntitiesGroupData{refChar}>", $"</buEntitiesGroupData{refChar}>", true, SL, ref CalcList1);
      if (CalcList1.Count > 1)
      {
        SL.Clear();
        SL.AddRange((IEnumerable<string>) CalcList1);
      }
      if (SL.Count < 2)
        return;
      refEntityGroup = new buEntitiesGroup();
      List<string> stringList = new List<string>();
      List<string> CalcList2 = new List<string>();
      List<List<string>> stringListList = new List<List<string>>();
      buStatics.ListToSpecificList("<buEntitiesGroupOutside>", "</buEntitiesGroupOutside>", true, SL, ref CalcList2);
      buLineCam.Decode(CalcList2, ref refEntityGroup.Outside);
      CalcList2.Clear();
      List<string> CalcList3 = new List<string>();
      stringListList.Clear();
      List<List<string>> CalcList4 = new List<List<string>>();
      buStatics.ListToSpecificList("<buEntitiesGroupOpenEntities>", "</buEntitiesGroupOpenEntities>", true, SL, ref CalcList3);
      buStatics.ListToSpecificList("<buEntitiesGroupOpenEntitiesItem>", "</buEntitiesGroupOpenEntitiesItem>", true, CalcList3, ref CalcList4);
      if (CalcList4.Count > 0)
        refEntityGroup.OpenEntities = new List<buEntityList>();
      for (int index = 0; index <= CalcList4.Count - 1; ++index)
      {
        buEntityList refEntity = (buEntityList) new buArcCam();
        buLineCam.Decode(CalcList4[index], ref refEntity);
        refEntityGroup.OpenEntities.Add(refEntity);
      }
      CalcList3.Clear();
      List<string> CalcList5 = new List<string>();
      CalcList4.Clear();
      CalcList4 = new List<List<string>>();
      buStatics.ListToSpecificList("<buEntitiesGroupInside>", "</buEntitiesGroupInside>", true, SL, ref CalcList5);
      buStatics.ListToSpecificList("<buEntitiesGroupInsideItem>", "</buEntitiesGroupInsideItem>", true, CalcList5, ref CalcList4);
      if (CalcList4.Count > 0)
        refEntityGroup.Inside = new List<buEntityList>();
      for (int index = 0; index <= CalcList4.Count - 1; ++index)
      {
        buEntityList refEntity = (buEntityList) new buArcCam();
        buLineCam.Decode(CalcList4[index], ref refEntity);
        refEntityGroup.Inside.Add(refEntity);
      }
      CalcList5.Clear();
      List<string> CalcList6 = new List<string>();
      CalcList4.Clear();
      CalcList4 = new List<List<string>>();
      buStatics.ListToSpecificList("<buEntitiesGroupText>", "</buEntitiesGroupText>", true, SL, ref CalcList6);
      buLineCam.Decode(CalcList6, ref ((DimensionGroup) refEntityGroup).Text);
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    string str = "Outside: " + ((\u0084.\u0001) ((buEntitiesGroup) this).Outside).Entities.Count.ToString();
    if (((buEntitiesGroup) this).Inside != null)
      str = $"{str} - Inside: {((buEntitiesGroup) this).Inside.Count.ToString()}";
    if (((buEntitiesGroup) this).OpenEntities != null)
      str = $"{str} - Open: {((buEntitiesGroup) this).OpenEntities.Count.ToString()}";
    if (this.Text != null)
      str = $"{str} - Text: {((\u0084.\u0001) this.Text).Entities.Count.ToString()}";
    if (this.Solid != null)
      str = $"{str} - Solid: {((\u0084.\u0001) this.Solid).Entities.Count.ToString()}";
    return str;
  }

  public abstract void m0000BF();
}
