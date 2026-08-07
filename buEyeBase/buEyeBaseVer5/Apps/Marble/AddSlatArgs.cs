// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.AddSlatArgs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class AddSlatArgs
{
  public double RoughSurfOffset;
  public double RoughDevideLen;
  public double RoughVerticalDevideLen;
  public double RoughMinZ;
  public double RoughLeadIn;

  public static ArrayList ToDef(MarbleItemExtend refItem, int Space)
  {
    ArrayList def = new ArrayList();
    screenInfo.ExceptionalVariables.Clear();
    buSerilization5.ClassToString((object) refItem);
    def.AddRange((ICollection) refItem.ToDefAll("", Space, (SerilizationMode5) 1));
    return def;
  }

  public static void Decode(List<string> SL, ref MarbleItemExtend refItem)
  {
    try
    {
      refItem = (MarbleItemExtend) new CounterTopCreateEventArg();
      buSerilization5.Decode(SL, "", (SerilizationMode5) 1, (object) refItem);
      List<List<string>> stringListList = new List<List<string>>();
      List<string> stringList = new List<string>();
    }
    catch (Exception ex)
    {
    }
  }
}
