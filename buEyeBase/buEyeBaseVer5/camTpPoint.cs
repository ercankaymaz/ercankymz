// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camTpPoint
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camTpPoint : buSerilization5
{
  public bool Used;
  public actionTypeBU Action;
  public object Obj1;
  public object Obj2;
  public static byte f000171;
  public ArrayList PreCodes;
  public ArrayList AfterCodes;
  public List<TpPnt9D> PrePoints;
  public List<TpPnt9D> AfterPoints;
  public List<TpPnt9D> Points;
  public Pnt9D GCodeOffset;
  public string Command;
  public int Type;
  public int Mode;
  public int NumberOfPlungeMovement;
  public int NumberOfLeaveMovement;
  public double Feed;
  public bool ForceWriteAllCoordinate;
  public bool isInside;
  public bool Used;

  public static void CopyCam(List<camTp> RefCam, ref List<camTp> CopiedCam)
  {
    CopiedCam.Clear();
    CopiedCam = new List<camTp>();
    for (int index = 0; index <= RefCam.Count - 1; ++index)
    {
      camTp camTp = new camTp(RefCam[index]);
      CopiedCam.Add(camTp);
    }
  }

  public ArrayList ToDefAll(int Space)
  {
    string str = new string(' ', Space);
    ArrayList defAll = new ArrayList();
    screenInfo.ExceptionalVariables.Clear();
    screenInfo.ExceptionalVariables.Add("Shape");
    defAll.Add((object) (str + "<camTp>"));
    defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, (SerilizationMode5) 1).ToArray());
    defAll.Add((object) (str + "</camTp>"));
    return defAll;
  }

  public static eEntities Decode(List<string> AL, string Char, SerilizationMode5 Mode)
  {
    List<string> CalcList = new List<string>();
    List<string> stringList = new List<string>();
    eEntities eEntities = new eEntities();
    string str = "";
    buStatics.ListToSpecificList($"<{eEntities.GetType().Name}{Char}>", $"</{eEntities.GetType().Name}{Char}>", AL, ref CalcList);
    if (CalcList.Count > 0)
      str = CalcList[0];
    if (str.Length == 0 & AL.Count > 0)
      str = AL[0];
    if (str.Length > 0)
      ;
    return eEntities;
  }
}
