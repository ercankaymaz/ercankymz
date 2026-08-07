// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationText
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationText : ProfileOperation
{
  public bool MirrorEnable;
  public string OutterContourLayerName;
  public double LastPartWidth;
  public double LastPartHeight;
  public int LastPartQuantity;
  public new static List<string> Captions;

  public static void Copy(List<buNestingMaterials> Base, ref List<buNestingMaterials> Copied)
  {
    Copied.Clear();
    Copied = new List<buNestingMaterials>();
    for (int index = 0; index <= Base.Count - 1; ++index)
    {
      buNestingMaterials nestingMaterials = (buNestingMaterials) new ProfileOperationFreeDraw(Base[index]);
      Copied.Add(nestingMaterials);
    }
  }

  public static List<buNestingMaterials> Copy(List<buNestingMaterials> Base)
  {
    List<buNestingMaterials> nestingMaterialsList = new List<buNestingMaterials>();
    for (int index = 0; index <= Base.Count - 1; ++index)
    {
      buNestingMaterials nestingMaterials = (buNestingMaterials) new ProfileOperationFreeDraw(Base[index]);
      nestingMaterialsList.Add(nestingMaterials);
    }
    return nestingMaterialsList;
  }

  public static ArrayList ToDef(List<buNestingMaterials> Mats, int Space)
  {
    string str1 = new string(' ', Space);
    string str2 = new string(' ', Space + 2);
    string str3 = new string(' ', Space + 6);
    string str4 = new string(' ', Space + 8);
    ArrayList def = new ArrayList();
    def.Add((object) (str1 + "<nestingMaterials>"));
    for (int index = 0; index <= Mats.Count - 1; ++index)
      def.AddRange((ICollection) Mats[index].ToDefAll("", 2 + Space, (SerilizationMode5) 1));
    def.Add((object) (str1 + "</nestingMaterials>"));
    return def;
  }
}
