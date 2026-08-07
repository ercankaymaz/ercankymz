// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.CamCreateSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class CamCreateSettings : buSerilization5
{
  public int RefIndex;
  public bool CamSelected;
  public bool CamSelectable;

  public CamCreateSettings([In] long obj0, [In] ulong obj1)
  {
    ((DoorRuntimeSettings) this).\u0001 = obj1;
    ((DoorRuntimeSettings) this).\u0001 = obj0;
  }

  [SpecialName]
  public static bool \u0001([In] \u000E.\u0001 obj0, [In] \u000E.\u0001 obj1)
  {
    return (ValueType) obj0 == (ValueType) obj1 || ((ValueType) obj0 == null ? 1 : ((ValueType) obj1 == null ? 1 : 0)) == 0 && obj0.\u0001 == obj1.\u0001 && (long) obj0.\u0001 == (long) obj1.\u0001;
  }
}
