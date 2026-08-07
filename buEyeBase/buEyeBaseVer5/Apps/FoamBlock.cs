// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamBlock
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamBlock : buSerilization5
{
  public static byte f003B4F;
  public double XPosition;
  public double LeftDistance;
  public double LeftAngle;
  public double RightDistance;
  public double RightAngle;
  public double UpDistance;
  public int Index;
  public bool Enable;
  public RollerBendMoveCommand Command;
  public Point3D Position;
  public static byte f003B5A;
  public int SimStep;
  public bool StepRun;
  public double CircleDiameter;
  public double CircleLength;
  public double CircleThickness;
  public double RectangleRadius;
  public double RectangleWidth;
  public double RectangleHeight;

  public static ArrayList ToDef(ProfileJob Item, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Item.ToDefAll("", 2, (SerilizationMode5) 1).ToArray());
    def.RemoveAt(def.Count - 1);
    def.AddRange((ICollection) PanelCutTempVars.ToDef(((ProfileSettings) Item).Items, Space + 2));
    def.Add((object) (str + "</ProfileJob>"));
    return def;
  }

  public static void Decode(List<string> AL, ref ProfileJob Job)
  {
    Job = (ProfileJob) new PanelDonePart();
    List<List<string>> CalcList = new List<List<string>>();
    buStatics.ListToSpecificList("<ProfileJob>", "</ProfileJob>", true, AL, ref CalcList);
    if (CalcList.Count <= 0)
      return;
    ArrayList AL1 = new ArrayList();
    AL1.AddRange((ICollection) CalcList[0].ToArray());
    buSerilization5.Decode(AL1, "", (SerilizationMode5) 1, (object) Job);
    List<List<string>> stringListList = new List<List<string>>();
    buMarbleCalc.Decode(AL1, ref ((ProfileSettings) Job).Items);
  }

  public override string ToString() => ((FoamItem) this).Name.ToString();

  public abstract void m001AAC();

  public FoamBlock()
  {
    // ISSUE: unable to decompile the method.
  }
}
