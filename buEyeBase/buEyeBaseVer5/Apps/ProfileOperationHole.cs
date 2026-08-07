// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationHole
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationHole : ProfileOperation
{
  public bool GetInternalEntitiesFromConnectedOutter;
  public double MultiplePArtAddOusideFilterLength;
  public new static List<string> Captions;
  public static byte f004293;
  public Color SelectionColor;
  public bool UseLayerForSelection;

  public static void Decode(ArrayList AL, ref List<buNestingPart> Parts)
  {
    Parts.Clear();
    Parts = new List<buNestingPart>();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<buNestingPart>", "</buNestingPart>", true, AL, ref CalcList1);
    for (int index = 0; index <= CalcList1.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) CalcList1[index].ToArray());
      buNestingPart buNestingPart = (buNestingPart) new ProfileOperationBarrel();
      buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) buNestingPart);
      List<string> CalcList2 = new List<string>();
      buStatics.ListToSpecificList("<buEntitiesGroupData>", "</buEntitiesGroupData>", true, arrayList, ref CalcList2);
      DimensionGroup.Decode(CalcList2, ref ((ProfileOperationRectangle) buNestingPart).EntitiesGroup);
      ((GProfileOperationGroup) buCall.\u0001).CreatePointAndSolidFromEntityGroup(ref ((ProfileOperationRectangle) buNestingPart).EntitiesGroup, false);
      Parts.Add(buNestingPart);
    }
  }

  static ProfileOperationHole() => ProfileOperationRectangle.Captions = new List<string>();

  public ProfileOperationHole()
  {
    // ISSUE: unable to decompile the method.
  }
}
