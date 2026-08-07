// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.PanelCutMove
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

public class PanelCutMove : buSerilization5
{
  public double RoundRectangleWidth;
  public double RoundRectangleHeight;
  public double RoundRectangleRadius;
  public double RoundRectangleAngle;
  public Color RoundRectangleColor;
  public double RoundRectangleThickness;
  public static byte f004529;
  public double BarrelLength;
  public double BarrelDiameter;
  public double BarrelWidth;
  public double BarrelAngle;
  public Color BarrelColor;
  public double BarrelThickness;

  public static ArrayList ToDef(List<ProfileCalculatedJob> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) PanelCutMove.ToDef(Items[index], Space).ToArray());
      def.AddRange((ICollection) c);
    }
    return def;
  }

  public static ArrayList ToDef(ProfileCalculatedJob Item, int Space)
  {
    string str = new string(' ', Space);
    return new ArrayList();
  }

  public static void Decode(List<string> AL, ref ProfileJob Job)
  {
    Job = (ProfileJob) new PanelDonePart();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<ProfileJob>", "</ProfileJob>", true, AL, ref CalcList1);
    if (CalcList1.Count <= 0)
      return;
    ArrayList arrayList = new ArrayList();
    arrayList.AddRange((ICollection) CalcList1[0].ToArray());
    buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) Job);
    List<List<string>> CalcList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<ProfileItem>", "</ProfileItem>", true, arrayList, ref CalcList2);
    buMarbleCalc.Decode(arrayList, ref ((ProfileSettings) Job).Items);
  }
}
