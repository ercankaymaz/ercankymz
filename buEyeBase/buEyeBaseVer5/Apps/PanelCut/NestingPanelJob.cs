// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.NestingPanelJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class NestingPanelJob : buSerilization5
{
  public double EllipseWidth;
  public double EllipseHeight;
  public double EllipseAngle;
  public Color EllipseColor;
  public double EllipseThickness;
  public static byte f004543;
  public double NotchDepth;
  public double NotchWidth;
  public double NotchHeight;

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

  public override string ToString() => ((ProfileSettings) this).Name.ToString();
}
