// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.PolyTree
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buClipperLib;

public class PolyTree : PolyNode
{
  public static byte f003875;

  public override string ToString()
  {
    // ISSUE: explicit non-virtual call
    // ISSUE: explicit non-virtual call
    return $"UpperLine - S : {__nonvirtual (((Line) this).StartPoint).ToString()} - E : {__nonvirtual (((Line) this).EndPoint).ToString()} - {this.get_sortDirection().ToString()}";
  }

  [CompilerGenerated]
  [SpecialName]
  public double get_DirArrowDistances() => ((Router3AXItem) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_DirArrowDistances(double value) => ((Router3AXItem) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoLength() => ((Router3AXItem) this).\u0002;

  public int Total
  {
    [SpecialName] get
    {
      int count = ((DoorRuntimeSettings) this).\u0001.Count;
      if ((count <= 0 ? 0 : (((DoorRuntimeSettings) this).\u0001[0] != ((DoorRuntimeSettings) this).\u0001[0] ? 1 : 0)) != 0)
        --count;
      return count;
    }
  }
}
