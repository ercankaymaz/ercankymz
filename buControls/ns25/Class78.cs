// Decompiled with JetBrains decompiler
// Type: ns25.Class78
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable disable
namespace ns25;

internal sealed class Class78
{
  private static Assembly assembly_0;
  private static string[] string_0 = new string[0];

  internal static void smethod_0()
  {
    try
    {
      AppDomain.CurrentDomain.ResourceResolve += new ResolveEventHandler(Class78.smethod_1);
    }
    catch
    {
    }
  }

  private static Assembly smethod_1(object object_0, ResolveEventArgs resolveEventArgs_0)
  {
    if (Class78.assembly_0 == (Assembly) null)
    {
      lock (Class78.string_0)
      {
        Class78.assembly_0 = Assembly.Load("{a0570de0-cedc-49f0-a923-ff2fbde6bca7}, PublicKeyToken=3e56350693f7355e");
        if (Class78.assembly_0 != (Assembly) null)
          Class78.string_0 = Class78.assembly_0.GetManifestResourceNames();
      }
    }
    if (!((IEnumerable<string>) Class78.string_0).Contains<string>(resolveEventArgs_0.Name))
      return (Assembly) null;
    Assembly executingAssembly = Assembly.GetExecutingAssembly();
    return !resolveEventArgs_0.RequestingAssembly.Equals((object) executingAssembly) ? (Assembly) null : Class78.assembly_0;
  }
}
