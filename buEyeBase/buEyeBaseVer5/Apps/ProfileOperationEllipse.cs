// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationEllipse
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationEllipse : ProfileOperation
{
  public bool CheckLinearPathToBackwardToFindClosed;
  public nestingPartMainDrawAddModes PartMainAddType;
  public Color PartListPreviewBackColor;

  public static void Copy(buNestingPart Base, ref buNestingPart Copied)
  {
    Copied = (buNestingPart) new ProfileOperationBarrel(Base);
  }

  public static void Copy(List<buNestingPart> Base, ref List<buNestingPart> Copied)
  {
    Copied.Clear();
    Copied = new List<buNestingPart>();
    for (int index = 0; index <= Base.Count - 1; ++index)
    {
      buNestingPart buNestingPart = (buNestingPart) new ProfileOperationBarrel(Base[index]);
      Copied.Add(buNestingPart);
    }
  }

  public static ArrayList ToDef(List<buNestingPart> Parts, int Space)
  {
    string str1 = new string(' ', Space);
    string str2 = new string(' ', Space + 2);
    string str3 = new string(' ', Space + 6);
    string str4 = new string(' ', Space + 8);
    ArrayList def = new ArrayList();
    def.Add((object) (str1 + "<NestingParts>"));
    for (int index = 0; index <= Parts.Count - 1; ++index)
    {
      def.AddRange((ICollection) Parts[index].ToDefAll("", 4 + Space, (SerilizationMode5) 1));
      string str5 = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      if (((\u0084.\u0001) ((ProfileOperationRectangle) Parts[index]).EntitiesGroup.Outside).Entities.Count > 0)
        def.AddRange((ICollection) DimensionGroup.ToDefGroup(((ProfileOperationRectangle) Parts[index]).EntitiesGroup, Space + 4));
      def.Add((object) str5);
    }
    def.Add((object) (str1 + "</NestingParts>"));
    return def;
  }
}
