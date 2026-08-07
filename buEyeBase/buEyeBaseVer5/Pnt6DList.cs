// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Pnt6DList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class Pnt6DList
{
  public bool PlungeEntitiesEnable;
  public bool LeadInEntitiesEnable;

  public Pnt6DList()
  {
    ((ToolBase5) this).MinLength = 0.0;
    ((ToolBase5) this).MaxLength = 0.0;
    ((ToolBase5) this).Feed = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public Pnt6DList(double minlen, double maxlen, double feed)
  {
    ((ToolBase5) this).MinLength = 0.0;
    ((ToolBase5) this).MaxLength = 0.0;
    ((ToolBase5) this).Feed = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ToolBase5) this).MinLength = minlen;
    ((ToolBase5) this).MaxLength = maxlen;
    ((ToolBase5) this).Feed = feed;
  }
}
