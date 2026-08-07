// Decompiled with JetBrains decompiler
// Type: ns13.Class13
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable disable
namespace ns13;

internal class Class13
{
  private static Assembly assembly_0;
  private static string[] string_0 = new string[0];

  internal static void smethod_0()
  {
    try
    {
      AppDomain.CurrentDomain.ResourceResolve += new ResolveEventHandler(Class13.smethod_1);
    }
    catch
    {
    }
  }

  private static Assembly smethod_1(object object_0, ResolveEventArgs resolveEventArgs_0)
  {
    if (Class13.assembly_0 == (Assembly) null)
    {
      lock (Class13.string_0)
      {
        Class13.assembly_0 = Assembly.Load("{0968f0f6-5c85-4515-a556-37e263655d72}, PublicKeyToken=3e56350693f7355e");
        if (Class13.assembly_0 != (Assembly) null)
          Class13.string_0 = Class13.assembly_0.GetManifestResourceNames();
      }
    }
    if (!((IEnumerable<string>) Class13.string_0).Contains<string>(resolveEventArgs_0.Name))
      return (Assembly) null;
    Assembly executingAssembly = Assembly.GetExecutingAssembly();
    return !resolveEventArgs_0.RequestingAssembly.Equals((object) executingAssembly) ? (Assembly) null : Class13.assembly_0;
  }
}
