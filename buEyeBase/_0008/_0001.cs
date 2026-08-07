// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;

#nullable disable
namespace \u0008;

internal class \u0001
{
  public entityGroupType GroupType;
  public entityToolType ToolType;
  public ClockDirectionType Direction;
  public entityInOutDirectionType InOutType;

  public override string ToString()
  {
    // ISSUE: explicit non-virtual call
    // ISSUE: explicit non-virtual call
    return $"ArrowLinearPath - S: {__nonvirtual (((LinearPath) this).StartPoint).ToString()} - E: {__nonvirtual (((LinearPath) this).EndPoint).ToString()} - Ref Ent : {((buClipper) this).get_RefEntity().ToString()}";
  }
}
