// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationCircle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationCircle : ProfileOperation
{
  public double EdgeRightThickness;

  public static void Copy(List<buNestingSheet> Base, ref List<buNestingSheet> Copied)
  {
    Copied.Clear();
    Copied = new List<buNestingSheet>();
    for (int index = 0; index <= Base.Count - 1; ++index)
    {
      buNestingSheet buNestingSheet = (buNestingSheet) new ProfileOperation(Base[index]);
      Copied.Add(buNestingSheet);
    }
  }

  public static ArrayList ToDef(List<buNestingSheet> Sheets, int Space, string Chars = "")
  {
    string str1 = new string(' ', Space);
    string str2 = new string(' ', Space + 2);
    string str3 = new string(' ', Space + 6);
    string str4 = new string(' ', Space + 8);
    ArrayList def = new ArrayList();
    def.Add((object) $"{buImage5.SpaceChar(Space)}<NestingSheets{Chars}>");
    for (int index = 0; index <= Sheets.Count - 1; ++index)
    {
      def.AddRange((ICollection) Sheets[index].ToDefAll("", 2 + Space, (SerilizationMode5) 1));
      string str5 = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      if (((\u0084.\u0001) ((ProfileItemCalc) Sheets[index]).EntitiesGroup.Outside).Entities.Count > 0)
        def.AddRange((ICollection) DimensionGroup.ToDefGroup(((ProfileItemCalc) Sheets[index]).EntitiesGroup, Space + 4));
      def.Add((object) str5);
    }
    def.Add((object) $"{buImage5.SpaceChar(Space)}</NestingSheets{Chars}>");
    return def;
  }

  public static void Decode(ArrayList AL, ref List<buNestingSheet> Sheets, string Chars = "")
  {
    Sheets.Clear();
    Sheets = new List<buNestingSheet>();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList($"<buNestingSheet{Chars}>", $"</buNestingSheet{Chars}>", true, AL, ref CalcList1);
    for (int index = 0; index <= CalcList1.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) CalcList1[index].ToArray());
      buNestingSheet buNestingSheet = (buNestingSheet) new ProfileOperation();
      buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) buNestingSheet);
      List<string> CalcList2 = new List<string>();
      buStatics.ListToSpecificList("<buEntitiesGroupData>", "</buEntitiesGroupData>", true, arrayList, ref CalcList2);
      DimensionGroup.Decode(CalcList2, ref ((ProfileItemCalc) buNestingSheet).EntitiesGroup);
      ((GProfileOperationGroup) buCall.\u0001).CreatePointAndSolidFromEntityGroup(ref ((ProfileItemCalc) buNestingSheet).EntitiesGroup);
      Sheets.Add(buNestingSheet);
    }
  }
}
