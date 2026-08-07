// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace \u001E;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal class \u0002 : Attribute
{
  static void \u0001([In] IntPoint obj0, [In] buClipperBase obj1, [In] ref bool obj2)
  {
    if (obj2)
    {
      if ((obj0.X > 4611686018427387903L /*0x3FFFFFFFFFFFFFFF*/ || obj0.Y > 4611686018427387903L /*0x3FFFFFFFFFFFFFFF*/ || -obj0.X > 4611686018427387903L /*0x3FFFFFFFFFFFFFFF*/ ? 1 : (-obj0.Y > 4611686018427387903L /*0x3FFFFFFFFFFFFFFF*/ ? 1 : 0)) != 0)
        throw new PipeBendSettings("Coordinate outside allowed range");
    }
    else
    {
      if ((obj0.X > 1073741823L /*0x3FFFFFFF*/ || obj0.Y > 1073741823L /*0x3FFFFFFF*/ || -obj0.X > 1073741823L /*0x3FFFFFFF*/ ? 1 : (-obj0.Y > 1073741823L /*0x3FFFFFFF*/ ? 1 : 0)) == 0)
        return;
      obj2 = true;
      \u0002.\u0001(obj0, obj1, ref obj2);
    }
  }
}
