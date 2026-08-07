// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using \u0006;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0001;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal sealed class \u0004 : Attribute
{
  private static Assembly \u0001([In] object obj0, [In] ResolveEventArgs obj1)
  {
    if (\u0005.\u0001.\u0001 == (Assembly) null)
    {
      lock (\u0005.\u0002.\u0001)
      {
        \u0005.\u0001.\u0001 = Assembly.Load("{1f74041b-e77e-41b0-ba17-174625b27b0f}, PublicKeyToken=3e56350693f7355e");
        if (\u0005.\u0001.\u0001 != (Assembly) null)
          \u0005.\u0002.\u0001 = \u0005.\u0001.\u0001.GetManifestResourceNames();
      }
    }
    if (!((IEnumerable<string>) \u0005.\u0002.\u0001).Contains<string>(obj1.Name))
      return (Assembly) null;
    Assembly executingAssembly = Assembly.GetExecutingAssembly();
    return !obj1.RequestingAssembly.Equals((object) executingAssembly) ? (Assembly) null : \u0005.\u0001.\u0001;
  }
}
