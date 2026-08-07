// Decompiled with JetBrains decompiler
// Type: ns1.Class14
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
namespace ns1;

internal class Class14
{
  private static readonly string string_0 = "1";
  private static readonly string string_1 = "38";
  internal static readonly byte[] byte_0 = (byte[]) null;
  internal static readonly Dictionary<int, string> dictionary_0;
  internal static readonly object object_0 = new object();
  internal static readonly bool bool_0 = false;
  private static readonly int int_0 = 0;

  public static string smethod_0(int int_1) => Class14.Class15.smethod_0(int_1);

  static Class14()
  {
    if (Class14.string_0 == "1")
    {
      Class14.bool_0 = true;
      Class14.dictionary_0 = new Dictionary<int, string>();
    }
    Class14.int_0 = Convert.ToInt32(Class14.string_1);
    using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{e1d240fa-e10d-4c46-a4bd-19e42daa2ad2}"))
    {
      int int32 = Convert.ToInt32(manifestResourceStream.Length);
      byte[] numArray = new byte[int32];
      manifestResourceStream.Read(numArray, 0, int32);
      Class14.byte_0 = Class5.smethod_134(numArray);
    }
  }

  public static class Class15
  {
    public static string smethod_0(int int_0)
    {
      int_0 ^= 107396847;
      int_0 -= Class14.int_0;
      return !Class14.bool_0 ? Class5.smethod_168(int_0) : Class5.smethod_179(int_0);
    }
  }
}
