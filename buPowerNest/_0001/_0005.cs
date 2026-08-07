// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0001;

internal class \u0005
{
  internal static readonly \u0003.\u0001.\u0001 \u0001;
  private static readonly string \u0001;
  private static readonly string \u0002;
  internal static readonly byte[] \u0001;
  internal static readonly Dictionary<int, string> \u0001;
  internal static readonly object \u0001;
  internal static readonly bool \u0001;

  public \u0005()
    : this()
  {
  }

  public static string \u0001([In] int obj0) => \u0005.\u0002.\u0001(obj0);

  public static class \u0001
  {
    static \u0001()
    {
      \u0001.\u0005.\u0001 = "1";
      \u0001.\u0005.\u0002 = "246";
      \u0001.\u0005.\u0001 = (byte[]) null;
      \u0001.\u0005.\u0001 = new object();
      \u0001.\u0005.\u0001 = false;
      \u0008.\u0001.\u0001 = 0;
      if (\u0001.\u0005.\u0001 == "1")
      {
        \u0001.\u0005.\u0001 = true;
        \u0001.\u0005.\u0001 = new Dictionary<int, string>();
      }
      \u0008.\u0001.\u0001 = Convert.ToInt32(\u0001.\u0005.\u0002);
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{83af42fd-9d96-4a96-ab01-e96d3dd2da63}"))
      {
        int int32 = Convert.ToInt32(manifestResourceStream.Length);
        byte[] buffer = new byte[int32];
        manifestResourceStream.Read(buffer, 0, int32);
        \u0001.\u0005.\u0001 = \u0005.\u0003.\u0001(buffer);
      }
    }
  }
}
