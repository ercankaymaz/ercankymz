// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0008;

internal class \u0005
{
  internal static Dictionary<string, Assembly> \u0001;
  public string \u0001;
  public Version \u0001;
  public string \u0002;
  public string \u0003;
  private static ModuleHandle \u0001;
  private static char[] \u0001;

  internal static void \u0001()
  {
    try
    {
      AppDomain.CurrentDomain.ResourceResolve += new ResolveEventHandler(\u0005.\u0001);
    }
    catch
    {
    }
  }

  private static Assembly \u0001([In] object obj0, [In] ResolveEventArgs obj1)
  {
    if (\u0007.\u0001.\u0001 == (Assembly) null)
    {
      lock (\u0007.\u0001.\u0001)
      {
        \u0007.\u0001.\u0001 = Assembly.Load("{46f9ed2e-10a8-4249-9811-829c3ace2f0f}, PublicKeyToken=3e56350693f7355e");
        if (\u0007.\u0001.\u0001 != (Assembly) null)
          \u0007.\u0001.\u0001 = \u0007.\u0001.\u0001.GetManifestResourceNames();
      }
    }
    if (!((IEnumerable<string>) \u0007.\u0001.\u0001).Contains<string>(obj1.Name))
      return (Assembly) null;
    Assembly executingAssembly = Assembly.GetExecutingAssembly();
    return !obj1.RequestingAssembly.Equals((object) executingAssembly) ? (Assembly) null : \u0007.\u0001.\u0001;
  }

  public static class \u0001
  {
  }
}
